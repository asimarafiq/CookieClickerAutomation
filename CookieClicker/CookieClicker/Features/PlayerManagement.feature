Feature: PlayerManagement

Homepage Player Management

# TC01 - Alphbetic Name: Ability to create a new player. - PASSED
# TC02 - Numeric Name: Ability to create a new player.- PASSED
# TC03 - Alphanumeric Name: Ability to create a  new player. - PASSED
Scenario Outline: Create a new players successfully
    Given I navigate to the Cookie Clicker home page
    When I enter "<playerName>" into the player name input
    And I click the Start button
    Then a game should be created for player "<playerName>"

    Examples:
        | playerName   |
        | CookiePlayer |
        | 658789       |
        | Player867    |

# TC04 - Ability to open an existing player's game. - PASSED
Scenario: Open an existing player's game
	Given I create a new player "Asim" 
    When I navigate to the home page
    And I select the existing player "Asim"
    Then the game page should be displayed for player "Asim"

# TC05 - Prevent creating a player with an empty name - FAILED (Bug 1)
Scenario: Prevent creating a player with an empty name
    Given I navigate to the Cookie Clicker home page
    When the player name input is empty
    And I click the Start button
	Then I should remain on the home page and a player should not be created
