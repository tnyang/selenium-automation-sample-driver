using Healthgrades.TestAutomation.SeleniumFramework.Core;
using SeleniumFrameworkV2Sample.Locators;
using System;
using System.Threading;

namespace SeleniumFrameworkV2Sample.PageObjects
{
    public class ReviewYourDoctorResultsPageObjects : BasePageObjects
    {
        #region Elements
        private OtherObject resultsLabel = new OtherObject("resultsLabel", ReviewYourDoctorResultsPageLocators.resultsLabel);

        #endregion

        #region methods
        public bool isResultsMessagePresent()
        {
            resultsLabel.WaitUntilPresent(5000);

            if (resultsLabel.GetText().ToString().Contains("Results for Family Medicine"))
            {
                return true;
            }
           
            return false;
        }
        #endregion



    }
}
