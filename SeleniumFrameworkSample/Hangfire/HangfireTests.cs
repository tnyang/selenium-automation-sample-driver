using Healthgrades.TestAutomation.SeleniumFramework.Core;
using NUnit.Framework;
using Ams.Acceptance.Testing.PageObjects;
using Ams.Acceptance.Testing.SqlDb;
using System.Threading;
using System;


namespace Ams.Acceptance.Testing.CreateTestData
{
    [TestFixture]
    public class HangfireTests : WebDriverTestBase
    {
        [Test]
        [Category("Hangfire")]
        public void ValidateHangfireInvalidUserLogin()
        {
            string userName = "invalid";
            string password = "hangfire#2016";

            var hangfire = new HangfireObjects();
            var sqlDbHelper = new SqlDatabaseHelper();

            //Login
            hangfire.OpenHangfireLoginPage();
            hangfire.Login(userName, password);
            Assert.IsTrue(hangfire.IsStringPresent("Invalid login attempt."), "'Invalid login attempt.' - error message is not displayed.");
  
        }

        [Test]
        [Category("Hangfire")]
        public void ValidateHangfireInvalidPasswordLogin()
        {
            string userName = "hangfireadmin";
            string password = "invalid";

            var hangfire = new HangfireObjects();
            var sqlDbHelper = new SqlDatabaseHelper();

            //Login
            hangfire.OpenHangfireLoginPage();
            hangfire.Login(userName, password);
            Assert.IsTrue(hangfire.IsStringPresent("Invalid login attempt."), "'Invalid login attempt.' - error message is not displayed.");
        }

        [Test]
        [Category("Hangfire")]
        public void ValidateHangfireSuccessfulLogin()
        {
            string userName = "hangfireadmin";
            string password = "hangfire#2016";

            var hangfire = new HangfireObjects();

            //Login
            hangfire.OpenHangfireLoginPage();
            hangfire.Login(userName, password);
            Assert.IsTrue(hangfire.IsRecurringJobsTabDisIsplayed(), "There is an issue with login.");
            Log.Info("----- User logged in successfully. -----\n\r");

            //Go to Jobs tab and get Succeeded job count
            hangfire.ClickOnJobsTab();
            Assert.IsTrue(hangfire.GetJobCounts("Enqueued").Equals("0 / 0"), "Enqueued should be 0 / 0");
            Assert.IsTrue(hangfire.GetJobCounts("Failed").Equals("0"), "Failed should be 0");

            //Go to Recurring Jobs tab
            hangfire.ClickOnRecurringJobsTab();
            Assert.IsTrue(hangfire.IsJobPresent("Update Providers"), "Job 'Update Providers' is not displayed on Recurring Jobs tab");
            Assert.IsTrue(hangfire.IsJobPresent("Update PartnerAppointmentReasons"), "Job 'Update PartnerAppointmentReasons' is not displayed on Recurring Jobs tab");
            Assert.IsTrue(hangfire.IsJobPresent("Update Timeslots -> Default"), "Job 'Update Timeslots -> Default' is not displayed on Recurring Jobs tab");
            Assert.IsTrue(hangfire.IsJobPresent("Update Timeslots -> High"), "Job 'Update Timeslots -> High' is not displayed on Recurring Jobs tab");
            Assert.IsTrue(hangfire.IsJobPresent("Update Timeslots -> Low"), "Job 'Update Timeslots -> Low' is not displayed on Recurring Jobs tab");
        }

        [Test]
        [Category("Hangfire")]
        public void ValidateUpdateProvidersJob()
        {
            string userName = "hangfireadmin";
            string password = "hangfire#2016";

            var hangfire = new HangfireObjects();
            var sqlDbHelper = new SqlDatabaseHelper();

            //Login
            hangfire.OpenHangfireLoginPage();
            hangfire.Login(userName, password);
            Assert.IsTrue(hangfire.IsRecurringJobsTabDisIsplayed(), "There is an issue with login.");
            Log.Info("----- User logged in successfully. -----\n\r");

            //Go to Jobs tab and get Succeeded job count
            hangfire.ClickOnJobsTab();
            string succeededJobCount = hangfire.GetJobCounts("Succeeded");

            //Clean up providers and Trigger the 'Updte Provider' job
            //Wait until all the providers are inserted and verify count
            sqlDbHelper.DeleteDataFromAppointmentManagementByTableName("Provider");
            hangfire.CheckJob("Update Providers");
            hangfire.ClickOnTriggerButton();
            hangfire.ClickOnJobsTab();
            Assert.IsTrue(hangfire.GetJobCounts("Processing").Equals("1"), "Processing should be 1");
            sqlDbHelper.WaitForDataInsertIntoSqlToFinish("Provider");
            Assert.IsTrue(hangfire.GetJobCounts("Succeeded").Equals((succeededJobCount + 1).ToString()), "Succeeded job count shoulud be " + succeededJobCount + 1);
            Assert.IsTrue(hangfire.GetJobCounts("Failed").Equals("0"), "Failed should be 1");
            Assert.IsTrue(hangfire.GetJobCounts("Processing").Equals("0"), "Processing should be 0");
            Assert.AreEqual(sqlDbHelper.GetTotalCount("Provider"), 685, "Total Provider count should be 685 in Test env");
        }

        [Test]
        [Category("Hangfire")]
        public void ValidateUpdatePartnerAppointmentReasonsJob()
        {
            string userName = "hangfireadmin";
            string password = "hangfire#2016";

            var hangfire = new HangfireObjects();
            var sqlDbHelper = new SqlDatabaseHelper();

            //Login
            hangfire.OpenHangfireLoginPage();
            hangfire.Login(userName, password);
            Assert.IsTrue(hangfire.IsRecurringJobsTabDisIsplayed(), "There is an issue with login.");
            Log.Info("----- User logged in successfully. -----\n\r");

            //Go to Jobs tab and get Succeeded job count
            hangfire.ClickOnJobsTab();
            string succeededJobCount = hangfire.GetJobCounts("Succeeded");

            //Clean up providers and Trigger the 'Updte Provider' job
            //Wait until all the providers are inserted and verify count
            sqlDbHelper.DeleteDataFromAppointmentManagementByTableName("InventoryPartnerAppointmentReason");
            sqlDbHelper.DeleteDataFromAppointmentManagementByTableName("PartnerAppointmentReason");
            hangfire.CheckJob("Update PartnerAppointmentReasons");
            hangfire.ClickOnTriggerButton();
            hangfire.ClickOnJobsTab();
            Assert.IsTrue(hangfire.GetJobCounts("Processing").Equals("1"), "Processing should be 1");
            sqlDbHelper.WaitForDataInsertIntoSqlToFinish("InventoryPartnerAppointmentReason");
            sqlDbHelper.WaitForDataInsertIntoSqlToFinish("PartnerAppointmentReason");
            Assert.IsTrue(hangfire.GetJobCounts("Succeeded").Equals((succeededJobCount + 1).ToString()), "Succeeded job count shoulud be " + succeededJobCount + 1);
            Assert.IsTrue(hangfire.GetJobCounts("Failed").Equals("0"), "Failed should be 1");
            Assert.IsTrue(hangfire.GetJobCounts("Processing").Equals("0"), "Processing should be 0");
            Assert.AreEqual(sqlDbHelper.GetTotalCount("InventoryPartnerAppointmentReason"), 0, "Total InventoryPartnerAppointmentReason count should be 685 in Test env");
            Assert.AreEqual(sqlDbHelper.GetTotalCount("PartnerAppointmentReason"), 0, "Total PartnerAppointmentReason count should be 685 in Test env");
        }

        [Test]
        [Category("Hangfire")]
        public void ValidateUpdateTimeslotsDefaultJob()
        {
            string userName = "hangfireadmin";
            string password = "hangfire#2016";

            var hangfire = new HangfireObjects();
            var sqlDbHelper = new SqlDatabaseHelper();
            var fileHelper = new FileHelper();

            //Login
            hangfire.OpenHangfireLoginPage();
            hangfire.Login(userName, password);
            Assert.IsTrue(hangfire.IsRecurringJobsTabDisIsplayed(), "There is an issue with login.");
            Log.Info("----- User logged in successfully. -----\n\r");

            //Go to Jobs tab and get Succeeded job count
            hangfire.ClickOnJobsTab();
            string succeededJobCount = hangfire.GetJobCounts("Succeeded");

            //Clean up providers and Trigger the 'Updte Provider' job
            //Wait until all the providers are inserted and verify count
            sqlDbHelper.DeleteDataFromAppointmentManagementByTableName("Inventory");
            hangfire.CheckJob("Update Timeslots -> Default");
            hangfire.ClickOnTriggerButton();
            hangfire.ClickOnJobsTab();
            Assert.IsTrue(hangfire.GetJobCounts("Processing").Equals("1"), "Processing should be 1");
            sqlDbHelper.WaitForDataInsertIntoSqlToFinish("Inventory");
            Assert.IsTrue(hangfire.GetJobCounts("Succeeded").Equals((succeededJobCount + 1).ToString()), "Succeeded job count shoulud be " + succeededJobCount + 1);
            Assert.IsTrue(hangfire.GetJobCounts("Failed").Equals("0"), "Failed should be 1");
            Assert.IsTrue(hangfire.GetJobCounts("Processing").Equals("0"), "Processing should be 0");
            Assert.IsTrue(sqlDbHelper.GetTotalCount("Inventory")>0, "Total Inventory count should be more than 0 in Test env");
        }

        [Test]
        [Category("Hangfire")]
        public void ValidateUpdateTimeslotsHighJob()
        {
            string userName = "hangfireadmin";
            string password = "hangfire#2016";

            var hangfire = new HangfireObjects();
            var sqlDbHelper = new SqlDatabaseHelper();

            //Login
            hangfire.OpenHangfireLoginPage();
            hangfire.Login(userName, password);
            Assert.IsTrue(hangfire.IsRecurringJobsTabDisIsplayed(), "There is an issue with login.");
            Log.Info("----- User logged in successfully. -----\n\r");

            //Go to Jobs tab and get Succeeded job count
            hangfire.ClickOnJobsTab();
            string succeededJobCount = hangfire.GetJobCounts("Succeeded");

            //Clean up providers and Trigger the 'Updte Provider' job
            //Wait until all the providers are inserted and verify count
            hangfire.CheckJob("Update Timeslots -> High");
            hangfire.ClickOnTriggerButton();
            hangfire.ClickOnJobsTab();
            Assert.IsTrue(hangfire.GetJobCounts("Processing").Equals("1"), "Processing should be 1");
            sqlDbHelper.WaitForDataInsertIntoSqlToFinish("Inventory");
            Assert.IsTrue(hangfire.GetJobCounts("Succeeded").Equals((succeededJobCount + 1).ToString()), "Succeeded job count shoulud be " + succeededJobCount + 1);
            Assert.IsTrue(hangfire.GetJobCounts("Failed").Equals("0"), "Failed should be 1");
            Assert.IsTrue(hangfire.GetJobCounts("Processing").Equals("0"), "Processing should be 0");
            Assert.IsTrue(sqlDbHelper.GetTotalCount("Inventory") > 0, "Total Inventory count should be more than 0 in Test env");
        }

        [Test]
        [Category("Hangfire")]
        public void ValidateUpdateTimeslotsLowJob()
        {
            string userName = "hangfireadmin";
            string password = "hangfire#2016";

            var hangfire = new HangfireObjects();
            var sqlDbHelper = new SqlDatabaseHelper();

            //Login
            hangfire.OpenHangfireLoginPage();
            hangfire.Login(userName, password);
            Assert.IsTrue(hangfire.IsRecurringJobsTabDisIsplayed(), "There is an issue with login.");
            Log.Info("----- User logged in successfully. -----\n\r");

            //Go to Jobs tab and get Succeeded job count
            hangfire.ClickOnJobsTab();
            string succeededJobCount = hangfire.GetJobCounts("Succeeded");

            //Clean up providers and Trigger the 'Updte Provider' job
            //Wait until all the providers are inserted and verify count
            hangfire.CheckJob("Update Timeslots -> Low");
            hangfire.ClickOnTriggerButton();
            hangfire.ClickOnJobsTab();
            Assert.IsTrue(hangfire.GetJobCounts("Processing").Equals("1"), "Processing should be 1");
            sqlDbHelper.WaitForDataInsertIntoSqlToFinish("Inventory");
            Assert.IsTrue(hangfire.GetJobCounts("Succeeded").Equals((succeededJobCount + 1).ToString()), "Succeeded job count shoulud be " + succeededJobCount + 1);
            Assert.IsTrue(hangfire.GetJobCounts("Failed").Equals("0"), "Failed should be 1");
            Assert.IsTrue(hangfire.GetJobCounts("Processing").Equals("0"), "Processing should be 0");
            Assert.IsTrue(sqlDbHelper.GetTotalCount("Inventory") > 0, "Total Inventory count should be more than 0 in Test env");
        }

      
    }
}