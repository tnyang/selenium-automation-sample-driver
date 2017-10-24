using SeleniumFrameworkV2Sample.PageObjects;
using OpenQA.Selenium;
using Healthgrades.TestAutomation.SeleniumFramework.Core;

namespace SeleniumFrameworkV2Sample.HtmlObjects
{
    class RadioButton : BasePageObjects
    {
        public RadioButton() { }

        private RadioButtonObject radioobj = new RadioButtonObject("radio", By.Id("radio"));
        private OtherObject displayedText = new OtherObject("demo", By.Id("demo"));


        public bool IsSelected()
        {
            return radioobj.IsSelected();
        }

        public void Select()
        {
            radioobj.Select();
        }

    }
}
