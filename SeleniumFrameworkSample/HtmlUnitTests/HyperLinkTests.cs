using Healthgrades.TestAutomation.SeleniumFramework.Core;
using NUnit.Framework;
using System;

namespace SeleniumFrameworkV2Sample
{
    [TestFixture]
    public class HyperLinkTests : WebDriverTestBase
    {

        [Test]
        [Category("HyperLinkTests")]
        public void GetHyperLinkText()
        {
            HtmlObjects.HyperLinkPage htmlHyperlink = new HtmlObjects.HyperLinkPage();
            htmlHyperlink.OpenPage("/HyperLinkPage.html");
            string ahref = htmlHyperlink.GetHyperLinkText();

            Assert.AreEqual(ahref, "https://www.google.com/", "The hyperlink GetHyperLinkText() did not return the correct text: " + ahref + " expected: " + "https://www.google.com/");
        }

}
}
