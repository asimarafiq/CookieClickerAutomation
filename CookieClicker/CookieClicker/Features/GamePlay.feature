Feature: GamePlay

As a player I want to generate cookies, sell cookies and purchase factories so that I can earn money and increase my cookie production.

Background:
	Given I create a new player "Asim" 
    When I navigate to the home page
    And I select the existing player "Asim"
    Then the game page should be displayed for player "Asim"

# TC06 - Create Cookies by clicking the cookie button and verifying the cookie count - PASSED
Scenario: Generate cookies by clicking the button
    Given the game has 0 cookies, 0 factories and "0" money
    When I click the cookie button 5 times
    Then the game has 5 cookies, 0 factories and "0" money

# TC07 Partial sale: Selling some cookies updates remaining cookie count and money balance.- PASSED
# TC08 Boundary of half the cookies: Selling exactly half the number of cookies verifies the calculation at the boundary.- PASSED
# TC09 Sell all cookies:The cookie count reaches zero and the money is correct. - FAILED (Bug 4)
# TC10 Minimum sale: Selling a single cookie works correctly.- PASSED
# TC11 Exceed available cookies: Should not be able to sell more cookies than the player owns.- PASSED
# TC12 Selling negative number of cookies: Checks that a negative number of cookies cant be sold. - FAILED (Bug 5)
# TC13 Fractional cookie sale: Non whole cookie sales should be rejected. - FAILED (Bug 6)
# TC14 Zero cookie sale: Attempting to sell zero cookies confirms no game changes occur.- PASSED
# TC15 Blank input sale: Attempting to sell a blank quantity is handled safely.- PASSED
# TC16 Non-numeric input sale: Confirms non numeric sale is rejected and no game changes occur.- PASSED
Scenario Outline: Sell cookies and verify the transaction calculations
    Given I click the cookie button <initialCookies> times
    When the game has <initialCookies> cookies, 0 factories and "0" money
    And I sell <sellQuantity> cookies
    Then the game has <expectedCookies> cookies, 0 factories and "<expectedMoney>" money

    Examples:
      | initialCookies | sellQuantity | expectedCookies | expectedMoney |
      | 10             | 4            | 6               | 1             |
      | 10             | 5            | 5               | 1.25          |
      | 10             | 10           | 0               | 2.50          |
      | 10             | 1            | 9               | 0.25          |
      | 5              | 6            | 5               | 0             |
      | 5              | -1           | 5               | 0             |
      | 5              | 1.5          | 5               | 0             |
      | 5              | 0            | 5               | 0             |
      | 5              | [blank]      | 5               | 0             |
      | 5              | abc          | 5               | 0             |


# TC17: Successful purchase of one factory with an exact balance. - PASSED
# TC18: Successful purchase of multiple factories with money remaining. - PASSED
# TC19: Insufficient funds — cannot afford a factory.- FAILED (Bug 7)
# TC20: Cannot purchase a factory with no money. - FAILED (Bug 7)
# TC21: Zero purchase quantity is rejected and no game changes occur - PASSED
# TC22: Negative purchase quantity is rejected and no game changes occur. - PASSED
# TC23: Non-numeric purchase quantity is rejected and no game changes occur. PASSED
# TC24: Fractional purchase quantity is rejected and no game changes occur. - FAILED (Bug 8)
Scenario Outline: Buying factories and verifying transaction calculations
    Given I click the cookie button <cookiesToCreate> times
    When the game has <cookiesToCreate> cookies, 0 factories and "0" money
    And I sell <cookiesToSell> cookies
    And the game has 0 factories and "<expectedMoneyBefore>" money
    And I buy <factoryBuyQuantity> factory
    Then the game has <factoriesPurchased> factories and "<expectedMoneyAfter>" money

Examples:
  | cookiesToCreate | cookiesToSell | expectedMoneyBefore | factoryBuyQuantity | expectedMoneyAfter | factoriesPurchased |
  | 13              | 12            | 3                   | 1                  | 0                  | 1                  |
  | 25              | 24            | 6                   | 2                  | 0                  | 2                  |
  | 6               | 5             | 1.25                | 1                  | 1.25               | 0                  |
  | 0               | 0             | 0                   | 1                  | 0                  | 0                  |
  | 25              | 24            | 6                   | 0                  | 6                  | 0                  |
  | 25              | 24            | 6                   | -1                 | 6                  | 0                  |
  | 25              | 24            | 6                   | abc                | 6                  | 0                  |
  | 25              | 24            | 6                   | 1.5                | 6                  | 0                  |

