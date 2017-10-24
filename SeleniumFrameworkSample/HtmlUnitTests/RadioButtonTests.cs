using Healthgrades.TestAutomation.SeleniumFramework.Core;
using NUnit.Framework;
using OpenQA.Selenium;

namespace SeleniumFrameworkV2Sample
{
    [TestFixture]
    public class RadioButtonTests : WebDriverTestBase
    {

        [Test]
        [Category("RadioButtonTests")]
        public void RadioButtonIsSelect()
        {
            HtmlObjects.RadioButton htmlRadio = new HtmlObjects.RadioButton();

            htmlRadio.OpenPage("/RadioButtonPage.html");

            bool selected = htmlRadio.IsSelected();
           Assert.AreEqual(selected, false, "The radio button isSelect() was value is wrong: " + selected + " expected: " + "false");           
        }

        [Test]
        [Category("RadioButtonTests")]
        public void RadioButtonSelect()
        {
            HtmlObjects.RadioButton htmlRadio = new HtmlObjects.RadioButton();

            htmlRadio.OpenPage("/RadioButtonPage.html");

            htmlRadio.Select();

            bool selected = htmlRadio.IsSelected();
            Assert.AreEqual(selected, true, "The radio button Select() was value is wrong: " + selected + " expected: " + "true");
        }

    }
}
