# Exercise - Restaurant Ordering System

Create a Java program that simulates a basic restaurant ordering system. The user will first be prompted to choose between two main menu categories: Drinks and Food. Based on the user's choice, a subcategory menu will be displayed for them to make a more specific selection.

### Instructions
1. Display the main menu:
```
Welcome to the Java Bistro!
Please select a category:
1 - Drinks
2 - Food
```
2. Read the user's category selection.
3. Depending on the category, display a sub-menu:
   - **Drinks Menu**:
     - 1 - Water
     - 2 - Soda
     - 3 - Coffee
   - **Food Menu**:
     - 1 - Pizza
     - 2 - Salad
     - 3 - Burger
4. Read the user's item selection.
5. Use nested switch statements to determine the exact item and print a confirmation message:
```
You ordered: Soda
```
6. If the user enters an invalid choice, show an appropriate message:
```
Invalid selection.
```

### Example Output
```
Welcome to the Java Bistro!
Please select a category:
1 - Drinks
2 - Food
> 1

Drinks Menu:
1 - Water
2 - Soda
3 - Coffee
> 2

You ordered: Soda
```