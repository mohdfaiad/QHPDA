using System;
using System.Linq;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using QHMobile.TransferOrderQH;
using QHMobile.TransferOrderLineQH;
using System.Text.RegularExpressions;
using System.Collections;
using System.Xml;
using System.Reflection;
using System.IO;

namespace QHMobile
{
    public partial class CreateTO : Form
    {
        //protected System.Net.NetworkCredential nc = new System.Net.NetworkCredential(WebServiceInstants.GetURL(ServiceType.userName).ToString(), WebServiceInstants.GetURL(ServiceType.password).ToString(), WebServiceInstants.GetURL(ServiceType.domain).ToString());
        protected System.Net.NetworkCredential nc = new System.Net.NetworkCredential(WebServiceInstants.GetURL(ServiceType.userName).ToString(), WebServiceInstants.GetURL(ServiceType.password).ToString(), WebServiceInstants.GetURL(ServiceType.domain).ToString());
        DataTable dtTOModule = new DataTable("TO Module");
        DataTable dtpost = new DataTable("Post Module");
        List<TOModule> toList = new List<TOModule>();
        ArrayList toArray = new ArrayList();

        static string postSO;
        string tempto;
        string usng, staffdimg, uslvelg;
        bool ifexist;
        int lineCount;

        public CreateTO(string staffusname, string staffdimension,string stafflevel)
        {
            
            InitializeComponent();

            ClearCache();

            this.usng = staffusname;
            this.staffdimg = staffdimension;
            this.uslvelg = stafflevel;

            txtFromBin.Focus();
            dtTOModule.Columns.Add("Item NO");
            dtTOModule.Columns.Add("From Location");
            dtTOModule.Columns.Add("To Location");
            dtTOModule.Columns.Add("Quantity");
            dtTOModule.Columns.Add("From Bin");
            dtTOModule.Columns.Add("To Bin");
            dtTOModule.Columns.Add("Empty Bin");


            dtpost.Columns.Add("Item NO");
            dtpost.Columns.Add("Description");
            dtpost.Columns.Add("from_Bin_Code");
            dtpost.Columns.Add("To_Bin_Code");
            dtpost.Columns.Add("Quantity");


            string tonumber= ValidateTO();


            if (!tonumber.Equals("false"))
            {
                lblToNo.Text = tonumber;
            }
            else
            {
                lblToNo.Text = "";
            }

            if (stafflevel.Equals("Super"))
            {
                tapLineToPost.Show();
                Main.Show();

                MnuNewGRN.Enabled = true;
                mnuItmRegtoNav.Enabled = false;
                
                //mnuPost.Enabled = false;
                //lblTOPost.Focus();

            }
            else
            {
                tapLineToPost.Hide();
                Main.Show();
                MnuNewGRN.Enabled = true;
                mnuItmRegtoNav.Enabled = true;                
                //mnuPost.Enabled = false;
            }
            
            GetFromAndTo();
            
        }

        private void GetFromAndTo()
        {
            try
            {

                QH_Location.QH_Location_Service binsev = new QH_Location.QH_Location_Service();
                binsev.Url = WebServiceInstants.GetURL(ServiceType.QH_Location);
                binsev.Credentials = nc;

                QH_Location.QH_Location[] locationArray = binsev.ReadMultiple(null, null, 0);

                for (int i = 0; i < locationArray.Length; i++)
                {
                    cboFrom.Items.Add(locationArray[i].Code);
                    cboTO.Items.Add(locationArray[i].Code);

                }
                string d = DateTime.Today.Day.ToString();
                string m = DateTime.Today.Month.ToString();
                string y = DateTime.Now.Year.ToString().Substring(2, 2);

                string datestr = m + "/" + d + "/" + y;

                txtExpectDate.Text = datestr; //DateTime.Now.ToShortDateString();//.ToString("dd/MM/yy"); datestr
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void ClearCache()
        {
            toList.Clear();
            postSO = null;
            dtTOModule.Clear();
            dtpost.Clear();
            dgTOLine.DataSource = null;
            dtTOModule.Rows.Clear();
            dtpost.Rows.Clear();
            
        }

        private string ValidateTO()
        {
            TransferOrderQH.TransferOrderQH_Service toserv = new TransferOrderQH_Service();
            toserv.Url = WebServiceInstants.GetURL(ServiceType.TransferOrderQH);
            toserv.Credentials = nc;


            List<TransferOrderQH.TransferOrderQH_Filter> filterArray = new List<TransferOrderQH_Filter>();

            TransferOrderQH.TransferOrderQH_Filter postdate = new TransferOrderQH_Filter();
            postdate.Field = TransferOrderQH_Fields.Posting_Date;

            string d = DateTime.Today.Day.ToString();
            string m = DateTime.Today.Month.ToString();
            string y = DateTime.Now.Year.ToString().Substring(2, 2);

            string datestr = m + "/" + d + "/" + y;


            postdate.Criteria = datestr; //DateTime.Now.ToShortDateString(); 

            TransferOrderQH.TransferOrderQH_Filter pdaTo = new TransferOrderQH_Filter();
            pdaTo.Field = TransferOrderQH_Fields.PDAOrder;
            pdaTo.Criteria = "Yes";

            TransferOrderQH.TransferOrderQH_Filter pdaStatus = new TransferOrderQH_Filter();
            pdaStatus.Field = TransferOrderQH_Fields.Status;
            pdaStatus.Criteria = TransferOrderQH.Status.Open.ToString();

            filterArray.Add(postdate);
            filterArray.Add(pdaTo);
            filterArray.Add(pdaStatus);

            TransferOrderQH.TransferOrderQH[] transferOrder = toserv.ReadMultiple(filterArray.ToArray(), null, 0);

            if (transferOrder.Length != 0)
            {
                return transferOrder[0].No;
            }
            else
            {
                string fal = "false";
                return fal;
            }
        }

        private void BindPostLines()
        {

            MessageBox.Show("Pending to discuss");

        }

        private void txtTOScan_KeyDown(object sender, KeyEventArgs e)
        {

           

        }

        private void btnAdd_Click(object sender, EventArgs e)
        {

            Cursor.Current = Cursors.WaitCursor;
            try
            {

                if (string.IsNullOrEmpty(txtFromBin.Text.Trim()) || string.IsNullOrEmpty(txtTobin.Text.Trim()) || string.IsNullOrEmpty(txtLocToCode.Text.Trim()) || string.IsNullOrEmpty(lblInfoLocation.Text.Trim()) || string.IsNullOrEmpty(txtItemNo.Text.Trim()) || string.IsNullOrEmpty(txtQty.Text.Trim()) || string.IsNullOrEmpty(lblStaffName.Text.Trim()))
                {
                    MessageBox.Show("Must fill all the fields first!");
                }
                else
                {
                    bool isNum = IsItNumber(txtQty.Text.Trim());

                    bool isItem = IsItemNumber(txtItemNo.Text.Trim()); // new coded line 

                    if (isNum && isItem)
                    {

                        
                        TOModule toInsert = new TOModule();

                        Object[] array = new Object[7];

                        toInsert.ItemNo = txtItemNo.Text.Trim();
                        array[0] = txtItemNo.Text.Trim();

                        toInsert.froomLoc = lblInfoLocation.Text.Trim();
                        array[1] = lblInfoLocation.Text.Trim();
                        toInsert.toLoc = txtLocToCode.Text.Trim();
                        array[2] = txtLocToCode.Text.Trim();

                        toInsert.qty = txtQty.Text.Trim();
                        array[3] = txtQty.Text.Trim();

                        toInsert.frombin = txtFromBin.Text.Trim();
                        array[4] = txtFromBin.Text.Trim();
                        toInsert.tobin = txtTobin.Text.Trim();
                        array[5] = txtTobin.Text.Trim();

                        if (chkEmpty.Checked)
                        {
                            toInsert.emptyBin = true;
                            array[6] = true;
                        }
                        else
                        {
                            toInsert.emptyBin = false;
                            array[6] = false;
                        }

                        dtTOModule.Rows.Add(array);

                        lblCount.Text = dtTOModule.Rows.Count.ToString();

                        BindGrid();

                        EnableComponent(dtTOModule,"Register");

                        toList.Add(toInsert);

                        txtFromBin.Text = "";
                        //txtTobin.Text = "";
                        //txtLocToCode.Text = "";
                        txtItemNo.Text = "";
                        txtQty.Text = "";
                        lblInfoLocation.Text = "";
                        chkEmpty.Checked = false;
                        txtFromBin.Focus();
                        //}
                    }
                    else
                    {
                        if (isItem == false)
                        {
                            MessageBox.Show("Invalid Item!");
                        }
                        else
                        {
                            MessageBox.Show("Qty value must be integer.");
                        }
                        txtQty.Text = "";
                        txtQty.Focus();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            Cursor.Current = Cursors.Default;
        }

        private void EnableComponent(DataTable dtTOModule, string p)
        {
            if (p.Equals("Register"))
            {
                if (dtTOModule.Rows.Count != 0)
                {
                    mnuItmRegtoNav.Enabled = true;
                }
            }
          
            

        }

        private bool IsItemNumber(string p)
        {
            ItemQH.ItemQH_Service itemSev = new QHMobile.ItemQH.ItemQH_Service();
            itemSev.Url = WebServiceInstants.GetURL(ServiceType.ItemQH);
            itemSev.Credentials = nc;

            ItemQH.ItemQH getitem = itemSev.Read(p);

            if (getitem != null)
            {
                return true;
            }
            else
            {
                return false; 
            }

        }

        private int CheckAvailableTO()
        {

            return 1;
        }


        public static bool IsItNumber(string inputvalue)
        {
            Regex isnumber = new Regex("[^0-9]");
            return !isnumber.IsMatch(inputvalue);
        }


        private Boolean GetToLocationValidation()
        {
        
            BinQH.BinQH_Service binSev= new QHMobile.BinQH.BinQH_Service();
            binSev.Url = WebServiceInstants.GetURL(ServiceType.BinQH);
            binSev.Credentials = nc;

            BinQH.BinQH qhBin = binSev.Read(txtLocToCode.Text.Trim(), txtTobin.Text.Trim());


            if (qhBin != null)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        private int GetFromLocationValidation()
        {

            BinQH.BinQH_Service binserv = new QHMobile.BinQH.BinQH_Service();
            binserv.Url = WebServiceInstants.GetURL(ServiceType.BinQH);
            binserv.Credentials = nc;

            List<BinQH.BinQH_Filter> binFilArray = new List<QHMobile.BinQH.BinQH_Filter>();
            
            BinQH.BinQH_Filter binFilter = new QHMobile.BinQH.BinQH_Filter();
            binFilter.Field = QHMobile.BinQH.BinQH_Fields.Code;
            //binFilter.Criteria = txtFromBin.Text.Trim();

            if (string.IsNullOrEmpty(txtFromBin.Text.Trim()))
            {
                binFilter.Criteria = "''";
            }
            else
            {
                binFilter.Criteria = txtFromBin.Text.Trim();
            }

            binFilArray.Add(binFilter);

            BinQH.BinQH[] binbl = binserv.ReadMultiple(binFilArray.ToArray(), null, 3);


            if (binbl.Length == 0)
            {
                return 0;
            }
            else
            {
                if(binbl[0].Block_Movement == QHMobile.BinQH.Block_Movement.All)
                {
                    return 1;
                }
                else
                {
                    //if (binbl[0].Empty == true)
                    //{
                    //    return 2;
                    //}
                    //else
                    //{
                        QHBinContent.QHBinContent_Service qhBinContSev = new QHMobile.QHBinContent.QHBinContent_Service();
                        qhBinContSev.Url = WebServiceInstants.GetURL(ServiceType.QHBinContent);
                        qhBinContSev.Credentials = nc;

                        List<QHBinContent.QHBinContent_Filter> filterarray = new List<QHMobile.QHBinContent.QHBinContent_Filter>();

                        QHBinContent.QHBinContent_Filter qtyfitler = new QHMobile.QHBinContent.QHBinContent_Filter();
                        qtyfitler.Field = QHMobile.QHBinContent.QHBinContent_Fields.Unit_of_Measure_Code;
                        qtyfitler.Criteria = "<>''";

                        QHBinContent.QHBinContent_Filter filterQty = new QHMobile.QHBinContent.QHBinContent_Filter();
                        filterQty.Field = QHMobile.QHBinContent.QHBinContent_Fields.Quantity;
                        filterQty.Criteria = ">0";

                        QHBinContent.QHBinContent_Filter filterbincode = new QHMobile.QHBinContent.QHBinContent_Filter();
                        filterbincode.Field = QHMobile.QHBinContent.QHBinContent_Fields.Bin_Code;
                        filterbincode.Criteria = txtFromBin.Text.Trim();

                        QHBinContent.QHBinContent_Filter filterloc = new QHMobile.QHBinContent.QHBinContent_Filter();
                        filterloc.Field = QHMobile.QHBinContent.QHBinContent_Fields.Location_Code;
                        filterloc.Criteria = binbl[0].Location_Code;

                        filterarray.Add(qtyfitler);
                        filterarray.Add(filterbincode);
                        filterarray.Add(filterloc);
                        filterarray.Add(filterQty);

                        QHBinContent.QHBinContent[] qhBinContent = qhBinContSev.ReadMultiple(filterarray.ToArray(), null, 0);

                        if (qhBinContent.Length == 0)
                        {
                            return 3;
                            
                        }
                        else
                        {
                            txtItemNo.Text = qhBinContent[0].Item_No;
                            decimal avalQty = qhBinContent[0].Quantity - qhBinContent[0].PDA_Inv_Pick_Quantity ;
                            txtQty.Text = avalQty.ToString();
                            lblInfoLocation.Text = qhBinContent[0].Location_Code;
                            return 4;
                            
                        }                    
                }
             }            
           
        }

        private void BindGrid()
        {
            dgTOLine.DataSource = dtTOModule;
        }

        private void mnuItmRegtoNav_Click(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
            string strPDAName;
            strPDAName = GetPDANamefromConfig();
            try
            {
                
                bool flagtemp = false;
                string itemtemp;
                string locationtemp;
                string bincodetemp;
                string tolocationtemp;

               

                string tonumber="";

                TransferOrderQH.TransferOrderQH_Service toservice = new TransferOrderQH_Service();
                toservice.Url = WebServiceInstants.GetURL(ServiceType.TransferOrderQH);
                toservice.Credentials = nc;

                QH_Functions.QH_Functions qhfun = new QHMobile.QH_Functions.QH_Functions();
                qhfun.Url= WebServiceInstants.GetURL(ServiceType.QH_Functions);
                qhfun.Credentials = nc; 

                List<TransferOrderQH_Filter> filterarray = new List<TransferOrderQH_Filter>();

                if (dgTOLine.DataSource == null)
                {
                    MessageBox.Show("There is no record to register!");
                }
                else
                {
                    

                    for (int i = 0; i < toList.Count; i++)
                    {
                        TransferOrderQH.TransferOrderQH_Filter filterfrom = new TransferOrderQH_Filter();
                        filterfrom.Field = TransferOrderQH_Fields.Transfer_from_Code;
                        filterfrom.Criteria = toList[i].frombin;

                        TransferOrderQH.TransferOrderQH_Filter filterTO = new TransferOrderQH_Filter();
                        filterTO.Field = TransferOrderQH_Fields.Transfer_to_Code;
                        filterTO.Criteria = toList[i].tobin;

                        TransferOrderQH.TransferOrderQH_Filter filterDate = new TransferOrderQH_Filter();
                        filterDate.Field = TransferOrderQH_Fields.Posting_Date;

                        string d = DateTime.Today.Day.ToString();
                        string m = DateTime.Today.Month.ToString();
                        string y = DateTime.Now.Year.ToString().Substring(2, 2);

                        string datestr = m + "/" + d + "/" + y;

                        filterDate.Criteria = datestr; //DateTime.Today.ToShortDateString();//DateTime.Today.ToShortDateString();
                        
                        TransferOrderQH.TransferOrderQH_Filter filterOrderPDA = new TransferOrderQH_Filter();
                        filterOrderPDA.Field = TransferOrderQH_Fields.PDAOrder;
                        filterOrderPDA.Criteria = "Yes";

                        filterarray.Add(filterfrom);
                        filterarray.Add(filterTO);
                        filterarray.Add(filterDate);
                        filterarray.Add(filterOrderPDA);

                        TransferOrderQH.TransferOrderQH[] toarray = toservice.ReadMultiple(filterarray.ToArray(), null, 5);                        

                        if (toarray.Length != 0)
                        {
                            Boolean oktoinsert;
                            tonumber = toarray[0].No;
                            //for (int l = 0; l < toarray[0].TransferLines.Count(); l++)
                            //{
                            //    if (toarray[0].TransferLines[l].Item_No.Equals(toList[i].ItemNo.Trim()) && toarray[0].TransferLines[l].Transfer_from_Bin_Code.Equals(toList[i].frombin.Trim()) && toarray[0].TransferLines[l].Transfer_To_Bin_Code.Equals(toList[i].tobin.Trim()) && toarray[0].TransferLines[l].Quantity == Convert.ToDecimal(toList[i].qty.Trim()))
                            //    {
                            //        oktoinsert = false;
                            //    }
                            //}

                            oktoinsert = qhfun.CheckDuplicateTOLines(toarray[0].No, toList[i].froomLoc, toList[i].toLoc, toList[i].frombin, toList[i].tobin, toList[i].ItemNo, Convert.ToDecimal(toList[i].qty));

                            if (oktoinsert == false)
                            {
                                int linecount = toarray[0].TransferLines.Count();

                                toarray[0].TransferLines = new Transfer_Order_Line[1];
                                toarray[0].TransferLines[0] = new Transfer_Order_Line();

                                toservice.UpdateMultiple(ref toarray);

                                toarray[0].TransferLines[linecount].Item_No = toList[i].ItemNo;
                                toarray[0].TransferLines[linecount].Quantity = Convert.ToInt32(toList[i].qty);
                                toarray[0].TransferLines[linecount].Transfer_from_Bin_Code = toList[i].frombin;
                                toarray[0].TransferLines[linecount].Transfer_To_Bin_Code = toList[i].tobin;
                                toarray[0].TransferLines[linecount].Staff_Dimension = staffdimg;

                                toservice.UpdateMultiple(ref toarray);
                            }
                        }
                        else
                        {
                            TransferOrderQH.TransferOrderQH toqhcreate = new QHMobile.TransferOrderQH.TransferOrderQH();
                            toservice.Create(ref toqhcreate);

                            //TransferOrderQH.TransferOrderQH toupdate = toservice.Read(toqhcreate.No);

                            List<TransferOrderQH.TransferOrderQH_Filter> FilterA = new List<TransferOrderQH_Filter>();

                            TransferOrderQH.TransferOrderQH_Filter filterNo = new TransferOrderQH_Filter();
                            filterNo.Field = TransferOrderQH_Fields.No;
                            filterNo.Criteria = toqhcreate.No.ToString();
                            tonumber= toqhcreate.No;

                            FilterA.Add(filterNo);

                            TransferOrderQH.TransferOrderQH[] toupdate = toservice.ReadMultiple(FilterA.ToArray(), null, 5);
                            int linecountb = toupdate[0].TransferLines.Count();

                            toupdate[0].Transfer_from_Code = toList[i].frombin;
                            toupdate[0].Transfer_to_Code = toList[i].tobin;
                            toupdate[0].In_Transit_Code = "OWN.LOG";
                            toupdate[0].PDAOrder = true; 
                            toupdate[0].TransferLines = new Transfer_Order_Line[1];
                            toupdate[0].TransferLines[0] = new Transfer_Order_Line();

                            toservice.UpdateMultiple(ref toupdate);

                            toupdate[0].TransferLines[linecountb].Item_No = toList[i].ItemNo;
                            toupdate[0].TransferLines[linecountb].Quantity = Convert.ToInt32(toList[i].qty);
                            toupdate[0].TransferLines[linecountb].Transfer_from_Bin_Code = toList[i].frombin;
                            toupdate[0].TransferLines[linecountb].Transfer_To_Bin_Code = toList[i].tobin;
                            toupdate[0].TransferLines[linecountb].Staff_Dimension = staffdimg;

                            toservice.UpdateMultiple(ref toupdate);
                        }
                    }
                }


                ArrayList tnk = new ArrayList();
                for (int i = 0; i < toList.Count; i++)
                {
                    if (i == 0)
                    {
                        tnk.Add(toList[i].frombin);
                    }
                    else
                    {
                        if (!tnk.Contains(toList[i].frombin))
                        {
                            tnk.Add(toList[i].frombin);

                        }

                    }
                }

                for (int j = 0; j < tnk.Count; j++)
                {
                    //countotal = 0;
                    flagtemp = false;
                    itemtemp = "";
                    locationtemp = "";
                    bincodetemp = "";
                    tolocationtemp = "";

                    for (int k = 0; k < toList.Count; k++)
                    {
                        if (tnk[j].ToString().ToUpper().Equals(toList[k].frombin.ToString().ToUpper()))
                        {
                            itemtemp = toList[k].ItemNo;
                            //countotal = countotal + Convert.ToDecimal(toList[k].qty);
                            locationtemp = toList[k].froomLoc;
                            tolocationtemp = toList[k].toLoc;
                            bincodetemp = toList[k].frombin;

                            if (toList[k].emptyBin == true)
                            {
                                flagtemp = true;
                                qhfun.TankAdj_NAV(toList[k].ItemNo, "", toList[k].froomLoc, toList[k].frombin, 0, flagtemp, staffdimg, strPDAName, "CreateTO");
                            }
                        }
                    }
                    //to delete
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

                    //QHBinContent.QHBinContent[] qhbincon = qhsev.ReadMultiple(filterArr.ToArray(), null, 0);

                    //if (flagtemp == true) //qhbincon[0].Quantity_Base < countotal || 
                    //{

                    //    QHEmptyTank.QHEmptyTank_Service qhempty = new QHMobile.QHEmptyTank.QHEmptyTank_Service();
                    //    qhempty.Url = WebServiceInstants.GetURL(ServiceType.QHEmptyTank);
                    //    qhempty.Credentials = nc;

                    //    QHEmptyTank.QHEmptyTank qhcheck = qhempty.Read(bincodetemp);

                    //    if (qhcheck == null)
                    //    {
                    //        QHEmptyTank.QHEmptyTank qhtnk = new QHMobile.QHEmptyTank.QHEmptyTank();
                    //        qhtnk.Bin_Code = bincodetemp;
                    //        qhempty.Create(ref qhtnk);

                    //        TransferOrderQH.TransferOrderQH_Service tosev = new TransferOrderQH_Service();
                    //        tosev.Url = WebServiceInstants.GetURL(ServiceType.TransferOrderQH);
                    //        tosev.Credentials = nc;

                    //        List<TransferOrderQH.TransferOrderQH_Filter> tofilter = new List<TransferOrderQH_Filter>();

                    //        TransferOrderQH.TransferOrderQH_Filter fromloc = new TransferOrderQH_Filter();
                    //        fromloc.Field = TransferOrderQH_Fields.Transfer_from_Code;
                    //        fromloc.Criteria = locationtemp;

                    //        TransferOrderQH.TransferOrderQH_Filter toloc = new TransferOrderQH_Filter();
                    //        toloc.Field = TransferOrderQH_Fields.Transfer_to_Code;
                    //        toloc.Criteria = tolocationtemp;

                    //        TransferOrderQH.TransferOrderQH_Filter pdaorder = new TransferOrderQH_Filter();
                    //        pdaorder.Field = TransferOrderQH_Fields.PDAOrder;
                    //        pdaorder.Criteria = "Yes";

                    //        TransferOrderQH.TransferOrderQH_Filter filterDate = new TransferOrderQH_Filter();
                    //        filterDate.Field = TransferOrderQH_Fields.Posting_Date;

                    //        string d = DateTime.Today.Day.ToString();
                    //        string m = DateTime.Today.Month.ToString();
                    //        string y = DateTime.Now.Year.ToString().Substring(2, 2);

                    //        string datestr = m + "/" + d + "/" + y;

                    //        filterDate.Criteria = datestr; //DateTime.Today.ToShortDateString();

                    //        tofilter.Add(fromloc);
                    //        tofilter.Add(toloc);
                    //        tofilter.Add(pdaorder);
                    //        tofilter.Add(filterDate);

                    //        TransferOrderQH.TransferOrderQH[] togetarray = tosev.ReadMultiple(tofilter.ToArray(), null, 5);

                            
                    //        //qhtnk.Batch_Name = "DOA";
                    //        qhtnk.Item_No = itemtemp;
                    //        qhtnk.Ref_No = togetarray[0].No;
                    //        qhtnk.Location_Code = locationtemp;

                    //        qhempty.Update(ref qhtnk);
                    //    }

                    //}
                    //to delete
                 }

               
                MessageBox.Show("TO is updated successfully!");
                CreateTO toform = new CreateTO(usng, staffdimg, uslvelg);
                this.Close();
                toform.Show();
                

            }
            catch (Exception ext)
            {
                MessageBox.Show(ext.Message);
            }

            Cursor.Current = Cursors.Default;
        }

        

        private void PostNavision()
        {
            Cursor.Current = Cursors.WaitCursor;
            try
            {
                QH_Functions.QH_Functions qhfun = new QHMobile.QH_Functions.QH_Functions();
                qhfun.Url = WebServiceInstants.GetURL(ServiceType.QH_Functions);
                qhfun.Credentials = nc;
                qhfun.PostTrasferOrder(postSO, false);
                MessageBox.Show("Posted Successfully.");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error" + ex);
            }
            Cursor.Current = Cursors.Default;

            CreateTO toform = new CreateTO(usng, staffdimg, uslvelg);
            toform.Show();

        }

        private void mnuItmMain_Click(object sender, EventArgs e)
        {
            frmMain msc = new frmMain(usng, staffdimg, uslvelg);
            msc.Show();
        }

        private void menuItem3_Click(object sender, EventArgs e)
        {
            try
            {

                int count = GetNoOfSelectedRows(dgTOLine);

                if (count == 0 || count == null)
                {
                    MessageBox.Show("Please select the record first!");
                }
                else
                {
                    for (int i = 0; i < count; i++)
                    {
                        deleteSelectedRows(dgTOLine);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("PDA Error: Please select the line first!" + ex.Message);
            }

        }

        private ArrayList deleteSelectedRows(DataGrid dgTOLine)
        {
            ArrayList al = new ArrayList();

            CurrencyManager cm = (CurrencyManager)this.BindingContext[dgTOLine.DataSource];

            DataView dv = (DataView)cm.List;

            bool isFound = false;

            for (int i = 0; i < dv.Count && !isFound; ++i)
            {

                if (dgTOLine.IsSelected(i))
                {
                    dgTOLine.CurrentRowIndex = i;
                    isFound = true;
                    deleteCurrentRow();
                }
            }

            return al;
        }

        private void deleteCurrentRow()
        {
            bool isFound = false;
            if (dtTOModule.Rows.Count > 0)
            {
                for (int i = 0; i < dtTOModule.Rows.Count; i++)
                {
                    ///thurein
                    if ((dtTOModule.Rows[i][0].ToString() == dgTOLine[dgTOLine.CurrentCell.RowNumber, 0].ToString()) && (dtTOModule.Rows[i][1].ToString() == dgTOLine[dgTOLine.CurrentCell.RowNumber, 1].ToString()) && (dtTOModule.Rows[i][2].ToString() == dgTOLine[dgTOLine.CurrentCell.RowNumber, 2].ToString()) && !isFound)
                    {
                        //subtract from summary table
                        //CalculateSummaryTable(dg_stock[dg_stock.CurrentCell.RowNumber, 0].ToString(), dg_stock[dg_stock.CurrentCell.RowNumber, 1].ToString(), "-" + dg_stock[dg_stock.CurrentCell.RowNumber, 2].ToString(), dg_stock[dg_stock.CurrentCell.RowNumber, 3].ToString());
                        // DeleteToSummaryTable(GrdAddline[GrdAddline.CurrentCell.RowNumber, 0].ToString(), GrdAddline[GrdAddline.CurrentCell.RowNumber, 1].ToString(), "-" + GrdAddline[GrdAddline.CurrentCell.RowNumber, 2].ToString(), GrdAddline[GrdAddline.CurrentCell.RowNumber, 3].ToString());
                        //addToSummaryTable(dg_stock[dg_stock.CurrentCell.RowNumber, 0].ToString(), dg_stock[dg_stock.CurrentCell.RowNumber, 1].ToString(), "-" + dg_stock[dg_stock.CurrentCell.RowNumber, 2].ToString());

                        dtTOModule.Rows.RemoveAt(i);
                        toList.RemoveAt(i);
                        isFound = true;
                    }
                }

            }
        }

        private int GetNoOfSelectedRows(DataGrid dgTOLine)
        {
            int count = 0;

            CurrencyManager cm = (CurrencyManager)this.BindingContext[dgTOLine.DataSource];

            DataView dv = (DataView)cm.List;

            for (int i = 0; i < dv.Count; ++i)
            {

                if (dgTOLine.IsSelected(i))
                {

                    count++;

                }
            }
            return count;
        }

        private void menuNewScan_Click(object sender, EventArgs e)
        {
            
            CreateTO cto = new CreateTO(usng, staffdimg, uslvelg);
            cto.Show();
        }

        private void txtFromBin_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                Cursor.Current = Cursors.WaitCursor;
                try{

                            int fromflag;

                            Cursor.Current = Cursors.WaitCursor;
                            QH_Functions.QH_Functions qhfun = new QHMobile.QH_Functions.QH_Functions();
                            qhfun.Url = WebServiceInstants.GetURL(ServiceType.QH_Functions);
                            qhfun.Credentials = nc;
                            string strItemNo = "";
                            decimal davalQty = 0;
                            string strLoc = "";
                            fromflag = qhfun.ScanTObyFromBin(txtFromBin.Text.ToString().Trim(), ref strItemNo, ref davalQty, ref strLoc);
                            if (fromflag == 0)
                            {
                                MessageBox.Show("Invalid Bin Code!");
                            }
                            else if (fromflag == 1)
                            {
                                MessageBox.Show("This bin is blocked!");
                            }
                            else if (fromflag == 3)
                            {

                                lblInfoLocation.Text = strLoc;
                                lblStaffName.Text = staffdimg;
                                lblStaffRole.Text = uslvelg;
                            }
                            else if (fromflag == 4)
                            {
                                txtItemNo.Text = strItemNo;
                                
                                txtQty.Text = davalQty.ToString().Trim() ;
                                lblInfoLocation.Text = strLoc;

                                lblStaffName.Text = staffdimg;
                                lblStaffRole.Text = uslvelg;
                                txtTobin.SelectAll();
                                txtTobin.Focus();
                            }



                    /* DD785
                     * 
                            fromflag = GetFromLocationValidation();


                            if (fromflag == 0)
                            {
                                MessageBox.Show("Invalid Bin Code!");
                            }
                            else if (fromflag == 1)
                            {
                                MessageBox.Show("This bin is blocked!");
                            }
                            else if (fromflag == 3)
                            {
                                BinQH.BinQH_Service binserv = new QHMobile.BinQH.BinQH_Service();
                                binserv.Url = WebServiceInstants.GetURL(ServiceType.BinQH);
                                binserv.Credentials = nc;

                                List<BinQH.BinQH_Filter> binFilArray = new List<QHMobile.BinQH.BinQH_Filter>();

                                BinQH.BinQH_Filter binFilter = new QHMobile.BinQH.BinQH_Filter();
                                binFilter.Field = QHMobile.BinQH.BinQH_Fields.Code;
                                binFilter.Criteria = txtFromBin.Text.Trim();

                                binFilArray.Add(binFilter);

                                BinQH.BinQH[] binbl = binserv.ReadMultiple(binFilArray.ToArray(), null, 3);

                                lblInfoLocation.Text = binbl[0].Location_Code;
                                lblStaffName.Text = staffdimg;
                                lblStaffRole.Text = uslvelg;


                                //MessageBox.Show("Bin Exist!But not fiound in Bin Content or available quantity is 0.");
                            }
                            else if (fromflag == 4)
                            {
                                lblStaffName.Text = staffdimg;
                                lblStaffRole.Text = uslvelg;
                                txtTobin.SelectAll();
                                txtTobin.Focus();
                            }
 */

                 }catch(Exception ex)
                {
                    MessageBox.Show("Error:" + ex.Message);
                }


                Cursor.Current = Cursors.Default;
            
            }
        }

        private void dgTOLine_CurrentCellChanged(object sender, EventArgs e)
        {

        }

        private void menuItem2_Click(object sender, EventArgs e)
        {

        }

        private void Main_Click(object sender, EventArgs e)
        {

        }

        private void txtTobin_TextChanged(object sender, EventArgs e)
        {

        }

        private void label7_ParentChanged(object sender, EventArgs e)
        {

        }

        private void txtQty_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtItemNo_TextChanged(object sender, EventArgs e)
        {

        }

       

        private void lblInfoLocation_ParentChanged(object sender, EventArgs e)
        {

        }

        private void label8_ParentChanged(object sender, EventArgs e)
        {

        }

        private void txtLocToCode_TextChanged(object sender, EventArgs e)
        {

        }

        private void label2_ParentChanged(object sender, EventArgs e)
        {

        }

        private void lblCount_ParentChanged(object sender, EventArgs e)
        {

        }

        private void menuItem1_Click(object sender, EventArgs e)
        {

        }

        private void mnuItemOpt_Click(object sender, EventArgs e)
        {

        }

        private void MnuNewGRN_Click(object sender, EventArgs e)
        {

        }

        private void mnuGRNBack_Click(object sender, EventArgs e)
        {

        }

        private void tbMain_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void label1_ParentChanged(object sender, EventArgs e)
        {

        }

        /*
        private void textBox1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                GrdPost.DataSource = null;
                dtpost.Rows.Clear();

                TransferOrderQH.TransferOrderQH_Service toserv = new TransferOrderQH_Service();
                toserv.Url = WebServiceInstants.GetURL(ServiceType.TransferOrderQH);
                toserv.Credentials = nc;

                List<TransferOrderQH.TransferOrderQH_Filter> filterarray = new List<TransferOrderQH_Filter>();

                TransferOrderQH.TransferOrderQH_Filter fromfilter = new TransferOrderQH_Filter();
                fromfilter.Field = TransferOrderQH_Fields.Transfer_from_Code;
                fromfilter.Criteria = "QH1";

                TransferOrderQH.TransferOrderQH_Filter tofilter = new TransferOrderQH_Filter();
                tofilter.Field = TransferOrderQH_Fields.Transfer_to_Code;
                tofilter.Criteria = "LS1";

                TransferOrderQH.TransferOrderQH_Filter toidfilter = new TransferOrderQH_Filter();
                toidfilter.Field = TransferOrderQH_Fields.No;
                toidfilter.Criteria = txtToScanNo.Text.Trim();

                filterarray.Add(fromfilter);
                filterarray.Add(tofilter);
                filterarray.Add(toidfilter);

                TransferOrderQH.TransferOrderQH[] toarray = toserv.ReadMultiple(filterarray.ToArray(), null, 0);


                if (toarray == null || toarray.Length == 0)
                {
                    MessageBox.Show("No Record Found!");
                    txtToScanNo.SelectAll();
                    txtToScanNo.Focus();
                        
                }
                else
                {
                   
                    //lblFrom.Text = toarray[0].Transfer_from_Code;
                    //lblTo.Text = toarray[0].Transfer_to_Code;

                    for (int i = 0; i < toarray[0].TransferLines.Count(); i++)
                    {
                        Object[] array = new Object[5];

                        array[0] = toarray[0].TransferLines[i].Item_No;
                        array[1] = toarray[0].TransferLines[i].Description;  
                        array[2] = toarray[0].TransferLines[i].Transfer_from_Bin_Code;
                        array[3] = toarray[0].TransferLines[i].Transfer_To_Bin_Code;
                        array[4] = toarray[0].TransferLines[i].Quantity;

                        dtpost.Rows.Add(array);

                    }

                    lblPostLineCount.Text = dtpost.Rows.Count.ToString();
                    GrdPost.DataSource = dtpost;
                    txtToScanNo.Focus();

                }




            }
        }
        */

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
        
        private void mnuPost_Click(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;

            try
            {

                    if (lblTOPost.Text.Equals(""))
                    {
                        MessageBox.Show("Please enter TO number to create pick/put away!");
                    }
                    else
                    {

                        string strPDAName;
                        strPDAName = GetPDANamefromConfig();
                        bool flagproceed=true;

                        QH_Functions.QH_Functions qhfun = new QHMobile.QH_Functions.QH_Functions();
                        qhfun.Url = WebServiceInstants.GetURL(ServiceType.QH_Functions);
                        qhfun.Credentials = nc;

                        TransferOrderQH.TransferOrderQH_Service toSev = new TransferOrderQH_Service();
                        toSev.Url = WebServiceInstants.GetURL(ServiceType.TransferOrderQH);
                        toSev.Credentials = nc;

                        TransferOrderQH.TransferOrderQH toPost = toSev.Read(lblTOPost.Text.Trim());
                        tempto = toPost.No;


                        ArrayList tnk = new ArrayList();
                        List<TODummyClass> listBin = new List<TODummyClass>();
                        
                        //bool found;

                        //QHMobile.TransferOrderQH.Transfer_Order_Line tl = new Transfer_Order_Line;

                        if (toPost.TransferLines.Count() > 0)
                        {
                            for (int i = 0; i < toPost.TransferLines.Count(); i++)
                            {

                                if (i == 0)
                                {
                                    TODummyClass ftank = new TODummyClass();
                                    ftank.dummybin = toPost.TransferLines[i].Transfer_from_Bin_Code;
                                    ftank.dummyitem = toPost.TransferLines[i].Item_No;
                                    ftank.qty = toPost.TransferLines[i].Quantity;
                                    ftank.dummyloca = toPost.Transfer_from_Code;
                                    listBin.Add(ftank);
                                }
                                else
                                {
                                    bool found = false;

                                    for (int j = 0; j < listBin.Count; j++)
                                    {

                                        if (toPost.TransferLines[i].Transfer_from_Bin_Code.Equals(listBin[j].dummybin) && toPost.TransferLines[i].Item_No.Equals(listBin[j].dummyitem))
                                        {
                                            found = true;
                                            listBin[j].qty += toPost.TransferLines[i].Quantity;

                                        }
                                        
                                    }

                                    if (found == false)
                                    {
                                        TODummyClass utank = new TODummyClass();
                                        utank.dummybin = toPost.TransferLines[i].Transfer_from_Bin_Code;
                                        utank.dummyitem = toPost.TransferLines[i].Item_No;
                                        utank.qty = toPost.TransferLines[i].Quantity;
                                        utank.dummyloca = toPost.Transfer_from_Code;
                                        listBin.Add(utank);
                                    }


                                }

                            }
                        }

                       

                        for (int j = 0; j < listBin.Count; j++)
                        {
                            
                            QHBinContent.QHBinContent_Service qhsev = new QHMobile.QHBinContent.QHBinContent_Service();
                            qhsev.Credentials = nc;
                            qhsev.Url = WebServiceInstants.GetURL(ServiceType.QHBinContent);

                            List<QHBinContent.QHBinContent_Filter> filterArr = new List<QHMobile.QHBinContent.QHBinContent_Filter>();

                            QHBinContent.QHBinContent_Filter binfilter = new QHMobile.QHBinContent.QHBinContent_Filter();
                            binfilter.Field = QHMobile.QHBinContent.QHBinContent_Fields.Bin_Code;
                            binfilter.Criteria = listBin[j].dummybin;

                            QHBinContent.QHBinContent_Filter Qtyfilter = new QHMobile.QHBinContent.QHBinContent_Filter();
                            Qtyfilter.Field = QHMobile.QHBinContent.QHBinContent_Fields.Unit_of_Measure_Code;
                            Qtyfilter.Criteria = "<>''";  

                            QHBinContent.QHBinContent_Filter itemFilter = new QHMobile.QHBinContent.QHBinContent_Filter();
                            itemFilter.Field = QHMobile.QHBinContent.QHBinContent_Fields.Item_No;
                            itemFilter.Criteria = listBin[j].dummyitem;

                            filterArr.Add(binfilter);
                            filterArr.Add(Qtyfilter);
                            filterArr.Add(itemFilter);

                            QHBinContent.QHBinContent[] qhbincon = qhsev.ReadMultiple(filterArr.ToArray(), null, 0);

                            if (qhbincon.Length != 0)
                            {
                                if (qhbincon[0].Quantity - qhbincon[0].PDA_Inv_Pick_Quantity < listBin[j].qty)
                                {

                                    decimal updatecount = listBin[j].qty - (qhbincon[0].Quantity - qhbincon[0].PDA_Inv_Pick_Quantity);
                                    //qhfun.InsertIJLPositiveAdjustment(listBin[j].dummyitem, "", listBin[j].dummyloca, listBin[j].dummybin, updatecount, staffdimg);
                                    qhfun.InsertIJLPositiveAdjustment(listBin[j].dummyitem, tempto + "_DP", listBin[j].dummyloca, listBin[j].dummybin, updatecount, staffdimg, strPDAName, "CreateTO");
                                    
                                    flagproceed = true;

                                }
                                else
                                {
                                    flagproceed = true;
                                }
                            }
                            else
                            {
                                BinQH.BinQH_Service binservice = new QHMobile.BinQH.BinQH_Service();
                                binservice.Url = WebServiceInstants.GetURL(ServiceType.BinQH);
                                binservice.Credentials = nc;

                                BinQH.BinQH bintoget = binservice.Read(listBin[j].dummyloca, listBin[j].dummybin);

                                if (bintoget != null)
                                {

                                    //qhfun.InsertIJLPositiveAdjustment(listBin[j].dummyitem, "", listBin[j].dummyloca, listBin[j].dummybin,listBin[j].qty , staffdimg);
                                    qhfun.InsertIJLPositiveAdjustment(listBin[j].dummyitem, tempto + "_DP", listBin[j].dummyloca, listBin[j].dummybin, listBin[j].qty, staffdimg, strPDAName, "CreateTO");

                                    
                                    flagproceed = true;
                                }
                                else
                                {
                                    flagproceed = false;
                                     
                                }
                            }
                        }

                        if (flagproceed == true)
                        {
                            string pickNum = qhfun.CreateInvPickTransferOrder(tempto, "", "", 5741, 0);
                            qhfun.PostInventoryPick(pickNum);

                            

                            MessageBox.Show("Creasted and Posted Inventory Pick!");
                            menuItem4.Enabled = true;
                        }
                        else
                        {
                            MessageBox.Show("Invalid Bin or Could not prceed to adjust the quantity.");
                        }

                        //CreateTO cto = new CreateTO(usng, staffdimg, uslvelg);
                        //cto.Show();
                    }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                Cursor.Current = Cursors.Default;
                this.Close();
            }

            Cursor.Current = Cursors.Default;

        }

        private void CreateTO_KeyDown(object sender, KeyEventArgs e)
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

        private void menuItem4_Click(object sender, EventArgs e)
        {

            Cursor.Current = Cursors.WaitCursor;

            try
            {
                

                if (lblTOPost.Text.Equals(""))
                {
                    MessageBox.Show("Please enter TO number to create pick/put away!");
                }
                else
                {
                    string strPDAName;
                    strPDAName = GetPDANamefromConfig();

                    
                    QH_Functions.QH_Functions qhfun = new QHMobile.QH_Functions.QH_Functions();
                    qhfun.Url = WebServiceInstants.GetURL(ServiceType.QH_Functions);
                    qhfun.Credentials = nc;
                    //QHTR005801
                    tempto = lblTOPost.Text.ToString();
                    //MessageBox.Show(tempto);
                    string putawayNum = qhfun.CreateInvPutAwayTransferOrder(tempto, "", "", 5741, 1);
                    //MessageBox.Show(putawayNum);
                    qhfun.PostReceiveInventoryPutAway(putawayNum);

                    
                    //move to register
                    //QHEmptyTank.QHEmptyTank_Service empSev = new QHMobile.QHEmptyTank.QHEmptyTank_Service();
                    //empSev.Url = WebServiceInstants.GetURL(ServiceType.QHEmptyTank);
                    //empSev.Credentials = nc;

                    //List<QHEmptyTank.QHEmptyTank_Filter> empfilterArray = new List<QHMobile.QHEmptyTank.QHEmptyTank_Filter>();

                    //QHEmptyTank.QHEmptyTank_Filter tonumberFilter = new QHMobile.QHEmptyTank.QHEmptyTank_Filter();
                    //tonumberFilter.Field = QHMobile.QHEmptyTank.QHEmptyTank_Fields.Ref_No;
                    //tonumberFilter.Criteria = tempto;

                    //empfilterArray.Add(tonumberFilter);

                    //QHEmptyTank.QHEmptyTank[] batchList = empSev.ReadMultiple(empfilterArray.ToArray(), null, 0);

                    //if (batchList.Length != 0)
                    //{
                    //    for (int i = 0; i < batchList.Length; i++)
                    //    {
                    //        bool templfag = true;
                    //        qhfun.TankAdj_NAV(batchList[i].Item_No, "", batchList[i].Location_Code, batchList[i].Bin_Code, 0, templfag, staffdimg, strPDAName, "CreateTO");
                    //        empSev.Delete(batchList[i].Key.ToString());

                    //    }
                    //}
                    //Move to register
                    MessageBox.Show("Inventory Put away created and posted successfully!");                   

                    CreateTO cto = new CreateTO(usng, staffdimg, uslvelg);
                    cto.Show();
                }
                //   }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            Cursor.Current = Cursors.Default;

        }

        private void txtLocToCode_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                Cursor.Current = Cursors.WaitCursor;

                try
                {
                    if (txtLocToCode.Text.Trim().Equals(""))
                    {
                        MessageBox.Show("Pls enter location first!");
                    }
                    else
                    {
                        BinQH.BinQH_Service binserv = new QHMobile.BinQH.BinQH_Service();
                        binserv.Url = WebServiceInstants.GetURL(ServiceType.BinQH);
                        binserv.Credentials = nc;

                        List<BinQH.BinQH_Filter> FilterArray = new List<QHMobile.BinQH.BinQH_Filter>();

                        BinQH.BinQH_Filter locationBin = new QHMobile.BinQH.BinQH_Filter();
                        locationBin.Field = QHMobile.BinQH.BinQH_Fields.Location_Code;
                        locationBin.Criteria = txtLocToCode.Text.Trim();

                        BinQH.BinQH_Filter binDefault = new QHMobile.BinQH.BinQH_Filter();
                        locationBin.Field = QHMobile.BinQH.BinQH_Fields.Default;
                        locationBin.Criteria = "Yes";

                        FilterArray.Add(locationBin);
                        FilterArray.Add(binDefault);

                        BinQH.BinQH[] tobin = binserv.ReadMultiple(FilterArray.ToArray(), null, 5);

                        if (tobin.Length == 0)
                        {
                            MessageBox.Show("There is no default bin for this location");
                        }
                        else
                        {
                            txtTobin.Text = tobin[0].Code;
                            txtLocToCode.Text = tobin[0].Location_Code;
                            txtQty.SelectAll();
                            txtQty.Focus();


                            
                            /*
                            TransferOrderQH.TransferOrderQH_Service tosev = new TransferOrderQH_Service();
                            tosev.Url = WebServiceInstants.GetURL(ServiceType.TransferOrderQH);
                            tosev.Credentials = nc;

                            List<TransferOrderQH.TransferOrderQH_Filter> filterarray = new List<TransferOrderQH_Filter>();

                            TransferOrderQH.TransferOrderQH_Filter filterdate = new TransferOrderQH_Filter();
                            filterdate.Field = TransferOrderQH_Fields.Posting_Date;
                            filterdate.Criteria = DateTime.Today.ToShort hDateString();

                            TransferOrderQH.TransferOrderQH_Filter filterfrom = new TransferOrderQH_Filter();
                            filterfrom.Field = TransferOrderQH_Fields.Transfer_from_Code;
                            filterfrom.Criteria = lblInfoLocation.Text;


                            TransferOrderQH.TransferOrderQH_Filter filterTO = new TransferOrderQH_Filter();
                            filterTO.Field = TransferOrderQH_Fields.Transfer_to_Code;
                            filterTO.Criteria = txtLocToCode.Text;

                            filterarray.Add(filterdate);
                            filterarray.Add(filterfrom);
                            filterarray.Add(filterTO);

                            TransferOrderQH.TransferOrderQH[] tomultiple = tosev.ReadMultiple(filterarray.ToArray(), null,5);

                            if (tomultiple.Length == 0)
                            {
                                if (MessageBox.Show("There is no TO for these location. DO you want to create a new TO?", "", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) == DialogResult.Yes)
                                {
                                    CreateNewRequest();
                                }
                            }
                             * */
                        }

                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
                Cursor.Current = Cursors.Default;
            }
        }

        private void CreateNewRequest()
        {
            TransferOrderQH.TransferOrderQH_Service tosev = new TransferOrderQH_Service();
            tosev.Url = WebServiceInstants.GetURL(ServiceType.TransferOrderQH);
            tosev.Credentials = nc;


            TransferOrderQH.TransferOrderQH toCreate = new QHMobile.TransferOrderQH.TransferOrderQH();
            tosev.Create(ref toCreate);

            tempto = toCreate.No;

            TransferOrderQH.TransferOrderQH toget = tosev.Read(tempto);

            toget.Transfer_from_Code = lblInfoLocation.Text;
            toget.Transfer_to_Code = txtLocToCode.Text;
            

            tosev.Update(ref toget);

            toget.In_Transit_Code = "OWN.LOG";
            toget.PDAOrder = true;

            tosev.Update(ref toget);

            //toArray.Add(tempto);

            MessageBox.Show("TO No." + tempto);

        }

        private void txtTobin_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                Cursor.Current = Cursors.WaitCursor;

                try
                {
                    BinQH.BinQH_Service binsev = new QHMobile.BinQH.BinQH_Service();
                    binsev.Credentials = nc;
                    binsev.Url = WebServiceInstants.GetURL(ServiceType.BinQH);

                    List<BinQH.BinQH_Filter> binarray = new List<QHMobile.BinQH.BinQH_Filter>();

                    BinQH.BinQH_Filter binfilter = new QHMobile.BinQH.BinQH_Filter();
                    binfilter.Field = QHMobile.BinQH.BinQH_Fields.Code;

                    if (string.IsNullOrEmpty(txtTobin.Text.Trim()))
                    {
                        binfilter.Criteria = "''";
                    }
                    else
                    {
                        binfilter.Criteria = txtTobin.Text.Trim();
                    }
                    binarray.Add(binfilter);

                    BinQH.BinQH[] binget = binsev.ReadMultiple(binarray.ToArray(), null, 5);

                    if (binget.Length != 0)
                    {
                        txtLocToCode.Text = binget[0].Location_Code;
                        txtQty.SelectAll();
                        txtQty.Focus();

                        /*
                         * 
                        TransferOrderQH.TransferOrderQH_Service tosev = new TransferOrderQH_Service();
                        tosev.Url = WebServiceInstants.GetURL(ServiceType.TransferOrderQH);
                        tosev.Credentials = nc;

                        List<TransferOrderQH.TransferOrderQH_Filter> filterarray = new List<TransferOrderQH_Filter>();

                        TransferOrderQH.TransferOrderQH_Filter filterdate = new TransferOrderQH_Filter();
                        filterdate.Field = TransferOrderQH_Fields.Posting_Date;
                        filterdate.Criteria = DateTime.Today.ToShortDateString();

                        TransferOrderQH.TransferOrderQH_Filter filterfrom = new TransferOrderQH_Filter();
                        filterfrom.Field = TransferOrderQH_Fields.Transfer_from_Code;
                        filterfrom.Criteria = binget[0].Location_Code;


                        TransferOrderQH.TransferOrderQH_Filter filterTO = new TransferOrderQH_Filter();
                        filterTO.Field = TransferOrderQH_Fields.Transfer_to_Code;
                        filterTO.Criteria = txtLocToCode.Text;

                        filterarray.Add(filterdate);
                        filterarray.Add(filterfrom);
                        filterarray.Add(filterTO);

                        TransferOrderQH.TransferOrderQH[] tomultiple = tosev.ReadMultiple(filterarray.ToArray(), null, 5);

                        if (tomultiple.Length == 0)
                        {
                            if (MessageBox.Show("There is no TO for these location. DO you want to create a new TO?", "", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) == DialogResult.Yes)
                            {
                                CreateNewRequest();
                            }
                        }

                        */
                    }
                    else
                    {
                        MessageBox.Show("Bin Not found!");
                        txtTobin.SelectAll();
                        txtTobin.Focus();
                    }
                    
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
                Cursor.Current = Cursors.Default;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;

            try
            {

                GrdPost.DataSource = null;
                dtpost.Rows.Clear();
                dtpost.Clear();


                TransferOrderQH.TransferOrderQH_Service tosev = new TransferOrderQH_Service();
                tosev.Credentials = nc;
                tosev.Url = WebServiceInstants.GetURL(ServiceType.TransferOrderQH);

                List<TransferOrderQH_Filter> filterArray = new List<TransferOrderQH_Filter>();

                TransferOrderQH.TransferOrderQH_Filter fromfilter = new TransferOrderQH_Filter();
                fromfilter.Field = TransferOrderQH_Fields.Transfer_from_Code;
                fromfilter.Criteria = cboFrom.SelectedItem.ToString();

                TransferOrderQH.TransferOrderQH_Filter tofilter = new TransferOrderQH_Filter();
                tofilter.Field = TransferOrderQH_Fields.Transfer_to_Code;
                tofilter.Criteria = cboTO.SelectedItem.ToString();

                TransferOrderQH.TransferOrderQH_Filter dateFilter = new TransferOrderQH_Filter();
                dateFilter.Field = TransferOrderQH_Fields.Posting_Date;
                dateFilter.Criteria = txtExpectDate.Text.Trim();

                TransferOrderQH.TransferOrderQH_Filter pdaFilter = new TransferOrderQH_Filter();
                pdaFilter.Field = TransferOrderQH_Fields.PDAOrder;
                pdaFilter.Criteria = "Yes";

                filterArray.Add(fromfilter);
                filterArray.Add(tofilter);
                filterArray.Add(dateFilter);
                filterArray.Add(pdaFilter);


                TransferOrderQH.TransferOrderQH[] toList = tosev.ReadMultiple(filterArray.ToArray(), null, 5);


                if (toList.Length != 0)
                {
                    if (toList.Length != 0)
                    {
                        lblTOPost.Text = toList[0].No;

                        for (int i = 0; i < toList[0].TransferLines.Count(); i++)
                        {
                            Object[] array = new Object[5];

                            array[0] = toList[0].TransferLines[i].Item_No;
                            array[1] = toList[0].TransferLines[i].Description;
                            array[2] = toList[0].TransferLines[i].Transfer_from_Bin_Code;
                            array[3] = toList[0].TransferLines[i].Transfer_To_Bin_Code;
                            array[4] = toList[0].TransferLines[i].Quantity;

                            dtpost.Rows.Add(array);

                        }

                        lblPostLineCount.Text = dtpost.Rows.Count.ToString();
                        GrdPost.DataSource = dtpost;
                        // mnuPost.Enabled = true; 
                    }
                    else
                    {
                        MessageBox.Show("There is no TO found for these location!");
                    }

                    CheckMenuEnable(lblTOPost.Text.Trim());
                }
                else
                {
                    MessageBox.Show("PDA Error: TO Not found.");
                }

                

            }
            catch (Exception ex)
            {
                MessageBox.Show("PDA Error:" + ex);
            }

            Cursor.Current = Cursors.Default;
        }

        private void menuItem5_Click(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
            try
            {

                QH_Functions.QH_Functions qhfun = new QHMobile.QH_Functions.QH_Functions();
                qhfun.Url = WebServiceInstants.GetURL(ServiceType.QH_Functions);
                qhfun.Credentials = nc;

                TransferOrderQH.TransferOrderQH_Service toSev = new TransferOrderQH_Service();
                toSev.Url = WebServiceInstants.GetURL(ServiceType.TransferOrderQH);
                toSev.Credentials = nc;

                TransferOrderQH.TransferOrderQH toPost = toSev.Read(lblTOPost.Text.Trim());
                tempto = toPost.No;
                //qhfun.DocDimension(tempto);

                for (int i = 0; i < toPost.TransferLines.Count(); i++)
                {
                    if(toPost.TransferLines[i].Item_No==null) 
                    {
                        toSev.Delete_TransferLines(toPost.TransferLines[i].Key.ToString());
                    }
                }



                qhfun.UpdateDeptTransferLine(tempto);
                qhfun.ReleaseTO(tempto);

                CheckMenuEnable(tempto);

                MessageBox.Show("Released.");

            }
            catch (Exception ex)
            {
                MessageBox.Show("PDA Error:" + ex);
            }

            Cursor.Current = Cursors.Default;
        }

        private void CheckMenuEnable(string tempto)
        {
            TransferOrderQH.TransferOrderQH_Service toSev = new TransferOrderQH_Service();
            toSev.Url = WebServiceInstants.GetURL(ServiceType.TransferOrderQH);
            toSev.Credentials = nc;

            TransferOrderQH.TransferOrderQH toPost = toSev.Read(lblTOPost.Text.Trim());

            if(toPost != null)
            {
                if (toPost.Status == Status.Released)
                {
                    mnuPost.Enabled = true; 
                }
                else if (toPost.Status == Status.Open)
                {
                    menuItem5.Enabled = true;
                }

            }

            PostedTransferShipmentQH.PostedTransferShipmentQH_Service postedserv = new QHMobile.PostedTransferShipmentQH.PostedTransferShipmentQH_Service();
            postedserv.Url = WebServiceInstants.GetURL(ServiceType.PostedTransferShipmentQH);
            postedserv.Credentials = nc;

            List<PostedTransferShipmentQH.PostedTransferShipmentQH_Filter> postedFilterArr = new List<QHMobile.PostedTransferShipmentQH.PostedTransferShipmentQH_Filter>();

            PostedTransferShipmentQH.PostedTransferShipmentQH_Filter sourcefilter = new QHMobile.PostedTransferShipmentQH.PostedTransferShipmentQH_Filter();
            sourcefilter.Field = QHMobile.PostedTransferShipmentQH.PostedTransferShipmentQH_Fields.Transfer_Order_No;
            sourcefilter.Criteria = tempto;

            postedFilterArr.Add(sourcefilter);

            PostedTransferShipmentQH.PostedTransferShipmentQH[] postedlist = postedserv.ReadMultiple(postedFilterArr.ToArray(), null, 5);

            if(postedlist.Length != 0 )
            {
                menuItem4.Enabled = true; 
            }

            


        }

      
    }
}