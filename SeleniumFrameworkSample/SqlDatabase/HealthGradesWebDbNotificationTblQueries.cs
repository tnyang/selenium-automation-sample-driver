using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeleniumFrameworkV2Sample.SqlDatabase
{
    public class HealthGradesWebDbNotificationTblQueries
    {

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
