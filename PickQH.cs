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
    public partial class PickQH : Form
    {
        protected System.Net.NetworkCredential nc = new System.Net.NetworkCredential(WebServiceInstants.GetURL(ServiceType.userName).ToString(), WebServiceInstants.GetURL(ServiceType.password).ToString(), WebServiceInstants.GetURL(ServiceType.domain).ToString());

        DataTable dtPick = new DataTable("Pick QH");
        DataTable dtPicked = new DataTable("Picked QH");
        DataTable dtEdit = new DataTable("Edit");

        static int count = 0;

        List<PickModule> pmArray = new List<PickModule>();
        List<PickModule> pickedArray = new List<PickModule>();
        List<PickModule> binarrayList = new List<PickModule>();
        List<PickModule> binArray = new List<PickModule>();
        List<Adjustment> adjustmentArray = new List<Adjustment>();
        List<Adjustment> ItemJnlArray = new List<Adjustment>();

        string packworksheet, itemNum,locationNum,SubstituteItemStr;
        string chBin;
        bool FlagAuto, FlagConvert, FlagpostiveSubsitute, dummysubstituteFlag;

        int updatnumber;
        decimal tempcount = 0;
        //decimal tempQtyCount = 0;

        string Rusername, Rstaffdimen, Ruserlevel;

        bool CheckItem =false;

        //bool ProcessOK = false;

        public PickQH(string username, string staffdimen, string userlevel)
        {
            InitializeComponent();
            txtScan.Focus();
            ClearCache();

            txtScan.Enabled = true; 

            Rusername = username;
            Rstaffdimen = staffdimen;
            Ruserlevel = userlevel;

            dtPick.Columns.Add("PW No");
            dtPick.Columns.Add("Item No");
            dtPick.Columns.Add("Location");
            dtPick.Columns.Add("Qty");
            dtPick.Columns.Add("Processed");

            dtPicked.Columns.Add("PW No");
            dtPicked.Columns.Add("Item No");
            dtPicked.Columns.Add("Bin");
            dtPicked.Columns.Add("Qty");
            dtPicked.Columns.Add("Empty Bin");
            dtPicked.Columns.Add("Processed");
            dtPicked.Columns.Add("Substitute Item");

            dtEdit.Columns.Add("PW No");
            dtEdit.Columns.Add("Item No");
            dtEdit.Columns.Add("Bin");
            dtEdit.Columns.Add("Qty");
            dtEdit.Columns.Add("Empty Bin");
            dtEdit.Columns.Add("Processed");
            dtEdit.Columns.Add("Substitute Item");
          
            
        }

        private void ClearCache()
        {
            pmArray.Clear();
            pickedArray.Clear();
            binarrayList.Clear();
            binArray.Clear();
            adjustmentArray.Clear();
            ItemJnlArray.Clear();
            dtPick.Clear();
            dtPicked.Clear();
            dtPick.Rows.Clear();
            dtPicked.Rows.Clear();
            count = 0;
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (grdLineToPost.DataSource != null)
            {
                MessageBox.Show("Please delete the previous records first!");
            }
            else
            {
                //QHIventoryPick.IventoryPick_Service invenSev = new QHMobile.QHIventoryPick.IventoryPick_Service();
                //invenSev.Credentials = nc;

                for (int i = 0; i < pmArray.Count; i++)
                {
                    Object[] array = new Object[5];
                   // QHIventoryPick.IventoryPick pk = invenSev.Read(QHIventoryPick.Activity_Type.Invt_Pick.ToString(), pmArray[i].pwNo, Convert.ToInt32(pmArray[i].lineno));

                    PickModule pkm = new PickModule();
                    
                    array[0] = pmArray[i].pwNo;
                    pkm.pwNo = pmArray[i].pwNo;
                    array[1] = pmArray[i].itemNo;
                    pkm.itemNo = pmArray[i].itemNo;
                    array[2] = pmArray[i].bin;
                    pkm.bin = pmArray[i].bin;
                    array[3] = pmArray[i].quatity;
                    pkm.quatity = pmArray[i].quatity;
                    array[4] = true;
                    pkm.proceed = true;
                    pkm.location = pmArray[i].location;
                   // pkm.conversionpostive = false;

                    pickedArray.Add(pkm);
                    dtPicked.Rows.Add(array);
                    
                }

                grdLineToPost.DataSource = dtPicked;

                MessageBox.Show("All the records are succesfully scanned!");

            }
        }

        private void txtScan_KeyDown(object sender, KeyEventArgs e)
        {

             if (e.KeyCode == Keys.Enter)
            {
                Cursor.Current = Cursors.WaitCursor;
                try
                {
                    if(! string.IsNullOrEmpty(txtScan.Text.ToString()))
                    {
                        int i = Convert.ToInt32(txtScan.Text.ToString());
                        QH_Functions.QH_Functions qhfun = new QHMobile.QH_Functions.QH_Functions();
                        qhfun.Url = WebServiceInstants.GetURL(ServiceType.QH_Functions);
                        qhfun.Credentials = nc;

                        string s = qhfun.GetBarcodePOPick(i);
                        //if (s != "NULL")
                        if (!string.IsNullOrEmpty(s))
                        {
                            string[] arr = s.Split('%');
                            ValidateItem(arr[1].ToString(), arr[0].ToString(), arr[2].ToString());

                            txtBin.SelectAll();
                            txtBin.Focus();
                            txtScan.Enabled = false;
                        }
                        else
                        {
                            MessageBox.Show("No Packing Worksheet no. found!");
                        }
                    }
                    else
                    {
                        MessageBox.Show("Please scan the Barcode!");
                    }

                    chkAutoScan.Checked = true;

                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }

               

                Cursor.Current = Cursors.Default;    
           
                

            }
        }

        private void ValidateItem(string p,string pw,string strLineNo)
        {
            QHIventoryPick.IventoryPick_Service invenSev = new QHMobile.QHIventoryPick.IventoryPick_Service();
            invenSev.Url = WebServiceInstants.GetURL(ServiceType.IventoryPick);
            invenSev.Credentials = nc;

            List<QHIventoryPick.IventoryPick_Filter> FilterArray = new List<QHMobile.QHIventoryPick.IventoryPick_Filter>();

            QHIventoryPick.IventoryPick_Filter filterTP = new QHMobile.QHIventoryPick.IventoryPick_Filter();
            filterTP.Field = QHMobile.QHIventoryPick.IventoryPick_Fields.Activity_Type;
            filterTP.Criteria = QHMobile.QHIventoryPick.Activity_Type.Invt_Pick.ToString();

            QHIventoryPick.IventoryPick_Filter filterPW = new QHMobile.QHIventoryPick.IventoryPick_Filter();
            filterPW.Field = QHMobile.QHIventoryPick.IventoryPick_Fields.No;
            filterPW.Criteria =pw ;
            packworksheet = pw;

            QHIventoryPick.IventoryPick_Filter filterIT = new QHMobile.QHIventoryPick.IventoryPick_Filter();
            filterIT.Field = QHMobile.QHIventoryPick.IventoryPick_Fields.Item_No;
            filterIT.Criteria = p;
            itemNum = p;

            QHIventoryPick.IventoryPick_Filter filterprocess = new QHMobile.QHIventoryPick.IventoryPick_Filter();
            filterprocess.Field = QHMobile.QHIventoryPick.IventoryPick_Fields.Processed;
            filterprocess.Criteria = "No";

            QHIventoryPick.IventoryPick_Filter filterQuantity = new QHMobile.QHIventoryPick.IventoryPick_Filter();
            filterQuantity.Field = QHMobile.QHIventoryPick.IventoryPick_Fields.Quantity;
            filterQuantity.Criteria = "<>0";

            QHIventoryPick.IventoryPick_Filter filterLineNo = new QHMobile.QHIventoryPick.IventoryPick_Filter();
            filterLineNo.Field = QHMobile.QHIventoryPick.IventoryPick_Fields.Source_Line_No;
            filterLineNo.Criteria = strLineNo;

            FilterArray.Add(filterTP);
            FilterArray.Add(filterPW);
            FilterArray.Add(filterIT);
            FilterArray.Add(filterprocess);
            FilterArray.Add(filterQuantity);
            FilterArray.Add(filterLineNo);


            QHIventoryPick.IventoryPick[] ArrayInv = invenSev.ReadMultiple(FilterArray.ToArray(), null, 0);


            if (ArrayInv.Length != 0)
            {
                txtItem.Text = ArrayInv[0].Item_No;
                //txtBin.Text = ArrayInv[0].Bin_Code;
                txtSubsItem.Text = ArrayInv[0].Item_No;
                txtQty.Text = ArrayInv[0].Quantity.ToString();
                locationNum = ArrayInv[0].Location_Code;
                lblLineInfo.Text = ArrayInv[0].Line_No.ToString();
                txtPickedQty.Text = ArrayInv[0].Quantity.ToString();
                lblStaffDimension.Text = Rstaffdimen;

                BindToGrid(ArrayInv);
            }
            else
            {
                MessageBox.Show("There is no record to scan!");
            }

            

        }

        private void BindToGrid(QHMobile.QHIventoryPick.IventoryPick[] ArrayInv)
        {
            for (int i = 0; i < ArrayInv.Length; i++)
            {
                Object[] array = new Object[5];
                PickModule pm = new PickModule();
                PickModule binarray = new PickModule();

                array[0] = ArrayInv[i].No;
                pm.pwNo = ArrayInv[i].No;
                array[1] = ArrayInv[i].Item_No;
                pm.itemNo = ArrayInv[i].Item_No;
                array[2] = ArrayInv[i].Location_Code;
                pm.location = ArrayInv[i].Location_Code;
                array[3] = ArrayInv[i].Quantity;
                pm.quatity = ArrayInv[i].Quantity;
                array[4] = ArrayInv[i].Processed;
                pm.proceed = ArrayInv[i].Processed;
                pm.lineno = ArrayInv[i].Line_No;
                

                dtPick.Rows.Add(array);
                pmArray.Add(pm);   /// put all records after scan 
                binarrayList.Add(binarray);
            }

            /*
            ArrayList tnk = new ArrayList();

            for (int i = 0; i < pmArray.Count; i++)
            {
                if (i == 0)
                {
                    PickModule pm1 = new PickModule();
                    tnk.Add(pmArray[i].bin);
                    pm1.bin = pmArray[i].bin;
                    binArray.Add(pm1);
                }
                else
                {
                    if (!tnk.Contains(pmArray[i].bin))
                    {
                        PickModule pm2 = new PickModule();
                        tnk.Add(pmArray[i].bin);
                        pm2.bin = pmArray[i].bin;
                        binArray.Add(pm2);
                    }

                }
            }

            for (int i = 0; i < binArray.Count; i++)
            {
                for (int j = 0; j < pmArray.Count; j++)
                {
                    if (binArray[i].bin.Equals(pmArray[j].bin))
                    {
                        binArray[i].quatity += pmArray[j].quatity;
                    }
                    
                } 
            }
            */

            GrdPick.DataSource = dtPick;

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

        private void btnAdd_Click(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
            try
            {
                if (FlagAuto == false)
                {
                    if (!string.IsNullOrEmpty(txtBin.Text.Trim()))
                    {
                        string itemtocheck = "";
                        FlagpostiveSubsitute = false;
                        dummysubstituteFlag = false;

                        QHBinContent.QHBinContent_Service qhsevice = new QHMobile.QHBinContent.QHBinContent_Service();
                        qhsevice.Url = WebServiceInstants.GetURL(ServiceType.QHBinContent);
                        qhsevice.Credentials = nc;

                        QH_Functions.QH_Functions qhfun = new QHMobile.QH_Functions.QH_Functions();
                        qhfun.Url = WebServiceInstants.GetURL(ServiceType.QH_Functions);
                        qhfun.Credentials = nc;


                        BinQH.BinQH_Service binservice = new QHMobile.BinQH.BinQH_Service();
                        binservice.Url = WebServiceInstants.GetURL(ServiceType.BinQH);
                        binservice.Credentials = nc;

                        List<BinQH.BinQH_Filter> filterBinArray = new List<QHMobile.BinQH.BinQH_Filter>();

                        BinQH.BinQH_Filter bincodefilter = new QHMobile.BinQH.BinQH_Filter();
                        bincodefilter.Field = QHMobile.BinQH.BinQH_Fields.Code;
                        bincodefilter.Criteria = txtBin.Text.Trim();

                        filterBinArray.Add(bincodefilter);

                        BinQH.BinQH[] getbinList = binservice.ReadMultiple(filterBinArray.ToArray(), null, 3);

                        if (getbinList.Length != 0)
                        {
                            if (getbinList[0].Dummy == true)
                            {
                                if (chkAutoScan.Checked == false)
                                {
                                    List<QHBinContent.QHBinContent_Filter> filterArray = new List<QHMobile.QHBinContent.QHBinContent_Filter>();

                                    QHBinContent.QHBinContent_Filter filterBin = new QHMobile.QHBinContent.QHBinContent_Filter();
                                    filterBin.Field = QHMobile.QHBinContent.QHBinContent_Fields.Bin_Code;
                                    filterBin.Criteria = txtBin.Text.Trim();

                                    QHBinContent.QHBinContent_Filter filterItem = new QHMobile.QHBinContent.QHBinContent_Filter();
                                    filterItem.Field = QHMobile.QHBinContent.QHBinContent_Fields.Item_No;
                                    filterItem.Criteria = txtSubsItem.Text.Trim();

                                    QHBinContent.QHBinContent_Filter fitlerPCS = new QHMobile.QHBinContent.QHBinContent_Filter();
                                    fitlerPCS.Field = QHMobile.QHBinContent.QHBinContent_Fields.Unit_of_Measure_Code;
                                    fitlerPCS.Criteria = "<>''";

                                    filterArray.Add(filterBin);
                                    filterArray.Add(fitlerPCS);
                                    filterArray.Add(filterItem);

                                    QHBinContent.QHBinContent[] qhcon = qhsevice.ReadMultiple(filterArray.ToArray(), null, 0);
                                    if (qhcon.Length != 0)
                                    {
                                        dummysubstituteFlag = true;
                                        if (txtItem.Text.Trim().Equals(qhcon[0].Item_No.Trim().ToString()))
                                        {
                                            if (txtPickedQty.Text.Equals(""))
                                            {
                                                NormalPicked();
                                            }
                                            else
                                            {
                                                SplitPick();
                                            }
                                        }
                                        else
                                        {
                                            var confirmResult = MessageBox.Show("Confirm to Substitute or not?", "Confirmation",
                                             MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1);

                                            if (confirmResult == DialogResult.Yes)
                                            {
                                                CheckItem = qhfun.CheckItemSubstitution(txtItem.Text.Trim(), txtSubsItem.Text.Trim()); // Call Navision

                                                if (CheckItem == true)
                                                {
                                                    SubstituteItemStr = itemtocheck;

                                                    if (txtPickedQty.Text.Equals(""))
                                                    {
                                                        NormalPicked();
                                                    }
                                                    else
                                                    {
                                                        SplitPick();
                                                    }
                                                }
                                                else
                                                {
                                                    MessageBox.Show("Cannot Substitute by these items.");
                                                }
                                            }
                                            else
                                            {
                                                MessageBox.Show("Please scan the another tank!");
                                                txtBin.Text = "";
                                            }

                                            CheckItem = false;
                                        }

                                    }

                                }
                                //else
                                //{
                                //    MessageBox.Show("Please enter the substitute item no as of dummy bin.");
                                //}
                            }
                            else
                            {


                                List<QHBinContent.QHBinContent_Filter> filterArray = new List<QHMobile.QHBinContent.QHBinContent_Filter>();

                                QHBinContent.QHBinContent_Filter filterBin = new QHMobile.QHBinContent.QHBinContent_Filter();
                                filterBin.Field = QHMobile.QHBinContent.QHBinContent_Fields.Bin_Code;
                                filterBin.Criteria = txtBin.Text.Trim();

                                QHBinContent.QHBinContent_Filter fitlerPCS = new QHMobile.QHBinContent.QHBinContent_Filter();
                                fitlerPCS.Field = QHMobile.QHBinContent.QHBinContent_Fields.Unit_of_Measure_Code;
                                fitlerPCS.Criteria = "<>''";

                                filterArray.Add(filterBin);
                                filterArray.Add(fitlerPCS);

                                QHBinContent.QHBinContent[] qhcon = qhsevice.ReadMultiple(filterArray.ToArray(), null, 0);

                                if (qhcon.Length != 0)
                                {
                                    for (int i = 0; i < qhcon.Length; i++)
                                    {

                                        decimal calculate = qhcon[i].Quantity - qhcon[i].PDA_Inv_Pick_Quantity;

                                        if (calculate != 0)
                                        {
                                            itemtocheck = qhcon[i].Item_No;

                                        }
                                    }
                                }
                                else
                                {
                                    itemtocheck = "";
                                }

                                if (itemtocheck == "")
                                {
                                    //BinQH.BinQH_Service binservice = new QHMobile.BinQH.BinQH_Service();
                                    //binservice.Url = WebServiceInstants.GetURL(ServiceType.BinQH);
                                    //binservice.Credentials = nc;

                                    //BinQH.BinQH binget = binservice.Read(locationNum, txtBin.Text.Trim());

                                    //if (binget != null)
                                    //{

                                    FlagpostiveSubsitute = true;

                                    if (txtPickedQty.Text.Equals(""))
                                    {
                                        NormalPicked();
                                    }
                                    else
                                    {
                                        SplitPick();
                                    }

                                    //}
                                    //else
                                    //{
                                    //    MessageBox.Show("You have scan invalid bin.Please try again.");
                                    //    txtEditBin.SelectAll();
                                    //    txtEditBin.Focus();
                                    //}

                                }
                                else
                                {

                                    if (txtItem.Text.Trim().Equals(itemtocheck))
                                    {
                                        if (txtPickedQty.Text.Equals(""))
                                        {
                                            NormalPicked();
                                        }
                                        else
                                        {
                                            SplitPick();
                                        }
                                    }
                                    else
                                    {
                                        var confirmResult = MessageBox.Show("Confirm to Substitute or not?", "Confirmation",
                                         MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1);

                                        if (confirmResult == DialogResult.Yes)
                                        {
                                            CheckItem = qhfun.CheckItemSubstitution(txtItem.Text.Trim(), itemtocheck); // Call Navision

                                            if (CheckItem == true)
                                            {
                                                SubstituteItemStr = itemtocheck;

                                                if (txtPickedQty.Text.Equals(""))
                                                {
                                                    NormalPicked();
                                                }
                                                else
                                                {
                                                    SplitPick();
                                                }
                                            }
                                            else
                                            {
                                                MessageBox.Show("Cannot Substitute by these items.");
                                            }
                                        }
                                        else
                                        {
                                            MessageBox.Show("Please scan the another tank!");
                                            txtBin.Text = "";
                                        }

                                        CheckItem = false;
                                    }

                                }
                            }
                        }
                        else
                        {
                            MessageBox.Show("The bin you have scanned is not found!");
                        }
                    }
                    else
                    {
                        MessageBox.Show("There is no bin code. Please scan first!");
                    }

                    EnableComponent();

                }
                else
                {
                    MessageBox.Show("You have to check off Auto Scan!");
                }
            }

            catch (Exception ex)
            {
                MessageBox.Show("Error:" + ex.Message);
            }

            Cursor.Current = Cursors.Default;


        }

        private void EnableComponent()
        {
            if (dtPicked.Rows.Count > 0)
            {
                menuItem3.Enabled = true;
            }

        }   

        private void NormalPicked()
        {
            for (int i = 0; i < pmArray.Count; i++)
            {
                if (pmArray[i].lineno.Equals(Convert.ToDecimal(lblLineInfo.Text.Trim())))
                {
                    if (pmArray[i].quatity == Convert.ToDecimal(txtPickedQty.Text))
                    {
                        PickModule pck = new PickModule();
                        Object[] array = new Object[7];

                        pck.bookmark = count;
                        pck.pwNo = pmArray[i].pwNo;
                        array[0] = pmArray[i].pwNo;
                        pck.itemNo = pmArray[i].itemNo;
                        array[1] = pmArray[i].itemNo;
                        pck.bin = txtBin.Text.Trim();
                        array[2] = txtBin.Text.Trim();
                        pck.quatity = Convert.ToDecimal(txtPickedQty.Text.Trim());
                        array[3] = Convert.ToDecimal(txtPickedQty.Text.Trim());

                        if (chkEmptyTank.Checked)
                        {
                            pck.emptyflag = true;
                        }
                        else
                        {
                            pck.emptyflag = false;
                        }
                        array[4] = pck.emptyflag;

                        pck.proceed = true;
                        array[5] = true;

                        pck.conversionflag = CheckItem;
                        array[6] = CheckItem;

                        if (CheckItem == true)
                        {
                            pck.substituteTank = txtBin.Text.Trim();
                            pck.substituteItem = SubstituteItemStr;

                        }
                        else
                        {
                            pck.substituteItem = null;
                            pck.substituteTank = null;
                        }

                        pck.lineno = pmArray[i].lineno;
                        pck.location = pmArray[i].location;
                        pck.conversionpostive = FlagpostiveSubsitute;

                        pickedArray.Add(pck);
                        dtPicked.Rows.Add(array);

                        //txtBin.Text = "";
                        chkEmptyTank.Checked = false;

                        if (pmArray.Count != i + 1)
                        {
                            txtItem.Text = pmArray[i + 1].itemNo;
                            txtQty.Text = pmArray[i + 1].quatity.ToString();
                            lblLineInfo.Text = pmArray[i + 1].lineno.ToString();
                            lblBagCount.Text = (i + 1).ToString() + "/" + pmArray.Count.ToString();
                            lblBagC.Text = (i + 1).ToString() + "/" + pmArray.Count.ToString();
                            lblpicklinecount.Text = dtPicked.Rows.Count.ToString();
                            lblLC.Text = dtPicked.Rows.Count.ToString();
                        }
                        else
                        {
                            //btnAdd.Enabled = false;
                            //btnAddAll.Enabled = false;
                            //txtBin.Enabled = false;
                            txtItem.Text = "";
                            txtBin.Text = "";
                            txtQty.Text = "";
                            txtPickedQty.Text = "";
                        }

                        //pmArray.RemoveAt(i);
                        break;
                        //locationNum = pmArray[count + 1].location;
                    }
                   
                }

               

            }

            grdLineToPost.DataSource = dtPicked;


        }

        private void SplitPick()
        {
            for (int i = 0; i < pmArray.Count; i++)
            {
                if (pmArray[i].lineno.Equals(Convert.ToDecimal(lblLineInfo.Text.Trim())))
                {
                    tempcount = Convert.ToDecimal(txtPickedQty.Text) + tempcount;

                    if (tempcount != pmArray[i].quatity)
                    {
                        PickModule pck = new PickModule();
                        Object[] array = new Object[7];

                        pck.bookmark = count;
                        pck.pwNo = pmArray[i].pwNo;
                        array[0] = pmArray[i].pwNo;
                        pck.itemNo = pmArray[i].itemNo;
                        array[1] = pmArray[i].itemNo;
                        pck.bin = txtBin.Text.Trim();
                        array[2] = txtBin.Text.Trim();
                        pck.quatity = Convert.ToDecimal(txtPickedQty.Text.Trim());
                        
                        array[3] = Convert.ToDecimal(txtPickedQty.Text.Trim());

                        if (chkEmptyTank.Checked)
                        {
                            pck.emptyflag = true;
                        }
                        else
                        {
                            pck.emptyflag = false;
                        }
                        array[4] = pck.emptyflag;

                        pck.proceed = true;
                        array[5] = true;

                        pck.conversionflag = CheckItem;
                        array[6] = CheckItem;

                        if (CheckItem == true)
                        {
                            pck.substituteTank = txtBin.Text.Trim();
                            pck.substituteItem = SubstituteItemStr;

                        }
                        else
                        {
                            pck.substituteItem = null;
                            pck.substituteTank = null;
                        }

                        pck.lineno = pmArray[i].lineno;
                        pck.location = pmArray[i].location;
                        pck.conversionpostive = FlagpostiveSubsitute;
                        pck.dummysubitem = txtSubsItem.Text.Trim();
                        pck.isDummyBin = dummysubstituteFlag;

                        pickedArray.Add(pck);
                        dtPicked.Rows.Add(array);

                        chkEmptyTank.Checked = false;
                        txtPickedQty.Text = (pmArray[i].quatity - tempcount).ToString();
                        //tempcount = pck.quatity + tempcount;

                        break;
                    }
                    else
                    {
                        PickModule pck = new PickModule();
                        Object[] array = new Object[7];

                        pck.bookmark = count;
                        pck.pwNo = pmArray[i].pwNo;
                        array[0] = pmArray[i].pwNo;
                        pck.itemNo = pmArray[i].itemNo;
                        array[1] = pmArray[i].itemNo;
                        pck.bin = txtBin.Text.Trim();
                        array[2] = txtBin.Text.Trim();
                        pck.quatity = Convert.ToDecimal(txtPickedQty.Text.Trim());
                        array[3] = Convert.ToDecimal(txtPickedQty.Text.Trim());

                        if (chkEmptyTank.Checked)
                        {
                            pck.emptyflag = true;
                        }
                        else
                        {
                            pck.emptyflag = false;
                        }
                        array[4] = pck.emptyflag;

                        pck.proceed = true;
                        array[5] = true;

                        pck.conversionflag = CheckItem;
                        array[6] = CheckItem;

                        if (CheckItem == true)
                        {
                            pck.substituteTank = txtBin.Text.Trim();
                            pck.substituteItem = SubstituteItemStr;

                        }
                        else
                        {
                            pck.substituteItem = null;
                            pck.substituteTank = null;
                        }

                        pck.lineno = pmArray[i].lineno;
                        pck.location = pmArray[i].location;
                        pck.conversionpostive = FlagpostiveSubsitute;
                        pck.dummysubitem = txtSubsItem.Text.Trim();
                        pck.isDummyBin = dummysubstituteFlag;

                        pickedArray.Add(pck);
                        dtPicked.Rows.Add(array);

                        chkEmptyTank.Checked = false;

                        txtBin.Text = "";
                        //pmArray.RemoveAt(i);

                        if (pmArray.Count != i + 1)
                        {
                            txtItem.Text = pmArray[i + 1].itemNo;
                            txtSubsItem.Text = pmArray[i + 1].itemNo;
                            txtQty.Text = pmArray[i + 1].quatity.ToString();
                            lblLineInfo.Text = pmArray[i + 1].lineno.ToString();
                            txtPickedQty.Text = pmArray[i + 1].quatity.ToString();
                            lblBagCount.Text = (i + 1).ToString() + "/" + pmArray.Count.ToString();
                            lblBagC.Text = (i + 1).ToString() + "/" + pmArray.Count.ToString();
                            lblpicklinecount.Text = dtPicked.Rows.Count.ToString();
                            lblLC.Text = dtPicked.Rows.Count.ToString();
                        }
                        else
                        {

                            lblBagCount.Text = (i + 1).ToString() + "/" + pmArray.Count.ToString();
                            lblBagC.Text = (i + 1).ToString() + "/" + pmArray.Count.ToString();
                            lblpicklinecount.Text = dtPicked.Rows.Count.ToString();
                            lblLC.Text = dtPicked.Rows.Count.ToString();

                            btnAdd.Enabled = false;
                            txtBin.Enabled = false;
                            //ProcessOK = true; 

                        }

                        tempcount = 0;

                        break;
                    }
                }

            }
            grdLineToPost.DataSource = dtPicked;
        }

        private void EditNormalPicked()
        {
            for (int i = 0; i < pmArray.Count; i++)
            {
                if (pmArray[i].lineno.Equals(Convert.ToDecimal(lblLineInfo.Text.Trim())))
                {
                    if (pmArray[i].quatity == Convert.ToDecimal(txtPickedQty.Text))
                    {
                        PickModule pck = new PickModule();
                        Object[] array = new Object[7];

                        pck.bookmark = count;
                        pck.pwNo = pmArray[i].pwNo;
                        array[0] = pmArray[i].pwNo;
                        pck.itemNo = pmArray[i].itemNo;
                        array[1] = pmArray[i].itemNo;
                        pck.bin = txtBin.Text.Trim();
                        array[2] = txtBin.Text.Trim();
                        pck.quatity = Convert.ToDecimal(txtPickedQty.Text.Trim());
                        array[3] = Convert.ToDecimal(txtPickedQty.Text.Trim());

                        if (chkEditEmptyTank.Checked)
                        {
                            pck.emptyflag = true;
                        }
                        else
                        {
                            pck.emptyflag = false;
                        }
                        array[4] = pck.emptyflag;

                        pck.proceed = true;
                        array[5] = true;

                        pck.conversionflag = CheckItem;
                        array[6] = CheckItem;

                        if (CheckItem == true)
                        {
                            pck.substituteTank = txtBin.Text.Trim();
                            pck.substituteItem = SubstituteItemStr;

                        }
                        else
                        {
                            pck.substituteItem = null;
                            pck.substituteTank = null;
                        }

                        pck.lineno = pmArray[i].lineno;
                        pck.location = pmArray[i].location;
                        pck.conversionpostive = FlagpostiveSubsitute;
                        pickedArray.Add(pck);

                        dtEdit.Rows.Add(array);
                        dtPicked.Rows.Add(array);
                        

                        //txtBin.Text = "";
                        chkEditEmptyTank.Checked = false;

                        //if (pmArray.Count != i + 1)
                        //{
                        //    txtEditBin.Text = pmArray[i + 1].itemNo;
                        //    lblTotalQty.Text = pmArray[i + 1].quatity.ToString();
                        //    txtEditLine.Text = pmArray[i + 1].lineno.ToString();
                        //}
                        //else
                        //{
                        //    btnAdd.Enabled = false;
                        //}
                      
                        break;
                       
                    }

                }



            }

            grdLineToPost.DataSource = dtPicked;
            GrdEditPick.DataSource =  dtEdit;

        }

        private void EditSplitPick()
        {
            for (int i = 0; i < pmArray.Count; i++)
            {
                if (pmArray[i].lineno.Equals(Convert.ToDecimal(txtEditLine.Text.Trim())))
                {
                    tempcount = Convert.ToDecimal(txtEditQty.Text) + tempcount;

                    if (tempcount != pmArray[i].quatity)
                    {
                        PickModule pck = new PickModule();
                        Object[] array = new Object[7];
                        Object[] editarray = new Object[7];

                        pck.bookmark = count;
                        pck.pwNo = pmArray[i].pwNo;
                        array[0] = pmArray[i].pwNo;
                        pck.itemNo = pmArray[i].itemNo;
                        array[1] = pmArray[i].itemNo;
                        pck.bin = txtEditBin.Text.Trim();
                        array[2] = txtEditBin.Text.Trim();
                        pck.quatity = Convert.ToDecimal(txtEditQty.Text.Trim());
                        array[3] = Convert.ToDecimal(txtEditQty.Text.Trim());

                        if (chkEditEmptyTank.Checked)
                        {
                            pck.emptyflag = true;
                        }
                        else
                        {
                            pck.emptyflag = false;
                        }
                        array[4] = pck.emptyflag;

                        pck.proceed = true;
                        array[5] = true;

                        pck.conversionflag = CheckItem;
                        array[6] = CheckItem;

                        editarray[0] = pmArray[i].pwNo;
                        editarray[1] = pmArray[i].itemNo;
                        editarray[2] = txtEditBin.Text.Trim();
                        editarray[3] = Convert.ToDecimal(txtEditQty.Text.Trim());
                        editarray[4] = pck.emptyflag;
                        editarray[5] = true;
                        editarray[6] = CheckItem;

                        if (CheckItem == true)
                        {
                            pck.substituteTank = txtEditBin.Text.Trim();
                            pck.substituteItem = SubstituteItemStr;

                        }
                        else
                        {
                            pck.substituteItem = null;
                            pck.substituteTank = null;
                        }

                        pck.lineno = pmArray[i].lineno;
                        pck.location = pmArray[i].location;
                        pck.conversionpostive = FlagpostiveSubsitute;
                        pickedArray.Add(pck);

                        dtEdit.Rows.Add(editarray);
                        dtPicked.Rows.Add(array);


                        chkEditEmptyTank.Checked = false;
                        txtEditQty.Text = (pmArray[i].quatity - tempcount).ToString();
                        //tempcount = pck.quatity + tempcount;

                        break;
                    }
                    else
                    {
                        PickModule pck = new PickModule();
                        Object[] array = new Object[7];
                        Object[] editarray = new Object[7];

                        pck.bookmark = count;
                        pck.pwNo = pmArray[i].pwNo;
                        array[0] = pmArray[i].pwNo;
                        editarray[0] = pmArray[i].pwNo;
                        pck.itemNo = pmArray[i].itemNo;
                        array[1] = pmArray[i].itemNo;
                        editarray[1] = pmArray[i].itemNo;
                        pck.bin = txtEditBin.Text.Trim();
                        array[2] = txtEditBin.Text.Trim();
                        editarray[2] = txtEditBin.Text.Trim();
                        pck.quatity = Convert.ToDecimal(txtEditQty.Text.Trim());
                        array[3] = Convert.ToDecimal(txtEditQty.Text.Trim());
                        editarray[3] = Convert.ToDecimal(txtEditQty.Text.Trim());

                        if (chkEditEmptyTank.Checked)
                        {
                            pck.emptyflag = true;
                        }
                        else
                        {
                            pck.emptyflag = false;
                        }
                        array[4] = pck.emptyflag;
                        editarray[4] = pck.emptyflag;

                        pck.proceed = true;
                        array[5] = true;
                        editarray[5] = true;

                        pck.conversionflag = CheckItem;
                        array[6] = CheckItem;
                        editarray[6] = CheckItem;

                        if (CheckItem == true)
                        {
                            pck.substituteTank = txtEditBin.Text.Trim();
                            pck.substituteItem = SubstituteItemStr;

                        }
                        else
                        {
                            pck.substituteItem = null;
                            pck.substituteTank = null;
                        }

                        pck.lineno = pmArray[i].lineno;
                        pck.location = pmArray[i].location;
                        pck.conversionpostive = FlagpostiveSubsitute;
                        pickedArray.Add(pck);

                        dtEdit.Rows.Add(editarray);
                        dtPicked.Rows.Add(array);

                        chkEditEmptyTank.Checked = false;
                        txtEditQty.Text = (pmArray[i].quatity - tempcount).ToString();
                        
                        //pmArray.RemoveAt(i);

                        //if (pmArray.Count != i + 1)
                        //{
                        //    txtItem.Text = pmArray[i + 1].itemNo;
                        //    txtQty.Text = pmArray[i + 1].quatity.ToString();
                        //    lblLineInfo.Text = pmArray[i + 1].lineno.ToString();
                        //}
                        //else
                        //{
                        //    btnAdd.Enabled = false;

                        //}

                        tempcount = 0;

                        break;
                    }
                }

            }
            grdLineToPost.DataSource = dtPicked;
            GrdEditPick.DataSource = dtEdit;

        }


        private void CheckForTank(string receivedBin)
        {
            chBin = txtBin.Text.Trim();

            if (!chBin.Trim().Equals(receivedBin.Trim()))
            {
                if (MessageBox.Show("You are now trying to modify the tank. Press Yes to continue!", "", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) == DialogResult.Yes)
                {
                    txtBin.Text = chBin;
                }
                else
                {
                    //txtBin.Text = recBin;
                    txtBin.Text = "";
                }
            }
        }

        private void menuItem3_Click(object sender, EventArgs e)
        {

            Cursor.Current = Cursors.WaitCursor;

            //if (ProcessOK == true)
            //{
                try
                {

                    //if (dtPicked.Rows.Count != 0)
                    //{

                        decimal countotal = 0;
                        decimal dmmycount = 0;
                        bool flagtemp = false;
                        bool converflag = false;
                        bool notexistbc = false;
                        string itemtemp;
                        string locationtemp;
                        string bincodetemp;
                        string substitueItem;
                        string substituteTnk;
                        bool dummyconverflag;
                        string itemoriginal;

                        string strPDAName = "";
                        strPDAName = GetPDANamefromConfig();

                        QH_Functions.QH_Functions qhfun = new QHMobile.QH_Functions.QH_Functions();
                        qhfun.Url = WebServiceInstants.GetURL(ServiceType.QH_Functions);
                        qhfun.Credentials = nc;

                        var result = MessageBox.Show("Confirm register to Navision or not?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1);
                        if (result == DialogResult.Yes)
                        {
                            //DD786
                            decimal iPickedQty = 0;
                            decimal iToPickQty = 0;

                            if ((pickedArray.Count > 0) && (pmArray.Count > 0))
                            {
                                for (int i = 0; i < pickedArray.Count; i++)
                                {
                                    iPickedQty += pickedArray[i].quatity;
                                }

                                for (int i = 0; i < pmArray.Count; i++)
                                {
                                    iToPickQty += pmArray[i].quatity;
                                }

                            }
                            if (iToPickQty != iPickedQty)
                            {
                                var CompareResult = MessageBox.Show("Haven't fully picked yet!Do you want to process or not?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1);
                                if (CompareResult == DialogResult.No)
                                {
                                    return;
                                    Cursor.Current = Cursors.Default;
                                }

                            }
                            //DD786

                            /// Unique Tank /// 

                            ArrayList tnk = new ArrayList();
                            ArrayList dummytnklist = new ArrayList();
                            ArrayList dummyitemlist = new ArrayList();
                            List<DummyClass> listDummy = new List<DummyClass>();


                            for (int i = 0; i < pickedArray.Count; i++)
                            {

                                if (!tnk.Contains(pickedArray[i].bin) && pickedArray[i].isDummyBin == false)
                                {
                                    tnk.Add(pickedArray[i].bin);

                                }
                                else if (pickedArray[i].isDummyBin == true && !dummyitemlist.Contains(pickedArray[i].dummysubitem))
                                {
                                    DummyClass dmc = new DummyClass();
                                    dmc.dummybin = pickedArray[i].bin;
                                    dmc.dummyitem = pickedArray[i].dummysubitem;
                                    dmc.dummyloca = pickedArray[i].location;

                                    dummytnklist.Add(pickedArray[i].bin);
                                    listDummy.Add(dmc);
                                    dummyitemlist.Add(pickedArray[i].dummysubitem);
                                }
                            }

                            /// Unique Tank /// 

                            //// Postitive and Negative Adjustment ///// 

                            for (int j = 0; j < tnk.Count; j++)
                            {
                                countotal = 0;
                                flagtemp = false;
                                converflag = false;
                                itemtemp = ""; // Item from PDA Inventory Pick
                                substitueItem = ""; // This is from PDA Inventory Pick 
                                locationtemp = "";
                                bincodetemp = "";
                                notexistbc = false;
                                substituteTnk = "";

                                for (int k = 0; k < pickedArray.Count; k++)
                                {
                                    if (tnk[j].ToString().Equals(pickedArray[k].bin))
                                    {

                                        itemtemp = pickedArray[k].itemNo;
                                        countotal = countotal + pickedArray[k].quatity; //ttttt
                                        locationtemp = pickedArray[k].location;
                                        bincodetemp = pickedArray[k].bin;

                                        if (pickedArray[k].emptyflag == true)
                                        {
                                            flagtemp = true;
                                        }
                                        if (pickedArray[k].conversionflag == true)
                                        {
                                            converflag = true;
                                            substitueItem = pickedArray[k].substituteItem;
                                            substituteTnk = pickedArray[k].substituteTank;
                                        }
                                        if (pickedArray[k].conversionpostive == true)
                                        {
                                            notexistbc = true;
                                        }
                                    }

                                }

                                if (bincodetemp != "" && itemtemp != "")
                                {
                                    QHBinContent.QHBinContent_Service qhsev = new QHMobile.QHBinContent.QHBinContent_Service();
                                    qhsev.Credentials = nc;
                                    qhsev.Url = WebServiceInstants.GetURL(ServiceType.QHBinContent);

                                    List<QHBinContent.QHBinContent_Filter> filterArr = new List<QHMobile.QHBinContent.QHBinContent_Filter>();

                                    QHBinContent.QHBinContent_Filter binfilter = new QHMobile.QHBinContent.QHBinContent_Filter();
                                    binfilter.Field = QHMobile.QHBinContent.QHBinContent_Fields.Bin_Code;
                                    binfilter.Criteria = bincodetemp;

                                    QHBinContent.QHBinContent_Filter itemFilter = new QHMobile.QHBinContent.QHBinContent_Filter();
                                    itemFilter.Field = QHMobile.QHBinContent.QHBinContent_Fields.Item_No;

                                    if (converflag == true)
                                    {
                                        itemFilter.Criteria = substitueItem;
                                    }
                                    else
                                    {
                                        itemFilter.Criteria = itemtemp;
                                    }

                                    QHBinContent.QHBinContent_Filter fitlerPCS = new QHMobile.QHBinContent.QHBinContent_Filter();
                                    fitlerPCS.Field = QHMobile.QHBinContent.QHBinContent_Fields.Unit_of_Measure_Code;
                                    fitlerPCS.Criteria = "<>''";

                                    filterArr.Add(binfilter);
                                    filterArr.Add(itemFilter);
                                    filterArr.Add(fitlerPCS);

                                    QHBinContent.QHBinContent[] qhbincon = qhsev.ReadMultiple(filterArr.ToArray(), null, 0);


                                    if (qhbincon.Length != 0)
                                    {

                                        if (converflag == true)
                                        {
                                            if (qhbincon[0].Quantity - qhbincon[0].PDA_Inv_Pick_Quantity < countotal)
                                            {
                                                decimal countdifference = qhbincon[0].Quantity - qhbincon[0].PDA_Inv_Pick_Quantity;
                                                countdifference = countotal - countdifference;
                                                qhfun.InsertIJLPositiveAdjustment(substitueItem, packworksheet, locationtemp, bincodetemp, countdifference, Rstaffdimen, GetPDANamefromConfig(), "PickQH");

                                            }
                                            qhfun.SubstituteItem(itemtemp, substitueItem, packworksheet, locationtemp, substituteTnk, countotal, Rstaffdimen, GetPDANamefromConfig(), "PickQH");


                                        }
                                        else if (converflag == false)
                                        {
                                            if (qhbincon[0].Quantity - qhbincon[0].PDA_Inv_Pick_Quantity < countotal)
                                            {
                                                decimal countdifference = qhbincon[0].Quantity - qhbincon[0].PDA_Inv_Pick_Quantity;
                                                countdifference = countotal - countdifference;

                                                qhfun.InsertIJLPositiveAdjustment(itemtemp, packworksheet, locationtemp, bincodetemp, countdifference, Rstaffdimen, GetPDANamefromConfig(), "PickQH");
                                            }

                                        }
                                    }
                                    else
                                    {

                                        if (converflag == false)
                                        {
                                            qhfun.InsertIJLPositiveAdjustment(itemtemp, packworksheet, locationtemp, bincodetemp, countotal, Rstaffdimen, GetPDANamefromConfig(), "PickQH");

                                        }
                                        else
                                        {
                                            qhfun.InsertIJLPositiveAdjustment(substitueItem, packworksheet, locationtemp, bincodetemp, countotal, Rstaffdimen, GetPDANamefromConfig(), "PickQH");
                                            qhfun.SubstituteItem(itemtemp, substitueItem, packworksheet, locationtemp, substituteTnk, countotal, Rstaffdimen, GetPDANamefromConfig(), "PickQH");



                                        }
                                        //}
                                    }
                                }

                            }

                            //// Postitive and Negative Adjustment ///// 

                            /////// ----- Dummy Bin --------------- ///// 

                            for (int k = 0; k < listDummy.Count; k++)
                            {

                                dummyconverflag = false;
                                dmmycount = 0;
                                itemoriginal = "";
                                for (int l = 0; l < pickedArray.Count; l++)
                                {

                                    if (listDummy[k].dummybin.Equals(pickedArray[l].bin) && listDummy[k].dummyitem.Equals(pickedArray[l].dummysubitem))
                                    {
                                        dmmycount = dmmycount + pickedArray[l].quatity;
                                        itemoriginal = pickedArray[k].itemNo;

                                        if (pickedArray[l].conversionflag == true)
                                        {
                                            dummyconverflag = true;
                                        }

                                    }


                                }


                                QHBinContent.QHBinContent_Service qhsev = new QHMobile.QHBinContent.QHBinContent_Service();
                                qhsev.Credentials = nc;
                                qhsev.Url = WebServiceInstants.GetURL(ServiceType.QHBinContent);

                                List<QHBinContent.QHBinContent_Filter> filterArr = new List<QHMobile.QHBinContent.QHBinContent_Filter>();

                                QHBinContent.QHBinContent_Filter binfilter = new QHMobile.QHBinContent.QHBinContent_Filter();
                                binfilter.Field = QHMobile.QHBinContent.QHBinContent_Fields.Bin_Code;
                                binfilter.Criteria = listDummy[k].dummybin;

                                QHBinContent.QHBinContent_Filter itemFilter = new QHMobile.QHBinContent.QHBinContent_Filter();
                                itemFilter.Field = QHMobile.QHBinContent.QHBinContent_Fields.Item_No;
                                itemFilter.Criteria = listDummy[k].dummyitem;

                                QHBinContent.QHBinContent_Filter fitlerPCS = new QHMobile.QHBinContent.QHBinContent_Filter();
                                fitlerPCS.Field = QHMobile.QHBinContent.QHBinContent_Fields.Unit_of_Measure_Code;
                                fitlerPCS.Criteria = "<>''";


                                filterArr.Add(binfilter);
                                filterArr.Add(itemFilter);
                                filterArr.Add(fitlerPCS);

                                QHBinContent.QHBinContent[] qhbincon = qhsev.ReadMultiple(filterArr.ToArray(), null, 0);

                                if (qhbincon.Length != 0)
                                {
                                    if (dummyconverflag == true)
                                    {
                                        if (qhbincon[0].Quantity - qhbincon[0].PDA_Inv_Pick_Quantity < dmmycount)
                                        {
                                            decimal countdifference = qhbincon[0].Quantity - qhbincon[0].PDA_Inv_Pick_Quantity;
                                            countdifference = dmmycount - countdifference;
                                            qhfun.InsertIJLPositiveAdjustment(listDummy[k].dummyitem, packworksheet, listDummy[k].dummyloca, listDummy[k].dummybin, countdifference, Rstaffdimen, GetPDANamefromConfig(), "PickQH");
                                            //qhfun.SubstituteItem(itemtemp, substitueItem, packworksheet, locationtemp, substituteTnk, countotal);
                                        }
                                        qhfun.SubstituteItem(itemoriginal, listDummy[k].dummyitem, packworksheet, listDummy[k].dummyloca, listDummy[k].dummybin, dmmycount, Rstaffdimen, GetPDANamefromConfig(), "PickQH");

                                    }
                                    else
                                    {
                                        if (qhbincon[0].Quantity - qhbincon[0].PDA_Inv_Pick_Quantity < dmmycount)
                                        {
                                            decimal countdifference = qhbincon[0].Quantity - qhbincon[0].PDA_Inv_Pick_Quantity;
                                            countdifference = dmmycount - countdifference;
                                            qhfun.InsertIJLPositiveAdjustment(listDummy[k].dummyitem, packworksheet, listDummy[k].dummyloca, listDummy[k].dummybin, countdifference, Rstaffdimen, GetPDANamefromConfig(), "PickQH");
                                        }
                                    }
                                }
                                else
                                {
                                    if (dummyconverflag == true)
                                    {
                                        qhfun.InsertIJLPositiveAdjustment(listDummy[k].dummyitem, packworksheet, listDummy[k].dummyloca, listDummy[k].dummybin, dmmycount, Rstaffdimen, GetPDANamefromConfig(), "PickQH");
                                        qhfun.SubstituteItem(itemoriginal, listDummy[k].dummyitem, packworksheet, listDummy[k].dummyloca, listDummy[k].dummybin, dmmycount, Rstaffdimen, GetPDANamefromConfig(), "PickQH");
                                    }
                                    else
                                    {
                                        qhfun.InsertIJLPositiveAdjustment(listDummy[k].dummyitem, packworksheet, listDummy[k].dummyloca, listDummy[k].dummybin, dmmycount, Rstaffdimen, GetPDANamefromConfig(), "PickQH");
                                    }
                                }



                            }

                            //////// -------- Dummy Bin ------------////////

                            ///// ----- Simple Update ------------ /// 

                            QHIventoryPick.IventoryPick_Service invenSev = new QHMobile.QHIventoryPick.IventoryPick_Service();
                            invenSev.Url = WebServiceInstants.GetURL(ServiceType.IventoryPick);
                            invenSev.Credentials = nc;


                            for (int i = 0; i < pickedArray.Count; i++)
                            {
                                QHIventoryPick.IventoryPick pk = invenSev.Read(QHIventoryPick.Activity_Type._blank_.ToString(), packworksheet, Convert.ToInt32(pickedArray[i].lineno));

                                if (pk != null && pk.Processed == false)
                                {

                                    string tempBinforConv = "";

                                    if (pickedArray[i].conversionflag == true)
                                    {
                                        tempBinforConv = pickedArray[i].bin;

                                        if (pickedArray[i].location.Equals("QH1"))
                                        {
                                            QHDummyBin.QHDummyBin_Service qhdummySeverice = new QHMobile.QHDummyBin.QHDummyBin_Service();
                                            qhdummySeverice.Url = WebServiceInstants.GetURL(ServiceType.QHDummyBin);
                                            qhdummySeverice.Credentials = nc;


                                            QHDummyBin.QHDummyBin[] qhdummy = qhdummySeverice.ReadMultiple(null, null, 3);

                                            pickedArray[i].oriBin = pickedArray[i].bin; // added enhancement 17 april 2013 by Hsu
                                            pickedArray[i].bin = qhdummy[0].Dummy_Bin;

                                            pk.Item_No_Substitution = pickedArray[i].substituteItem; //added enhancement 17 april 2013 by Hsu
                                            pk.Bin_Code_Substitution = pickedArray[i].oriBin; //added enhancement 17 april 2013 by Hsu

                                        }
                                        else
                                        {
                                            BinQH.BinQH_Service binservice = new QHMobile.BinQH.BinQH_Service();
                                            binservice.Url = WebServiceInstants.GetURL(ServiceType.BinQH);
                                            binservice.Credentials = nc;

                                            List<BinQH.BinQH_Filter> binfilterArr = new List<QHMobile.BinQH.BinQH_Filter>();

                                            BinQH.BinQH_Filter dummyFilter = new QHMobile.BinQH.BinQH_Filter();
                                            dummyFilter.Field = QHMobile.BinQH.BinQH_Fields.Dummy;
                                            dummyFilter.Criteria = "Yes";

                                            BinQH.BinQH_Filter locationFilter = new QHMobile.BinQH.BinQH_Filter();
                                            locationFilter.Field = QHMobile.BinQH.BinQH_Fields.Dummy;
                                            locationFilter.Criteria = pickedArray[i].location;

                                            binfilterArr.Add(dummyFilter);
                                            binfilterArr.Add(locationFilter);

                                            BinQH.BinQH[] bindummy = binservice.ReadMultiple(binfilterArr.ToArray(), null, 3);

                                            pickedArray[i].oriBin = pickedArray[i].bin; // added enhancement 17 april 2013 by Hsu
                                            pickedArray[i].bin = bindummy[0].Code;

                                            pk.Item_No_Substitution = pickedArray[i].substituteItem; //added enhancement 17 april 2013 by Hsu
                                            pk.Bin_Code_Substitution = pickedArray[i].oriBin; //added enhancement 17 april 2013 by Hsu


                                        }

                                    }


                                    pk.Activity_Type = QHMobile.QHIventoryPick.Activity_Type.Invt_Pick;
                                    invenSev.Update(ref pk);
                                    pk.Processed = pickedArray[i].proceed;
                                    pk.Quantity = pickedArray[i].quatity;
                                    pk.Bin_Code = pickedArray[i].bin;
                                    pk.Staff_Dimension = Rstaffdimen;
                                    // pk.Bin_Code_Substitution = pickedArray[i].oriBin; // added enhancement 17 april 2013 by Hsu


                                    invenSev.Update(ref pk);

                                    if (pickedArray[i].isDummyBin == false)
                                    {
                                        if (pickedArray[i].emptyflag == true)
                                        {
                                            pk.Empty_Tank = true;
                                            invenSev.Update(ref pk);

                                            Boolean emptyflag = true;

                                            //DD972
                                            decimal iQtyTemp = 0;
                                            for (int kk = 0; kk < pickedArray.Count; kk++)
                                            {
                                                if (pickedArray[i].bin.Equals(pickedArray[kk].bin))
                                                {

                                                    iQtyTemp = iQtyTemp + pickedArray[kk].quatity;
                                                }

                                            }
                                            //DD972


                                            if (pickedArray[i].conversionflag == true)
                                            {
                                                //DD972 qhfun.TankAdj_NAV(pickedArray[i].substituteItem, packworksheet, pickedArray[i].location, tempBinforConv, pickedArray[i].quatity, emptyflag, Rstaffdimen,GetPDANamefromConfig(),"PickQH");
                                                qhfun.TankAdj_NAV(pickedArray[i].substituteItem, packworksheet, pickedArray[i].location, tempBinforConv, iQtyTemp, emptyflag, Rstaffdimen, GetPDANamefromConfig(), "PickQH");
                                            }
                                            else
                                            {
                                                //DD972 qhfun.TankAdj_NAV(pickedArray[i].itemNo, packworksheet, pickedArray[i].location, pickedArray[i].bin, pickedArray[i].quatity, emptyflag, Rstaffdimen, GetPDANamefromConfig(), "PickQH");
                                                qhfun.TankAdj_NAV(pickedArray[i].itemNo, packworksheet, pickedArray[i].location, pickedArray[i].bin, iQtyTemp, emptyflag, Rstaffdimen, GetPDANamefromConfig(), "PickQH");
                                            }

                                        }
                                        else
                                        {
                                            pk.Empty_Tank = false;
                                            invenSev.Update(ref pk);
                                        }
                                    }

                                }
                                else if (pk.Processed == true || pk == null)
                                {
                                    string tempBinforConv1 = "";

                                    List<QHIventoryPick.IventoryPick_Filter> filterarray = new List<QHMobile.QHIventoryPick.IventoryPick_Filter>();
                                    QHIventoryPick.IventoryPick_Filter filter = new QHMobile.QHIventoryPick.IventoryPick_Filter();
                                    filter.Field = QHMobile.QHIventoryPick.IventoryPick_Fields.No;
                                    filter.Criteria = packworksheet;

                                    filterarray.Add(filter);

                                    QHIventoryPick.IventoryPick[] packarray = invenSev.ReadMultiple(filterarray.ToArray(), null, 0);


                                    QHIventoryPick.IventoryPick pknew = new QHMobile.QHIventoryPick.IventoryPick();
                                    pknew.Activity_TypeSpecified = true;
                                    pknew.Activity_Type = QHMobile.QHIventoryPick.Activity_Type.Invt_Pick;
                                    pknew.No = packworksheet;
                                    pknew.Line_NoSpecified = true;
                                    int count = packarray.Count();
                                    int lineno = packarray[count - 1].Line_No + 10000;
                                    pknew.Line_No = lineno;

                                    invenSev.Create(ref pknew);

                                    pknew.No = packworksheet;
                                    invenSev.Update(ref pknew);

                                    invenSev.Update(ref pknew);
                                    pknew.Activity_Type = QHMobile.QHIventoryPick.Activity_Type.Invt_Pick;
                                    invenSev.Update(ref pknew);
                                    pknew.Source_No = packworksheet;
                                    pknew.Bin_Code = pickedArray[i].bin;
                                    pknew.Item_No = pickedArray[i].itemNo;
                                    pknew.Processed = true;
                                    pknew.Quantity = pickedArray[i].quatity;
                                    pknew.Location_Code = pk.Location_Code;
                                    pknew.Source_Line_NoSpecified = true;
                                    pknew.Source_Line_No = pk.Source_Line_No;
                                    pknew.Source_Subline_NoSpecified = true;
                                    pknew.Source_Subline_No = pk.Source_Subline_No;


                                    if (pickedArray[i].conversionflag == true)
                                    {

                                        tempBinforConv1 = pickedArray[i].bin;

                                        if (pickedArray[i].location.Equals("QH1"))
                                        {
                                            QHDummyBin.QHDummyBin_Service qhdummySeverice = new QHMobile.QHDummyBin.QHDummyBin_Service();
                                            qhdummySeverice.Url = WebServiceInstants.GetURL(ServiceType.QHDummyBin);
                                            qhdummySeverice.Credentials = nc;
                                            QHDummyBin.QHDummyBin[] qhdummy = qhdummySeverice.ReadMultiple(null, null, 3);


                                            pickedArray[i].oriBin = pickedArray[i].bin; //added enhancement 17 april 2013 by Hsu
                                            pickedArray[i].bin = qhdummy[0].Dummy_Bin;

                                            pknew.Item_No_Substitution = pickedArray[i].substituteItem; //added enhancement 17 april 2013 by Hsu
                                            pknew.Bin_Code_Substitution = pickedArray[i].oriBin; //added enhancement 17 april 2013 by Hsu


                                        }
                                        else
                                        {
                                            BinQH.BinQH_Service binservice = new QHMobile.BinQH.BinQH_Service();
                                            binservice.Url = WebServiceInstants.GetURL(ServiceType.BinQH);
                                            binservice.Credentials = nc;

                                            List<BinQH.BinQH_Filter> binfilterArr = new List<QHMobile.BinQH.BinQH_Filter>();

                                            BinQH.BinQH_Filter dummyFilter = new QHMobile.BinQH.BinQH_Filter();
                                            dummyFilter.Field = QHMobile.BinQH.BinQH_Fields.Dummy;
                                            dummyFilter.Criteria = "Yes";

                                            BinQH.BinQH_Filter locationFilter = new QHMobile.BinQH.BinQH_Filter();
                                            locationFilter.Field = QHMobile.BinQH.BinQH_Fields.Dummy;
                                            locationFilter.Criteria = pickedArray[i].location;

                                            binfilterArr.Add(dummyFilter);
                                            binfilterArr.Add(locationFilter);

                                            BinQH.BinQH[] bindummy = binservice.ReadMultiple(binfilterArr.ToArray(), null, 3);

                                            pickedArray[i].oriBin = pickedArray[i].bin; //added enhancement 17 april 2013 by Hsu
                                            pickedArray[i].bin = bindummy[0].Code;

                                            pknew.Item_No_Substitution = pickedArray[i].substituteItem; //added enhancement 17 april 2013 by Hsu
                                            pknew.Bin_Code_Substitution = pickedArray[i].oriBin; //added enhancement 17 april 2013 by Hsu

                                        }

                                    }

                                    pknew.Processed = pickedArray[i].proceed;
                                    pknew.Quantity = pickedArray[i].quatity;
                                    pknew.Bin_Code = pickedArray[i].bin;
                                    pknew.Staff_Dimension = Rstaffdimen;


                                    invenSev.Update(ref pknew);

                                    if (pickedArray[i].isDummyBin == false)
                                    {
                                        if (pickedArray[i].emptyflag == true)
                                        {
                                            pk.Empty_Tank = true;
                                            invenSev.Update(ref pk);

                                            Boolean emptyflag = true;
                                            //DD972
                                            decimal iQtyTemp = 0;
                                            for (int kk = 0; kk < pickedArray.Count; kk++)
                                            {
                                                if (pickedArray[i].bin.Equals(pickedArray[kk].bin))
                                                {

                                                    iQtyTemp = iQtyTemp + pickedArray[kk].quatity;
                                                }

                                            }
                                            //DD972
                                            if (pickedArray[i].conversionflag == true)
                                            {
                                                // DD972 qhfun.TankAdj_NAV(pickedArray[i].substituteItem, packworksheet, pickedArray[i].location, tempBinforConv1, pickedArray[i].quatity, emptyflag, Rstaffdimen,GetPDANamefromConfig(), "PickQH");
                                                qhfun.TankAdj_NAV(pickedArray[i].substituteItem, packworksheet, pickedArray[i].location, tempBinforConv1, iQtyTemp, emptyflag, Rstaffdimen, GetPDANamefromConfig(), "PickQH");
                                            }
                                            else
                                            {
                                                //DD972 qhfun.TankAdj_NAV(pickedArray[i].itemNo, packworksheet, pickedArray[i].location, pickedArray[i].bin, pickedArray[i].quatity, emptyflag, Rstaffdimen, GetPDANamefromConfig(), "PickQH");
                                                qhfun.TankAdj_NAV(pickedArray[i].itemNo, packworksheet, pickedArray[i].location, pickedArray[i].bin, iQtyTemp, emptyflag, Rstaffdimen, GetPDANamefromConfig(), "PickQH");
                                            }

                                        }
                                        else
                                        {
                                            pk.Empty_Tank = false;
                                            invenSev.Update(ref pk);
                                        }
                                    }



                                }

                            }

                            ///// ----- Simple Update ------------ /// 

                            MessageBox.Show("Updated Succesfully!");
                            PickQH pqh = new PickQH(Rusername, Rstaffdimen, Ruserlevel);
                            this.Close();
                            pqh.Show();

                        }
                    //}
                    //else
                    //{
                    //    MessageBox.Show("There is no line to picked.");
                    //}

                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error:" + ex);
                    menuItem3.Enabled = false;
                }
           
            Cursor.Current = Cursors.Default;
                
        }

        private void GrdPickedAredy_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (GrdPickedAredy.SelectedIndex == 2)
                {

                    dtEdit.Rows.Clear();
                    GrdEditPick.DataSource = null;
                    txtEditBin.Text = "";
                    txtEditItem.Text = "";
                    txtEditLine.Text = "";
                    txtEditQty.Text = "";
                    chkEditEmptyTank.Checked = false;

                    int count = GetNoOfSelectedRows(grdLineToPost);

                    if (count == 0 || count == null)
                    {
                        MessageBox.Show("Please select the record first!");
                    }
                    else
                    {
                        bool flagqty;

                        var result = MessageBox.Show("Do you want to change the Qty? If you need, you have to reassign this item.", "Confirmation",
                                     MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1);
                        if (result == DialogResult.Yes)
                        {

                            flagqty = true;
                            btnEditAdd.Visible = true;
                            btnConfirmUpdate.Visible = false;
                        }
                        else
                        {
                            flagqty = false;
                            btnEditAdd.Visible = false;
                            btnConfirmUpdate.Visible = true;
                            btnConfirmUpdate.Enabled = true;
                            //chkEditEmptyTank.Enabled = false;
                            //chkEditEmptyTank.Visible = false;
                        }



                        for (int i = 0; i < count; i++)
                        {
                            UpdateSelectedRows(grdLineToPost,flagqty);
                        }
                    }


                }

                /*
                if (GrdPickedAredy.SelectedIndex == 4)
                {
                    int count = GetNoOfSelectedRows(GrdItemJnl);

                    if (count == 0 || count == null)
                    {
                        MessageBox.Show("Please select the record first!");
                    }
                    else
                    {
                        for (int i = 0; i < count; i++)
                        {
                            //UpdatTheBin(GrdItemJnl);
                        }
                    }


                }
                 */

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            //else if (GrdPickedAredy.SelectedIndex == 3)
            //{
            //    int count = GetNoOfSelectedRows(grdLineToPost);

            //    if (count == 0 || count == null)
            //    {
            //        MessageBox.Show("Please select the record first!");
            //    }
            //    else
            //    {
            //        for (int i = 0; i < count; i++)
            //        {
            //            UpdatePositiveAjustment(grdLineToPost);
            //        }
            //    }


            //}



        }

        private ArrayList UpdateSelectedRows(DataGrid grdLineToPost,bool flagReceive)
        {
            
            ArrayList al = new ArrayList();

            CurrencyManager cm = (CurrencyManager)this.BindingContext[grdLineToPost.DataSource];

            DataView dv = (DataView)cm.List;

            bool isFound = false;

            for (int i = 0; i < dv.Count && !isFound; ++i)
            {

                if (grdLineToPost.IsSelected(i))
                {
                    //grdLineToPost.CurrentRowIndex = i;

                    txtEditBin.Text = pickedArray[i].bin;
                    txtEditItem.Text = pickedArray[i].itemNo;
                    txtEditQty.Text = pickedArray[i].quatity.ToString();
                    //txtEditPW.Text = packworksheet;
                    txtEditLine.Text = pickedArray[i].lineno.ToString();
                    isFound = true;
                    //updateCurrentRow();
                }
            }

            for (int j = 0; j < pmArray.Count; j++)
            {
                if (pmArray[j].lineno.Equals(Convert.ToDecimal(txtEditLine.Text)))
                {
                    lblTotalQty.Text = pmArray[j].quatity.ToString();
                }
            }


            if (flagReceive == true)
            {
                txtEditQty.Enabled = true;
                btnConfirmUpdate.Enabled = true;


                string str=""; 

                for (int i = 0; i < pickedArray.Count; i++)
                {
                    if (pickedArray[i].lineno.Equals(Convert.ToDecimal(txtEditLine.Text)))
                    {

                        str += "~" + i;
                        
                        //pickedArray.RemoveAt(i);
                    }
                }
                string[] arr = str.Split('~');

                int tempcount=0;

                int linecount = pickedArray.Count();

                for (int i = 0; i < linecount; i++)
                {
                    if (pickedArray[tempcount].lineno.Equals(Convert.ToDecimal(txtEditLine.Text.Trim())))
                    {
                        pickedArray.RemoveAt(tempcount);
                    }
                    else
                    {
                        //pickedArray.RemoveAt(tempcount);
                        tempcount = tempcount + 1;
                    }
                }



                dtPicked.Rows.Clear();
                grdLineToPost.DataSource = null; 

                for (int j = 0; j < pickedArray.Count; j++)
                {
                     Object[] array = new Object[7];

                     array[0] = pickedArray[j].pwNo;
                     array[1] = pickedArray[j].itemNo;
                     array[2] = pickedArray[j].bin;
                     array[3] = pickedArray[j].quatity;
                     array[4] = pickedArray[j].emptyflag;
                     array[5] = pickedArray[j].proceed;
                     array[6] = pickedArray[j].conversionflag;

                     dtPicked.Rows.Add(array);

                }

                grdLineToPost.DataSource = dtPicked;

            }
            else
            {
                txtEditQty.Enabled = false;
                //btnConfirmUpdate.Enabled = false;
            }


            return al;
        }

        private void updateCurrentRow()
        {
            bool isFound = false;
            if (dtPicked.Rows.Count > 0)
            {
                for (int i = 0; i < dtPicked.Rows.Count; i++)
                {
                    
                    if ((dtPicked.Rows[i][0].ToString() == grdLineToPost[grdLineToPost.CurrentCell.RowNumber, 0].ToString()) && (dtPicked.Rows[i][1].ToString() == grdLineToPost[grdLineToPost.CurrentCell.RowNumber, 1].ToString()) && (dtPicked.Rows[i][2].ToString() == grdLineToPost[grdLineToPost.CurrentCell.RowNumber, 2].ToString()) && !isFound)
                    {
                        //subtract from summary table
                        //CalculateSummaryTable(dg_stock[dg_stock.CurrentCell.RowNumber, 0].ToString(), dg_stock[dg_stock.CurrentCell.RowNumber, 1].ToString(), "-" + dg_stock[dg_stock.CurrentCell.RowNumber, 2].ToString(), dg_stock[dg_stock.CurrentCell.RowNumber, 3].ToString());
                        // DeleteToSummaryTable(GrdAddline[GrdAddline.CurrentCell.RowNumber, 0].ToString(), GrdAddline[GrdAddline.CurrentCell.RowNumber, 1].ToString(), "-" + GrdAddline[GrdAddline.CurrentCell.RowNumber, 2].ToString(), GrdAddline[GrdAddline.CurrentCell.RowNumber, 3].ToString());
                        //addToSummaryTable(dg_stock[dg_stock.CurrentCell.RowNumber, 0].ToString(), dg_stock[dg_stock.CurrentCell.RowNumber, 1].ToString(), "-" + dg_stock[dg_stock.CurrentCell.RowNumber, 2].ToString());

                        //dtPicked.Rows.RemoveAt(i);
                        //toList.RemoveAt(i);

                        txtEditItem.Text = pickedArray[i].itemNo;
                        txtEditQty.Text = pickedArray[i].quatity.ToString();
                        txtEditBin.Text = pickedArray[i].bin;

                        isFound = true;
                    }
                }

            }
        }

        private int GetNoOfSelectedRows(DataGrid grdLineToPost)
        {
            int count = 0;

            CurrencyManager cm = (CurrencyManager)this.BindingContext[grdLineToPost.DataSource];

            DataView dv = (DataView)cm.List;

            for (int i = 0; i < dv.Count; ++i)
            {

                if (grdLineToPost.IsSelected(i))
                {

                    count++;
                    updatnumber = i;
                }
            }
            return count;
        }

        private void mnuGRNBack_Click(object sender, EventArgs e)
        {
            frmMain frm = new frmMain(Rusername,Rstaffdimen,Ruserlevel);
            frm.Show();
        }

      
        private void btnConfirmUpdate_Click(object sender, EventArgs e)
        {
             Cursor.Current = Cursors.WaitCursor;
             try
             {

                 string itemtocheck = "";
                 FlagpostiveSubsitute = false;

                 QHBinContent.QHBinContent_Service qhsevice = new QHMobile.QHBinContent.QHBinContent_Service();
                 qhsevice.Url = WebServiceInstants.GetURL(ServiceType.QHBinContent);
                 qhsevice.Credentials = nc;

                 QH_Functions.QH_Functions qhfun = new QHMobile.QH_Functions.QH_Functions();
                 qhfun.Url = WebServiceInstants.GetURL(ServiceType.QH_Functions);
                 qhfun.Credentials = nc;

                 List<QHBinContent.QHBinContent_Filter> filterArray = new List<QHMobile.QHBinContent.QHBinContent_Filter>();

                 QHBinContent.QHBinContent_Filter filterBin = new QHMobile.QHBinContent.QHBinContent_Filter();
                 filterBin.Field = QHMobile.QHBinContent.QHBinContent_Fields.Bin_Code;
                 filterBin.Criteria = txtEditBin.Text.Trim();

                 QHBinContent.QHBinContent_Filter fitlerPCS = new QHMobile.QHBinContent.QHBinContent_Filter();
                 fitlerPCS.Field = QHMobile.QHBinContent.QHBinContent_Fields.Unit_of_Measure_Code;
                 fitlerPCS.Criteria = "<>''";

                 filterArray.Add(filterBin);
                 filterArray.Add(fitlerPCS);

                 QHBinContent.QHBinContent[] qhcon = qhsevice.ReadMultiple(filterArray.ToArray(), null, 0);

                 if (qhcon.Length != 0)
                 {
                     for (int i = 0; i < qhcon.Length; i++)
                     {

                         decimal calculate = qhcon[i].Quantity - qhcon[i].PDA_Inv_Pick_Quantity;

                         if (calculate != 0)
                         {
                             itemtocheck = qhcon[i].Item_No;

                         }
                     }
                 }
                 else
                 {
                     itemtocheck = "";
                 }

                 if (itemtocheck == "")
                 {
                     BinQH.BinQH_Service binservice = new QHMobile.BinQH.BinQH_Service();
                     binservice.Url = WebServiceInstants.GetURL(ServiceType.BinQH);
                     binservice.Credentials = nc;

                     BinQH.BinQH binget = binservice.Read(pickedArray[updatnumber].location, txtEditQty.Text);

                     if (binget != null)
                     {
                         pickedArray[updatnumber].conversionpostive = true;

                         pickedArray[updatnumber].bin = txtEditBin.Text;
                         pickedArray[updatnumber].quatity = Convert.ToDecimal(txtEditQty.Text);
                         if (chkEditEmptyTank.Checked == true)
                         {
                             pickedArray[updatnumber].emptyflag = true;
                         }
                         else
                         {
                             pickedArray[updatnumber].emptyflag = false;
                         }

                     }
                     else
                     {
                         MessageBox.Show("You have scan invalid bin.Please try again.");
                         txtEditBin.SelectAll();
                         txtEditBin.Focus();
                     }

                    // MessageBox.Show("Updated Successfully.");
                 }//
                 else
                 {
                     pickedArray[updatnumber].conversionpostive = false;

                     if (txtEditItem.Text.Trim().Equals(itemtocheck))
                     {
                         pickedArray[updatnumber].bin = txtEditBin.Text;
                         pickedArray[updatnumber].quatity = Convert.ToDecimal(txtEditQty.Text);

                         if (chkEditEmptyTank.Checked == true)
                         {
                             pickedArray[updatnumber].emptyflag = true;
                         }
                         else
                         {
                             pickedArray[updatnumber].emptyflag = false;
                         }


                        // MessageBox.Show("Updated Successfully.");
                     }
                     else
                     {
                          var confirmResult = MessageBox.Show("Confirm to Substitute or not?", "Confirmation",
                                 MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1);
                         if (confirmResult == DialogResult.Yes)
                         {
                              CheckItem = qhfun.CheckItemSubstitution(txtItem.Text.Trim(), itemtocheck); // Call Navision
                              if (CheckItem == true)
                              {

                                  pickedArray[updatnumber].substituteTank = txtEditBin.Text.Trim();
                                  pickedArray[updatnumber].bin = txtEditBin.Text.Trim();
                                  pickedArray[updatnumber].substituteItem = itemtocheck;

                                  if (chkEditEmptyTank.Checked == true)
                                  {
                                      pickedArray[updatnumber].emptyflag = true;
                                  }
                                  else
                                  {
                                      pickedArray[updatnumber].emptyflag = false;
                                  }


                                 // MessageBox.Show("Updated Successfully.");
                              }
                              else
                              {
                                  MessageBox.Show("This item not allowed to substitute");
                              }
                         }
                     }
                     dtPicked.Rows.Clear();
                     grdLineToPost.DataSource = null;

                     for (int j = 0; j < pickedArray.Count; j++)
                     {
                         Object[] array = new Object[7];

                         array[0] = pickedArray[j].pwNo;
                         array[1] = pickedArray[j].itemNo;
                         array[2] = pickedArray[j].bin;
                         array[3] = pickedArray[j].quatity;
                         array[4] = pickedArray[j].emptyflag;
                         array[5] = pickedArray[j].proceed;
                         array[6] = pickedArray[j].conversionflag;

                         dtPicked.Rows.Add(array);

                     }

                     grdLineToPost.DataSource = dtPicked;


                     MessageBox.Show("Update Successfully.");

                 }

                 


             }
             catch (Exception ex)
             {
                 MessageBox.Show("PDA Error:" + ex.Message);
             }

             Cursor.Current = Cursors.Default;

             chkEditEmptyTank.Checked = false;
        
        }

        //private void menuItem1_Click_1(object sender, EventArgs e)
        //{
        //    ItemJournalDailyLossQH.ItemJournalDailyLossQH_Service itemSev = new QHMobile.ItemJournalDailyLossQH.ItemJournalDailyLossQH_Service();
        //    itemSev.Credentials = nc;
        //    itemSev.Url = WebServiceInstants.GetURL(ServiceType.ItemJournalDailyLossQH);

        //    for (int i = 0; i < ItemJnlArray.Count; i++)
        //    {
        //        ItemJournalDailyLossQH.ItemJournalDailyLossQH iteminsert = new QHMobile.ItemJournalDailyLossQH.ItemJournalDailyLossQH();
        //        itemSev.Create("DEFAULT", ref iteminsert);

        //        iteminsert.Posting_Date = ItemJnlArray[i].postingDate;
        //        iteminsert.Posting_DateSpecified = true;
        //        iteminsert.Entry_Type = ItemJournalDailyLossQH.Entry_Type.Positive_Adjmt;
        //        iteminsert.Entry_TypeSpecified = true;
        //        iteminsert.Location_Code = ItemJnlArray[i].location;
        //        iteminsert.Item_No = ItemJnlArray[i].itemno;

        //        itemSev.Update("DEFAULT", ref iteminsert);

                
        //        iteminsert.Bin_Code = ItemJnlArray[i].bincode;
                
                
        //        iteminsert.Quantity = Convert.ToInt32(ItemJnlArray[i].quantity);
        //        iteminsert.QuantitySpecified = true;

        //        itemSev.Update("DEFAULT", ref iteminsert);
                

        //    }

        //    MessageBox.Show("Registered Successfully!");

        //}

        private void menuItem2_Click(object sender, EventArgs e)
        {
            PickQH pqh = new PickQH(Rusername, Rstaffdimen, Ruserlevel);
            pqh.Show();
        }

        private void txtBin_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                Cursor.Current = Cursors.WaitCursor;

                try
                {
                    if (chkAutoScan.Checked == false)
                    {
                        MessageBox.Show("Please check the auto scan!");
                    }
                    else
                    {

                        if (!string.IsNullOrEmpty(txtBin.Text.Trim()))
                        {
                            string itemtocheck = "";
                            FlagpostiveSubsitute = false;

                            QHBinContent.QHBinContent_Service qhsevice = new QHMobile.QHBinContent.QHBinContent_Service();
                            qhsevice.Url = WebServiceInstants.GetURL(ServiceType.QHBinContent);
                            qhsevice.Credentials = nc;

                            QH_Functions.QH_Functions qhfun = new QHMobile.QH_Functions.QH_Functions();
                            qhfun.Url = WebServiceInstants.GetURL(ServiceType.QH_Functions);
                            qhfun.Credentials = nc;


                            BinQH.BinQH_Service binservice = new QHMobile.BinQH.BinQH_Service();
                            binservice.Url = WebServiceInstants.GetURL(ServiceType.BinQH);
                            binservice.Credentials = nc;

                            List<BinQH.BinQH_Filter> filterBinArray = new List<QHMobile.BinQH.BinQH_Filter>();

                            BinQH.BinQH_Filter bincodefilter = new QHMobile.BinQH.BinQH_Filter();
                            bincodefilter.Field = QHMobile.BinQH.BinQH_Fields.Code;

                            bincodefilter.Criteria = txtBin.Text;

                            filterBinArray.Add(bincodefilter);

                            BinQH.BinQH[] getbinList = binservice.ReadMultiple(filterBinArray.ToArray(), null, 0);

                            if (getbinList.Length != 0)
                            {

                                if (getbinList[0].Dummy == true)
                                {
                                    MessageBox.Show("Please turn off the auto scan!");
                                }
                                else
                                {

                                    List<QHBinContent.QHBinContent_Filter> filterArray = new List<QHMobile.QHBinContent.QHBinContent_Filter>();

                                    QHBinContent.QHBinContent_Filter filterBin = new QHMobile.QHBinContent.QHBinContent_Filter();
                                    filterBin.Field = QHMobile.QHBinContent.QHBinContent_Fields.Bin_Code;
                                    filterBin.Criteria = txtBin.Text.Trim();

                                    QHBinContent.QHBinContent_Filter fitlerPCS = new QHMobile.QHBinContent.QHBinContent_Filter();
                                    fitlerPCS.Field = QHMobile.QHBinContent.QHBinContent_Fields.Unit_of_Measure_Code;
                                    fitlerPCS.Criteria = "<>''";

                                    filterArray.Add(filterBin);
                                    filterArray.Add(fitlerPCS);

                                    QHBinContent.QHBinContent[] qhcon = qhsevice.ReadMultiple(filterArray.ToArray(), null, 0);

                                    if (qhcon.Length != 0)
                                    {
                                        for (int i = 0; i < qhcon.Length; i++)
                                        {

                                            decimal calculate = qhcon[i].Quantity - qhcon[i].PDA_Inv_Pick_Quantity;

                                            if (calculate != 0)
                                            {
                                                itemtocheck = qhcon[i].Item_No;

                                            }
                                        }
                                    }
                                    else
                                    {
                                        itemtocheck = "";
                                    }

                                    if (itemtocheck == "")
                                    {
                                        //BinQH.BinQH_Service binservice = new QHMobile.BinQH.BinQH_Service();
                                        //binservice.Url = WebServiceInstants.GetURL(ServiceType.BinQH);
                                        //binservice.Credentials = nc;

                                        //BinQH.BinQH binget = binservice.Read(locationNum, txtBin.Text.Trim());

                                        //if (binget != null)
                                        //{

                                        FlagpostiveSubsitute = true;

                                        if (txtPickedQty.Text.Equals(""))
                                        {
                                            NormalPicked();
                                        }
                                        else
                                        {
                                            SplitPick();
                                        }

                                        //}
                                        //else
                                        //{
                                        //    MessageBox.Show("You have scan invalid bin.Please try again.");
                                        //    txtEditBin.SelectAll();
                                        //    txtEditBin.Focus();
                                        //}

                                    }
                                    else
                                    {

                                        if (txtItem.Text.Trim().Equals(itemtocheck))
                                        {
                                            if (txtPickedQty.Text.Equals(""))
                                            {
                                                NormalPicked();
                                            }
                                            else
                                            {
                                                SplitPick();
                                            }
                                        }
                                        else
                                        {
                                            var confirmResult = MessageBox.Show("Confirm to Substitute or not?", "Confirmation",
                                             MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1);

                                            if (confirmResult == DialogResult.Yes)
                                            {
                                                CheckItem = qhfun.CheckItemSubstitution(txtItem.Text.Trim(), itemtocheck); // Call Navision

                                                if (CheckItem == true)
                                                {
                                                    SubstituteItemStr = itemtocheck;

                                                    if (txtPickedQty.Text.Equals(""))
                                                    {
                                                        NormalPicked();
                                                    }
                                                    else
                                                    {
                                                        SplitPick();
                                                    }
                                                }
                                                else
                                                {
                                                    MessageBox.Show("Cannot Substitute by these items.");
                                                }
                                            }
                                            else
                                            {
                                                MessageBox.Show("Please scan the another tank!");
                                                txtBin.Text = "";
                                            }

                                            CheckItem = false;
                                        }

                                    }
                                }
                            }
                            else
                            {
                                MessageBox.Show("The bin you have scanned is not found!");
                            }

                        }

                        else
                        {
                            MessageBox.Show("The bin code is empty. Please scan or enter bin.");
                        }

                        EnableComponent();

                    }
                    
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error:" + ex.Message);
                }

                Cursor.Current = Cursors.Default;
            }
          
        }

        private void CheckItemConversion()
        {
            QHBinContent.QHBinContent_Service qhsevice = new QHMobile.QHBinContent.QHBinContent_Service();
            qhsevice.Url = WebServiceInstants.GetURL(ServiceType.QHBinContent);
            qhsevice.Credentials = nc;

            QH_Functions.QH_Functions qhfun = new QHMobile.QH_Functions.QH_Functions();
            qhfun.Url = WebServiceInstants.GetURL(ServiceType.QH_Functions);
            qhfun.Credentials = nc;

            List<QHBinContent.QHBinContent_Filter> filterArray = new List<QHMobile.QHBinContent.QHBinContent_Filter>();

            QHBinContent.QHBinContent_Filter filterBin = new QHMobile.QHBinContent.QHBinContent_Filter();
            filterBin.Field = QHMobile.QHBinContent.QHBinContent_Fields.Bin_Code;
            filterBin.Criteria = txtBin.Text.Trim();

            filterArray.Add(filterBin);

            QHBinContent.QHBinContent[] qhcon = qhsevice.ReadMultiple(filterArray.ToArray(), null, 0);

            if (qhcon.Length != 0)
            {
                if (!txtItem.Text.Trim().Equals(qhcon[0].Item_No))
                {
                     var confirmResult = MessageBox.Show("Confirm to Substitute or not?", "Confirmation",
                                 MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1);

                     if (confirmResult == DialogResult.Yes)
                     {
                         CheckItem = qhfun.CheckItemSubstitution(txtItem.Text.Trim(), qhcon[0].Item_No);
                     }
                }
            }
            else
            {
                MessageBox.Show("Bin Not Found!");
            }
        }

        private string GetSuggestedBin(string strLoc, string strBin, string strItem, int iQty)
        {
            string retString = "";
            ArrayList binsuggarray = new ArrayList();
            QH_Functions.QH_Functions qhfun = new QHMobile.QH_Functions.QH_Functions();
            qhfun.Url = WebServiceInstants.GetURL(ServiceType.QH_Functions);
            qhfun.Credentials = nc;
            string[] SugBinList = new string[100];

            for (int i = 0; i < 100; i++)
            {
                SugBinList[i] = "-";
            }
            qhfun.GetBinContentAvalBin(strLoc, strBin, strItem, iQty, ref SugBinList);
            for (int i = 0; i < 100; i++)
            {
                if (SugBinList[i] != "-")
                {
                    if (!isPickedBin(SugBinList[i].ToString()))
                    {
                        binsuggarray.Add(SugBinList[i]);
                    }
                }

            }

            if (binsuggarray.Count > 0)
            {
                retString = binsuggarray[0].ToString();
            }
            return retString;
        }
        private bool isPickedBin(string strBin)
        {
            bool retVale = false;
            CurrencyManager cm = (CurrencyManager)this.BindingContext[grdLineToPost.DataSource];

            DataView dv = (DataView)cm.List;

            bool isFound = false;

            for (int i = 0; i < dv.Count && !isFound; ++i)
            {
                if (dv[i][2].ToString() == strBin)
                {
                    retVale = true;
                }
            }
            return retVale;
        }

        private void chkAutoScan_CheckStateChanged(object sender, EventArgs e)
        {
            if (chkAutoScan.Checked)
            {
                FlagAuto = true;
                //btnAdd.Enabled = true;
                //btnAddAll.Enabled = true;
            }
            else
            {
                FlagAuto = false;
                //btnAdd.Enabled = false;
                //btnAddAll.Enabled = false;
            }

        }

        private void btnEditAdd_Click(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;

            try
            {

                string itemtocheck = "";
                FlagpostiveSubsitute = false;
               

                QHBinContent.QHBinContent_Service qhsevice = new QHMobile.QHBinContent.QHBinContent_Service();
                qhsevice.Url = WebServiceInstants.GetURL(ServiceType.QHBinContent);
                qhsevice.Credentials = nc;

                QH_Functions.QH_Functions qhfun = new QHMobile.QH_Functions.QH_Functions();
                qhfun.Url = WebServiceInstants.GetURL(ServiceType.QH_Functions);
                qhfun.Credentials = nc;

                List<QHBinContent.QHBinContent_Filter> filterArray = new List<QHMobile.QHBinContent.QHBinContent_Filter>();

                QHBinContent.QHBinContent_Filter filterBin = new QHMobile.QHBinContent.QHBinContent_Filter();
                filterBin.Field = QHMobile.QHBinContent.QHBinContent_Fields.Bin_Code;
                filterBin.Criteria = txtEditBin.Text.Trim();

                QHBinContent.QHBinContent_Filter fitlerPCS = new QHMobile.QHBinContent.QHBinContent_Filter();
                fitlerPCS.Field = QHMobile.QHBinContent.QHBinContent_Fields.Unit_of_Measure_Code;
                fitlerPCS.Criteria = "<>''";

                filterArray.Add(filterBin);
                filterArray.Add(fitlerPCS);

                QHBinContent.QHBinContent[] qhcon = qhsevice.ReadMultiple(filterArray.ToArray(), null, 0);

                if (qhcon.Length != 0)
                {
                    for (int i = 0; i < qhcon.Length; i++)
                    {

                        decimal calculate = qhcon[i].Quantity - qhcon[i].PDA_Inv_Pick_Quantity;

                        if (calculate != 0)
                        {
                            itemtocheck = qhcon[i].Item_No;

                        }
                    }
                }
                else
                {
                    itemtocheck = "";
                }

                if (itemtocheck == "")
                {
                    BinQH.BinQH_Service binservice = new QHMobile.BinQH.BinQH_Service();
                    binservice.Url = WebServiceInstants.GetURL(ServiceType.BinQH);
                    binservice.Credentials = nc;

                    BinQH.BinQH binget = binservice.Read(pickedArray[updatnumber].location, txtEditQty.Text);

                    if (binget != null)
                    {
                        FlagpostiveSubsitute = true;

                        if (txtPickedQty.Text.Equals(""))
                        {
                            EditNormalPicked();
                        }
                        else
                        {
                            EditSplitPick();
                        }
                    }
                    else
                    {
                        MessageBox.Show("You have scan invalid bin.Please try again.");
                        txtEditBin.SelectAll();
                        txtEditBin.Focus();
                    }
                }
                else
                {

                    if (txtItem.Text.Trim().Equals(itemtocheck))
                    {
                        if (txtPickedQty.Text.Equals(""))
                        {
                            EditNormalPicked();
                        }
                        else
                        {
                            EditSplitPick();
                        }
                    }
                    else
                    {
                        var confirmResult = MessageBox.Show("Confirm to Substitute or not?", "Confirmation",
                         MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1);

                        if (confirmResult == DialogResult.Yes)
                        {
                            CheckItem = qhfun.CheckItemSubstitution(txtItem.Text.Trim(), itemtocheck); // Call Navision

                            if (CheckItem == true)
                            {
                                SubstituteItemStr = itemtocheck;

                                if (txtPickedQty.Text.Equals(""))
                                {
                                    EditNormalPicked();
                                }
                                else
                                {
                                    EditSplitPick();
                                }
                            }
                            else
                            {
                                MessageBox.Show("Cannot Substitute by these items.");
                            }
                        }
                        else
                        {
                            MessageBox.Show("Please scan the another tank!");
                            txtBin.Text = "";
                        }

                        CheckItem = false;
                    }


                }


              
                    //if (lblLineInfo.Text.Equals(txtEditQty.Text))
                    //{
                    //    EditNormalPicked();
                    //}
                    //else
                    //{
                    //    EditSplitPick();
                    //}
                
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            Cursor.Current = Cursors.Default;   
        }

        private void lblStaffDimension_ParentChanged(object sender, EventArgs e)
        {

        }





    }
}