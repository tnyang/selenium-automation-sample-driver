using Healthgrades.TestAutomation.SeleniumFramework.Core;
using NUnit.Framework;
using OpenQA.Selenium;

namespace SeleniumFrameworkV2Sample
{
    [TestFixture]
    public class CheckBoxTests : WebDriverTestBase
    {

        [Test]
        [Category("CheckBoxTests")]
        public void CheckBoxIsChecked()
        {
            HtmlObjects.CheckBoxPage htmlCheckbox = new HtmlObjects.CheckBoxPage();

            htmlCheckbox.OpenPage("/CheckBoxPage.html");

            bool selected = htmlCheckbox.IsChecked();
           Assert.AreEqual(selected, false, "The checkbox IsChecked() was value is wrong: " + selected + " expected: " + "false");           
        }

        [Test]
        [Category("CheckBoxTests")]
        public void CheckBoxCheck()
        {
            HtmlObjects.CheckBoxPage htmlCheckbox = new HtmlObjects.CheckBoxPage();

            htmlCheckbox.OpenPage("/CheckBoxPage.html");

            htmlCheckbox.Check();

            string displayedText = htmlCheckbox.GetCheckedAttribute();

            Assert.AreEqual(displayedText, "true", "The checkbox Check() was value is wrong: " + displayedText + " expected: " + "true");
        }

    }
}
