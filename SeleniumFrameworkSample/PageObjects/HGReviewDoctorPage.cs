
using Healthgrades.TestAutomation.SeleniumFramework.Core;
using SeleniumFrameworkV2Sample.Locators;
using System;

namespace SeleniumFrameworkV2Sample.PageObjects
{
    public class HGReviewDoctorPage : BasePageObjects
    {
        public TextFieldObject searchTextField = new TextFieldObject("searchTextField", HGReviewDoctorPageLocators.searchTextField);
        public TextFieldObject searchLocationTextField = new TextFieldObject("searchLocationTextField", HGReviewDoctorPageLocators.searchLocationTextField);
        public ButtonObject searchButton = new ButtonObject("searchButton", HGReviewDoctorPageLocators.searchButton);

        //Set user name in textbox
        public void setSearch(String searchItem)
        {
            searchTextField.SetText(searchItem);
        }

        //Set password in password textbox
        public void setSearchLocation(String searchLocation)
        {
            searchLocationTextField.SetText(searchLocation);
        }

        //Click on search button
        public void clickSearch()
        {
            searchButton.Click();
        }

        public void searchYourDoctor(String searchItem, String searchLocation)
        {
            //Fill user name
            this.searchTextField(searchItem);
            //Fill password
            this.searchLocationTextField(searchLocation);
            //Click Login button
            this.searchButton();

        }

    }
}
