using Healthgrades.TestAutomation.SeleniumFramework.Core;
using NUnit.Framework;
using SeleniumFrameworkV2Sample.PageObjects;
using SeleniumFrameworkV2Sample.Utils;

namespace SeleniumFrameworkV2Sample
{
    [TestFixture]
    public class LoginTests : WebDriverTestBase
    {
        [Test]
        [Category(MyTestCategory.ONE)]
        public void test1()
        {
            System.Console.WriteLine("------------------test1");
        }

        [Test]
        [Category(MyTestCategory.ONE),Category(MyTestCategory.TWO)]
        public void test2()
        {
            System.Console.WriteLine("------------------test2");
        }
        [Test]
        //[Category("one")]
        [Category(MyTestCategory.THREE)]
        public void test3()
        {
            System.Console.WriteLine("------------------test3");
        }
        [Test]
        [Category(MyTestCategory.ONE)]
        [Category(MyTestCategory.TWO)]
        public void test4()
        {
            System.Console.WriteLine("------------------test4");
        }


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
        [Category(MyTestCategory.NIGHTLY_RUN)]
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
        [Category(MyTestCategory.NIGHTLY_RUN)]
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

        // -------------------------------- use for saucelab testing
        [Test]
        [Category(MyTestCategory.SAUCELABS_TEST)]
        public void SauceLabValidateSuccessfulLoginPositive1()
        {
            var loginPage = new LoginPageObjects();
            loginPage.OpenGooglePage("/");
            Log.Info("----- End of Positive GoogleTestForIE -----\n\r");
        }

        [Test]
        [Category(MyTestCategory.SAUCELABS_TEST)]
        public void SauceLabValidateSuccessfulLoginPositive2()
        {
            var loginPage = new LoginPageObjects();
            loginPage.OpenGooglePage("/");
            Log.Info("----- End of Positive GoogleTestForIE -----\n\r");
        }

        [Test]
        [Category(MyTestCategory.SAUCELABS_TEST)]
        public void SauceLabValidateSuccessfulLoginPositive3()
        {
            var loginPage = new LoginPageObjects();
            loginPage.OpenGooglePage("/");
            Log.Info("----- End of Positive GoogleTestForIE -----\n\r");
        }

        [Test]
        [Category(MyTestCategory.SAUCELABS_TEST)]
        public void SauceLabValidateSuccessfulLoginPositive4()
        {
            var loginPage = new LoginPageObjects();
            loginPage.OpenGooglePage("/");
            Log.Info("----- End of Positive GoogleTestForIE -----\n\r");
        }

        [Test]
        [Category(MyTestCategory.SAUCELABS_TEST)]
        public void SauceLabValidateSuccessfulLoginPositive5()
        {
            var loginPage = new LoginPageObjects();
            loginPage.OpenGooglePage("/");
            Log.Info("----- End of Positive GoogleTestForIE -----\n\r");
        }

        [Test]
        [Category(MyTestCategory.SAUCELABS_TEST)]
        public void SauceLabValidateSuccessfulLoginPositive6()
        {
            var loginPage = new LoginPageObjects();
            loginPage.OpenGooglePage("/");
            Log.Info("----- End of Positive GoogleTestForIE -----\n\r");
        }

        [Test]
        [Category(MyTestCategory.SAUCELABS_TEST)]
        public void SauceLabValidateSuccessfulLoginPositive7()
        {
            var loginPage = new LoginPageObjects();
            loginPage.OpenGooglePage("/");
            Log.Info("----- End of Positive GoogleTestForIE -----\n\r");
        }

        [Test]
        [Category(MyTestCategory.SAUCELABS_TEST)]
        public void SauceLabValidateSuccessfulLoginPositive8()
        {
            var loginPage = new LoginPageObjects();
            loginPage.OpenGooglePage("/");
            Log.Info("----- End of Positive GoogleTestForIE -----\n\r");
        }

        [Test]
        [Category(MyTestCategory.SAUCELABS_TEST)]
        public void SauceLabValidateSuccessfulLoginPositive9()
        {
            var loginPage = new LoginPageObjects();
            loginPage.OpenGooglePage("/");
            Log.Info("----- End of Positive GoogleTestForIE -----\n\r");
        }

        [Test]
        [Category(MyTestCategory.SAUCELABS_TEST)]
        public void SauceLabValidateSuccessfulLoginPositive10()
        {
            var loginPage = new LoginPageObjects();
            loginPage.OpenGooglePage("/");
            Log.Info("----- End of Positive GoogleTestForIE -----\n\r");
        }

        [Test]
        [Category(MyTestCategory.SAUCELABS_TEST)]
        public void SauceLabValidateSuccessfulLoginPositive11()
        {
            var loginPage = new LoginPageObjects();
            loginPage.OpenGooglePage("/");
            Log.Info("----- End of Positive GoogleTestForIE -----\n\r");
        }

        [Test]
        [Category(MyTestCategory.SAUCELABS_TEST)]
        public void SauceLabValidateSuccessfulLoginPositive12()
        {
            var loginPage = new LoginPageObjects();
            loginPage.OpenGooglePage("/");
            Log.Info("----- End of Positive GoogleTestForIE -----\n\r");
        }

        [Test]
        [Category(MyTestCategory.SAUCELABS_TEST)]
        public void SauceLabValidateSuccessfulLoginPositive13()
        {
            var loginPage = new LoginPageObjects();
            loginPage.OpenGooglePage("/");
            Log.Info("----- End of Positive GoogleTestForIE -----\n\r");
        }

        [Test]
        [Category(MyTestCategory.SAUCELABS_TEST)]
        public void SauceLabValidateSuccessfulLoginPositive14()
        {
            var loginPage = new LoginPageObjects();
            loginPage.OpenGooglePage("/");
            Log.Info("----- End of Positive GoogleTestForIE -----\n\r");
        }

        [Test]
        [Category(MyTestCategory.SAUCELABS_TEST)]
        public void SauceLabValidateSuccessfulLoginPositive15()
        {
            var loginPage = new LoginPageObjects();
            loginPage.OpenGooglePage("/");
            Log.Info("----- End of Positive GoogleTestForIE -----\n\r");
        }

        [Test]
        [Category(MyTestCategory.SAUCELABS_TEST)]
        public void SauceLabValidateSuccessfulLoginPositive16()
        {
            var loginPage = new LoginPageObjects();
            loginPage.OpenGooglePage("/");
            Log.Info("----- End of Positive GoogleTestForIE -----\n\r");
        }

        [Test]
        [Category(MyTestCategory.SAUCELABS_TEST)]
        public void SauceLabValidateSuccessfulLoginPositive17()
        {
            var loginPage = new LoginPageObjects();
            loginPage.OpenGooglePage("/");
            Log.Info("----- End of Positive GoogleTestForIE -----\n\r");
        }

        [Test]
        [Category(MyTestCategory.SAUCELABS_TEST)]
        public void SauceLabValidateSuccessfulLoginPositive18()
        {
            var loginPage = new LoginPageObjects();
            loginPage.OpenGooglePage("/");
            Log.Info("----- End of Positive GoogleTestForIE -----\n\r");
        }

        [Test]
        [Category(MyTestCategory.SAUCELABS_TEST)]
        public void SauceLabValidateSuccessfulLoginPositive19()
        {
            var loginPage = new LoginPageObjects();
            loginPage.OpenGooglePage("/");
            Log.Info("----- End of Positive GoogleTestForIE -----\n\r");
        }

        [Test]
        [Category(MyTestCategory.SAUCELABS_TEST)]
        public void SauceLabValidateSuccessfulLoginPositive20()
        {
            var loginPage = new LoginPageObjects();
            loginPage.OpenGooglePage("/");
            Log.Info("----- End of Positive GoogleTestForIE -----\n\r");
        }

        [Test]
        [Category(MyTestCategory.SAUCELABS_TEST)]
        public void SauceLabValidateSuccessfulLoginPositive21()
        {
            var loginPage = new LoginPageObjects();
            loginPage.OpenGooglePage("/");
            Log.Info("----- End of Positive GoogleTestForIE -----\n\r");
        }

    }
}
