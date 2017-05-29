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
    public partial class PickSlip : Form
    {
        protected DataTable dt = new DataTable("MyTable");
        protected DataTable dtSo = new DataTable("MyTable1");
        //string q1 = "No";
        //string q2 = "No";
        //string q3 = "No";


        protected System.Net.NetworkCredential nc = new System.Net.NetworkCredential("admin", "bingo28", "dptech");
        public PickSlip()
        {
            InitializeComponent();
            txtTO.Focus();
            cboLine.Enabled = false;
            //  txtQuantity.Enabled = false;

            dt.Columns.Add(new DataColumn("Item No."));
            dt.Columns.Add(new DataColumn("Description"));
            dt.Columns.Add(new DataColumn("Quantity"));
            dt.Columns.Add(new DataColumn("BinCode"));

            dtSo.Columns.Add(new DataColumn("Item No."));
            dtSo.Columns.Add(new DataColumn("Description"));
            dtSo.Columns.Add(new DataColumn("Order Qty"));
            dtSo.Columns.Add(new DataColumn("Bin Code"));
            dtSo.Columns.Add(new DataColumn("Price"));
            dtSo.Columns.Add(new DataColumn("UOM"));

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
            PickSlip grn = new PickSlip();
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

        //private DataGridTableStyle DataGridStyle(DataTable dTable)
        //{
        //    DataGridTableStyle ts = new DataGridTableStyle();
        //    ts.MappingName = dTable.TableName;

        //    DataGridColumnStyle s1 = new DataGridTextBoxColumn();
        //    s1.Width = 90;
        //    s1.MappingName = "Item No.";
        //    s1.HeaderText = "Item No.";
        //    ts.GridColumnStyles.Add(s1);
        //    DataGridColumnStyle s2 = new DataGridTextBoxColumn();
        //    s2.Width = 60;
        //    s2.MappingName = "From";
        //    s2.HeaderText = "From";
        //    ts.GridColumnStyles.Add(s2);
        //    DataGridColumnStyle s3 = new DataGridTextBoxColumn();
        //    s3.Width = 80;
        //    s3.MappingName = "To";
        //    s3.HeaderText = "To";
        //    ts.GridColumnStyles.Add(s3);
        //    DataGridColumnStyle s33 = new DataGridTextBoxColumn();
        //    s33.Width = 60;
        //    s33.MappingName = "Quantity";
        //    s33.HeaderText = "Quantity";
        //    ts.GridColumnStyles.Add(s33);
        //    DataGridColumnStyle s4 = new DataGridTextBoxColumn();
        //    s4.Width = 80;
        //    s4.MappingName = "UOM";
        //    s4.HeaderText = "UOM";
        //    ts.GridColumnStyles.Add(s4);
        //    DataGridColumnStyle s5 = new DataGridTextBoxColumn();
        //    s5.Width = 60;
        //    s5.MappingName = "Description";
        //    s5.HeaderText = "Description";
        //    ts.GridColumnStyles.Add(s5);
        //    DataGridColumnStyle s6 = new DataGridTextBoxColumn();
        //    s6.Width = 80;
        //    s6.MappingName = "BinCode";
        //    s6.HeaderText = "Bin Code";
        //    ts.GridColumnStyles.Add(s6);

        //    return ts;
        //}


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
                string desc = "";
                if (cboLine.SelectedIndex == 0)
                {
                    desc = "OF SUPER KOI STICK 12G";
                }
                else if (cboLine.SelectedIndex == 1)
                {
                    desc = "OF SUPER KOI STICK 13G";
                }
                else
                {
                    desc = "OF SUPER KOI STICK 14G";
                }

                Cursor.Current = Cursors.WaitCursor;

                object[] array = new object[4];

                array[0] = cboLine.SelectedItem.ToString();
                array[1] = desc;
                array[2] = txtQty.Text.Trim();
                array[3] = cboBin.SelectedItem.ToString();

                dt.Rows.Add(array);

                dgGRNLine.DataSource = dt;
                dgGRNLine.BackColor = Color.SkyBlue;

                //dgGRNLine.TableStyles.Clear();
                //dgGRNLine.TableStyles.Add(DataGridStyle(dt));

                Cursor.Current = Cursors.Default;

            }
            catch (Exception ex)
            {
                string s = ex.Message;
            }
            /*
            try
            {
                if (cboLine.SelectedIndex == 0)
                {
                    q1 = "Yes";
                    Insert_Record(q1.ToString(), q2.ToString(), q3.ToString());
                }
                else if (cboLine.SelectedIndex == 1)
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
             */
        }

        private void menuItem1_Click(object sender, EventArgs e)
        {
            this.Close();
            PickSlip grn = new PickSlip();
            grn.ShowDialog();
        }

        private void dgGRNLine_CurrentCellChanged(object sender, EventArgs e)
        {

        }

        //private void Insert_Record(string q1, string q2, string q3)
        //{
        //    dt.Rows.Clear();

        //    object[] array = new object[6];

        //    array[0] = "Item01";
        //    array[2] = "222";
        //    array[4] = "Bottle";
        //    array[5] = "OF SUPER KOI STICK 12G";

        //    dt.Rows.Add(array);

        //    object[] array2 = new object[6];

        //    array2[0] = "Item02";
        //    array[1] = "111";
        //    array[2] = "222";
        //    array2[3] = q2;
        //    array2[4] = "Bottle";
        //    array2[5] = "OF SUPER KOI STICK 12G";

        //    dt.Rows.Add(array2);


        //    object[] array3 = new object[6];

        //    array3[0] = "Item03";
        //    array[1] = "111";
        //    array[2] = "222";
        //    array3[3] = q3;
        //    array3[4] = "Bottle";
        //    array3[5] = "OF SUPER KOI STICK 12G";

        //    dt.Rows.Add(array3);

        //    //lblCount.Text = "( " + dt.Rows.Count.ToString() + " )";

        //    dgGRNLine.DataSource = null;
        //    dgGRNLine.DataSource = dt;
        //    dgGRNLine.BackColor = Color.SkyBlue;

        //    Cursor.Current = Cursors.Default;

        //}

        private void Insert_SOLines()
        {
            dtSo.Rows.Clear();

            object[] array = new object[6];
            array[0] = "Item01";
            array[1] = "OF SUPER KOI STICK 12G";
            array[2] = "111";
            array[3] = "Bin1";
            array[4] = "120.50";
            array[5] = "Bottle";
            dtSo.Rows.Add(array);

            object[] array2 = new object[6];

            array2[0] = "Item02";
            array2[1] = "OF SUPER KOI STICK 13G";
            array2[2] = "222";
            array2[3] = "Bin2";
            array2[4] = "120.50";
            array2[5] = "Bottle";

            dtSo.Rows.Add(array2);

            object[] array3 = new object[6];

            array3[0] = "Item03";
            array3[1] = "OF SUPER KOI STICK 14G";
            array3[2] = "333";
            array3[3] = "Bin3";
            array3[4] = "120.50";
            array3[5] = "Bottle";

            dtSo.Rows.Add(array3);

            //lblCount.Text = "( " + dt.Rows.Count.ToString() + " )";

            dgSOLines.DataSource = null;
            dgSOLines.DataSource = dtSo;
            dgSOLines.BackColor = Color.SkyBlue;

            Cursor.Current = Cursors.Default;

        }
        private void txtTO_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                cboLine.Enabled = true;
                cboBin.Enabled = true;
                lblAccountNo.Text = "AC0123";
                lblSaleMan.Text = "Hsu";
                lblToLoc.Text = "ABC";
                lblDate.Text = "12/12/2012";

                //Insert_Record(q1.ToString(), q2.ToString(), q3.ToString());
                Insert_SOLines();

                cboLine.Items.Clear();
                cboBin.Items.Clear();

                cboLine.Items.Add("Item01");
                cboLine.Items.Add("Item02");
                cboLine.Items.Add("Item03");

                cboBin.Items.Add("Bin1");
                cboBin.Items.Add("Bin2");
                cboBin.Items.Add("Bin3");

                txtTO.Enabled = false;

            }


        }


    }
}