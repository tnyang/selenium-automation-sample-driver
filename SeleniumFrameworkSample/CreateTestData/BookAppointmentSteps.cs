using Ams.Acceptance.Testing.CreateTestData.ResponseModels;
using Newtonsoft.Json;
using TechTalk.SpecFlow;
using NUnit.Framework;

namespace Ams.Acceptance.Testing.CreateTestData
{
    [Scope(Feature = "BookAppointment")]
    [Binding]
    public class BookAppointmentSteps: RequestHandler
    {
        [Then(@"the response should be successfull (.*)")]
        public void ThenTheResponseShouldBeSuccessfull(string testscenario)
        {
            var responseData = JsonConvert.DeserializeObject<BookAppointmentResponseModel>(_response.Content.ReadAsStringAsync().Result);

            Assert.IsTrue(_response.IsSuccessStatusCode, "response should  be SUCCESS");
            Assert.AreEqual(responseData.Appointment.AppointmentMessage.Acknowledge, "Success", "Acknowledge should be Success");
            Assert.AreEqual(responseData.Appointment.AppointmentMessage.StatusCode, 1, "StatusCode should be 1");
            Assert.AreEqual(responseData.Appointment.AppointmentMessage.MessageTitle, "Book Appointment");
            Assert.AreEqual(responseData.Appointment.AppointmentMessage.Data, null, "Data should be null");

        }
    }
}
