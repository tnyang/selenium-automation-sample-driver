using Healthgrades.TestAutomation.SeleniumFramework.Core;
using NUnit.Framework;
using SeleniumFrameworkV2Sample.PageObjects;

namespace SeleniumFrameworkV2Sample
{
    [TestFixture]
    public class LoginTests : WebDriverTestBase
    {
        [Test]
        [Category("Single_Positive")]
        public void ValidateSuccessfulLoginSinglePositive()
        {
            string userName = "mbadyelkhan@healthgrades.com";
            string password = "Abcd1234!";
            var loginPage = new LoginPageObjects();
            loginPage.OpenPage("/#/Login");
            var homePage = loginPage.Login(userName, password);
            Assert.IsTrue(homePage.isLogoLinkPresent(), "There is an issue with login.");
            Log.Info("----- End of Positive test 1 -----\n\r");
        }

        [Test]
        [Category("Positive")]
        public void ValidateSuccessfulLoginPositive1()
        {
            string userName = "mbadyelkhan@healthgrades.com";
            string password = "Abcd1234!";
            var loginPage = new LoginPageObjects();
            loginPage.OpenPage("/#/Login");
            var homePage = loginPage.Login(userName, password);
            Assert.IsTrue(homePage.isLogoLinkPresent(), "There is an issue with login.");
            Log.Info("----- End of Positive test 1 -----\n\r");
        }

        [Test]
        [Category("Positive")]
        public void ValidateSuccessfulLoginPositive2()
        {
            string userName = "mbadyelkhan@healthgrades.com";
            string password = "Abcd1234!";
            var loginPage = new LoginPageObjects();
            loginPage.OpenPage("/#/Login");
            var homePage = loginPage.Login(userName, password);
            Assert.IsTrue(homePage.isLogoLinkPresent(), "There is an issue with login.");
            Log.Info("----- End of Positive test 2 -----\n\r");
        }

        [Test]
        [Category("Single_Negative")]
        public void ValidateSuccessfulLoginNegative1()
        {
            string userName = "mbadyelkhan@healthgrades.com";
            string password = "Abcd1234?";
            var loginPage = new LoginPageObjects();
            loginPage.OpenPage("/#/Login");
            var homePage = loginPage.Login(userName, password);
            Assert.IsFalse(loginPage.isUnsuccssfulTextMessageLocatorPresent(), "Negative login test works.");
            Log.Info("----- End of Negative test 1 -----\n\r");
        }

        [Test]
        [Category("Negative")]
        public void ValidateSuccessfulLoginSingleNegative()
        {
            string userName = "mbadyelkhan@healthgrades.com";
            string password = "Abcd1234?";
            var loginPage = new LoginPageObjects();
            loginPage.OpenPage("/#/Login");
            var homePage = loginPage.Login(userName, password);
            Assert.IsFalse(loginPage.isUnsuccssfulTextMessageLocatorPresent(), "Negative login test works.");
            Log.Info("----- End of Negative test 1 -----\n\r");
        }

        [Test]
        [Category("Negative")]
        public void ValidateSuccessfulLoginNegative2()
        {
            string userName = "mbadyelkhan@healthgrades.com";
            string password = "Abcd1234?";
            var loginPage = new LoginPageObjects();
            loginPage.OpenPage("/#/Login");
            var homePage = loginPage.Login(userName, password);
            Assert.IsTrue(loginPage.isUnsuccssfulTextMessageLocatorPresent(), "Negative login test works.");
            Log.Info("----- End of Negative test 2 -----\n\r");
        }


    }
}
