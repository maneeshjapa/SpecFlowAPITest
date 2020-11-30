Feature: Spring API test
		 As a user
		 I want to access rest api to perform CRUD operations

Scenario: Get list of all users
	Given User access the api
	When User requests to view all users
	Then The service returns list of all users

Scenario: Create a new user
	Given User access the api
	When User requests to create a user with details
	| userName | password | firstName | lastName | email                   |
	| TestUser | TestUser | TestUser  | TestUser | TestUser@automation.com |
	Then The service should successfully create a user

Scenario: Delete a user
	Given User access the api
	When User requests to create a user with details
	| userName         | password         | firstName        | lastName         | email                           |
	| TestUserToDelete | TestUserToDelete | TestUserToDelete | TestUserToDelete | TestUserToDelete@automation.com |
	Then The service should successfully create a user
	When User requests to delete the created user with userId
	Then The Service should successfully delete the user