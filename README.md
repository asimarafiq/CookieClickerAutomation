# CookieClickerAutomation
Automated Test Cases for Cookie Clicker
# TC01: Alphabetic Name: Ability to create a new player.	FAILED	Bug 1
# TC02: Numeric Name: Ability to create a new player.	PASSED	
# TC03: Alphanumeric Name: Ability to create a  new player.	PASSED	
# TC04: Ability to open an existing player's game.	PASSED	
# TC05: Prevent creating a player with an empty name	PASSED	
# TC06: Create Cookies by clicking the cookie button and verifying the cookie count	PASSED	
# TC07: Partial sale: Selling some cookies updates remaining cookie count and money balance.	PASSED	
# TC08: Boundary of half the cookies: Selling exactly half the number of cookies verifies the calculation at the boundary.	PASSED	
# TC09: Sell all cookies: The cookie count reaches zero and the money is correct.	FAILED	Bug 4
# TC10: Minimum sale: Selling a single cookie works correctly.	PASSED	
# TC11: Exceed available cookies: Should not be able to sell more cookies than the player owns.	PASSED	
# TC12: Selling negative number of cookies: Checks that a negative number of cookies cant be sold.	FAILED	Bug 5
# TC13: Fractional cookie sale: Non whole cookie sales should be rejected.	FAILED	Bug 6
# TC14: Zero cookie sale: Attempting to sell zero cookies confirms no game changes occur.	PASSED	
# TC15: Blank input sale: Attempting to sell a blank quantity is handled safely.	PASSED	
# TC16: Non-numeric input sale: Confirms non numeric sale is rejected and no game changes occur.	PASSED	
# TC17: Successful purchase of one factory with an exact balance.	PASSED	
# TC18: Successful purchase of multiple factories with money remaining.	PASSED	
# TC19: Insufficient funds — cannot afford a factory.	FAILED	Bug 7
# TC20: Cannot purchase a factory with no money.	FAILED	Bug 7
# TC21: Zero purchase quantity is rejected and no game changes occur	PASSED	
# TC22: Negative purchase quantity is rejected and no game changes occur.	PASSED	
# TC23: Non-numeric purchase quantity is rejected and no game changes occur.	PASSED	
# TC24: Fractional purchase quantity is rejected and no game changes occur.	FAILED	Bug 8

Bug No.	Bug
1	Can create a player with no name. Then unable to return to game as no link.
2	Can overwrite an existing player by creating a new player with the same name.
3	Currency format of money changes from $0.0 to $0 on game start.
4	Unable to sell All cookies as last cookie can not be sold.
5	Should not be able to sell negative number of cookies increases cookie count and creates money debt.
6	Fractional cookie sale is accepted but I expect non whole cookie sales to be rejected.
7	Able to buy a factory with no money or insufficient funds.
8	Fractional factory purchase is accepted but I expect non whole factory purchases to be rejected.
9	Factory purchase accepted in scientific notation (e.g.1e27 and displayed money cookies and factories purchased also displayed as scientific notation)


