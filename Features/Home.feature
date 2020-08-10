Feature: Home
	In order to test functionalities in Home page

@Home
Scenario: A user is able to add items to cart and reflected in the badge
	Given the user is logged in with standard_user username and secret_sauce password
	When the user add Sauce Labs Backpack item to cart
	Then the shopping cart icon badge will display 1 as number of items in cart