# Exercise - List app

This exercise is similar to the last one from the array session. You will make a console application, to manipulate a list of strings. The application will allow the user to add, remove, display, etc items in the list.

We will expand the functionality one step at a time.

## Exercise 1: List App

First, create the program, which instantiates a list of strings. Don't add any elements to the list yet.

Then in a loop, print out a menu with the following options:
- `exit` - terminates the app


If the user inputs `exit`, the program should terminate.

If the user inputs an invalid option, print an error message, and prompt the user again.

You may use numbers to select menu options, or just type the option name.

## Exercise 2: Add Item

Expand the program, so the menu now allows the user to add an item to the list. 

When the user selects the option to add an item, prompt them for the string to add, and then add it to the list.

## Exercise 3: Display List

Now, allow the user to display the current state of the list.

When the user selects the option to display the list, print out all the items in the list.

The menu should now look something like this (not necessarily in this order):

```
1. Add Item
2. Display List
3. Exit
```

## Exercise 4: Remove index

Expand the program to allow the user to remove an item from the list by its index.

When the user selects the option to remove an item, prompt them for the index of the item to remove. If the index is valid, remove the item and display a success message. If the index is invalid, display an error message.

## Exercise 5: Remove single Value

Expand the program to allow the user to remove an item from the list by its value.

When the user selects the option to remove an item by value, prompt them for the string to remove. If the string is found in the list, remove it and display a success message. Remove only the first occurrence of the value. If it is not found, display an error message.

## Exercise 6: Remove all Occurrences
Expand the program to allow the user to remove all occurrences of a specific value from the list.

When the user selects the option to remove all occurrences, prompt them for the string to remove. If the string is found in the list, remove all occurrences and display a success message. If it is not found, display an error message.

## Exercise 7: Search for Item
Expand the program to allow the user to search for an item in the list.

When the user selects the option to search, prompt them for the string to search for. If the string is found, display its index. If it is not found, display an error message.

## Exercise 8: Count Items
Expand the program to allow the user to request a count of how many items are in the list.

When the user selects the option to count items, display the total number of items in the list.

## Exercise 9: Clear List
Expand the program to allow the user to clear the entire list.

When the user selects the option to clear the list, remove all items from the list and display a success message.   

Optionally, you may request the user to confirm the action before clearing the list.

## Exercise 10: Replace Item
Expand the program to allow the user to replace an item in the list.

When the user selects the option to replace an item, prompt them for the index of the item to replace and the new value. If the index is valid, replace the item and display a success message, and the current state of the list. If the index is invalid, display an error message.

## Exercise 11: Extra

You may optionally add more features, such as:
- Sorting the list (This functionality is built in, there is already a method for that. Look it up)
- Finding the longest or shortest string in the list
- Implementing a search feature that finds all occurrences of a specific string and displays their indices
- Implementing a feature to reverse the order of items in the list
- Implementing a feature to shuffle the items in the list randomly (i.e. randomly rearranging the items)
  - Shuffling can be implemented with a for-loop, and a number of iterations equal to the number of items in the list (or more, if you want to shuffle more thoroughly).
  - In each iteration, swap two random items in the list.
