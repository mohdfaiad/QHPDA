using System;
using System.Linq;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlServerCe;
using System.Text.RegularExpressions;
using System.Collections;

namespace QHMobile
{
    public partial class BlockBin : Form
    {
        protected DataTable dt;
        protected System.Net.NetworkCredential nc = new System.Net.NetworkCredential(WebServiceInstants.GetURL(ServiceType.userName).ToString(), WebServiceInstants.GetURL(ServiceType.password).ToString(), WebServiceInstants.GetURL(ServiceType.domain).ToString());
        string staffdim, username, userlevel;
        public BlockBin(string userd, string staffd, string uleveld)
        {
            InitializeComponent();
            staffdim = staffd;
            username = userd;
            userlevel = uleveld;

            lblStaffName.Text = staffdim + "/ Role:" + userlevel;
            txtBinNo.Focus();
        }

        private void NoBinFound()
        {
            Cursor.Current = Cursors.Default;
            lblCount.Text = "(0)";
            gdBins.DataSource = null;
            MessageBox.Show("No bin found.");
        }

        private DataGridTableStyle DataGridStyle(DataTable dTable)
        {
            DataGridTableStyle ts = new DataGridTableStyle();
            ts.MappingName = dTable.TableName;

            DataGridColumnStyle s1 = new DataGridTextBoxColumn();
            s1.Width = 70;
            s1.MappingName = "BinCode";
            s1.HeaderText = "Bin Code";
            ts.GridColumnStyles.Add(s1);

            DataGridColumnStyle s2 = new DataGridTextBoxColumn();
            s2.Width = 100;
            s2.MappingName = "LocationCode";
            s2.HeaderText = "Locatin Code";
            ts.GridColumnStyles.Add(s2);

            DataGridColumnStyle s22 = new DataGridTextBoxColumn();
            s22.Width = 90;
            s22.MappingName = "BlockMovement";
            s22.HeaderText = "Block Movement";
            ts.GridColumnStyles.Add(s22);

            return ts;
        }

        private void mnuGRNBack_Click(object sender, EventArgs e)
        {
            frmMain msc = new frmMain(username, staffdim, userlevel);
            msc.Show();
        }

        private void MnuBlockBin_Click(object sender, EventArgs e)
        {
            try
            {
                Cursor.Current = Cursors.WaitCursor;
                BinQH.BinQH_Service binserv = new QHMobile.BinQH.BinQH_Service();
                binserv.Url = WebServiceInstants.GetURL(ServiceType.BinQH);
                binserv.Credentials = nc;
                if (dt.Rows.Count > 0)
                {
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        BinQH.BinQH binupdate = binserv.Read(dt.Rows[i][1].ToString(), dt.Rows[i][0].ToString());
                        binupdate.Block_MovementSpecified = true;
                        if (dt.Rows[i][2].ToString().Trim() == "All")
                        {
                            binupdate.Block_Movement = BinQH.Block_Movement._blank_;
                        }
                        else
                        {
                            binupdate.Block_Movement = BinQH.Block_Movement.All;
                        }
                        binserv.Update(ref binupdate);


                    }
                    BindToGrid();
                    MessageBox.Show("Update Successfully!");

                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }
        private void BindToGrid()
        {
            try
            {
                if (!String.IsNullOrEmpty(txtBinNo.Text.Trim()))
                {
                   
                    dt = new DataTable("BlockBin");

                    dt.Columns.Add("BinCode");
                    dt.Columns.Add("LocationCode");
                    dt.Columns.Add("BlockMovement");

                    BinQH.BinQH_Service binserv = new QHMobile.BinQH.BinQH_Service();
                    binserv.Url = WebServiceInstants.GetURL(ServiceType.BinQH);
                    binserv.Credentials = nc;

                    List<BinQH.BinQH_Filter> arrayBinFilter = new List<BinQH.BinQH_Filter>();

                    BinQH.BinQH_Filter FilterBin = new QHMobile.BinQH.BinQH_Filter();
                    FilterBin.Field = QHMobile.BinQH.BinQH_Fields.Code;
                    FilterBin.Criteria = txtBinNo.Text.Trim();
                    arrayBinFilter.Add(FilterBin);

                    BinQH.BinQH[] BinList = binserv.ReadMultiple(arrayBinFilter.ToArray(), null, 0);
                    if (BinList.Length > 0)
                    {
                        dt.Clear();
                        lblCount.Text = "(" + BinList.Length.ToString() + ")";
                        for (int i = 0; i < BinList.Length; i++)
                        {
                            if (BinList[i].Location_Code != BinList[i].Code)
                            {
                                Object[] array = new Object[3];
                                array[0] = BinList[i].Code;
                                array[1] = BinList[i].Location_Code;
                                array[2] = BinList[i].Block_Movement.ToString();
                                dt.Rows.Add(array);
                            }

                        }
                        gdBins.DataSource = dt;
                        gdBins.TableStyles.Clear();
                        gdBins.TableStyles.Add(DataGridStyle(dt));
                        Cursor.Current = Cursors.Default;


                    }
                    else
                    {
                        NoBinFound();
                    }
                }

            }
            catch (Exception ex)
            {
                Cursor.Current = Cursors.Default;
                MessageBox.Show(ex.Message);
            }


        }

        private void txtBinNo_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                try
                {
                    Cursor.Current = Cursors.WaitCursor;
                    dt = new DataTable("BlockBin");

                    dt.Columns.Add("BinCode");
                    dt.Columns.Add("LocationCode");
                    dt.Columns.Add("BlockMovement");
                    //List<BinQH.BinQH> Lbin = new List<QHMobile.BinQH.BinQH>();

                    BinQH.BinQH_Service binserv = new QHMobile.BinQH.BinQH_Service();
                    binserv.Url = WebServiceInstants.GetURL(ServiceType.BinQH);
                    binserv.Credentials = nc;
                    
                    List<BinQH.BinQH_Filter> arrayBinFilter = new List<BinQH.BinQH_Filter>();

                    BinQH.BinQH_Filter FilterBin = new QHMobile.BinQH.BinQH_Filter();
                    FilterBin.Field = QHMobile.BinQH.BinQH_Fields.Code;
                    FilterBin.Criteria = txtBinNo.Text.Trim();
                    arrayBinFilter.Add(FilterBin);

                    //BinQH.BinQH_Filter FilterBlock = new QHMobile.BinQH.BinQH_Filter();
                    //FilterBlock.Field = QHMobile.BinQH.BinQH_Fields.Block_Movement;
                    //FilterBlock.Criteria = BinQH.Block_Movement._blank_.ToString();
                    //arrayBinFilter.Add(FilterBlock);

                    BinQH.BinQH[] BinList = binserv.ReadMultiple(arrayBinFilter.ToArray(), null, 0);
                    if (BinList.Length > 0)
                    {
                        dt.Clear();
                        lblCount.Text = "(" + BinList.Length.ToString() + ")";
                        for (int i = 0; i < BinList.Length; i++)
                        {
                            if (BinList[i].Location_Code != BinList[i].Code)
                            {
                                Object[] array = new Object[3];
                                array[0] = BinList[i].Code;
                                array[1] = BinList[i].Location_Code;
                                array[2] = BinList[i].Block_Movement.ToString();
                                dt.Rows.Add(array);
                            }

                        }
                        gdBins.DataSource = dt;
                        gdBins.TableStyles.Clear();
                        gdBins.TableStyles.Add(DataGridStyle(dt));
                        Cursor.Current = Cursors.Default;

                    }
                    else
                    {
                        NoBinFound();
                    }

                }
                catch (Exception ex)
                {
                    Cursor.Current = Cursors.Default;
                    MessageBox.Show(ex.Message);
                }
            }
        }
    }
}