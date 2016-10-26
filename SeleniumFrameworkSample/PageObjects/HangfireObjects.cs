using Healthgrades.TestAutomation.SeleniumFramework.Core;
using Ams.Acceptance.Testing.Locators;
using System;
using System.Configuration;
using System.Threading;

namespace Ams.Acceptance.Testing.PageObjects
{
    public class HangfireObjects : BasePageObjects
    {
        #region Elements
        public TextFieldObject userNameBox = new TextFieldObject("userNameBox", HangfireLocators.UserNameBoxLocator);
        public PasswordTextFieldObject passwordBox = new PasswordTextFieldObject("passwordBox", HangfireLocators.PasswordBoxLocator);
        public ButtonObject loginButton = new ButtonObject("loginButton", HangfireLocators.LoginButtonLocator);
        public ButtonObject triggerButton = new ButtonObject("triggerButton", HangfireLocators.TriggerButtonLocator);

        public CheckboxObject JobCheckbox(string jobName)
        {
            return new CheckboxObject("JobCheckbox", HangfireLocators.JobCheckboxLocator(jobName));
        }
        public OtherObject JobCounts(string jobName)
        {
            return new OtherObject("JobCheckbox", HangfireLocators.JobCountsLocator(jobName));
        }


        #endregion

        #region methods

        public void OpenHangfireLoginPage()
        {
            WebDriverTestBase.Driver.Navigate().GoToUrl(ConfigurationManager.AppSettings["hangfireUrl"] + "/AppointmentManagement/Account/Login?ReturnUrl=%2FAppointmentManagement%2Fdashboard");
        }
        public void Login(string username, string password)
        {
            userNameBox.SetText(username);
            userNameBox.GetText();
            passwordBox.SetText(password);
            loginButton.Click();
            Thread.Sleep(5000);
        }
        public bool IsRecurringJobsTabDisIsplayed()
        {
            Thread.Sleep(5000);
            return LinkByHref("/recurring").IsElementDisplayed();
        }
        public void ClickOnRecurringJobsTab ()
        {
            LinkByHref("/recurring").Click();
            Thread.Sleep(1000);
        }
        public void ClickOnJobsTab()
        {
            LinkByHref("/enqueued").Click();
            Thread.Sleep(1000);
        }
        public bool IsJobPresent(string jobName)
        {
            return JobCheckbox(jobName).IsElementDisplayed();
        }
        public void CheckJob(string jobName)
        {
            JobCheckbox(jobName).Click();
        }
        public string GetJobCounts(string jobName)
        {
            return JobCounts(jobName).element.Text;
        }
        public void ClickOnTriggerButton()
        {
            triggerButton.Click();
        }
       
    }
    #endregion
}
