using System;
using System.Linq;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlServerCe;
using QHMobile.PutAlwaysLinesQH;
using QHMobile.PutAlwaysQH;
using QHMobile.QH_Functions;
using System.Collections;
using QHMobile.QHBinContent;
using System.Text.RegularExpressions;

namespace QHMobile
{
    public partial class POAssignBin : Form
    {
        protected DataTable dt = new DataTable("MyTable");
        protected DataTable dtSo = new DataTable("MyTable1");
        protected DataTable dtassigned = new DataTable("MyTable1");

        protected System.Net.NetworkCredential nc = new System.Net.NetworkCredential(WebServiceInstants.GetURL(ServiceType.userName).ToString(), WebServiceInstants.GetURL(ServiceType.password).ToString(), WebServiceInstants.GetURL(ServiceType.domain).ToString());
        static List<QHMobile.POModule> pomod = new List<POModule>();
        static List<QHMobile.POModule> arraypo = new List<POModule>();
        static List<QHMobile.POModule> indivitualpo = new List<POModule>();
        static List<QHMobile.POModule> arl = new List<POModule>();
        static List<QHMobile.POModule> poCombo = new List<POModule>();
        ArrayList comboarray = new ArrayList();
        ArrayList comboAssigned = new ArrayList();
        SqlCeDataReader getallrecords;
        int updatnumber;
        //static BinQH.BinQH[] binhold;

        static string tempkey;
        decimal tempshowqty;
        string staffname, staffdimen, stafflevel;
        static ArrayList binarray = new ArrayList();
        //QHPO132473~VE0005~YUTAK~QH1
        string strVendorNo, strItem, strGLoc;
        
        string pukno;

        bool postflag = false;

        string strRecLoc;

        public POAssignBin()
        {
            InitializeComponent();

            MessageBox.Show("You cannot process further. Please go back to PO Bin List.");
        }


        public POAssignBin(string Rstaffname, string Rstaffdimen, string Rstafflevel, string ponumber, string RecvLocation)
        {
            InitializeComponent();

            pomod.Clear();
            arraypo.Clear();
            indivitualpo.Clear();
            arl.Clear();
            poCombo.Clear();
            comboarray.Clear();
            dtSo.Clear();
            dt.Clear();
            binarray.Clear();
            strRecLoc = RecvLocation;

            dt.Columns.Add(new DataColumn("Line No"));
            dt.Columns.Add(new DataColumn("Item No."));
            dt.Columns.Add(new DataColumn("Description"));
            dt.Columns.Add(new DataColumn("Quantity"));
            dt.Columns.Add(new DataColumn("Location"));
            dt.Columns.Add(new DataColumn("Bin"));

            dtSo.Columns.Add(new DataColumn("Line No"));
            dtSo.Columns.Add(new DataColumn("Item No."));
            dtSo.Columns.Add(new DataColumn("Description"));
            dtSo.Columns.Add(new DataColumn("Quantity"));
            dtSo.Columns.Add(new DataColumn("Location"));

            dtassigned.Columns.Add(new DataColumn("Line No"));
            dtassigned.Columns.Add(new DataColumn("Item No."));
            dtassigned.Columns.Add(new DataColumn("Description"));
            dtassigned.Columns.Add(new DataColumn("Quantity"));
            dtassigned.Columns.Add(new DataColumn("Location"));
            dtassigned.Columns.Add(new DataColumn("Bin"));

            this.staffname = Rstaffname;
            this.staffdimen = Rstaffdimen;
            this.stafflevel = Rstafflevel;

            string s = ponumber;
            string[] words = s.Split('~');
            txtPO.Text = words[0];
            strVendorNo = words[1];
            strItem = words[2];
            txtlocation.Text = words[3];
            pomod.Clear();

            lblStaffDimension.Text = staffdimen; 

            CheckPO();

            //CompactSQL comsql = new CompactSQL();
            //getallrecords = comsql.SelectRecordPOAssign("POAssign", txtTO.Text);

            //if (getallrecords.Read())
            //{
            //    MessageBox.Show("Here has got SQL value!");
            //    GetRecordsFromSQL(getallrecords);
            //    CheckPO();
            //}
            //else
            //{

                
            //}

            

            if (txtScanItemNo.Items.Count > 0)
            {
                AddValue SelItemValue = (AddValue)txtScanItemNo.Items[0];
                string strItemNo = SelItemValue.Display;
                
                ItemQH.ItemQH_Service itemsev = new QHMobile.ItemQH.ItemQH_Service();
                itemsev.Url = WebServiceInstants.GetURL(ServiceType.ItemQH);
                itemsev.Credentials = nc;
                //string aa = txtScanItemNo.SelectedValue.ToString();
                ItemQH.ItemQH itemdescription = itemsev.Read(strItemNo);
                if (itemdescription != null)
                {
                    lblDescription.Text = itemdescription.Description;
                }
        



                GetEmptyBin(txtScanItemNo.Items[0].ToString(), txtlocation.Text.ToString().Trim());

                if (binarray.Count > 0)
                {
                    txtbin.Text = binarray[0].ToString();
                }

                
            }



            if (postflag == false)
            {
                MnuPost.Enabled = false;
            }
            else
            {
                MnuPost.Enabled = true;
            }

            BindAssigned();

        }

        private void GetRecordsFromSQL(SqlCeDataReader getallrecords)
        {
            do
            {
                Object[] array = new Object[6];
                QHMobile.POModule assignPO = new POModule();

                assignPO.lineno = Convert.ToInt32(getallrecords["LineNo"]);
                array[0] = getallrecords["LineNo"].ToString();

                array[1] = getallrecords["itemNo"].ToString();
                assignPO.itemNo = getallrecords["itemNo"].ToString();
                array[2] = getallrecords["Description"].ToString();
                assignPO.description = getallrecords["Description"].ToString();
                array[3] = getallrecords["Quantity"].ToString();
                assignPO.quantity = Convert.ToInt32(getallrecords["Quantity"]);
                array[4] = getallrecords["Location"].ToString();
                assignPO.location = getallrecords["Location"].ToString();
                array[5] = getallrecords["BinCode"].ToString();
                assignPO.bin = getallrecords["BinCode"].ToString();

                dt.Rows.Add(array);
                arraypo.Add(assignPO);

            } while (getallrecords.Read());


            for (int i = 0; i < arraypo.Count; i++)
            {
                for (int j = 0; j < binarray.Count; j++)
                {
                    if(arraypo[i].bin.Equals(binarray[j].ToString()))
                    {
                        binarray.RemoveAt(j);
                    }
                }
                
            }
            //txtbin.Text = binarray[0].ToString();

            //if (txtScanItemNo.Items.Count > 0)
            //{
            //    GetEmptyBin(txtScanItemNo.Items[0].ToString(), txtlocation.Text.ToString().Trim());

            //    if (binarray.Count > 0)
            //    {
            //        txtbin.Text = binarray[0].ToString();
            //    }
            //}

            GrdTO.DataSource = dt;
        }

        private void BindAssigned()
        {
            try
            {
                Cursor.Current = Cursors.WaitCursor;


                dtassigned.Rows.Clear();
                GrdAssign.DataSource = null;
                dtassigned.Clear();

                WhseLineQH.WhseLineQH_Service wseverice = new QHMobile.WhseLineQH.WhseLineQH_Service();
                wseverice.Url = WebServiceInstants.GetURL(ServiceType.WhseLineQH);
                wseverice.Credentials = nc;
                //string linetemp = cboAssignedItems.SelectedValue.ToString();
                //int lineNo = Convert.ToInt16(linetemp);

                List<WhseLineQH.WhseLineQH_Filter> filterArray = new List<QHMobile.WhseLineQH.WhseLineQH_Filter>();

                WhseLineQH.WhseLineQH_Filter filNum = new QHMobile.WhseLineQH.WhseLineQH_Filter();
                filNum.Field = QHMobile.WhseLineQH.WhseLineQH_Fields.No;
                filNum.Criteria = tempkey;


                filterArray.Add(filNum);

                WhseLineQH.WhseLineQH[] whseLines = wseverice.ReadMultiple(filterArray.ToArray(),null,0);//("Invt. Put-away"


                for (int i = 0; i < whseLines.Length; i++)
                {
                    if (whseLines[i].Bin_Code != null)
                    {
                        Object[] array = new Object[6];
                        array[0] = whseLines[i].Line_No;
                        array[1] = whseLines[i].Item_No;
                        array[2] = whseLines[i].Description;
                        array[3] = whseLines[i].Quantity;
                        array[4] = whseLines[i].Location_Code;
                        array[5] = whseLines[i].Bin_Code;

                        dtassigned.Rows.Add(array);
                    }
                }

                

                GrdAssign.DataSource = dtassigned;

                Cursor.Current = Cursors.Default;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Exception" + ex);
            } 
        }

        /*
        private void GetBinByItemNo(string ItemNo)
        {
            binarray = new ArrayList();

            QHBinContent.QHBinContent_Service qhBinContSev = new QHMobile.QHBinContent.QHBinContent_Service();
            qhBinContSev.Url = WebServiceInstants.GetURL(ServiceType.QHBinContent);
            qhBinContSev.Credentials = nc;

            List<QHBinContent.QHBinContent_Filter> filterarray = new List<QHMobile.QHBinContent.QHBinContent_Filter>();

            QHBinContent.QHBinContent_Filter fitem = new QHMobile.QHBinContent.QHBinContent_Filter();
            fitem.Field = QHMobile.QHBinContent.QHBinContent_Fields.Item_No;
            fitem.Criteria = ItemNo;

            filterarray.Add(fitem);

            QHBinContent.QHBinContent[] qhBinContent = qhBinContSev.ReadMultiple(filterarray.ToArray(), null, 0);

            List<BinQH.BinQH> Lbin = new List<QHMobile.BinQH.BinQH>();

            if (qhBinContent.Length > 0)
            {
                BinQH.BinQH_Service binserv = new QHMobile.BinQH.BinQH_Service();
                binserv.Url = WebServiceInstants.GetURL(ServiceType.BinQH);
                binserv.Credentials = nc;

                for (int i = 0; i < qhBinContent.Length; i++)
                {
                    List<BinQH.BinQH_Filter> filterarrayBin = new List<BinQH.BinQH_Filter>();
                    BinQH.BinQH_Filter filterBin = new QHMobile.BinQH.BinQH_Filter();
                    filterBin.Field = QHMobile.BinQH.BinQH_Fields.Code;
                    filterBin.Criteria = qhBinContent[i].Bin_Code;
                    filterarrayBin.Add(filterBin);
                    BinQH.BinQH[] bin = binserv.ReadMultiple(filterarrayBin.ToArray(), null, 0);

                    //BinQH.BinQH bin = binserv.Read(qhBinContent[i].Location_Code, qhBinContent[i].Bin_Code);

                    if (bin.Length > 0)
                    {

                        if (bin[0].Empty && !bin[0].Assigned)
                        {
                            binarray.Add(binhold[i].Code);
                        }
                        else
                        {
                            ///rrrr
                            /// Checking at warehouse activity line having same item or not

                            WhseLineQH.WhseLineQH_Service wseActLine = new QHMobile.WhseLineQH.WhseLineQH_Service();
                            wseActLine.Url = WebServiceInstants.GetURL(ServiceType.WhseLineQH);
                            wseActLine.Credentials = nc;

                            List<WhseLineQH.WhseLineQH_Filter> filterArray = new List<QHMobile.WhseLineQH.WhseLineQH_Filter>();

                            WhseLineQH.WhseLineQH_Filter filterBinCode = new QHMobile.WhseLineQH.WhseLineQH_Filter();
                            filterBinCode.Field = QHMobile.WhseLineQH.WhseLineQH_Fields.Bin_Code;
                            filterBinCode.Criteria = qhBinContent[i].Bin_Code;

                            WhseLineQH.WhseLineQH_Filter filterItemNo = new QHMobile.WhseLineQH.WhseLineQH_Filter();
                            filterItemNo.Field = QHMobile.WhseLineQH.WhseLineQH_Fields.Item_No;
                            filterItemNo.Criteria = txtScanItemNo.Items[i].ToString();

                            //WhseLineQH.WhseLineQH_Filter filterLocation = new QHMobile.WhseLineQH.WhseLineQH_Filter();
                            //filterLocation.Field = QHMobile.WhseLineQH.WhseLineQH_Fields.Location_Code;
                            //filterLocation.Criteria = qhBinContent[i].Location_Code;


                            filterArray.Add(filterBinCode);
                            //filterArray.Add(filterLocation);
                            filterArray.Add(filterItemNo);

                            WhseLineQH.WhseLineQH[] ActList = wseActLine.ReadMultiple(filterArray.ToArray(), null, 0);
                            //int totalcount = 0;

                            if (ActList.Length > 0)
                            {
                                binarray.Add(binhold[i].Code);
                            }
                            /// Checking at warehouse activity line having same item or not
                            

                        }
                    }
                }

            }
            
        }
        */

        private void GetEmptyBin(string strItem, string strLocation)
        {

            QH_Functions.QH_Functions qhfun = new QHMobile.QH_Functions.QH_Functions();
            qhfun.Url = WebServiceInstants.GetURL(ServiceType.QH_Functions);
            qhfun.Credentials = nc;

            string[] EmptList = new string[100];
            for (int i = 0; i < 100; i++)
            {
                EmptList[i] = "-";

            }
            
            if (txtScanItemNo.Items.Count > 0)
            {
                //qhfun.GetEmptyBin(txtScanItemNo.Items[0].ToString(), ref EmptList);
                qhfun.GetEmptyBin(strItem, strLocation.Trim(), ref EmptList);
            }
            else
            {
                qhfun.GetEmptyBin("", strLocation.Trim(), ref EmptList);
            }

            for (int i = 0; i < 100; i++)
            {
                if (EmptList[i] != "-")
                {
                    binarray.Add(EmptList[i]);
                }
                
            }
        }
        private void CheckPO()
        {
            try
            {

                WhseLineQH.WhseLineQH_Service whserv = new QHMobile.WhseLineQH.WhseLineQH_Service();
                whserv.Url = WebServiceInstants.GetURL(ServiceType.WhseLineQH);
                whserv.Credentials = nc;

                List<WhseLineQH.WhseLineQH_Filter> filter = new List<QHMobile.WhseLineQH.WhseLineQH_Filter>();

                WhseLineQH.WhseLineQH_Filter filtersource = new QHMobile.WhseLineQH.WhseLineQH_Filter();
                filtersource.Field = QHMobile.WhseLineQH.WhseLineQH_Fields.Source_No;
                filtersource.Criteria = txtPO.Text.Trim();

                filter.Add(filtersource);

                WhseLineQH.WhseLineQH_Filter filterLoc = new QHMobile.WhseLineQH.WhseLineQH_Filter();
                filterLoc.Field = QHMobile.WhseLineQH.WhseLineQH_Fields.Location_Code;
                filterLoc.Criteria = txtlocation.Text.Trim();
                filter.Add(filterLoc);


                WhseLineQH.WhseLineQH[] linearray = whserv.ReadMultiple(filter.ToArray(), null, 0);

                if (linearray.Length < 1)
                {
                    InsertToJournal();
                }
                else
                {
                    GoToUpdateProcess(linearray);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void BindItemCombo()
        {
            ArrayList values = new ArrayList();
            for (int i = 0; i < pomod.Count; i++)
            {

                //if (!values.Contains(pomod[i].itemNo))
                //{
                   // values.Add(pomod[i].itemNo);
                    txtScanItemNo.Items.Add(pomod[i].itemNo);
                    txtScanItemNo.ValueMember = pomod[i].lineno.ToString();

                //}

            }

            for (int i = 0; i < values.Count; i++)
            {
                POModule poc = new POModule();

                for (int j = 0; j < pomod.Count; j++)
                {
                    if (values[i].ToString().Equals(pomod[j].itemNo))
                    {

                        poc.itemNo = values[i].ToString();
                        poc.quantity += pomod[j].quantity;
                    }
                }

                poCombo.Add(poc);

            }

        }

        private void mnuGRNBack_Click(object sender, EventArgs e)
        {
            this.Close();
            frmMain msc = new frmMain(staffname, staffdimen, stafflevel);
            msc.Show();
        }
        private void frmGRN_Load(object sender, EventArgs e)
        {

            Cursor.Current = Cursors.Default;

        }
        private string SplitString(string strInput)
        {
            char[] aChar = strInput.ToCharArray();
            Array.Reverse(aChar);
            string strResult = new string(aChar);
            return strResult;
        }
        private string CheckBinAssignOnCurrentPDA(string strBin)
        {
            string ret = "";
            if (dt.Rows.Count > 0)
            {
                 for (int i = 0; i < dt.Rows.Count; i++)
                {
                    if (dt.Rows[i][5].ToString() == txtbin.Text.ToString())
                    {
                        //ret = 
                        return dt.Rows[i][1].ToString(); //return Item
                    }
                 }
            }
            return ret;
        }
        private string CheckAssignBinByItem()
        {
            string ret = "";

            AddValue SelItemValue = (AddValue)txtScanItemNo.SelectedItem;
            string strItemNo = SelItemValue.Display;


            if (arraypo.Count > 0)
            {
                for (int i = 0; i < arraypo.Count; i++)
                {
                    if ((arraypo[i].bin.ToString().ToUpper() == txtbin.Text.ToString().ToUpper()) &&
                        (arraypo[i].itemNo.ToString().ToUpper() != strItemNo.ToUpper()))
                    {
                        ret = arraypo[i].itemNo.ToString();
                    }
                }
            }

            if (dtassigned.Rows.Count >0)
            {
                for (int i = 0; i < dtassigned.Rows.Count; i++)
                {
                    if ((dtassigned.Rows[i][5].ToString().ToUpper() == txtbin.Text.ToString().ToUpper()) &&
                       (dtassigned.Rows[i][1].ToString().ToUpper() != strItemNo.ToUpper()))
                    {
                        ret = dtassigned.Rows[i][1].ToString();
                    }

                }
            }
            return ret;
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtbin.Text.Equals("") || txtlocation.Text.Equals("") || txtScanItemNo.Text.Equals("") || txtqty.Text.Equals(""))
                {
                    MessageBox.Show("Key in all required fields.");
                }
                else
                {

                    for (int i = 0; i < pomod.Count; i++)
                    {
                       
                    
                        if (txtScanItemNo.SelectedValue.ToString().Equals(pomod[i].lineno.ToString()))
                        {
                            QH_Functions.QH_Functions qhfun1 = new QHMobile.QH_Functions.QH_Functions();
                            qhfun1.Credentials = nc;
                            qhfun1.Url = WebServiceInstants.GetURL(ServiceType.QH_Functions);
                            AddValue oItem1 = (AddValue)txtScanItemNo.SelectedItem;
                                                                        //Checking for already assign Bin
                            if (!qhfun1.CheckDummyBin(txtlocation.Text.Trim(), txtbin.Text.Trim(), oItem1.Display.Trim()))
                            {
                                string strItemRet = CheckAssignBinByItem();
                                if (!string.IsNullOrEmpty(strItemRet.Trim()))
                                {
                                    //thurein33
                                    //MessageBox.Show("Bin " + txtbin.Text.ToString() + " was already assigned item " + strItemRet);
                                    MessageBox.Show("You are not allow to assign different item into " + txtbin.Text.ToString());
                                    //"You are not allow to assign different item into Z-2000"
                                    return;
                                }
                            }


                            if (Convert.ToInt32(txtqty.Text.Trim()) > pomod[i].quantity ||
                                pomod[i].quantity <= 0)//pomod[i].quantity <= 0 )
                            {
                                MessageBox.Show("No more quantity!");
                            }
                            else
                            {
                                //string strItemRet = CheckAssignBinByItem(
                                BinQH.BinQH_Service bqhservice = new QHMobile.BinQH.BinQH_Service();
                                bqhservice.Url = WebServiceInstants.GetURL(ServiceType.BinQH);
                                bqhservice.Credentials = nc;
                                BinQH.BinQH bqh = bqhservice.Read(txtlocation.Text.Trim(), txtbin.Text.Trim());

                                if (bqh == null)
                                {
                                    MessageBox.Show("There is no bin found.");
                                }
                                else
                                {
                                    Cursor.Current = Cursors.WaitCursor;
                                    for (int j = 0; j < pomod.Count; j++)
                                    {
                                        if (txtScanItemNo.SelectedValue.ToString().Equals(pomod[j].lineno.ToString()))
                                        {
                                            //Checking for assign item to existing bin or not

                                            //check 
                                            QH_Functions.QH_Functions qhfun = new QHMobile.QH_Functions.QH_Functions();
                                            qhfun.Credentials = nc;
                                            qhfun.Url = WebServiceInstants.GetURL(ServiceType.QH_Functions);
                                            AddValue oItem = (AddValue)txtScanItemNo.SelectedItem;
                                            //Checking for already assign Bin
                                            if (!qhfun.CheckDummyBin(txtlocation.Text.Trim(), txtbin.Text.Trim(), oItem.Display.Trim()))
                                            {
                                                string retItem = CheckBinAssignOnCurrentPDA(txtbin.Text.ToString()); //thu55
                                                if (!string.IsNullOrEmpty(retItem))
                                                {
                                                    if (retItem == txtScanItemNo.Text.Trim())
                                                    {
                                                        MessageBox.Show("Bin : " + txtbin.Text.ToString() + " assigned to Item: " + retItem);
                                                        //Cursor.Current = Cursors.Default;
                                                        //txtbin.SelectAll();
                                                    }
                                                    else
                                                    {
                                                        MessageBox.Show("Bin : " + txtbin.Text.ToString() + " assigned to Item: " + retItem);
                                                        Cursor.Current = Cursors.Default;
                                                        txtbin.SelectAll();
                                                        return;
                                                    }

                                                }
                                            }

                                            //string vStrLoc = "";
                                            //string vStrBin = "";
                                            //string vStrItem = "";
                                            //vStrLoc = txtlocation.Text.Trim();
                                            //vStrBin = txtbin.Text.Trim();
                                            //qhfun.BinContentInfo(ref vStrLoc, ref vStrBin, ref vStrItem);
                                            //if (!string.IsNullOrEmpty(vStrItem))
                                            //{
                                            //    string[] lItem = vStrItem.Split('|');
                                            //    string strMsg = "Existing Item(s) in Loc : " + vStrLoc + " Bin: " + vStrBin + " have ";
                                            //    foreach (string s in lItem)
                                            //    {
                                            //        strMsg = strMsg + s.Replace('~', '=') + " ";
                                            //    }
                                            //    MessageBox.Show(strMsg);
                                            //    //MessageBox.Show("Item :" + vStrItem + " is allocated on Loc: " + vStrLoc + " Bin: " + vStrBin);
                                            //    Cursor.Current = Cursors.Default;
                                            //    txtbin.SelectAll();
                                            //   // return;
                                            //}
                                            
                                            //DD717 flow changes
                                            if (qhfun.CheckDummyBin(txtlocation.Text.Trim(), txtbin.Text.Trim(), oItem.Display.Trim()))
                                            {
                                                if (qhfun.CheckDummyBinSameItem(txtlocation.Text.Trim(), txtbin.Text.Trim(), oItem.Display.Trim()))
                                                {
                                                    //Process Put-Away
                                                    //copy from original on top
                                                    Object[] array = new Object[6];
                                                    POModule poline = new POModule();

                                                    array[0] = pomod[j].lineno;
                                                    poline.lineno = pomod[j].lineno;
                                                    array[1] = pomod[j].itemNo;
                                                    poline.itemNo = pomod[i].itemNo;
                                                    array[2] = pomod[i].description;
                                                    poline.description = pomod[i].description;

                                                    array[3] = txtqty.Text.Trim();
                                                    poline.quantity = Convert.ToInt32(txtqty.Text.Trim());
                                                    pomod[i].quantity = pomod[i].quantity - Convert.ToInt32(txtqty.Text.Trim());
                                                    lblTotalQty.Text = "Total Qty of this item is : " + pomod[i].quantity;

                                                    array[4] = txtlocation.Text.Trim();
                                                    poline.location = txtlocation.Text.Trim();
                                                    array[5] = txtbin.Text.Trim();
                                                    poline.bin = txtbin.Text.Trim();
                                                    poline.Sourcelineno = pomod[j].Sourcelineno;

                                                    //ttt
                                                    //poline.Sourcelineno = pomod[i].s

                                                    arraypo.Add(poline);
                                                    dt.Rows.Add(array);

                                                    binarray.Remove(txtbin.Text);

                                                    if (pomod[i].quantity > 0)
                                                    {
                                                        if (binarray.Count > 0)
                                                        {
                                                            txtbin.Text = binarray[0].ToString();
                                                        }

                                                    }
                                                    else
                                                    {
                                                        //txtbin.Text = "";
                                                        txtbin.SelectAll();
                                                    }

                                                    Cursor.Current = Cursors.Default;
                                                    break;
                                                    //copy from original on top
                                                    //Process Put-Away
                                                }
                                                else
                                                {
                                                    //Prompt Message
                                                    //string vStrLoc = "";
                                                    //string vStrBin = "";
                                                    //string vStrItem = "";
                                                    //vStrLoc = txtlocation.Text.Trim();
                                                    //vStrBin = txtbin.Text.Trim();
                                                    //qhfun.BinContentInfo(ref vStrLoc, ref vStrBin, ref vStrItem);
                                                    //if (!string.IsNullOrEmpty(vStrItem))
                                                    //{
                                                    //    string[] lItem = vStrItem.Split('|'); //thu22
                                                    //    //string strMsg = "Existing Item(s) in Loc : " + vStrLoc + " Bin: " + vStrBin + " have ";
                                                    //    //foreach (string s in lItem)
                                                    //    //{
                                                    //    //    strMsg = strMsg + s.Replace('~', '=') + " ";
                                                    //    //}
                                                    //    string strMsg = "You are not allow to assign different item code into Dummy Bin";
                                                    //    MessageBox.Show(strMsg);
                                                    //    //MessageBox.Show("Item :" + vStrItem + " is allocated on Loc: " + vStrLoc + " Bin: " + vStrBin);
                                                    //    Cursor.Current = Cursors.Default;
                                                    //    txtbin.SelectAll();
                                                    //    return;
                                                    //}
                                                    //End of the prompt

                                                    //copy from original on top
                                                    Object[] array = new Object[6];
                                                    POModule poline = new POModule();

                                                    array[0] = pomod[j].lineno;
                                                    poline.lineno = pomod[j].lineno;
                                                    array[1] = pomod[j].itemNo;
                                                    poline.itemNo = pomod[i].itemNo;
                                                    array[2] = pomod[i].description;
                                                    poline.description = pomod[i].description;

                                                    array[3] = txtqty.Text.Trim();
                                                    poline.quantity = Convert.ToInt32(txtqty.Text.Trim());
                                                    pomod[i].quantity = pomod[i].quantity - Convert.ToInt32(txtqty.Text.Trim());
                                                    lblTotalQty.Text = "Total Qty of this item is : " + pomod[i].quantity;

                                                    array[4] = txtlocation.Text.Trim();
                                                    poline.location = txtlocation.Text.Trim();
                                                    array[5] = txtbin.Text.Trim();
                                                    poline.bin = txtbin.Text.Trim();
                                                    poline.Sourcelineno = pomod[j].Sourcelineno;

                                                    //ttt
                                                    //poline.Sourcelineno = pomod[i].s

                                                    arraypo.Add(poline);
                                                    dt.Rows.Add(array);

                                                    binarray.Remove(txtbin.Text);

                                                    if (pomod[i].quantity > 0)
                                                    {
                                                        if (binarray.Count > 0)
                                                        {
                                                            txtbin.Text = binarray[0].ToString();
                                                        }

                                                    }
                                                    else
                                                    {
                                                        //txtbin.Text = "";
                                                        txtbin.SelectAll();
                                                    }

                                                    Cursor.Current = Cursors.Default;
                                                    break;
                                                    //copy from original on top



                                                }
                                            }
                                            else
                                            {
                                                if (!qhfun.CheckBinContent2(txtlocation.Text.Trim(), txtbin.Text.Trim(), oItem.Display.Trim()))
                                                {
                                                    //prompt item Actual Avalibility (custom)
                                                    string vStrLoc = "";
                                                    string vStrBin = "";
                                                    string vStrItem = "";
                                                    vStrLoc = txtlocation.Text.Trim();
                                                    vStrBin = txtbin.Text.Trim();
                                                    string[] lItem;
                                                    qhfun.BinContentInfo(ref vStrLoc, ref vStrBin, ref vStrItem);
                                                    string strConfirmMsg = "";
                                                    if (!string.IsNullOrEmpty(vStrItem))
                                                    {
                                                        lItem = vStrItem.Split('|');
                                                        string strMsg = "Existing Item(s) in Loc : " + vStrLoc + " Bin: " + vStrBin + " have ";
                                                        strConfirmMsg = "Empty Bin with ";
                                                        foreach (string s in lItem)
                                                        {
                                                            strMsg = strMsg + s.Replace('~', '=') + " ";
                                                            strConfirmMsg = strConfirmMsg + s.Replace('~', '=') + " ";
                                                        }
                                                        MessageBox.Show(strMsg);
                                                        //MessageBox.Show("Item :" + vStrItem + " is allocated on Loc: " + vStrLoc + " Bin: " + vStrBin);
                                                        Cursor.Current = Cursors.Default;
                                                        //txtbin.SelectAll();
                                                    }
                                                    //Prompt end
                                                    //yes/no

                                                    if (MessageBox.Show(strConfirmMsg + " Do you want to proceed?", "Confirm Clear Bin", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1) == DialogResult.Yes)
                                                    //if (MessageBox.Show("This Bin " + txtbin.Text + " is not allow to assign for Item " + oItem.Display.ToString() + " Do you want to proceed?", "Confirm Clear Bin", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1) == DialogResult.Yes)
                                                    {
                                                        Cursor.Current = Cursors.WaitCursor;
                                                        qhfun.ClearBinContent_POAssignment(txtlocation.Text.Trim(), txtbin.Text.Trim(), oItem.Display.Trim(), txtPO.Text.Trim(), lblStaffDimension.Text.Trim());
                                                        //copy from original on top
                                                        Object[] array = new Object[6];
                                                        POModule poline = new POModule();

                                                        array[0] = pomod[j].lineno;
                                                        poline.lineno = pomod[j].lineno;
                                                        array[1] = pomod[j].itemNo;
                                                        poline.itemNo = pomod[i].itemNo;
                                                        array[2] = pomod[i].description;
                                                        poline.description = pomod[i].description;

                                                        array[3] = txtqty.Text.Trim();
                                                        poline.quantity = Convert.ToInt32(txtqty.Text.Trim());
                                                        pomod[i].quantity = pomod[i].quantity - Convert.ToInt32(txtqty.Text.Trim());
                                                        lblTotalQty.Text = "Total Qty of this item is : " + pomod[i].quantity;

                                                        array[4] = txtlocation.Text.Trim();
                                                        poline.location = txtlocation.Text.Trim();
                                                        array[5] = txtbin.Text.Trim();
                                                        poline.bin = txtbin.Text.Trim();
                                                        poline.Sourcelineno = pomod[j].Sourcelineno;

                                                        arraypo.Add(poline);
                                                        dt.Rows.Add(array);

                                                        binarray.Remove(txtbin.Text);

                                                        if (pomod[i].quantity > 0)
                                                        {
                                                            if (binarray.Count > 0)
                                                            {
                                                                txtbin.Text = binarray[0].ToString();
                                                            }

                                                        }
                                                        else
                                                        {
                                                            //txtbin.Text = "";
                                                            txtbin.SelectAll();
                                                        }
                                                        Cursor.Current = Cursors.Default;
                                                        break;

                                                    }
                                                    //yes/no

                                                }
                                                else
                                                {
                                                    //Process Put away
                                                    Object[] array = new Object[6];
                                                    POModule poline = new POModule();

                                                    array[0] = pomod[j].lineno;
                                                    poline.lineno = pomod[j].lineno;
                                                    array[1] = pomod[j].itemNo;
                                                    poline.itemNo = pomod[i].itemNo;
                                                    array[2] = pomod[i].description;
                                                    poline.description = pomod[i].description;

                                                    array[3] = txtqty.Text.Trim();
                                                    poline.quantity = Convert.ToInt32(txtqty.Text.Trim());
                                                    pomod[i].quantity = pomod[i].quantity - Convert.ToInt32(txtqty.Text.Trim());
                                                    lblTotalQty.Text = "Total Qty of this item is : " + pomod[i].quantity;

                                                    array[4] = txtlocation.Text.Trim();
                                                    poline.location = txtlocation.Text.Trim();
                                                    array[5] = txtbin.Text.Trim();
                                                    poline.bin = txtbin.Text.Trim();
                                                    poline.Sourcelineno = pomod[j].Sourcelineno;

                                                    //ttt
                                                    //poline.Sourcelineno = pomod[i].s

                                                    arraypo.Add(poline);
                                                    dt.Rows.Add(array);

                                                    binarray.Remove(txtbin.Text);

                                                    if (pomod[i].quantity > 0)
                                                    {
                                                        if (binarray.Count > 0)
                                                        {
                                                            txtbin.Text = binarray[0].ToString();
                                                        }

                                                    }
                                                    else
                                                    {
                                                        //txtbin.Text = "";
                                                        txtbin.SelectAll();
                                                    }

                                                    Cursor.Current = Cursors.Default;
                                                    break;
                                                    //Process Put away


                                                }
                                            }
                                            //DD717 flow changes

                                        }

                                    }

                                }

                                txtqty.SelectAll();
                            }

                        }
                    }
                    GrdTO.DataSource = dt;

                    CheckMenuVisible(pomod);

                }

            }
            catch (Exception ex)
            {
                //string s = ex.Message;
                MessageBox.Show(ex.Message);
            }

        }
        private void CheckMenuVisible(List<POModule> pomod)
        {
            bool MenuFlag = false;

            for (int i = 0; i < pomod.Count; i++)
            {
                if (pomod[i].quantity != 0)
                {
                    MenuFlag = true;
                }

            }

            if (MenuFlag == true)
            {
                // MnuNewGRN.Enabled = false;
            }
            else
            {
                //MnuNewGRN.Enabled = true;
            }

        }
        private void InsertToJournal()
        {
            try
            {
                comboarray.Clear();

                PurchaseQH.PurchaseQH_Service poservice = new QHMobile.PurchaseQH.PurchaseQH_Service();
                poservice.Url = WebServiceInstants.GetURL(ServiceType.PurchaseQH);
                poservice.Credentials = nc;
                PutAlwaysQH.PutAlwaysQH_Service alwayservice = new QHMobile.PutAlwaysQH.PutAlwaysQH_Service();
                alwayservice.Url = WebServiceInstants.GetURL(ServiceType.PutAlwaysQH);
                alwayservice.Credentials = nc;
                PutAlwaysQH.PutAlwaysQH putalways = new QHMobile.PutAlwaysQH.PutAlwaysQH();
                alwayservice.Create(ref putalways);

                tempkey = putalways.No;
                pukno = putalways.No;
                string temptype = PutAlwaysQH.Type.Put_away.ToString();

                putalways.Source_Document = QHMobile.PutAlwaysQH.Source_Document.Purchase_Order;
                //putalways.Location_Code = strRecLoc; // Hard Code 
                putalways.Location_Code = txtlocation.Text.Trim();

                alwayservice.Update(ref putalways);

                putalways.Source_No = txtPO.Text.Trim();

                alwayservice.Update(ref putalways);

                PutAlwaysLinesQH.PutAlwaysLinesQH_Service lineservice = new PutAlwaysLinesQH_Service();
                lineservice.Url = WebServiceInstants.GetURL(ServiceType.PutAlwaysLinesQH);
                lineservice.Credentials = nc;
                string tempactivity = PutAlwaysLinesQH.Activity_Type.Invt_Put_away.ToString();

                List<PutAlwaysLinesQH.PutAlwaysLinesQH_Filter> filterArray = new List<PutAlwaysLinesQH_Filter>();

                PutAlwaysLinesQH.PutAlwaysLinesQH_Filter fitlerNumber = new PutAlwaysLinesQH_Filter();
                fitlerNumber.Field = PutAlwaysLinesQH_Fields.No;
                fitlerNumber.Criteria = putalways.No;
                filterArray.Add(fitlerNumber);


                PutAlwaysLinesQH.PutAlwaysLinesQH[] forCombo = lineservice.ReadMultiple(filterArray.ToArray(), null, 0);
                txtlocation.Text = forCombo[0].Location_Code;
                //warehouse activity line bin code update to empty
                for (int k = 0; k < forCombo.Length; k++)
                {
                    PutAlwaysLinesQH.PutAlwaysLinesQH toUpdate = new QHMobile.PutAlwaysLinesQH.PutAlwaysLinesQH();
                   toUpdate = lineservice.Read(PutAlwaysLinesQH.Activity_Type.Invt_Put_away.ToString(),tempkey,forCombo[k].Line_No);

                   toUpdate.Bin_Code = "";

                   lineservice.Update(ref toUpdate);
                   // forCombo[k].Bin_Code = null; 

                }
                //warehouse activity line bin code update to empty

                //lineservice.UpdateMultiple(ref forCombo);

                for (int i = 0; i < forCombo.Length; i++)
                {
                    Object[] array = new Object[5];
                    QHMobile.POModule po = new POModule();

                    //txtScanItemNo.Items.Add(forCombo[i].Item_No);
                    //txtScanItemNo.ValueMember = forCombo[i].Line_No.ToString();

                    comboarray.Add(new AddValue(forCombo[i].Item_No, forCombo[i].Line_No));

                    po.itemNo = forCombo[i].Item_No;
                    array[0] = forCombo[i].Line_No;
                    po.lineno = forCombo[i].Line_No;
                    array[1] = forCombo[i].Item_No;
                    po.description = forCombo[i].Description;
                    array[2] = forCombo[i].Description;
                    po.location = forCombo[i].Location_Code;
                    array[3] = forCombo[i].Quantity;
                    po.quantity = forCombo[i].Quantity;
                    array[4] = forCombo[i].Location_Code;
                    po.Sourcelineno = forCombo[i].Source_Line_No;

                    dtSo.Rows.Add(array);
                    pomod.Add(po);
                }

                this.txtScanItemNo.DataSource = comboarray;
                this.txtScanItemNo.DisplayMember = "Display";
                this.txtScanItemNo.ValueMember = "Value";
                lblTotalQty.Text = "Total Qty is of this item: " + forCombo[0].Quantity;

                GrdPoLines.DataSource = dtSo;

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            Cursor.Current = Cursors.Default;

        }

        private void menuItem1_Click(object sender, EventArgs e)
        {
            this.Close();
            frmMain fm = new frmMain(staffname, staffdimen, stafflevel);
            fm.Show();
        }

        private decimal GetPutawayTotalQtyByPOLine(WhseLineQH.WhseLineQH[] Rlinearray, int LineNo)
        {
            decimal ret=0;
            for (int i = 0; i < Rlinearray.Length; i++)
            {
                if ((Rlinearray[i].Bin_Code != null) && (Rlinearray[i].Source_Line_No == LineNo))
                {
                    ret+= Rlinearray[i].Quantity;
                }
            }
            return ret;
        }
        private void GoToUpdateProcess(WhseLineQH.WhseLineQH[] Rlinearray)
        {
            try
            {
                txtScanItemNo.Items.Clear();
                comboarray.Clear();
                comboAssigned.Clear();
                tempkey = Rlinearray[0].No;

                QH_Functions.QH_Functions qhfun = new QHMobile.QH_Functions.QH_Functions();
                qhfun.Url = WebServiceInstants.GetURL(ServiceType.QH_Functions);
                qhfun.Credentials = nc;
                qhfun.CombineInvtPutAway(Rlinearray[0].Source_No);


                WhseLineQH.WhseLineQH_Service whserv = new QHMobile.WhseLineQH.WhseLineQH_Service();
                whserv.Url = WebServiceInstants.GetURL(ServiceType.WhseLineQH);
                whserv.Credentials = nc;

                List<WhseLineQH.WhseLineQH_Filter> filter = new List<QHMobile.WhseLineQH.WhseLineQH_Filter>();

                WhseLineQH.WhseLineQH_Filter filtersource = new QHMobile.WhseLineQH.WhseLineQH_Filter();
                filtersource.Field = QHMobile.WhseLineQH.WhseLineQH_Fields.Source_No;
                filtersource.Criteria = Rlinearray[0].Source_No.ToString();
                filter.Add(filtersource);

                WhseLineQH.WhseLineQH_Filter filterLoc = new QHMobile.WhseLineQH.WhseLineQH_Filter();
                filterLoc.Field = QHMobile.WhseLineQH.WhseLineQH_Fields.Location_Code;
                filterLoc.Criteria = Rlinearray[0].Location_Code.ToString();
                filter.Add(filterLoc);


                WhseLineQH.WhseLineQH[] linearray = whserv.ReadMultiple(filter.ToArray(), null, 0);




                for (int i = 0; i < linearray.Length; i++)
                {
                    if (linearray[i].Bin_Code == null)
                    {
                        comboarray.Add(new AddValue(linearray[i].Item_No, linearray[i].Line_No));
                        if (comboarray.Count == 1)
                        {
                            tempshowqty = linearray[i].Quantity;
                        }
                    }
                    else
                    {
                        comboAssigned.Add(new AddValue(linearray[i].Item_No, linearray[i].Line_No));
                    }
                }
                //test
                //for (int i = 0; i < linearray.Length; i++)
                //{
                //    if (linearray[i].Quantity != linearray[i].Qty_to_Handle)
                //    {
                //        postflag = true;
                //    }
                //}
                postflag = true; //DD578
                //test


                if (comboarray.Count != 0)
                {
                    this.txtScanItemNo.DataSource = comboarray;
                    this.txtScanItemNo.DisplayMember = "Display";
                    this.txtScanItemNo.ValueMember = "Value";

                    //if (comboAssigned.Count != 0)
                    //{
                    //    this.cboAssignedItems.DataSource = comboAssigned;
                    //    this.cboAssignedItems.DisplayMember = "Display";
                    //    this.cboAssignedItems.ValueMember = "Value";
                    //}

                    lblTotalQty.Text = "Total Qty is of this item: " + tempshowqty;

                    for (int i = 0; i < linearray.Length; i++)
                    {
                        if (linearray[i].Quantity != linearray[i].Qty_to_Handle)
                        {
                            postflag = true;
                        }
                    }

                    UpdateProcess();
                }
                else
                {
                    if (postflag == false)
                    {
                        MnuPost.Enabled = false;
                    }
                    else
                    {
                        MnuPost.Enabled = true;
                    }

                    MessageBox.Show("There is nothing to assign!");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void UpdateProcess()
        {
          
            PutAlwaysLinesQH.PutAlwaysLinesQH_Service lineservice = new PutAlwaysLinesQH_Service();
            lineservice.Url = WebServiceInstants.GetURL(ServiceType.PutAlwaysLinesQH);
            lineservice.Credentials = nc;
            //string tempactivity = PutAlwaysLinesQH.Activity_Type.Invt_Put_away.ToString();

            List<PutAlwaysLinesQH.PutAlwaysLinesQH_Filter> filterArray = new List<PutAlwaysLinesQH_Filter>();

            PutAlwaysLinesQH.PutAlwaysLinesQH_Filter fitlerNumber = new PutAlwaysLinesQH_Filter();
            fitlerNumber.Field = PutAlwaysLinesQH_Fields.Source_No;
            fitlerNumber.Criteria = txtPO.Text.Trim();
            filterArray.Add(fitlerNumber);

            PutAlwaysLinesQH.PutAlwaysLinesQH_Filter fitlerLoc = new PutAlwaysLinesQH_Filter();
            fitlerLoc.Field = PutAlwaysLinesQH_Fields.Location_Code;
            fitlerLoc.Criteria = txtlocation.Text.Trim();
            filterArray.Add(fitlerLoc);

            PutAlwaysLinesQH.PutAlwaysLinesQH[] forCombo = lineservice.ReadMultiple(filterArray.ToArray(), null, 0);

            txtlocation.Text = forCombo[0].Location_Code;

            for (int i = 0; i < forCombo.Length; i++)
            {
                Object[] array = new Object[5];
                QHMobile.POModule po = new POModule();

                // txtScanItemNo.Items.Add(forCombo[i].Item_No);

                po.itemNo = forCombo[i].Item_No;
                array[0] = forCombo[i].Line_No;
                po.lineno = forCombo[i].Line_No;
                array[1] = forCombo[i].Item_No;
                po.description = forCombo[i].Description;
                array[2] = forCombo[i].Description;
                po.location = forCombo[i].Location_Code;
                array[3] = forCombo[i].Quantity;
                po.quantity = forCombo[i].Quantity;
                array[4] = forCombo[i].Location_Code;
                po.Sourcelineno = forCombo[i].Source_Line_No;

                dtSo.Rows.Add(array);
                pomod.Add(po);

              }
            GrdPoLines.DataSource = dtSo;
            Cursor.Current = Cursors.Default;

        }

        private bool GetAllSavedRecords(string p)
        {
            CompactSQL comsql = new CompactSQL();
            getallrecords = comsql.SelectRecordPOAssign("POAssign",p);

            if (getallrecords != null)
            {
                while (getallrecords.Read())
                {
                    Object[] array = new Object[6];
                    POModule poline = new POModule();

                    array[0] = getallrecords["LineNo"].ToString();
                    poline.lineno = Convert.ToInt32(getallrecords["LineNo"].ToString());
                    array[1] = getallrecords["itemNo"].ToString();
                    poline.itemNo = getallrecords["itemNo"].ToString();
                    array[2] = getallrecords["Description"].ToString();
                    poline.description = getallrecords["Description"].ToString();

                    array[3] = getallrecords["Quantity"].ToString();
                    poline.quantity = Convert.ToInt32(getallrecords["Quantity"].ToString());
                    //pomod[i].quantity = pomod[i].quantity - Convert.ToInt32(txtqty.Text.Trim());
                    //lblTotalQty.Text = "Total Qty of this item is : " + pomod[i].quantity;

                    array[4] = getallrecords["Location"].ToString();
                    poline.location = getallrecords["Location"].ToString();
                    array[5] = getallrecords["BinCode"].ToString();
                    poline.bin = getallrecords["BinCode"].ToString();

                    arraypo.Add(poline);
                    dt.Rows.Add(array);

                }

                GrdTO.DataSource = dt;
                MessageBox.Show("There are some lines saved into PDA in previous action.");
                return true; 
            }
            else
            {
                return false;
            }

        }

        private void menuItem2_Click(object sender, EventArgs e)
        {
            int count = GetNoOfSelectedRows(GrdTO);

            if (count == 0 || count == null)
            {
                MessageBox.Show("Please select the record first!");
            }
            else
            {
                for (int i = 0; i < count; i++)
                {
                    deleteSelectedRows(GrdTO);
                }
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
            if (dt.Rows.Count > 0)
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    if ((dt.Rows[i][0].ToString() == GrdTO[GrdTO.CurrentCell.RowNumber, 0].ToString()) &&
                        (dt.Rows[i][1].ToString() == GrdTO[GrdTO.CurrentCell.RowNumber, 1].ToString()) &&
                        (dt.Rows[i][3].ToString() == GrdTO[GrdTO.CurrentCell.RowNumber, 3].ToString()) &&
                        !isFound)
                    {
                        for (int pp = 0; pp < pomod.Count; pp++)
                        {

                            //if (arraypo[pp].itemNo.Equals(pomod[pp].itemNo))
                            if (GrdTO[GrdTO.CurrentCell.RowNumber, 1].Equals(pomod[pp].itemNo))
                            {
                                pomod[pp].quantity = pomod[pp].quantity + Convert.ToInt32(GrdTO[GrdTO.CurrentCell.RowNumber, 3]);
                                if (pomod[pp].itemNo.Equals(txtScanItemNo.Text.Trim()))
                                {
                                    //txtScanItemNo.Text.Trim().Equals(pomod[i].itemNo)
                                    lblTotalQty.Text = "Total Qty is of this item: " + pomod[pp].quantity;
                                }
                            }

                        }
                        dt.Rows.RemoveAt(i);
                        arraypo.RemoveAt(i);
                        isFound = true;
                    }
                }

            }
        }

        private int GetNoOfSelectedRows(DataGrid GrdTO)
        {
            int count = 0;
            try
            {
                if (GrdTO.DataSource != null)
                {
                    CurrencyManager cm = (CurrencyManager)this.BindingContext[GrdTO.DataSource];

                    DataView dv = (DataView)cm.List;

                    for (int i = 0; i < dv.Count; ++i)
                    {

                        if (GrdTO.IsSelected(i))
                        {
                            count++;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Please select the record first!" + ex);
            }

            return count;
        }

        private void txtScanItemNo_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                Cursor.Current = Cursors.WaitCursor;
                
                //decimal total = 0;
                //GetBinByItemNo(txtScanItemNo.SelectedItem.ToString());

                //ComboBoxItem typeItem = (ComboBoxItem)cboType.SelectedItem;
                //string value = typeItem.Content.ToString();

                //string aaa = txtScanItemNo.SelectedItem.ToString();
                //string val = txtScanItemNo.SelectedValue.ToString();
                //string bbb = ((AddValue)(txtScanItemNo.SelectedValue)).Display;

                if (txtScanItemNo.Items.Count > 0)
                {
                    AddValue SelItemValue = (AddValue)txtScanItemNo.SelectedItem;
                    string strItemNo = SelItemValue.Display;

                    ItemQH.ItemQH_Service itemsev = new QHMobile.ItemQH.ItemQH_Service();
                    itemsev.Url = WebServiceInstants.GetURL(ServiceType.ItemQH);
                    itemsev.Credentials = nc;
                    ItemQH.ItemQH itemdescription = itemsev.Read(strItemNo);
                    if (itemdescription != null)
                    {
                        //txtDescription.Text = itemdescription.Description;
                        lblDescription.Text = itemdescription.Description;
                    }
                }


                GetEmptyBin(txtScanItemNo.SelectedValue.ToString(), txtlocation.Text.ToString().Trim());
                //GetEmptyBin(txtScanItemNo.SelectedValue.ToString(), txtlocation.Text.ToString().Trim());
                
                for (int j = 0; j < pomod.Count; j++)
                {
                    //AddValue ad = (AddValue)txtScanItemNo.SelectedValue;

                    //string aa = txtScanItemNo.SelectedValue.ToString();
                    if (txtScanItemNo.SelectedValue.ToString().Equals(pomod[j].lineno.ToString()))
                    {
                        if (pomod[j].quantity == 0)
                        {
                            MessageBox.Show("There is no more quantity to assign!");
                            lblTotalQty.Text = "Total Qty is of this item: " + pomod[j].quantity;
                        }
                        else
                        {
                            string drptVal = txtScanItemNo.SelectedValue.ToString();

                            if (binarray.Count==0)
                            {
                                MessageBox.Show("No Suggest Empty Bin");
                            }
                            else
                            {
                                txtbin.Text = binarray[0].ToString();
                            }

                            if (drptVal.Equals(pomod[j].lineno.ToString()))
                            {

                                lblTotalQty.Text = "Total Qty is of this item: " + pomod[j].quantity;
                                txtqty.Text = "";
                                txtqty.Focus();
                            }


                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            Cursor.Current = Cursors.Default;

        }

        public void postInventory()
        {
            QH_Functions.QH_Functions qhfun = new QHMobile.QH_Functions.QH_Functions();
            qhfun.Credentials = nc;
            qhfun.Url = WebServiceInstants.GetURL(ServiceType.QH_Functions);
            qhfun.PostReceiveInventoryPutAway(pukno);
        }

       

        private void tbMain_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {

                if (tbMain.SelectedIndex == 2)
                {
                    int count = GetNoOfSelectedRows(GrdTO);

                    if (count == 0 || count == null)
                    {
                        MessageBox.Show("Please select the record first!");
                    }
                    else
                    {
                        for (int i = 0; i < count; i++)
                        {
                            UpdateSelectedRows(GrdTO);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Pls select the record first" + ex);
            }
        }

        private ArrayList UpdateSelectedRows(DataGrid GrdTO)
        {
            txtEditItemNo.Text = "";
            txtEditQty.Text = "";
            txtEditBinCode.Text = "";
            txtEditLocation.Text = "";
            ArrayList al = new ArrayList();
            CurrencyManager cm = (CurrencyManager)this.BindingContext[GrdTO.DataSource];
            DataView dv = (DataView)cm.List;
            bool isFound = false;
            lblStaffCode.Text = staffdimen;
            lblRole.Text = stafflevel;
            for (int i = 0; i < dv.Count && !isFound; ++i)
            {
                if (GrdTO.IsSelected(i))
                {
                    txtEditItemNo.Text = arraypo[i].itemNo;
                    txtEditQty.Text = arraypo[i].quantity.ToString();
                    txtEditBinCode.Text = arraypo[i].bin;
                    txtEditLocation.Text = arraypo[i].location;
                    updatnumber = i;
                    //isFound = true;
                }
            }
                return al;
        }
        private bool CheckAssigedUpdatedQty()
        {
            bool ret = true;
            decimal totalAssignedQty = 0;
            for (int jj = 0; jj < arraypo.Count; jj++)
            {

                if (arraypo[jj].lineno == arraypo[updatnumber].lineno)
                {
                  if ((arraypo[updatnumber].Sourcelineno.ToString().Equals(arraypo[jj].Sourcelineno.ToString())) &&
                    (arraypo[updatnumber].itemNo.ToString().Equals(arraypo[jj].itemNo.ToString())) &&
                    (arraypo[updatnumber].bin.ToString().Equals(arraypo[jj].bin.ToString())) &&
                    (arraypo[updatnumber].location.ToString().Equals(arraypo[jj].location.ToString())))
                    {
                    totalAssignedQty +=  Convert.ToDecimal(txtEditQty.Text);
                    }
                    else
                    {
                        totalAssignedQty +=  arraypo[jj].quantity;
                    }
                }
            }



            decimal dToAssignQty = 0;
            WhseLineQH.WhseLineQH_Service wseActLine = new QHMobile.WhseLineQH.WhseLineQH_Service();
            wseActLine.Url = WebServiceInstants.GetURL(ServiceType.WhseLineQH);
            wseActLine.Credentials = nc;

            List<WhseLineQH.WhseLineQH_Filter> filterArray = new List<QHMobile.WhseLineQH.WhseLineQH_Filter>();

            WhseLineQH.WhseLineQH_Filter filterPuCode = new QHMobile.WhseLineQH.WhseLineQH_Filter();
            filterPuCode.Field = QHMobile.WhseLineQH.WhseLineQH_Fields.No;
            filterPuCode.Criteria = tempkey;
            filterArray.Add(filterPuCode);

            WhseLineQH.WhseLineQH_Filter filterBinCode = new QHMobile.WhseLineQH.WhseLineQH_Filter();
            filterBinCode.Field = QHMobile.WhseLineQH.WhseLineQH_Fields.Bin_Code;
            filterBinCode.Criteria = "";
            filterArray.Add(filterBinCode);

            WhseLineQH.WhseLineQH[] lPutAwayList = wseActLine.ReadMultiple(filterArray.ToArray(), null, 0);
            if (lPutAwayList.Length != 0)
            {
                for (int i = 0; i < lPutAwayList.Length; i++)
                {
                    if ((arraypo[updatnumber].Sourcelineno.ToString().Equals(lPutAwayList[i].Source_Line_No.ToString())) &&
                   (arraypo[updatnumber].itemNo.ToString().Equals(lPutAwayList[i].Item_No.ToString())))
                    {
                        dToAssignQty = Convert.ToDecimal(lPutAwayList[i].Quantity);
                    }

                }
            }
            if (dToAssignQty <= totalAssignedQty)
            {
                ret = false;
            }




            return ret;

        }
        public static bool IsItNumber(string inputvalue)
        {
            Regex isnumber = new Regex("[^0-9]");
            return !isnumber.IsMatch(inputvalue);
        }
        private void btnSaveUpdate_Click(object sender, EventArgs e)
        {
            bool flagdifference;
            decimal differentNumber;
            bool isNum = IsItNumber(txtEditQty.Text.Trim());
            if (!isNum)
            {
                MessageBox.Show("Invalid Qty Number!");
                txtEditQty.Text = "";
                txtEditQty.Focus();
                return;
            }

            if (CheckAssigedUpdatedQty())
            {
                arraypo[updatnumber].bin = txtEditBinCode.Text;
                if (arraypo[updatnumber].quantity < Convert.ToDecimal(txtEditQty.Text))
                {
                    differentNumber = Convert.ToDecimal(txtEditQty.Text) - arraypo[updatnumber].quantity;
                    flagdifference = false;
                }
                else
                {
                    differentNumber = arraypo[updatnumber].quantity - Convert.ToDecimal(txtEditQty.Text);
                    flagdifference = true;
                }

                arraypo[updatnumber].quantity = Convert.ToDecimal(txtEditQty.Text);
                GrdTO.DataSource = null;
                dt.Clear();
                for (int j = 0; j < arraypo.Count; j++)
                {
                    Object[] array = new Object[6];
                    //  POModule poline = new POModule();
                    array[0] = arraypo[j].lineno;
                    array[1] = arraypo[j].itemNo;
                    array[2] = arraypo[j].description;
                    array[3] = arraypo[j].quantity;
                    array[4] = arraypo[j].location;
                    array[5] = arraypo[j].bin;
                    //lblTotalQty.Text = "Total Qty is of this item: " + pomod[j].quantity;
                    //  arraypo.Add(poline);
                    dt.Rows.Add(array);
                }

                for (int i = 0; i < pomod.Count; i++)
                {
                    if (arraypo[updatnumber].itemNo.Equals(pomod[i].itemNo))
                    {
                        if (flagdifference == false)
                        {
                            pomod[i].quantity = pomod[i].quantity - differentNumber;
                        }
                        else
                        {
                            pomod[i].quantity = pomod[i].quantity + differentNumber;
                        }
                        lblTotalQty.Text = "Total Qty is of this item: " + pomod[i].quantity;
                        //if (Convert.ToInt32(txtqty.Text.Trim()) > pomod[i].quantity || pomod[i].quantity <= 0)//pomod[i].quantity <= 0 )
                        //{
                        //    MessageBox.Show("No Enough Quantity!");
                        //}
                    }
                }

                GrdTO.DataSource = dt;
                MessageBox.Show("Updated Succesfully!");
            }
            else
            {
                MessageBox.Show("No Enough Quantity!");
            }
            
        }

        private int GetInvPutSplittedLastLineNo(int sourceLineNo,string strItemNo)
        {
            int ret = 0;
            WhseLineQH.WhseLineQH_Service wseActLine = new QHMobile.WhseLineQH.WhseLineQH_Service();
            wseActLine.Url = WebServiceInstants.GetURL(ServiceType.WhseLineQH);
            wseActLine.Credentials = nc;

            List<WhseLineQH.WhseLineQH_Filter> filterArray = new List<QHMobile.WhseLineQH.WhseLineQH_Filter>();

            WhseLineQH.WhseLineQH_Filter filterPuCode = new QHMobile.WhseLineQH.WhseLineQH_Filter();
            filterPuCode.Field = QHMobile.WhseLineQH.WhseLineQH_Fields.No;
            filterPuCode.Criteria = tempkey;
            filterArray.Add(filterPuCode);

            WhseLineQH.WhseLineQH_Filter filterSourceLineNo = new QHMobile.WhseLineQH.WhseLineQH_Filter();
            filterSourceLineNo.Field = QHMobile.WhseLineQH.WhseLineQH_Fields.Source_Line_No;
            filterSourceLineNo.Criteria = sourceLineNo.ToString();
            filterArray.Add(filterSourceLineNo);

            WhseLineQH.WhseLineQH_Filter filterItemNo = new QHMobile.WhseLineQH.WhseLineQH_Filter();
            filterItemNo.Field = QHMobile.WhseLineQH.WhseLineQH_Fields.Item_No;
            filterItemNo.Criteria = strItemNo;
            filterArray.Add(filterItemNo);

            WhseLineQH.WhseLineQH_Filter filterBinCode = new QHMobile.WhseLineQH.WhseLineQH_Filter();
            filterBinCode.Field = QHMobile.WhseLineQH.WhseLineQH_Fields.Bin_Code;
            filterBinCode.Criteria = "";
            filterArray.Add(filterBinCode);

            WhseLineQH.WhseLineQH[] lPutAwayList = wseActLine.ReadMultiple(filterArray.ToArray(), null, 0);
            if (lPutAwayList.Length != 0)
            {
                for (int i = 0; i < lPutAwayList.Length; i++)
                {
                    ret = lPutAwayList[i].Line_No;
                }
            }
            return ret;
        }
        private decimal GetInvPutSplittedLastLineQty(int sourceLineNo, string strItemNo)
        {
            decimal ret = 0;
            WhseLineQH.WhseLineQH_Service wseActLine = new QHMobile.WhseLineQH.WhseLineQH_Service();
            wseActLine.Url = WebServiceInstants.GetURL(ServiceType.WhseLineQH);
            wseActLine.Credentials = nc;

            List<WhseLineQH.WhseLineQH_Filter> filterArray = new List<QHMobile.WhseLineQH.WhseLineQH_Filter>();

            WhseLineQH.WhseLineQH_Filter filterPuCode = new QHMobile.WhseLineQH.WhseLineQH_Filter();
            filterPuCode.Field = QHMobile.WhseLineQH.WhseLineQH_Fields.No;
            filterPuCode.Criteria = tempkey;
            filterArray.Add(filterPuCode);

            WhseLineQH.WhseLineQH_Filter filterSourceLineNo = new QHMobile.WhseLineQH.WhseLineQH_Filter();
            filterSourceLineNo.Field = QHMobile.WhseLineQH.WhseLineQH_Fields.Source_Line_No;
            filterSourceLineNo.Criteria = sourceLineNo.ToString();
            filterArray.Add(filterSourceLineNo);

            WhseLineQH.WhseLineQH_Filter filterItemNo = new QHMobile.WhseLineQH.WhseLineQH_Filter();
            filterItemNo.Field = QHMobile.WhseLineQH.WhseLineQH_Fields.Item_No;
            filterItemNo.Criteria = strItemNo;
            filterArray.Add(filterItemNo);

            WhseLineQH.WhseLineQH_Filter filterBinCode = new QHMobile.WhseLineQH.WhseLineQH_Filter();
            filterBinCode.Field = QHMobile.WhseLineQH.WhseLineQH_Fields.Bin_Code;
            filterBinCode.Criteria = "";
            filterArray.Add(filterBinCode);

            WhseLineQH.WhseLineQH[] lPutAwayList = wseActLine.ReadMultiple(filterArray.ToArray(), null, 0);
            if (lPutAwayList.Length != 0)
            {
                for (int i = 0; i < lPutAwayList.Length; i++)
                {
                    ret = lPutAwayList[i].Quantity;
                }
            }
            return ret;
        }
        private void RegisterToInvPick()
        {
            Cursor.Current = Cursors.WaitCursor;
            try
            {
                for (int i = 0; i < pomod.Count; i++)
                {
                    WhseLineQH.WhseLineQH_Service wseActLine = new QHMobile.WhseLineQH.WhseLineQH_Service();
                    wseActLine.Url = WebServiceInstants.GetURL(ServiceType.WhseLineQH);
                    wseActLine.Credentials = nc;

                    List<WhseLineQH.WhseLineQH_Filter> filterArray = new List<QHMobile.WhseLineQH.WhseLineQH_Filter>();

                    WhseLineQH.WhseLineQH_Filter filterPuCode = new QHMobile.WhseLineQH.WhseLineQH_Filter();
                    filterPuCode.Field = QHMobile.WhseLineQH.WhseLineQH_Fields.No;
                    filterPuCode.Criteria = tempkey;

                    WhseLineQH.WhseLineQH_Filter filterItemNo = new QHMobile.WhseLineQH.WhseLineQH_Filter();
                    filterItemNo.Field = QHMobile.WhseLineQH.WhseLineQH_Fields.Source_Line_No;
                    filterItemNo.Criteria = pomod[i].lineno.ToString();

                    WhseLineQH.WhseLineQH_Filter filterBin = new QHMobile.WhseLineQH.WhseLineQH_Filter();
                    filterBin.Field = QHMobile.WhseLineQH.WhseLineQH_Fields.Bin_Code;
                    filterBin.Criteria = "=''";
                    filterArray.Add(filterBin);

                    filterArray.Add(filterPuCode);
                    filterArray.Add(filterItemNo);

                    WhseLineQH.WhseLineQH[] ActList = wseActLine.ReadMultiple(filterArray.ToArray(), null, 0);
                    if (ActList.Length != 0)
                    {
                        for (int ii = 0; ii < ActList.Length; ii++)
                        {
                            indivitualpo.Clear();
                            for (int j = 0; j < arraypo.Count; j++)
                            {
                                if (arraypo[j].lineno.Equals(ActList[ii].Line_No))
                                {
                                    POModule poinsert = new POModule();
                                    poinsert.itemNo = arraypo[i].itemNo;
                                    poinsert.lineno = arraypo[i].lineno;
                                    poinsert.quantity = arraypo[i].quantity;
                                    poinsert.location = arraypo[i].location;
                                    poinsert.bin = arraypo[i].bin;
                                    poinsert.description = arraypo[i].description;
                                    poinsert.Sourcelineno = arraypo[i].Sourcelineno;
                                    indivitualpo.Add(poinsert);
                                }
                            }//picked array
                            QH_Functions.QH_Functions qhfun = new QHMobile.QH_Functions.QH_Functions();
                            qhfun.Url = WebServiceInstants.GetURL(ServiceType.QH_Functions);
                            qhfun.Credentials = nc;
                            if (indivitualpo.Count > 1)
                            {
                                for (int sp = 0; sp < indivitualpo.Count; sp++)
                                {
                                    int InvPutAwayLastLineNo = GetInvPutSplittedLastLineNo(indivitualpo[sp].Sourcelineno, indivitualpo[sp].itemNo);
                                    decimal lastlineQty = GetInvPutSplittedLastLineQty(indivitualpo[sp].Sourcelineno, indivitualpo[sp].itemNo);
                                    if (InvPutAwayLastLineNo == indivitualpo[sp].lineno)   //first time split
                                    {
                                        if (lastlineQty >= indivitualpo[sp].quantity)
                                        {
                                            qhfun.CreatSplitLineWhs(tempkey, indivitualpo[sp].lineno, indivitualpo[sp].quantity, indivitualpo[sp].bin);
                                        }
                                    }
                                    else
                                    {
                                        if (lastlineQty == indivitualpo[sp].quantity)
                                        {
                                            WhseLineQH.WhseLineQH ActListupdate2 = wseActLine.Read(WhseLineQH.Activity_Type.Invt_Put_away.ToString(), tempkey, indivitualpo[sp].lineno);
                                            ActListupdate2.Bin_Code = indivitualpo[sp].bin;
                                            wseActLine.Update(ref ActListupdate2);
                                        }
                                        if (lastlineQty >= indivitualpo[sp].quantity)
                                        {
                                            qhfun.CreatSplitLineWhs(tempkey, InvPutAwayLastLineNo, indivitualpo[sp].quantity, indivitualpo[sp].bin);
                                        }
                                    }
                                }
                            }
                            if (indivitualpo.Count == 1)
                            {
                                WhseLineQH.WhseLineQH ActListupdate2 = wseActLine.Read(WhseLineQH.Activity_Type.Invt_Put_away.ToString(), tempkey, indivitualpo[0].lineno);
                                ActListupdate2.Bin_Code = indivitualpo[0].bin;
                                wseActLine.Update(ref ActListupdate2);
                            }
                        }//NAV pick array
                    }//check NAV pick by source line no
                }//org PO array

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void MnuRegister_Click(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
            try
            {
                if (arraypo.Count <= 0)
                {
                    MessageBox.Show("Nothing to Transfer");
                }
                else
                {
                    QH_Functions.QH_Functions qhfun = new QHMobile.QH_Functions.QH_Functions();
                    qhfun.Url = WebServiceInstants.GetURL(ServiceType.QH_Functions);
                    qhfun.Credentials = nc;
                    for (int p = 0; p < arraypo.Count; p++)
                    {
                        qhfun.CreatSplitLineWhs2(tempkey, arraypo[p].Sourcelineno, arraypo[p].quantity, arraypo[p].bin,staffdimen);
                    }
                    //ClearCache();

                    //arraypo.Clear();
                    //dt.Clear();
                    //dt.Rows.Clear();
                    //GrdTO.DataSource = null;
                    //txtPO.Enabled = false;
                    ////MnuRegister.Enabled = false;
                    //BindAssigned();


                    MessageBox.Show("Process is done!");
                    //this.Close();
                    //QHPO132473~VE0005~YUTAK~QH1

            //                    txtPO.Text = words[0];
            //strVendorNo = words[1];
            //strItem = words[2];
            //txtlocation.Text = words[3];
            string strPassNo = txtPO.Text.ToString() + "~" + strVendorNo + "~" + strItem + "~" + txtlocation.Text.ToString();


            POAssignBin frmpoassign = new POAssignBin(staffname, staffdimen, stafflevel, strPassNo, txtlocation.Text.ToString());
            frmpoassign.Show();


            //POAssignBin poassignBin = new POAssignBin();
            //poassignBin.Show();

                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            Cursor.Current = Cursors.Default;
            //Cursor.Current = Cursors.WaitCursor;
            //try
            //{
            //    for (int i = 0; i < pomod.Count; i++)
            //    {
            //        WhseLineQH.WhseLineQH_Service wseActLine = new QHMobile.WhseLineQH.WhseLineQH_Service();
            //        wseActLine.Url = WebServiceInstants.GetURL(ServiceType.WhseLineQH);
            //        wseActLine.Credentials = nc;

            //        List<WhseLineQH.WhseLineQH_Filter> filterArray = new List<QHMobile.WhseLineQH.WhseLineQH_Filter>();

            //        WhseLineQH.WhseLineQH_Filter filterPuCode = new QHMobile.WhseLineQH.WhseLineQH_Filter();
            //        filterPuCode.Field = QHMobile.WhseLineQH.WhseLineQH_Fields.No;
            //        filterPuCode.Criteria = tempkey;

            //        WhseLineQH.WhseLineQH_Filter filterItemNo = new QHMobile.WhseLineQH.WhseLineQH_Filter();
            //        filterItemNo.Field = QHMobile.WhseLineQH.WhseLineQH_Fields.Source_Line_No;
            //        filterItemNo.Criteria = pomod[i].lineno.ToString();

            //        WhseLineQH.WhseLineQH_Filter filterBin = new QHMobile.WhseLineQH.WhseLineQH_Filter();
            //        filterBin.Field = QHMobile.WhseLineQH.WhseLineQH_Fields.Bin_Code;
            //        filterBin.Criteria = "=''";
            //        filterArray.Add(filterBin);

            //        filterArray.Add(filterPuCode);
            //        filterArray.Add(filterItemNo);

            //        WhseLineQH.WhseLineQH[] ActList = wseActLine.ReadMultiple(filterArray.ToArray(), null, 0);
            //        int totalcount = 0;

            //        if (ActList.Length != 0)
            //        {
            //            for (int j = 0; j < arraypo.Count; j++)
            //            {
            //                if (arraypo[j].lineno.Equals(ActList[0].Line_No))
            //                {
            //                    totalcount = totalcount + 1;
            //                }

            //            }
            //            indivitualpo.Clear();
            //            if (totalcount >= ActList.Count())
            //            {
            //                for (int p = 0; p < arraypo.Count; p++)
            //                {
            //                    if (arraypo[p].lineno.Equals(ActList[0].Line_No))
            //                    {
            //                        POModule poinsert = new POModule();
            //                        poinsert.itemNo = arraypo[p].itemNo;
            //                        poinsert.lineno = arraypo[p].lineno;
            //                        poinsert.quantity = arraypo[p].quantity;
            //                        poinsert.location = arraypo[p].location;
            //                        poinsert.bin = arraypo[p].bin;
            //                        poinsert.description = arraypo[p].description;
            //                        poinsert.Sourcelineno = arraypo[p].Sourcelineno;
            //                        indivitualpo.Add(poinsert);
            //                    }
            //                }
                                                        
            //                QH_Functions.QH_Functions qhfun = new QHMobile.QH_Functions.QH_Functions();
            //                qhfun.Url = WebServiceInstants.GetURL(ServiceType.QH_Functions);
            //                qhfun.Credentials = nc;
            //                for (int k = 0; k < indivitualpo.Count; k++)
            //                {
            //                    //Get Inv put away splited last line.
            //                    int InvPutAwayLastLineNo = GetInvPutSplittedLastLineNo(indivitualpo[k].Sourcelineno, indivitualpo[k].itemNo);
            //                    if (InvPutAwayLastLineNo == 0)
            //                    {
            //                        WhseLineQH.WhseLineQH ActListupdate2 = wseActLine.Read(WhseLineQH.Activity_Type.Invt_Put_away.ToString(), tempkey, indivitualpo[k].lineno);
            //                        ActListupdate2.Bin_Code = indivitualpo[k].bin;
            //                        wseActLine.Update(ref ActListupdate2);
            //                    }

            //                    if (k == indivitualpo.Count - 1)// update Bin code on splitted line last record
            //                    {
            //                        decimal lastlineQty = GetInvPutSplittedLastLineQty(indivitualpo[k].Sourcelineno, indivitualpo[k].itemNo);
            //                        if (InvPutAwayLastLineNo == indivitualpo[k].lineno) //first time split
            //                        {
            //                            if (lastlineQty == indivitualpo[k].quantity)
            //                            {
            //                                WhseLineQH.WhseLineQH ActListupdate2 = wseActLine.Read(WhseLineQH.Activity_Type.Invt_Put_away.ToString(), tempkey, InvPutAwayLastLineNo);
            //                                ActListupdate2.Bin_Code = indivitualpo[k].bin;
            //                                wseActLine.Update(ref ActListupdate2);

            //                            }
            //                            else
            //                            {
            //                                qhfun.CreatSplitLineWhs(tempkey, indivitualpo[k].lineno, indivitualpo[k].quantity, indivitualpo[k].bin);
            //                            }
            //                        }
            //                        else
            //                        {
            //                            //// check for partial
            //                            //decimal dd = pomod[i].quantity;
                                        
            //                            if (lastlineQty > indivitualpo[k].quantity)
            //                            {
            //                                //qhfun.CreatSplitLineWhs(tempkey, indivitualpo[k].lineno, indivitualpo[k].quantity, indivitualpo[k].bin);
            //                                qhfun.CreatSplitLineWhs(tempkey, InvPutAwayLastLineNo, indivitualpo[k].quantity, indivitualpo[k].bin);

            //                            }
            //                            else
            //                            {
            //                                if (InvPutAwayLastLineNo != 0)
            //                                {
            //                                    WhseLineQH.WhseLineQH ActListupdate2 = wseActLine.Read(WhseLineQH.Activity_Type.Invt_Put_away.ToString(), tempkey, InvPutAwayLastLineNo);
            //                                    ActListupdate2.Bin_Code = indivitualpo[k].bin;
            //                                    wseActLine.Update(ref ActListupdate2);
            //                                }
            //                            }
            //                        }
            //                    }
            //                    else
            //                    {
            //                        if (InvPutAwayLastLineNo == indivitualpo[k].lineno) //first time split
            //                        {
            //                            qhfun.CreatSplitLineWhs(tempkey, indivitualpo[k].lineno, indivitualpo[k].quantity, indivitualpo[k].bin);
            //                        }
            //                        else //Get last splitted line
            //                        {
            //                            qhfun.CreatSplitLineWhs(tempkey, InvPutAwayLastLineNo, indivitualpo[k].quantity, indivitualpo[k].bin);
            //                        }
            //                    }
            //                    // not finished to assig the Bin
            //                }

            //            }
            //            //else
            //            //{
            //            //    MessageBox.Show("Nothing to update!");
            //            //}
            //        }
            //    }
            //    ClearCache();
            //    MessageBox.Show("Process is done!");
                



            // //   RebindToComboAssign();



            //}
            //catch (Exception ex)
            //{
            //    MessageBox.Show("Error:" + ex.Message);
            //}
            ////   postInventory();

            ////POAssignBin poa = new POAssignBin(staffname, staffdimen, stafflevel,txtTO.Text.Trim());
            ////poa.Show();
          
            //Cursor.Current = Cursors.Default;
        }

        private void ClearCache()
        {
            arraypo.Clear();
            dt.Clear();
            dt.Rows.Clear();
            GrdTO.DataSource = null;
            txtPO.Enabled = false;
            MnuRegister.Enabled = false;
            BindAssigned();
        }

        private void MnuPost_Click(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
            try
            {

                //PutAlwaysQH.PutAlwaysQH_Service putSev = new PutAlwaysQH_Service();
                //putSev.Credentials = nc;
                //putSev.Url = WebServiceInstants.GetURL(ServiceType.PutAlwaysQH);

                //List<PutAlwaysQH.PutAlwaysQH_Filter> putawayFitlerArray = new List<PutAlwaysQH.PutAlwaysQH_Filter>();

                //PutAlwaysQH.PutAlwaysQH_Filter filterSource = new PutAlwaysQH_Filter();
                //filterSource.Field = PutAlwaysQH_Fields.Source_No;
                //filterSource.Criteria = txtPO.Text.Trim();
                //putawayFitlerArray.Add(filterSource);

                //PutAlwaysQH.PutAlwaysQH[] phArray = putSev.ReadMultiple(putawayFitlerArray.ToArray(), null, 0);


            WhseLineQH.WhseLineQH_Service wseActLine = new QHMobile.WhseLineQH.WhseLineQH_Service();
            wseActLine.Url = WebServiceInstants.GetURL(ServiceType.WhseLineQH);
            wseActLine.Credentials = nc;

            List<WhseLineQH.WhseLineQH_Filter> filterArray = new List<QHMobile.WhseLineQH.WhseLineQH_Filter>();

            WhseLineQH.WhseLineQH_Filter filterPuCode = new QHMobile.WhseLineQH.WhseLineQH_Filter();
            filterPuCode.Field = QHMobile.WhseLineQH.WhseLineQH_Fields.Source_No;
            filterPuCode.Criteria = txtPO.Text.Trim();
            filterArray.Add(filterPuCode);


            WhseLineQH.WhseLineQH_Filter filterBinCode = new QHMobile.WhseLineQH.WhseLineQH_Filter();
            filterBinCode.Field = QHMobile.WhseLineQH.WhseLineQH_Fields.Bin_Code;
            filterBinCode.Criteria = "";
            filterArray.Add(filterBinCode);

            WhseLineQH.WhseLineQH[] lPutAwayList = wseActLine.ReadMultiple(filterArray.ToArray(), null, 0);
            if (lPutAwayList.Length != 0)
            {

                QH_Functions.QH_Functions qhfun = new QHMobile.QH_Functions.QH_Functions();
                qhfun.Credentials = nc;
                qhfun.Url = WebServiceInstants.GetURL(ServiceType.QH_Functions);
                //qhfun.PostReceiveInventoryPutAway(phArray[0].No);
                qhfun.PostReceiveInventoryPutAway(lPutAwayList[0].No);

                MessageBox.Show("Posted Successfully");
            }
            else
            {
                MessageBox.Show("Pick all the item before Posting");
            }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            Cursor.Current = Cursors.Default;
        }


        private void RebindToComboAssign()
        {
            //comboAssigned.Clear();
            //cboAssignedItems.DataSource = null;

            WhseLineQH.WhseLineQH_Service whserv = new QHMobile.WhseLineQH.WhseLineQH_Service();
            whserv.Url = WebServiceInstants.GetURL(ServiceType.WhseLineQH);
            whserv.Credentials = nc;

            List<WhseLineQH.WhseLineQH_Filter> filter = new List<QHMobile.WhseLineQH.WhseLineQH_Filter>();

            WhseLineQH.WhseLineQH_Filter filtersource = new QHMobile.WhseLineQH.WhseLineQH_Filter();
            filtersource.Field = QHMobile.WhseLineQH.WhseLineQH_Fields.Source_No;
            filtersource.Criteria = txtPO.Text.Trim();

            filter.Add(filtersource);

            WhseLineQH.WhseLineQH[] linearray = whserv.ReadMultiple(filter.ToArray(), null, 0);

            for (int i = 0; i < linearray.Length; i++)
            {
                if (linearray[i].Bin_Code != null)
                {
                    comboAssigned.Add(new AddValue(linearray[i].Item_No, linearray[i].Line_No));
                }
            }

            //if (comboAssigned.Count != 0)
            //{
            //    this.cboAssignedItems.DataSource = comboAssigned;
            //    this.cboAssignedItems.DisplayMember = "Display";
            //    this.cboAssignedItems.ValueMember = "Value";
            //}

        }

        private void POAssignBin_KeyDown(object sender, KeyEventArgs e)
        {
            if ((e.KeyCode == System.Windows.Forms.Keys.Up))
            {
                // Up
            }
            if ((e.KeyCode == System.Windows.Forms.Keys.Down))
            {
                // Down
            }
            if ((e.KeyCode == System.Windows.Forms.Keys.Left))
            {
                // Left
            }
            if ((e.KeyCode == System.Windows.Forms.Keys.Right))
            {
                // Right
            }
            if ((e.KeyCode == System.Windows.Forms.Keys.Enter))
            {
                // Enter
            }

        }

        private void mnutest_Click(object sender, EventArgs e)
        {
            try
            {
                QH_Functions.QH_Functions qhfun = new QHMobile.QH_Functions.QH_Functions();
                qhfun.Url = WebServiceInstants.GetURL(ServiceType.QH_Functions);
                qhfun.Credentials = nc;
                for (int p = 0; p < arraypo.Count; p++)
                {
                    qhfun.CreatSplitLineWhs2(tempkey, arraypo[p].Sourcelineno, arraypo[p].quantity, arraypo[p].bin, staffdimen);
                }
                ClearCache();
                MessageBox.Show("Process is done!");
                this.Close();
                POAssignBin frmpoassign = new POAssignBin(staffname, staffdimen, stafflevel,txtPO.Text.ToString(),txtlocation.Text.ToString());
                frmpoassign.Show();
                
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
       
    }
}

public class AddValue
{
    private string m_Display;
    private long m_Value;
    public AddValue(string Display, long Value)
    {
        m_Display = Display;
        m_Value = Value;
    }
    public string Display
    {
        get { return m_Display; }
    }
    public long Value
    {
        get { return m_Value; }
    }
}