using Ams.Acceptance.Testing.CreateTestData;
using Newtonsoft.Json;
using TechTalk.SpecFlow;
using NUnit.Framework;
using System;

namespace Ams.Acceptance.Testing.Warmer
{
    [Scope(Feature = "WarmerImport")]
    [Binding]
    public class WarmerImportSteps: RequestHandler
    {
        [Then(@"the response should be successfull")]
        public void ThenTheResponseShouldBeSuccessfull()
        {
            var responseData = JsonConvert.DeserializeObject<WarmerResponseModel>(_response.Content.ReadAsStringAsync().Result);

            Assert.IsTrue(_response.IsSuccessStatusCode, "response should  be SUCCESS");
            Assert.AreEqual(responseData.Acknowledge, "Success", "Acknowledge should be Success");
            Assert.AreEqual(responseData.StatusCode, 200, "StatusCode should be 200");
            Assert.AreEqual(responseData.MessageTitle, "Warmer", "Message title should be 'Warmer'");
            Assert.AreEqual(responseData.MessageBody, "Warmer Processed.", "Message Body should be'Warmer Processed.'");
            Assert.AreEqual(responseData.Data.Error, null, "Error should be null");

        }
    }
}
