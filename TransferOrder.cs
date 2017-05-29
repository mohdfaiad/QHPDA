using System;
using System.Linq;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlServerCe;
using System.Collections;
using System.Reflection;
using System.IO;
using System.Xml;

namespace QHMobile
{
    public partial class TransferOrder : Form
    {
        protected System.Net.NetworkCredential nc = new System.Net.NetworkCredential(WebServiceInstants.GetURL(ServiceType.userName).ToString(), WebServiceInstants.GetURL(ServiceType.password).ToString(), WebServiceInstants.GetURL(ServiceType.domain).ToString());
        List<ItemJournalL> journalarray = new List<ItemJournalL>();
        DataTable tableJournal = new DataTable("Journal");
        DataTable PostJournal = new DataTable("Journal To Post");

        bool fromloc = false;
        bool tolocl = false;
        string staffname,staffdimension,stafflevel;

        string fishdescription;
        SqlCeDataReader getdata;

        public TransferOrder(string Rstaffname, string Rstaffdimension,string Rstafflevel)
        {
            InitializeComponent();
            journalarray.Clear();
            txtFromBin.Focus();


            this.staffname = Rstaffname;
            this.staffdimension = Rstaffdimension;
            this.stafflevel = Rstafflevel;

            
            tableJournal.Columns.Add("Posting Date");
            tableJournal.Columns.Add("Item No");
            tableJournal.Columns.Add("Location");
            tableJournal.Columns.Add("From Bin");
            tableJournal.Columns.Add("To Bin");
            tableJournal.Columns.Add("Quantity");
            tableJournal.Columns.Add("Staff Code");
            tableJournal.Columns.Add("LineNo");//test3 
            tableJournal.Columns.Add("Empty Tank");

            
            PostJournal.Columns.Add("Item No");
            PostJournal.Columns.Add("From Location");
            PostJournal.Columns.Add("From Bin");
            PostJournal.Columns.Add("To Location");
            PostJournal.Columns.Add("To Bin");
            PostJournal.Columns.Add("Quantity");
            BindPostLines();

            CompactSQL comsql = new CompactSQL();
            getdata = comsql.SelectRecord("ItemReclass");
            GetSQLData(getdata);


            tbScanLine.Show();
            mnuPostToNav.Enabled = true;
            menuItem1.Enabled = true;
            menuItem2.Enabled = true;
            menuItem3.Enabled = true;

            lblStaffDimension.Text = staffdimension;

            //if (Rstafflevel.Equals("Super"))
            //{
            //    tbScanLine.Show();
            //    mnuPostToNav.Enabled = true;
            //    menuItem1.Enabled = true;
            //    menuItem2.Enabled = true;
            //    menuItem3.Enabled = true;

               
            //}
            //else
            //{
            //    tbScanLine.Show();
            //    tbLinePost.Show();
            //    mnuPostToNav.Enabled = true;
            //    menuItem1.Enabled = true;
            //    menuItem2.Enabled = true;
            //    menuItem3.Enabled = true;

            //    //tbLinePost.Hide();
            //    //mnuPostToNav.Enabled = false;
            //    //menuItem1.Enabled = true;
            //    //menuItem2.Enabled = true;
            //    //menuItem3.Enabled = true;
            //}

        }

        private void GetSQLData(SqlCeDataReader getdata)
        {
            tableJournal.Clear();
            journalarray.Clear();
            while (getdata.Read())
            {
                ItemJournalL insertOneLine = new ItemJournalL();
                Object[] array = new Object[9];

                insertOneLine.postingDate = Convert.ToDateTime(getdata["PostingDate"]);
                array[0] = Convert.ToDateTime(getdata["PostingDate"]); 
                insertOneLine.ItemNo = getdata["ItemNo"].ToString();
                array[1] = getdata["ItemNo"].ToString();
                insertOneLine.location = getdata["Location"].ToString();
                array[2] = getdata["Location"].ToString();
                insertOneLine.frombin = getdata["FromBin"].ToString();
                array[3] = getdata["FromBin"].ToString();
                insertOneLine.tobin = getdata["ToBin"].ToString();
                array[4] = getdata["ToBin"].ToString();
                insertOneLine.quantity = Convert.ToInt32(getdata["Quantity"]);
                array[5] = Convert.ToInt32(getdata["Quantity"]);
                insertOneLine.staffdimension = getdata["StaffCode"].ToString();
                array[6] = getdata["StaffCode"].ToString();

                array[7] = getdata["LineNo"].ToString();//test3 
                array[8] = getdata["EmptyTank"].ToString();//test3 
                insertOneLine.emptyBin = Convert.ToBoolean(getdata["EmptyTank"]);

                tableJournal.Rows.Add(array);
                journalarray.Add(insertOneLine);
            }


            BindTOGrid();
        }

        private void BindPostLines()
        {
            ItemJournalQH.ItemJournalQH_Service sev = new QHMobile.ItemJournalQH.ItemJournalQH_Service();
            sev.Url = WebServiceInstants.GetURL(ServiceType.ItemJournalQH);
            sev.Credentials = nc;

            ItemJournalQH.ItemJournalQH[] journal = sev.ReadMultiple("DEFAULT", null, null, 0);

            for (int i = 0; i < journal.Length; i++)
            {
                Object[] array = new Object[6];
                array[0] = journal[i].Item_No;
                array[1] = journal[i].Location_Code;
                array[2] = journal[i].New_Location_Code;
                array[3] = journal[i].Bin_Code;
                array[4] = journal[i].New_Bin_Code;
                array[5] = journal[i].Quantity;

                PostJournal.Rows.Add(array);


            }

            grdLineToPost.DataSource = PostJournal;
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
            try
            {
                if(!string.IsNullOrEmpty(txtItemNo.Text.Trim()) && !string.IsNullOrEmpty(txtFromBin.Text.Trim()) && !string.IsNullOrEmpty(txtToBin.Text.Trim()))
                //if (!txtItemNo.Text.Equals("") && !txtFromBin.Text.Equals("") && !txtToBin.Text.Equals(""))
                {
                    ItemQH.ItemQH_Service iqhservice = new QHMobile.ItemQH.ItemQH_Service();
                    iqhservice.Url = WebServiceInstants.GetURL(ServiceType.ItemQH);
                    iqhservice.Credentials = nc;
                    ItemQH.ItemQH iqh = iqhservice.Read(txtItemNo.Text.Trim());

                    if (iqh != null)
                    {
                        BinQH.BinQH_Service binServ = new QHMobile.BinQH.BinQH_Service();
                        binServ.Url = WebServiceInstants.GetURL(ServiceType.BinQH);
                        binServ.Credentials = nc;

                        BinQH.BinQH tobinqh = binServ.Read(lblInfoLocation.Text.ToString(), txtToBin.Text.Trim());
                        if (tobinqh != null)
                        {
                            if (tobinqh.Block_Movement == QHMobile.BinQH.Block_Movement.All)
                            {
                                MessageBox.Show("To Bin is Blocked");
                                txtToBin.SelectAll();
                                txtToBin.Focus();

                            }
                            else
                            {

                                bool flag = GotoBinvalidation();

                                if (flag == true)
                                {

                                    InsertLines();

                                    CompactSQL comsql = new CompactSQL();//test3

                                    getdata = comsql.SelectRecord("ItemReclass");//test3
                                    GetSQLData(getdata);//test3

                                    //BindTOGrid();
                                    Cursor.Current = Cursors.Default;

                                    txtFromBin.Text = "";
                                    txtToBin.Text = "";
                                    textBox1.Text = "";
                                    txtItemNo.Text = "";
                                    txtFishDescription.Text = "";
                                    lblInfoLocation.Text = "";
                                    chkEmpty.Checked = false;
                                    txtFromBin.Focus();
                                }
                                else
                                {
                                    MessageBox.Show("You are not allowed to put into the bin with different item!Fish Description: " + fishdescription);
                                    txtToBin.SelectAll();
                                    txtToBin.Focus();
                                }
                            }
                        }
                       // }
//////here
                    }
                    else
                    {
                        MessageBox.Show("Invalid Item No!");
                    }
                }
                else
                {
                    MessageBox.Show("All field are required to enter.");
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            Cursor.Current = Cursors.Default;
        }

        private bool GotoBinvalidation()
        {
                BinQH.BinQH_Service binServ = new QHMobile.BinQH.BinQH_Service();
                binServ.Url = WebServiceInstants.GetURL(ServiceType.BinQH);
                binServ.Credentials = nc;

                QHBinContent.QHBinContent_Service contentSev = new QHMobile.QHBinContent.QHBinContent_Service();
                contentSev.Url = WebServiceInstants.GetURL(ServiceType.QHBinContent);
                contentSev.Credentials = nc;

                List<QHBinContent.QHBinContent_Filter> ContentArray = new List<QHBinContent.QHBinContent_Filter>();

                QHBinContent.QHBinContent_Filter contentfilter = new QHMobile.QHBinContent.QHBinContent_Filter();
                if (!string.IsNullOrEmpty(lblInfoLocation.Text.ToString()))
                {
                    
                    contentfilter.Field = QHMobile.QHBinContent.QHBinContent_Fields.Location_Code;
                    contentfilter.Criteria = lblInfoLocation.Text.ToString();

                }
                else
                {
                    contentfilter.Criteria = "QH1";
                }

                QHBinContent.QHBinContent_Filter binfilter = new QHMobile.QHBinContent.QHBinContent_Filter();
                binfilter.Field = QHMobile.QHBinContent.QHBinContent_Fields.Bin_Code;
                binfilter.Criteria = txtToBin.Text.Trim();

                QHBinContent.QHBinContent_Filter qtyfilter = new QHMobile.QHBinContent.QHBinContent_Filter();
                qtyfilter.Field = QHMobile.QHBinContent.QHBinContent_Fields.Quantity;
                qtyfilter.Criteria = "<>0";

                ContentArray.Add(contentfilter);
                ContentArray.Add(binfilter);
                ContentArray.Add(qtyfilter);


                BinQH.BinQH frombinqh;
                BinQH.BinQH tobinqh;
                if (!string.IsNullOrEmpty(lblInfoLocation.Text.ToString()))
                {
                    //BinQH.BinQH
                        frombinqh = binServ.Read(lblInfoLocation.Text.ToString(), txtFromBin.Text.Trim());
                    //BinQH.BinQH 
                        tobinqh = binServ.Read(lblInfoLocation.Text.ToString(), txtToBin.Text.Trim());
                }
                else
                {
                    //BinQH.BinQH 
                        frombinqh = binServ.Read("QH1", txtFromBin.Text.Trim());
                    //BinQH.BinQH 
                        tobinqh = binServ.Read("QH1", txtToBin.Text.Trim());

                }


                QHBinContent.QHBinContent[] qhbincontent = contentSev.ReadMultiple(ContentArray.ToArray(), null, 0);
                if (!tobinqh.Empty)
                {
                    if (qhbincontent.Length > 0)
                    {
                        ItemQH.ItemQH_Service itemsev = new QHMobile.ItemQH.ItemQH_Service();
                        itemsev.Url = WebServiceInstants.GetURL(ServiceType.ItemQH);
                        itemsev.Credentials = nc;

                        ItemQH.ItemQH itemdescription = itemsev.Read(qhbincontent[0].Item_No.ToString());
                        fishdescription = itemdescription.Description;
                    }

                    if (frombinqh != null && tobinqh != null)
                    {
                        if (qhbincontent.Length > 0)
                        {
                            int notoget=0;
 
                            for (int i = 0; i < qhbincontent.Length; i++)
                            {

                                if (qhbincontent[i].Quantity - qhbincontent[i].PDA_Inv_Pick_Quantity > 0)
                                {
                                    notoget = i;
                                }


                            }


                            if (notoget == 0)
                            {
                                return true;
                            }
                            else if (tobinqh.Location_Code == "QH1" && tobinqh.Empty == false && (!qhbincontent[notoget].Item_No.Equals(txtItemNo.Text.Trim())))
                            {
                                //MessageBox.Show("Bin is not empty and different Item exit. Fish description: " + fishdescription);
                                //return true;
                                return false;
                            }

                            else if (tobinqh.Location_Code == "QH1" && tobinqh.Empty == false && qhbincontent[notoget].Item_No.Equals(txtItemNo.Text.Trim()))
                            {
                                MessageBox.Show("Bin is not empty and Same Item. Fish description: " + fishdescription);
                                return true;
                                //return false;
                            }
                            else
                            {

                                //return false;
                                return true;
                            }

                            

                        }
                        else
                        {
                            if (tobinqh.Empty == false)
                            {

                                MessageBox.Show("Bin is not empty");
                                return false;
                            }
                            else
                            {
                                //return false;
                                return true;
                            }


                        }




                    }
                    else
                    {
                        if (frombinqh == null)
                        {
                            MessageBox.Show("Location is not found. Check your From location and From Bin.");
                        }
                        else
                        {
                            MessageBox.Show("Location is not found. Check your To location and To bin.");
                        }

                        return false;
                    }


                }// IF Empty
                else
                {
                    //if (tobinqh.Code == "QH1" && qhbincontent[0].Item_No.Equals(txtItemNo.Text.Trim()))
                    //{
                    //    MessageBox.Show("Bin is not empty and Same Item. Fish description: " + fishdescription);
                    //    return true;
                    //}
                    //else
                    //{

                    //    return true;
                    //}
                    return true;
                }

            
        }


       private void txtItemNo_KeyDown(object sender, KeyEventArgs e)
        {
            
        }

        private void BindTOGrid()
        {
            GrdTO.DataSource = tableJournal;
        }

        private void InsertLines()
        {
                ItemJournalL insertOneLine = new ItemJournalL();

                Object[] array = new Object[8];

                insertOneLine.postingDate = DateTime.Now;
                array[0] = DateTime.Now;
                insertOneLine.ItemNo = txtItemNo.Text.Trim();
                array[1] = txtItemNo.Text.Trim();
                insertOneLine.location = "QH1";
                array[2] = "QH1";
                insertOneLine.frombin = txtFromBin.Text.Trim();
                array[3] = txtFromBin.Text.Trim();
                insertOneLine.tobin = txtToBin.Text.Trim();
                array[4] = txtToBin.Text.Trim();
                insertOneLine.quantity = Convert.ToInt32(textBox1.Text.Trim());
                array[5] = textBox1.Text.Trim();
                insertOneLine.staffdimension = staffdimension;
                array[6] = staffdimension;
                if (chkEmpty.Checked)
                {
                    insertOneLine.emptyBin = true;
                    array[7] = true;
                }
                else
                {
                    insertOneLine.emptyBin = false;
                    array[7] = false;
                }

                tableJournal.Rows.Add(array);
                journalarray.Add(insertOneLine);

                CompactSQL comsql = new CompactSQL();
                comsql.InsertRecord("ItemReclass", array);

        }

        private void menuItem2_Click(object sender, EventArgs e)
        {
            if (GrdTO == null)
            {
                MessageBox.Show("There is no record to register!");
            }
            else
            {
                Cursor.Current = Cursors.WaitCursor;

                try
                {

                    ItemJournalQH.ItemJournalQH_Service journalService = new QHMobile.ItemJournalQH.ItemJournalQH_Service();
                    journalService.Url = WebServiceInstants.GetURL(ServiceType.ItemJournalQH);
                    journalService.Credentials = nc;

                    for (int i = 0; i < journalarray.Count; i++)
                    {

                        ItemJournalQH.ItemJournalQH journal = new QHMobile.ItemJournalQH.ItemJournalQH();
                        journalService.Create("DEFAULT", ref journal);
                        journal.Document_Date = journalarray[i].postingDate;
                        journal.Document_DateSpecified = true; 
                        journal.Posting_Date = journalarray[i].postingDate;
                        

                        journalService.Update("DEFAULT", ref journal);

                        journal.Item_No = journalarray[i].ItemNo;
                        journal.Location_Code = journalarray[i].location;
                        journal.Bin_Code = journalarray[i].frombin;
                        journal.New_Location_Code = journalarray[i].location;
                        journal.New_Bin_Code = journalarray[i].tobin;
                        journal.Quantity = journalarray[i].quantity;
                        journal.Staff_Dimension_Code = journalarray[i].staffdimension;
                       
                        

                        journalService.Update("DEFAULT", ref journal);
                    }


                    ArrayList tnk = new ArrayList();
                    for (int i = 0; i < journalarray.Count; i++)
                    {
                        if (i == 0)
                        {
                            tnk.Add(journalarray[i].frombin);
                        }
                        else
                        {
                            if (!tnk.Contains(journalarray[i].frombin))
                            {
                                tnk.Add(journalarray[i].frombin);

                            }

                        }
                    }

                    decimal countotal = 0;
                    bool flagtemp = false;
                    string itemtemp;
                    string locationtemp;
                    string bincodetemp;

                    for (int j = 0; j < tnk.Count; j++)
                    {
                        countotal = 0;
                        flagtemp = false;
                        itemtemp = "";
                        locationtemp = "";
                        bincodetemp = "";

                        for (int k = 0; k < journalarray.Count; k++)
                        {
                            if (tnk[j].ToString().Equals(journalarray[k].frombin))
                            {
                                itemtemp = journalarray[k].ItemNo;
                                countotal = countotal + Convert.ToDecimal(journalarray[k].quantity);
                                locationtemp = journalarray[k].location;
                                bincodetemp = journalarray[k].frombin;

                                if (journalarray[k].emptyBin == true)
                                {
                                    flagtemp = true;
                                }
                            }

                        }

                        if (flagtemp == true) //qhbincon[0].Quantity_Base < countotal || 
                        {

                            QHEmptyTank.QHEmptyTank_Service qhempty = new QHMobile.QHEmptyTank.QHEmptyTank_Service();
                            qhempty.Url = WebServiceInstants.GetURL(ServiceType.QHEmptyTank);
                            qhempty.Credentials = nc;

                            QHEmptyTank.QHEmptyTank qhcheck = qhempty.Read(bincodetemp);
                            if (qhcheck == null)
                            {

                                QHEmptyTank.QHEmptyTank qhtnk = new QHMobile.QHEmptyTank.QHEmptyTank();
                                qhtnk.Bin_Code = bincodetemp;

                                qhempty.Create(ref qhtnk);


                                qhtnk.Batch_Name = "IReclass";
                                qhtnk.Item_No = itemtemp;
                                qhtnk.Location_Code = locationtemp;
                                qhempty.Update(ref qhtnk);

                            }
                        }

                    }

                    CompactSQL comsql = new CompactSQL();
                    comsql.deleteRecord("ItemReclass");

                    MessageBox.Show("Submitted to Journal.");
                    
                    TransferOrder tro = new TransferOrder(staffname, staffdimension, stafflevel);
                    tro.Show();
                    GrdTO.DataSource = null; 

                    Cursor.Current = Cursors.Default;

                }
                catch (Exception ex)
                {
                    MessageBox.Show("Eorror:" + ex);
                }
                Cursor.Current = Cursors.Default;
            }
        }

        private void mnuGRNBack_Click(object sender, EventArgs e)
        {
            frmMain msc = new frmMain(staffname,staffdimension,stafflevel);
            msc.Show();
        }

        private void menuItem3_Click(object sender, EventArgs e)
        {
            try
            {
                int count = GetNoOfSelectedRows(GrdTO);

                if (count != -1 || count != null || count != 0)
                {
                    for (int i = 0; i < count; i++)
                    {
                        deleteSelectedRows(GrdTO);
                    }
                }
                else if (count == 0)
                {
                    MessageBox.Show("There is no record to delete.Please select first!");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }


        }

        private ArrayList deleteSelectedRows(DataGrid GrdTO)
        {
            ArrayList al = new ArrayList();

            CurrencyManager cm = (CurrencyManager)this.BindingContext[GrdTO.DataSource];

            DataView dv = (DataView)cm.List;

            bool isFound = false;

            for (int i = 0; i < dv.Count && !isFound; ++i)
            {

                if (GrdTO.IsSelected(i))
                {
                    GrdTO.CurrentRowIndex = i;
                    isFound = true;
                    deleteCurrentRow();
                }
            }

            return al;
           
        }

        private void deleteCurrentRow()
        {
            bool isFound = false;
            if (tableJournal.Rows.Count > 0)
            {
                for (int i = 0; i < tableJournal.Rows.Count; i++)
                {
                    ///thurein
                    if ((tableJournal.Rows[i][0].ToString() == GrdTO[GrdTO.CurrentCell.RowNumber, 0].ToString()) && (tableJournal.Rows[i][1].ToString() == GrdTO[GrdTO.CurrentCell.RowNumber, 1].ToString()) && (tableJournal.Rows[i][2].ToString() == GrdTO[GrdTO.CurrentCell.RowNumber, 2].ToString()) && !isFound)
                    {
                        //subtract from summary table
                        //CalculateSummaryTable(dg_stock[dg_stock.CurrentCell.RowNumber, 0].ToString(), dg_stock[dg_stock.CurrentCell.RowNumber, 1].ToString(), "-" + dg_stock[dg_stock.CurrentCell.RowNumber, 2].ToString(), dg_stock[dg_stock.CurrentCell.RowNumber, 3].ToString());
                        // DeleteToSummaryTable(GrdAddline[GrdAddline.CurrentCell.RowNumber, 0].ToString(), GrdAddline[GrdAddline.CurrentCell.RowNumber, 1].ToString(), "-" + GrdAddline[GrdAddline.CurrentCell.RowNumber, 2].ToString(), GrdAddline[GrdAddline.CurrentCell.RowNumber, 3].ToString());
                        //addToSummaryTable(dg_stock[dg_stock.CurrentCell.RowNumber, 0].ToString(), dg_stock[dg_stock.CurrentCell.RowNumber, 1].ToString(), "-" + dg_stock[dg_stock.CurrentCell.RowNumber, 2].ToString());
                        
                        CompactSQL comsql = new CompactSQL();
                        comsql.deleteRecordLine("ItemReclass",Convert.ToInt32(GrdTO[GrdTO.CurrentCell.RowNumber, 7].ToString().Trim()));
                        tableJournal.Rows.RemoveAt(i);
                        //string aaaaa = GrdTO[GrdTO.CurrentCell.RowNumber, 7].ToString();
                        journalarray.RemoveAt(i);
                        isFound = true;
                    }
                }

            }
        }

        private int GetNoOfSelectedRows(DataGrid GrdTO)
        {

            if (GrdTO.DataSource == null)
            {
                MessageBox.Show("You cannot delete the record which is already registered in Navision.");
                int count = -1;
                return count;
            }
            else
            {
                int count = 0;

                CurrencyManager cm = (CurrencyManager)this.BindingContext[GrdTO.DataSource];

                DataView dv = (DataView)cm.List;

                for (int i = 0; i < dv.Count; ++i)
                {

                    if (GrdTO.IsSelected(i))
                    {

                        count++;

                    }
                }
                return count;
            }
            
        }

        private void label2_ParentChanged(object sender, EventArgs e)
        {

        }

        private void menuItem1_Click(object sender, EventArgs e)
        {
            TransferOrder tof = new TransferOrder(staffname, staffdimension, stafflevel);
            tof.Show();
        }

        private void txtFromBin_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    Cursor.Current = Cursors.WaitCursor;
                    QHBinContent.QHBinContent_Service binserv = new QHMobile.QHBinContent.QHBinContent_Service();
                    binserv.Url = WebServiceInstants.GetURL(ServiceType.QHBinContent);
                    binserv.Credentials = nc;

                    List<QHBinContent.QHBinContent_Filter> listarray = new List<QHMobile.QHBinContent.QHBinContent_Filter>();
                    QHBinContent.QHBinContent_Filter filterqh = new QHMobile.QHBinContent.QHBinContent_Filter();
                    filterqh.Field = QHMobile.QHBinContent.QHBinContent_Fields.Bin_Code;

                    if (string.IsNullOrEmpty(txtFromBin.Text.Trim()))
                    {
                        filterqh.Criteria = "''";
                    }
                    else
                    {
                        filterqh.Criteria = txtFromBin.Text.Trim();
                    }
                    
                    listarray.Add(filterqh);

                    QHBinContent.QHBinContent_Filter filterBaseQty = new QHMobile.QHBinContent.QHBinContent_Filter();
                    filterBaseQty.Field = QHMobile.QHBinContent.QHBinContent_Fields.Quantity;
                    filterBaseQty.Criteria = ">0";
                    listarray.Add(filterBaseQty);

                    QHBinContent.QHBinContent_Filter filterPCS = new QHMobile.QHBinContent.QHBinContent_Filter();
                    filterPCS.Field = QHMobile.QHBinContent.QHBinContent_Fields.Unit_of_Measure_Code;
                    filterPCS.Criteria = "<>''";
                    listarray.Add(filterPCS);



                    QHBinContent.QHBinContent[] qhbin = binserv.ReadMultiple(listarray.ToArray(), null, 0);


                    if (qhbin.Length != 0)
                    {
                        ItemQH.ItemQH_Service itemSev = new QHMobile.ItemQH.ItemQH_Service();
                        itemSev.Url = WebServiceInstants.GetURL(ServiceType.ItemQH);
                        itemSev.Credentials = nc;

                        ItemQH.ItemQH item = itemSev.Read(qhbin[0].Item_No);

                        BinQH.BinQH_Service binqhsev = new QHMobile.BinQH.BinQH_Service();
                        binqhsev.Url = WebServiceInstants.GetURL(ServiceType.BinQH);
                        binqhsev.Credentials = nc;

                        BinQH.BinQH bincheck = binqhsev.Read(qhbin[0].Location_Code, txtFromBin.Text.Trim());

                        //if (bincheck.Block_Movement == QHMobile.BinQH.Block_Movement.All)
                        //{
                        //    MessageBox.Show("This bin is blocked!Please try again.");
                        //    txtFromBin.SelectAll();
                        //    txtFromBin.Focus();
                        //}
                        //else
                        //{
                            txtItemNo.Text = qhbin[0].Item_No;
                            lblInfoLocation.Text = qhbin[0].Location_Code;
                            textBox1.Text = (qhbin[0].Quantity - qhbin[0].PDA_Inv_Pick_Quantity).ToString();


                            txtFishDescription.Text = item.Description;

                            //Cursor.Current = Cursors.Default;

                            txtToBin.Focus();
                        //}
                    }
                    else
                    {
                        BinQH.BinQH_Service binqhsev = new QHMobile.BinQH.BinQH_Service();
                        binqhsev.Url = WebServiceInstants.GetURL(ServiceType.BinQH);
                        binqhsev.Credentials = nc;

                        List<BinQH.BinQH_Filter> filterArray = new List<QHMobile.BinQH.BinQH_Filter>();

                        BinQH.BinQH_Filter binfitler = new QHMobile.BinQH.BinQH_Filter();
                        binfitler.Field = QHMobile.BinQH.BinQH_Fields.Code;
                        binfitler.Criteria = txtFromBin.Text.Trim();


                        filterArray.Add(binfitler);

                        BinQH.BinQH[] bincheck = binqhsev.ReadMultiple(filterArray.ToArray(),null,0);

                        if (bincheck.Length > 0)
                        {
                            lblInfoLocation.Text = bincheck[0].Location_Code;
                            txtItemNo.Focus();
                        }
                        else
                        {
                            MessageBox.Show("Bin Not Found!");
                            txtFromBin.Text = "";
                            txtFromBin.Focus();
                        }
                    }
                }

                Cursor.Current = Cursors.Default;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }
        private string GetPDANamefromConfig()
        {
            string retPDAName = "";
            XmlDocument xmlDoc;
            string ApplicationPath = Path.GetDirectoryName(
                Assembly.GetExecutingAssembly().GetName().CodeBase);
            xmlDoc = new XmlDocument();
            if (!System.IO.File.Exists(ApplicationPath + "\\config.xml"))
            {
                MessageBox.Show("The config.xml file is not exist.\n Cannot Start the Application!");
                Application.Exit();
            }
            xmlDoc.Load(ApplicationPath + "\\config.xml");
            retPDAName = xmlDoc.SelectSingleNode("/config/PDAName").InnerText;
            if ("".Equals(retPDAName))
            {
                retPDAName = "";
            }
            return retPDAName;
        }
        private void mnuPostToNav_Click(object sender, EventArgs e)
        {

            Cursor.Current = Cursors.WaitCursor;

            string strPDAName;
            strPDAName = GetPDANamefromConfig();

            QHEmptyTank.QHEmptyTank_Service empSev = new QHMobile.QHEmptyTank.QHEmptyTank_Service();
            empSev.Url = WebServiceInstants.GetURL(ServiceType.QHEmptyTank);
            empSev.Credentials = nc;

            List<QHEmptyTank.QHEmptyTank_Filter> empfilterArray = new List<QHMobile.QHEmptyTank.QHEmptyTank_Filter>();


            if (grdLineToPost.DataSource != null)
            {
                QH_Functions.QH_Functions qhfun = new QHMobile.QH_Functions.QH_Functions();
                qhfun.Url = WebServiceInstants.GetURL(ServiceType.QH_Functions);
                qhfun.Credentials = nc;
                qhfun.UpdateDepItemReclassicJournal("TRANSFER", "DEFAULT");
                //qhfun.UpdateDepItemJournal("TRANSFER", "DEFAULT");
                qhfun.PostItemJournalReClassic();


                QHEmptyTank.QHEmptyTank_Filter batchfilter = new QHMobile.QHEmptyTank.QHEmptyTank_Filter();
                batchfilter.Field = QHMobile.QHEmptyTank.QHEmptyTank_Fields.Batch_Name;
                batchfilter.Criteria = "IReclass";

                empfilterArray.Add(batchfilter);

                QHEmptyTank.QHEmptyTank[] batchList = empSev.ReadMultiple(empfilterArray.ToArray(), null, 0);

                for (int i = 0; i < batchList.Length; i++)
                {
                    bool templfag = true;
                    qhfun.TankAdj_NAV(batchList[i].Item_No, "", batchList[i].Location_Code, batchList[i].Bin_Code, 0, templfag, staffdimension,strPDAName,"TransferOrder");
                    empSev.Delete(batchList[i].Key.ToString());

                }

                grdLineToPost.DataSource = null;
                MessageBox.Show("Posted Successfully!");

               
                // Post function for TO
            }
            else
            {
                MessageBox.Show("No line to post!");
            }
            Cursor.Current = Cursors.Default;
        }

        private void txtToBin_TextChanged(object sender, EventArgs e)
        {

        }



    }
}