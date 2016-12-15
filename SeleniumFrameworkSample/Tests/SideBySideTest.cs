using Healthgrades.TestAutomation.SeleniumFramework.Core;
using NUnit.Framework;
using SeleniumFrameworkV2Sample.PageObjects;
using SeleniumFrameworkV2Sample.Utils;

namespace SeleniumFrameworkV2Sample
{
    [TestFixture]
    public class LoginTest : WebDriverTestBase
    {

        [Test]
        [Category(MyTestCategory.SINGLE_POSITIVE)]
        [Category(MyTestCategory.NIGHTLY_RUN)]
        public void ValidateOtpionsInAppointmentFilterDropDown()
        {
            var providerProfile = new ProviderProfileObjects();
            providerProfile.OpenPage("/physician/dr-anthony-sanchez-y3ydh");

            Assert.IsTrue(providerProfile.VerifyAppointmentTypeFilterOptions("New"));
            Assert.IsTrue(providerProfile.VerifyAppointmentTypeFilterOptions("Existing"));
            //Assert.IsFalse(providerProfile.VerifyAppointmentTypeFilterOptions("Both"));
            Log.Info("----- End of Positive test 1 -----\n\r");
        }

        
    }
}
