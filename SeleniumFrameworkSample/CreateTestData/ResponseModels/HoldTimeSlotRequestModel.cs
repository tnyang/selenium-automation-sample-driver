using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ams.Acceptance.Testing.CreateTestData.ResponseModels
{
    public class HoldTimeSlotRequestModel
    {
        public Dictionary<string, string> Appointment { get; set; }
        public string ProductChannel { get; set; }
    }
}
