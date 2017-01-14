Feature: ArticleApiTest
	In order to avoid silly mistakes
	As a ArticleApiUser
	I want to test all possible scenarios

Scenario Outline: Create New Article Using Api
	Given I have a Article <Title>,<Body>,<AuthourName>
	And I Save the Article
	When I Query the Article Repository
	Then the result should be an Article
	Examples:
	| Title     | Body            | AuthourName |
	| Welcome   | Lunch at casino | John        |
	| Appraisal | Money           | John        |


Scenario Outline: Update an Article Using Api
	Given I have a Article <Id>,<Title>,<Body>,<AuthourName>
	And I update the Article <Id>,<Title>,<Body>,<AuthourName>
	When I Query the Article Repository
	Then the result should be an Article
	Examples:
	| Id | Title      | Body            | AuthourName |
	| 5  | Welcome1   | Lunch at casino | John        |
	| 7  | Appraisal1 | Money           | John        |

Scenario Outline: Delete an Article Using Api
	Given I have a Article <Id>
	And I delete the Article <Id>
	When I Query the Article Repository
	Then the result should be null
	Examples: 
	| Id |
	| 1  |
	| 2  |



