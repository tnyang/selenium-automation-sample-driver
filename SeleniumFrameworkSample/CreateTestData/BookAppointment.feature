@CreateTestData
Feature: BookAppointment
	In order build an app for a specific campaingId
	As an internal developer
	I want to be able to book appointment by appointmentId


Scenario: CreateTestDataCreate Book appointment _MHD
	Given I have prepared an api request
	And the url is /Appointments/AvailableAppointments
	And the partnerId is MHD
	And add partnerId to url
	And the partnerOfficeId is 1333
	And the officeId is FLX4Y
	And add partnerOfficeId to url
	And the partnerPracticeId is 1333
	And add partnerPracticeId to url
	And the partnerProviderId is 675
	And add partnerProviderId to url
	And the providerId is 3cncw
	And add providerId to url
	And the windowDateTime is today
	And add windowDateTime to url
	And the windowDays is 180
	And add windowDays to url
	And set available timeslotId and AppointmentDateTime
	And set HoldTimeSlot request body with following additional fields
	    | name              | value    |
	    | PartnerSiteId     | 1        |
	    | AppointmentSource | OAS      |
	And the url is /Appointments/HoldTimeSlot
	And set consumerId
	And set PreBookAppointment request body with following additional fields
		| name                       | value                              |
		| firstname                  | FirstName                          |
		| lastname                   | LastName                           |
		| dateOfBirth                | 1970-01-01                         |
		| sex                        | male                               |
		| address1                   | 123 Main St.                       |
		| city                       | Denver                             |
		| state                      | CO                                 |
		| zipcode                    | 80202                              |
		| email                      | automationTest@healthgrades.com    |
		| HomeNumber                 | 303-333-3333                       |
		| MobileNumber               | 303-333-3333                       |
		| isPatientInsured           | false                              |
		| InsuranceCarrier           |                                    |
		| InsurancePlan              |                                    |
		| InsuranceSubscriberId      |                                    |
		| SendTextReminders          | false                              |
		| Reminder7DaysBefore        | false                              |
		| Reminder2DaysBefore        | false                              |
		| ReminderDayOf              | false                              |
		| ReminderTakeSurvey         | false                              |
		| productChannel             | 9                                  |
		| SponsorCode                | hg                                 |
		| SponsorName                | Pinnacle University Medical Center |
		| FacilityCode               |                                    |
		| CustomerServicePhone       |                                    |
		| AppointmentType            | New Patient                        |
		| isTextVerification         | false                              |
		| isEmailVerification        | false                              |
		| acceptedTermsAndConditions | true                               |
		| appointmentCategory        | N                                  |
		| appointmentReason          | Problem                            |
		| appointmentReasonId        | 541                                |
		| partnerDepartmentId        | x                                  |
	And the url is /Appointments/PreBookAppointment
	And the request is sent as POST
	And the url is /Appointments/BookAppointmentByAppointmentId
	And add appointmentId to url
	And add userip to url
	When the request is sent as a GET
	Then the response should be successfull <testscenario>


Scenario: CreateTestDataCreate Book appointment _ATH
	Given I have prepared an api request
	And the url is /Appointments/AvailableAppointments
	And the partnerId is ATH
	And add partnerId to url
	And the partnerOfficeId is 1
	And the officeId is OO7H5K9
	And add partnerOfficeId to url
	And the partnerPracticeId is 1959005
	And add partnerPracticeId to url
	And the partnerProviderId is 23
	And add partnerProviderId to url
	And the providerId is xbd3x
	And add providerId to url
	And the windowDateTime is today
	And add windowDateTime to url
	And the windowDays is 180
	And add windowDays to url
	And set available timeslotId and AppointmentDateTime
	And set HoldTimeSlot request body with following additional fields
	    | name              | value    |
	    | PartnerSiteId     | 1        |
	    | AppointmentSource | OAS      |
	And the url is /Appointments/HoldTimeSlot
	And set consumerId
	And set PreBookAppointment request body with following additional fields
		| name                       | value                              |
		| firstname                  | FirstName                          |
		| lastname                   | LastName                           |
		| dateOfBirth                | 1970-01-01                         |
		| sex                        | male                               |
		| address1                   | 123 Main St.                       |
		| city                       | Denver                             |
		| state                      | CO                                 |
		| zipcode                    | 80202                              |
		| email                      | automationTest@healthgrades.com    |
		| HomeNumber                 | 303-333-3333                       |
		| MobileNumber               | 303-333-3333                       |
		| isPatientInsured           | false                              |
		| InsuranceCarrier           |                                    |
		| InsurancePlan              |                                    |
		| InsuranceSubscriberId      |                                    |
		| SendTextReminders          | false                              |
		| Reminder7DaysBefore        | false                              |
		| Reminder2DaysBefore        | false                              |
		| ReminderDayOf              | false                              |
		| ReminderTakeSurvey         | false                              |
		| productChannel             | 9                                  |
		| SponsorCode                | hg                                 |
		| SponsorName                | Pinnacle University Medical Center |
		| FacilityCode               |                                    |
		| CustomerServicePhone       |                                    |
		| AppointmentType            | New Patient                        |
		| isTextVerification         | false                              |
		| isEmailVerification        | false                              |
		| acceptedTermsAndConditions | true                               |
		| appointmentCategory        | N                                  |
		| appointmentReason          | Problem                            |
		| appointmentReasonId        | 541                                |
		| partnerDepartmentId        | x                                  |
	And the url is /Appointments/PreBookAppointment
	And the request is sent as POST
	And the url is /Appointments/BookAppointmentByAppointmentId
	And add appointmentId to url
	And add userip to url
	When the request is sent as a GET
	Then the response should be successfull <testscenario>

