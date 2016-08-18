using Healthgrades.TestAutomation.SeleniumFramework.Core;
using NUnit.Framework;
using SeleniumFrameworkV2Sample.PageObjects;
using System;
using TechTalk.SpecFlow;

namespace SeleniumFrameworkV2Sample
{
    // if need to reference multiple feature files
    [Scope(Feature = "Login to healthgrades Admin")]
    [Binding]
    public class LoginSharedSteps : WebDriverTestBase
    {
        protected LoginPageObjects loginPage;
        protected HomePageObjects homePage;

        [Given(@"I am at the healthgrades Admins login page")]
        public void GivenIAmAtTheHealthgradesAdminsLoginPage()
        {
            loginPage = new LoginPageObjects();
            loginPage.OpenPage("/#/Login");
        }
               

        [When(@"I enter email user id ""(.*)"" and password ""(.*)""")]
        public void WhenIEnterEmailUserIdAndPassword(string userName, string password)
        {
            homePage = loginPage.Login(userName, password);
        }

        [Then(@"the homepage logo is present")]
        public void ThenTheHomepageLogoIsPresent()
        {
            Assert.IsTrue(homePage.isLogoLinkPresent(), "There is an issue with login.");
        }


    }
}
