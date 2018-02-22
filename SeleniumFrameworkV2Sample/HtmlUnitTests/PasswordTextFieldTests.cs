using Healthgrades.TestAutomation.SeleniumFramework.Core;
using NUnit.Framework;
using OpenQA.Selenium;
using System;

namespace SeleniumFrameworkV2Sample
{
    [TestFixture]
    public class PasswordTextFieldTests : WebDriverTestBase
    {

        [Test]
        [Category("PasswordTextFieldTests")]
        public void SetText()
        {
            HtmlObjects.PasswordTextField htmlPasswordtextfield = new HtmlObjects.PasswordTextField();

            htmlPasswordtextfield.OpenHtmlPage("PasswordTextFieldPage.html");

            htmlPasswordtextfield.SetText("abcd");

            String text = htmlPasswordtextfield.GetText();

           Assert.AreEqual(text, "abcd", "The passwordtextfield SetText() was value is wrong: " + text + " expected: " + "abcd");           
        }

        [Test]
        [Category("PasswordTextFieldTests")]
        public void ClearText()
        {
            HtmlObjects.PasswordTextField htmlPasswordtextfield = new HtmlObjects.PasswordTextField();

            htmlPasswordtextfield.OpenHtmlPage("PasswordTextFieldPage.html");

            htmlPasswordtextfield.ClearText();

            string text = htmlPasswordtextfield.GetText();

            Assert.AreEqual(text, "", "The passwordtextfield ClearText() was value is wrong: " + text + " expected: " + "");
        }




    }
}
