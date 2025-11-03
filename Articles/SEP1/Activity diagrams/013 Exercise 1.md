# Exercise 1

For each of the following scenarios, create an activity diagram. Include start and end nodes, activity boxes, decision diamonds, and appropriate arrows with conditions.


## Exercise 1.1: Withdraw Cash from ATM

Create an activity diagram for the following scenario, about withdrawing cash from an ATM.

1. User inserts card
2. System prompts for PIN
3. User enters PIN
4. System validates PIN
   - If PIN is invalid, show error message and go back to step 3
   - If user enters wrong PIN 3 times, card is retained and process ends
5. User enters withdrawal amount
6. System checks account balance
   - If insufficient funds, show error message and go back to step 5, or
   - User selects to cancel withdrawal and end process
7. System dispenses cash
8. System prints receipt
9. System returns card

Note: that part about 3 wrong tries, that is a bit iffy to show. You may have to invent your own notation. Or, portentially make a sequence of selections.


## Exercise 1.2: Make Coffee

Create an activity diagram to express the following scenario, about making coffee.

1. Turn on coffee machine
2. Check if water reservoir has water
   - If no water, show "Add water" message
   - User should add water and go back to step 2
3. Check if coffee grounds container has coffee
   - If no coffee grounds, show "Add coffee" message and go back to step 2
4. Place cup under dispenser
5. Press start button
6. System checks if cup is in place
   - If no cup detected, show error and go back to step 4
7. System heats water
8. System brews coffee
9. System beeps when done
10. User removes cup

**Challenge:** Include multiple precondition checks before brewing can start.


