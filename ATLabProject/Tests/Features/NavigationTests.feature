Feature: NavigationTests

    Background: User should be logged in
        Given User logged in with standard_user as username and secret_sauce as password

    @CriticalPath
    Scenario: Twitter link should be opened
        When Click Twitter link
        Then Twitter saucelabs page is opened

    @CriticalPath
    Scenario: Facebook link should be opened
        When Click Facebook link
        Then Facebook saucelabs page is opened
        
    @CriticalPath
    Scenario: Linkedin link should be opened
        When Click Linkedin link
        Then Linkedin saucelabs page is opened
        
    @CriticalPath
    Scenario: The Products page should be opened by clicking the back to products button on the product page
        Given Open Product page
        When Click back to products button
        Then Home page is opened
        
    @CriticalPath
    Scenario: The Products page should be opened by clicking the cancel button on the overview page
        Given Open Overview page
        When Click cancel button on the overview page 
        Then Home page is opened
       
     @CriticalPath
    Scenario: The cart page should be opened by clicking the cancel button on the checkout page
    Given Open checkout page
    When Click cancel button on the checkout page
    Then cart page is opened