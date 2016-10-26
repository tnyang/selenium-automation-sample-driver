@SolrTests
Feature: AppointmentManagementSolrTests
	Run Solr queries agains ProviderAppointment  and ProviderAppointmentFull cores

#Scenario: Get Total Provider Count _Slave_ProviderAppointment
#    Given I have prepared an api request
#	And the solrNode is slave
#	And the solrCore is providerappointment
#	And the url is /select?q=*%3A*&fq=schema_type%3APROVIDER&wt=json&indent=true
#	When the request is sent as a GET
#	Then the response should contain correct info
#
#Scenario: Get Total Provider Count _Master_ProviderAppointmentFull
#    Given I have prepared an api request
#	And the solrNode is master
#	And the solrCore is providerappointmentfull
#	And the url is /select?q=*%3A*&fq=schema_type%3APROVIDER&wt=json&indent=true
#	When the request is sent as a GET
#	Then the response should contain correct info
#
#
#Scenario: Get Total AppointmentReason Count _Slave_ProviderAppointment
#    Given I have prepared an api request
#	And the solrNode is slave
#	And the solrCore is providerappointment
#	And the url is /select?q=*%3A*&fq=schema_type%3AAPPTREASON&wt=json&indent=true
#	When the request is sent as a GET
#	Then the response should contain correct info
#
#Scenario: Get Total AppointmentReason Count _Master_ProviderAppointmentFull
#    Given I have prepared an api request
#	And the solrNode is master
#	And the solrCore is providerappointmentfull
#	And the url is /select?q=*%3A*&fq=schema_type%3AAPPTREASON&wt=json&indent=true
#	When the request is sent as a GET
#	Then the response should contain correct info
#
#
#Scenario Outline: Get Total Timeslot Count _Slave_ProviderAppointment
#    Given I have prepared an api request
#	And the solrNode is slave
#	And the solrCore is providerappointment
#	And the url is /select?q=*%3A*&fq=schema_type%3ATIMESLOT&wt=json&indent=true
#	When the request is sent as a GET
#	Then the response should contain correct info
#
#Scenario Outline: Get Total Timeslot Count _Master_ProviderAppointmentFull
#    Given I have prepared an api request
#	And the solrNode is master
#	And the solrCore is providerappointmentfull
#	And the url is /select?q=*%3A*&fq=schema_type%3ATIMESLOT&wt=json&indent=true
#	When the request is sent as a GET
#	Then the response should contain correct info




Scenario Outline: Get Removed Timeslot _MHD
    Given I have prepared an api request
	And the solrNode is slave
	And the solrCore is <solrCore>
	And the url is /select?q=timeslot_id%3A+TIMESLOTID&fq=schema_type%3ATIMESLOT&wt=json&indent=true
	And the fileName is MHD <slotIdMHD.txt>
	When the request is sent as a GET
	Then the response should NOT contain removed timeslot
Examples:
| solrCore |
| providerappointmentfull  |
| providerappointment  |

Scenario Outline: Get Added Timeslot _MHD
    Given I have prepared an api request
	And the solrNode is slave
	And the solrCore is providerappointment
	And the url is /select?q=timeslot_id%3A+SLOTID&fq=schema_type%3ATIMESLOT&wt=json&indent=true
	And the fileName is MHD <MHDDateTime.txt>
	When the request is sent as a GET
	Then the response should contain added timeslot
Examples:
| solrCore |
| providerappointmentfull  |
| providerappointment  |

