using OpenQA.Selenium;


namespace SeleniumFrameworkV2Sample.Locators
{
    class BaseLocators
    {
        #region Header Element Locators
        public static readonly By logoLinkLocator = By.Id("hgfui-flyout-button"); //changed id to make it an element which exists only after login:)
        public static readonly By universalSearchLocator = By.Id("search-term-selector-child");
        #endregion

        #region Footer Element Locators
        public static readonly By loadingBarLocator = By.XPath("//div[@class='loading-container']");
        #endregion
    }
}
