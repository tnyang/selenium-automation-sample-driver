using SeleniumFrameworkV2Sample.PageObjects;
using OpenQA.Selenium;
using Healthgrades.TestAutomation.SeleniumFramework.Core;

namespace SeleniumFrameworkV2Sample.HtmlObjects
{
    class PasswordTextField : BasePageObjects
    {
        public PasswordTextField() { }

        private PasswordTextFieldObject passwordTextfieldObj = new PasswordTextFieldObject("password", By.Id("password"));


        public void SetText(string text)
        {
            passwordTextfieldObj.SetText(text);
        }

        public void ClearText()
        {
            passwordTextfieldObj.ClearText();
        }

        public string GetText()
        {
            return passwordTextfieldObj.GetAttribute("value");
        }
    }
}
