Feature: ArticleManagerTest
	In order to avoid silly mistakes
	As a ArticleManager
	I want to test all possible scenarios


Scenario Outline: Create New Article
	Given I have a Article <Title>,<Body>,<AuthourName>
	And I Save the Article
	When I Query the Article Repository
	Then the result should be an Article
	Examples:
	| Title     | Body            | AuthourName |
	| Welcome   | Lunch at casino | John        |
	| Appraisal | Money           | John        |


