Feature: LoginFeature
	To ensure that the login features are implemented correctly

@Login
Scenario: A user will not be able to login without username and password
	Given the user is in the login page
	When the user has no username and password are inputted
	Then An error message that "Epic sadface: Username is required" is displayed

@login
Scenario: A user will not be able to login with invalid credentials
	Given the user is in the login page
	When the user input "Test" in username field and "123" in password field
	Then An error message that "Epic sadface: Username and password do not match any user in this service" is displayed

@Login
Scenario: A user will not be able to login without a password
	Given the user is in the login page
	When the user input "Test" in username field and "" in password field
	Then An error message that "Epic sadface: Password is required" is displayed

@Login
Scenario: A user with valid credentials will be able to login
	Given the user is in the login page
	When the user input "standard_user" in username field and "secret_sauce" in password field
	Then the Home page is displayed