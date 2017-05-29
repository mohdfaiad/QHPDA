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
    public partial class TO : Form
    {

        protected DataTable dt = new DataTable("MyTable");
        int q1 = 1;
        int q2 = 2;
        int q3 = 3;


        protected System.Net.NetworkCredential nc = new System.Net.NetworkCredential("admin", "bingo28", "dptech");
        public TO()
        {
            InitializeComponent();
            txtTO.Focus();
            cboLine.Enabled = false;
            //  txtQuantity.Enabled = false;

            dt.Columns.Add(new DataColumn("Item No."));
            dt.Columns.Add(new DataColumn("From"));
            dt.Columns.Add(new DataColumn("To"));
            dt.Columns.Add(new DataColumn("Quantity"));
            dt.Columns.Add(new DataColumn("UOM"));
            dt.Columns.Add(new DataColumn("Description"));



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
            TO grn = new TO();
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

        private DataGridTableStyle DataGridStyle(DataTable dTable)
        {
            DataGridTableStyle ts = new DataGridTableStyle();
            ts.MappingName = dTable.TableName;

            DataGridColumnStyle s1 = new DataGridTextBoxColumn();
            s1.Width = 90;
            s1.MappingName = "Item No.";
            s1.HeaderText = "Item No.";
            ts.GridColumnStyles.Add(s1);
            DataGridColumnStyle s2 = new DataGridTextBoxColumn();
            s2.Width = 60;
            s2.MappingName = "From";
            s2.HeaderText = "From";
            ts.GridColumnStyles.Add(s2);
            DataGridColumnStyle s3 = new DataGridTextBoxColumn();
            s3.Width = 80;
            s3.MappingName = "To";
            s3.HeaderText = "To";
            ts.GridColumnStyles.Add(s3);
            DataGridColumnStyle s33 = new DataGridTextBoxColumn();
            s33.Width = 60;
            s33.MappingName = "Quantity";
            s33.HeaderText = "Quantity";
            ts.GridColumnStyles.Add(s33);
            DataGridColumnStyle s4 = new DataGridTextBoxColumn();
            s4.Width = 80;
            s4.MappingName = "UOM";
            s4.HeaderText = "UOM";
            ts.GridColumnStyles.Add(s4);
            DataGridColumnStyle s5 = new DataGridTextBoxColumn();
            s5.Width = 60;
            s5.MappingName = "Description";
            s5.HeaderText = "Description";
            ts.GridColumnStyles.Add(s5);
            DataGridColumnStyle s6 = new DataGridTextBoxColumn();
            s6.Width = 80;
            s6.MappingName = "BinCode";
            s6.HeaderText = "Bin Code";
            ts.GridColumnStyles.Add(s6);

            return ts;
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
            /*
            Cursor.Current = Cursors.WaitCursor;
            PoCard.POCard_Service poCrdSvc = new RGSMobile.PoCard.POCard_Service();
            poCrdSvc.Credentials = nc;
            PoCard.POCard poCd = poCrdSvc.Read(txtStaffNo.Text.Trim());

            for (int i = 0; i < POlinesScanIndex.Count; i++)
            {
                int iVal = Convert.ToInt16(POlinesScanIndex[i]);

                poCd.PurchLines[iVal].ScanedSpecified = true;
                poCd.PurchLines[iVal].Scaned = true;
            }

            bool bSuccess = false;
            try
            {
                poCrdSvc.Update(ref poCd);
                bSuccess = true;
            }
            catch (Exception ex)
            {
                Cursor.Current = Cursors.Default;
                MessageBox.Show("Failed. " + ex.Message);
            }
            if (bSuccess)
            {
                Cursor.Current = Cursors.Default;
                MessageBox.Show("Successfully registered.");
                //menuItem3_Click(null, null);
                this.Close();
                StockTake newScan = new StockTake();
                newScan.ShowDialog();
            }

            */
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                if (cboLine.SelectedIndex == 0)
                {
                    q1 = int.Parse(txtqty.Text.Trim());
                    Insert_Record(q1.ToString(), q2.ToString(), q3.ToString());
                }
                else if (cboLine.SelectedIndex == 1)
                {
                    q2 = int.Parse(txtqty.Text.Trim());
                    Insert_Record(q1.ToString(), q2.ToString(), q3.ToString());
                }
                else
                {
                    q3 = int.Parse(txtqty.Text.Trim());
                    Insert_Record(q1.ToString(), q2.ToString(), q3.ToString());
                }
                //if (cboLine.SelectedIndex != null)
                //{
                //    Cursor.Current = Cursors.WaitCursor;

                //    for (int i = 0; i < dt.Rows.Count; i++)
                //    {
                //        string temp = dt.Rows[i].ItemArray[0].ToString();
                //        string temp2 = cboLine.SelectedItem.ToString();
                //        if (dt.Rows[i].ItemArray[0].ToString() == temp2)
                //        {
                //            //string temp = dt.Rows[i].ItemArray[0].ToString(); 
                //            dt.Rows[i].ItemArray[3] = txtqty.Text.ToString();
                //        }
                //    }
                //}


            }
            catch (Exception ex)
            {
                string s = ex.Message;
            }
        }

        private void menuItem1_Click(object sender, EventArgs e)
        {
            this.Close();
            TO grn = new TO();
            grn.ShowDialog();
        }

        private void dgGRNLine_CurrentCellChanged(object sender, EventArgs e)
        {

        }

        private void Insert_Record(string q1, string q2, string q3)
        {
            dt.Rows.Clear();

            object[] array = new object[6];

            array[0] = "Item01";
            array[1] = txtfrom.Text.Trim();
            array[2] = txtTOWhere.Text.Trim();
            array[3] = q1;
            array[4] = "Bottle";
            array[5] = "OF SUPER KOI STICK 12G";

            dt.Rows.Add(array);

            object[] array2 = new object[6];

            array2[0] = "Item02";
            array2[1] = txtfrom.Text.Trim();
            array2[2] = txtTOWhere.Text.Trim();
            array2[3] = q2;
            array2[4] = "Bottle";
            array2[5] = "OF SUPER KOI STICK 12G";

            dt.Rows.Add(array2);


            object[] array3 = new object[6];

            array3[0] = "Item03";
            array3[1] = txtfrom.Text.Trim();
            array3[2] = txtTOWhere.Text.Trim();
            array3[3] = q3;
            array3[4] = "Bottle";
            array3[5] = "OF SUPER KOI STICK 12G";

            dt.Rows.Add(array3);

            lblCount.Text = "( " + dt.Rows.Count.ToString() + " )";

            dgGRNLine.DataSource = null;
            dgGRNLine.DataSource = dt;
            dgGRNLine.BackColor = Color.SkyBlue;

            Cursor.Current = Cursors.Default;

        }
        private void txtTO_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                cboLine.Enabled = true;
                txtfrom.Text = "Location1";
                txtTOWhere.Text = "Location2";

                Insert_Record(q1.ToString(), q2.ToString(), q3.ToString());

                cboLine.Items.Add("Item01");
                cboLine.Items.Add("Item02");
                cboLine.Items.Add("Item03");
            }

        }


    }
}