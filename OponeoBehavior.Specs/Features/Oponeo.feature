Feature: Oponeo Main page
	Simple test of oponeo main page
	

Scenario: Open a main page and scroll down
	Given Open main oponeo page
	When Click at the car search
	* wait to show result
	* scroll down of the page
	Then wait to show result
	* Check the bottom of page is displayed
	
Scenario: Choose a car and model
	Given Open main oponeo page
	When Click at the car search
	* wait to show result
	* Select Car mark as "Opel"
	* Select model as "Corsa"
	* wait to show result
	Then Mark is "Opel" and model is "Corsa"
	
Scenario: Go to motor subpage
	Given Open main oponeo page
	When Click at the submenu
	* click at motor submenu
	* wait to show result
	Then wait to show result
	Then the subpage is a motor page
