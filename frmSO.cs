using System;
using System.Linq;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace RGSMobile
{
    public partial class frmSO : Form
    {
        public frmSO()
        {
            InitializeComponent();
        }

        private void txtGRNScan_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtGRNScan_KeyDown(object sender, KeyEventArgs e)
        {

        }

        private void menuItem3_Click(object sender, EventArgs e)
        {

        }

        private void mnuGRNBack_Click(object sender, EventArgs e)
        {

        }

        private void txtSOScan_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                try
                {
                   /* Cursor.Current = Cursors.WaitCursor;
                    txtGRNScan.Enabled = false;
                    PoCard.POCard_Service poCrdSvc = new RGSMobile.PoCard.POCard_Service();
                    poCrdSvc.Credentials = nc;
                    PoCard.POCard poC = poCrdSvc.Read(txtGRNScan.Text.Trim().ToString());
                    poLines = poC.PurchLines;
                    txtVendorShipmentNo.Text = poC.Vendor_Shipment_No;
                    txtPODate.Text = poC.Document_Date.ToShortDateString();
                    txtBatchNo.Enabled = true;

                    dgGRNLine.DataSource = poLines;
                    //dgGRNLine.BackColor = Color.Blue;

                    txtBatchNo.Focus();
                    Cursor.Current = Cursors.Default;
                    */
                }
                catch (Exception ex)
                {
                    string s = ex.Message;
                }
            }
        }

        private void frmSO_Load(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.Default;
        }

        private void mnuMain_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void txtScanNo_KeyDown(object sender, KeyEventArgs e)
        {

        }

      
    }
}