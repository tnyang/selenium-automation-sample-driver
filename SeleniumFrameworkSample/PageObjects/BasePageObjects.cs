using Healthgrades.TestAutomation.SeleniumFramework.Core;
using SeleniumFrameworkV2Sample.Locators;
using System;

namespace SeleniumFrameworkV2Sample.PageObjects
{
    public abstract class BasePageObjects
    {
        #region Header Element Objects
        public HyperlinkObject logoLink = new HyperlinkObject("logoLink", BaseLocators.logoLinkLocator);
        public TextFieldObject universalSearch = new TextFieldObject("universalSearch", BaseLocators.universalSearchLocator);
        #endregion

        #region Footer Element Objects
        public OtherObject loadingBar = new OtherObject("loadingBar", BaseLocators.loadingBarLocator);
        #endregion


        public void OpenPage(string pageUrl)
        {
                WebDriverTestBase.Driver.Navigate().GoToUrl(Config.Settings.runTimeSettings.EnvironmentUrl + pageUrl);
                Console.WriteLine("Go to url: " + Config.Settings.runTimeSettings.EnvironmentUrl + pageUrl);            
        }
        public void OpenGooglePage(string pageUrl)
        {
            WebDriverTestBase.Driver.Navigate().GoToUrl("https://www.google.com/" + pageUrl);            
        }
    }
}
