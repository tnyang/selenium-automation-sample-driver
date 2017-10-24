using SeleniumFrameworkV2Sample.PageObjects;
using OpenQA.Selenium;
using Healthgrades.TestAutomation.SeleniumFramework.Core;

namespace SeleniumFrameworkV2Sample.HtmlObjects
{
    class CheckBoxPage : BasePageObjects
    {
        public CheckBoxPage() { }

        private CheckboxObject checkboxObj = new CheckboxObject("checkbox", By.Id("checkbox"));
        private OtherObject displayedText = new OtherObject("demo", By.Id("demo"));


        public bool IsChecked()
        {
            return checkboxObj.IsChecked();
        }

        public void Check()
        {
            checkboxObj.Check();
        }

        public string GetCheckedAttribute()
        {
            return checkboxObj.GetAttribute("checked");
        }

    }
}
