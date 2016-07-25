using OpenQA.Selenium;


namespace SeleniumFrameworkV2Sample.Locators
{
    class BaseLocators
    {
        #region Header Element Locators
        public static By logoLinkLocator = By.Id("hgfui-flyout-button"); //changed id to make it an element which exists only after login:)
        public static By universalSearchLocator = By.XPath("//a[@href='#/Search']");
        #endregion

        #region Footer Element Locators
        public static By loadingBarLocator = By.XPath("//div[@class='loading-container']");
        #endregion
    }
}
