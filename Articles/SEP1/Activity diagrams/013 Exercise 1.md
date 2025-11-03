# Exercise 1

For each of the following scenarios, create an activity diagram. Include start and end nodes, activity boxes, decision diamonds, and appropriate arrows with conditions.

---

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
   - If insufficient funds, show error message and go back to step 5
7. System dispenses cash
8. System prints receipt
9. System returns card

**Challenge:** Make sure to handle both the invalid PIN loop and the maximum attempts before ending.

---

## Exercise 1.2: Make Coffee

Create an activity diagram for the following scenario, about making coffee.

1. Check if water reservoir has water
   - If no water, show "Add water" message and go back to step 1
2. Check if coffee grounds container has coffee
   - If no coffee grounds, show "Add coffee" message and go back to step 2
3. Place cup under dispenser
4. Press start button
5. System checks if cup is in place
   - If no cup detected, show error and go back to step 3
6. System heats water
7. System brews coffee
8. System beeps when done
9. User removes cup

**Challenge:** Include multiple precondition checks before brewing can start.

---

## Exercise 1.3: Login to System

Create an activity diagram for the following scenario, about logging in to a system.

1. Display login screen
2. User enters username
3. User enters password
4. User clicks login button
5. System validates username exists
   - If username not found, show "Invalid credentials" error and go back to step 2
6. System validates password matches
   - If password incorrect, increment failed login counter
   - If failed login counter < 3, show "Invalid credentials" error and go back to step 3
   - If failed login counter = 3, lock account and end process
7. System checks if account is active
   - If account is locked, show "Account locked" message and end process
8. System loads user preferences
9. System displays dashboard

**Challenge:** Track the number of failed login attempts and lock the account after 3 attempts.

---

## Tips for Creating Activity Diagrams

- Start with a filled black circle (start node)
- Use rounded rectangles for activities
- Use diamonds for decisions/conditions
- Label condition branches with `[condition]` and `[otherwise]`
- End with a filled black circle with a ring around it (end node)
- Use arrows to show the flow between elements
