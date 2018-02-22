using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeleniumFrameworkV2Sample.SqlDatabase
{
    public class HealthGradesWebDbNotificationTblQueries
    {

        //	SELECT count(*) as counts FROM [HealthGradesWeb].[dbo].[Notification]
        public string GetNotificationCount()
        {
            return "SELECT count(*) as counts FROM [HealthGradesWeb].[dbo].[Notification]";
        }

        //SELECT * FROM [HealthGradesWeb].[dbo].[Notification]
        //WHERE AppointmentID = '36693'
        public string GetNotificationCountProvidingAppointmentId(string AppointmentId)
        {
            return "SELECT * FROM[HealthGradesWeb].[dbo].[Notification] WHERE AppointmentID = '"+ AppointmentId + "'";
        }

        //	SELECT * FROM [HealthGradesWeb].[dbo].[Notification] WHERE AppointmentID = '36693' AND NotificationTypeID = '2'
        public string GetNotificationCount(string AppointmentId, string NotificationId)
        {
            return "SELECT * FROM [HealthGradesWeb].[dbo].[Notification] WHERE AppointmentID = '"+ AppointmentId + "' AND NotificationTypeID = '"+ NotificationId + "'";
        }

        //	UPDATE [HealthGradesWeb].[dbo].[Notification] SET NotificationSendDate = '2017-01-25' WHERE NotificationID = '31906'







        //Select query
        public string selectNotificationsBasedOnAppointmentId (string AppointmentID)
        {
            return "SELECT * FROM HealthGradesWeb.dbo.Notification WHERE AppointmentID='" + AppointmentID + "'";
        }

        //Update query
        public string updateNotificationSetDate(string NotificationID, string AppointmentID)
        {
            return "UPDATE HealthGradesWeb.dbo.Notification "+
                   "SET NotificationSendDate = Getdate() "+
                   "WHERE NotificationID='"+ NotificationID + "' AND AppointmentID='"+ AppointmentID + "'";
        }

        //Delete query
        public string deleteNotification(string NotificationID, string AppointmentID)
        {
            return "DELETE FROM HealthGradesWeb.dbo.Notification " +
                   "WHERE NotificationID='" + NotificationID + "' AND AppointmentID='" + AppointmentID + "'";
        }
    }
}
