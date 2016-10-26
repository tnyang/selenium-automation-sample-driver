using Newtonsoft.Json;
using TechTalk.SpecFlow;
using NUnit.Framework;
using Ams.Acceptance.Testing.SqlDb;

namespace Ams.Acceptance.Testing.Solr
{
    [Scope(Feature = "AppointmentManagementSolrTests")]
    [Binding]
    public class AppointmentManagementSolrTestsSteps: RequestHandler
    {
        public SqlDatabaseHelper sqlDbHelper = new SqlDatabaseHelper();

        [Then(@"the response should contain correct info")]
        public void ThenTheResponseShouldContainCorrectInfo()
        {
            var responseData = JsonConvert.DeserializeObject<SolrResponseModel>(_response.Content.ReadAsStringAsync().Result);

            Assert.IsTrue(_response.IsSuccessStatusCode, "response should  be SUCCESS");
            if (_url.Contains("PROVIDER"))
            {
                Assert.AreEqual(responseData.response.numFound, sqlDbHelper.GetTotalCount("Provider"), "SQL and Solr total counts are not matching.");
            }
            else if (_url.Contains("REASON"))
            {
                Assert.AreEqual(responseData.response.numFound, sqlDbHelper.GetTotalCount("PartnerAppointmentReason"), "SQL and Solr total counts are not matching.");
            }
            else if (_url.Contains("TIMESLOT"))
            {
                Assert.AreEqual(responseData.response.numFound, sqlDbHelper.GetTotalCount("Inventory"), "SQL and Solr total counts are not matching.");
            }
        }

        [Then(@"the response should NOT contain removed timeslot")]
        public void ThenTheResponseShouldNOTContainRemovedTimeslot()
        {
            var responseData = JsonConvert.DeserializeObject<SolrResponseModel>(_response.Content.ReadAsStringAsync().Result);
            Assert.AreEqual(responseData.response.numFound, 0, "Timeslot should be removed");
        }
        [Then(@"the response should contain added timeslot")]
        public void ThenTheResponseShouldContainAddedTimeslot()
        {
            var responseData = JsonConvert.DeserializeObject<SolrResponseModel>(_response.Content.ReadAsStringAsync().Result);
            Assert.AreEqual(responseData.response.numFound, 1, "Timeslot should be created");
            Assert.AreEqual(responseData.response.docs[0].pwid, "3CNCW", "Pwid is not matching");
            Assert.AreEqual(responseData.response.docs[0].office_code, "FLX4Y", "Office code is not matching");
            Assert.AreEqual(responseData.response.docs[0].partner_code, "MHD", "Partner code is not matching");
            Assert.AreEqual(responseData.response.docs[0].partner_provider_id, "1333", "Partner provider id is not matching");
            Assert.AreEqual(responseData.response.docs[0].partner_provider_id, "1333", "Partner provider id is not matching");
            Assert.IsNotNull(responseData.response.docs[0].timeslot_json, "Json is not matching");
            Assert.IsNotEmpty(responseData.response.docs[0].timeslot_json, "Json is not matching");
        }

    }
}
