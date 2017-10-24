using SeleniumFrameworkV2Sample.PageObjects;
using OpenQA.Selenium;
using Healthgrades.TestAutomation.SeleniumFramework.Core;
using System.Collections.Generic;

namespace SeleniumFrameworkV2Sample.HtmlObjects
{
    class DropDownListPage : BasePageObjects
    {
        public DropDownListPage() { }

        private DropDownListObject dropdownlistObj = new DropDownListObject("select", By.Id("select"));

        public string GetSelectedElement()
        {
            return dropdownlistObj.GetSelectedElement();
        }

        public void SelectByText(string text)
        {
            dropdownlistObj.SelectByText(text);
        }

        public IList<IWebElement> GetOptions()
        {
            return dropdownlistObj.GetOptions();
        }

    }
}
