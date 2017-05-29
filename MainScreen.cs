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
    public partial class MainScreen : Form
    {
        string usng,staffdimg, uslvelg;

        public MainScreen(string usn,string psd,string staffdim, string uslvel)
        {
            //InitializeComponent();

            //lblUserName.Text = usn;

            //lblUL.Text = uslvel;
            //lblUserDimension.Text = staffdim;

            //usng = usn;
            //staffdimg = staffdim;
            //uslvelg = uslvel;

            //MessageBox.Show(usn + psd+ staffdim+uslvel);
        }

        public MainScreen()
        {
            //InitializeComponent();
        }

        private void btnStockTake_Click(object sender, EventArgs e)
        {
            //StockTake stk = new StockTake();
            //stk.Show();
        }

        private void btnPOAssignBin_Click(object sender, EventArgs e)
        {
            //POAssignBin po = new POAssignBin();
            //po.Show();
        }

        private void btnLedgerTransfer_Click(object sender, EventArgs e)
        {
            //TransferOrder toledger = new TransferOrder(usng, staffdimg, uslvelg);
            //toledger.Show();
        }

        private void btnTransferOrder_Click(object sender, EventArgs e)
        {
            //CreateTO cto = new CreateTO(usng, staffdimg, uslvelg);
            //cto.Show();
        }

        private void label5_ParentChanged(object sender, EventArgs e)
        {

        }

        private void label6_ParentChanged(object sender, EventArgs e)
        {

        }

        private void btnDailyLoss_Click(object sender, EventArgs e)
        {
            //DailyLoss dlf = new DailyLoss(usng,staffdimg,uslvelg);
            //dlf.Show();
        }

        private void btnDailyLossTS_Click(object sender, EventArgs e)
        {
            //DailyLossTS dilts = new DailyLossTS(usng, staffdimg, uslvelg);
           // DailyLossTS dilts = new DailyLossTS();
            //dilts.Show();

        }

        private void btnPKQH_Click(object sender, EventArgs e)
        {
            //PickingSlip ps = new PickingSlip();
            //ps.Show();
        }
    }
}


