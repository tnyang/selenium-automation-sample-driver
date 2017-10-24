using SeleniumFrameworkV2Sample.PageObjects;
using OpenQA.Selenium;
using Healthgrades.TestAutomation.SeleniumFramework.Core;
using System.Collections.Generic;

namespace SeleniumFrameworkV2Sample.HtmlObjects
{
    class ListBoxPage : BasePageObjects
    {
        public ListBoxPage() { }

        private ListBoxObject listboxObj = new ListBoxObject("select", By.Id("select"));

        public string GetSelectedElement()
        {
            return listboxObj.GetSelectedElement();
        }

        public void SelectByText(string text)
        {
            listboxObj.SelectByText(text);
        }

    }
}
