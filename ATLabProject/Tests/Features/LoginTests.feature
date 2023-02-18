Feature: LoginTests
I want to be able load the login page and see homepage (vitrine)

@smoke
Scenario: Login page should open
	Then Login page is opened

@CriticalPath
Scenario Outline: Enterining correct login and password I should see webshop's vitrine
	When I type correct '<login>' and password
	Then Homepage is opened	
	Examples: 
	| login                   |
	| standard_user           | 
	| problem_user            | 
	| performance_glitch_user | 

@CriticalPath
Scenario: User shouldn't be abe to login with locked_out_user login and correct password
When I type locked_out_user username in username field and correct password
Then 'Epic sadface: Sorry, this user has been locked out.' label should appeared.

@CriticalPath
Scenario: Login page should open when user go to url "https://www.saucedemo.com/inventory.html"
When I type the url "https://www.saucedemo.com/inventory.html" at the browser
Then the Login page is opened