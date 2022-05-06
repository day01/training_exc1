Feature: Calculator
![Calculator](https://specflow.org/wp-content/uploads/2020/09/calculator.png)
Simple calculator for adding **two** numbers

Link to a feature: [Calculator]($projectname$/Features/Calculator.feature)
***Further read***: **[Learn more about how to generate Living Documentation](https://docs.specflow.org/projects/specflow-livingdoc/en/latest/LivingDocGenerator/Generating-Documentation.html)**

#Scenario: Add two numbers
#	Given the first number is 50
#	And the second number is 70
#	When the two numbers are added
#	Then the result should be 120
#
#Scenario: Add two numbers with reset while adding and result equals null
#	Given the first number is 50
#	* the second number is 70
#	When reset the calculator 
#	* the two numbers are added
#	Then the result should empty

#Scenario: Subtrack two numbers
#	Given the first number is 100
#	And the second number is 10
#	When the two numbers are subtracted
#	Then the result should be 90
	
#Scenario Outline: Add two numbers permutations
#	Given the first number is <first number>
#	And the second number is <second number>
#	When the two numbers are added
#	Then the result should be <expected result>
#	
#Examples:
#| first number | second number | expected result |
#| 50           | 70            | 120             |
#| 120          | 70            | 190             |
#| -31          | 90            | 59              |
