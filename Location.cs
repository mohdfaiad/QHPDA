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
    public partial class Location : Form
    {
        protected System.Net.NetworkCredential nc = new System.Net.NetworkCredential(WebServiceInstants.GetURL(ServiceType.userName).ToString(), WebServiceInstants.GetURL(ServiceType.password).ToString(), WebServiceInstants.GetURL(ServiceType.domain).ToString());

        string staffdimension;


        public Location(string staffdim)
        {
            InitializeComponent();
            staffdimension = staffdim;
        }

        private void Location_KeyDown(object sender, KeyEventArgs e)
        {
            if ((e.KeyCode == System.Windows.Forms.Keys.Up))
            {
                // Up
            }
            if ((e.KeyCode == System.Windows.Forms.Keys.Down))
            {
                // Down
            }
            if ((e.KeyCode == System.Windows.Forms.Keys.Left))
            {
                // Left
            }
            if ((e.KeyCode == System.Windows.Forms.Keys.Right))
            {
                // Right
            }
            if ((e.KeyCode == System.Windows.Forms.Keys.Enter))
            {
                // Enter
            }

        }

        private void btnEnter_Click(object sender, EventArgs e)
        {
            
            QH_Location.QH_Location_Service qhserv = new QHMobile.QH_Location.QH_Location_Service();
            qhserv.Url = WebServiceInstants.GetURL(ServiceType.QH_Location);
            qhserv.Credentials = nc;

            QH_Location.QH_Location qhloc = qhserv.Read(textBox1.Text.Trim());

            if (qhloc != null)
            {
               // QHMobile.StockTake fGRN = new StockTake(staffdimension);
                //fGRN.ShowDialog();
            }
            else
            {
                MessageBox.Show("Location was not found. Please try again.");
            }

        }
    }
}