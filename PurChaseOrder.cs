using System;
using System.Linq;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Collections;
using System.Data.SqlServerCe;

namespace QHMobile
{
    public partial class PurChaseOrder : Form
    {
        string vNumber, vName;
        string vuser, vstaffdimension,vstafflevel; 

        protected System.Net.NetworkCredential nc = new System.Net.NetworkCredential(WebServiceInstants.GetURL(ServiceType.userName).ToString(), WebServiceInstants.GetURL(ServiceType.password).ToString(), WebServiceInstants.GetURL(ServiceType.domain).ToString());

        DataTable dt = new DataTable("Purchase Order");
        SqlCeDataReader getdata;

        ItemQH.ItemQH_Service itemSev = new QHMobile.ItemQH.ItemQH_Service();
        List<PurchaseOrderModule> PoArray = new List<PurchaseOrderModule>();

        int updatnumber=0;

        Boolean NullValue = false;

        string PO;

        public PurChaseOrder(string vname, string vno, string usng, string staffdimg, string uslvelg)
        {
            InitializeComponent();
            PoArray.Clear();
            dt.Clear();

            vNumber = vno;
            vName = vname;
            vuser = usng;
            vstaffdimension = staffdimg;
            vstafflevel = uslvelg;

            txtVendorNo.Text = vNumber;
            txtVendorName.Text = vName;
            txtRegDate.Text = DateTime.Now.ToString("dd/MM/yyyy");
            txtLocation.Text = "QH1";

            dt.Columns.Add("Item No");
            dt.Columns.Add("Item Description");
            dt.Columns.Add("Location");
            dt.Columns.Add("Quantity");
            dt.Columns.Add("LineNo");

            txtItemNo.Focus();

            //load from SQL
            //
            CompactSQL comsql = new CompactSQL();
            getdata = comsql.SelectRecord("PurchaseOrder");
            GetSQLData(getdata,false);
        }
        public PurChaseOrder(string usng, string staffdimg, string uslvelg)
        {
            InitializeComponent();
            PoArray.Clear();
            dt.Clear();

            txtRegDate.Text = DateTime.Now.ToString("dd/MM/yyyy");
            vuser = usng;
            vstaffdimension = staffdimg;
            vstafflevel = uslvelg;


            dt.Columns.Add("Item No");
            dt.Columns.Add("Item Description");
            dt.Columns.Add("Location");
            dt.Columns.Add("Quantity");
            dt.Columns.Add("LineNo");

            CompactSQL comsql = new CompactSQL();
            getdata = comsql.SelectRecord("PurchaseOrder");
            GetSQLData(getdata,true);
            


        }

        private void GetSQLData(SqlCeDataReader getdata,bool bShow)
        {
            //tableJournal.Clear();
            //journalarray.Clear();
            //while (getdata.Read())
            //{
                
            //}
            //BindTOGrid();

            try
            {
                PoArray.Clear();
                dt.Clear();
                while (getdata.Read())
                {
                    Object[] array = new Object[5];
                    PurchaseOrderModule pomodule = new PurchaseOrderModule();
                    array[0] = getdata["ItemNo"].ToString();
                    pomodule.itemno = getdata["ItemNo"].ToString();
                    if (!String.IsNullOrEmpty(getdata["ItemNo"].ToString()))
                    {
                        ItemQH.ItemQH_Service itemsev = new QHMobile.ItemQH.ItemQH_Service();
                        itemsev.Url = WebServiceInstants.GetURL(ServiceType.ItemQH);
                        itemsev.Credentials = nc;

                        ItemQH.ItemQH itemdescription = itemsev.Read(getdata["ItemNo"].ToString());
                        string strItemDescription;
                        strItemDescription = itemdescription.Description;
                        pomodule.itemDescription = strItemDescription;
                        array[1] = strItemDescription;

                    }
                    else
                    {
                        pomodule.itemDescription = "";
                        array[1] = "";
                    }


                    array[2] = getdata["Loc"].ToString();
                    pomodule.location = getdata["Loc"].ToString();
                    array[3] = Convert.ToInt32(getdata["Quantity"]);
                    pomodule.quantity = getdata["Quantity"].ToString();
                    array[4] = Convert.ToInt32(getdata["LineNo"]);
                    PoArray.Add(pomodule);
                    dt.Rows.Add(array);


                    if (bShow)
                    {
                        txtVendorNo.Text = getdata["VendorNo"].ToString().Trim();
                        txtVendorName.Text = getdata["VendorName"].ToString().Trim();
                    }
                }

                GrdPO.DataSource = dt;

                txtItemNo.Text = "";
                txtItemNo.Focus();
                txtLocation.Enabled = false;
                txtRegDate.Enabled = false;
                txtQty.Enabled = false;

            }
            catch (Exception ex)
            {
                MessageBox.Show("Error:" + ex);
            }

        }


        private void btnAdd_Click(object sender, EventArgs e)
        {

        }

        private void btnVendor_Click(object sender, EventArgs e)
        {
            VendorList vls = new VendorList(txtSearch.Text.Trim(),vuser,vstaffdimension,vstafflevel);
            vls.Show();
        }

        private void txtItemNo_KeyDown_1(object sender, KeyEventArgs e)
        {

            if (e.KeyCode == Keys.Enter || e.KeyCode== Keys.Tab)
            {
                Cursor.Current = Cursors.WaitCursor;

                itemSev.Url = WebServiceInstants.GetURL(ServiceType.ItemQH);
                itemSev.Credentials = nc;

                ItemQH.ItemQH itemqh = itemSev.Read(txtItemNo.Text.Trim());

                if (itemqh == null)
                {
                    MessageBox.Show("Item not found!");
                    txtItemNo.SelectAll();
                    txtItemNo.Focus();
                }
                else
                {
                    txtLocation.Enabled = true;
                    txtQty.Text = "";
                    txtQty.Enabled = true;
                    txtRegDate.Enabled = true; 
                    txtQty.Focus();
                }

                Cursor.Current = Cursors.Default;

            }
        }

        private void btnAdd_Click_1(object sender, EventArgs e)
        {
            try
            {
                Cursor.Current = Cursors.WaitCursor;
                Object[] array = new Object[4];
                PurchaseOrderModule pomodule = new PurchaseOrderModule();

                array[0] = txtItemNo.Text.Trim();
                //SQL to save
                Object[] arraySQL = new Object[7];
                pomodule.itemno = txtItemNo.Text.Trim();
                arraySQL[0] = txtVendorNo.Text.Trim();
                arraySQL[1] = txtVendorName.Text.Trim();
                arraySQL[2] = txtRegDate.Text.Trim();
                arraySQL[3] = txtLocation.Text.Trim();
                arraySQL[4] = txtItemNo.Text.Trim();
                arraySQL[6] = Convert.ToInt32(txtQty.Text.Trim());


                if (!String.IsNullOrEmpty(txtItemNo.Text.Trim()))
                {
                    ItemQH.ItemQH_Service itemsev = new QHMobile.ItemQH.ItemQH_Service();
                    itemsev.Url = WebServiceInstants.GetURL(ServiceType.ItemQH);
                    itemsev.Credentials = nc;

                    ItemQH.ItemQH itemdescription = itemsev.Read(txtItemNo.Text.Trim());
                    string strItemDescription;
                    strItemDescription = itemdescription.Description;
                    pomodule.itemDescription = strItemDescription;
                    array[1] = strItemDescription;
                    arraySQL[5] = strItemDescription;

                }
                else
                {
                    arraySQL[5] = "";
                    pomodule.itemDescription = "";
                    array[1] = "";
                }


                array[2] = txtLocation.Text.Trim();
                pomodule.location = txtLocation.Text.Trim();
                array[3] = txtQty.Text.Trim();
                pomodule.quantity = txtQty.Text.Trim();


                PoArray.Add(pomodule);
                dt.Rows.Add(array);

                CompactSQL comsql = new CompactSQL();
                comsql.InsertRecord("PurchaseOrder", arraySQL);

                /*
                    GrdPO.DataSource = dt;


                    txtItemNo.Text = "";
                    txtItemNo.Focus();
                    txtLocation.Enabled = false;
                    txtRegDate.Enabled = false;
                    txtQty.Enabled = false;
                */

                 //dffd
                
            getdata = comsql.SelectRecord("PurchaseOrder");
            GetSQLData(getdata,false);

            Cursor.Current = Cursors.Default;


            }
            catch (Exception ex)
            {
                MessageBox.Show("Error:" + ex);
                Cursor.Current = Cursors.Default;
            }
            
        }

        private void mnuRegisterToNav_Click(object sender, EventArgs e)
        {
            try
            {
                if(GrdPO.DataSource != null)
                {
                Cursor.Current = Cursors.WaitCursor;

                PurchaseQH.PurchaseQH_Service purSev = new QHMobile.PurchaseQH.PurchaseQH_Service();
                purSev.Credentials = nc;
                purSev.Url = WebServiceInstants.GetURL(ServiceType.PurchaseQH);


                PurchaseQH.PurchaseQH phcreate = new QHMobile.PurchaseQH.PurchaseQH();

                purSev.Create(ref phcreate);

                PO = phcreate.No;


                PurchaseQH.PurchaseQH phupdate = purSev.Read(phcreate.No);

                phupdate.Buy_from_Vendor_No = txtVendorNo.Text.Trim();

                phupdate.Buy_from_Vendor_Name = txtVendorName.Text.Trim();

                phupdate.Order_Date = DateTime.Now;

                purSev.Update(ref phupdate);

                phupdate.PurchLines = new QHMobile.PurchaseQH.Purchase_Order_Line[PoArray.Count];

                for (int i = 0; i < PoArray.Count; i++)
                {
                    phupdate.PurchLines[i] = new QHMobile.PurchaseQH.Purchase_Order_Line();
                }

                purSev.Update(ref phupdate);

                for (int j = 0; j < phupdate.PurchLines.Length; j++)
                {
                    phupdate.PurchLines[j].Type = QHMobile.PurchaseQH.Type.Item;
                    phupdate.PurchLines[j].No = PoArray[j].itemno;
                    phupdate.PurchLines[j].Location_Code = PoArray[j].location;
                    phupdate.PurchLines[j].Quantity = Convert.ToInt32(PoArray[j].quantity);
                    phupdate.PurchLines[j].Bin_Code = "";

                }

                purSev.Update(ref phupdate);

                lblPO.Text = "PO:" + phupdate.No;

                if (!String.IsNullOrEmpty(phupdate.No))
                {
                    QH_Functions.QH_Functions qhfun = new QHMobile.QH_Functions.QH_Functions();
                    qhfun.Credentials = nc;
                    qhfun.Url = WebServiceInstants.GetURL(ServiceType.QH_Functions);
                    //qhfun.ReleasePO(PO);
                    qhfun.ReleasePO(phupdate.No.Trim());
                    MessageBox.Show("Purchase Order is created succesfully!" + phupdate.No);


                    CompactSQL comsql = new CompactSQL();
                    comsql.deleteRecord("PurchaseOrder");
                    PurChaseOrder po = new PurChaseOrder(vuser, vstaffdimension, vstafflevel);
                    po.Show();

                }

                Cursor.Current = Cursors.Default;
                }
                else
                {
                    MessageBox.Show("There is no line to post!");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error:" + ex);
            }
        }
 
        private void menuItem1_Click(object sender, EventArgs e)
        {
            PurChaseOrder po = new PurChaseOrder(vuser, vstaffdimension, vstafflevel);
            po.Show();
        }

        private void tbMain_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (tbMain.SelectedIndex == 1)
                {
                    int count = GetNoOfSelectedRows(GrdPO);

                    if (count == 0 || count == null)
                    {
                        MessageBox.Show("Please select the record first!");
                    }
                    else
                    {
                        for (int i = 0; i < count; i++)
                        {
                            UpdateSelectedRows(GrdPO);
                        }
                    }


                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private ArrayList UpdateSelectedRows(DataGrid GrdPO)
        {
            ArrayList al = new ArrayList();

            CurrencyManager cm = (CurrencyManager)this.BindingContext[GrdPO.DataSource];

            DataView dv = (DataView)cm.List;

            bool isFound = false;

            for (int i = 0; i < dv.Count && !isFound; ++i)
            {

                if (GrdPO.IsSelected(i))
                {
                    txtEditItem.Text = PoArray[i].itemno;
                    txtEditDate.Text = txtRegDate.Text;
                    txtEditLocation.Text = PoArray[i].location;
                    txtEditQuantity.Text = PoArray[i].quantity.ToString();
                    tetEditDescription.Text = PoArray[i].itemDescription.ToString();
                    txtLineno.Text = GrdPO[GrdPO.CurrentCell.RowNumber, 4].ToString();
                }
            }

            return al;
        }

        private int GetNoOfSelectedRows(DataGrid GrdPO)
        {
            int count = 0;

            try
            {
                
                CurrencyManager cm = (CurrencyManager)this.BindingContext[GrdPO.DataSource];

                DataView dv = (DataView)cm.List;

                for (int i = 0; i < dv.Count; ++i)
                {

                    if (GrdPO.IsSelected(i))
                    {

                        count++;
                        updatnumber = i;
                    }
                }
                
            }
            catch (Exception ex)
            {
                MessageBox.Show("No selected record to delete!");
                NullValue = true;
            }

            return count;
        }
        
        private void btnConfirmUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                Cursor.Current = Cursors.WaitCursor;

                PoArray[updatnumber].location = txtEditLocation.Text;
                PoArray[updatnumber].quantity = txtEditQuantity.Text;


                GrdPO.DataSource = null;
                dt.Clear();
                for (int i = 0; i < PoArray.Count; i++)
                {
                    Object[] array = new Object[4];

                    array[0] = PoArray[i].itemno;
                    array[1] = PoArray[i].itemDescription;
                    array[2] = PoArray[i].location;
                    array[3] = PoArray[i].quantity;

                    dt.Rows.Add(array);

                }
                Object[] arraySQLUpdate = new Object[2];
                arraySQLUpdate[0] = txtEditLocation.Text;
                arraySQLUpdate[1] = Convert.ToInt32(txtEditQuantity.Text.Trim());
                CompactSQL comsql = new CompactSQL();
                comsql.updatePOLine(arraySQLUpdate, Convert.ToInt32(txtLineno.Text));

                //CompactSQL comsql = new CompactSQL();
                getdata = comsql.SelectRecord("PurchaseOrder");
                GetSQLData(getdata, false);

                //GrdPO.DataSource = dt;
                Cursor.Current = Cursors.Default;
                MessageBox.Show("Updated Succesfully!");
                
            }
            catch (Exception ex)
            {
                Cursor.Current = Cursors.Default;
                MessageBox.Show(ex.Message);
            }
        }

        private void menuItem2_Click(object sender, EventArgs e)
        {
            int count = GetNoOfSelectedRows(GrdPO);

            if (count == 0 && NullValue != true)
            {
                MessageBox.Show("Please select the record!");
            }
            else
            {
                for (int i = 0; i < count; i++)
                {
                    deleteSelectedRows(GrdPO);
                }
            }
        }

        private ArrayList deleteSelectedRows(DataGrid GrdPO)
        {
            ArrayList al = new ArrayList();

            CurrencyManager cm = (CurrencyManager)this.BindingContext[GrdPO.DataSource];

            DataView dv = (DataView)cm.List;

            bool isFound = false;

            for (int i = 0; i < dv.Count && !isFound; ++i)
            {

                if (GrdPO.IsSelected(i))
                {
                    GrdPO.CurrentRowIndex = i;
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
                    if ((dt.Rows[i][0].ToString() == GrdPO[GrdPO.CurrentCell.RowNumber, 0].ToString()) && (dt.Rows[i][1].ToString() == GrdPO[GrdPO.CurrentCell.RowNumber, 1].ToString()) && (dt.Rows[i][2].ToString() == GrdPO[GrdPO.CurrentCell.RowNumber, 2].ToString()) && !isFound)
                    {
                        //int tt = Convert.ToInt32(GrdPO[GrdPO.CurrentCell.RowNumber, 4].ToString().Trim());
                        CompactSQL comsql = new CompactSQL();
                        comsql.deleteRecordLine("PurchaseOrder", Convert.ToInt32(GrdPO[GrdPO.CurrentCell.RowNumber, 4].ToString().Trim()));
                        dt.Rows.RemoveAt(i);
                        PoArray.RemoveAt(i);
                        isFound = true;
                    }
                }

            }
        }

        private void mnuPostToNav_Click(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;

            QH_Functions.QH_Functions qhfun = new QHMobile.QH_Functions.QH_Functions();
            qhfun.Credentials = nc;
            qhfun.Url = WebServiceInstants.GetURL(ServiceType.QH_Functions);

            qhfun.ReleasePO(PO);

            Cursor.Current = Cursors.Default;

            MessageBox.Show("Released!");
        }

        private void mnuGRNBack_Click(object sender, EventArgs e)
        {
            frmMain msc = new frmMain(vuser, vstaffdimension, vstafflevel);
            msc.Show();
        }

        private void txtSearch_KeyDown(object sender, KeyEventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
            try
            {
                if (e.KeyCode == Keys.Enter || e.KeyCode == Keys.Tab)
                {
                    if (!string.IsNullOrEmpty(txtSearch.Text.ToString()))
                    {
                        VendorListQH.VendorListQH_Service vdrSev = new QHMobile.VendorListQH.VendorListQH_Service();
                        vdrSev.Url = WebServiceInstants.GetURL(ServiceType.VendorListQH);
                        vdrSev.Credentials = nc;
                        VendorListQH.VendorListQH oVendor = new QHMobile.VendorListQH.VendorListQH();

                        oVendor = vdrSev.Read(txtSearch.Text.ToString());
                        if (oVendor != null)
                        {

                            txtVendorNo.Text = oVendor.No.ToString();
                            txtVendorName.Text = oVendor.Name.ToString();
                        }
                        else
                        {
                            txtSearch.Text = "";
                            txtVendorNo.Text = "";
                            txtVendorName.Text = "";

                            txtSearch.Focus();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
            Cursor.Current = Cursors.Default;
        }

  

    }
}