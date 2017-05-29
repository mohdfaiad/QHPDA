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
    public partial class StockTake : Form
    {
        protected System.Net.NetworkCredential nc = new System.Net.NetworkCredential(WebServiceInstants.GetURL(ServiceType.userName).ToString(), WebServiceInstants.GetURL(ServiceType.password).ToString(), WebServiceInstants.GetURL(ServiceType.domain).ToString());
        static List<QHMobile.App_Data.STModule> stmod;
        DataTable dt;
        static int linecount;
        QHBinContent.QHBinContent_Service globalsvr = new QHMobile.QHBinContent.QHBinContent_Service();

        string location_code;
        string staffdim,uname,ulevel;
        String menuValue = "0";

        SqlCeDataReader getdata;
        public StockTake(string username, string staffdim, string userlevel)
        {
                InitializeComponent();
                stmod = new List<QHMobile.App_Data.STModule>();
                stmod.Clear();
                dt = new DataTable("ST_Table");
                dt.Clear();
                dt.Rows.Clear();
               
                dgGRNLine.DataSource = null;
                dgGRNLine.Refresh();

                dt.Columns.Add(new DataColumn("ItemNo"));
                dt.Columns.Add(new DataColumn("BinNo"));
                dt.Columns.Add(new DataColumn("Qty"));
                dt.Columns.Add(new DataColumn("Posting_Date")); // Stock take date
                dt.Columns.Add(new DataColumn("Staff_Name"));
                //dt.Columns.Add(new DataColumn("Entry_Date"));
                dt.Columns.Add(new DataColumn("Category"));
                dt.Columns.Add(new DataColumn("Lineno"));
                //txtBin.Focus();
                this.staffdim = staffdim;
                this.uname = username;
                this.ulevel = userlevel;

                CompactSQL comsql = new CompactSQL();
                getdata = comsql.SelectRecord("StockTakeEntry");
                GetSQLData(getdata);
           
        }

        private void GetSQLData(SqlCeDataReader getdata)
        {
            dt.Clear();
            stmod.Clear();
            while (getdata.Read())
            {
                Object[] array = new Object[7];
                QHMobile.App_Data.STModule mod = new QHMobile.App_Data.STModule();

                array[0] = getdata["ItemNo"];
                mod.ItemNo = getdata["ItemNo"].ToString(); ;
                array[1] = getdata["BinCode"];
                mod.binNo = getdata["BinCode"].ToString();
                array[2] = getdata["Quantity"];
                mod.qty = Convert.ToInt32(getdata["Quantity"]);
                array[3] = getdata["PostDate"];
                mod.postDate = Convert.ToDateTime(getdata["PostDate"]);
                array[4] = getdata["StaffName"];
                mod.staffName = getdata["StaffName"].ToString();
                //array[5] = getdata["EntryDate"];
                //if (!string.IsNullOrEmpty(getdata["EntryDate"].ToString()))
                //{
                //    mod.entryDate = DateTime.Now;
                //}
                //else
                //{
                //    mod.entryDate = Convert.ToDateTime(getdata["EntryDate"]);
                //}
                array[5] = getdata["Category"];
                mod.category = getdata["Category"].ToString();

                array[6] = getdata["LineNo"];
                dt.Rows.Add(array);
                stmod.Add(mod);
            }

            dgGRNLine.DataSource = dt;
        }
            
        private void btnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                if (!string.IsNullOrEmpty(txtBin.Text) && !string.IsNullOrEmpty(txtItemNo.Text) && !string.IsNullOrEmpty(txtQty.Text))
                {

                    txtBin.Enabled = true;
                    txtQty.Enabled = false;
                    txtItemNo.Enabled = false;
                    textBox1.Enabled = false;

                    string itemNo;
                    string binNo;
                    int quantity;
                    DateTime postdate;
                    string staffname;
                    DateTime entrydate;
                    string categ;

                    itemNo = txtItemNo.Text;
                    binNo = txtBin.Text;
                    postdate = Convert.ToDateTime(textBox1.Text);
                    staffname = staffdim;
                    entrydate = Convert.ToDateTime(textBox1.Text);
                    categ = txtCategory.Text.Trim();

                    bool isNum = IsItNumber(txtQty.Text.Trim());

                    if (txtQty.Text.Equals("") || txtBin.Text.Equals(""))
                    {
                        MessageBox.Show("All field are required to enter");
                    }
                    else
                    {
                        if (isNum)
                        {
                            quantity = Convert.ToInt32(txtQty.Text);
                            AddtoRow(itemNo, binNo, quantity, postdate, staffname, entrydate, categ);
                            //dgGRNLine.DataSource = dt;
                            CompactSQL comsql = new CompactSQL();
                            getdata = comsql.SelectRecord("StockTakeEntry");
                            GetSQLData(getdata);



                            txtBin.Focus();
                            txtItemNo.Text = "";
                            textBox1.Text = "";
                            txtQty.Text = "";
                            txtBin.Text = "";
                            txtCategory.Text = "";
                            txtDescription.Text = "";
                            txtDescription2.Text = "";
                        }
                        else
                        {
                            MessageBox.Show("Invalid Qty Number!");
                            txtQty.Text = "";
                            txtQty.Focus();
                            dgGRNLine.DataSource = dt;
                        }
                    }
                }
            }catch (Exception ex)
            {
                MessageBox.Show("Error" + ex);
            }
        }

        private void AddtoRow(string ino, string bno,int qt, DateTime post,string sname,DateTime entry, string categ)
        {
            object[] array = new object[6];
            QHMobile.App_Data.STModule module = new QHMobile.App_Data.STModule();
            array[0]= module.ItemNo = ino;
            array[1]=module.binNo = bno;
            array[2]=module.qty = qt;
            array[3] = module.postDate = post;
            array[4] = module.staffName = sname;
            //array[5] = module.entryDate = entry;
            module.entryDate = entry;
            array[5] = module.category = categ;

            dt.Rows.Add(array);
            lblCount.Text = dt.Rows.Count.ToString();
            stmod.Add(module);

            txtItemNo.Enabled = true; 
            txtBin.Enabled = true;

            CompactSQL comsql = new CompactSQL();
            comsql.InsertRecord("StockTakeEntry", array);

        }

        private void MnuNewGRN_Click(object sender, EventArgs e)
        {
            try
            {

                if (dgGRNLine.DataSource == null)
                {
                    MessageBox.Show("Please scan the item first!");
                }
                else
                {
                    Cursor.Current = Cursors.WaitCursor;

                    try
                    {
                        qhStockTakeWS.StockTakeWS_Service qhserv = new QHMobile.qhStockTakeWS.StockTakeWS_Service();
                        qhserv.Url = WebServiceInstants.GetURL(ServiceType.StockTakeWS);
                        qhserv.Credentials = nc;

                        CurrencyManager cm = (CurrencyManager)this.BindingContext[dgGRNLine.DataSource];
                        DataView dv = (DataView)cm.List;
                        //qhStockTakeWS.StockTakeWS[] stock_list = new qhStockTakeWS.StockTakeWS[stmod.Count];
                        qhStockTakeWS.StockTakeWS[] stock_list = new qhStockTakeWS.StockTakeWS[dv.Count];

                        //qhStockTakeWS.StockTakeWS[] stock_all = qhserv.ReadMultiple(null, null, 0);
                        //linecount = stock_all.Count();


                        QH_Functions.QH_Functions qhfun = new QHMobile.QH_Functions.QH_Functions();
                        qhfun.Url = WebServiceInstants.GetURL(ServiceType.QH_Functions);
                        qhfun.Credentials = nc;
                        
                   
                            for (int i = 0; i < dv.Count; i++)
                            {
                                qhStockTakeWS.StockTakeWS updatestock = new QHMobile.qhStockTakeWS.StockTakeWS();

                                updatestock.Stock_take_Code = "1";
                                updatestock.Item_No = stmod[i].ItemNo;
                                //updatestock.Item_No = dgGRNLine[i, 0].ToString();
                              
                                
                                //  updatestock.Line_NoSpecified = true;

                                //linecount = qhfun.GetStockTakeLastLineNo();
                                // linecount = ++linecount;
                                //updatestock.Line_No = linecount;


                                updatestock.BinCode = stmod[i].binNo;
                                //updatestock.BinCode = dgGRNLine[i, 1].ToString();

                                updatestock.Stock_take_QuantitySpecified = true;
                                updatestock.Stock_take_Quantity = stmod[i].qty;
                                //updatestock.Stock_take_Quantity = Convert.ToInt32(dgGRNLine[i, 2].ToString());
                                updatestock.Stock_take_DateSpecified = true;
                                updatestock.Stock_take_Date = stmod[i].postDate;
                                //updatestock.Stock_take_Date = Convert.ToDateTime(dgGRNLine[i, 3].ToString()); 
                                updatestock.Staff_Dimension_Code = staffdim;
                                //updatestock.Staff_Dimension_Code = dgGRNLine[i, 4].ToString();
                                updatestock.Entry_DateSpecified = true;
                                updatestock.Entry_Date = stmod[i].entryDate;
                                //updatestock.Entry_Date = Convert.ToDateTime(dgGRNLine[i, 5].ToString());
                                updatestock.Registered_DateSpecified = true;
                                updatestock.Registered_Date = stmod[i].entryDate;
                                //updatestock.Registered_Date = Convert.ToDateTime(dgGRNLine[i, 5].ToString());
                                
                                
                                updatestock.Message = "Items not in Phys. Invty Jnl";
                                if (string.IsNullOrEmpty(txtLocation.Text.ToString()))
                                {
                                    updatestock.Location_Code = "QH1";
                                }
                                else
                                {
                                    updatestock.Location_Code = txtLocation.Text.ToString();
                                }

                                updatestock.Category = stmod[i].category;
                                //updatestock.Category = dgGRNLine[i, 6].ToString();

                                updatestock.Skip_Auto_NumberSpecified = false;
                                updatestock.Skip_Auto_Number = false;
                                qhserv.Create(ref updatestock);
                                //stock_list[i] = updatestock;


                            }

                            //qhserv.CreateMultiple(ref stock_list);

                            CompactSQL comsql = new CompactSQL();
                            comsql.deleteRecord("StockTakeEntry");

                            Cursor.Current = Cursors.Default;

                            MessageBox.Show("Submitted!");
                            this.Close();
                            StockTake st = new StockTake(uname, staffdim, ulevel);
                            st.Show();


                    }
                    catch (Exception ex)
                    {
                        Cursor.Current = Cursors.Default;
                        MessageBox.Show("Error" + ex);
                    }
                }
            }catch (Exception ex)
            {
                MessageBox.Show("Error" + ex);
            }
        }

      
        public static bool IsItNumber(string inputvalue)
        {
            Regex isnumber = new Regex("[^0-9]");
            return !isnumber.IsMatch(inputvalue);
        }

        private void menuItem1_Click(object sender, EventArgs e)
        {
            this.Close();
            StockTake stk = new StockTake(uname,staffdim,ulevel);
            stk.Show();
        }

        private void mnuGRNBack_Click(object sender, EventArgs e)
        {
           
        }

        private void menuItem2_Click(object sender, EventArgs e)
        {
            try
            {
                int count = GetNoOfSelectedRows(dgGRNLine);

                if (count == 0)
                {
                    MessageBox.Show("Please select the record!");
                }
                else
                {
                    for (int i = 0; i < count; i++)
                    {
                        deleteSelectedRows(dgGRNLine);
                    }
                }
                lblCount.Text = dt.Rows.Count.ToString();

            }catch (Exception ex)
            {
                MessageBox.Show("There is no record selected to delete!" + ex);
            }
        }

        private ArrayList deleteSelectedRows(DataGrid dgGRNLine)
        {
            ArrayList al = new ArrayList();

            CurrencyManager cm = (CurrencyManager)this.BindingContext[dgGRNLine.DataSource];

            DataView dv = (DataView)cm.List;

            bool isFound = false;

            for (int i = 0; i < dv.Count && !isFound; ++i)
            {

                if (dgGRNLine.IsSelected(i))
                {
                    dgGRNLine.CurrentRowIndex = i;
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
                    if ((dt.Rows[i][0].ToString() == dgGRNLine[dgGRNLine.CurrentCell.RowNumber, 0].ToString()) && (dt.Rows[i][1].ToString() == dgGRNLine[dgGRNLine.CurrentCell.RowNumber, 1].ToString()) && (dt.Rows[i][2].ToString() == dgGRNLine[dgGRNLine.CurrentCell.RowNumber, 2].ToString()) && !isFound)
                    {
                        CompactSQL comsql = new CompactSQL();
                        comsql.deleteRecordLine("StockTakeEntry", Convert.ToInt32(dgGRNLine[dgGRNLine.CurrentCell.RowNumber, 6].ToString().Trim()));

                        dt.Rows.RemoveAt(i);
                        stmod.RemoveAt(i);
                        isFound = true;
                    }
                }

            }
        }

        private int GetNoOfSelectedRows(DataGrid dgGRNLine)
        {
            int count = 0;

            CurrencyManager cm = (CurrencyManager)this.BindingContext[dgGRNLine.DataSource];

            DataView dv = (DataView)cm.List;

            for (int i = 0; i < dv.Count; ++i)
            {

                if (dgGRNLine.IsSelected(i))
                {

                    count++;

                }
            }
            return count;
        }

        private void txtQty_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtBin_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {

                if (e.KeyCode == Keys.Enter)
                {

                    try
                    {
                        globalsvr.Url = WebServiceInstants.GetURL(ServiceType.QHBinContent);
                        globalsvr.Credentials = nc;
                        Cursor.Current = Cursors.WaitCursor;

                        List<QHBinContent.QHBinContent_Filter> filterarray = new List<QHMobile.QHBinContent.QHBinContent_Filter>();

                        QHBinContent.QHBinContent_Filter filterBin = new QHMobile.QHBinContent.QHBinContent_Filter();
                        filterBin.Field = QHMobile.QHBinContent.QHBinContent_Fields.Bin_Code;
                        filterBin.Criteria = txtBin.Text.Trim();

                        filterarray.Add(filterBin);

                        BinQH.BinQH_Service binsev = new QHMobile.BinQH.BinQH_Service();
                        binsev.Url = WebServiceInstants.GetURL(ServiceType.BinQH);
                        binsev.Credentials = nc;

                        List<BinQH.BinQH_Filter> binfitlerArray = new List<QHMobile.BinQH.BinQH_Filter>();

                        BinQH.BinQH_Filter bincodefilter = new QHMobile.BinQH.BinQH_Filter();
                        bincodefilter.Field = QHMobile.BinQH.BinQH_Fields.Code;
                        bincodefilter.Criteria = txtBin.Text.Trim();

                        binfitlerArray.Add(bincodefilter);

                        BinQH.BinQH[] binget = binsev.ReadMultiple(binfitlerArray.ToArray(), null, 0);


                        QHBinContent.QHBinContent[] bintemp = globalsvr.ReadMultiple(filterarray.ToArray(), null, 0);


                        if (bintemp.Length == 0 && binget.Length == 0)
                        {
                            Cursor.Current = Cursors.Default;
                            MessageBox.Show("Not found!");
                            txtBin.SelectAll();
                            txtBin.Focus();

                        }
                        else
                        {
                            if (binget[0].Block_Movement == QHMobile.BinQH.Block_Movement.All)
                            {
                                MessageBox.Show("You are not allowed to scan blocked bin! Please try again!");
                                txtBin.Text = "";
                                txtBin.Focus();
                            }
                            else
                            {

                                    if (bintemp.Length == 0)
                                    {
                                        Cursor.Current = Cursors.Default;

                                        if (menuValue.Equals("1") || menuValue.Equals("0") || menuValue == null)
                                        {
                                            txtQty.Text = "0";//bintemp[0].Quantity_Base.ToString();

                                            txtQty.Enabled = true;
                                            textBox1.Enabled = true;
                                            txtBin.Enabled = false;

                                            lblStaffInfo.Text = "Staff Name: " + staffdim;
                                            textBox1.Text = DateTime.Today.ToShortDateString();

                                            txtQty.SelectAll();
                                            txtItemNo.Focus();
                                        }
                                        else if (menuValue.Equals("2"))
                                        {

                                            txtCategory.Enabled = true;

                                            txtItemNo.Enabled = true;
                                            txtItemNo.Focus();

                                            txtQty.Enabled = true;
                                            textBox1.Enabled = true;
                                            txtBin.Enabled = false;


                                            lblStaffInfo.Text = "Staff Name: " + staffdim;
                                            textBox1.Text = DateTime.Today.ToShortDateString();

                                        }

                                    }
                                    else
                                    {
                                        Cursor.Current = Cursors.Default;

                                        ItemQH.ItemQH item;

                                        ItemQH.ItemQH_Service itemSev = new QHMobile.ItemQH.ItemQH_Service();
                                        itemSev.Url = WebServiceInstants.GetURL(ServiceType.ItemQH);
                                        itemSev.Credentials = nc;

                                        item = itemSev.Read(bintemp[0].Item_No);


                                        if (menuValue.Equals("1") || menuValue.Equals("0") || menuValue == null)
                                        {
                                            txtQty.Text = "0";//bintemp[0].Quantity_Base.ToString();

                                            txtCategory.Text = item.Item_Category_Code;

                                            txtQty.Enabled = true;
                                            textBox1.Enabled = true;
                                            txtBin.Enabled = false;
                                            txtItemNo.Text = item.No;

                                            lblStaffInfo.Text = "Staff Name: " + staffdim;
                                            textBox1.Text = DateTime.Today.ToShortDateString();
                                            txtDescription.Text = item.Description;
                                            txtDescription2.Text = item.Description_2;

                                            txtQty.SelectAll();
                                            txtQty.Focus();
                                        }
                                        else if (menuValue.Equals("2"))
                                        {

                                            txtCategory.Enabled = true;
                                            //txtItemNo.Text = item.No;
                                            txtItemNo.Enabled = true;
                                            txtItemNo.Focus();

                                            txtQty.Enabled = true;
                                            textBox1.Enabled = true;
                                            txtBin.Enabled = false;


                                            lblStaffInfo.Text = "Staff Name: " + staffdim;
                                            textBox1.Text = DateTime.Today.ToShortDateString();

                                        }

                                    }
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message.ToString());
                    }

                }
            }catch (Exception ex)
            {
                MessageBox.Show("Error" + ex);
            }

            Cursor.Current = Cursors.Default;

        }



        private void btnAdd_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    txtBin.Enabled = true;
                    txtQty.Enabled = false;
                    txtItemNo.Enabled = false;
                    textBox1.Enabled = false;

                    string itemNo;
                    string binNo;
                    int quantity;
                    DateTime postdate;
                    string staffname;
                    DateTime entrydate;
                    string categ;
                    itemNo = txtItemNo.Text;
                    binNo = txtBin.Text;
                    postdate = DateTime.Today;
                    staffname = staffdim;
                    entrydate = DateTime.Today;
                    categ = txtCategory.Text.Trim();


                    bool isNum = IsItNumber(txtQty.Text.Trim());

                    if (txtQty.Text.Equals("") || txtBin.Text.Equals(""))
                    {
                        MessageBox.Show("All field are required to enter");
                    }
                    else
                    {
                        if (isNum)
                        {
                            quantity = Convert.ToInt32(txtQty.Text);
                            AddtoRow(itemNo, binNo, quantity, postdate, staffname, entrydate, categ);

                            dgGRNLine.DataSource = dt;

                            txtItemNo.Enabled = true;
                            txtItemNo.Focus();
                            txtItemNo.Text = "";
                            textBox1.Text = "";
                            txtQty.Text = "";
                            txtBin.Text = "";

                        }
                        else
                        {
                            MessageBox.Show("Invalid Qty Number!");
                            txtQty.Text = "";
                            txtQty.Focus();
                            dgGRNLine.DataSource = dt;
                        }
                    }

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
        }

        private void menuItem3_Click(object sender, EventArgs e)
        {
            try
            {
                dt.Clear();
                
                Cursor.Current = Cursors.WaitCursor;
                StockTake stk = new StockTake(uname, staffdim, ulevel);
                stk.Show();
                dgGRNLine.DataSource = null;
                menuValue = "2";
                txtBin.Enabled = true;
                txtBin.Focus();
                MessageBox.Show("You have choosen Opening Balance Option.");
                Cursor.Current = Cursors.Default;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error" + ex);
            }
        }

        private void menuItem4_Click(object sender, EventArgs e)
        {
            try
            {
                dt.Clear();
               
                Cursor.Current = Cursors.WaitCursor;
                StockTake stk = new StockTake(uname, staffdim, ulevel);
                stk.Show();
                dgGRNLine.DataSource = null;
                menuValue = "1";
                txtBin.Enabled = true;
                txtBin.Focus();
                MessageBox.Show("You have choosen Stock Take Option.");
                Cursor.Current = Cursors.Default;
            }catch (Exception ex)
            {
                MessageBox.Show("Error" + ex);
            }
        }

        private void txtItemNo_LostFocus(object sender, EventArgs e)
        {
            if (menuValue.Equals("1"))
            {
                textBox1.Focus();
            }
            else
            {
                txtQty.SelectAll();
                txtQty.Focus();
            }
        }

        private void menuItem5_Click(object sender, EventArgs e)
        {
            this.Close();
            frmMain msc = new frmMain(uname, staffdim, ulevel);
            msc.Show();
        }

        private void txtItemNo_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                Cursor.Current = Cursors.WaitCursor;

                if (e.KeyCode == Keys.Enter)
                {
                    ItemQH.ItemQH_Service itemSev = new QHMobile.ItemQH.ItemQH_Service();
                    itemSev.Url = WebServiceInstants.GetURL(ServiceType.ItemQH);
                    itemSev.Credentials = nc;
                    ItemQH.ItemQH item = itemSev.Read(txtItemNo.Text.Trim());

                    if (item == null)
                    {
                        MessageBox.Show("Invalid Item!");
                        txtItemNo.Text = "";
                        txtItemNo.Focus();
                    }
                    else
                    {
                        txtCategory.Text = item.Item_Category_Code;
                        txtDescription.Text = item.Description;
                        txtDescription2.Text = item.Description_2;
                        txtQty.Focus();

                    }

                }

                Cursor.Current = Cursors.Default;
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }//end

    }
}