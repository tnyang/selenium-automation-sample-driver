using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Data.SqlClient;

namespace Ams.Acceptance.Testing.SqlDb
{
    public class SqlDatabaseHelper
    {
        private static string dbName = "AppointmentManagement";
        private string connectionString = "Data Source=hgtestdb1;Initial Catalog=" + dbName + ";User ID=webuser;Password=dog.bone;";

        #region Queries
        private string deleteDataFromTable(string tableName)
        {
            // return "Delete from AppointmentManagement.dbo.Provider where Pwid = 'Y87XV'";
            return " DELETE FROM AppointmentManagement.dbo." + tableName + "";
        }
        private string getTotalCountQuery(string tableName)
        {
            return " SELECT COUNT(*) as total FROM AppointmentManagement.dbo." + tableName + "";
        }
        private string getCountQuery(string TimeslotId)
        {
            return " SELECT COUNT(*) as total FROM AppointmentManagement.dbo.Inventory WHERE TimeslotId='" + TimeslotId + "'";
        }
        private string selectTimeSlotInfoBySlotId(string timeslotId)
        {
            return " SELECT * FROM AppointmentManagement.dbo.Inventory WHERE TimeslotId='" + timeslotId + "'";
        }
        private string selectTimeSlotInfoByDateAndPwid(string date, string pwid)
        {
            return " SELECT * FROM AppointmentManagement.dbo.Inventory WHERE "+
                   " CONVERT(VARCHAR, AppointmentDateTime, 120) LIKE '%"+date+"%' "+
                   "  AND Pwid='"+pwid+"'";
        }

        #endregion


        public void DeleteDataFromAppointmentManagementByTableName(string tableName)
        {
            using (SqlConnection myConnection = new SqlConnection(connectionString))
            {
                SqlCommand myCommand = new SqlCommand(deleteDataFromTable(tableName), myConnection);
                myConnection.Open();
                myCommand.ExecuteNonQuery();
                myConnection.Close();
            }
        }
        public void WaitForDataInsertIntoSqlToFinish(string tableName)
        {
            int totalCount = 1;
            int currentCount = 0;
            using (SqlConnection myConnection = new SqlConnection(connectionString))
            {
                SqlCommand myCommand = new SqlCommand(getTotalCountQuery(tableName), myConnection);
                myConnection.Open();
                using (SqlDataReader myReader = myCommand.ExecuteReader())
                {
                    while (myReader.Read())
                    {
                        while (totalCount != currentCount)
                        {
                            currentCount = Convert.ToInt32(myReader["total"]);
                            totalCount = currentCount;
                            Thread.Sleep(2000);
                        }

                    }
                }

            }
        }
        public int GetTotalCount(string tableName)
        {
            int totalCount = 0;
            using (SqlConnection myConnection = new SqlConnection(connectionString))
            {
                SqlCommand myCommand = new SqlCommand(getTotalCountQuery(tableName), myConnection);
                myConnection.Open();
                using (SqlDataReader myReader = myCommand.ExecuteReader())
                {
                    while (myReader.Read())
                    {
                        totalCount = Convert.ToInt32(myReader["total"]);
                    }
                }
            }
            return totalCount;
        }
        public int GetTimeSlotCountFromInventory(string TimeslotId)
        {
            int totalCount = 0;
            using (SqlConnection myConnection = new SqlConnection(connectionString))
            {
                SqlCommand myCommand = new SqlCommand(getCountQuery(TimeslotId), myConnection);
                myConnection.Open();
                using (SqlDataReader myReader = myCommand.ExecuteReader())
                {
                    while (myReader.Read())
                    {
                        totalCount = Convert.ToInt32(myReader["total"]);
                    }
                }
            }
            return totalCount;
        }
        public InventoryModel GetTimeSlotInfoBySlotIdFromInventory(string TimeslotId)
        {
            InventoryModel im = new InventoryModel();
            using (SqlConnection myConnection = new SqlConnection(connectionString))
            {
                SqlCommand myCommand = new SqlCommand(selectTimeSlotInfoBySlotId(TimeslotId), myConnection);
                myConnection.Open();
                using (SqlDataReader myReader = myCommand.ExecuteReader())
                {
                    while (myReader.Read())
                    {
                        while (myReader.Read())
                        {
                            im.TimeslotId = myReader["TimeslotId"].ToString();
                            im.Pwid = myReader["Pwid"].ToString();
                            im.OfficeCode = myReader["OfficeCode"].ToString();
                            im.PartnerCode = myReader["PartnerCode"].ToString();
                            im.PartnerPracticeId = myReader["PartnerPracticeId"].ToString();
                            im.PartnerProviderId = myReader["PartnerProviderId"].ToString();
                            im.AppointmentDateTime = myReader["AppointmentDateTime"].ToString();
                            im.AppointmentDateTimeUtc = myReader["AppointmentDateTimeUtc"].ToString();
                            im.Json = myReader["Json"].ToString();
                        }
                        myConnection.Close();
                    }
                }
                return im;
            }

        }
        public InventoryModel GetTimeSlotInfoByDateAndPwidFromInventory(string date, string pwid)
        {
            InventoryModel im = new InventoryModel();
            using (SqlConnection myConnection = new SqlConnection(connectionString))
            {
                SqlCommand myCommand = new SqlCommand(selectTimeSlotInfoByDateAndPwid(date, pwid), myConnection);
                myConnection.Open();
                using (SqlDataReader myReader = myCommand.ExecuteReader())
                {
                    while (myReader.Read())
                    {
                        while (myReader.Read())
                        {
                            im.TimeslotId = myReader["TimeslotId"].ToString();
                            im.Pwid = myReader["Pwid"].ToString();
                            im.OfficeCode = myReader["OfficeCode"].ToString();
                            im.PartnerCode = myReader["PartnerCode"].ToString();
                            im.PartnerPracticeId = myReader["PartnerPracticeId"].ToString();
                            im.PartnerProviderId = myReader["PartnerProviderId"].ToString();
                            im.AppointmentDateTime = myReader["AppointmentDateTime"].ToString();
                            im.AppointmentDateTimeUtc = myReader["AppointmentDateTimeUtc"].ToString();
                            im.Json = myReader["Json"].ToString();
                        }
                        myConnection.Close();
                    }
                }
                return im;
            }

        }


    }
}
