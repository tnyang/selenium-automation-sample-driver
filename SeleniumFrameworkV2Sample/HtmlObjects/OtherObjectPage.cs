using SeleniumFrameworkV2Sample.PageObjects;
using OpenQA.Selenium;
using Healthgrades.TestAutomation.SeleniumFramework.Core;

namespace SeleniumFrameworkV2Sample.HtmlObjects
{
    class OtherObjectPage : BasePageObjects
    {
        public OtherObjectPage() { }

        public ButtonObject buttonObj = new ButtonObject("login", By.Id("button"));
        public CheckboxObject checkboxObj = new CheckboxObject("checkbox", By.Id("checkbox"));
        public DropDownListObject dropdownlistObj = new DropDownListObject("select", By.Id("select"));
        public HyperlinkObject hyperlinkObj = new HyperlinkObject("link", By.Id("link"));
        public ListBoxObject listboxObj = new ListBoxObject("select", By.Id("select"));
        public PasswordTextFieldObject passwordTextfieldObj = new PasswordTextFieldObject("password", By.Id("password"));
        public RadioButtonObject radioobj = new RadioButtonObject("radio", By.Id("radio"));
        public TextFieldObject textfieldObj = new TextFieldObject("text", By.Id("text"));

        public OtherObject buttonDemoText = new OtherObject("button_demo", By.Id("button_demo"));

    }
}
