using Healthgrades.TestAutomation.SeleniumFramework.Core;
using NUnit.Framework;
using SeleniumFrameworkV2Sample.PageObjects;
using System;

namespace SeleniumFrameworkV2Sample
{
    [TestFixture]
    public class ProviderProfileTests : WebDriverTestBase
    {

        [Test]
        [Category("SampleTest")]
        public void AssertVideoDisplaysOnProviderProfilePg()
        {
            var providerProfilePage = new ProviderProfileObjects();

            providerProfilePage.OpenPageBypassingModal("/physician/dr-amy-rabalais-3nf8x");
            Assert.IsTrue(providerProfilePage.isVideoPresent(),
                "Video container didn't display on Provider Profile page");
        }

        [Test]
        [Category("OCTOPUS")]
        public void Octo1()
        {
            Assert.IsTrue(true);
        }

        [Test]
        [Category("OCTOPUS_TEST")]
        public void Octo2()
        {
            Assert.IsTrue(true);
        }
    }
}
