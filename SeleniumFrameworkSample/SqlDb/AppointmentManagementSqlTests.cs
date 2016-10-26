using Healthgrades.TestAutomation.SeleniumFramework.Core;
using NUnit.Framework;
using Ams.Acceptance.Testing.PageObjects;
using Ams.Acceptance.Testing.SqlDb;
using System.Threading;
using System;


namespace Ams.Acceptance.Testing.CreateTestData
{
    [TestFixture]
    public class AppointmentManagementSqlTests : WebDriverTestBase
    {

        [Test]
        [Category("SqlTests")]
        public void ValidateUpdateProvidersJob()
        {
            var sqlDbHelper = new SqlDatabaseHelper();
            var fileHelper = new FileHelper();

            //booked timeslots should be removed from the db
            string bookedTimeSlotMHD = fileHelper.readFromFile("slotIdMHD.txt");
            Assert.AreEqual(sqlDbHelper.GetTimeSlotCountFromInventory(bookedTimeSlotMHD), 0);
            //newly created timeslot shouldn't be in the db
            string dateMHD = fileHelper.readFromFile("MHDDateTime.txt");
            var createdTimeslotMHD = sqlDbHelper.GetTimeSlotInfoByDateAndPwidFromInventory(dateMHD, "3CNCW");
            Assert.AreEqual(createdTimeslotMHD.Pwid, "3CNCW");
            Assert.AreEqual(createdTimeslotMHD.OfficeCode, "FLX4Y");
            Assert.AreEqual(createdTimeslotMHD.PartnerCode, "MHD");
            Assert.AreEqual(createdTimeslotMHD.PartnerProviderId, "1333");
            Assert.AreEqual(createdTimeslotMHD.Json, null);
            Assert.AreEqual(createdTimeslotMHD.Json, string.Empty);
            Assert.IsTrue(createdTimeslotMHD.Json.Contains("3CNCW"));
            Assert.IsTrue(createdTimeslotMHD.Json.Contains(createdTimeslotMHD.TimeslotId));
        }

        [Test]
        [Category("SqlTests")]
        public void db()
        {

            var sqlDbHelper = new SqlDatabaseHelper();
            var fileHelper =new FileHelper();
            fileHelper.writeToFile("text.txt", "Mishka");
            string fileContent = fileHelper.readFromFile("slotIdMHD.txt");
            sqlDbHelper.GetTotalCount("Inventory");
           
        }
    }
}