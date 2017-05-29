using System;
using System.Linq;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace QHMobile
{
    public partial class VendorList : Form
    {
        protected System.Net.NetworkCredential nc = new System.Net.NetworkCredential(WebServiceInstants.GetURL(ServiceType.userName).ToString(), WebServiceInstants.GetURL(ServiceType.password).ToString(), WebServiceInstants.GetURL(ServiceType.domain).ToString());

        VendorListQH.VendorListQH[] vendorArray;

        string vendorNumber;
        string Ruser, Rstaffdimension, Rstafflevel;


        public VendorList(string vendorname,string vuser, string vstaffdimension, string vstafflevel)
        {
            InitializeComponent();
            BindtoList(vendorname);
            Ruser = vuser;
            Rstaffdimension = vstaffdimension;
            Rstafflevel = vstafflevel;

            lstVendorList.SelectedItem = null;
         
        }

        private void BindtoList(string vendorname)
        {
            Cursor.Current = Cursors.WaitCursor;

            VendorListQH.VendorListQH_Service vdrSev = new QHMobile.VendorListQH.VendorListQH_Service();
            vdrSev.Url = WebServiceInstants.GetURL(ServiceType.VendorListQH);
            vdrSev.Credentials = nc;

            List<VendorListQH.VendorListQH_Filter> vArray = new List<QHMobile.VendorListQH.VendorListQH_Filter>();

            VendorListQH.VendorListQH_Filter vfilter = new QHMobile.VendorListQH.VendorListQH_Filter();
            vfilter.Field = QHMobile.VendorListQH.VendorListQH_Fields.Name;
            vfilter.Criteria = vendorname + "*";

            vArray.Add(vfilter);

            vendorArray = vdrSev.ReadMultiple(vArray.ToArray(), null, 0);

            for (var i = 0; i < vendorArray.Length; i++)
            {
                if (vendorArray[i].Name != null)
                {
                    lstVendorList.Items.Add(vendorArray[i].Name);
                }
            }

            Cursor.Current = Cursors.Default;

          //  MessageBox.Show("Parse Ok!");
        }

        private void lstVendorList_SelectedIndexChanged(object sender, EventArgs e)
        {
            for (int i = 0; i < vendorArray.Length; i++)
            {
                if (lstVendorList.SelectedItem.ToString().Equals(vendorArray[i].Name))
                {
                    vendorNumber = vendorArray[i].No;
                    lblVendorNo.Text= "Vendor No: " + vendorArray[i].No;
                }
            }
        }

        private void btnSubmit_Click(object sender, EventArgs e)
        {
            try
            {
                PurChaseOrder pco = new PurChaseOrder(lstVendorList.SelectedItem.ToString(), vendorNumber, Ruser, Rstaffdimension, Rstafflevel);
                pco.Show();

            }catch (Exception ex)
            {
                MessageBox.Show("Please select the vendor first!");
            }
         
        }

        private void butcancel_Click(object sender, EventArgs e)
        {
            this.Close();
            PurChaseOrder pco = new PurChaseOrder(Ruser, Rstaffdimension, Rstafflevel);
            pco.Show();
            //PurChaseOrder pco = new PurChaseOrder(
        }
    }
}