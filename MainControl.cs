using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Reflection;
using System.Xml;
using System.Windows.Forms;

namespace QHMobile
{

    public class MainControl
    {
        public string UserName;
        public string Password;
        public string ServiceUser;
        public string Servicepassword;
        public string DomainName;
        public string ApplicationPath;
        public string ServiceURL;
        public string CompanyName;


        public MainControl()
        {
            InitMainControl();
        }
        public void InitMainControl()
        {
            ApplicationPath = GetApplicationPath();
            XmlDocument xmlDoc;
            try
            {
                xmlDoc = new XmlDocument();
                if (!System.IO.File.Exists(ApplicationPath + "\\config.xml"))
                {
                    MessageBox.Show("The config.xml file is not exist.\n Cannot Start the Application!");
                    Application.Exit();
                }


                xmlDoc.Load(ApplicationPath + "\\config.xml");
                UserName = xmlDoc.SelectSingleNode("/config/UserName").InnerText;
                string strPassword = xmlDoc.SelectSingleNode("/config/Password").InnerText;
                if ("".Equals(strPassword))
                {
                    Password = "";
                }
                else
                {
                    //Password = Encrypt.Decrypto(strPassword);
                    Password = strPassword;
                }
                //add service user
                if (!String.IsNullOrEmpty(xmlDoc.SelectSingleNode("/config/ServiceUser").InnerText))
                {
                    ServiceUser = xmlDoc.SelectSingleNode("/config/ServiceUser").InnerText;
                }
                else
                {
                    ServiceUser = "";
                }

                //add service password
                if (!String.IsNullOrEmpty(xmlDoc.SelectSingleNode("/config/Servicepassword").InnerText))
                {
                    Servicepassword = xmlDoc.SelectSingleNode("/config/Servicepassword").InnerText;
                }
                else
                {
                    Servicepassword = "";
                }

                //add service Domain
                if (!String.IsNullOrEmpty(xmlDoc.SelectSingleNode("/config/DomainName").InnerText))
                {
                    DomainName = xmlDoc.SelectSingleNode("/config/DomainName").InnerText;
                }
                else
                {
                    DomainName = "";
                }

                //add service URL
                if (!String.IsNullOrEmpty(xmlDoc.SelectSingleNode("/config/Serviceurl").InnerText))
                {
                    ServiceURL = xmlDoc.SelectSingleNode("/config/Serviceurl").InnerText;
                }
                else
                {
                    ServiceURL = "";
                }

                //add service Company Name
                if (!String.IsNullOrEmpty(xmlDoc.SelectSingleNode("/config/Company").InnerText))
                {
                    CompanyName = xmlDoc.SelectSingleNode("/config/Company").InnerText;
                }
                else
                {
                    CompanyName = "";
                }

            }
            catch (Exception ex)
            {
                WriteToLogFile(ex.Message.ToString());
            }
            finally
            {
                xmlDoc = null;
            }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <returns>current appliation path</returns>
        public string GetApplicationPath()
        {
            return Path.GetDirectoryName(
                Assembly.GetExecutingAssembly().GetName().CodeBase);
        }

        /// <summary>
        /// This function it to keep the log file
        /// </summary>
        /// <param name="LogInfo"></param>
        public void WriteToLogFile(string LogInfo)
        {
            string strLogFile = ApplicationPath + "\\QHMobile.log";

            StreamWriter writer = new StreamWriter(strLogFile, true);
            writer.WriteLine(DateTime.Now.ToString() + "::" + LogInfo);
            writer.Close();

            FileInfo fileInfo = new FileInfo(strLogFile);
            if (fileInfo.Length > 10240)
            {
                fileInfo.Delete();
            }
        }

        public void UpdateConfigFile(string CmpName, string UsrName, string Pwd,
            string svcUserName, string svcPassword, string Domain, string WebServiceAddress)
        {
            this.CompanyName = CmpName;
            this.UserName = UsrName;
            this.Password = Pwd;
            this.ServiceUser = svcUserName;
            this.Servicepassword = svcPassword;
            this.DomainName = Domain;
            this.ServiceURL = WebServiceAddress;
            XmlDocument xmlDoc;
            try
            {
                string ApplicationPath = Path.GetDirectoryName(
                    Assembly.GetExecutingAssembly().GetName().CodeBase);

                xmlDoc = new XmlDocument();
                xmlDoc.Load(ApplicationPath + "\\config.xml");
                xmlDoc.SelectSingleNode("/config/UserName").InnerText = UserName;
                xmlDoc.SelectSingleNode("/config/Password").InnerText = Pwd;
                xmlDoc.SelectSingleNode("/config/DomainName").InnerText = Domain;
                xmlDoc.SelectSingleNode("/config/ServiceUser").InnerText = svcUserName;
                xmlDoc.SelectSingleNode("/config/Servicepassword").InnerText = svcPassword;
                xmlDoc.SelectSingleNode("/config/Serviceurl").InnerText = WebServiceAddress;
                xmlDoc.SelectSingleNode("/config/Company").InnerText = CmpName;
                xmlDoc.Save(ApplicationPath + "\\config.xml");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
            finally
            {
                xmlDoc = null;
            }

        }

    }


}
