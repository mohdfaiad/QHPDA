using System;
using System.Linq;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Text.RegularExpressions;
using System.Collections;
using System.Data.SqlServerCe;

namespace QHMobile
{
    public partial class DailyLossTS : Form
    {
        List<DailyLossFormTS> dl_array = new List<DailyLossFormTS>();
        protected DataTable dt = new DataTable("MyTable");
        protected DataTable dtpost = new DataTable("Posting Table");
        
        protected System.Net.NetworkCredential nc = new System.Net.NetworkCredential(WebServiceInstants.GetURL(ServiceType.userName).ToString(), WebServiceInstants.GetURL(ServiceType.password).ToString(), WebServiceInstants.GetURL(ServiceType.domain).ToString());
        string staffdim,staffname,stafflevel;
        static int count;
        static string tempitem;
        SqlCeDataReader getdata;


        public DailyLossTS(string usname,string staffdimen,string uslevel)
        {
            InitializeComponent();
            try
            {

                staffdim = staffdimen;
                staffname = usname;
                stafflevel = uslevel;

                dl_array.Clear();
                dt.Clear();
                dtpost.Clear();
                GrdDailyLoss.DataSource = null;
                
                lblStaffName.Text = staffdim + "/Role:" + uslevel;
                count = 0;
                dt.Columns.Add("Item No");
                dt.Columns.Add("Description");
                dt.Columns.Add("EntryType");
                dt.Columns.Add("Location");
                dt.Columns.Add("Bin Code");
                dt.Columns.Add("Quantity");
                dt.Columns.Add("StaffDimension");
                dt.Columns.Add("PostingDate");
                dt.Columns.Add("LineNo");
                dt.Columns.Add("EmptyTank");


                dtpost.Columns.Add("Item No");
                dtpost.Columns.Add("Location");
                dtpost.Columns.Add("Bin Code");
                dtpost.Columns.Add("Entry Type");
                dtpost.Columns.Add("Quantity");
                BindToPost();

                CompactSQL comsql = new CompactSQL();
                getdata = comsql.SelectRecord("ChangeSize");
                GetSQLData(getdata);


                if (uslevel.Equals("Super"))
                {
                    tbDL.Show();

                    menuItem1.Enabled = true;
                }
                else
                {
                    tbDL.Show();
                    menuItem1.Enabled = true;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void GetSQLData(SqlCeDataReader getdata)
        {
            try
            {
                dl_array.Clear();
                dt.Clear();
                while (getdata.Read())
                {
                    DailyLossFormTS insert = new DailyLossFormTS();
                    Object[] array = new Object[10];

                    insert.itemno = getdata["ItemNo"].ToString();
                    array[0] = getdata["ItemNo"].ToString();

                    insert.entrytype = getdata["EntryType"].ToString();
                    array[1] = getdata["Description"].ToString();
                        //getdata["EntryType"].ToString();

                    insert.location = getdata["Location"].ToString();
                    array[2] = getdata["EntryType"].ToString();
                        //getdata["Location"].ToString();
                    insert.bincode = getdata["BinCode"].ToString();
                    array[3] = getdata["Location"].ToString();
                        //getdata["BinCode"].ToString();

                    insert.quantity = getdata["Quantity"].ToString();
                    array[4] = getdata["BinCode"].ToString();
                        //getdata["Quantity"].ToString();
                    insert.staffdimension = getdata["StaffDimension"].ToString();
                    array[5] = getdata["Quantity"].ToString();
                        //getdata["StaffDimension"].ToString();

                    insert.postdate = getdata["PostingDate"].ToString();
                    array[6] = getdata["StaffDimension"].ToString();
                        //Convert.ToDateTime(getdata["PostingDate"]);

                    insert.description = getdata["Description"].ToString();
                    array[7] = getdata["PostingDate"].ToString();
                        //getdata["Description"].ToString();
                    
                    array[8] = Convert.ToInt32(getdata["LineNo"]);

                    array[9] = getdata["EmptyTank"];
                    insert.EmptyTank = Convert.ToBoolean(getdata["EmptyTank"]);

                    dl_array.Add(insert);
                    dt.Rows.Add(array);

                }
                lblCount.Text = dt.Rows.Count.ToString();
                CallBindGrid();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        public DailyLossTS(string usname, string staffdimen, string uslevel, List<DailyLossFormTS> rebindArray, DailyLossFormTS currentControl)
        {
            try
            {
                InitializeComponent();
                staffname = usname;
                stafflevel = uslevel;
                staffdim = staffdimen;

                string[] tempstr = currentControl.itemno.Split('~');

                txtItemNo.Text = tempstr[0].ToString();
                txtBinCode.Text = currentControl.bincode;
                txtLocation.Text = currentControl.location;
                cboEntryType.SelectedItem = currentControl.entrytype;
                txtPostingDate.Text = currentControl.postdate.ToString();
                txtQuantity.Text = currentControl.quantity;
                txtDescription.Text = tempstr[1].ToString();

                lblStaffName.Text = staffdim + "/Role:" + uslevel;

                RebindToGrid(rebindArray);
                
                CompactSQL comsql = new CompactSQL();
                getdata = comsql.SelectRecord("ChangeSize");
                GetSQLData(getdata);
                ///
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        private void RebindToGrid(List<DailyLossFormTS> rebindArray)
        {
            dt.Columns.Add("Item No");
            dt.Columns.Add("Description");
            dt.Columns.Add("EntryType");
            dt.Columns.Add("Location");
            dt.Columns.Add("Bin Code");
            dt.Columns.Add("Quantity");
            dt.Columns.Add("StaffDimension");
            dt.Columns.Add("PostingDate");
            dt.Columns.Add("LineNo");
            dt.Columns.Add("EmptyTank");



            for (int i = 0; i < rebindArray.Count; i++)
            {
                Object[] array = new Object[9];
                array[0] = rebindArray[i].itemno;
                array[1] = rebindArray[i].description;
                array[2] = rebindArray[i].entrytype;
                array[3] = rebindArray[i].location;
                array[4] = rebindArray[i].bincode;
                array[5] = rebindArray[i].quantity;
                array[6] = rebindArray[i].staffdimension;
                array[7] = rebindArray[i].postdate;

                if (chkEmpty.Checked)
                {
                    array[8] = true;
                }
                else
                {
                    array[8] = false;
                }

                dt.Rows.Add(array);
            }
            dl_array = rebindArray;
            GrdDailyLoss.DataSource = dt;
        }

        
        private void BindToPost()
        {
            ItemJournalDailyLossQH.ItemJournalDailyLossQH_Service sev = new QHMobile.ItemJournalDailyLossQH.ItemJournalDailyLossQH_Service();
            sev.Credentials = nc;
            sev.Url = WebServiceInstants.GetURL(ServiceType.ItemJournalDailyLossQH);
            ItemJournalDailyLossQH.ItemJournalDailyLossQH[] journal = sev.ReadMultiple("DEFAULT", null, null, 0);

            for (int i = 0; i < journal.Length; i++)
            {
                Object[] array = new Object[5];

                array[0] = journal[i].Item_No;
                array[1] = journal[i].Location_Code;
                array[2] = journal[i].Bin_Code;
                array[3] = journal[i].Entry_Type;
                array[4] = journal[i].Quantity;
                dtpost.Rows.Add(array);
            }
        }
       
        private void btnAdd_Click(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
            try
            {
                if (cboEntryType.SelectedText.Equals("Positive Adjmt.") && chkEmpty.Checked == true)
                {
                    MessageBox.Show("PDA: You cannot now allow to empty the bin in positive state.");
                }
                else
                {
                    if (count == 0)
                    {

                        if(!string.IsNullOrEmpty(txtItemNo.Text.Trim()) && !string.IsNullOrEmpty(txtBinCode.Text.Trim()) && !string.IsNullOrEmpty(txtLocation.Text.Trim()) && !string.IsNullOrEmpty(txtQuantity.Text.Trim()) && !txtQuantity.Text.Trim().Equals("0"))
                        //if (!txtItemNo.Text.Equals("") && !txtBinCode.Text.Equals("") && !txtLocation.Text.Equals("") && !txtQuantity.Text.Equals(""))
                        {
                            bool isNum = IsItNumber(txtQuantity.Text.Trim());

                            if (isNum)
                            {

                                bool flagLocation = LocationValidating();

                                bool flagItem = ItemValidating();

                                if (flagLocation == true && flagItem == true)
                                {

                                    DailyLossFormTS insert = new DailyLossFormTS();
                                    Object[] array = new Object[9];

                                    insert.itemno = txtItemNo.Text.Trim();
                                    array[0] = txtItemNo.Text.Trim();
                                    insert.entrytype = cboEntryType.Text.Trim();
                                    array[1] = txtDescription.Text.Trim();
                                    insert.description = txtDescription.Text.Trim();
                                    array[2] = cboEntryType.Text.Trim();
                                    insert.location = txtLocation.Text.Trim();
                                    array[3] = txtLocation.Text.Trim();
                                    insert.bincode = txtBinCode.Text.Trim();
                                    array[4] = txtBinCode.Text.Trim();
                                    insert.quantity = txtQuantity.Text.Trim();
                                    array[5] = txtQuantity.Text.Trim();
                                    insert.staffdimension = staffdim;
                                    array[6] = staffdim;
                                    insert.postdate = txtPostingDate.Text.Trim();
                                    array[7] = Convert.ToDateTime(txtPostingDate.Text.Trim());
                                    if (chkEmpty.Checked)
                                    {
                                        array[8] = true;
                                    }
                                    else
                                    {
                                        array[8] = false;
                                    }
                                    dl_array.Add(insert);
                                    dt.Rows.Add(array);
                                    lblCount.Text = dt.Rows.Count.ToString();

                                    //tempthu
                                    CompactSQL comsql = new CompactSQL();
                                    comsql.InsertRecord("ChangeSize", array);

                                    getdata = comsql.SelectRecord("ChangeSize");//test3
                                    GetSQLData(getdata);//test3
                                    CallBindGrid();
                                    //tempthu
                                    //CompactSQL comsql = new CompactSQL();
                                    //comsql.InsertRecord("ChangeSize", array);

                                }
                                else
                                {
                                    if (flagLocation == false)
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
                                            MessageBox.Show("Location and Bin is not found.");
                                            txtItemNo.SelectAll();
                                            txtItemNo.Focus();
                                        }
                                        else
                                        {
                                            DailyLossFormTS insert = new DailyLossFormTS();
                                            Object[] array = new Object[9];

                                            insert.itemno = txtItemNo.Text.Trim();
                                            array[0] = txtItemNo.Text.Trim();
                                            insert.entrytype = cboEntryType.Text.Trim();
                                            array[1] = txtDescription.Text.Trim();
                                            insert.description = txtDescription.Text.Trim();
                                            array[2] = cboEntryType.Text.Trim();
                                            insert.location = txtLocation.Text.Trim();
                                            array[3] = txtLocation.Text.Trim();
                                            insert.bincode = txtBinCode.Text.Trim();
                                            array[4] = txtBinCode.Text.Trim();
                                            insert.quantity = txtQuantity.Text.Trim();
                                            array[5] = txtQuantity.Text.Trim();
                                            insert.staffdimension = staffdim;
                                            array[6] = staffdim;
                                            insert.postdate = txtPostingDate.Text.Trim();
                                            array[7] = Convert.ToDateTime(txtPostingDate.Text.Trim());
                                            if (chkEmpty.Checked)
                                            {
                                                array[8] = true;
                                            }
                                            else
                                            {
                                                array[8] = false;
                                            }
                                            dl_array.Add(insert);
                                            dt.Rows.Add(array);
                                            lblCount.Text = dt.Rows.Count.ToString();

                                            //tempthu
                                            CompactSQL comsql = new CompactSQL();
                                            comsql.InsertRecord("ChangeSize", array);

                                            getdata = comsql.SelectRecord("ChangeSize");//test3
                                            GetSQLData(getdata);//test3
                                            CallBindGrid();
                                        }
                                    }
                                    
                                }
                            }
                        }
                        else
                        {
                            MessageBox.Show("All fields are required to enter.");
                        }

                        count = count + 1;
                        txtItemNo.SelectAll();
                        txtItemNo.Focus();

                    }
                    else
                    {

                        if (!string.IsNullOrEmpty(txtItemNo.Text.Trim()) && !string.IsNullOrEmpty(txtBinCode.Text.Trim()) && !string.IsNullOrEmpty(txtLocation.Text.Trim()) && !string.IsNullOrEmpty(txtQuantity.Text.Trim()) && !txtQuantity.Text.Trim().Equals("0"))
                        {
                            bool isNum = IsItNumber(txtQuantity.Text.Trim());

                            if (isNum)
                            {

                                // bool flagLocation = LocationValidating();

                                bool flagItem = ItemValidating();

                                if (flagItem == true)
                                {
                                    count = 0;

                                    DailyLossFormTS insert = new DailyLossFormTS();
                                    Object[] array = new Object[9];

                                    insert.itemno = txtItemNo.Text.Trim();
                                    array[0] = txtItemNo.Text.Trim();
                                    insert.entrytype = cboEntryType.Text.Trim();
                                    array[1] = txtDescription.Text.Trim();
                                    insert.description = txtDescription.Text.Trim();
                                    array[2] = cboEntryType.Text.Trim();
                                    insert.location = txtLocation.Text.Trim();
                                    array[3] = txtLocation.Text.Trim();
                                    insert.bincode = txtBinCode.Text.Trim();
                                    array[4] = txtBinCode.Text.Trim();
                                    insert.quantity = txtQuantity.Text.Trim();
                                    array[5] = txtQuantity.Text.Trim();
                                    insert.staffdimension = staffdim;
                                    array[6] = staffdim;
                                    insert.postdate = txtPostingDate.Text.Trim();
                                    array[7] = Convert.ToDateTime(txtPostingDate.Text.Trim());
                                    if (chkEmpty.Checked)
                                    {
                                        array[8] = true;
                                    }
                                    else
                                    {
                                        array[8] = false;
                                    }

                                    dl_array.Add(insert);
                                    dt.Rows.Add(array);
                                    lblCount.Text = dt.Rows.Count.ToString();
                                    CallBindGrid();

                                    //CompactSQL comsql = new CompactSQL();
                                    //comsql.InsertRecord("ChangeSize", array);

                                    //tempthu
                                    CompactSQL comsql = new CompactSQL();
                                    comsql.InsertRecord("ChangeSize", array);

                                    getdata = comsql.SelectRecord("ChangeSize");//test3
                                    GetSQLData(getdata);//test3
                                    CallBindGrid();
                                    //tempthu

                                }
                                else
                                {
                                    if (flagItem == false)
                                    {
                                        MessageBox.Show("Item is not found.");
                                        txtItemNo.Focus();
                                    }
                                }
                            }
                        }
                        else
                        {
                            MessageBox.Show("All fields are required to enter.");
                        }

                    }

                    if (count == 1)
                    {

                        // txtBinCode.Enabled = false;
                        //txtItemNo.Enabled = true;
                        txtLocation.Enabled = false;
                        cboEntryType.Text = cboEntryType.Items[0].ToString();


                    }
                    else
                    {
                        txtBinCode.Enabled = true;
                        txtBinCode.Text = "";
                        txtItemNo.Enabled = true;
                        txtItemNo.Text = "";
                        txtLocation.Enabled = true;
                        txtLocation.Text = "";
                        txtQuantity.Text = "";
                        txtBinCode.Focus();
                        cboEntryType.Text = cboEntryType.Items[1].ToString();
                    }
                    Cursor.Current = Cursors.Default;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                Cursor.Current = Cursors.Default;
            }

            
        }

        private bool ItemValidating()
        {
            try
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
            catch (Exception ex)
            {
                return false;
                //MessageBox.Show(ex.Message);
            }
        }

        private bool LocationValidating()
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


                //txtLocation.Text.Trim(), txtBinCode.Text.Trim()


                if (binqh.Length != 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception ex)
            {
                //MessageBox.Show(ex.Message);
                return false;
            }
        }

        private bool IsItNumber(string inputvalue)
        {
            Regex isnumber = new Regex("[^0-9]");
            return !isnumber.IsMatch(inputvalue);
        }

        private void CallBindGrid()
        {
            GrdDailyLoss.DataSource = dt;
        }

        private void mnuGRNBack_Click(object sender, EventArgs e)
        {
            this.Close();
            frmMain msc = new frmMain(staffname,staffdim,stafflevel);
            msc.Show();
        }

        private void menuItem1_Click(object sender, EventArgs e)
        {
           
            if (GrdDailyLoss == null)
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

                    QHSalesReceivableSetup.QHSalesReceivableSetup_Service qhsalesev = new QHMobile.QHSalesReceivableSetup.QHSalesReceivableSetup_Service();
                    qhsalesev.Credentials = nc;
                    qhsalesev.Url = WebServiceInstants.GetURL(ServiceType.QHSalesReceivableSetup);

                    QHSalesReceivableSetup.QHSalesReceivableSetup[] qhsaleGet = qhsalesev.ReadMultiple(null, null, 0);


                    for (int i = 0; i < dl_array.Count; i++)
                    {
                        ItemJournalDailyLossQH.ItemJournalDailyLossQH dl = new QHMobile.ItemJournalDailyLossQH.ItemJournalDailyLossQH();

                        dlservice.Create(qhsaleGet[0].Change_Size_Batch, ref dl); // Actual value should be DOA

                        dl.Posting_Date = DateTime.Now;

                        if (dl_array[i].entrytype.Equals("Positive Adjmt."))
                        {
                            dl.Entry_Type = ItemJournalDailyLossQH.Entry_Type.Positive_Adjmt;
                        }
                        else if (dl_array[i].entrytype.Equals("Negative Adjmt."))
                        {
                            dl.Entry_Type = ItemJournalDailyLossQH.Entry_Type.Negative_Adjmt;
                        }

                        dl.Entry_TypeSpecified = true;

                        dl.Item_No = dl_array[i].itemno;
                        dl.Quantity = Convert.ToInt32(dl_array[i].quantity);
                        dl.Location_Code = dl_array[i].location;
                        //dl.Posting_Date = dl_array[i].postdate;
                        dl.Staff_Dimension_Code = staffdim;
                        dl.Bin_Code = dl_array[i].bincode;

                        dlservice.Update(qhsaleGet[0].Change_Size_Batch, ref dl);

                    }
                    //// to adjust //// 

                    ArrayList tnk = new ArrayList();
                    for (int i = 0; i < dl_array.Count; i++)
                    {
                        if ((dl_array[i].EmptyTank == true) && (dl_array[i].entrytype.Equals("Negative Adjmt.")))
                        {
                            if (i == 0)
                            {
                                tnk.Add(dl_array[i].bincode);
                            }
                            else
                            {
                                if (!tnk.Contains(dl_array[i].bincode))
                                {
                                    tnk.Add(dl_array[i].bincode);

                                }

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

                        for (int k = 0; k < dl_array.Count; k++)
                        {
                            if ((dl_array[k].EmptyTank == true) && (dl_array[k].entrytype.Equals("Negative Adjmt.")))
                            {
                                if (tnk[j].ToString().Equals(dl_array[k].bincode))
                                {
                                    itemtemp = dl_array[k].itemno;
                                    countotal = countotal + Convert.ToDecimal(dl_array[k].quantity);
                                    locationtemp = dl_array[k].location;
                                    bincodetemp = dl_array[k].bincode;

                                    if (dl_array[k].EmptyTank == true)
                                    {
                                        flagtemp = true;
                                    }
                                }
                            }
                        }

                        //QHBinContent.QHBinContent_Service qhsev = new QHMobile.QHBinContent.QHBinContent_Service();
                        //qhsev.Credentials = nc;
                        //qhsev.Url = WebServiceInstants.GetURL(ServiceType.QHBinContent);

                        //List<QHBinContent.QHBinContent_Filter> filterArr = new List<QHMobile.QHBinContent.QHBinContent_Filter>();

                        //QHBinContent.QHBinContent_Filter binfilter = new QHMobile.QHBinContent.QHBinContent_Filter();
                        //binfilter.Field = QHMobile.QHBinContent.QHBinContent_Fields.Bin_Code;
                        //binfilter.Criteria = bincodetemp;

                        ////QHBinContent.QHBinContent_Filter Qtyfilter = new QHMobile.QHBinContent.QHBinContent_Filter();
                        ////Qtyfilter.Field = QHMobile.QHBinContent.QHBinContent_Fields.Quantity_Base;
                        ////Qtyfilter.Criteria = "<>0";  

                        //QHBinContent.QHBinContent_Filter itemFilter = new QHMobile.QHBinContent.QHBinContent_Filter();
                        //itemFilter.Field = QHMobile.QHBinContent.QHBinContent_Fields.Item_No;
                        //itemFilter.Criteria = itemtemp;

                        //filterArr.Add(binfilter);
                        ////filterArr.Add(Qtyfilter);
                        //filterArr.Add(itemFilter);

                        //QHBinContent.QHBinContent[] qhbincon = qhsev.ReadMultiple(filterArr.ToArray(), null, 5);

                        if (flagtemp == true) //qhbincon[0].Quantity_Base < countotal || 
                        {
                            //  qhfun.TankAdj_NAV(itemtemp, packworksheet, locationtemp, bincodetemp, countotal, flagtemp);
                            //qhfun.TankAdj_NAV(itemtemp, packworksheet, locationtemp, bincodetemp, countotal);

                            QHEmptyTank.QHEmptyTank_Service qhempty = new QHMobile.QHEmptyTank.QHEmptyTank_Service();
                            qhempty.Url = WebServiceInstants.GetURL(ServiceType.QHEmptyTank);
                            qhempty.Credentials = nc;

                            QHEmptyTank.QHEmptyTank qhcheck = qhempty.Read(bincodetemp);
                            if (qhcheck == null)
                            {

                                QHEmptyTank.QHEmptyTank qhtnk = new QHMobile.QHEmptyTank.QHEmptyTank();
                                qhtnk.Bin_Code = bincodetemp;
                                qhempty.Create(ref qhtnk);

                                
                                qhtnk.Batch_Name = qhsaleGet[0].Change_Size_Batch;
                                qhtnk.Item_No = itemtemp;
                                qhtnk.Location_Code = locationtemp;
                                qhempty.Update(ref qhtnk);

                            }
                        }
                        //else if (qhbincon[0].Quantity - qhbincon[0].PDA_Inv_Pick_Quantity < countotal)
                        //{
                        //    QH_Functions.QH_Functions qhfun = new QHMobile.QH_Functions.QH_Functions();
                        //    qhfun.Url = WebServiceInstants.GetURL(ServiceType.QH_Functions);
                        //    qhfun.Credentials = nc;
                        //    decimal updatecount = countotal - (qhbincon[0].Quantity - qhbincon[0].PDA_Inv_Pick_Quantity);
                        //    qhfun.InsertIJLPositiveAdjustment(itemtemp, "", locationtemp, bincodetemp, updatecount);
                        //    //qhfun.TankAdj_NAV(itemtemp, "", locationtemp, bincodetemp, countotal, flagtemp);
                        //}
                    }

                    //// to adjust //// 
                    CompactSQL comsql = new CompactSQL();
                    comsql.deleteRecord("ChangeSize");

                    MessageBox.Show("Submitted.");


                    this.Close();
                    DailyLossTS dilts = new DailyLossTS(staffname, staffdim, stafflevel);
                    dilts.Show();

                    
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error:" + ex);
                }
                Cursor.Current = Cursors.Default;

                //DailyLossTS dts = new DailyLossTS(staffname, staffdim, stafflevel);
            }
        }

        private void menuItem2_Click(object sender, EventArgs e)
        {
            int count = GetNoOfSelectedRows(GrdDailyLoss);

            if (count == 0 || count == null)
            {
                MessageBox.Show("No record to delete!Please select the record first!");
            }
            else
            {
                for (int i = 0; i < count; i++)
                {
                    deleteSelectedRows(GrdDailyLoss);
                }
            }
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
                    ///thurein
                    if ((dt.Rows[i][0].ToString() == GrdDailyLoss[GrdDailyLoss.CurrentCell.RowNumber, 0].ToString()) && (dt.Rows[i][1].ToString() == GrdDailyLoss[GrdDailyLoss.CurrentCell.RowNumber, 1].ToString()) && (dt.Rows[i][2].ToString() == GrdDailyLoss[GrdDailyLoss.CurrentCell.RowNumber, 2].ToString()) && !isFound)
                    {
                        //subtract from summary table
                        //CalculateSummaryTable(dg_stock[dg_stock.CurrentCell.RowNumber, 0].ToString(), dg_stock[dg_stock.CurrentCell.RowNumber, 1].ToString(), "-" + dg_stock[dg_stock.CurrentCell.RowNumber, 2].ToString(), dg_stock[dg_stock.CurrentCell.RowNumber, 3].ToString());
                        // DeleteToSummaryTable(GrdAddline[GrdAddline.CurrentCell.RowNumber, 0].ToString(), GrdAddline[GrdAddline.CurrentCell.RowNumber, 1].ToString(), "-" + GrdAddline[GrdAddline.CurrentCell.RowNumber, 2].ToString(), GrdAddline[GrdAddline.CurrentCell.RowNumber, 3].ToString());
                        //addToSummaryTable(dg_stock[dg_stock.CurrentCell.RowNumber, 0].ToString(), dg_stock[dg_stock.CurrentCell.RowNumber, 1].ToString(), "-" + dg_stock[dg_stock.CurrentCell.RowNumber, 2].ToString());

                        CompactSQL comsql = new CompactSQL();
                        comsql.deleteRecordLine("ChangeSize", Convert.ToInt32(GrdDailyLoss[GrdDailyLoss.CurrentCell.RowNumber, 8].ToString().Trim()));

                        dt.Rows.RemoveAt(i);
                        dl_array.RemoveAt(i);
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

                }
            }
            return count;
        }

        private void MnuNewGRN_Click(object sender, EventArgs e)
        {
            //if (GrdDailyLoss == null)
            //{
            //    MessageBox.Show("There is no record to post!");
            //}
            //else
            //{

                Cursor.Current = Cursors.WaitCursor;
                try
                {

                    QH_Functions.QH_Functions qhfun = new QHMobile.QH_Functions.QH_Functions();
                    qhfun.Url = WebServiceInstants.GetURL(ServiceType.QH_Functions);
                    qhfun.Credentials = nc;
                    qhfun.PostItemJournalLine();

                    MessageBox.Show("Journal Lines are posted.");
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error" + ex);
                }

                Cursor.Current = Cursors.Default;
           // }
        }

        private void menuItem3_Click(object sender, EventArgs e)
        {
            this.Close();
            DailyLossTS dst = new DailyLossTS(staffname, staffdim , stafflevel);
            dst.Show();
        }

        private void txtItemNo_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)

            {
                if (!string.IsNullOrEmpty(txtItemNo.Text.Trim()))
                {
                    ItemQH.ItemQH_Service itemsev = new QHMobile.ItemQH.ItemQH_Service();
                    itemsev.Url = WebServiceInstants.GetURL(ServiceType.ItemQH);
                    itemsev.Credentials = nc;

                    ItemQH.ItemQH itemdescription = itemsev.Read(txtItemNo.Text.Trim());
                    if (itemdescription != null)
                    {
                        txtDescription.Text = itemdescription.Description;
                    }
                }

                txtQuantity.SelectAll();
                txtQuantity.Focus();
            }

        }

        private void txtBinCode_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {

                    Cursor.Current = Cursors.WaitCursor;

                    ItemQH.ItemQH_Service itemSev = new QHMobile.ItemQH.ItemQH_Service();
                    itemSev.Credentials = nc;
                    itemSev.Url = WebServiceInstants.GetURL(ServiceType.ItemQH);

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


                    filterArray.Add(filter);

                    QHBinContent.QHBinContent_Filter filterBaseQty = new QHMobile.QHBinContent.QHBinContent_Filter();
                    filterBaseQty.Field = QHMobile.QHBinContent.QHBinContent_Fields.Quantity;
                    filterBaseQty.Criteria = ">0";
                    filterArray.Add(filterBaseQty);

                    QHBinContent.QHBinContent_Filter filterPCS = new QHMobile.QHBinContent.QHBinContent_Filter();
                    filterPCS.Field = QHMobile.QHBinContent.QHBinContent_Fields.Unit_of_Measure_Code;
                    filterPCS.Criteria = "<>''";
                    filterArray.Add(filterPCS);
                    
                    
                    //QHBinContent.QHBinContent_Filter filter2 = new QHMobile.QHBinContent.QHBinContent_Filter();
                    //filter2.Field = QHMobile.QHBinContent.QHBinContent_Fields.Quantity;
                    //filter2.Criteria = ">0";
                    //filterArray.Add(filter2);


                    QHBinContent.QHBinContent[] qhbin = qhbinServ.ReadMultiple(filterArray.ToArray(), null, 0);

                    //MessageBox.Show(qhbin.Length.ToString());
                    //ItemQH.ItemQH findItem = itemSev.Read(qhbin[0].Item_No.ToString());

                    BinQH.BinQH_Service binsev = new QHMobile.BinQH.BinQH_Service();
                    binsev.Credentials = nc;
                    binsev.Url = WebServiceInstants.GetURL(ServiceType.BinQH);


                    if (qhbin.Length != 0)
                    {
                        BinQH.BinQH binbl = binsev.Read(qhbin[0].Location_Code, txtBinCode.Text.Trim());

                        if (binbl.Block_Movement == QHMobile.BinQH.Block_Movement.All)
                        {
                            MessageBox.Show("This bin is blocked.Hence please try again!");
                            txtBinCode.SelectAll();
                            txtBinCode.Focus();
                        }
                        else
                        {
                            ItemQH.ItemQH findItem = itemSev.Read(qhbin[0].Item_No.ToString());
                            
                            txtLocation.Text = qhbin[0].Location_Code;
                            //txtBinCode.Text = qhbin[0].Bin_Code;
                            txtItemNo.Text = qhbin[0].Item_No;
                            txtQuantity.Text = "0"; //qhbin[0].Quantity_Base.ToString();
                            cboEntryType.Text = cboEntryType.Items[1].ToString();
                            txtPostingDate.Text = DateTime.Today.ToShortDateString();
                            txtDescription.Text = findItem.Description;
                            chkEmpty.Enabled = true;
                        }
                    }
                    else
                    {
                        BinQH.BinQH_Service binservice = new QHMobile.BinQH.BinQH_Service();
                        binservice.Url = WebServiceInstants.GetURL(ServiceType.BinQH);
                        binservice.Credentials = nc;

                        List<BinQH.BinQH_Filter> filterArr = new List<QHMobile.BinQH.BinQH_Filter>();

                        BinQH.BinQH_Filter bincodefilter = new QHMobile.BinQH.BinQH_Filter();
                        bincodefilter.Field = QHMobile.BinQH.BinQH_Fields.Code;

                        if (string.IsNullOrEmpty(txtBinCode.Text.Trim()))
                        {
                            bincodefilter.Criteria = "''";
                        }
                        else
                        {
                            bincodefilter.Criteria = txtBinCode.Text.Trim();
                        }

                        filterArr.Add(bincodefilter);


                        BinQH.BinQH[] binqhget = binservice.ReadMultiple(filterArr.ToArray(), null, 3);

                        if (binqhget.Length != 0)
                        {
                            if (binqhget[0].Block_Movement == QHMobile.BinQH.Block_Movement.All)
                            {
                                MessageBox.Show("The bin is blocked!");
                            }
                            else
                            {

                                txtLocation.Text = binqhget[0].Location_Code;
                                //txtBinCode.Text = qhbin[0].Bin_Code;
                                txtItemNo.Text = "";
                                txtQuantity.Text = "0"; //qhbin[0].Quantity_Base.ToString();
                                cboEntryType.Text = cboEntryType.Items[1].ToString();
                                txtPostingDate.Text = DateTime.Today.ToShortDateString();
                                txtDescription.Text = "";
                                chkEmpty.Enabled = true;
                                txtItemNo.Focus();
                            }

                        }
                        else
                        {
                            MessageBox.Show("Invalid Bin!");
                            txtBinCode.SelectAll();
                            txtBinCode.Focus();
                        }
                        
                    }


                    Cursor.Current = Cursors.Default;

                    txtQuantity.SelectAll();
                    txtQuantity.Focus();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                Cursor.Current = Cursors.Default;
            }
        }

       private void pictureBox1_Click(object sender, EventArgs e)
        {
        // dl_array // Current Status 

            Cursor.Current = Cursors.WaitCursor;

            DailyLossFormTS dts = new DailyLossFormTS();
            dts.itemno = txtItemNo.Text; 
            dts.bincode = txtBinCode.Text;
            dts.location = txtLocation.Text;
            dts.postdate = txtPostingDate.Text;
            dts.quantity = txtQuantity.Text;
            dts.entrytype = cboEntryType.SelectedItem.ToString();

            ItemLists itemlst = new ItemLists(staffname, staffdim, stafflevel, dl_array,dts);
            itemlst.Show();
        }

        private void txtItemNo_TextChanged(object sender, EventArgs e)
        {
        
        }

       

    }
}