using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ams.Acceptance.Testing.CreateTestData.ResponseModels
{
        public class BookAppointmentResponseModel
        {
            public HoldTimeSlotModel Appointment { get; set; }
            public Consumer Consumer { get; set; }
            public string Message { get; set; }
        }

        public class Consumer
        {
            public string ConsumerId { get; set; }
            public string FirstName { get; set; }
            public string MiddleName { get; set; }
            public string LastName { get; set; }
            public string FCDOB { get; set; }
            public string BirthDate { get; set; }
            public string Address { get; set; }
            public string Address1 { get; set; }
            public string Address2 { get; set; }
            public string City { get; set; }
            public string State { get; set; }
            public string Zip { get; set; }
            public string Zipcode { get; set; }
            public string Phone { get; set; }
            public string PhoneNumber { get; set; }
            public string AlternatePhoneNumber { get; set; }
            public string Email { get; set; }
            public string EmailAddress { get; set; }
            public bool IsNewPatient { get; set; }
            public string ConsumerSource { get; set; }
            public string ConsumerStatus { get; set; }
            public NotificationPref NotificationPref { get; set; }
            public bool AcceptedTermsAndConditions { get; set; }
            public bool IsPatientSelf { get; set; }
            public string ParentOrGuardianName { get; set; }
            public string RelativeBirthDate { get; set; }
            public string RelationToPatient { get; set; }
            public string RelativeSex { get; set; }
            public string PartnerPracticeId { get; set; }
            public string ContactName { get; set; }
            public string ContactRelationship { get; set; }
            public string CountryCode3166 { get; set; }
            public string PartnerSiteId { get; set; }
            public string GuarantorAddress1 { get; set; }
            public string GuarantorCity { get; set; }
            public string GuarantorCountryCode3166 { get; set; }
            public string GuarantorDOB { get; set; }
            public string GuarantorDateOfBirth { get; set; }
            public string GuarantorEmail { get; set; }
            public string GuarantorFirstName { get; set; }
            public string GuarantorLastName { get; set; }
            public string GuarantorPhone { get; set; }
            public string GuarantorState { get; set; }
            public string GuarantorZip { get; set; }
            public string MaritalStatus { get; set; }
            public string Gender { get; set; }
            public string Sex { get; set; }
            public string SSN { get; set; }
            public string WorkPhone { get; set; }
            public string RelativeFirstName { get; set; }
            public string RelativeLastName { get; set; }
            public string SmsPhoneNumber { get; set; }
            public string IsPartnerPatientNew { get; set; }
            public bool IsPatientInsured { get; set; }
            public string Insurance { get; set; }
            public string InsurancePlanName { get; set; }
            public string InsuranceSubscriberId { get; set; }
            public string UserId { get; set; }
            public string ChildId { get; set; }
            public string RegistrationToken { get; set; }
            public bool IsRegisteredUser { get; set; }

        }
        public class NotificationPref
        {
            public bool ReminderSevenDaysBefore { get; set; }
            public bool ReminderTwoDaysBefore { get; set; }
            public bool ReminderDayOf { get; set; }
            public bool TakeSurvey { get; set; }
            public int NumberOfReminders { get; set; }
            public TargetedMessage TargetedMessage { get; set; }
            public bool SendEmailReminders { get; set; }
            public bool SendTextReminders { get; set; }
        }
        public class TargetedMessage
        {
            public string Sponsor { get; set; }
            public string SponsorName { get; set; }
            public string CustomerServicePhone { get; set; }
            public string Facility { get; set; }
            public string ProductChannel { get; set; }
        }
        public class HoldTimeSlotModel
        {
            public string AppointmentID { get; set; }
            public string SlotId { get; set; }
            public string OfficeId { get; set; }
            public string ProviderId { get; set; }
            public string ConsumerID { get; set; }
            public string AppointmentType { get; set; }
            public string AppointmentDateTime { get; set; }
            public string AppointmentDateTimeUtc { get; set; }
            public string AppointmentReason { get; set; }
            public string AppointmentReasonId { get; set; }
            public string AppointmentCategory { get; set; }
            public string AdditionalNotes { get; set; }
            public string AppointmentStatus { get; set; }
            public string AccessTypeId { get; set; }
            public AppointmentMessage AppointmentMessage { get; set; }
            public string PartnerReasonIdList { get; set; }
            public string PartnerPracticeId { get; set; }
            public string PartnerAppointmentId { get; set; }
            public string PartnerProviderId { get; set; }
            public string PartnerSiteId { get; set; }
            public string PartnerDepartmentId { get; set; }
            public string PartnerId { get; set; }
            public string PartnerStatus { get; set; }
            public string HasAppointmentReasons { get; set; }
            public string PartnerHandlesCrm { get; set; }
            public string AppointmentSource { get; set; }
            public string PartnerPatientId { get; set; }
            public bool IsModifiedAppointment { get; set; }
            public bool IsChangedTimeSlot { get; set; }
            public bool SuppressConfirmationEmail { get; set; }
            public string MobilePin { get; set; }
            public bool IsTextVerification { get; set; }
            public bool IsEmailVerification { get; set; }
            public string LoadDate { get; set; }
            public string ProvideToPartnerProviderCode { get; set; }
            public string SponsorCode { get; set; }
            public string FacilityCode { get; set; }
            public string AppointmentDateTimeToString { get; set; }
            public string AppointmentConfirmationId { get; set; }
            public string AppointmentToken { get; set; }
            public string BookingSource { get; set; }

        }
        public class AppointmentMessage
        {
            public string Acknowledge { get; set; }
            public int StatusCode { get; set; }
            public string MessageTitle { get; set; }
            public string MessageBody { get; set; }
            public string Data { get; set; }
        }
    
}
