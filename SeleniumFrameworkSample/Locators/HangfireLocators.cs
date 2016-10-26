using OpenQA.Selenium;

namespace Ams.Acceptance.Testing.Locators
{
    public class HangfireLocators
    {
        
        public static readonly By UserNameBoxLocator = By.Id("UserName");
        public static readonly By PasswordBoxLocator = By.Id("Password");
        public static readonly By LoginButtonLocator = By.XPath("//input[@value='Log in']");
        public static readonly By TriggerButtonLocator = By.XPath("//button[@data-loading-text='Triggering...']");

        public static By JobCheckboxLocator(string jobName)
        {
            return By.XPath("//input[@value='Update Providers']");
        }
        public static By JobCountsLocator(string jobName)
        {
            return By.XPath("//a[contains(@href, '" + jobName.ToLower() + "')]/span/span");
        }
    }
}
