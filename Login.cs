using System;
using System.Linq;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Reflection;
using System.Xml;

namespace QHMobile
{
    public partial class frmLogin : Form
    {
        protected System.Net.NetworkCredential nc = new System.Net.NetworkCredential(WebServiceInstants.GetURL(ServiceType.userName).ToString(), WebServiceInstants.GetURL(ServiceType.password).ToString(), WebServiceInstants.GetURL(ServiceType.domain).ToString());
        public frmLogin()
        {
            InitializeComponent();
        }

        private void menuItemExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void MeuItemLogin_Click(object sender, EventArgs e)
        {
            try
            {
                Cursor.Current = Cursors.WaitCursor;
                QH_Functions.QH_Functions qhfun = new QHMobile.QH_Functions.QH_Functions();
                qhfun.Url = WebServiceInstants.GetURL(ServiceType.QH_Functions);
                qhfun.Credentials = nc;
                if (!qhfun.CompareDate(System.DateTime.Today.Day.ToString(), System.DateTime.Today.Month.ToString(), System.DateTime.Today.Year.ToString()))
                {
                    MessageBox.Show("Plase check your PDA date!");
                    return;
                    Cursor.Current = Cursors.Default;
                }

                if (!txtUserID.Text.Equals("") && !txtPassword.Text.Equals(""))
                {

                    string tempuser = txtUserID.Text;
                    string temppassword = txtPassword.Text;


                    UsersQH.UsersQH_Service serviceUser = new QHMobile.UsersQH.UsersQH_Service();
                    serviceUser.Url = WebServiceInstants.GetURL(ServiceType.UsersQH);
                    serviceUser.Credentials = nc;

                    UsersQH.UsersQH user = serviceUser.Read(tempuser);

                    if (user != null)
                    {

                        if (temppassword.Equals(user.Password))
                        {
                            LoginInformation linfo = new LoginInformation();
                            linfo.loginpassword = user.Password;
                            linfo.loginuser = user.UserName;
                            linfo.staffdimension = user.Stuff_Dimension;
                            linfo.userlevel = user.UserLevel.ToString();

                            Cursor.Current = Cursors.Default;
                            SaveToConfig();
                            frmMain msc = new frmMain(linfo.loginuser, linfo.loginpassword, linfo.staffdimension, linfo.userlevel);
                            msc.Show();
                            this.Hide();

                        }
                        else
                        {
                            MessageBox.Show("Password is wrong.");
                            Cursor.Current = Cursors.Default;

                        }
                    }
                    else
                    {
                        MessageBox.Show("User Not Found!");
                        
                    }

                }
                else
                {
                    MessageBox.Show("Please enter User Name and password.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
            Cursor.Current = Cursors.Default;


        }
        private void SaveToConfig()
        {
            try
            {
                if (chkRememberMe.Checked)
                {
                    string ApplicationPath = Path.GetDirectoryName(
                        Assembly.GetExecutingAssembly().GetName().CodeBase);

                    XmlDocument xmlDoc = new XmlDocument();
                    xmlDoc.Load(ApplicationPath + "\\config.xml");
                    xmlDoc.SelectSingleNode("/config/remUser").InnerText = txtUserID.Text.Trim();
                    xmlDoc.SelectSingleNode("/config/remPassword").InnerText = txtPassword.Text.Trim();

                    xmlDoc.Save(ApplicationPath + "\\config.xml");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
        }



        private void frmLogin_Load(object sender, EventArgs e)
        {
            //WebServiceInstants.GetURL(ServiceType.userName
            txtUserID.Text = WebServiceInstants.GetURL(ServiceType.remUser);
            txtPassword.Text = WebServiceInstants.GetURL(ServiceType.remPassword);

        }

        private void txtPassword_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {

                if (!txtUserID.Text.Equals("") && !txtPassword.Text.Equals(""))
                {

                    Cursor.Current = Cursors.WaitCursor;
                    QH_Functions.QH_Functions qhfun = new QHMobile.QH_Functions.QH_Functions();
                    qhfun.Url = WebServiceInstants.GetURL(ServiceType.QH_Functions);
                    qhfun.Credentials = nc;
                    if (!qhfun.CompareDate(System.DateTime.Today.Day.ToString(), System.DateTime.Today.Month.ToString(), System.DateTime.Today.Year.ToString()))
                    {
                        MessageBox.Show("Plase check your PDA date!");
                        Cursor.Current = Cursors.Default;
                        return;
                        
                    }

                    string tempuser = txtUserID.Text;
                    string temppassword = txtPassword.Text;


                    UsersQH.UsersQH_Service serviceUser = new QHMobile.UsersQH.UsersQH_Service();
                    serviceUser.Url = WebServiceInstants.GetURL(ServiceType.UsersQH);
                    serviceUser.Credentials = nc;

                    UsersQH.UsersQH user = serviceUser.Read(tempuser);

                    if (user != null)
                    {

                        if (temppassword.Equals(user.Password))
                        {
                            LoginInformation linfo = new LoginInformation();
                            linfo.loginpassword = user.Password;
                            linfo.loginuser = user.UserName;
                            linfo.staffdimension = user.Stuff_Dimension;
                            linfo.userlevel = user.UserLevel.ToString();

                            Cursor.Current = Cursors.Default;

                            frmMain msc = new frmMain(linfo.loginuser, linfo.loginpassword, linfo.staffdimension, linfo.userlevel);
                            msc.Show();
                            this.Hide();

                        }
                        else
                        {
                            MessageBox.Show("Password is wrong.");
                            Cursor.Current = Cursors.Default;

                        }
                    }
                    else
                    {
                        MessageBox.Show("User Not Found!");
                        Cursor.Current = Cursors.Default;
                    }



                }
                else
                {
                    MessageBox.Show("Please enter User Name and password.");
                }


            }
        }


    }
}