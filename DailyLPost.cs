using System;
using System.Linq;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Collections;
using System.Xml;
using System.IO;
using System.Reflection;

namespace QHMobile
{
    public partial class DailyLPost : Form
    {
        protected System.Net.NetworkCredential nc = new System.Net.NetworkCredential(WebServiceInstants.GetURL(ServiceType.userName).ToString(), WebServiceInstants.GetURL(ServiceType.password).ToString(), WebServiceInstants.GetURL(ServiceType.domain).ToString());

        int updatnumber;

        DataTable dtPost = new DataTable();

        ItemJournalDailyLossQH.ItemJournalDailyLossQH[] itemArray;

        string Rusername, Rstaffdimensio, Ruserlevel;

        string BatchName;

        public DailyLPost(string username, string staffdimen, string userlevel)
        {
            InitializeComponent();
            MnuNewGRN.Enabled = false;
            BatchName = "";
            dtPost.Clear();

            Rusername = username;
            Rstaffdimensio = staffdimen;
            Ruserlevel = userlevel;

            lblStaffCode.Text = Rstaffdimensio;
            lblRole.Text = Ruserlevel;

            dtPost.Columns.Add("Line No");
            dtPost.Columns.Add("Item No");
            dtPost.Columns.Add("Item Description");
            dtPost.Columns.Add("Entry Type");
            dtPost.Columns.Add("Quantity");
            dtPost.Columns.Add("Location");
            dtPost.Columns.Add("Bin Code");
            dtPost.Columns.Add("Staff Dimen");
            dtPost.Columns.Add("Posting Date");


           

        }

        private void btnFind_Click(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;

            dtPost.Clear();
            GrdPost.DataSource = null;

            ItemJournalDailyLossQH.ItemJournalDailyLossQH_Service itemSev = new QHMobile.ItemJournalDailyLossQH.ItemJournalDailyLossQH_Service();
            itemSev.Url = WebServiceInstants.GetURL(ServiceType.ItemJournalDailyLossQH);
            itemSev.Credentials = nc;

            List<ItemJournalDailyLossQH.ItemJournalDailyLossQH_Filter> FilterArray = new List<QHMobile.ItemJournalDailyLossQH.ItemJournalDailyLossQH_Filter>();

            ItemJournalDailyLossQH.ItemJournalDailyLossQH_Filter filterStaff = new QHMobile.ItemJournalDailyLossQH.ItemJournalDailyLossQH_Filter();
            filterStaff.Field = QHMobile.ItemJournalDailyLossQH.ItemJournalDailyLossQH_Fields.Staff_Dimension_Code;
            filterStaff.Criteria = cboDailyLPost.SelectedItem.ToString();

      

            FilterArray.Add(filterStaff);

            itemArray = itemSev.ReadMultiple(BatchName, FilterArray.ToArray(), null, 0);

            //DateTime[] dateToCompare = new DateTime[itemArray.Length];

            //for (int j = 0; j < itemArray.Length; j++)
            //{
            //    dateToCompare[j] = itemArray[j].Posting_Date;


            //}

            //Array.Sort(dateToCompare);


            //for (int k = 0; k < dateToCompare.Length; k++)
            //{

                for (int i = 0; i < itemArray.Length; i++)
                {
                    //DateTime compare1 = dateToCompare[k];
                    //DateTime compare2 = itemArray[i].Posting_Date;

                    //if (dateToCompare[k].Equals(itemArray[i].Posting_Date))
                    //{
                        Object[] array = new Object[9];

                        array[0] = itemArray[i].Line_No;
                        array[1] = itemArray[i].Item_No;
                        array[2] = itemArray[i].Description;
                        array[3] = itemArray[i].Entry_Type;
                        array[4] = itemArray[i].Quantity;
                        array[5] = itemArray[i].Location_Code;
                        array[6] = itemArray[i].Bin_Code;
                        array[7] = itemArray[i].Staff_Dimension_Code;
                        array[8] = itemArray[i].Posting_Date;

                        dtPost.Rows.Add(array);

                   // }
                }
           // }

            GrdPost.DataSource = dtPost;

            lblcountforpost.Text = dtPost.Rows.Count.ToString();

            Cursor.Current = Cursors.Default;

        }

        private void tbMain_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (tbMain.SelectedIndex == 1)
            {
                int count = GetNoOfSelectedRows(GrdPost);

                if (count == 0 || count == null)
                {
                    MessageBox.Show("Please select the record first!");
                }
                else
                {
                    for (int i = 0; i < count; i++)
                    {
                        UpdateSelectedRows(GrdPost);
                    }
                }


            }
        }

        private ArrayList UpdateSelectedRows(DataGrid GrdPost)
        {
            ArrayList al = new ArrayList();

            CurrencyManager cm = (CurrencyManager)this.BindingContext[GrdPost.DataSource];

            DataView dv = (DataView)cm.List;

            bool isFound = false;

            for (int i = 0; i < dv.Count && !isFound; ++i)
            {

                if (GrdPost.IsSelected(i))
                {

                    txtLine.Text = itemArray[i].Line_No.ToString();
                    txtItemNo.Text = itemArray[i].Item_No;
                    txtQty.Text = itemArray[i].Quantity.ToString();
                    txtBin.Text = itemArray[i].Bin_Code;
                    txtStaffCode.Text = itemArray[i].Staff_Dimension_Code;
                    txtLocation.Text = itemArray[i].Location_Code;
                    //isFound = true;
                    
                }
            }

            return al;
        }

       

        private int GetNoOfSelectedRows(DataGrid GrdPost)
        {
            int count = 0;

            CurrencyManager cm = (CurrencyManager)this.BindingContext[GrdPost.DataSource];

            DataView dv = (DataView)cm.List;

            for (int i = 0; i < dv.Count; ++i)
            {

                if (GrdPost.IsSelected(i))
                {

                    count++;
                    updatnumber = i;
                }
            }
            return count;
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
        
        private void MnuNewGRN_Click(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
            try
            {
               
                int lineval;

                string strPDAName;
                strPDAName = GetPDANamefromConfig();

                QH_Functions.QH_Functions qhfun = new QHMobile.QH_Functions.QH_Functions();
                qhfun.Url = WebServiceInstants.GetURL(ServiceType.QH_Functions);
                qhfun.Credentials = nc;

                QHEmptyTank.QHEmptyTank_Service empSev = new QHMobile.QHEmptyTank.QHEmptyTank_Service();
                empSev.Url = WebServiceInstants.GetURL(ServiceType.QHEmptyTank);
                empSev.Credentials = nc;

                List<QHEmptyTank.QHEmptyTank_Filter> empfilterArray = new List<QHMobile.QHEmptyTank.QHEmptyTank_Filter>();


                if (BatchName.Equals("DOA"))
                {
                    qhfun.UpdateDepItemJournal("ITEM", "DOA");
                    string str = qhfun.PostItemJournalLineNeg();

                    if (str != "")
                    {
                        MessageBox.Show("This Bin could not find." + str);
                        return;
                    }
                    

                    MessageBox.Show("Journal Lines are posted sucessfully.");
                    dtPost.Clear();


                    QHEmptyTank.QHEmptyTank_Filter batchfilter = new QHMobile.QHEmptyTank.QHEmptyTank_Filter();
                    batchfilter.Field = QHMobile.QHEmptyTank.QHEmptyTank_Fields.Batch_Name;
                    batchfilter.Criteria = "DOA";

                    empfilterArray.Add(batchfilter);

                    QHEmptyTank.QHEmptyTank[] batchList = empSev.ReadMultiple(empfilterArray.ToArray(), null, 0);

                    for (int i = 0; i < batchList.Length; i++)
                    {
                        bool templfag = true;

                        if (!string.IsNullOrEmpty(batchList[i].Item_No) && !string.IsNullOrEmpty(batchList[i].Location_Code) && !string.IsNullOrEmpty(batchList[i].Bin_Code))
                        {
                            qhfun.TankAdj_NAV(batchList[i].Item_No, "", batchList[i].Location_Code, batchList[i].Bin_Code, 0, templfag, Rstaffdimensio,strPDAName,"DailyLPost");
                            //qhfun.TankAdj_NAV("", "", "", batchList[i].Bin_Code, 0, templfag);
                            // empSev.Delete(batchList[i].Bin_Code);  /// Need to check
                            empSev.Delete(batchList[i].Key.ToString());
                        }

                    }

                    //this.Close();
                    DailyLPost dlp = new DailyLPost(Rusername, Rstaffdimensio, Ruserlevel);
                    dlp.Show();
              
                    Cursor.Current = Cursors.Default;
                }
                else
                {
                    qhfun.UpdateDepItemJournal("ITEM", BatchName);
                    lineval = qhfun.PostItemJournalLine_DEFAULT();
                    if (lineval == 0)
                    {
                        MessageBox.Show("Journal Lines are posted sucessfully.");
                        dtPost.Clear();


                        QHEmptyTank.QHEmptyTank_Filter batchfilter = new QHMobile.QHEmptyTank.QHEmptyTank_Filter();
                        batchfilter.Field = QHMobile.QHEmptyTank.QHEmptyTank_Fields.Batch_Name;
                        batchfilter.Criteria = BatchName;

                        empfilterArray.Add(batchfilter);

                        QHEmptyTank.QHEmptyTank[] batchList = empSev.ReadMultiple(empfilterArray.ToArray(), null, 0);

                        for (int i = 0; i < batchList.Length; i++)
                        {
                            bool templfag = true;
                            qhfun.TankAdj_NAV(batchList[i].Item_No, "", batchList[i].Location_Code, batchList[i].Bin_Code, 0, templfag, Rstaffdimensio,strPDAName,"DailyLPost");
                            //qhfun.TankAdj_NAV("", "", "", batchList[i].Bin_Code, 0, templfag);
                            // empSev.Delete(batchList[i].Bin_Code);  /// Need to check
                            empSev.Delete(batchList[i].Key.ToString());

                        }

                        //this.Close();
                        DailyLPost dlp = new DailyLPost(Rusername, Rstaffdimensio, Ruserlevel);
                        dlp.Show();

                        Cursor.Current = Cursors.Default;
                    }
                    else
                    {
                        MessageBox.Show("Journal Lines are posted but throws error in some record. Line No" + lineval);
                    }
                }

                

            }
            catch (Exception ex)
            {
                MessageBox.Show("Error" + ex);
                Cursor.Current = Cursors.Default;
            }


            Cursor.Current = Cursors.Default;
        }

      

        private void mnuGRNBack_Click(object sender, EventArgs e)
        {
            this.Close();
            frmMain fm = new frmMain(Rusername, Rstaffdimensio, Ruserlevel);
            fm.Show();
        }

        private void btnSaveUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                Cursor.Current = Cursors.WaitCursor;

                ItemJournalDailyLossQH.ItemJournalDailyLossQH_Service Sev = new QHMobile.ItemJournalDailyLossQH.ItemJournalDailyLossQH_Service();
                Sev.Url = WebServiceInstants.GetURL(ServiceType.ItemJournalDailyLossQH);
                Sev.Credentials = nc;

                ItemJournalDailyLossQH.ItemJournalDailyLossQH update = Sev.Read(BatchName, Convert.ToInt32(txtLine.Text.Trim()));

                update.Bin_Code = txtBin.Text.Trim();
                update.Quantity = Convert.ToInt32(txtQty.Text.Trim());
                update.Staff_Dimension_Code = txtStaffCode.Text.Trim();

                Sev.Update(BatchName, ref update);


                GrdPost.DataSource = null;
                dtPost.Clear();

                List<ItemJournalDailyLossQH.ItemJournalDailyLossQH_Filter> FilterArray = new List<QHMobile.ItemJournalDailyLossQH.ItemJournalDailyLossQH_Filter>();

                ItemJournalDailyLossQH.ItemJournalDailyLossQH_Filter filterStaff = new QHMobile.ItemJournalDailyLossQH.ItemJournalDailyLossQH_Filter();
                filterStaff.Field = QHMobile.ItemJournalDailyLossQH.ItemJournalDailyLossQH_Fields.Staff_Dimension_Code;
                filterStaff.Criteria = cboDailyLPost.SelectedItem.ToString();

                FilterArray.Add(filterStaff);

                itemArray = Sev.ReadMultiple(BatchName, FilterArray.ToArray(), null, 0);


                for (int i = 0; i < itemArray.Length; i++)
                {
                    Object[] array = new Object[9];

                    array[0] = itemArray[i].Line_No;
                    array[1] = itemArray[i].Item_No;
                    array[2] = itemArray[i].Description;
                    array[3] = itemArray[i].Entry_Type;
                    array[4] = itemArray[i].Quantity;
                    array[5] = itemArray[i].Location_Code;
                    array[6] = itemArray[i].Bin_Code;
                    array[7] = itemArray[i].Staff_Dimension_Code;
                    array[8] = itemArray[i].Posting_Date;
                    dtPost.Rows.Add(array);





                   //Object[] array = new Object[9];

                 
                    
                }

                GrdPost.DataSource = dtPost;

                lblcountforpost.Text = dtPost.Rows.Count.ToString();

                Cursor.Current = Cursors.Default;

                MessageBox.Show("Successfully Updated!");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error:" + ex);
            }
        }

        private void menuItem1_Click(object sender, EventArgs e)
        {
            BatchName = "DOA";
            dtPost.Clear();
            cboDailyLPost.Items.Clear();
            MnuNewGRN.Enabled = true;
            BindLinesToPost();
            
        }

        private void menuItem2_Click(object sender, EventArgs e)
        {

            try
            {

                QHSalesReceivableSetup.QHSalesReceivableSetup_Service qhSaleSev = new QHMobile.QHSalesReceivableSetup.QHSalesReceivableSetup_Service();
                qhSaleSev.Url = WebServiceInstants.GetURL(ServiceType.QHSalesReceivableSetup);
                qhSaleSev.Credentials = nc;

                QHSalesReceivableSetup.QHSalesReceivableSetup[] qhBatch = qhSaleSev.ReadMultiple(null, null, 0);

                if (qhBatch.Length == 0)
                {
                    MessageBox.Show("There is no batch name found!. Please go and check in NAV!");
                }
                else
                {
                    BatchName = qhBatch[0].Change_Size_Batch;
                    dtPost.Clear();
                    cboDailyLPost.Items.Clear();
                    MnuNewGRN.Enabled = true;
                    BindLinesToPost();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        public void BindLinesToPost()
        {
            Cursor.Current = Cursors.WaitCursor;

            ItemJournalDailyLossQH.ItemJournalDailyLossQH_Service itemSev = new QHMobile.ItemJournalDailyLossQH.ItemJournalDailyLossQH_Service();
            itemSev.Url = WebServiceInstants.GetURL(ServiceType.ItemJournalDailyLossQH);
            itemSev.Credentials = nc;

            ItemJournalDailyLossQH.ItemJournalDailyLossQH[] itemArray = itemSev.ReadMultiple(BatchName, null, null, 0);


            ArrayList values = new ArrayList();

            for (int i = 0; i < itemArray.Length; i++)
            {
                if (!(values.Contains(itemArray[i].Staff_Dimension_Code)))
                {
                    if (itemArray[i].Staff_Dimension_Code != null)
                    {
                        values.Add(itemArray[i].Staff_Dimension_Code);
                    }
                }
            }

            for (int j = 0; j < values.Count; j++)
            {
                cboDailyLPost.Items.Add(values[j].ToString());
            }


            Cursor.Current = Cursors.Default;
        }
   
    }
}