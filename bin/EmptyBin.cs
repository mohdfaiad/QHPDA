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
        public EmptyBin(string userd, string staffd, string uleveld)
        {
            InitializeComponent();
            staffdim = staffd;
            username = userd;
            userlevel = uleveld;
            

            lblStaffName.Text = staffdim + "/ Role:" + userlevel;

            txtBinNo.Focus();

           // BindtoGrid();
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
                    dt.Columns.Add("ZoneCode");

                    //List<BinQH.BinQH> Lbin = new List<QHMobile.BinQH.BinQH>();

                    BinQH.BinQH_Service binserv = new QHMobile.BinQH.BinQH_Service();
                    binserv.Url = WebServiceInstants.GetURL(ServiceType.BinQH);
                    binserv.Credentials = nc;

                   List<BinQH.BinQH_Filter> binFilterArray = new List<QHMobile.BinQH.BinQH_Filter>();
                   BinQH.BinQH_Filter binFilter = new QHMobile.BinQH.BinQH_Filter();
                    if (!String.IsNullOrEmpty(txtBinNo.Text.Trim()))
                    {
                        binFilter.Field = QHMobile.BinQH.BinQH_Fields.Code;
                        binFilter.Criteria = txtBinNo.Text.Trim();
                        binFilterArray.Add(binFilter);
                    }
                    BinQH.BinQH_Filter EmptyFilter = new QHMobile.BinQH.BinQH_Filter();
                    EmptyFilter.Field = QHMobile.BinQH.BinQH_Fields.Empty;
                    EmptyFilter.Criteria = "1";
                    binFilterArray.Add(EmptyFilter);
                    BinQH.BinQH[] BinList = binserv.ReadMultiple(binFilterArray.ToArray(),null,0);
                    dt.Clear();
                    if (BinList.Length> 0)
                    {
                        for (int i = 0; i < BinList.Length; i++)
			            {
                            Object[] array = new Object[3];
                            array[0] = BinList[i].Code;
                            array[1] = BinList[i].Location_Code;
                            array[2] = BinList[i].Zone_Code;
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
                }//End Empty Bin
                if (menuValue == "1") //1= Find Bin Content
                {
                    dt = new DataTable("BinContent");
                    dt.Columns.Add("LocationCode");
                    dt.Columns.Add("BinCode");
                    dt.Columns.Add("ItemNo");
                    dt.Columns.Add("ItemDescription");
                    dt.Columns.Add("Quantity");

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
                        qhBinContent = qhBinContSev.ReadMultiple(filterarray.ToArray(), null, 0);
                    }
                    else
                    {
                        qhBinContent = qhBinContSev.ReadMultiple(filterarray.ToArray(), null, 10);
                    }
                    dt.Clear();
                    if (qhBinContent.Length > 0)
                    {
                        dt.Clear();
                        for (int i = 0; i < qhBinContent.Length; i++)
                        {
                            Object[] array = new Object[5];
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
                            }
                            else
                            {
                                array[3] = "";
                            }
                            array[4] = qhBinContent[i].Quantity;
                            dt.Rows.Add(array);
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
                }//END Bin Content
                if (menuValue == "2") //1= Find Bin Content by Item
                {
                    dt = new DataTable("BinContent");
                    dt.Columns.Add("LocationCode");
                    dt.Columns.Add("BinCode");
                    dt.Columns.Add("ItemNo");
                    dt.Columns.Add("ItemDescription");
                    dt.Columns.Add("Quantity");

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
                        qhBinContent = qhBinContSev.ReadMultiple(filterarray.ToArray(), null, 0);
                    }
                    else
                    {
                        qhBinContent = qhBinContSev.ReadMultiple(filterarray.ToArray(), null, 10);
                    }
                    dt.Clear();
                    if (qhBinContent.Length > 0)
                    {
                        dt.Clear();
                        for (int i = 0; i < qhBinContent.Length; i++)
                        {
                            Object[] array = new Object[5];
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
                            }
                            else
                            {
                                array[3] = "";
                            }
                            array[4] = qhBinContent[i].Quantity;
                            dt.Rows.Add(array);
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
                }//END Bin Content by Item

                Cursor.Current = Cursors.Default;
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
            s2.HeaderText = "Locatin Code";
            ts.GridColumnStyles.Add(s2);

            DataGridColumnStyle s22 = new DataGridTextBoxColumn();
            s22.Width = 90;
            s22.MappingName = "ZoneCode";
            s22.HeaderText = "Zone Code";
            ts.GridColumnStyles.Add(s22);

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
            s2.HeaderText = "Locatin Code";
            ts.GridColumnStyles.Add(s2);

            DataGridColumnStyle s22 = new DataGridTextBoxColumn();
            s22.Width = 90;
            s22.MappingName = "ItemNo";
            s22.HeaderText = "Item No";
            ts.GridColumnStyles.Add(s22);


            DataGridColumnStyle s3 = new DataGridTextBoxColumn();
            s3.Width = 100;
            s3.MappingName = "ItemDescription";
            s3.HeaderText = "Item Description";
            ts.GridColumnStyles.Add(s3);

            DataGridColumnStyle s4 = new DataGridTextBoxColumn();
            s4.Width = 100;
            s4.MappingName = "Quantity";
            s4.HeaderText = "Quantity";
            ts.GridColumnStyles.Add(s4);

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
            mnuEmptyBin1.Checked = false;
            mnuBinItem.Checked = false;
            mnuBinContent.Checked = true;
            menuValue = "1";

            dt.Clear();
            lblCount.Text = "(" + "0" + ")";
            gdBins.DataSource = dt;
            gdBins.TableStyles.Clear();
            gdBins.TableStyles.Add(DataGridStyleBinContent(dt));

        }

        private void butFind_Click(object sender, EventArgs e)
        {
            if (!String.IsNullOrEmpty(txtBinNo.Text.Trim()))
            {
                BindtoGrid();
            }
            else
            {
                MessageBox.Show("Please key in the Bin no.");
                txtBinNo.Focus();
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
            mnuEmptyBin1.Checked = true;
            mnuBinItem.Checked = false;
            mnuBinContent.Checked = false;
            menuValue = "0";

            dt.Clear();
            lblCount.Text = "(" + "0" + ")";
            gdBins.DataSource = dt;
            gdBins.TableStyles.Clear();
            gdBins.TableStyles.Add(DataGridStyle(dt));
        }

        private void mnuBinItem_Click(object sender, EventArgs e)
        {
            lblItemNo.Text = "Item No.";
            mnuBinItem.Checked = true;
            mnuEmptyBin1.Checked = false;
            mnuBinContent.Checked = false;
            menuValue = "2";

            dt.Clear();
            lblCount.Text = "(" + "0" + ")";
            gdBins.DataSource = dt;
            gdBins.TableStyles.Clear();
            gdBins.TableStyles.Add(DataGridStyleBinContent(dt));

        }
    }

}