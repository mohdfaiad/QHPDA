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
    public partial class DailyLoss : Form
    {
      
        protected DataTable dt = new DataTable("MyTable");

        protected System.Net.NetworkCredential nc = new System.Net.NetworkCredential(WebServiceInstants.GetURL(ServiceType.userName).ToString(), WebServiceInstants.GetURL(ServiceType.password).ToString(), WebServiceInstants.GetURL(ServiceType.domain).ToString());

        string staffdim,username,userlevel;

        List<DailyLossQH> array_daily = new List<DailyLossQH>();

        String st;

        int updatnumber;

        SqlCeDataReader getdata;

        public DailyLoss(string userd, string staffd, string uleveld)
        {

            InitializeComponent();
            staffdim = staffd;
            username = userd;
            userlevel = uleveld;
            array_daily.Clear();
            dt.Clear();

            txtBinCode.Focus();
            //txtQuantity.Enabled = false;
            dt.Columns.Add(new DataColumn("Posting Date"));
            dt.Columns.Add(new DataColumn("Item No."));
            dt.Columns.Add(new DataColumn("Location"));
            dt.Columns.Add(new DataColumn("Quantity"));
            dt.Columns.Add(new DataColumn("Bin Code"));
            dt.Columns.Add(new DataColumn("Staff Dimsn"));
            dt.Columns.Add(new DataColumn("LineNo"));
            dt.Columns.Add(new DataColumn("EmptyTank"));

           // MnuNewGRN.Enabled = false;
            lblStaffName.Text = staffd + "/Role:" + uleveld;
            Main.Show();
            st = DateTime.Now.ToString("ddMMyyyy");


            CompactSQL comsql = new CompactSQL();
            getdata = comsql.SelectRecord("DailyLoss");
            GetSQLData(getdata);


        }

        private void GetSQLData(SqlCeDataReader getdata)
        {
            dt.Clear();
            array_daily.Clear();
            while (getdata.Read())
            {

                DailyLossQH insert_dl = new DailyLossQH();
                //Object[] array = new Object[6];
                Object[] array = new Object[8];

                insert_dl.itemno = getdata["ItemNo"].ToString() ;
                array[0] = getdata["PostingDate"].ToString();
                insert_dl.location = getdata["Location"].ToString();
                array[1] = getdata["ItemNo"].ToString();
                    
                insert_dl.quantity = getdata["Quantity"].ToString();
                array[2] = getdata["Location"].ToString();
                    
                insert_dl.bincode = getdata["BinCode"].ToString();
                array[3] = getdata["Quantity"].ToString();
                insert_dl.postingDate = getdata["PostingDate"].ToString() ;
                array[4] = getdata["BinCode"].ToString();

                insert_dl.staffdimension = getdata["StaffDimension"].ToString();
                array[5] = getdata["StaffDimension"].ToString();
                array[6] = getdata["Lineno"].ToString();
                insert_dl.sqlLineNum = Convert.ToInt16(getdata["Lineno"]);
                array[7] = getdata["EmptyTank"].ToString();
                insert_dl.emptyTank = Convert.ToBoolean(getdata["EmptyTank"]);

                //array[5] = getdata["StaffDimension"].ToString();

                array_daily.Add(insert_dl);
                dt.Rows.Add(array);

               
            }
            lblCount.Text = dt.Rows.Count.ToString();
            CallGridBind();

        }
           

        private void mnuGRNBack_Click(object sender, EventArgs e)
        {
            this.Close();
            frmMain msc = new frmMain(username, staffdim, userlevel);
            msc.Show();
        }
        private void menuItem3_Click(object sender, EventArgs e)
        {
                Cursor.Current = Cursors.WaitCursor;
                try
                {

                    QH_Functions.QH_Functions qhfun = new QHMobile.QH_Functions.QH_Functions();
                    qhfun.Url = WebServiceInstants.GetURL(ServiceType.QH_Functions);
                    qhfun.Credentials = nc;
                    qhfun.PostItemJournalLineNeg();

                    MessageBox.Show("Journal Lines are posted sucessfully.");
                    Cursor.Current = Cursors.Default;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error" + ex);
                    Cursor.Current = Cursors.Default;
                }
        }

        private void frmGRN_Load(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.Default;

        }
        private void insertCustomer()
        {
            SqlCeConnection conn = null;
            try
            {
                string path;
                path = System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().GetName().CodeBase);
                conn = new SqlCeConnection("Data Source = " + path + "\\Data\\QHMobileDB.sdf;" + "Password ='pass@word1'");
               
                conn.Open();
               
            }
            finally
            {
                conn.Close();
            }
        }

        private string EscalateValue(string Val)
        {
            if (String.IsNullOrEmpty(Val))
            {
                return "";
            }
            else
            {
                return Val;
            }
        }


        private string SplitString(string strInput)
        {
            char[] aChar = strInput.ToCharArray();
            Array.Reverse(aChar);
            string strResult = new string(aChar);
            return strResult;
        }


        private void btnAdd_Click(object sender, EventArgs e)
        {
           
            Cursor.Current = Cursors.WaitCursor;
            try
            {
                if (!string.IsNullOrEmpty(txtBinCode.Text.Trim()) && !string.IsNullOrEmpty(txtQuantity.Text.Trim()) && !txtQuantity.Text.Trim().Equals("0") && !string.IsNullOrEmpty(txtItemNo.Text.Trim()) && !string.IsNullOrEmpty(txtQuantity.Text.Trim()) && !string.IsNullOrEmpty(txtLocation.Text.Trim()) && !string.IsNullOrEmpty(txtPostingDate.Text.Trim()))
                //if (!txtBinCode.Text.Equals("") && !txtQuantity.Text.Equals("") && !txtItemNo.Text.Equals("") && !txtQuantity.Text.Equals("") && !txtLocation.Text.Equals("") && !txtPostingDate.Text.Equals(""))
                {
                    bool isNum = IsItNumber(txtQuantity.Text.Trim());

                    if (isNum)
                    {
                        int flagLocation = QtyValidating();

                        //bool flagItem = ItemValidating();

                        if (flagLocation == 1 || flagLocation == 2)
                        {
                            DailyLossQH insert_dl = new DailyLossQH();
                            Object[] array = new Object[7];

                            insert_dl.itemno = txtItemNo.Text.Trim();
                            array[0] = Convert.ToDateTime(txtPostingDate.Text);

                            insert_dl.location = txtLocation.Text.Trim();
                            array[1] = txtItemNo.Text.Trim();
                            insert_dl.quantity = txtQuantity.Text.Trim();
                            array[2] = txtLocation.Text.Trim();
                            insert_dl.bincode = txtBinCode.Text.Trim();
                            array[3] = txtQuantity.Text.Trim();
                            insert_dl.postingDate = txtPostingDate.Text;
                            array[4] = txtBinCode.Text.Trim();
                            insert_dl.staffdimension = staffdim;
                            array[5] = staffdim;
                            if (chkEmpty.Checked)
                            {
                                insert_dl.emptyTank = true ;
                                array[6] = true;
                            }
                            else
                            {
                                insert_dl.emptyTank = false;
                                array[6] = false;
                            }

 

                            array_daily.Add(insert_dl);
                            dt.Rows.Add(array);
                            lblCount.Text = dt.Rows.Count.ToString();
                            //CallGridBind();

                            CompactSQL comsql = new CompactSQL();
                            comsql.InsertRecord("DailyLoss", array);

                            getdata = comsql.SelectRecord("DailyLoss");
                            GetSQLData(getdata);
                            

                            txtQuantity.Text = "";
                            txtItemNo.Text = "";
                            txtLocation.Text = "";
                            txtPostingDate.Text = "";
                            txtBinCode.Enabled = true;
                            txtBinCode.Text = "";
                            txtBinCode.Focus();
                            chkEmpty.Checked = false;

                        }
                        else if (flagLocation == 3)
                        {
                            MessageBox.Show("Item Not found!");
                        }
                        else
                        {
                            //MessageBox.Show("Item Not found!");
                            txtQuantity.Focus();
                            //if (flagLocation == 2)
                            //{
                            //    MessageBox.Show("Item Not found!");
                            //    txtQuantity.Focus();
                            //}
                            //else
                            //{
                            //    MessageBox.Show("Item is not found.");
                            //    txtItemNo.Focus();
                            //}
                        }

                    }
                    else
                    {
                        MessageBox.Show("Quantity value must be integer.");
                        txtQuantity.Text = "";
                        txtQuantity.Focus();
                    }

                    txtQuantity.Enabled = false;
                    txtPostingDate.Enabled = false;
                    //txtBinCode.Enabled = true;

                }
                else
                {
                    MessageBox.Show("All fields are required to enter and quantity must be larger than 0.");
                    txtBinCode.SelectAll();
                    txtBinCode.Focus();
                }

                
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }

            Cursor.Current = Cursors.Default;
        }

        private bool IsItNumber(string inputvalue)
        {
            Regex isnumber = new Regex("[^0-9]");
            return !isnumber.IsMatch(inputvalue);
        }

        private bool ItemValidating()
        {
            ItemQH.ItemQH_Service itemQHserv = new QHMobile.ItemQH.ItemQH_Service();
            itemQHserv.Url = WebServiceInstants.GetURL(ServiceType.ItemQH);
            itemQHserv.Credentials = nc;

            ItemQH.ItemQH itemqh = itemQHserv.Read(txtItemNo.Text.Trim());

            if (itemqh != null)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        private int QtyValidating()
        {
            try
            {

                QHBinContent.QHBinContent_Service qhserv = new QHMobile.QHBinContent.QHBinContent_Service();
                qhserv.Url = WebServiceInstants.GetURL(ServiceType.QHBinContent);
                qhserv.Credentials = nc;

                List<QHBinContent.QHBinContent_Filter> filterarray = new List<QHMobile.QHBinContent.QHBinContent_Filter>();

                QHBinContent.QHBinContent_Filter binfilter = new QHMobile.QHBinContent.QHBinContent_Filter();
                binfilter.Field = QHMobile.QHBinContent.QHBinContent_Fields.Bin_Code;
                binfilter.Criteria = txtBinCode.Text.Trim();

                //QHBinContent.QHBinContent_Filter qtyfilter = new QHMobile.QHBinContent.QHBinContent_Filter();
                //qtyfilter.Field = QHMobile.QHBinContent.QHBinContent_Fields.Quantity_Base;
                //qtyfilter.Criteria = "<>0";

                QHBinContent.QHBinContent_Filter qtyfilter = new QHMobile.QHBinContent.QHBinContent_Filter();
                qtyfilter.Field = QHMobile.QHBinContent.QHBinContent_Fields.Unit_of_Measure_Code;
                qtyfilter.Criteria = "<>''";

                QHBinContent.QHBinContent_Filter itemfilter = new QHMobile.QHBinContent.QHBinContent_Filter();
                itemfilter.Field = QHMobile.QHBinContent.QHBinContent_Fields.Item_No;
                itemfilter.Criteria = txtItemNo.Text.Trim();

                filterarray.Add(binfilter);
                filterarray.Add(itemfilter);
                filterarray.Add(qtyfilter);

                QHBinContent.QHBinContent[] binqh = qhserv.ReadMultiple(filterarray.ToArray(), null, 5);


                if (binqh.Length != 0)
                {
                    //if (binqh[0].Quantity_Base < Convert.ToInt32(txtQuantity.Text))
                    //{
                    //    return 0;
                    //}
                    //{

                        return 1;
                    //}
                }
                else
                {
                    BinQH.BinQH_Service binservice = new QHMobile.BinQH.BinQH_Service();
                    binservice.Url = WebServiceInstants.GetURL(ServiceType.BinQH);
                    binservice.Credentials = nc; 

                    List<BinQH.BinQH_Filter> filterArr = new List<QHMobile.BinQH.BinQH_Filter>();

                    BinQH.BinQH_Filter bincodefilter = new QHMobile.BinQH.BinQH_Filter();
                    bincodefilter.Field = QHMobile.BinQH.BinQH_Fields.Code;
                    bincodefilter.Criteria = txtBinCode.Text.Trim();

                    filterArr.Add(bincodefilter);


                    BinQH.BinQH[] binqhget = binservice.ReadMultiple(filterArr.ToArray(), null, 3);

                    if (binqhget.Length == 0)
                    {
                        return 3;
                    }
                    else
                    {
                        return 2;
                    }
                }
                
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return 2;
            }
          
        }

        private void CallGridBind()
        {
            GrdDailyLoss.DataSource = dt;
        }

        private void menuItem1_Click(object sender, EventArgs e)
        {
            if (GrdDailyLoss.DataSource == null)
            {
                MessageBox.Show("There is no record to register!");
            }
            else
            {
                Cursor.Current = Cursors.WaitCursor;

                try
                {
                    
                        decimal countotal = 0;
                        bool flagtemp = false;
                        string itemtemp;
                        string locationtemp;
                        string bincodetemp;


                        ItemJournalDailyLossQH.ItemJournalDailyLossQH_Service dlservice = new QHMobile.ItemJournalDailyLossQH.ItemJournalDailyLossQH_Service();
                        dlservice.Url = WebServiceInstants.GetURL(ServiceType.ItemJournalDailyLossQH);
                        dlservice.Credentials = nc;

                        for (int i = 0; i < array_daily.Count; i++)
                        {

                            if (array_daily[i].lineNum.Equals("") || array_daily[i].lineNum == 0)
                            {
                                ItemJournalDailyLossQH.ItemJournalDailyLossQH dl = new QHMobile.ItemJournalDailyLossQH.ItemJournalDailyLossQH();

                                dlservice.Create("DOA", ref dl); // Actual value should be DOA

                                ItemJournalDailyLossQH.ItemJournalDailyLossQH dlupdate = new QHMobile.ItemJournalDailyLossQH.ItemJournalDailyLossQH();
                                dlupdate = dlservice.Read("DOA", dl.Line_No);

                                //added by Hsu 23 april 2013// 
                                array_daily[i].lineNum = dl.Line_No;

                                // added by Hsu 23 april 2013 // 
                                dlupdate.Posting_Date = Convert.ToDateTime(array_daily[i].postingDate);
                                dlupdate.Posting_DateSpecified = true;
                                dlupdate.Entry_Type = ItemJournalDailyLossQH.Entry_Type.Negative_Adjmt;
                                dlupdate.Entry_TypeSpecified = true;
                                dlupdate.Item_No = array_daily[i].itemno;

                                st = DateTime.Now.ToString("ddMMyyyy");
                                dlupdate.Document_No = st;

                                //dlservice.Update("DOA", ref dlupdate);

                                dlupdate.Quantity = Convert.ToInt32(array_daily[i].quantity);
                                dlupdate.Location_Code = array_daily[i].location;
                                dlupdate.Staff_Dimension_Code = staffdim;
                                dlupdate.Bin_Code = array_daily[i].bincode;

                                dlservice.Update("DOA", ref dlupdate);
                                //array_daily.RemoveAt(i);
                            }

                            CompactSQL comsql = new CompactSQL();
                            comsql.DeleteOneRecord(array_daily[i].sqlLineNum,"DailyLoss");


                        }
                        //// to adjust //// 

                        ArrayList tnk = new ArrayList();
                        for (int i = 0; i < array_daily.Count; i++)
                        {
                            if (i == 0)
                            {
                                tnk.Add(array_daily[i].bincode);
                            }
                            else
                            {
                                if (!tnk.Contains(array_daily[i].bincode))
                                {
                                    tnk.Add(array_daily[i].bincode);

                                }

                            }
                        }

                        for (int j = 0; j < tnk.Count; j++)
                        {
                            countotal = 0;
                            flagtemp = false;
                            itemtemp = "";
                            locationtemp = "";
                            bincodetemp = "";

                            for (int k = 0; k < array_daily.Count; k++)
                            {
                                if (tnk[j].ToString().Equals(array_daily[k].bincode))
                                {
                                    itemtemp = array_daily[k].itemno;
                                    countotal = countotal + Convert.ToDecimal(array_daily[k].quantity);
                                    locationtemp = array_daily[k].location;
                                    bincodetemp = array_daily[k].bincode;

                                    if (array_daily[k].emptyTank == true)
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
                                    
                                    
                                    qhtnk.Batch_Name = "DOA";
                                    qhtnk.Item_No = itemtemp;
                                    qhtnk.Location_Code = locationtemp;
                                    qhempty.Update(ref qhtnk);

                                }
                            }
                            
                        }

                        //// to adjsut ////

                        //CompactSQL comsql = new CompactSQL();
                        //comsql.deleteRecord("DailyLoss");

                        MessageBox.Show("Submitted.");
                        Cursor.Current = Cursors.Default;
                        GrdDailyLoss.DataSource = null;
                        this.Close();
                        DailyLoss dlf = new DailyLoss(username, staffdim, userlevel);
                        dlf.Show();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error:" + ex);
                    Cursor.Current = Cursors.Default;
                }
            }
        }

   
        private void menuItem3_Click_1(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
            try
            {
                int count = GetNoOfSelectedRows(GrdDailyLoss);

                if (count == 0)
                {
                    MessageBox.Show("Please select the reocrd first!");
                }
                else
                {
                    for (int i = 0; i < count; i++)
                    {
                        deleteSelectedRows(GrdDailyLoss);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
            Cursor.Current = Cursors.Default;
        }

        private ArrayList deleteSelectedRows(DataGrid GrdDailyLoss)
        {
            ArrayList al = new ArrayList();

            CurrencyManager cm = (CurrencyManager)this.BindingContext[GrdDailyLoss.DataSource];

            DataView dv = (DataView)cm.List;

            bool isFound = false;

            for (int i = 0; i < dv.Count && !isFound; ++i)
            {

                if (GrdDailyLoss.IsSelected(i))
                {
                    GrdDailyLoss.CurrentRowIndex = i;
                    isFound = true;
                    deleteCurrentRow();
                }
            }

            return al;
        }

        private void deleteCurrentRow()
        {
            bool isFound = false;
            if (dt.Rows.Count > 0)
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    //if ((dt.Rows[i][0].ToString() == GrdDailyLoss[GrdDailyLoss.CurrentCell.RowNumber, 0].ToString()) && 
                    //    (dt.Rows[i][1].ToString() == GrdDailyLoss[GrdDailyLoss.CurrentCell.RowNumber, 1].ToString()) &&
                    //    (dt.Rows[i][2].ToString() == GrdDailyLoss[GrdDailyLoss.CurrentCell.RowNumber, 2].ToString()) &&
                    //    (dt.Rows[i][3].ToString() == GrdDailyLoss[GrdDailyLoss.CurrentCell.RowNumber, 3].ToString()) &&
                    //    (dt.Rows[i][5].ToString() == GrdDailyLoss[GrdDailyLoss.CurrentCell.RowNumber, 4].ToString()) &&
                    //    !isFound)
                    if ((dt.Rows[i][6].ToString() == GrdDailyLoss[GrdDailyLoss.CurrentCell.RowNumber, 6].ToString()) &&
                   !isFound)
                    {
 
                        CompactSQL comsql = new CompactSQL();
                        comsql.deleteRecordLine("DailyLoss",Convert.ToInt32(GrdDailyLoss[GrdDailyLoss.CurrentCell.RowNumber, 6].ToString().Trim()));
                        dt.Rows.RemoveAt(i);
                        array_daily.RemoveAt(i);

                        getdata = comsql.SelectRecord("DailyLoss");
                        GetSQLData(getdata);

                        isFound = true;
                    }
                }

            }
        }

        private int GetNoOfSelectedRows(DataGrid GrdDailyLoss)
        {
            int count = 0;

            CurrencyManager cm = (CurrencyManager)this.BindingContext[GrdDailyLoss.DataSource];

            DataView dv = (DataView)cm.List;

            for (int i = 0; i < dv.Count; ++i)
            {

                if (GrdDailyLoss.IsSelected(i))
                {

                    count++;
                    updatnumber = i;

                }
            }
            return count;
        }

        private void txtBinCode_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {

                    Cursor.Current = Cursors.WaitCursor;

                    QHBinContent.QHBinContent_Service qhbinServ = new QHMobile.QHBinContent.QHBinContent_Service();
                    qhbinServ.Url = WebServiceInstants.GetURL(ServiceType.QHBinContent);
                    qhbinServ.Credentials = nc;

                    List<QHBinContent.QHBinContent_Filter> filterArray = new List<QHMobile.QHBinContent.QHBinContent_Filter>();
                    QHBinContent.QHBinContent_Filter filter = new QHMobile.QHBinContent.QHBinContent_Filter();
                    filter.Field = QHMobile.QHBinContent.QHBinContent_Fields.Bin_Code;

                    if (string.IsNullOrEmpty(txtBinCode.Text.Trim()))
                    {
                        filter.Criteria = "''";
                    }
                    else
                    {
                        filter.Criteria = txtBinCode.Text.Trim();
                    }

                    QHBinContent.QHBinContent_Filter filterBaseQty = new QHMobile.QHBinContent.QHBinContent_Filter();
                    filterBaseQty.Field = QHMobile.QHBinContent.QHBinContent_Fields.Quantity;
                    filterBaseQty.Criteria = ">0";

                    QHBinContent.QHBinContent_Filter filterPCS = new QHMobile.QHBinContent.QHBinContent_Filter();
                    filterPCS.Field = QHMobile.QHBinContent.QHBinContent_Fields.Unit_of_Measure_Code;
                    filterPCS.Criteria = "<>''";


                    filterArray.Add(filter);
                    filterArray.Add(filterPCS);
                    filterArray.Add(filterBaseQty);

                    QHBinContent.QHBinContent[] qhbin = qhbinServ.ReadMultiple(filterArray.ToArray(), null, 10);

                    BinQH.BinQH_Service binsev = new QHMobile.BinQH.BinQH_Service();
                    binsev.Url = WebServiceInstants.GetURL(ServiceType.BinQH);
                    binsev.Credentials = nc;


                    if (qhbin.Length != 0)
                    {
                        BinQH.BinQH binbl = binsev.Read(qhbin[0].Location_Code, txtBinCode.Text.Trim());

                        if (binbl.Block_Movement == QHMobile.BinQH.Block_Movement.All)
                        {
                            MessageBox.Show("This Bin is blocked.Hence please try again!");
                        }
                    
                        else
                        {
                            txtLocation.Text = qhbin[0].Location_Code;
                            txtItemNo.Text = qhbin[0].Item_No;
                            txtQuantity.Text = "0";//qhbin[0].Quantity_Base.ToString();
                            txtPostingDate.Text = DateTime.Now.ToShortDateString();


                            txtQuantity.Enabled = true;
                            txtPostingDate.Enabled = true;
                            txtBinCode.Enabled = false;

                            if ((qhbin[0].Location_Code.ToString() != "RT1") || (qhbin[0].Location_Code.ToString() != "LS1"))
                            {
                                txtItemNo.Enabled = true;

                            }
                        }

                        txtQuantity.SelectAll();
                        txtQuantity.Focus();
                    }
                    else
                    {
                        List<BinQH.BinQH_Filter> filterBinArr = new List<QHMobile.BinQH.BinQH_Filter>();

                        BinQH.BinQH_Filter binfilter = new QHMobile.BinQH.BinQH_Filter();
                        binfilter.Field = QHMobile.BinQH.BinQH_Fields.Code;

                        if (string.IsNullOrEmpty(txtBinCode.Text.Trim()))
                        {
                            binfilter.Criteria = "''";
                        }
                        else
                        {
                            binfilter.Criteria = txtBinCode.Text.Trim();
                        }

                        filterBinArr.Add(binfilter);

                        BinQH.BinQH[] bingetlist = binsev.ReadMultiple(filterBinArr.ToArray(), null, 3);

                        if (bingetlist.Length != 0)
                        {
                            txtLocation.Text = bingetlist[0].Location_Code;
                            txtItemNo.Text = "";
                            txtQuantity.Text = "0";//qhbin[0].Quantity_Base.ToString();
                            txtPostingDate.Text = DateTime.Now.ToShortDateString();
                            txtItemNo.Enabled = true;
                            txtQuantity.Enabled = true;
                            txtItemNo.Focus();

                        }
                        else
                        {
                            MessageBox.Show("Bin Not found!");
                            txtItemNo.Text = "";
                        }
                    }

                    
                    Cursor.Current = Cursors.Default;


                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
        }

    
        private void txtQuantity_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Tab)
            {
                txtPostingDate.SelectAll();
                txtPostingDate.Focus();
            }
        }

      
        private void tbMain_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (tbMain.SelectedIndex == 1)
            {
                int count = GetNoOfSelectedRows(GrdDailyLoss);

                if (count == 0 )
                {
                    MessageBox.Show("Please select the record first!");
                }
                else
                {
                    for (int i = 0; i < count; i++)
                    {
                        UpdateSelectedRows(GrdDailyLoss);
                    }
                }


            }
        }

        private ArrayList UpdateSelectedRows(DataGrid GrdDailyLoss)
        {
            ArrayList al = new ArrayList();

            CurrencyManager cm = (CurrencyManager)this.BindingContext[GrdDailyLoss.DataSource];

            DataView dv = (DataView)cm.List;

            bool isFound = false;

            lblStaffCode.Text = staffdim;
            lblRole.Text = userlevel;

            for (int i = 0; i < dv.Count && !isFound; ++i)
            {

                if (GrdDailyLoss.IsSelected(i))
                {
                  
                    txtEditItemNo.Text = array_daily[i].itemno;
                    txtEditQty.Text = array_daily[i].quantity.ToString();
                    txtEditBinCode.Text = array_daily[i].bincode;
                    txtEditLocation.Text = array_daily[i].location ;
                    txtLineNo.Text = GrdDailyLoss[GrdDailyLoss.CurrentCell.RowNumber,6 ].ToString();
                    //isFound = true;

                }
            }

            return al;
        }

        private void btnSaveUpdate_Click(object sender, EventArgs e)
        {

            array_daily[updatnumber].bincode = txtEditBinCode.Text;
            array_daily[updatnumber].quantity = txtEditQty.Text;

            GrdDailyLoss.DataSource = null;
            dt.Clear();

            //for (int i = 0; i < array_daily.Count; i++)
            //{
            //    Object[] array = new Object[6];

            //    array[0] = array_daily[i].itemno;
            //    array[1] = array_daily[i].location;
            //    array[2] = array_daily[i].bincode;
            //    array[3] = array_daily[i].quantity;
            //    array[4] = array_daily[i].postingDate;
            //    array[5] = array_daily[i].staffdimension;

            //    dt.Rows.Add(array);

            //}

            CompactSQL comsql = new CompactSQL();
            comsql.updateDailyLoss( Convert.ToInt32(txtEditQty.Text.ToString()), Convert.ToInt32(txtLineNo.Text.ToString()));

            getdata = comsql.SelectRecord("DailyLoss");
            GetSQLData(getdata);

            //GrdDailyLoss.DataSource = dt;

            MessageBox.Show("Updated Succesfully!");
        }

        private void txtItemNo_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txtQuantity.SelectAll();
                txtQuantity.Focus();
            }
        }

        private void GrdDailyLoss_CurrentCellChanged(object sender, EventArgs e)
        {

        }

      

      
       
    }
}