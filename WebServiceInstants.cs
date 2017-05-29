using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using System.Net;
using System.Configuration.Assemblies;
using System.IO;
using System.Reflection;
using System.Windows.Forms;
using System.Xml;

namespace QHMobile
{
    enum ServiceType
    {
        UsersQH,
        WhseLineQH,
        BinQH,
        ItemJournalDailyLossQH,
        ItemJournalQH,
        ItemQH,
        PurchaseQH,
        PutAlwaysLinesQH,
        PutAlwaysQH,
        QH_Location,
        QHBinContent,
        IventoryPick,
        StockTakeWS,
        TransferOrderLineQH,
        TransferOrderQH,
        userName,
        password,
        domain,
        QH_Functions,
        VendorListQH,
        WarehouseRequestQH,
        remUser,
        remPassword,
        SaleOrderQH,
        QHEmptyTank,
        PostedTransferShipmentQH,
        QHDummyBin,
        QHItemJournalLine,
        QHWarehouseEntry,
        QHSalesReceivableSetup
    }
    class WebServiceInstants
    {

        public static DateTime EscalateDate(string DateInString)
        {
            string[] dtime = DateInString.Split(new char[] { '/' });
            DateTime WorkDate = new DateTime(Convert.ToInt16(dtime[2]), Convert.ToInt16(dtime[1]), Convert.ToInt16(dtime[0]));
            return WorkDate;
        }

        public static string GetURL(ServiceType ServiceType)
        {
            XmlDocument xmlDoc;
            string xmlFile = Path.GetDirectoryName(Assembly.GetExecutingAssembly().GetName().CodeBase) + "\\config.xml";
            
            //string xmlFile = @"C:\QHPDA\config.xml";
            if (!System.IO.File.Exists(xmlFile))
            {
                MessageBox.Show("The config.xml file is not exist.\n Cannot Start the Application!");
                Application.Exit();
            }
            xmlDoc = new XmlDocument();
            xmlDoc.Load(xmlFile);
            switch (ServiceType)
            {
                case ServiceType.UsersQH:
                    {
                        return xmlDoc.SelectSingleNode("/config/UsersQH").InnerText;
                    }
                case ServiceType.WhseLineQH:
                    {
                        return xmlDoc.SelectSingleNode("/config/WhseLineQH").InnerText;
                    }
                case ServiceType.BinQH:
                    {
                        return xmlDoc.SelectSingleNode("/config/BinQH").InnerText;
                    }
                case ServiceType.ItemJournalDailyLossQH:
                    {
                        return xmlDoc.SelectSingleNode("/config/ItemJournalDailyLossQH").InnerText;
                    }
                case ServiceType.ItemJournalQH:
                    {
                        return xmlDoc.SelectSingleNode("/config/ItemJournalQH").InnerText;
                    }
                case ServiceType.ItemQH:
                    {
                        return xmlDoc.SelectSingleNode("/config/ItemQH").InnerText;
                    }
                case ServiceType.PurchaseQH:
                    {
                        return xmlDoc.SelectSingleNode("/config/PurchaseQH").InnerText;
                    }
                case ServiceType.PutAlwaysLinesQH:
                    {
                        return xmlDoc.SelectSingleNode("/config/PutAlwaysLinesQH").InnerText;
                    }
                case ServiceType.PutAlwaysQH:
                    {
                        return xmlDoc.SelectSingleNode("/config/PutAlwaysQH").InnerText;
                    }
                case ServiceType.QH_Location:
                    {
                        return xmlDoc.SelectSingleNode("/config/QH_Location").InnerText;
                    }
                case ServiceType.QHBinContent:
                    {
                        return xmlDoc.SelectSingleNode("/config/QHBinContent").InnerText;
                    }
                case ServiceType.IventoryPick:
                    {
                        return xmlDoc.SelectSingleNode("/config/IventoryPick").InnerText;
                    }
                case ServiceType.StockTakeWS:
                    {
                        return xmlDoc.SelectSingleNode("/config/StockTakeWS").InnerText;
                    }
                case ServiceType.TransferOrderLineQH:
                    {
                        return xmlDoc.SelectSingleNode("/config/TransferOrderLineQH").InnerText;
                    }
                case ServiceType.TransferOrderQH:
                    {
                        return xmlDoc.SelectSingleNode("/config/TransferOrderQH").InnerText;
                    }
                case ServiceType.password:
                    {
                        return xmlDoc.SelectSingleNode("/config/password").InnerText;
                    }
                case ServiceType.userName:
                    {
                        return xmlDoc.SelectSingleNode("/config/userName").InnerText;
                    }
                case ServiceType.domain:
                    {
                        return xmlDoc.SelectSingleNode("/config/domain").InnerText;
                    }

                case ServiceType.QH_Functions:
                    {
                        return xmlDoc.SelectSingleNode("/config/QH_Functions").InnerText;
                    }
                case ServiceType.VendorListQH:
                    {
                        return xmlDoc.SelectSingleNode("/config/VendorListQH").InnerText;
                    }
                case ServiceType.WarehouseRequestQH:
                    {
                        return xmlDoc.SelectSingleNode("/config/WarehouseRequestQH").InnerText;
                    }
                case ServiceType.SaleOrderQH:
                    {
                        return xmlDoc.SelectSingleNode("/config/SaleOrderQH").InnerText;
                    }
                case ServiceType.remUser:
                    {
                        return xmlDoc.SelectSingleNode("/config/remUser").InnerText;
                    }
                case ServiceType.remPassword:
                    {
                        return xmlDoc.SelectSingleNode("/config/remPassword").InnerText;
                    }
                case ServiceType.QHEmptyTank:
                    {
                        return xmlDoc.SelectSingleNode("/config/QHEmptyTank").InnerText;
                    }
                case ServiceType.PostedTransferShipmentQH:
                    {
                        return xmlDoc.SelectSingleNode("/config/PostedTransferShipmentQH").InnerText;
                    }
                case ServiceType.QHDummyBin:
                    {
                        return xmlDoc.SelectSingleNode("/config/QHDummyBin").InnerText;
                    }
                case ServiceType.QHItemJournalLine:
                    {
                        return xmlDoc.SelectSingleNode("/config/QHItemJournalLine").InnerText;
                    }
                case ServiceType.QHWarehouseEntry:
                    {
                        return xmlDoc.SelectSingleNode("/config/QHWarehouseEntry").InnerText;
                    }
                case ServiceType.QHSalesReceivableSetup:
                    {
                        return xmlDoc.SelectSingleNode("/config/QHSalesReceivableSetup").InnerText;
                    } 
                default: return "";
                
            }
        }



        //1. Bin QH // 

        public BinQH.BinQH_Service Service_BinQH
        {
            get
            {
                return svc_BinQH();
            }
        }

        public static BinQH.BinQH_Service svc_BinQH()
        {
            BinQH.BinQH_Service svc = new BinQH.BinQH_Service();
            svc.Credentials = WebServiceAuthentication();
            return svc;
        }

        // Bin QH // 
         

        //3. ItemJournalDailyLossQH QH // 

        public ItemJournalDailyLossQH.ItemJournalDailyLossQH_Service Service_ItemJournalDailyLossQH
        {
            get
            {
                return svc_ItemJournalDailyLossQH();
            }
        }

        public static ItemJournalDailyLossQH.ItemJournalDailyLossQH_Service svc_ItemJournalDailyLossQH()
        {
            ItemJournalDailyLossQH.ItemJournalDailyLossQH_Service svc = new ItemJournalDailyLossQH.ItemJournalDailyLossQH_Service();
            svc.Credentials = WebServiceAuthentication();
            return svc;
        }

        // ItemJournalDailyLossQH QH // 

        //4. ItemQH // 

        public ItemQH.ItemQH_Service Service_ItemQH
        {
            get
            {
                return svc_ItemQH();
            }
        }

        public static ItemQH.ItemQH_Service svc_ItemQH()
        {
            ItemQH.ItemQH_Service svc = new ItemQH.ItemQH_Service();
            svc.Credentials = WebServiceAuthentication();
            return svc;
        }

        // ItemQH //


        //5. PurchaseQH // 

        public PurchaseQH.PurchaseQH_Service Service_PurchaseQH
        {
            get
            {
                return svc_PurchaseQH();
            }
        }

        public static PurchaseQH.PurchaseQH_Service svc_PurchaseQH()
        {
            PurchaseQH.PurchaseQH_Service svc = new PurchaseQH.PurchaseQH_Service();
            svc.Credentials = WebServiceAuthentication();
            return svc;
        }

        // PurchaseQH //

        //6. PutAlwaysLinesQH // 

        public PutAlwaysLinesQH.PutAlwaysLinesQH_Service Service_PutAlwaysLinesQH
        {
            get
            {
                return svc_PutAlwaysLinesQH();
            }
        }

        public static PutAlwaysLinesQH.PutAlwaysLinesQH_Service svc_PutAlwaysLinesQH()
        {
            PutAlwaysLinesQH.PutAlwaysLinesQH_Service svc = new PutAlwaysLinesQH.PutAlwaysLinesQH_Service();
            svc.Credentials = WebServiceAuthentication();
            return svc;
        }

        // PutAlwaysLinesQH //

        //7. PutAlwaysQH // 

        public PutAlwaysQH.PutAlwaysQH_Service Service_PutAlwaysQH
        {
            get
            {
                return svc_PutAlwaysQH();
            }
        }

        public static PutAlwaysQH.PutAlwaysQH_Service svc_PutAlwaysQH()
        {
            PutAlwaysQH.PutAlwaysQH_Service svc = new PutAlwaysQH.PutAlwaysQH_Service();
            svc.Credentials = WebServiceAuthentication();
            return svc;
        }

        // PutAlwaysQH //


        //8. QH_Location // 

        public QH_Location.QH_Location_Service Service_QH_Location
        {
            get
            {
                return svc_QH_Location();
            }
        }

        public static QH_Location.QH_Location_Service svc_QH_Location()
        {
            QH_Location.QH_Location_Service svc = new QH_Location.QH_Location_Service();
            svc.Credentials = WebServiceAuthentication();
            return svc;
        }

        // QH_Location //

        //9. QHBinContent // 

        public QHBinContent.QHBinContent_Service Service_QHBinContent
        {
            get
            {
                return svc_QHBinContent();
            }
        }

        public static QHBinContent.QHBinContent_Service svc_QHBinContent()
        {
            QHBinContent.QHBinContent_Service svc = new QHBinContent.QHBinContent_Service();
            svc.Credentials = WebServiceAuthentication();
            return svc;
        }

        // QHBinContent //

        //10. QHIventoryPick // 

        public QHIventoryPick.IventoryPick_Service Service_QHIventoryPick
        {
            get
            {
                return svc_QHIventoryPick();
            }
        }

        public static QHIventoryPick.IventoryPick_Service svc_QHIventoryPick()
        {
            QHIventoryPick.IventoryPick_Service svc = new QHIventoryPick.IventoryPick_Service();
            svc.Credentials = WebServiceAuthentication();
            return svc;
        }

        // QHIventoryPick //

        //11. qhStockTakeWS // 

        public qhStockTakeWS.StockTakeWS_Service Service_qhStockTakeWS
        {
            get
            {
                return svc_qhStockTakeWS();
            }
        }

        public static qhStockTakeWS.StockTakeWS_Service svc_qhStockTakeWS()
        {
            qhStockTakeWS.StockTakeWS_Service svc = new qhStockTakeWS.StockTakeWS_Service();
            svc.Credentials = WebServiceAuthentication();
            return svc;
        }

        // qhStockTakeWS //
      

        //14. TransferOrderLineQH // 

        public TransferOrderLineQH.TransferOrderLineQH_Service Service_TransferOrderLineQH
        {
            get
            {
                return svc_TransferOrderLineQH();
            }
        }

        public static TransferOrderLineQH.TransferOrderLineQH_Service svc_TransferOrderLineQH()
        {
            TransferOrderLineQH.TransferOrderLineQH_Service svc = new TransferOrderLineQH.TransferOrderLineQH_Service();
            svc.Credentials = WebServiceAuthentication();
            return svc;
        }

        // TransferOrderLineQH //

        //15. TransferOrderQH // 

        public TransferOrderQH.TransferOrderQH_Service Service_TransferOrderQH
        {
            get
            {
                return svc_TransferOrderQH();
            }
        }

        public static TransferOrderQH.TransferOrderQH_Service svc_TransferOrderQH()
        {
            TransferOrderQH.TransferOrderQH_Service svc = new TransferOrderQH.TransferOrderQH_Service();
            svc.Credentials = WebServiceAuthentication();
            return svc;
        }

        // TransferOrderQH //


        //16. UsersQH // 

        public UsersQH.UsersQH_Service Service_UsersQH
        {
            get
            {
                return svc_UsersQH();
            }
        }

        public static UsersQH.UsersQH_Service svc_UsersQH()
        {
            UsersQH.UsersQH_Service svc = new UsersQH.UsersQH_Service();
            svc.Credentials = WebServiceAuthentication();
            return svc;
        }

        // UsersQH //

        //17. WhseLineQH // 

        public WhseLineQH.WhseLineQH_Service Service_WhseLineQH
        {
            get
            {
                return svc_WhseLineQH();
            }
        }

        public static WhseLineQH.WhseLineQH_Service svc_WhseLineQH()
        {
            WhseLineQH.WhseLineQH_Service svc = new WhseLineQH.WhseLineQH_Service();
            svc.Credentials = WebServiceAuthentication();
            return svc;
        }

        // WhseLineQH //

        //18. ItemJournalQH // 

        public ItemJournalQH.ItemJournalQH_Service Service_ItemJournalQH
        {
            get
            {
                return svc_ItemJournalQH();
            }
        }

        public static ItemJournalQH.ItemJournalQH_Service svc_ItemJournalQH()
        {
            ItemJournalQH.ItemJournalQH_Service svc = new ItemJournalQH.ItemJournalQH_Service();
            svc.Credentials = WebServiceAuthentication();
            return svc;
        }

        // ItemJournalQH //

        //QHSalesReceivableSetup // 

        public QHSalesReceivableSetup.QHSalesReceivableSetup_Service Service_QHSalesReceivableSetup
        {
            get
            {
                return svc_QHSalesReceivableSetup();
            }
        }

        public static QHSalesReceivableSetup.QHSalesReceivableSetup_Service svc_QHSalesReceivableSetup()
        {
            QHSalesReceivableSetup.QHSalesReceivableSetup_Service svc = new QHMobile.QHSalesReceivableSetup.QHSalesReceivableSetup_Service();
            svc.Credentials = WebServiceAuthentication();
            return svc;
        }

        // QHSalesReceivableSetup //


        // Code Unit:QH_Functions   // 

        public QH_Functions.QH_Functions QH_Function
        {
            get
            {
                QH_Functions.QH_Functions svc = new QH_Functions.QH_Functions();
                svc.Url = WebServiceInstants.GetURL(ServiceType.QH_Functions);
                svc.Credentials = WebServiceAuthentication();
                return svc;
            }
        }

        // Code Unit:QH_Functions //

        public static NetworkCredential WebServiceAuthentication()
        {
            MainControl mainControl = new MainControl();
            NetworkCredential nc = new NetworkCredential();
            nc.Domain = mainControl.DomainName;
            nc.UserName = mainControl.ServiceUser;
            nc.Password = mainControl.Servicepassword;
            return nc;
        }


    }
}
