Feature: Login to healthgrades Admin
	In order to validate the healthgrades Admin page
	As a user
	I want to be able to login to the healthgrades Admin page

@login_positive
Scenario Outline: Login to healthgrades Admin page successfully
	Given I am at the healthgrades Admins login page for environment 'hgtestweb12'
	When  I enter email user id "<userid>" and password "<password>"
	Then the homepage logo is present

Examples:
| userid                       | password  |
| mbadyelkhan@healthgrades.com | Abcd1234! |