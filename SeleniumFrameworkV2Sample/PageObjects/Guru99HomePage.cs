
using Healthgrades.TestAutomation.SeleniumFramework.Core;
using SeleniumFrameworkV2Sample.Locators;
using System;

namespace SeleniumFrameworkV2Sample.PageObjects
{
    public class Guru99HomePage : BasePageObjects
    {
        public OtherObject homePageUserName = new OtherObject("homePageUserName", Guru99HomePageLocators.homePageUserName);

        public String getHomePageDashboardUserName()
        {
            return homePageUserName.GetText();
        }

    }
}
