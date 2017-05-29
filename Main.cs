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
    public partial class frmMain : Form
    {
        public static MainControl mainControl;
        string usng, staffdimg, uslvelg;

        public frmMain(string username,string staffdim, string userlevel)
        {
            //mainControl = new MainControl();
            InitializeComponent();
            this.staffdimg = staffdim;
            this.usng = username;
            this.uslvelg = userlevel;

            //if(!userlevel.Equals("Super"))
            //{
               // pictureBox5.Hide();
            //}
        }

       
        public frmMain(string usn, string psd, string staffdim, string uslvel)
        {
            InitializeComponent();

            //lblUserName.Text = usn;

            //lblUL.Text = uslvel;
            //lblUserDimension.Text = staffdim;

            usng = usn;
            staffdimg = staffdim;
            uslvelg = uslvel;

            //MessageBox.Show(usn + psd+ staffdim+uslvel);
        }


        private void txt_Shipment_GotFocus(object sender, EventArgs e)
        {

        }

        private void txt_Receipt_TextChanged(object sender, EventArgs e)
        {

        }

        private void menuItemBinContent_Click(object sender, EventArgs e)
        {

        }

        private void menuItemSetting_Click(object sender, EventArgs e)
        {

        }

        private void menuItemBinMovement_Click(object sender, EventArgs e)
        {

        }

        private void menuItemReceipt_Click(object sender, EventArgs e)
        {

        }

        private void menuItemShipment_Click(object sender, EventArgs e)
        {

        }

        private void menuItemPost_Click(object sender, EventArgs e)
        {

        }

        private void menuItemGenerate_Click(object sender, EventArgs e)
        {

        }

        private void menuItemSyn_Click(object sender, EventArgs e)
        {

        }

        private void picture_Exit_Click_1(object sender, EventArgs e)
        {

        }

        private void txt_Exit_KeyDown(object sender, KeyEventArgs e)
        {

        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            //Location loc = new Location();
            //loc.Show();

            Cursor.Current = Cursors.WaitCursor;
            StockTake stk = new StockTake(usng, staffdimg, uslvelg);
            stk.Show();
            Cursor.Current = Cursors.Default;

        }

        private void frmMain_Load(object sender, EventArgs e)
        {
           
        }

        private void pictureSetting_Click(object sender, EventArgs e)
        {
           
        }

        private void pictureSODelivery_Click(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
            DailyLoss dlf = new DailyLoss(usng, staffdimg, uslvelg);
            dlf.Show();
            Cursor.Current = Cursors.Default;
        }
        private void pictureBoxTR_Click(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
            TransferOrder toledger = new TransferOrder(usng, staffdimg, uslvelg);
            toledger.Show();
            Cursor.Current = Cursors.Default;
        }

        private void pictureToReceive_Click(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
            PickQH pqh = new PickQH(usng, staffdimg, uslvelg);
            pqh.Show();
            Cursor.Current = Cursors.Default;
        }

        private void pictureBoxExit_Click(object sender, EventArgs e)
        {
            //this.Close();
            //Application.Exit();
            Cursor.Current = Cursors.WaitCursor;
            frmLogin frmlogin = new frmLogin();
            frmlogin.Show();
            Cursor.Current = Cursors.Default;
        }

        private void pictureBoxSetting_Click(object sender, EventArgs e)
        {
           
        }

        private void picturePOAssignBin_Click(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
            POAssignBinList polist = new POAssignBinList(usng, staffdimg, uslvelg);
            polist.Show();
            Cursor.Current = Cursors.Default;
            //POAssignBin po = new POAssignBin(usng, staffdimg, uslvelg);
            //po.Show();
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
            DailyLossTS dilts = new DailyLossTS(usng, staffdimg, uslvelg);
            dilts.Show();
            Cursor.Current = Cursors.Default;
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
            CreateTO cto = new CreateTO(usng, staffdimg, uslvelg);
            cto.Show();
            Cursor.Current = Cursors.Default;
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
            PurChaseOrder po = new PurChaseOrder(usng, staffdimg, uslvelg);
            po.Show();
            Cursor.Current = Cursors.Default;
        }

        private void label8_ParentChanged(object sender, EventArgs e)
        {
           
        }

        private void pictureBox5_Click(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;

            if (!uslvelg.Equals("Super"))
            {
                MessageBox.Show("This function is used for supervisor only.");
            }
            else
            {
                DailyLPost dlp = new DailyLPost(usng, staffdimg, uslvelg);
                dlp.Show();
            }

            Cursor.Current = Cursors.Default;
        }

       

        private void pictureBox7_Click(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
            EmptyBin soEmptyBin = new EmptyBin(usng, staffdimg, uslvelg);
            soEmptyBin.Show();
            Cursor.Current = Cursors.Default;

        }

        private void pictureBox6_Click(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
            SOPickingQH soPick = new SOPickingQH(usng, staffdimg, uslvelg);
            soPick.Show();
            Cursor.Current = Cursors.Default;
        }

        private void pictureBox8_Click(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
            BlockBin blockBin = new BlockBin(usng, staffdimg, uslvelg);
            blockBin.Show();
            Cursor.Current = Cursors.Default;

        }

        private void pictureBox9_Click(object sender, EventArgs e)
        {

        }

       

       
    }
}