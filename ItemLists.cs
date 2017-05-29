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
    public partial class ItemLists : Form
    {
        string tocheckItemName;
        protected System.Net.NetworkCredential nc = new System.Net.NetworkCredential(WebServiceInstants.GetURL(ServiceType.userName).ToString(), WebServiceInstants.GetURL(ServiceType.password).ToString(), WebServiceInstants.GetURL(ServiceType.domain).ToString());

        string Rname, Rstaffdimen, Rslevel;
        List<DailyLossFormTS> CurrentArray = new List<DailyLossFormTS>();
        DailyLossFormTS currentRds = new DailyLossFormTS();
        public ItemLists(string staffname, string staffdim, string stafflevel, List<DailyLossFormTS> RDL_Array,DailyLossFormTS currentdts)
        {
            InitializeComponent();
            tocheckItemName = currentdts.itemno;
            Rname = staffname;
            Rstaffdimen = staffdim;
            Rslevel = stafflevel;
            CurrentArray = RDL_Array;
            currentRds = currentdts;
            BindListControl();

           Cursor.Current = Cursors.Default;


        }

        private void BindListControl()
        {
            ItemQH.ItemQH_Service itemSev = new QHMobile.ItemQH.ItemQH_Service();
            itemSev.Url=WebServiceInstants.GetURL(ServiceType.ItemQH);
            itemSev.Credentials = nc;

            List<ItemQH.ItemQH_Filter> filterArray = new List<QHMobile.ItemQH.ItemQH_Filter>();
            
            ItemQH.ItemQH_Filter filter = new QHMobile.ItemQH.ItemQH_Filter();
            filter.Field = QHMobile.ItemQH.ItemQH_Fields.No;
            filter.Criteria = tocheckItemName + "*";

            filterArray.Add(filter);

            ItemQH.ItemQH[] itemArray = itemSev.ReadMultiple(filterArray.ToArray(), null, 0);

            for (int i = 0; i < itemArray.Length; i++)
            {
                lstItem.Items.Add(itemArray[i].No + "~" + itemArray[i].Description); 
            }

            //MessageBox.Show("Please choose one item from the list and click OK!");

        }

        private void btnSubmit_Click(object sender, EventArgs e)
        {
            currentRds.itemno = lstItem.SelectedItem.ToString();
            DailyLossTS dls = new DailyLossTS(Rname,Rstaffdimen,Rslevel, CurrentArray,currentRds);
            dls.Show();

        }



    }
}