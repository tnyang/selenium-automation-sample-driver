using SeleniumFrameworkV2Sample.PageObjects;
using OpenQA.Selenium;
using Healthgrades.TestAutomation.SeleniumFramework.Core;

namespace SeleniumFrameworkV2Sample.HtmlObjects
{
    class HyperLinkPage : BasePageObjects
    {
        public HyperLinkPage() { }

        private HyperlinkObject hyperlinkObj = new HyperlinkObject("link", By.Id("link"));


        public string GetHyperLinkText()
        {
            return hyperlinkObj.GetHyperlinkText();
        }


    }
}
