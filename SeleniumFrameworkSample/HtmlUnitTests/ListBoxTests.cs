using Healthgrades.TestAutomation.SeleniumFramework.Core;
using NUnit.Framework;
using OpenQA.Selenium;
using System;

namespace SeleniumFrameworkV2Sample
{
    [TestFixture]
    public class ListBoxTests : WebDriverTestBase
    {

        [Test]
        [Category("ListBoxTests")]
        public void GetSelectedElement()
        {
            HtmlObjects.ListBoxPage htmlListbox = new HtmlObjects.ListBoxPage();

            htmlListbox.OpenPage("/ListBoxPage.html");

            string selected = htmlListbox.GetSelectedElement();
           Assert.AreEqual(selected, "apple", "The dropdownlist GetSelectedElement() was value is wrong: " + selected + " expected: " + "apple");           
        }

        [Test]
        [Category("ListBoxTests")]
        public void SelectByText()
        {
            HtmlObjects.ListBoxPage htmlListbox = new HtmlObjects.ListBoxPage();

            htmlListbox.OpenPage("/ListBoxPage.html");

            htmlListbox.SelectByText("cherry");

            string selected = htmlListbox.GetSelectedElement();
            Assert.AreEqual(selected, "cherry", "The dropdownlist SelectByText() was value is wrong: " + selected + " expected: " + "cherry");
        }

       


    }
}
