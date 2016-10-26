using System;
using System.Collections.Generic;
using System.Configuration;
using System.Net.Http;
using TechTalk.SpecFlow;
using Newtonsoft.Json;
using System.Linq;
using Ams.Acceptance.Testing.CreateTestData;
using Ams.Acceptance.Testing.SqlDb;

namespace Ams.Acceptance.Testing.Solr
{
    [Binding]
    public class RequestHandler
    {
        protected HttpClient _client;
        protected string _url;
        protected string _solrNode;
        protected string _solrCore;
        protected string _fileName;
        private FileHelper fileHelper = new FileHelper();
        private SqlDatabaseHelper sqlDbHelper = new SqlDatabaseHelper();


        protected HttpResponseMessage _response;
        protected HttpContent _data;
        protected Dictionary<string, string> _postData;
        private HttpRequestMessage message = new HttpRequestMessage();
        protected Dictionary<string, string> serviceArguments = null;
        protected string _urlParams;
        protected string _jsonbody;
        protected string parameterString = "";

        // --------------------------------------- GIVEN steps ------------------------------------------- //


        [Given(@"I have prepared an api request")]
        public void GivenIHavePreparedAnApiRequest()
        {
            _client = new HttpClient();
            _response = null;
        }
        [Given(@"the fileName is MHD (.*)")]
        public void GivenTheFileNameIsMHD(string fileName)
        {
            _fileName = fileName;
            string slotId = "";
            if (_fileName.Contains("slotId"))
            {
                slotId = fileHelper.readFromFile("slotIdMHD.txt");
            }
            else
            {
                string dateMHD = fileHelper.readFromFile("MHDDateTime.txt");
                slotId = sqlDbHelper.GetTimeSlotInfoByDateAndPwidFromInventory(dateMHD, "3CNCW").ToString();
            }
            _url = _url.Replace("TIMESLOTID", slotId);
        }

        [Given(@"the url is (.*)")]
        public void GivenTheUrlIs(string url)
        {
            _url = _url+url;
        }
        [Given(@"the solrNode is (.*)")]
        public void GivenThesolrNodeIs(string solrNode)
        {
            _solrNode = solrNode;
        }
        [Given(@"the solrCore is (.*)")]
        public void GivenThesolCoreIs(string solrCore)
        {
            _solrCore = solrCore;
            _url = "solr/" + solrCore;
        }


        [When(@"the request is sent as a (.*)")]
        public void WhenTheRequestIsSentAsA(string verb)
        {
            SendRequest(verb);
        }
        [Given(@"the request is sent as (.*)")]
        public void WhenTheRequestIsSentAs(string verb)
        {
            SendRequest(verb);
        }

        private void SendRequest(string verb)
        {
            var fullUrl = (_solrNode == "master") ? ConfigurationManager.AppSettings["solrMasterUri"] + _url : ConfigurationManager.AppSettings["solrSlaveUri"] + _url;

            HttpRequestMessage message = new HttpRequestMessage();
            message.RequestUri = new Uri(fullUrl);
            switch (verb)
            {
                case "GET":
                    message.Method = HttpMethod.Get;
                    break;
            }
            _response = _client.SendAsync(message).Result;

            Console.WriteLine("---------------------------------------------------------------------------------");
            Console.WriteLine("REQUEST INFO:\n" + _response.RequestMessage);

            //Log response info
            Console.WriteLine("---------------------------------------------------------------------------------");
            Console.WriteLine("RESPONSE INFO:\n" + _response);
            Console.WriteLine("Response body:\n" + _response.Content.ReadAsStringAsync().Result);
            Console.WriteLine("---------------------------------------------------------------------------------");
            Console.WriteLine("---------------------------------------------------------------------------------");
        }

    }
}

