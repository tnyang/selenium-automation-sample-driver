using OpenQA.Selenium;

namespace SeleniumFrameworkV2Sample.Locators
{
    class LoginPageLocators
    {
        
        public static By UserNameBoxLocator = By.Id("Email");
        public static By PasswordBoxLocator = By.Id("Password");
        public static By LoginButtonLocator = By.XPath("//button[contains(text(), 'Login')]");
        public static By UnsuccssfulTextMessageLocator = By.XPath("//*[@id='loginForm']/form/div/div/div[6]/div[contains(text(), 'The user name or password is incorrect')]");
    }
}
