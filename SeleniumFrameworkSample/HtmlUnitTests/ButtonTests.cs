using Healthgrades.TestAutomation.SeleniumFramework.Core;
using NUnit.Framework;

namespace SeleniumFrameworkV2Sample
{
    [TestFixture]
    public class ButtonTests : WebDriverTestBase
    {

        [Test]
        [Category("ButtonTests")]
        public void ButtonClick()
        {
            HtmlObjects.ButtonPage htmlButton = new HtmlObjects.ButtonPage();
            htmlButton.OpenPage("/ButtonPage.html");
            htmlButton.Click();

            string displaytext = htmlButton.getDisplayedText();
            Assert.AreEqual(displaytext, "Hello World", "The button Click() did not return the correct text: " + displaytext + " expected: " + "Hellow World");
        }

}
}
