using System;
using System.Linq;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Text.RegularExpressions;

namespace QHMobile
{
    public partial class POAssignBinList : Form
    {
        protected System.Net.NetworkCredential nc = new System.Net.NetworkCredential(WebServiceInstants.GetURL(ServiceType.userName).ToString(), WebServiceInstants.GetURL(ServiceType.password).ToString(), WebServiceInstants.GetURL(ServiceType.domain).ToString());

        string staffname, staffdimension, stafflevel;

        string locationTopass;

        public POAssignBinList(string sname, string sdimension, string slevel)
        {
            InitializeComponent();
            staffname = sname;
            staffdimension = sdimension;
            stafflevel = slevel;
            //DateTime d = DateTime.Now;
            txtDate.Text = DateTime.Now.ToString("MM/dd/yy");

        }
        private void button1_Click(object sender, EventArgs e)
        {
            if (cboPoList.SelectedItem.ToString().Equals(""))
            {
            }
            else
            {
                Cursor.Current = Cursors.WaitCursor;

                string potemp = "QHPO" + cboPoList.SelectedItem.ToString();

                string s = potemp;
                string[] words = s.Split('~');
                string strLocationLocation;
                s = words[0];
                strLocationLocation = words[3].ToString();


                PurchaseQH.PurchaseQH_Service poserv = new QHMobile.PurchaseQH.PurchaseQH_Service();
                poserv.Url = WebServiceInstants.GetURL(ServiceType.PurchaseQH);
                poserv.Credentials = nc;

                PurchaseQH.PurchaseQH poRecord = poserv.Read(s);


                //POAssignBin po = new POAssignBin(staffname, staffdimension, stafflevel, potemp,poRecord.Location_Code);
                POAssignBin po = new POAssignBin(staffname, staffdimension, stafflevel, potemp, strLocationLocation);
                
                po.Show();

                Cursor.Current = Cursors.Default;
            }
        }

        private void menuItem1_Click(object sender, EventArgs e)
        {
            frmMain frmMain = new frmMain(staffname, staffdimension, stafflevel);
            frmMain.Show();
        }
       

        private void btnGetPo_Click(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
            try
            {
                if (!string.IsNullOrEmpty(txtDate.Text.Trim()))
                {
                    cboPoList.Items.Clear();
                    WarehouseRequestQH.WarehouseRequestQH_Service requestSev = new QHMobile.WarehouseRequestQH.WarehouseRequestQH_Service();
                    requestSev.Url = WebServiceInstants.GetURL(ServiceType.WarehouseRequestQH);
                    requestSev.Credentials = nc;

                    List<QHMobile.WarehouseRequestQH.WarehouseRequestQH_Filter> Whfilterarray = new List<QHMobile.WarehouseRequestQH.WarehouseRequestQH_Filter>();

                    WarehouseRequestQH.WarehouseRequestQH_Filter whF1 = new QHMobile.WarehouseRequestQH.WarehouseRequestQH_Filter();
                    whF1.Field = QHMobile.WarehouseRequestQH.WarehouseRequestQH_Fields.Type;
                    whF1.Criteria = "Inbound";
                    Whfilterarray.Add(whF1);

                    WarehouseRequestQH.WarehouseRequestQH_Filter whF2 = new QHMobile.WarehouseRequestQH.WarehouseRequestQH_Filter();
                    whF2.Field = QHMobile.WarehouseRequestQH.WarehouseRequestQH_Fields.Expected_Receipt_Date;
                    whF2.Criteria = txtDate.Text;
                    Whfilterarray.Add(whF2);

                    WarehouseRequestQH.WarehouseRequestQH_Filter whF3 = new QHMobile.WarehouseRequestQH.WarehouseRequestQH_Filter();
                    whF3.Field = QHMobile.WarehouseRequestQH.WarehouseRequestQH_Fields.Completely_Handled;
                    whF3.Criteria = "false";
                    Whfilterarray.Add(whF3);

                    WarehouseRequestQH.WarehouseRequestQH_Filter whF4 = new QHMobile.WarehouseRequestQH.WarehouseRequestQH_Filter();
                    whF4.Field = QHMobile.WarehouseRequestQH.WarehouseRequestQH_Fields.Source_Document;
                    whF4.Criteria = QHMobile.WarehouseRequestQH.Source_Document.Purchase_Order.ToString();
                    Whfilterarray.Add(whF4);

                    WarehouseRequestQH.WarehouseRequestQH[] comboRequest = requestSev.ReadMultiple(Whfilterarray.ToArray(), null, 0);
                    if (comboRequest.Length > 0)
                    {

                        for (int i = 0; i < comboRequest.Length; i++)
                        {
                            PurchaseQH.PurchaseQH_Service poserv = new QHMobile.PurchaseQH.PurchaseQH_Service();
                            poserv.Url = WebServiceInstants.GetURL(ServiceType.PurchaseQH);
                            poserv.Credentials = nc;

                            PurchaseQH.PurchaseQH po = poserv.Read(comboRequest[i].Source_No.ToString());
                            string v = po.Buy_from_Vendor_Name.ToString();
                            v = v.Substring(0, 5);

                            string ponumber = comboRequest[i].Source_No.Substring(4);

                            cboPoList.Items.Add(ponumber + "~" + po.Buy_from_Vendor_No + "~" + v + "~" + comboRequest[i].Location_Code.ToString());
                            
                        }
                        button1.Enabled = true;
                        cboPoList.Enabled = true;
                        Cursor.Current = Cursors.WaitCursor;
       
                    }
                    else
                    {
                        Cursor.Current = Cursors.WaitCursor;
                        MessageBox.Show("There is no PO.");
                    }

                }
                else
                {
                    Cursor.Current = Cursors.WaitCursor;
                    MessageBox.Show("Please Key in the Date");
                }
                

            }
            catch (Exception ex)
            {
                Cursor.Current = Cursors.WaitCursor;
                MessageBox.Show(ex.Message);
            }


            Cursor.Current = Cursors.Default;

        }

     
    }
}