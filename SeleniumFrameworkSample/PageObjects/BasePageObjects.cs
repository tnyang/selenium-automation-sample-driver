using Healthgrades.TestAutomation.SeleniumFramework.Core;
using Ams.Acceptance.Testing.Locators;
using System;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Interactions.Internal;
using OpenQA.Selenium.Support.UI;
using System.Threading;

namespace Ams.Acceptance.Testing.PageObjects
{
    public abstract class BasePageObjects
    {
        public OtherObject LinkByText(string text)
        {
            return new OtherObject("Link", BaseLocators.LinkByTextLocator(text));
        }
        public OtherObject LinkByHref(string text)
        {
            return new OtherObject("Link", BaseLocators.LinkByHrefLocator(text));
        }
        public OtherObject Text(string text)
        {
            return new OtherObject("Link", BaseLocators.TextLocator(text));
        }
        public OtherObject AnyElement(string text)
        {
            return new OtherObject("Link", BaseLocators.AnyElementLocator(text));
        }


        #region Methods
        public void OpenPage(string pageUrl)
        {
            WebDriverTestBase.Driver.Navigate().GoToUrl(Config.Settings.runTimeSettings.EnvironmentUrl + pageUrl);
            Console.WriteLine("Go to url: " + Config.Settings.runTimeSettings.EnvironmentUrl + pageUrl);
        }
        public bool isLinkPresent(string text)
        {
            LinkByText(text).WaitUntilPresent(5000);
            return LinkByText(text).IsElementDisplayed();
        }
        public void ClickLinkBasedOnText(string text)
        {
            LinkByText(text).WaitUntilPresent(5000);
            LinkByText(text).Click();
        }
        public void ClickLinkBasedOnPartialHref(string text)
        {
            Thread.Sleep(5000);
            LinkByHref(text).Click();
        }
        public bool IsStringPresent(string text)
        {
            return AnyElement(text).IsElementDisplayed();
        }
        #endregion
    }
}
