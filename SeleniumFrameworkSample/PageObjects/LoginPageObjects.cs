using Healthgrades.TestAutomation.SeleniumFramework.Core;
using SeleniumFrameworkV2Sample.Locators;

namespace SeleniumFrameworkV2Sample.PageObjects
{
    public class LoginPageObjects : BasePageObjects
    {
        #region Elements
        public TextFieldObject userNameBox = new TextFieldObject("userNameBox", LoginPageLocators.UserNameBoxLocator);
        public PasswordTextFieldObject passwordBox = new PasswordTextFieldObject("passwordBox", LoginPageLocators.PasswordBoxLocator);
        public ButtonObject loginButton = new ButtonObject("loginButton", LoginPageLocators.LoginButtonLocator);
        public OtherObject unsuccessfulLoginLabel = new OtherObject("unsuccessfulLoginLabel", LoginPageLocators.UnsuccssfulTextMessageLocator);
        #endregion

        #region methods
        public HomePageObjects Login(string username, string password)
        {
            userNameBox.SetText(username);
            passwordBox.SetText(password);
            loginButton.Click();
            return new HomePageObjects();
        }
        #endregion

        public bool isUnsuccssfulTextMessageLocatorPresent()
        {
            return unsuccessfulLoginLabel.IsElementDisplayed();
        }

    }
}
