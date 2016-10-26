using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ams.Acceptance.Testing.CreateTestData.ResponseModels
{
    public class AvailableAppointmentsModel
    {
        public int NewPatientTimeSlotCount { get; set; }
        public int ExistingPatientTimeSlotCount { get; set; }
        public int OtherPatientTimeSlotCount { get; set; }
        public bool HasReminderReason { get; set; }
        public List<TimeSlot> TimeSlotList { get; set; }
        public List<AllAppointmentReasonsModel> AppointmentReasonList { get; set; }
    }
    public class TimeSlot
    {
        public string Id { get; set; }
        public string PartnerPracticeId { get; set; }
        public string Pwid { get; set; }
        public string OfficeId { get; set; }
        public string PartnerId { get; set; }
        public string PartnerProviderId { get; set; }
        public string PartnerSiteId { get; set; }
        public string PartnerDepartmentId { get; set; }
        public string PartnerReasonIdList { get; set; }
        public string Time { get; set; }
        public string UtcTime { get; set; }
        public int Length { get; set; }
        public string Type { get; set; }
        public string AppointmentCategory { get; set; }
        public string HasAppointmentReasons { get; set; }
        public string ProviderId { get; set; }

    }
    public class AllAppointmentReasonsModel
    {
        public string ReasonId { get; set; }
        public string Reason { get; set; }
        public string Reasontype { get; set; }
        public string Description { get; set; }
        public int AppointmentCategoryId { get; set; }
        public string AppointmentCategoryName { get; set; }
        public int AppointmentDuration { get; set; }
        public bool IsDefaultReason { get; set; }
        public string ReasonCode { get; set; }
    }
}
