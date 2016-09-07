﻿using Healthgrades.TestAutomation.SeleniumFramework.Core;
using NUnit.Framework;
using SeleniumFrameworkV2Sample.PageObjects;
using SeleniumFrameworkV2Sample.Utils;

namespace SeleniumFrameworkV2Sample
{
    [TestFixture]
    public class LoginTests : WebDriverTestBase
    {

        [Test]
        [Category(MyTestCategory.SINGLE_POSITIVE)]
        [Category(MyTestCategory.NIGHTLY_RUN)]
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
        [Category(MyTestCategory.SEVERITY_1)]
        public void ValidateSuccessfulLoginSeverity1()
        {
            string userName = "mbadyelkhan@healthgrades.com";
            string password = "Abcd1234?";
            var loginPage = new LoginPageObjects();
            loginPage.OpenPage("/#/Login");
            var homePage = loginPage.Login(userName, password);
            Assert.IsTrue(loginPage.isUnsuccssfulTextMessageLocatorPresent(), "Negative login test works.");
            Log.Info("----- End of Severity1 test -----\n\r"); 
        }

        [Test]
        [Category(MyTestCategory.POSITIVE)]
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
        [Category(MyTestCategory.POSITIVE)]
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
        [Category(MyTestCategory.SINGLE_NEGATIVE)]
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
        [Category(MyTestCategory.NEGATIVE)]
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
        [Category(MyTestCategory.NEGATIVE)]
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

        [Test]
        [Category(MyTestCategory.NIGHTLY_RUN)]
        public void ValidateSuccessfulLoginNegativeNightlyRun()
        {
            string userName = "mbadyelkhan@healthgrades.com";
            string password = "Abcd1234?";
            var loginPage = new LoginPageObjects();
            loginPage.OpenPage("/#/Login");
            var homePage = loginPage.Login(userName, password);
            Assert.IsTrue(loginPage.isUnsuccssfulTextMessageLocatorPresent(), "Negative login test works.");
            Log.Info("----- End of Negative test 2 -----\n\r");
        }

        [Test]
        [Category(MyTestCategory.GOOGLE_TEST_FOR_IE)]
        public void GoogleTestForIE()
        {
            var loginPage = new LoginPageObjects();
            loginPage.OpenGooglePage("/");
            Log.Info("----- End of Positive GoogleTestForIE -----\n\r");
        }
    }
}
