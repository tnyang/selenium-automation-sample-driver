using Healthgrades.TestAutomation.SeleniumFramework.Core;
using NUnit.Framework;

namespace SeleniumFrameworkV2Sample
{
    // ************ NOTE: NEED TO FINISH UNIT TESTS FOR THIS CLASS.....................

    [TestFixture]
    public class OtherObjectTests : WebDriverTestBase
    {

        [Test]
        [Category("OtherObjectTests")]
        public void Click()
        {
            HtmlObjects.OtherObjectPage htmlOtherobject = new HtmlObjects.OtherObjectPage();
            htmlOtherobject.OpenHtmlPage("MainPage.html");

            htmlOtherobject.buttonObj.Click();

            string displaytext = htmlOtherobject.buttonDemoText.GetAttribute("innerHTML");
            Assert.AreEqual(displaytext, "Hello World", "The otherobject Click() did not return the correct text: " + displaytext + " expected: " + "Hellow World");
        }

        [Test]
        [Category("OtherObjectTests")]
        public void GetSelectedElement()
        {
            HtmlObjects.OtherObjectPage htmlOtherobject = new HtmlObjects.OtherObjectPage();
            htmlOtherobject.OpenHtmlPage("MainPage.html");

            string selected = htmlOtherobject.listboxObj.GetSelectedElement();

            Assert.AreEqual(selected, "apple", "The otherobject GetSelectedElement() was value is wrong: " + selected + " expected: " + "apple");
        }

        [Test]
        [Category("OtherObjectTests")]
        public void SelectByText()
        {
            HtmlObjects.OtherObjectPage htmlOtherobject = new HtmlObjects.OtherObjectPage();

            htmlOtherobject.OpenHtmlPage("MainPage.html");

            htmlOtherobject.listboxObj.SelectByText("cherry");

            string selected = htmlOtherobject.listboxObj.GetSelectedElement();
            Assert.AreEqual(selected, "cherry", "The otherobject SelectByText() was value is wrong: " + selected + " expected: " + "cherry");
        }




    }
}
