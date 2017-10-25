using OpenQA.Selenium;

namespace SeleniumFrameworkV2Sample.Locators
{
    class ReviewYourDoctorPageLocators
    {
        
        public static readonly By searchBoxLocator = By.CssSelector("#search-term-selector-child");
        public static readonly By locationBoxLocator = By.CssSelector("#search-location-selector-child");
        public static readonly By searchButtonLocator = By.CssSelector(".autosuggest__submiter");
    }
}
