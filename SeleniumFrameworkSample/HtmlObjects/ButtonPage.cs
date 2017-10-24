using SeleniumFrameworkV2Sample.PageObjects;
using OpenQA.Selenium;
using Healthgrades.TestAutomation.SeleniumFramework.Core;

namespace SeleniumFrameworkV2Sample.HtmlObjects
{
    class ButtonPage : BasePageObjects
    {
        public ButtonPage() { }

        private ButtonObject buttonObj = new ButtonObject("login", By.Id("button"));
        private OtherObject displayedText = new OtherObject("demo", By.Id("demo"));


        public void Click()
        {
            buttonObj.Click();
        }

        public string getDisplayedText()
        {
            return displayedText.GetAttribute("innerHTML");
        }

    }
}
