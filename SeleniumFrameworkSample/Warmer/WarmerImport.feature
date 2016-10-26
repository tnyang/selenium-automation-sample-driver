@Warmer
Feature: WarmerImport
	Test warmer api-s


Scenario: Run Warmer _FullImportJob
	Given I have prepared an api request
	And the url is /Utilities/NewWarmer
	And the fullDataImportFlag is true
	And add fullDataImportFlag to url
	When the request is sent as a GET
	Then the response should be successfull

	Scenario: Run Warmer _PartialImportJob
	Given I have prepared an api request
	And the url is /Utilities/NewWarmer
	And the fullDataImportFlag is false
	And add fullDataImportFlag to url
	When the request is sent as a GET
	Then the response should be successfull