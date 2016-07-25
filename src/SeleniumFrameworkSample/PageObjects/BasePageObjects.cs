using Healthgrades.TestAutomation.SeleniumFramework.Core;
using SeleniumFrameworkV2Sample.Locators;
using System;

namespace SeleniumFrameworkV2Sample.PageObjects
{
    class BasePageObjects
    {
        #region Header Element Objects
        public static HyperlinkObject logoLink = new HyperlinkObject("logoLink", BaseLocators.logoLinkLocator);
        public static TextFieldObject universalSearch = new TextFieldObject("universalSearch", BaseLocators.universalSearchLocator);
        #endregion

        #region Footer Element Objects
        public static OtherObject loadingBar = new OtherObject("loadingBar", BaseLocators.loadingBarLocator);
        #endregion
        public void OpenPage(string pageUrl)
        {
            WebDriverTestBase.Driver.Navigate().GoToUrl(Config.Settings.runTimeSettings.EnvironmentUrl + pageUrl);
            Console.WriteLine("Go to url: " + Config.Settings.runTimeSettings.EnvironmentUrl + pageUrl);
        }
    }
}
