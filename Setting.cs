using System;
using System.Linq;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Net;

namespace QHMobile
{
    public partial class frmSetting : Form
    {
        //protected System.Net.NetworkCredential nc = new System.Net.NetworkCredential(frmMain.mainControl.ServiceUser, frmMain.mainControl.Servicepassword, frmMain.mainControl.DomainName);
        protected System.Net.NetworkCredential nc = new System.Net.NetworkCredential("", "", "");
        public frmSetting()
        {
            InitializeComponent();
        }

        private void Setting_Load(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.Default;
            /*
            try
            {
                txtSvcUser.Text = "admin"; frmMain.mainControl.ServiceUser.ToString();
                txtsvcPassword.Text = "a1d2m3"; frmMain.mainControl.Servicepassword.ToString();
                txtDomain.Text = "QHtest"; frmMain.mainControl.DomainName.ToString();
                if (!String.IsNullOrEmpty(frmMain.mainControl.ServiceURL.ToString()))
                {
                    txtSvcURL.Text = "http://....";//frmMain.mainControl.ServiceURL.ToString();
                    cboCompanyDatabinding();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
                //frmMain.mainControl.WriteToLogFile(ex.Message.ToString());
            }
            Cursor.Current = Cursors.Default;
            */
        }
        private void cboCompanyDatabinding()
        {
            //string baseURL = frmMain.mainControl.ServiceURL.ToString();
            //SystemServiceRef.SystemService systemService = new SystemServiceRef.SystemService();
            //systemService.Url = baseURL.Replace("Services", "SystemService");
            //systemService.Credentials = nc;
            //string[] companies = systemService.Companies();
            //cboCompanyName.DataSource = companies;
            //cboCompanyName.DisplayMember = companies[0];
            //cboCompanyName.SelectedItem = frmMain.mainControl.CompanyName.ToString();
        }

        private void mnuSaveSetting_Click(object sender, EventArgs e)
        {
           // MessageBox.Show(cboCompanyName.SelectedValue.ToString());
            //frmMain.mainControl.UpdateConfigFile(cboCompanyName.SelectedText.ToString(), frmMain.mainControl.UserName.ToString(), frmMain.mainControl.Password.ToString(),txtSvcUser.Text.ToString(), txtsvcPassword.Text.ToString(), txtDomain.Text.ToString(), txtSvcURL.Text.ToString());
        }

        private void mnuMain_Click(object sender, EventArgs e)
        {
            this.Close();
        }





    }
}