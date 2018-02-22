using Healthgrades.TestAutomation.SeleniumFramework.Core;
using NUnit.Framework;
using OpenQA.Selenium;
using System;

namespace SeleniumFrameworkV2Sample
{
    [TestFixture]
    public class TextFieldTests : WebDriverTestBase
    {

        [Test]
        [Category("TextFieldTests")]
        public void SetText()
        {
            HtmlObjects.TextField htmlTextfield = new HtmlObjects.TextField();

            htmlTextfield.OpenHtmlPage("TextFieldPage.html");

            htmlTextfield.SetText("abcd");

            string text = htmlTextfield.GetText();

           Assert.AreEqual(text, "abcd", "The textfield SetText() was value is wrong: " + text + " expected: " + "abcd");           
        }

        [Test]
        [Category("TextFieldTests")]
        public void GetText()
        {
            HtmlObjects.TextField htmlTextfield = new HtmlObjects.TextField();

            htmlTextfield.OpenHtmlPage("TextFieldPage.html");

            string text = htmlTextfield.GetText();

            Assert.AreEqual(text, "1234", "The textfield GetText() was value is wrong: " + text + " expected: " + "1234");
        }

        [Test]
        [Category("TextFieldTests")]
        public void ClearText()
        {
            HtmlObjects.TextField htmlTextfield = new HtmlObjects.TextField();

            htmlTextfield.OpenHtmlPage("TextFieldPage.html");

            htmlTextfield.ClearText();

            string text = htmlTextfield.GetText();

            Assert.AreEqual(text, "", "The textfield ClearText() was value is wrong: " + text + " expected: " + "");
        }




    }
}
