using Healthgrades.TestAutomation.SeleniumFramework.Core;
using NUnit.Framework;
using OpenQA.Selenium;
using System;

namespace SeleniumFrameworkV2Sample
{
    [TestFixture]
    public class DropDownListTests : WebDriverTestBase
    {

        [Test]
        [Category("DropDownListTests")]
        public void GetSelectedElement()
        {
            HtmlObjects.DropDownListPage htmlDropdownlist = new HtmlObjects.DropDownListPage();

            htmlDropdownlist.OpenHtmlPage("DropDownListPage.html");

            string selected = htmlDropdownlist.GetSelectedElement();
           Assert.AreEqual(selected, "cat", "The dropdownlist GetSelectedElement() was value is wrong: " + selected + " expected: " + "cat");           
        }

        [Test]
        [Category("DropDownListTests")]
        public void SelectByText()
        {
            HtmlObjects.DropDownListPage htmlDropdownlist = new HtmlObjects.DropDownListPage();

            htmlDropdownlist.OpenHtmlPage("DropDownListPage.html");

            htmlDropdownlist.SelectByText("mouse");

            string selected = htmlDropdownlist.GetSelectedElement();
            Assert.AreEqual(selected, "mouse", "The dropdownlist SelectByText() was value is wrong: " + selected + " expected: " + "mouse");
        }

        [Test]
        [Category("DropDownListTests")]
        public void GetOptions()
        {
            HtmlObjects.DropDownListPage htmlDropdownlist = new HtmlObjects.DropDownListPage();

            htmlDropdownlist.OpenHtmlPage("DropDownListPage.html");

            System.Collections.Generic.List<string> animals = new System.Collections.Generic.List<string>(new string[] { "cat", "dog", "mouse" });

            System.Collections.Generic.IList<IWebElement> list = htmlDropdownlist.GetOptions();

            int index = 0;
            foreach(IWebElement op in list)
            {
                string curitem = op.Text;
                string curdropdownitem = animals[index].ToString();
                Assert.AreEqual(curitem, curdropdownitem, "The dropdownlist GetOptions() was value is wrong at index[" + index + "]: " + curitem + " expected: " + curdropdownitem);
                index++;
            }

         }


    }
}
