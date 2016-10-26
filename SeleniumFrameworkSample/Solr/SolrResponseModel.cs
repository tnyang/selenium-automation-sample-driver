using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ams.Acceptance.Testing.Solr
{
    public class SolrResponseModel
    {
        public ResponseHeader responseHeader { get; set; }
        public Response response { get; set; }
    }
    public class Response
    {
        public int numFound { get; set; }
        public int start { get; set; }
        public List<TimeSlot> docs { get; set; }
}
    public class TimeSlot
    {
        public bool is_avaliable { get; set; }
        public int inventory_id { get; set; }
        public string office_code { get; set; }
        public string appt_type { get; set; }
        public string timeslot_id { get; set; }
        public int duration_min { get; set; }
        public string appt_category { get; set; }
        public string partner_office_id { get; set; }
        public string pwid { get; set; }
        public string timeslot_json { get; set; }
        public string appt_datetime_local { get; set; }
        public string id { get; set; }
        public string partner_code { get; set; }
        public string appt_datetime_utc { get; set; }
        public string schema_type { get; set; }
        public string partner_provider_id { get; set; }
        public bool is_active { get; set; }
        public string timestamp { get; set; }
    }
    public class ResponseHeader
    {
        public int status { get; set; }
        public int QTime { get; set; }
        public List<Params> parameters { get; set; }
    }
    public class Params
{
    public string q { get; set; }
    public string indent { get; set; }
    public string fq { get; set; }
    public string wt { get; set; }
}

}
