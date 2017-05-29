using System;
using System.Linq;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlServerCe;
using System.Text.RegularExpressions;
using System.Collections;


namespace QHMobile
{
    public partial class EmptyBin : Form
    {
        protected DataTable dt;
        protected System.Net.NetworkCredential nc = new System.Net.NetworkCredential(WebServiceInstants.GetURL(ServiceType.userName).ToString(), WebServiceInstants.GetURL(ServiceType.password).ToString(), WebServiceInstants.GetURL(ServiceType.domain).ToString());
        string staffdim, username, userlevel;
        String menuValue = "1"; //0= Find Empty Bin, 1= Find Bin Content 2= Fin nin content by Item
        String binOnMemory = "";
        public EmptyBin(string userd, string staffd, string uleveld)
        {
            InitializeComponent();
            staffdim = staffd;
            username = userd;
            userlevel = uleveld;
            

            lblStaffName.Text = staffdim + "/ Role:" + userlevel;
            
            DateTime fDate = DateTime.Now.AddMonths(-1);
            txtFromDate.Text = fDate.ToString("MM/dd/yy");
            txtToDate.Text = DateTime.Today.ToString("MM/dd/yy");

            lblTodate.Visible = false;
            txtToDate.Visible = false;
            lblFromDate.Visible = false;
            txtFromDate.Visible = false;

            txtBinNo.Focus();

            BindtoGrid();
        
       }

        private void txtItemNo_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                BindtoGrid();
            }

        }

        private void NoEmptyBinFound()
        {
            Cursor.Current = Cursors.Default;

            lblCount.Text = "(0)";
            gdBins.DataSource = null;
            MessageBox.Show("No empty bin found.");
        }
        private void NoBinContentFound()
        {
            Cursor.Current = Cursors.Default;

            lblCount.Text = "(0)";
            gdBins.DataSource = null;
            MessageBox.Show("No bin found.");
        }

        private void BindtoGrid()
        {
            try
            {
                Cursor.Current = Cursors.WaitCursor;
                if (menuValue == "0") //0= Find Empty Bin
                {
                    dt = new DataTable("EmptyBin");
                    dt.Columns.Add("BinCode");
                    dt.Columns.Add("LocationCode");
                    //dt.Columns.Add("ZoneCode");
                    // dt.Columns.Add("Vendor");
                    //List<BinQH.BinQH> Lbin = new List<QHMobile.BinQH.BinQH>();

                    BinQH.BinQH_Service binserv = new QHMobile.BinQH.BinQH_Service();
                    binserv.Url = WebServiceInstants.GetURL(ServiceType.BinQH);
                    binserv.Credentials = nc;

                    List<BinQH.BinQH_Filter> binFilterArray = new List<QHMobile.BinQH.BinQH_Filter>();

                    //BinQH.BinQH_Filter binFilter = new QHMobile.BinQH.BinQH_Filter();
                    //if (!String.IsNullOrEmpty(txtBinNo.Text.Trim()))
                    //{
                    //    binFilter.Field = QHMobile.BinQH.BinQH_Fields.Code;
                    //    binFilter.Criteria = txtBinNo.Text.Trim();
                    //    binFilterArray.Add(binFilter);
                    //}

                    BinQH.BinQH_Filter EmptyFilter = new QHMobile.BinQH.BinQH_Filter();
                    EmptyFilter.Field = QHMobile.BinQH.BinQH_Fields.Empty;
                    EmptyFilter.Criteria = "1";
                    binFilterArray.Add(EmptyFilter);
                    BinQH.BinQH[] BinList = binserv.ReadMultiple(binFilterArray.ToArray(), null, 0);
                    dt.Clear();
                    if (BinList.Length > 0)
                    {
                        for (int i = 0; i < BinList.Length; i++)
                        {
                            Object[] array = new Object[2];
                            array[0] = BinList[i].Code;
                            array[1] = BinList[i].Location_Code;
                            //array[2] = BinList[i].Zone_Code;

                            dt.Rows.Add(array);


                        }
                        lblCount.Text = "(" + BinList.Length.ToString() + ")";
                        gdBins.DataSource = dt;
                        gdBins.TableStyles.Clear();
                        gdBins.TableStyles.Add(DataGridStyle(dt));

                    }
                    else
                    {
                        NoEmptyBinFound();
                    }
                    Cursor.Current = Cursors.Default;
                }//End Empty Bin
                if (menuValue == "1") //1= Find Bin Content
                {
                    dt = new DataTable("BinContent");
                    dt.Columns.Add("LocationCode");
                    dt.Columns.Add("BinCode");
                    dt.Columns.Add("ItemNo");
                    dt.Columns.Add("Description");
                    dt.Columns.Add("Description2");
                    dt.Columns.Add("Quantity");
                    dt.Columns.Add("VendorNo");
                    dt.Columns.Add("Receipt Date");
                    dt.Columns.Add("CustomerNo");

                    QHBinContent.QHBinContent_Service qhBinContSev = new QHMobile.QHBinContent.QHBinContent_Service();
                    qhBinContSev.Url = WebServiceInstants.GetURL(ServiceType.QHBinContent);
                    qhBinContSev.Credentials = nc;

                    List<QHBinContent.QHBinContent_Filter> filterarray = new List<QHMobile.QHBinContent.QHBinContent_Filter>();

                    QHBinContent.QHBinContent_Filter filBin = new QHMobile.QHBinContent.QHBinContent_Filter();

                    if (!String.IsNullOrEmpty(txtBinNo.Text.Trim()))
                    {
                        //binFilter.Field = QHMobile.BinQH.BinQH_Fields.Code;
                        //binFilter.Criteria = txtBinNo.Text.Trim();
                        //binFilterArray.Add(binFilter);
                        filBin.Field = QHMobile.QHBinContent.QHBinContent_Fields.Bin_Code;
                        filBin.Criteria = txtBinNo.Text.Trim();
                        filterarray.Add(filBin);
                    }

                    QHBinContent.QHBinContent[] qhBinContent;
                    if (!String.IsNullOrEmpty(txtBinNo.Text.Trim()))
                    {
                        QHBinContent.QHBinContent_Filter filterQty = new QHMobile.QHBinContent.QHBinContent_Filter();
                        filterQty.Field = QHMobile.QHBinContent.QHBinContent_Fields.Quantity;
                        filterQty.Criteria = "<>0";
                        filterarray.Add(filterQty);


                        QHBinContent.QHBinContent_Filter filtVendorName = new QHMobile.QHBinContent.QHBinContent_Filter();
                        filtVendorName.Field = QHMobile.QHBinContent.QHBinContent_Fields.VendorNo;
                        filtVendorName.Criteria = "<>''";
                        //filterarray.Add(filtVendorName);

                        qhBinContent = qhBinContSev.ReadMultiple(filterarray.ToArray(), null, 0);
                        //}
                        //else
                        //{
                        //    //qhBinContent = qhBinContSev.ReadMultiple(filterarray.ToArray(), null, 10);
                        //    qhBinContent = null;//thurein
                        //}
                        dt.Clear();
                        if (qhBinContent.Length > 0)
                        {
                            dt.Clear();
                            for (int i = 0; i < qhBinContent.Length; i++)
                            {
                                //if (!String.IsNullOrEmpty(qhBinContent[i].VendorNo))
                                //{
                                    Object[] array = new Object[9];
                                    array[0] = qhBinContent[i].Location_Code;
                                    array[1] = qhBinContent[i].Bin_Code;
                                    array[2] = qhBinContent[i].Item_No;
                                    if (!String.IsNullOrEmpty(qhBinContent[i].Item_No.Trim()))
                                    {
                                        ItemQH.ItemQH_Service itemsev = new QHMobile.ItemQH.ItemQH_Service();
                                        itemsev.Url = WebServiceInstants.GetURL(ServiceType.ItemQH);
                                        itemsev.Credentials = nc;

                                        ItemQH.ItemQH itemdescription = itemsev.Read(qhBinContent[i].Item_No.ToString());
                                        array[3] = itemdescription.Description;
                                        array[4] = itemdescription.Description_2;
                                    }
                                    else
                                    {
                                        array[3] = "";
                                        array[4] = "";
                                    }
                                    array[5] = qhBinContent[i].Quantity-qhBinContent[i].PDA_Inv_Pick_Quantity;
                                    array[6] = qhBinContent[i].VendorNo;
                                    array[7] = qhBinContent[i].ReceiptDate;
                                    array[8] = qhBinContent[i].CustNo;   
                                    dt.Rows.Add(array);
                                //}
                            }

                            lblCount.Text = "(" + qhBinContent.Length.ToString() + ")";
                            gdBins.DataSource = dt;
                            gdBins.TableStyles.Clear();
                            gdBins.TableStyles.Add(DataGridStyleBinContent(dt));

                        }
                        else
                        {
                            NoBinContentFound();
                        }
                    }
                    Cursor.Current = Cursors.Default;
                }//END Bin Content
                if (menuValue == "2") //1= Find Bin Content by Item
                {
                    dt = new DataTable("BinContent");
                    dt.Columns.Add("LocationCode");
                    dt.Columns.Add("BinCode");
                    dt.Columns.Add("ItemNo");
                    dt.Columns.Add("Description");
                    dt.Columns.Add("Description2");
                    dt.Columns.Add("Quantity");
                    dt.Columns.Add("VendorNo");
                    dt.Columns.Add("Receipt Date");
                    dt.Columns.Add("CustomerNo");

                    QHBinContent.QHBinContent_Service qhBinContSev = new QHMobile.QHBinContent.QHBinContent_Service();
                    qhBinContSev.Url = WebServiceInstants.GetURL(ServiceType.QHBinContent);
                    qhBinContSev.Credentials = nc;

                    List<QHBinContent.QHBinContent_Filter> filterarray = new List<QHMobile.QHBinContent.QHBinContent_Filter>();

                    QHBinContent.QHBinContent_Filter filItem = new QHMobile.QHBinContent.QHBinContent_Filter();

                    if (!String.IsNullOrEmpty(txtBinNo.Text.Trim()))
                    {

                        filItem.Field = QHMobile.QHBinContent.QHBinContent_Fields.Item_No;
                        filItem.Criteria = txtBinNo.Text.Trim();
                        filterarray.Add(filItem);
                    }

                    QHBinContent.QHBinContent[] qhBinContent;
                    if (!String.IsNullOrEmpty(txtBinNo.Text.Trim()))
                    {
                        QHBinContent.QHBinContent_Filter filterQty = new QHMobile.QHBinContent.QHBinContent_Filter();
                        filterQty.Field = QHMobile.QHBinContent.QHBinContent_Fields.Quantity;
                        filterQty.Criteria = "<>0";
                        filterarray.Add(filterQty);

                        //QHBinContent.QHBinContent_Filter filtVendorName = new QHMobile.QHBinContent.QHBinContent_Filter();
                        //filtVendorName.Field = QHMobile.QHBinContent.QHBinContent_Fields.VendorNo;
                        //filtVendorName.Criteria = "<>''";
                        //filterarray.Add(filtVendorName);

                        qhBinContent = qhBinContSev.ReadMultiple(filterarray.ToArray(), null, 0);

                        //else
                        //{
                        //    //qhBinContent = qhBinContSev.ReadMultiple(filterarray.ToArray(), null, 10);
                        //    qhBinContent = null;//thurein
                        //}
                        dt.Clear();
                        if (qhBinContent.Length > 0)
                        {
                            dt.Clear();
                            for (int i = 0; i < qhBinContent.Length; i++)
                            {
                                //if (!String.IsNullOrEmpty(qhBinContent[i].VendorNo))
                                //{

                                    Object[] array = new Object[9];
                                    array[0] = qhBinContent[i].Location_Code;
                                    array[1] = qhBinContent[i].Bin_Code;
                                    array[2] = qhBinContent[i].Item_No;
                                    if (!String.IsNullOrEmpty(qhBinContent[i].Item_No.Trim()))
                                    {
                                        ItemQH.ItemQH_Service itemsev = new QHMobile.ItemQH.ItemQH_Service();
                                        itemsev.Url = WebServiceInstants.GetURL(ServiceType.ItemQH);
                                        itemsev.Credentials = nc;

                                        ItemQH.ItemQH itemdescription = itemsev.Read(qhBinContent[i].Item_No.ToString());
                                        array[3] = itemdescription.Description;
                                        array[4] = itemdescription.Description_2;
                                    }
                                    else
                                    {
                                        array[3] = "";
                                        array[4] = "";
                                    }
                                    array[5] = qhBinContent[i].Quantity - qhBinContent[i].PDA_Inv_Pick_Quantity;
                                    array[6] = qhBinContent[i].VendorNo;
                                    array[7] = qhBinContent[i].ReceiptDate;
                                    array[8] = qhBinContent[i].CustNo;
                                    dt.Rows.Add(array);
                               // }
                            }

                            lblCount.Text = "(" + qhBinContent.Length.ToString() + ")";
                            gdBins.DataSource = dt;
                            gdBins.TableStyles.Clear();
                            gdBins.TableStyles.Add(DataGridStyleBinContent(dt));

                        }
                        else
                        {
                            NoBinContentFound();
                        }
                    }
                    Cursor.Current = Cursors.Default;
                }
                if (menuValue == "3")
                {
                    dt = new DataTable("DailyLoss");
                    dt.Columns.Add("Location");
                    dt.Columns.Add("ItemNo");
                    dt.Columns.Add("Description");
                    dt.Columns.Add("Description2");
                    dt.Columns.Add("Quantity");
                    dt.Columns.Add("Date");

                    QHItemJournalLine.QHItemJournalLine_Service qhjnlSev = new QHMobile.QHItemJournalLine.QHItemJournalLine_Service();
                    qhjnlSev.Url = WebServiceInstants.GetURL(ServiceType.QHItemJournalLine);
                    qhjnlSev.Credentials = nc;

                    List<QHItemJournalLine.QHItemJournalLine_Filter> filterJNLArray = new List<QHMobile.QHItemJournalLine.QHItemJournalLine_Filter>();

                    QHItemJournalLine.QHItemJournalLine_Filter qhfilterBin = new QHMobile.QHItemJournalLine.QHItemJournalLine_Filter();
                    qhfilterBin.Field = QHMobile.QHItemJournalLine.QHItemJournalLine_Fields.Bin_Code;

                    if (!String.IsNullOrEmpty(txtBinNo.Text.Trim()))
                    {
                        qhfilterBin.Criteria = txtBinNo.Text.Trim();
                    }

                    QHItemJournalLine.QHItemJournalLine_Filter filterqty = new QHMobile.QHItemJournalLine.QHItemJournalLine_Filter();
                    filterqty.Field = QHMobile.QHItemJournalLine.QHItemJournalLine_Fields.Quantity;
                    filterqty.Criteria = "<>0";

                    QHItemJournalLine.QHItemJournalLine_Filter filterbatch = new QHMobile.QHItemJournalLine.QHItemJournalLine_Filter();
                    filterbatch.Field = QHMobile.QHItemJournalLine.QHItemJournalLine_Fields.Journal_Batch_Name;
                    filterbatch.Criteria = "DOA";

                    QHItemJournalLine.QHItemJournalLine_Filter filterPostingDate = new QHMobile.QHItemJournalLine.QHItemJournalLine_Filter();
                    filterPostingDate.Field = QHMobile.QHItemJournalLine.QHItemJournalLine_Fields.Posting_Date;
                    filterPostingDate.Criteria = txtFromDate.Text.Trim() + ".." + txtToDate.Text.Trim();

                    filterJNLArray.Add(qhfilterBin);
                    filterJNLArray.Add(filterqty);
                    filterJNLArray.Add(filterbatch);
                    filterJNLArray.Add(filterPostingDate);

                    QHItemJournalLine.QHItemJournalLine[] getJNLlines = qhjnlSev.ReadMultiple(filterJNLArray.ToArray(), null, 0);

                    dt.Clear();

                    if (getJNLlines.Length > 0)
                    {
                        dt.Clear();
                        for (int i = 0; i < getJNLlines.Length; i++)
                        {
                            Object[] array = new Object[6];
                            array[0] = getJNLlines[i].Location_Code;
                            array[1] = getJNLlines[i].Item_No;

                            if (!String.IsNullOrEmpty(getJNLlines[i].Item_No.Trim()))
                            {
                                ItemQH.ItemQH_Service itemsev = new QHMobile.ItemQH.ItemQH_Service();
                                itemsev.Url = WebServiceInstants.GetURL(ServiceType.ItemQH);
                                itemsev.Credentials = nc;

                                ItemQH.ItemQH itemdescription = itemsev.Read(getJNLlines[i].Item_No.ToString());
                                array[2] = itemdescription.Description;
                                array[3] = itemdescription.Description_2;
                            }

                            
                            array[4] = getJNLlines[i].Quantity;
                            array[5] = getJNLlines[i].Posting_Date;


                            dt.Rows.Add(array);
                        }

                        //lblCount.Text = "(" + qhBinContent.Length.ToString() + ")";
                        gdBins.DataSource = dt;
                        gdBins.TableStyles.Clear();
                        gdBins.TableStyles.Add(DataGridStyleDailyLoss(dt));
                    }

                    QHWarehouseEntry.QHWarehouseEntry_Service waresev = new QHMobile.QHWarehouseEntry.QHWarehouseEntry_Service();
                    waresev.Url = WebServiceInstants.GetURL(ServiceType.QHWarehouseEntry);
                    waresev.Credentials = nc;

                    List<QHWarehouseEntry.QHWarehouseEntry_Filter> filterWarehouseArray = new List<QHMobile.QHWarehouseEntry.QHWarehouseEntry_Filter>();

                    QHWarehouseEntry.QHWarehouseEntry_Filter warehousebin = new QHMobile.QHWarehouseEntry.QHWarehouseEntry_Filter();
                    warehousebin.Field = QHMobile.QHWarehouseEntry.QHWarehouseEntry_Fields.Bin_Code;
                    if (!String.IsNullOrEmpty(txtBinNo.Text.Trim()))
                    {
                        warehousebin.Criteria = txtBinNo.Text.Trim();
                    }
                    filterWarehouseArray.Add(warehousebin);

                    QHWarehouseEntry.QHWarehouseEntry_Filter warehouseqty = new QHMobile.QHWarehouseEntry.QHWarehouseEntry_Filter();
                    warehouseqty.Field = QHMobile.QHWarehouseEntry.QHWarehouseEntry_Fields.Quantity;
                    warehouseqty.Criteria = "<>0";
                    filterWarehouseArray.Add(warehouseqty);

                    QHWarehouseEntry.QHWarehouseEntry_Filter warehousebatch = new QHMobile.QHWarehouseEntry.QHWarehouseEntry_Filter();
                    warehousebatch.Field = QHMobile.QHWarehouseEntry.QHWarehouseEntry_Fields.Journal_Batch_Name;
                    warehousebatch.Criteria = "DOA";
                    filterWarehouseArray.Add(warehousebatch);

                    QHWarehouseEntry.QHWarehouseEntry_Filter filterWHRegDate = new QHMobile.QHWarehouseEntry.QHWarehouseEntry_Filter();
                    filterWHRegDate.Field = QHMobile.QHWarehouseEntry.QHWarehouseEntry_Fields.Registering_Date;
                    filterWHRegDate.Criteria = txtFromDate.Text.Trim() + ".." + txtToDate.Text.Trim();
                    filterWarehouseArray.Add(filterWHRegDate);

                    QHWarehouseEntry.QHWarehouseEntry[] getWarehouseList = waresev.ReadMultiple(filterWarehouseArray.ToArray(), null, 0);

                    if (getWarehouseList.Length > 0)
                    {

                        for (int k = 0; k < getWarehouseList.Length; k++)
                        {
                            Object[] array = new Object[5];
                            array[0] = getWarehouseList[k].Location_Code;
                            array[1] = getWarehouseList[k].Item_No;
                            if (!String.IsNullOrEmpty(getWarehouseList[k].Item_No.Trim()))
                            {
                                ItemQH.ItemQH_Service itemsev = new QHMobile.ItemQH.ItemQH_Service();
                                itemsev.Url = WebServiceInstants.GetURL(ServiceType.ItemQH);
                                itemsev.Credentials = nc;

                                ItemQH.ItemQH itemdescription = itemsev.Read(getWarehouseList[k].Item_No.ToString());
                                array[2] = itemdescription.Description;
                            }
                            
                            array[3] = getWarehouseList[k].Quantity;
                            array[4] = getWarehouseList[k].Registering_Date; // suppposed to be posting date
                            dt.Rows.Add(array);
                        }

                        //lblCount.Text = "(" + qhBinContent.Length.ToString() + ")";
                        gdBins.DataSource = dt;
                        gdBins.TableStyles.Clear();
                        gdBins.TableStyles.Add(DataGridStyleDailyLoss(dt));
                    }

                    int totalcount = getJNLlines.Length + getWarehouseList.Length;

                    lblCount.Text = "(" + totalcount + ")";

                    //END Bin Content by Item

                    Cursor.Current = Cursors.Default;
                }
                if (menuValue == "4")
                {
                   DataTable dt = new DataTable("DailyLoss");
                    dt.Columns.Add("Location");
                    dt.Columns.Add("ItemNo");
                    dt.Columns.Add("Description");
                    dt.Columns.Add("Description2");
                    dt.Columns.Add("Quantity");
                    dt.Columns.Add("ReferenceNo"); // Reference No 
                    dt.Columns.Add("VendorNo");
                    dt.Columns.Add("ReceiptDate");
                    dt.Columns.Add("CustomerNo");
                   
                    QHWarehouseEntry.QHWarehouseEntry_Service waresev = new QHMobile.QHWarehouseEntry.QHWarehouseEntry_Service();
                    waresev.Url = WebServiceInstants.GetURL(ServiceType.QHWarehouseEntry);
                    waresev.Credentials = nc;

                    List<QHWarehouseEntry.QHWarehouseEntry_Filter> filterWarehouseArray = new List<QHMobile.QHWarehouseEntry.QHWarehouseEntry_Filter>();

                    QHWarehouseEntry.QHWarehouseEntry_Filter warehousebin = new QHMobile.QHWarehouseEntry.QHWarehouseEntry_Filter();
                    warehousebin.Field = QHMobile.QHWarehouseEntry.QHWarehouseEntry_Fields.Bin_Code;
                    if (!String.IsNullOrEmpty(txtBinNo.Text.Trim()))
                    {
                        warehousebin.Criteria = txtBinNo.Text.Trim();
                    }
                    filterWarehouseArray.Add(warehousebin);

                    QHWarehouseEntry.QHWarehouseEntry_Filter warehouseqty = new QHMobile.QHWarehouseEntry.QHWarehouseEntry_Filter();
                    warehouseqty.Field = QHMobile.QHWarehouseEntry.QHWarehouseEntry_Fields.Quantity;
                    warehouseqty.Criteria = "<>0";
                    filterWarehouseArray.Add(warehouseqty);

                    QHWarehouseEntry.QHWarehouseEntry_Filter warehousebatch = new QHMobile.QHWarehouseEntry.QHWarehouseEntry_Filter();
                    warehousebatch.Field = QHMobile.QHWarehouseEntry.QHWarehouseEntry_Fields.Journal_Batch_Name;
                    warehousebatch.Criteria = "<>DOA";
                    filterWarehouseArray.Add(warehousebatch);

                    QHWarehouseEntry.QHWarehouseEntry_Filter filterWHRegDate = new QHMobile.QHWarehouseEntry.QHWarehouseEntry_Filter();
                    filterWHRegDate.Field = QHMobile.QHWarehouseEntry.QHWarehouseEntry_Fields.Registering_Date;
                    filterWHRegDate.Criteria = txtFromDate.Text.Trim() + ".." + txtToDate.Text.Trim();
                    filterWarehouseArray.Add(filterWHRegDate);

                    QHWarehouseEntry.QHWarehouseEntry[] getWarehouseList = waresev.ReadMultiple(filterWarehouseArray.ToArray(), null, 0);

                    //dt.Clear();
                    //dt.Rows.Clear();

                    if (getWarehouseList.Length > 0)
                    {
                        //  dt.Clear();


                        for (int k = 0; k < getWarehouseList.Length; k++)
                        {
                            Object[] array = new Object[9];
                            array[0] = getWarehouseList[k].Location_Code;
                            array[1] = getWarehouseList[k].Item_No;
                            if (!String.IsNullOrEmpty(getWarehouseList[k].Item_No.Trim()))
                            {
                                ItemQH.ItemQH_Service itemsev = new QHMobile.ItemQH.ItemQH_Service();
                                itemsev.Url = WebServiceInstants.GetURL(ServiceType.ItemQH);
                                itemsev.Credentials = nc;

                                ItemQH.ItemQH itemdescription = itemsev.Read(getWarehouseList[k].Item_No.ToString());
                                array[2] = itemdescription.Description;
                                array[3] = itemdescription.Description_2;
                            }

                            array[4] = getWarehouseList[k].Quantity;
                            array[5] = getWarehouseList[k].Reference_No; // suppposed to be posting date
                            array[6] = getWarehouseList[k].VendorNo;
                            array[7] = getWarehouseList[k].ReceiptDate;
                            array[8] = getWarehouseList[k].CustNo;
                            dt.Rows.Add(array);
                        }

                        //lblCount.Text = "(" + qhBinContent.Length.ToString() + ")";
                        gdBins.DataSource = dt;
                        gdBins.TableStyles.Clear();
                        gdBins.TableStyles.Add(DataGridStyleDailyLoss(dt));
                    }
                    else
                    {
                        dt = null;
                        gdBins.DataSource = dt;
                    }

                    int totalcount = getWarehouseList.Length;

                    lblCount.Text = "(" + totalcount + ")";

                    //END Bin Content by Item

                    Cursor.Current = Cursors.Default;

                }


            }
            catch (Exception ex)
            {
                Cursor.Current = Cursors.Default;
                MessageBox.Show(ex.Message);
            }

        }

        private DataGridTableStyle DataGridStyle(DataTable dTable)
        {
            DataGridTableStyle ts = new DataGridTableStyle();
            ts.MappingName = dTable.TableName;

            DataGridColumnStyle s1 = new DataGridTextBoxColumn();
            s1.Width = 70;
            s1.MappingName = "BinCode";
            s1.HeaderText = "Bin Code";
            ts.GridColumnStyles.Add(s1);

            DataGridColumnStyle s2 = new DataGridTextBoxColumn();
            s2.Width = 100;
            s2.MappingName = "LocationCode";
            s2.HeaderText = "Location Code";
            ts.GridColumnStyles.Add(s2);

            //DataGridColumnStyle s22 = new DataGridTextBoxColumn();
            //s22.Width = 90;
            //s22.MappingName = "ZoneCode";
            //s22.HeaderText = "Zone Code";
            //ts.GridColumnStyles.Add(s22);

            return ts;
        }


        private DataGridTableStyle DataGridStyleBinContent(DataTable dTable)
        {
            DataGridTableStyle ts = new DataGridTableStyle();
            ts.MappingName = dTable.TableName;

            DataGridColumnStyle s1 = new DataGridTextBoxColumn();
            s1.Width = 70;
            s1.MappingName = "BinCode";
            s1.HeaderText = "Bin Code";
            ts.GridColumnStyles.Add(s1);

            DataGridColumnStyle s2 = new DataGridTextBoxColumn();
            s2.Width = 100;
            s2.MappingName = "LocationCode";
            s2.HeaderText = "Location Code";
            ts.GridColumnStyles.Add(s2);

            DataGridColumnStyle s22 = new DataGridTextBoxColumn();
            s22.Width = 90;
            s22.MappingName = "ItemNo";
            s22.HeaderText = "Item No";
            ts.GridColumnStyles.Add(s22);


            DataGridColumnStyle s3 = new DataGridTextBoxColumn();
            s3.Width = 100;
            s3.MappingName = "Description";
            s3.HeaderText = "Description";
            ts.GridColumnStyles.Add(s3);

            DataGridColumnStyle s4 = new DataGridTextBoxColumn();
            s4.Width = 100;
            s4.MappingName = "Description2";
            s4.HeaderText = "Description2";
            ts.GridColumnStyles.Add(s4);

            DataGridColumnStyle s5 = new DataGridTextBoxColumn();
            s5.Width = 100;
            s5.MappingName = "Quantity";
            s5.HeaderText = "Quantity";
            ts.GridColumnStyles.Add(s5);

            DataGridColumnStyle s6 = new DataGridTextBoxColumn();
            s6.Width = 100;
            s6.MappingName = "VendorNo";
            s6.HeaderText = "VendorNo";
            ts.GridColumnStyles.Add(s6);

            DataGridColumnStyle s7 = new DataGridTextBoxColumn();
            s7.Width = 100;
            s7.MappingName = "Receipt Date";
            s7.HeaderText = "Receipt Date";
            ts.GridColumnStyles.Add(s7);

            DataGridColumnStyle s8 = new DataGridTextBoxColumn();
            s8.Width = 100;
            s8.MappingName = "CustomerNo";
            s8.HeaderText = "Customer No";
            ts.GridColumnStyles.Add(s8);

            return ts;
        }
        private void mnuGRNBack_Click(object sender, EventArgs e)
        {
            frmMain msc = new frmMain(username, staffdim, userlevel);
            msc.Show();
        }

      

        private void mnuBinContent_Click(object sender, EventArgs e)
        {
            lblItemNo.Text = "Bin No.";
            //txtBinNo.Text = "";
            
            if(string.IsNullOrEmpty(txtBinNo.Text.Trim()))
            {
                txtBinNo.Text = binOnMemory;
            }

            mnuEmptyBin1.Checked = false;
            mnuBinItem.Checked = false;
            mnuBinContent.Checked = true;
            mnudailyloss.Checked = false;
            menuValue = "1";


            lblTodate.Visible = false;
            txtToDate.Visible = false;
            lblFromDate.Visible = false;
            txtFromDate.Visible = false;

            dt.Clear();
            lblCount.Text = "(" + "0" + ")";
            gdBins.DataSource = dt;
            gdBins.TableStyles.Clear();
            gdBins.TableStyles.Add(DataGridStyleBinContent(dt));

        }

        private void butFind_Click(object sender, EventArgs e)
        {
            if (menuValue.Equals("0"))
            {
                BindtoGrid();
            }
            else
            {
                if (!String.IsNullOrEmpty(txtBinNo.Text.Trim()) && !String.IsNullOrEmpty(txtFromDate.Text.Trim()) && !String.IsNullOrEmpty(txtToDate.Text.Trim()))
                {
                    BindtoGrid();
                }
                else
                {
                    MessageBox.Show("Please key in the Bin no, from date and to date!");
                    txtBinNo.Focus();
                }
            }
        }

        private void mnuMainBack_Click(object sender, EventArgs e)
        {
            this.Close();
            frmMain msc = new frmMain(username, staffdim, userlevel);
            msc.Show();
        }

        private void mnuEmptyBin1_Click(object sender, EventArgs e)
        {
            lblItemNo.Text = "Bin No.";
            //txtBinNo.Text = "";

            //if (string.IsNullOrEmpty(txtBinNo.Text.Trim()))
            //{
            //    txtBinNo.Text = binOnMemory;
            //}

            mnuEmptyBin1.Checked = true;
            mnuBinItem.Checked = false;
            mnuBinContent.Checked = false;
            mnudailyloss.Checked = false;
            lblTodate.Visible = false;
            txtToDate.Visible = false;
            lblFromDate.Visible = false;
            txtFromDate.Visible = false;
            menuValue = "0";
            //lblItemNo.Visible = false;
            dt.Clear();
            lblCount.Text = "(" + "0" + ")";
            gdBins.DataSource = dt;
            gdBins.TableStyles.Clear();
            gdBins.TableStyles.Add(DataGridStyle(dt));
        }

        private void mnuBinItem_Click(object sender, EventArgs e)
        {
            lblItemNo.Text = "Item No.";
            binOnMemory = txtBinNo.Text.Trim(); 

            txtBinNo.Text = "";
            mnuBinItem.Checked = true;
            mnuEmptyBin1.Checked = false;
            mnuBinContent.Checked = false;
            mnudailyloss.Checked = false;
            lblTodate.Visible = false;
            txtToDate.Visible = false;
            lblFromDate.Visible = false;
            txtFromDate.Visible = false;
            menuValue = "2";

            dt.Clear();
            lblCount.Text = "(" + "0" + ")";
            gdBins.DataSource = dt;
            gdBins.TableStyles.Clear();
            gdBins.TableStyles.Add(DataGridStyleBinContent(dt));

        }

        private void mnudailyloss_Click(object sender, EventArgs e)
        {
            lblItemNo.Text = "Bin No.";
            //txtBinNo.Text = "";
            if (string.IsNullOrEmpty(txtBinNo.Text.Trim()))
            {
                txtBinNo.Text = binOnMemory;
            }

            mnuEmptyBin1.Checked = false;
            mnuBinItem.Checked = false;
            mnuBinContent.Checked = false;
            mnudailyloss.Checked = true;
            menuValue = "3";

            lblTodate.Visible = true;
            txtToDate.Visible = true;
            lblFromDate.Visible = true;
            txtFromDate.Visible = true;

            dt.Clear();
            lblCount.Text = "(" + "0" + ")";
            gdBins.DataSource = dt;
            gdBins.TableStyles.Clear();
            gdBins.TableStyles.Add(DataGridStyleDailyLoss(dt));
        }

        private DataGridTableStyle DataGridStyleDailyLoss(DataTable dt)
        {
            DataGridTableStyle ts = new DataGridTableStyle();
            ts.MappingName = dt.TableName;

            DataGridColumnStyle s1 = new DataGridTextBoxColumn();
            s1.Width = 70;
            s1.MappingName = "Location";
            s1.HeaderText = "Location";
            ts.GridColumnStyles.Add(s1);

            DataGridColumnStyle s2 = new DataGridTextBoxColumn();
            s2.Width = 100;
            s2.MappingName = "ItemNo";
            s2.HeaderText = "Item No";
            ts.GridColumnStyles.Add(s2);

            DataGridColumnStyle s22 = new DataGridTextBoxColumn();
            s22.Width = 90;
            s22.MappingName = "Description";
            s22.HeaderText = "Description";
            ts.GridColumnStyles.Add(s22);


            DataGridColumnStyle s3 = new DataGridTextBoxColumn();
            s3.Width = 90;
            s3.MappingName = "Description2";
            s3.HeaderText = "Description 2";
            ts.GridColumnStyles.Add(s3);

            DataGridColumnStyle s4 = new DataGridTextBoxColumn();
            s4.Width = 100;
            s4.MappingName = "Quantity";
            s4.HeaderText = "Quantity";
            ts.GridColumnStyles.Add(s4);

            DataGridColumnStyle s5 = new DataGridTextBoxColumn();
            s5.Width = 100;
            s5.MappingName = "Date";
            s5.HeaderText = "Date";
            ts.GridColumnStyles.Add(s5);

            DataGridColumnStyle s6 = new DataGridTextBoxColumn();
            s6.Width = 100;
            s6.MappingName = "ReferenceNo";
            s6.HeaderText = "Reference No";
            ts.GridColumnStyles.Add(s6);

            DataGridColumnStyle s7 = new DataGridTextBoxColumn();
            s7.Width = 100;
            s7.MappingName = "VendorNo";
            s7.HeaderText = "VendorNo";
            ts.GridColumnStyles.Add(s7);

            DataGridColumnStyle s8 = new DataGridTextBoxColumn();
            s8.Width = 100;
            s8.MappingName = "ReceiptDate";
            s8.HeaderText = "ReceiptDate";
            ts.GridColumnStyles.Add(s8);

            DataGridColumnStyle s9 = new DataGridTextBoxColumn();
            s9.Width = 100;
            s9.MappingName = "CustomerNo";
            s9.HeaderText = "Customer No";
            ts.GridColumnStyles.Add(s9);

            return ts;
        }

        private void menuItem1_Click(object sender, EventArgs e)
        {
            lblItemNo.Text = "Bin No.";
            //txtBinNo.Text = "";

            if (string.IsNullOrEmpty(txtBinNo.Text.Trim()))
            {
                txtBinNo.Text = binOnMemory;
            }
            mnuEmptyBin1.Checked = false;
            mnuBinItem.Checked = false;
            mnuBinContent.Checked = false;
            mnudailyloss.Checked = true;
            menuValue = "4";

            lblTodate.Visible = true;
            txtToDate.Visible = true;
            lblFromDate.Visible = true;
            txtFromDate.Visible = true;

            dt.Clear();
            lblCount.Text = "(" + "0" + ")";
            gdBins.DataSource = dt;
            gdBins.TableStyles.Clear();
            gdBins.TableStyles.Add(DataGridStyleDailyLoss(dt));
        }
    }

}