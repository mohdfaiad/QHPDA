using System;
using System.Linq;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlServerCe;

namespace RGSMobile
{
    public partial class PickingSlip : Form
    {

        protected DataTable dt = new DataTable("MyTable");
        String q1 = "";
        String q2 = "";
        String q3 = "";


        protected System.Net.NetworkCredential nc = new System.Net.NetworkCredential("admin", "bingo28", "dptech");
        
        public PickingSlip()
        {
            InitializeComponent();
           
            //  txtQuantity.Enabled = false;

            dt.Columns.Add(new DataColumn("Item Code"));
            dt.Columns.Add(new DataColumn("Description"));
            dt.Columns.Add(new DataColumn("OrderQty"));
            dt.Columns.Add(new DataColumn("FOC"));
            dt.Columns.Add(new DataColumn("Qty"));
            dt.Columns.Add(new DataColumn("Price"));
            dt.Columns.Add(new DataColumn("Location"));
            dt.Columns.Add(new DataColumn("Bar Code"));


        }

        private void mnuGRNBack_Click(object sender, EventArgs e)
        {
            this.Close();
            //RGSMobile.frmMain frmMain = new frmMain();
            //frmMain.ShowDialog();
        }
        private void menuItem3_Click(object sender, EventArgs e)
        {
            this.Close();
            DailyLoss grn = new DailyLoss();
            grn.ShowDialog();

        }

        private void frmGRN_Load(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.Default;

        }
        private void insertCustomer()
        {
            SqlCeConnection conn = null;
            try
            {
                string path;
                path = System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().GetName().CodeBase);
                conn = new SqlCeConnection("Data Source = " + path + "\\Data\\RGSMobileDB.sdf;" + "Password ='pass@word1'");

                conn.Open();

            }
            finally
            {
                conn.Close();
            }
        }



        private string EscalateValue(string Val)
        {
            if (String.IsNullOrEmpty(Val))
            {
                return "";
            }
            else
            {
                return Val;
            }
        }

       

        private string SplitString(string strInput)
        {
            char[] aChar = strInput.ToCharArray();
            Array.Reverse(aChar);
            string strResult = new string(aChar);
            return strResult;
        }

        private void menRegToNav_Click(object sender, EventArgs e)
        {
           
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                if (cboItemList.SelectedIndex == 0)
                {
                    q1 = "Yes";
                    Insert_Record(q1.ToString(), q2.ToString(), q3.ToString());
                }
                else if (cboItemList.SelectedIndex == 1)
                {
                    q2 = "Yes";
                    Insert_Record(q1.ToString(), q2.ToString(), q3.ToString());
                }
                else
                {
                    q3 = "Yes";
                    Insert_Record(q1.ToString(), q2.ToString(), q3.ToString());
                }
               
            }
            catch (Exception ex)
            {
                string s = ex.Message;
            }
        }

        private void menuItem1_Click(object sender, EventArgs e)
        {
            this.Close();
            PickingSlip grn = new PickingSlip();
            grn.ShowDialog();
        }


        private void Insert_Record(string q1, string q2, string q3)
        {
            dt.Rows.Clear();

            object[] array = new object[6];

            array[0] = "Item01";
            array[1] = "OF CLEAR CHECK VALUE";
            array[2] = "0.00";
            array[3] = "0";
            array[4] = "2";
            array[5] = "0.00";
            array[6] = "";
            array[7] = "99877444098";
            array[8] = q1;

            dt.Rows.Add(array);

            object[] array2 = new object[6];

            array2[0] = "Item02";
            array2[1] = "OF CLEAR CHECK VALUE";
            array2[2] = "0.00";
            array2[3] = "0";
            array2[4] = "2";
            array2[5] = "0.00";
            array2[6] = "";
            array2[7] = "99877444098";
            array2[8] = q2;

            dt.Rows.Add(array2);


            object[] array3 = new object[6];

            array3[0] = "Item03";
            array3[1] = "OF CLEAR CHECK VALUE";
            array3[2] = "0.00";
            array3[3] = "0";
            array3[4] = "2";
            array3[5] = "0.00";
            array3[6] = "";
            array3[7] = "99877444098";
            array3[8] = q3;

            dt.Rows.Add(array3);

            lblCount.Text = "( " + dt.Rows.Count.ToString() + " )";

            dgGRNLine.DataSource = null;
            dgGRNLine.DataSource = dt;
            dgGRNLine.BackColor = Color.SkyBlue;

            Cursor.Current = Cursors.Default;

        }
        //private void txtTO_KeyDown(object sender, KeyEventArgs e)
        //{
        //    if (e.KeyCode == Keys.Enter)
        //    {
        //        //cboLine.Enabled = true;
        //        //txtfrom.Text = "Singapore";
        //        //txtTOWhere.Text = "Malaysia";

        //        //Insert_Record(q1.ToString(), q2.ToString(), q3.ToString());

        //        //cboLine.Items.Add("Item01");
        //        //cboLine.Items.Add("Item02");
        //        //cboLine.Items.Add("Item03");
        //    }

        //}

 

        private void txtTO_KeyDown_1(object sender, KeyEventArgs e)
        {
            lblAccountNo.Text = "Ä011";
            lblToAdd.Text = "AH SOON";
            lblDate.Text = "19 December 2011";
            cboItemList.Items.Add("Item01");
            cboItemList.Items.Add("Item02");
            cboItemList.Items.Add("Item03");
            cboBin.Items.Add("Bin01");
            cboBin.Items.Add("Bin02");
            cboBin.Items.Add("Bin03");
            txtTO.Enabled = false;


        }


    }
}