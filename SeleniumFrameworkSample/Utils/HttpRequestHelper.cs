using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System.Net.Http;
using Newtonsoft.Json.Linq;

namespace SeleniumFrameworkV2Sample.Utils
{
    public class HttpRequestHelper
    {
        protected HttpClient _client;
        protected HttpResponseMessage _response;
        protected HttpContent _data;
        protected Dictionary<string, string> _postData;
        private HttpRequestMessage message = new HttpRequestMessage();


        private void SendRequest(string url, string verb)
        {
            try
            {
                string baseUrl = "http://hgsolr2testmstr.healthgrades.com:8983";

                message.RequestUri = new Uri(baseUrl+url);
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
                _client = new HttpClient();
                _response = null;
                _response = _client.SendAsync(message).Result;
            }
            catch (Exception e)
            {
                Console.WriteLine("Sending request errored out with error: " + e.Message);
            }

            Console.WriteLine("---------------------------------------------------------------------------------");
            Console.WriteLine("REQUEST INFO:\n" + _response.RequestMessage);

        }

        public string GetSolrData(string url)
        {
            SendRequest(url, "GET");
            if(_response.StatusCode!=System.Net.HttpStatusCode.OK) throw new Exception(String.Format("Server error (HTTP {0}). Solr could be down",_response.StatusCode));
            var test = _response.Content.ReadAsStringAsync().Result;
            var responseData = JsonConvert.DeserializeObject(_response.Content.ReadAsStringAsync().Result);
            JObject json = JObject.Parse(test);
            return "string";
        }
    }
}
