using OpenQA.Selenium;

namespace Ams.Acceptance.Testing.Locators
{
    public class MhdstageTimeslotCreateLocators
    {
        
        public static readonly By UserNameBoxLocator = By.Id("txtUsername");
        public static readonly By PasswordBoxLocator = By.Id("txtPassword");
        public static readonly By LoginButtonLocator = By.Id("btnLogin");
        public static readonly By OkPopupButtonLocator = By.XPath("//span[contains(text(),'OK')]/parent::*");
        public static readonly By CreateSlotButtonLocator = By.XPath("//span[contains(text(), 'Create Slot')]");
        public static readonly By AddSlotButtonLocator = By.XPath("//span[contains(text(), 'Add Slot')]");
        public static readonly By AppointmentTypeDropdownLocator = By.Id("selectAppointmentType");

        //TimeslotDateTime
        public static readonly By DateLocator = By.Id("txtEditSlotAppointmentDate");
        public static readonly By selectAppointmentStartTimeHourLocator = By.Id("selectAppointmentStartTimeHour");
        public static readonly By selectAppointmentStartTimeMinuteLocator = By.Id("selectAppointmentStartTimeMinute");
        public static readonly By selectAppointmentStartTimeComponentLocator = By.Id("selectAppointmentStartTimeComponent");
        public static readonly By selectAppointmentEndTimeHourLocator = By.Id("selectAppointmentEndTimeHour");
        public static readonly By selectAppointmentEndTimeMinuteLocator = By.Id("selectAppointmentEndTimeMinute");
        public static readonly By selectAppointmentEndTimeComponentLocator = By.Id("selectAppointmentEndTimeComponent");

        public static By CalendarCellLocator(int index)
        {
            return By.XPath("//*[@id='divCalendar992']/div/div/div[2]/div/table/tbody/tr[" + index.ToString() + "]/td/div");
        }
    }
}
