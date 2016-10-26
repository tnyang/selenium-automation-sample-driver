using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ams.Acceptance.Testing.Warmer
{
    public class WarmerResponseModel
    {
        public string Acknowledge { get; set; }
        public int StatusCode { get; set; }
        public string MessageTitle { get; set; }
        public string MessageBody { get; set; }
        public DataModel Data { get; set; }
        
    }
    public class DataModel
    {
        public string RequestId { get; set; }
        public string PoweredByHealthgradesLogoUrl { get; set; }
        public string HealthgradesUrl { get; set; }
        public string ProviderProfileUrl { get; set; }
        public string ResponseObject { get; set; }
        public string Error { get; set; }
    }
}
