using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ams.Acceptance.Testing.SqlDb
{
    public class InventoryModel
    {
        public string TimeslotId { get; set; }
        public string Pwid { get; set; }
        public string OfficeCode { get; set; }
        public string PartnerCode { get; set; }
        public string PartnerPracticeId { get; set; }
        public string PartnerProviderId { get; set; }
        public string PartnerOfficeId { get; set; }
        public string AppointmentDateTime { get; set; }
        public string AppointmentDateTimeUtc { get; set; }
        public string Json { get; set; }
    }
}
