using OpenQA.Selenium;

namespace SeleniumFrameworkV2Sample.Locators
{
    class LoginPageLocators
    {
        
        public static readonly By UserNameBoxLocator = By.Id("Email");
        public static readonly By PasswordBoxLocator = By.Id("Password");
        public static readonly By LoginButtonLocator = By.XPath("//button[contains(text(), 'Login')]");
        public static readonly By UnsuccssfulTextMessageLocator = By.XPath("//*[@id='loginForm']/form/div/div/div[6]/div[contains(text(), 'The user name or password is incorrect')]");
    }
}
