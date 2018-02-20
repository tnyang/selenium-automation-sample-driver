
using Healthgrades.TestAutomation.SeleniumFramework.Core;
using SeleniumFrameworkV2Sample.Locators;
using System.Threading;

namespace SeleniumFrameworkV2Sample.PageObjects
{
    public class ProviderProfileObjects : BasePageObjects
    {
        public HyperlinkObject Video = new HyperlinkObject("Video", ProviderProfilePageLocators.VideoLocator);

        public bool isVideoPresent()
        {
            Thread.Sleep(2500);
            return Video.IsElementDisplayed();
        }

    }
}
