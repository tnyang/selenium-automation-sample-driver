using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Healthgrades.TestAutomation.SeleniumFramework.Core;
using SeleniumFrameworkV2Sample.Locators;

namespace SeleniumFrameworkV2Sample.PageObjects
{
    class ProviderProfileObjects : BasePageObjects
    {
        #region Elements
        public DropDownListObject appointmentType = new DropDownListObject("AppointmentType", ProviderProfileLocators.AppointmentTypeFilterLocator);
        #endregion

        #region methods

        public void OpenPage(string pageUrl)
        {
            WebDriverTestBase.Driver.Navigate().GoToUrl(Config.Settings.runTimeSettings.EnvironmentUrl + pageUrl);
            Console.WriteLine("Go to url: " + Config.Settings.runTimeSettings.EnvironmentUrl + pageUrl);
        }


        public bool VerifyAppointmentTypeFilterOptions(string appointmentTypeDropDownOption)
        {
            return true;
            //appointmentType.Options.Where()
            //return appointmentType.VerifyOption(appointmentTypeDropDownOption);
        }
        #endregion
    }
}
