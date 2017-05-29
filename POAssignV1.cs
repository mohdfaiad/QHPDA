using System;
using System.Linq;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Collections;
using System.Data.SqlServerCe;

namespace QHMobile
{
    public partial class POAssignV1 : Form
    {
        string RstName, Rstdimension, RstLevel;
        protected System.Net.NetworkCredential nc = new System.Net.NetworkCredential(WebServiceInstants.GetURL(ServiceType.userName).ToString(), WebServiceInstants.GetURL(ServiceType.password).ToString(), WebServiceInstants.GetURL(ServiceType.domain).ToString());
        string TONumber, PutNumber;

        protected DataTable dt = new DataTable("MyTable");
        protected DataTable dtPo = new DataTable("MyTable1");
        protected DataTable dtassigned = new DataTable("MyTable1");

        List<QHMobile.POModule> pomod = new List<POModule>();
        List<QHMobile.POModule> assignPOList = new List<POModule>();


        SqlCeDataReader getallrecords;

        public POAssignV1(string Rstaffname, string Rstaffdimen, string Rstafflevel, string ponumber)
        {
            InitializeComponent();
            CleanArray();

            RstName = Rstaffname;
            Rstdimension = Rstaffdimen;
            RstLevel = Rstafflevel;

            dtPo.Columns.Add(new DataColumn("Line No"));
            dtPo.Columns.Add(new DataColumn("Item No."));
            dtPo.Columns.Add(new DataColumn("Description"));
            dtPo.Columns.Add(new DataColumn("Quantity"));
            dtPo.Columns.Add(new DataColumn("Location"));

            dt.Columns.Add(new DataColumn("Line No"));
            dt.Columns.Add(new DataColumn("Item No."));
            dt.Columns.Add(new DataColumn("Description"));
            dt.Columns.Add(new DataColumn("Quantity"));
            dt.Columns.Add(new DataColumn("Location"));
            dt.Columns.Add(new DataColumn("Bin"));

            string[] po= AssignPO(ponumber);
            TONumber= txtTO.Text = po[0];

            CompactSQL comsql = new CompactSQL();
            getallrecords = comsql.SelectRecordPOAssign("POAssign", TONumber);

            if (getallrecords.Read())
            {
                MessageBox.Show("Here has got SQL value!");
                GetRecordsFromSQL(getallrecords);
            }
            else
            {
                CheckPO();
            }
                      
        }

        private void GetRecordsFromSQL(SqlCeDataReader getallrecords)
        {
            do
            {
                Object[] array = new Object[6];
                QHMobile.POModule assignPO = new POModule();

                assignPO.lineno = Convert.ToInt32(getallrecords["LineNo"]);
                array[0] = getallrecords["LineNo"].ToString();

                array[1] = getallrecords["itemNo"].ToString();
                assignPO.itemNo = getallrecords["itemNo"].ToString();
                array[2] = getallrecords["Description"].ToString();
                assignPO.description = getallrecords["Description"].ToString();
                array[3] = getallrecords["Quantity"].ToString();
                assignPO.quantity = Convert.ToInt32(getallrecords["Quantity"]);
                array[4] = getallrecords["Location"].ToString();
                assignPO.location = getallrecords["Location"].ToString();
                array[5] = getallrecords["BinCode"].ToString();
                assignPO.bin = getallrecords["BinCode"].ToString();

                dt.Rows.Add(array);
                assignPOList.Add(assignPO);

            } while (getallrecords.Read());

            GrdTO.DataSource = dt;

        }

       

        private void CheckPO()
        {
            WhseLineQH.WhseLineQH_Service whserv = new QHMobile.WhseLineQH.WhseLineQH_Service();
            whserv.Url = WebServiceInstants.GetURL(ServiceType.WhseLineQH);
            whserv.Credentials = nc;

            List<WhseLineQH.WhseLineQH_Filter> filter = new List<QHMobile.WhseLineQH.WhseLineQH_Filter>();

            WhseLineQH.WhseLineQH_Filter filtersource = new QHMobile.WhseLineQH.WhseLineQH_Filter();
            filtersource.Field = QHMobile.WhseLineQH.WhseLineQH_Fields.Source_No;
            filtersource.Criteria = txtTO.Text.Trim();

            filter.Add(filtersource);

            WhseLineQH.WhseLineQH[] linearray = whserv.ReadMultiple(filter.ToArray(), null, 0);

            if (linearray.Length < 1)
            {
                CreatePutAway();
            }
            else
            {
                UpdatePutAway(linearray);
            }
        }

        private void UpdatePutAway(QHMobile.WhseLineQH.WhseLineQH[] linearray)
        {
            try
            {

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void CreatePutAway()
        {
            try
            {

                PutAlwaysQH.PutAlwaysQH_Service putSev = new QHMobile.PutAlwaysQH.PutAlwaysQH_Service();
                putSev.Url = WebServiceInstants.GetURL(ServiceType.PutAlwaysQH);
                putSev.Credentials = nc;

                PurchaseQH.PurchaseQH_Service poservice = new QHMobile.PurchaseQH.PurchaseQH_Service();
                poservice.Url = WebServiceInstants.GetURL(ServiceType.PurchaseQH);
                poservice.Credentials = nc;

                PutAlwaysQH.PutAlwaysQH putAwayCreate = new QHMobile.PutAlwaysQH.PutAlwaysQH();
                PurchaseQH.PurchaseQH poRead = poservice.Read(TONumber);

                putSev.Create(ref putAwayCreate);
                PutNumber = putAwayCreate.No;

                putAwayCreate.Source_Document = QHMobile.PutAlwaysQH.Source_Document.Purchase_Order;
                putAwayCreate.Location_Code = "QH1";//poRead.Location_Code;
                putSev.Update(ref putAwayCreate);
                
                putAwayCreate.Source_No = txtTO.Text.Trim();
                putSev.Update(ref putAwayCreate);
               

                PutAlwaysLinesQH.PutAlwaysLinesQH_Service lineservice = new QHMobile.PutAlwaysLinesQH.PutAlwaysLinesQH_Service();
                lineservice.Url = WebServiceInstants.GetURL(ServiceType.PutAlwaysLinesQH);
                lineservice.Credentials = nc;

                List<PutAlwaysLinesQH.PutAlwaysLinesQH_Filter> filterArray = new List<QHMobile.PutAlwaysLinesQH.PutAlwaysLinesQH_Filter>();

                PutAlwaysLinesQH.PutAlwaysLinesQH_Filter fitlerNumber = new PutAlwaysLinesQH.PutAlwaysLinesQH_Filter();
                fitlerNumber.Field = PutAlwaysLinesQH.PutAlwaysLinesQH_Fields.No;
                fitlerNumber.Criteria = PutNumber;

                filterArray.Add(fitlerNumber);

                PutAlwaysLinesQH.PutAlwaysLinesQH[] GridPutAwayLines = lineservice.ReadMultiple(filterArray.ToArray(), null, 0);


                for (int k = 0; k < GridPutAwayLines.Length; k++)
                {
                    PutAlwaysLinesQH.PutAlwaysLinesQH toUpdate = new QHMobile.PutAlwaysLinesQH.PutAlwaysLinesQH();
                    toUpdate = lineservice.Read(PutAlwaysLinesQH.Activity_Type.Invt_Put_away.ToString(), PutNumber, GridPutAwayLines[k].Line_No);
                    toUpdate.Bin_Code = null;
                    lineservice.Update(ref toUpdate);
                 
                }

                PutAlwaysLinesQH.PutAlwaysLinesQH[] PutAwayRead = lineservice.ReadMultiple(filterArray.ToArray(), null, 0);

                for (int i = 0; i < PutAwayRead.Length; i++)
                {
    
                    QHMobile.POModule po = new POModule();

                    po.itemNo = PutAwayRead[i].Item_No;
                    po.lineno = PutAwayRead[i].Line_No;
                    po.description = PutAwayRead[i].Description;
                    po.location = PutAwayRead[i].Location_Code;
                    po.quantity = PutAwayRead[i].Quantity;
                   
                    pomod.Add(po);
                }

                BindToGridLines(pomod);
                
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            
        }

                  
        private void BindToGridLines(List<QHMobile.POModule> poReceive)
        {
            try
            {
                ArrayList comboarray = new ArrayList();

                for (int i = 0; i < poReceive.Count; i++)
                {
                    Object[] array = new Object[5];

                    array[0] = poReceive[i].lineno;
                    array[1] = poReceive[i].itemNo;
                    array[2] = poReceive[i].description;
                    array[3] = poReceive[i].quantity;
                    array[4] = poReceive[i].location;

                    comboarray.Add(new AddComboValue(poReceive[i].itemNo, poReceive[i].lineno));
                    dtPo.Rows.Add(array);
                }


                this.txtScanItemNo.DataSource = comboarray;
                this.txtScanItemNo.DisplayMember = "Display";
                this.txtScanItemNo.ValueMember = "Value";
                lblTotalQty.Text = "Total Qty is of this item: " + poReceive[0].quantity;

                GrdPoLines.DataSource = dtPo;
               

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private string[] AssignPO(string ponumber)
        {
            string[] words = ponumber.Split('~');
            
            return words;
        }
      
        private void CleanArray()
        {
            // to clear the cache 
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            Object[] array = new Object[6];

            for (int j = 0; j < pomod.Count; j++)
            {
                if (txtScanItemNo.SelectedValue.ToString().Equals(pomod[j].lineno.ToString()))
                {
                    
                    QHMobile.POModule assignPO = new POModule();

                    array[0] = pomod[j].lineno;
                    assignPO.lineno = pomod[j].lineno;
                    array[1] = pomod[j].itemNo;
                    assignPO.itemNo = pomod[j].itemNo;
                    array[2] = pomod[j].description;
                    assignPO.description = pomod[j].description;
                    array[3] = txtqty.Text.Trim();
                    assignPO.quantity = Convert.ToDecimal(txtqty.Text.Trim());
                    array[4] = txtlocation.Text.Trim();
                    assignPO.location = txtlocation.Text.Trim();
                    array[5] = txtbin.Text.Trim();
                    assignPO.bin = txtbin.Text.Trim();

                    dt.Rows.Add(array);
                    assignPOList.Add(assignPO);

                    CompactSQL compa = new CompactSQL();
                    compa.InsertPOAssign("POAssign", array, PutNumber, TONumber);
                    lblTotalQty.Text = "Total Qty of this item is : " + pomod[j].quantity;
                }

                GrdTO.DataSource = dt;

            }
            

            
        }

        private void mnuGRNBack_Click(object sender, EventArgs e)
        {
            this.Close();
            frmMain msc = new frmMain(RstName, Rstdimension, RstLevel);
            msc.Show();
        }

  
    }
}

public class AddComboValue
{
    private string m_Display;
    private long m_Value;
    public AddComboValue(string Display, long Value)
    {
        m_Display = Display;
        m_Value = Value;
    }
    public string Display
    {
        get { return m_Display; }
    }
    public long Value
    {
        get { return m_Value; }
    }
}