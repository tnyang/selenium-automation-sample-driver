using OpenQA.Selenium;

namespace SeleniumFrameworkV2Sample.Locators
{
    class HGReviewDoctorPageLocators
    {
        public static By searchTextField = By.Id("search-term-selector-child");
        public static By searchLocationTextField = By.Id("search-location-selector-child");
        public static By searchButton = By.ClassName("autosuggest__submiter");
    }
}
