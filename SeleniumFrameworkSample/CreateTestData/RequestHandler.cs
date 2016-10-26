using System;
using System.Collections.Generic;
using System.Configuration;
using System.Net.Http;
using TechTalk.SpecFlow;
using Newtonsoft.Json;
using System.Linq;
using Ams.Acceptance.Testing.CreateTestData.ResponseModels;
using System.Text;

namespace Ams.Acceptance.Testing.CreateTestData
{
    [Binding]
    public class RequestHandler
    {
        protected HttpClient _client;
        protected string _url;
        protected string _partnerId;
        protected string _partnerOfficeId;
        protected string _partnerPracticeId;
        protected string _partnerProviderId;
        protected string _providerId;
        protected string _windowDateTime;
        protected string _windowDays;
        protected string _timeSlotId;
        protected string _appointmentDateTime;
        protected string _appointmentDateTimeUtc;
        protected string _consumerId;
        protected string _appointmentId;
        protected string _officeId;
        protected string _fullDataImportFlag;

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

        #region set parameters
        [Given(@"the url is (.*)")]
        public void GivenTheUrlIs(string url)
        {
            _url = url;
        }

        [Given(@"the partnerId is (.*)")]
        public void GivenThePartnerIdIs(string partnerId)
        {
            _partnerId = partnerId;
        }

        [Given(@"the partnerOfficeId is (.*)")]
        public void GivenThePartnerOfficeIdIs(string partnerOfficeId)
        {
            _partnerOfficeId = partnerOfficeId;
        }

        [Given(@"the partnerPracticeId is (.*)")]
        public void GivenThePartnerPracticeIdIs(string partnerPracticeId)
        {
            _partnerPracticeId = partnerPracticeId;
        }

        [Given(@"the partnerProviderId is (.*)")]
        public void GivenThePartnerProviderIdIs(string partnerProviderId)
        {
            _partnerProviderId = partnerProviderId;
        }

        [Given(@"the slotID is (.*)")]
        public void GivenTheSlotIDIs(string slotId)
        {
            if (slotId != "noChange") _timeSlotId = slotId;
        }

        [Given(@"the appointmentDateTime is (.*)")]
        public void GivenTheAppointmentDateTimeIs(string appointmentDateTime)
        {
            if (appointmentDateTime != "noChange") _appointmentDateTime = appointmentDateTime;
            if (appointmentDateTime == "passed") _appointmentDateTime = "1/13/2016";

        }

        [Given(@"the appointmentDateTimeUtc is (.*)")]
        public void GivenTheappointmentDateTimeUtcIs(string appointmentDateTimeUtc)
        {
            if (appointmentDateTimeUtc != "noChange") _appointmentDateTimeUtc = appointmentDateTimeUtc;
            if (appointmentDateTimeUtc == "passed") _appointmentDateTimeUtc = "2016-01-13T17:00:00";
        }

        [Given(@"the providerId is (.*)")]
        public void GivenTheProviderIdIs(string providerId)
        {
            _providerId = providerId;
        }


        [Given(@"the windowDateTime is (.*)")]
        public void GivenTheWindowDateTimeIs(string windowDateTime)
        {
            if (windowDateTime == "today")
            {
                _windowDateTime = DateTime.Now.ToShortDateString();
            }
            else
            {
                _windowDateTime = windowDateTime;
            }
        }

        [Given(@"the windowDays is (.*)")]
        public void GivenTheWindowDaysIs(string windowDays)
        {
            _windowDays = windowDays;
        }

        [Given(@"the consumerID is (.*)")]
        public void GivenTheConsumerIDIs(string consumerId)
        {
            if (consumerId != "noChange") _consumerId = consumerId;
        }

        [Given(@"the appointmentId is (.*)")]
        public void GivenTheAppointmentIdIs(string appointmentId)
        {
            if (appointmentId != "noChange") _appointmentId = appointmentId;
        }

        [Given(@"the officeId is (.*)")]
        public void GivenTheOfficeIdIs(string officeId)
        {
            if (officeId != "noChange") _officeId = officeId;
        }
        [Given(@"the fullDataImportFlag is (.*)")]
        public void GivenTheFullDataImportFlagIs(string flag)
        {
            _fullDataImportFlag = flag;
        }

        #endregion

        #region add parameters to the url
        [Given(@"add partnerId to url")]
        public void GivenAddPartnerIdToUrl()
        {
            if (_url.Contains("="))
            {
                _url = _url + "&partnerId=" + _partnerId;
            }
            else
            {
                if (_partnerId != "null")
                {
                    _url = _url + "?partnerId=" + _partnerId;
                }
            }
        }

        [Given(@"add partnerOfficeId to url")]
        public void GivenAddPartnerOfficeIdToUrl()
        {
            if (_partnerOfficeId != "null")
            {
                if (_url.Contains("="))
                {
                    _url = _url + "&partnerOfficeId=" + _partnerOfficeId;
                }
                else
                {
                    _url = _url + "?partnerOfficeId=" + _partnerOfficeId;
                }
            }
        }

        [Given(@"add partnerPracticeId to url")]
        public void GivenAddPartnerPracticeIdToUrl()
        {
            if (_partnerPracticeId != "null")
            {

                if (_url.Contains("="))
                {
                    _url = _url + "&partnerPracticeId=" + _partnerPracticeId;
                }
                else
                {
                    _url = _url + "?partnerPracticeId=" + _partnerPracticeId;
                }
            }
        }

        [Given(@"add partnerProviderId to url")]
        public void GivenAddPartnerProviderIdToUrl()
        {
            if (_partnerProviderId != "null")
            {
                if (_url.Contains("="))
                {
                    _url = _url + "&partnerProviderId=" + _partnerProviderId;
                }
                else
                {
                    _url = _url + "?partnerProviderId=" + _partnerProviderId;
                }
            }
        }

        [Given(@"add providerId to url")]
        public void GivenAddProviderIdToUrl()
        {
            if (_providerId != "null")
            {
                if (_url.Contains("="))
                {
                    _url = _url + "&providerId=" + _providerId;
                }
                else
                {
                    _url = _url + "?providerId=" + _providerId;
                }

            }
        }

        [Given(@"add windowDateTime to url")]
        public void GivenAddWindowDateTimeToUrl()
        {
            if (_windowDateTime != "null")
            {
                if (_url.Contains("="))
                {
                    _url = _url + "&windowDateTime=" + _windowDateTime;
                }
                else
                {
                    _url = _url + "?windowDateTime=" + _windowDateTime;
                }

            }
        }

        [Given(@"add windowDays to url")]
        public void GivenAddWindowDaysToUrl()
        {
            if (_windowDays != "null")
            {
                if (_url.Contains("="))
                {
                    _url = _url + "&windowDays=" + _windowDays;
                }
                else
                {
                    _url = _url + "?windowDays=" + _windowDays;
                }

            }
        }

        [Given(@"add appointmentId to url")]
        public void GivenAddAppointmentIdToUrl()
        {
            if (_appointmentId != "null")
            {
                if (_url.Contains("="))
                {
                    _url = _url + "&appointmentId=" + _appointmentId;
                }
                else
                {
                    _url = _url + "?appointmentId=" + _appointmentId;
                }
            }
        }

        [Given(@"add userip to url")]
        public void GivenAddUseripToUrl()
        {
            if (_url.Contains("="))
            {
                _url = _url + "&userip=127.0.0.1";
            }
            else
            {
                _url = _url + "?userip=127.0.0.1";
            }
        }

        [Given(@"add fullDataImportFlag to url")]
        public void GivenAddFullDataImportFlagToUrl()
        {
            if (_url.Contains("="))
            {
                _url = _url + "&fullDataImportFlag=" + _fullDataImportFlag;
            }
            else
            {
                _url = _url + "?fullDataImportFlag=" + _fullDataImportFlag;
            }
        }

        #endregion  


        [Given(@"set available timeslotId and AppointmentDateTime")]
        public void GivenSetAvailableTimeslotIdAndAppointmentDateTime()
        {
            WhenTheRequestIsSentAsA("GET");
            var responseData = JsonConvert.DeserializeObject<AvailableAppointmentsModel>(_response.Content.ReadAsStringAsync().Result);

            var index = new Random().Next(0, responseData.TimeSlotList.Count - 1);
            _timeSlotId = responseData.TimeSlotList[index].Id;
            _appointmentDateTime = responseData.TimeSlotList[index].Time;
            _appointmentDateTimeUtc = responseData.TimeSlotList[index].UtcTime;
        }

        [Given(@"set consumerId")]
        public void GivenSetConsumerId()
        {
            WhenTheRequestIsSentAsA("POST");
            var responseData = JsonConvert.DeserializeObject<HoldTimeSlotModel>(_response.Content.ReadAsStringAsync().Result);

            _consumerId = responseData.ConsumerID;
            _appointmentId = responseData.AppointmentID;
            var fileHelper = new FileHelper();
            fileHelper.writeToFile("slotId"+ _partnerId+".txt", responseData.SlotId);
        }


        [Given(@"set HoldTimeSlot request body with following additional fields")]
        public void GivenSetHoldTimeSlotRequestBodyWithFollowingAdditionalFields(Table table)
        {
            var _pData = new HoldTimeSlotRequestModel();
            var _appointmentData = new Dictionary<string, string>();

            foreach (var row in table.Rows)
            {
                var values = row.Values.ToList();
                var key = values[0];
                var val = values[1];

                _appointmentData.Add(key, val);
            }

            if (_providerId != "null") _appointmentData.Add("ProviderId", _providerId);
            if (_partnerId != "null") _appointmentData.Add("PartnerId", _partnerId);
            if (_partnerProviderId != "null") _appointmentData.Add("PartnerProviderId", _partnerProviderId);
            if (_partnerOfficeId != "null") _appointmentData.Add("PartnerOfficeId", _partnerOfficeId);
            if (_appointmentDateTime != "null") _appointmentData.Add("AppointmentDateTime", _appointmentDateTime);
            if (_appointmentDateTimeUtc != "null") _appointmentData.Add("AppointmentDateTimeUtc", _appointmentDateTimeUtc);
            if (_timeSlotId != "null") _appointmentData.Add("SlotId", _timeSlotId);
            if (_partnerPracticeId != "null") _appointmentData.Add("PartnerPracticeId", _partnerPracticeId);
            if (_officeId != "null") _appointmentData.Add("OfficeId", _officeId);

            _pData.Appointment = _appointmentData;
            _pData.ProductChannel = "9";

            _data = new StringContent(JsonConvert.SerializeObject(_pData), Encoding.UTF8, "application/json");
        }

        [Given(@"set PreBookAppointment request body with following additional fields")]
        public void GivenSetPreBookAppointmentRequestBodyWithFollowingAdditionalFields(Table table)
        {
            var _pData = new Dictionary<string, string>();

            foreach (var row in table.Rows)
            {
                var values = row.Values.ToList();
                var key = values[0];
                var val = values[1];

                _pData.Add(key, val);
            }

            if (_providerId != "null") _pData.Add("ProviderId", _providerId);
            if (_partnerId != "null") _pData.Add("PartnerId", _partnerId);
            if (_partnerProviderId != "null") _pData.Add("PartnerProviderId", _partnerProviderId);
            if (_partnerOfficeId != "null") _pData.Add("PartnerOfficeId", _partnerOfficeId);
            if (_appointmentDateTime != "null") _pData.Add("AppointmentDateTime", _appointmentDateTime);
            if (_appointmentDateTimeUtc != "null") _pData.Add("AppointmentDateTimeUtc", _appointmentDateTimeUtc);
            if (_timeSlotId != "null") _pData.Add("SlotId", _timeSlotId);
            if (_partnerPracticeId != "null") _pData.Add("PartnerPracticeId", _partnerPracticeId);
            if (_consumerId != "null") _pData.Add("Consumerid", _consumerId);
            if (_officeId != "null") _pData.Add("OfficeId", _officeId);

            _postData = _pData;
            _data = new StringContent(JsonConvert.SerializeObject(_pData), Encoding.UTF8, "application/json");
        }

        [Given(@"set CancelAppointment request body")]
        public void GivenSetCancelAppointmentRequestBody()
        {
            var _pData = new Dictionary<string, string>();
            if (_appointmentId != "null") _pData.Add("AppointmentId", _appointmentId);
            _pData.Add("userip", "127.0.0.1");

            _postData = _pData;
            _data = new StringContent(JsonConvert.SerializeObject(_pData), Encoding.UTF8, "application/json");
        }

        [Given(@"set ModifyAppointment request body")]
        public void GivenSetModifyAppointmentRequestBody()
        {
            var _pData = new Dictionary<string, string>();
            if (_appointmentId != "null") _pData.Add("AppointmentId", _appointmentId);
            _pData.Add("userip", "127.0.0.1");
            if (_partnerOfficeId != "null") _pData.Add("PartnerOfficeId", _partnerOfficeId);
            if (_appointmentDateTime != "null") _pData.Add("AppointmentDateTime", _appointmentDateTime);
            if (_appointmentDateTimeUtc != "null") _pData.Add("AppointmentDateTimeUtc", _appointmentDateTimeUtc);
            if (_timeSlotId != "null") _pData.Add("SlotId", _timeSlotId);
            if (_officeId != "null") _pData.Add("OfficeId", _officeId);

            _postData = _pData;
            _data = new StringContent(JsonConvert.SerializeObject(_pData), Encoding.UTF8, "application/json");
        }


        [Given(@"the request has the following body parameters")]
        public void GivenTheRequestHasTheFollowingBodyParameters(Table table)
        {
            _postData = new Dictionary<string, string>();

            foreach (var row in table.Rows)
            {
                var values = row.Values.ToList();
                var key = values[0];
                var val = values[1];

                _postData.Add(key, val);
            }
            _data = new StringContent(JsonConvert.SerializeObject(_postData), Encoding.UTF8, "application/json");
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
            var fullUrl = (!_url.Contains("Utilities")) ? ConfigurationManager.AppSettings["baseOASServiceUrl"] + "/api" + _url : ConfigurationManager.AppSettings["baseOASServiceUrl"] + _url;


            HttpRequestMessage message = new HttpRequestMessage();
            message.RequestUri = new Uri(fullUrl);
            switch (verb)
            {
                case "GET":
                    message.Method = HttpMethod.Get;
                    break;

                case "POST":
                    message.Method = HttpMethod.Post;
                    message.Content = _data;
                    break;

                case "PUT":
                    message.Method = HttpMethod.Put;
                    message.Content = _data;
                    break;

                case "DELETE":
                    message.Method = HttpMethod.Delete;
                    break;
            }
            _response = _client.SendAsync(message).Result;

            Console.WriteLine("---------------------------------------------------------------------------------");
            Console.WriteLine("REQUEST INFO:\n" + _response.RequestMessage);

            if (message.Method != HttpMethod.Get && _postData != null)
            {
                Console.WriteLine("Request body:\n {");
                foreach (KeyValuePair<string, string> entry in _postData)
                {
                    Console.WriteLine(entry.Key + " : " + entry.Value);
                }
                Console.WriteLine("} \n");
            }
            Console.WriteLine("---------------------------------------------------------------------------------");
            Console.WriteLine("---------------------------------------------------------------------------------");

            //Log response info
            Console.WriteLine("---------------------------------------------------------------------------------");
            Console.WriteLine("RESPONSE INFO:\n" + _response);
            Console.WriteLine("Response body:\n" + _response.Content.ReadAsStringAsync().Result);
            Console.WriteLine("---------------------------------------------------------------------------------");
            Console.WriteLine("---------------------------------------------------------------------------------");
        }

    }
}

