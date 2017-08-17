using Healthgrades.TestAutomation.SeleniumFramework.Core;
using NUnit.Framework;
using SeleniumFrameworkV2Sample.PageObjects;
using SeleniumFrameworkV2Sample.Utils;
using SeleniumFrameworkV2Sample.SqlDatabase;

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


        //[Test]
        //[Category(MyTestCategory.SINGLE_POSITIVE)]
        //[Category(MyTestCategory.NIGHTLY_RUN)]
        //public void ValidateSuccessfulLoginSinglePositive()
        //{
        //    string userName = "mbadyelkhan@healthgrades.com"; 
        //    string password = "Abcd1234!";
        //    var loginPage = new LoginPageObjects();
        //    loginPage.OpenPage("/#/Login");
        //    var homePage = loginPage.Login(userName, password);
        //    Assert.IsTrue(homePage.isLogoLinkPresent(), "There is an issue with login.");
        //    string sourcecode = homePage.GetViewSourceCode();
        //    System.Console.WriteLine("SOURCE CODE:");
        //    System.Console.WriteLine(sourcecode);
        //    Log.Info("----- End of Positive test 1 -----\n\r");
        //}
        //[Test]
        //[Category(MyTestCategory.SINGLE_POSITIVE)]
        //public void ValidateSuccessfulLoginSinglePositive2()
        //{
        //    //This test passes
        //}
        //[Test]
        //[Category(MyTestCategory.SINGLE_POSITIVE)]
        //public void ValidateSuccessfulLoginSinglePositive3()
        //{
        //    //This test fails
        //    Assert.IsTrue(true, "Always fail");
        //}

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
            //var loginPage = new LoginPageObjects();
            //loginPage.OpenGooglePage("/");
            //Log.Info("----- End of Positive GoogleTestForIE -----\n\r");

            //SQL tests
            SqlDatabaseHelper sqlHelper = new SqlDatabaseHelper();
            HealthGradesWebDbNotificationTblQueries queries = new HealthGradesWebDbNotificationTblQueries();

            var list = sqlHelper.ExecuteSelectQuery(queries.selectNotificationsBasedOnAppointmentId("36693"));
            string firstOne = list[0]["NotificationID"];
            var update = sqlHelper.ExecuteUpdateOrDeleteQuery(queries.updateNotificationSetDate("31903", "36693"));

            ////Solr tests
            //HttpRequestHelper solrHelper = new HttpRequestHelper();
            //solrHelper.GetSolrData("/solr/autosuggest/select?q=*%3A*&wt=json&indent=true");
        }

        [Test]
        [Category("SQLTest")]
        public void SQLSampleTest()
        {
            SqlDatabaseHelper sqlHelper = new SqlDatabaseHelper();
            HealthGradesWebDbNotificationTblQueries myQueries = new HealthGradesWebDbNotificationTblQueries();
            var countList = sqlHelper.ExecuteSelectQuery(myQueries.GetNotificationCount());
            var count = countList[0]["counts"];
            Assert.AreEqual(count, "11193");
        }

        [Test]
        [Category("TestChromeLoad")]
        public void ValidateSuccessfulLoginSinglePositive()
        {
            string userName = "mbadyelkhan@healthgrades.com";
            string password = "Abcd1234!";
            var loginPage = new LoginPageObjects();
            loginPage.OpenPage("");
            Log.Info("----- End of TestChromeLoad test 1 -----\n\r");
        }
        [Test]
        [Category("TestChromeLoad")]
        public void ValidateSuccessfulLoginSinglePositive2()
        {
            string userName = "mbadyelkhan@healthgrades.com";
            string password = "Abcd1234!";
            var loginPage = new LoginPageObjects();
            loginPage.OpenPage("");
            Log.Info("----- End of TestChromeLoad test 1 -----\n\r");
        }


    }
}
