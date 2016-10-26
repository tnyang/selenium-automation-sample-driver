using OpenQA.Selenium;


namespace Ams.Acceptance.Testing.Locators
{
    public class BaseLocators
    {
        public static By LinkByTextLocator(string text)
        {
            return By.XPath("//a[contains(text(),'" + text + "')]");
        }
        public static By LinkByHrefLocator(string text)
        {
            return By.XPath("//a[contains(@href, '"+text+"')]");
        }
        public static By TextLocator(string text)
        {
            return By.XPath("//*[contains(text(), '"+text+"')]");
        }
        public static By AnyElementLocator(string text)
        {
            return By.XPath("//*[contains(text(),'" + text + "')]");
        }

    }
}
