
using Healthgrades.TestAutomation.SeleniumFramework.Core;
using SeleniumFrameworkV2Sample.Locators;
using System;

namespace SeleniumFrameworkV2Sample.PageObjects
{
    public class Guru99LoginPage : BasePageObjects
    {
        public TextFieldObject user99GuruName = new TextFieldObject("user99GuruName", Guru99LoginPageLocators.user99GuruName);
        public TextFieldObject password99Guru = new TextFieldObject("password99Guru", Guru99LoginPageLocators.password99Guru);
        public ButtonObject login = new ButtonObject("login", Guru99LoginPageLocators.login);
        public OtherObject titleText = new OtherObject("titleText", Guru99LoginPageLocators.titleText);


        //Set user name in textbox
        public void setUserName(String strUserName)
        {
            user99GuruName.SetText(strUserName); ;
        }

        //Set password in password textbox
        public void setPassword(String strPassword)
        {
            password99Guru.SetText(strPassword);
        }

        //Click on login button
        public void clickLogin()
        {
            login.Click();
        }

        //Get the title of Login Page
        public String getLoginTitle()
        {
            return titleText.GetText();
        }
        /**
         * This POM method will be exposed in test case to login in the application
         * @param strUserName
         * @param strPasword
         * @return
         */
        public Guru99HomePage loginToGuru99(String strUserName, String strPasword)
        {
            //Fill user name
            this.setUserName(strUserName);
            //Fill password
            this.setPassword(strPasword);
            //Click Login button
            this.clickLogin();

            return new Guru99HomePage();
        }

    }
}
