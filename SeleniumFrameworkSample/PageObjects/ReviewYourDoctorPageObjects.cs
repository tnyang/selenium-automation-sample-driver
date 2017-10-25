using Healthgrades.TestAutomation.SeleniumFramework.Core;
using SeleniumFrameworkV2Sample.Locators;

namespace SeleniumFrameworkV2Sample.PageObjects
{
    public class ReviewYourDoctorPageObjects : BasePageObjects
    {
        #region Elements
        private TextFieldObject searchBoxLocator = new TextFieldObject("searchBoxLocator", ReviewYourDoctorPageLocators.searchBoxLocator);
        private TextFieldObject locationBoxLocator = new TextFieldObject("locationBoxLocator", ReviewYourDoctorPageLocators.locationBoxLocator);
        private ButtonObject searchButtonLocator = new ButtonObject("searchButtonLocator", ReviewYourDoctorPageLocators.searchButtonLocator);

        #endregion

        #region methods
        public ReviewYourDoctorResultsPageObjects SearchDoctor(string search, string near)
        {
            searchBoxLocator.SetText(search);
            locationBoxLocator.SetText(near);
            searchButtonLocator.Click();

            return new ReviewYourDoctorResultsPageObjects();
        }
        #endregion

       
    }
}
