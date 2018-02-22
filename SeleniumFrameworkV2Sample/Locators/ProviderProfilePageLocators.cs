using OpenQA.Selenium;

namespace SeleniumFrameworkV2Sample.Locators
{
    class ProviderProfilePageLocators
    {
        public static readonly By VideoLocator = By.XPath("//*[@data-qa-target='learn-video-section' or contains(@class, 'about-me-video')]");
 
    }
}
