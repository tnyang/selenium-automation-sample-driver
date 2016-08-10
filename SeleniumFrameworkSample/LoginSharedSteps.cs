using Healthgrades.TestAutomation.SeleniumFramework.Core;
using SeleniumFrameworkV2Sample.PageObjects;
using SeleniumFrameworkV2Sample.Tests_Gherkin;
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

        [Given(@"I am at the healthgrades Admins login page for environment '(.*)'")]
        public void GivenIAmAtTheHealthgradesAdminsLoginPageForEnvironment(string environment)
        {
            Console.WriteLine("---------------@@@@@@@@@@@@@@@@@@@@@@@@ GivenIAmAtTheHealthgradesAdminsLoginPageForEnvironment");
            loginPage = new LoginPageObjects();
            loginPage.OpenPage("/#/Login");
            Console.WriteLine("GivenIAmAtTheHealthgradesAdminsLoginPageForEnvironment");
        }
               

        [When(@"I enter email user id ""(.*)"" and password ""(.*)""")]
        public void WhenIEnterEmailUserIdAndPassword(string userName, string password)
        {
            var homePage = loginPage.Login(userName, password);
            Console.WriteLine("WhenIEnterEmailUserIdAndPassword");
        }


        [Then(@"the result should be (.*) on the screen")]
        public void ThenTheResultShouldBeOnTheScreen(int p0)
        {
            Console.WriteLine("ThenTheResultShouldBeOnTheScreen");
        }

        [When(@"I clicked on the submit button")]
        public void WhenIClickedOnTheSubmitButton()
        {
            ScenarioContext.Current.Pending();
        }


    }
}
