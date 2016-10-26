using Healthgrades.TestAutomation.SeleniumFramework.Core;
using Ams.Acceptance.Testing.Locators;
using System;
using System.Configuration;
using System.Threading;
using Ams.Acceptance.Testing.CreateTestData;

namespace Ams.Acceptance.Testing.PageObjects
{
    public class MhdstageTimeslotCreateObjects : BasePageObjects
    {
        private string _date;
        private string _startHour;
        private string _startMin;
        private string _endHour;
        private string _endMin;
        private string _component;

        #region Elements
        public TextFieldObject userNameBox = new TextFieldObject("userNameBox", MhdstageTimeslotCreateLocators.UserNameBoxLocator);
        public PasswordTextFieldObject passwordBox = new PasswordTextFieldObject("passwordBox", MhdstageTimeslotCreateLocators.PasswordBoxLocator);
        public ButtonObject loginButton = new ButtonObject("loginButton", MhdstageTimeslotCreateLocators.LoginButtonLocator);
        public ButtonObject OkPopupButton = new ButtonObject("OkPopupButton", MhdstageTimeslotCreateLocators.OkPopupButtonLocator);
        public ButtonObject CreateSlotButton = new ButtonObject("CreateSlotButton", MhdstageTimeslotCreateLocators.CreateSlotButtonLocator);
        public ButtonObject AddSlotButton = new ButtonObject("AddSlotButton", MhdstageTimeslotCreateLocators.AddSlotButtonLocator);
        public DropDownListObject AppointmentTypeDropdown = new DropDownListObject("AppointmentTypeDropdown", MhdstageTimeslotCreateLocators.AppointmentTypeDropdownLocator);

        //TimeslotDateTime
        public TextFieldObject DateTextBox = new TextFieldObject("DateTextBox", MhdstageTimeslotCreateLocators.DateLocator);
        public DropDownListObject selectAppointmentStartTimeHour = new DropDownListObject("selectAppointmentStartTimeHour", MhdstageTimeslotCreateLocators.selectAppointmentStartTimeHourLocator);
        public DropDownListObject selectAppointmentStartTimeMinute = new DropDownListObject("selectAppointmentStartTimeMinute", MhdstageTimeslotCreateLocators.selectAppointmentStartTimeMinuteLocator);
        public DropDownListObject selectAppointmentStartTimeComponent = new DropDownListObject("selectAppointmentStartTimeComponent", MhdstageTimeslotCreateLocators.selectAppointmentStartTimeComponentLocator);
        public DropDownListObject selectAppointmentEndTimeHour = new DropDownListObject("selectAppointmentEndTimeHour", MhdstageTimeslotCreateLocators.selectAppointmentEndTimeHourLocator);
        public DropDownListObject selectAppointmentEndTimeMinute = new DropDownListObject("selectAppointmentEndTimeMinute", MhdstageTimeslotCreateLocators.selectAppointmentEndTimeMinuteLocator);
        public DropDownListObject selectAppointmentEndTimeComponent = new DropDownListObject("selectAppointmentEndTimeComponent", MhdstageTimeslotCreateLocators.selectAppointmentEndTimeComponentLocator);

        public OtherObject CalendarCell(int index)
        {
            return new OtherObject("Link", MhdstageTimeslotCreateLocators.CalendarCellLocator(index));
        }
        #endregion

        #region methods

        public void OpenMHDStagePage(string pageUrl)
        {
            WebDriverTestBase.Driver.Navigate().GoToUrl(ConfigurationManager.AppSettings["mhdstageUrl"] + pageUrl);
            Console.WriteLine("Go to url: " + Config.Settings.runTimeSettings.EnvironmentUrl + pageUrl);
        }
        public void Login(string username, string password)
        {
            userNameBox.SetText(username);
            userNameBox.GetText();
            passwordBox.SetText(password);
            loginButton.Click();
        }
        public bool isPopupDisplayed()
        {
            Thread.Sleep(5000);
            return OkPopupButton.IsElementDisplayed();
        }
        public void closePopupDialog()
        {
             OkPopupButton.Click();
        }
        public bool IsCreateSlotDialogPresent()
        {
            Thread.Sleep(5000);
            return AddSlotButton.IsElementDisplayed();
        }
        public void AddSlot(string date, string hour, string min, string component)
        {
            _startHour = hour;
            _startMin = min;
            _component = component;
            _date = date;

            bool isSlotCreatingSuccessful = false;
            while (!isSlotCreatingSuccessful)
            {
                Thread.Sleep(5000);
                CalendarCell(92).Click();
                Thread.Sleep(5000);
                CreateSlotButton.Click();
                
                //Select 'New or Current Patient' option from dropdown
                AppointmentTypeDropdown.SelectByText("New or Current Patient");
                //Set date time
                setDate();
                setStartAppointmentTime();
                setEndAppointmentTime();

                AddSlotButton.Click();

                try
                {
                    isSlotCreatingSuccessful = Text("New slot(s) successfully Inserted").IsElementDisplayed();
                    increateTimeBy15Min();
                }
                catch(Exception)
                {
                    increateTimeBy15Min();
                }
            }
           FileHelper fh = new FileHelper();
           fh.writeToFile("MHDDateTime.txt", DateTime.Now.ToString("yyy-MM-dd ")+ getFormattedTime());
        }
        public bool IsSlotCreatedSuccessfully()
        {
            return Text("New slot(s) successfully Inserted").IsElementDisplayed();
        }
        private void setDate()
        {
            DateTextBox.ClearText();
            DateTextBox.SetText(_date);
        }
        private void setStartAppointmentTime()
        {
            selectAppointmentStartTimeHour.SelectByText(_startHour);
            selectAppointmentStartTimeMinute.SelectByText(_startMin);
            selectAppointmentStartTimeComponent.SelectByText(_component);
        }
        private void setEndAppointmentTime()
        {
            setEndHourAndMin();
            selectAppointmentEndTimeHour.SelectByText(_endHour);
            selectAppointmentEndTimeMinute.SelectByText(_endMin);
            selectAppointmentEndTimeComponent.SelectByText(_component);
        }
        private void setEndHourAndMin()
        {
            if (_startMin == "45" && _startHour == "12")
            {
                _endMin = "00";
                _endHour = "01";
                _component=(_component == "AM") ?  "PM" : "AM";
            }
            else if (_startMin == "45" && _startHour != "12")
            {
                _endMin = "00";
                _endHour = (Convert.ToInt64(_startHour) + 1).ToString();
            }
            else
            {
                _endMin = (Convert.ToInt64(_startMin) + 15).ToString();
                _endHour = _startHour;
            }
        }
        private void increateTimeBy15Min()
        {
            if (_startMin == "45" && _startHour=="12")
            {
                _startMin = "00";
                _startHour = "01";
            }
            else if (_startMin == "45" && _startHour != "12")
            {
                _startMin = "00";
                _startHour = (Convert.ToInt64(_startHour) + 1).ToString();
            }
            else
            {
                _startMin = (Convert.ToInt64(_startMin) + 15).ToString();
            }
        }
        private string getFormattedTime()
        {
            string formattedTime = (_component == "PM") ? _startHour : (Convert.ToInt32(_startHour) + 12).ToString();
            return formattedTime + ":" + _startMin + ":00.000";
        }
        #endregion



    }
}
