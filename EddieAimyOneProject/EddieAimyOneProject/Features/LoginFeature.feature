Feature: LoginFeature

As a Tester
I would like to login to the AimyOne portal with different credentials
So that I can check the status of each possibility

@tag1
Scenario: I used valid credentials to login
Given I use this valid credentials json file to login the protal
Then I enter valid username and valid password
Then I should be able to see my account username showing on the profile page


Scenario Outline: I login to portal without enter the username
Given I enter empty '<username>' and valid '<password>'
Then I should be able to see the error username message popup

Examples: 
| username | password |
|          | 12341234 |


Scenario Outline: I login to portal without enter the password
Given I enter valid '<username>' and empty '<password>'
Then I should be able to see the password error message popup

Examples: 
| username            | password |
| hlhedison@gmail.com |          |


Scenario Outline: Login to portal with not existed username
Given I enter the '<username>' and '<password>'
Then I should be able to see the invaild credentials error message

Examples: 
| username         | password  |
| edison@gmail.com | 123456789 |