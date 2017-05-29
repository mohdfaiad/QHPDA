using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlServerCe;
using System.IO;
using System.Reflection;
using System.Data;

namespace QHMobile
{
    class CompactSQL
    {
        public SqlCeConnection conn;
        //private DataSet dst;

        public void CreateConnection()
        {
            String dblocation = GetApplicationPath() + "\\QHMobile.sdf";
            //String dblocation = @"C:\QHPDA" + "\\QHMobile.sdf";
            String sconn = "Data Source=\"" + dblocation + "\"; ";
            sconn += "Password='';Encrypt=True;";
            conn = new SqlCeConnection(sconn);
            conn.Open();
        }

        private string GetApplicationPath()
        {
            return Path.GetDirectoryName(
                Assembly.GetExecutingAssembly().GetName().CodeBase);
        }

        public void InsertRecord(string tablename,Object[] arr)
        {
            CreateConnection();

            SqlCeCommand insertMaster = new SqlCeCommand();

            insertMaster.Connection = conn;

            if(tablename.Equals("StockTakeEntry"))
            {
                insertMaster.CommandText = "Insert Into " + tablename + "(ItemNo,BinCode,Quantity,PostDate,StaffName,EntryDate,Category,Loc)Values('" + arr[0].ToString() + "','" + arr[1].ToString() + "','" + arr[2].ToString() + "','" + arr[3].ToString() + "','" + arr[4].ToString() + "','" + " " + "','" + arr[5].ToString() + "','" + arr[6].ToString() + "')";
            }
            else if (tablename.Equals("DailyLoss"))
            {
                insertMaster.CommandText = "Insert Into " + tablename + "(ItemNo,Location,Quantity,BinCode,PostingDate,StaffDimension,EmptyTank)Values('" + arr[1].ToString() + "','" + arr[2].ToString() + "','" + arr[3].ToString() + "','" + arr[4].ToString() + "','" + arr[0].ToString() + "','" + arr[5].ToString() + "','" + arr[6].ToString() + "')";

            }
            else if (tablename.Equals("ChangeSize"))
            {
                insertMaster.CommandText = "Insert Into " + tablename + "(ItemNo,Description,EntryType,Location,BinCode,Quantity,StaffDimension,PostingDate,EmptyTank)Values('" + arr[0].ToString() + "','" + arr[1].ToString().Replace("'", "") + "','" + arr[2].ToString() + "','" + arr[3].ToString() + "','" + arr[4].ToString() + "','" + arr[5].ToString() +
                    "','" + arr[6].ToString() + "','" + arr[7].ToString() + "','" + arr[8].ToString() + "')";
            }
            else if (tablename.Equals("ItemReclass"))
            {
                insertMaster.CommandText = "Insert Into " + tablename + "(ItemNo,Location,FromBin,ToBin,Quantity,StaffCode,PostingDate,EmptyTank)Values('" + arr[1].ToString() + "','" + arr[2].ToString() + "','" + arr[3].ToString() + "','" + arr[4].ToString() + "','" + arr[5].ToString() + "','" + arr[6].ToString() + "','" + arr[0].ToString() + "','" + arr[7].ToString() + "')";
            }
            else if (tablename.Equals("PurchaseOrder"))
            {
                insertMaster.CommandText = "Insert Into " + tablename + "( VendorNo, VendorName, RegDate, Loc, ItemNo, ItemDescription, Quantity)Values('" + arr[0].ToString() + "','" + arr[1].ToString() + "','" + arr[2].ToString() + "','" + arr[3].ToString() + "','" + arr[4].ToString() + "','" + arr[5].ToString() + "','" + arr[6].ToString() + "')";
            }


            insertMaster.ExecuteNonQuery();
            conn.Close();

        }

        public SqlCeDataReader SelectRecord(string tablename)
        {   
            CreateConnection();

            SqlCeCommand sqlcmd = null;
            SqlCeDataReader sqlreader = null;

            String cmdtext = "Select * from " + tablename ;
            sqlcmd = new SqlCeCommand(cmdtext);
            sqlcmd.Connection = conn;

            sqlreader = sqlcmd.ExecuteReader();

            return sqlreader;

        }

        public void deleteRecord(string tablename)
        {
            CreateConnection();
            String deletesql = "DELETE FROM " + tablename;
            SqlCeCommand cmd = new SqlCeCommand(deletesql, conn);
            cmd.ExecuteNonQuery();
            conn.Close();
        }

        public void DeleteOneRecord(int receiveLine, string tablename)
        {
            try
            {

                CreateConnection();
                String deletesql = "DELETE FROM " + tablename + " WHERE ([LineNo] =" + receiveLine + ")";
                SqlCeCommand cmd = new SqlCeCommand(deletesql, conn);
                cmd.ExecuteNonQuery();
                conn.Close();
            }
            catch (Exception ex)
            {
               
            }
        }


        public void deleteRecordLine(string tablename, int iLineNo)
        {
            CreateConnection();
            String deletesql = "DELETE FROM " + tablename + " WHERE ([LineNo] =" + iLineNo + ")";
            
            //where LineNo='" + iLineNo.ToString() + "'";
            SqlCeCommand cmd = new SqlCeCommand(deletesql, conn);
            cmd.ExecuteNonQuery();
            conn.Close();
        }
        public void updatePOLine(Object[] arr, int iLineNo)
        {
            CreateConnection();
            String deletesql = "UPDATE PurchaseOrder SET  Loc='" + arr[0].ToString() + "', Quantity='" + arr[1].ToString() +
            "' WHERE ([LineNo] =" + iLineNo + ")";

            //where LineNo='" + iLineNo.ToString() + "'";
            SqlCeCommand cmd = new SqlCeCommand(deletesql, conn);
            cmd.ExecuteNonQuery();
            conn.Close();
        }


        public void updateDailyLoss(int i, int iLineNo)
        {
            CreateConnection();
            String Updateql = "UPDATE DailyLoss SET Quantity='" + i.ToString() +
            "' WHERE ([LineNo] =" + iLineNo + ")";

            //where LineNo='" + iLineNo.ToString() + "'";
            SqlCeCommand cmd = new SqlCeCommand(Updateql, conn);
            cmd.ExecuteNonQuery();
            conn.Close();
        }
        public void deleteRecordLine(string tablename, string fieldname, string fieldvalue)
        {
            CreateConnection();
            String deletesql = "DELETE FROM " + tablename + " where " + fieldname.Trim() + "=" + fieldvalue.Trim();
            SqlCeCommand cmd = new SqlCeCommand(deletesql, conn);
            cmd.ExecuteNonQuery();
            conn.Close();

        }


        public void InsertPOAssign(string tablename, Object[] arr, string puknumber, string ponumber)
        {
            CreateConnection();

            SqlCeCommand insertMaster = new SqlCeCommand();

            insertMaster.Connection = conn;

            if (tablename.Equals("POAssign"))
            {
                insertMaster.CommandText = "Insert Into " + tablename + "(pukNo,poNo,[LineNo],itemNo,Description,Quantity,Location,BinCode,Registered)Values('" + puknumber + "','" + ponumber + "','" + arr[0].ToString() + "','" + arr[1].ToString() + "','" + arr[2].ToString() + "','" + arr[3].ToString() + "','" + arr[4].ToString() + "','" + arr[5].ToString() + "','" + "No" + "')";
            }

            insertMaster.ExecuteNonQuery();

        }


        public SqlCeDataReader SelectRecordPOAssign(string tablename, string ponumber)
        {
            CreateConnection();

            SqlCeCommand sqlcmd = null;
            SqlCeDataReader sqlreader = null;

            String cmdtext = "Select * from " + tablename + " where poNo='" +ponumber+"'" ;
            sqlcmd = new SqlCeCommand(cmdtext);
            sqlcmd.Connection = conn;

            sqlreader = sqlcmd.ExecuteReader();

            return sqlreader;

        }

        
       public void UpdatePOAssign(string tablename, string putNumber, string poNumber, string lineNo, string sourceLineNo, string itemNo, string RegisterV)
       {
           CreateConnection();

           SqlCeCommand updateMaster = new SqlCeCommand();

           updateMaster.Connection = conn;

           if (tablename.Equals("POAssign"))
           {
               updateMaster.CommandText = "Update" + tablename + "SET Scanned=" + RegisterV + "' WHERE ([LineNo] =" + lineNo + "[pukNo]=" + putNumber + "[poNo]=" + poNumber + "[itemNo]=" + itemNo + "[itemNo]=" + sourceLineNo + ")";
           }

           updateMaster.ExecuteNonQuery();

       }
     


     }

}
