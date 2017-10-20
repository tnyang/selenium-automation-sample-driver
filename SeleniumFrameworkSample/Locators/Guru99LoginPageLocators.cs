using OpenQA.Selenium;

namespace SeleniumFrameworkV2Sample.Locators
{
    class Guru99LoginPageLocators
    {
        public static By user99GuruName = By.Name("uid");
        public static By password99Guru = By.Name("password");
        public static By login = By.Name("btnLogin");
        public static By titleText = By.ClassName("barone");
    }
}
