using Healthgrades.TestAutomation.SeleniumFramework.Core;
using NUnit.Framework;
using Ams.Acceptance.Testing.PageObjects;
using System.Threading;
using System;


namespace Ams.Acceptance.Testing.CreateTestData
{
    [TestFixture]
    public class CreateNewTimeSlot : WebDriverTestBase
    {
        [Test]
        [Category("CreateTestData")]
        public void CreateTestDataCreateTimeSlotForMHD()
        {
            string userName = "smadinoor@healthgrades.com";
            string password = "Mhdpassword=001";
            string site = "Millcreek Primary Care";
            string provider = "Robert Corson";
            string date= DateTime.Now.ToString("MM/dd/yyyy");
            string hour = "09";
            string min = "00";
            string timeComponent = "PM";


            //Login
            var mhdStage = new MhdstageTimeslotCreateObjects();
            mhdStage.OpenMHDStagePage("/Login/Logon");
            mhdStage.Login(userName, password);
            Assert.IsTrue(mhdStage.isPopupDisplayed(), "There is an issue with login.");
            mhdStage.closePopupDialog();
            Log.Info("----- User logged in successfully. -----\n\r");


            //Go to the site
            mhdStage.ClickLinkBasedOnText(site);
            Assert.IsTrue(mhdStage.isLinkPresent(provider), "There is an issue with displaying Site details page.");
            Log.Info("----- User successfully loaded /Admin/Site/Detals/... page. -----\n\r");

            //View Calendar
            mhdStage.ClickLinkBasedOnPartialHref("Service/675");
            mhdStage.AddSlot(date, hour, min, timeComponent);
            Assert.IsTrue(mhdStage.IsSlotCreatedSuccessfully(), "Time slot is NOT created successfully.");;
            Thread.Sleep(10000);
        }
    }
}
