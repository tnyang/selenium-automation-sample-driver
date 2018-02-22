using SeleniumFrameworkV2Sample.PageObjects;
using OpenQA.Selenium;
using Healthgrades.TestAutomation.SeleniumFramework.Core;

namespace SeleniumFrameworkV2Sample.HtmlObjects
{
    class TextField : BasePageObjects
    {
        public TextField() { }

        private TextFieldObject textfieldObj = new TextFieldObject("text", By.Id("text"));


        public void SetText(string text)
        {
            textfieldObj.SetText(text);
        }

        public string GetText()
        {
            return textfieldObj.GetText();
        }

        public void ClearText()
        {
            textfieldObj.ClearText();
        }

    }
}
