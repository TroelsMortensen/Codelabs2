# Exercise - Adding and removing

In this exercise, you will create a small program, which continuously will allow a user to add or remove elements from an array, and print the current state of the array.

1) Create an array of integers with size 5.
2) Use a `while` loop to continuously ask the user for input, think of this as the "main menu", one of:
   1) "add" - to add a number to the array
   2) "remove" - to remove a number from the array
   3) "print" - to print the current state of the array
   4) "exit" - to exit the program
3) If the user enters "add", ask for a number and add it to the first empty position in the array.
4) If the user enters "remove", remove the last number in the array.
5) If the user enters "print", print the current state of the array, remember how you can use `Arrays.toString(array)` to print the array in a readable format.
6) If the user enters "exit", break the loop and end the program.

Now, a few details on the behaviour of the program:
1) You will add numbers to the first empty position in the array, so if the user adds a number, it will be added to the first index that is `0`. The next number is added at index 1, and so on. Create an integer variable to keep track of the current index where the next number should be added.
2) If the array is full, and the user selects to add a number, print a message saying "Array is full, cannot add more numbers." And go back to the main menu.
3) If the user selects to remove a number, but the array is empty, print a message saying "Array is empty, cannot remove numbers." and go back to the main menu.

### Example Input/Output:
```
Main menu:
Enter command (add/remove/print/exit): add
Enter a number to add: 10

Main menu:
Enter command (add/remove/print/exit): add
Enter a number to add: 20

Main menu:
Enter command (add/remove/print/exit): print
Current array: [10, 20, 0, 0, 0]

Main menu:
Enter command (add/remove/print/exit): add
Enter a number to add: 30

Main menu:
Enter command (add/remove/print/exit): add
Enter a number to add: 40

Main menu:
Enter command (add/remove/print/exit): add
Enter a number to add: 50

Main menu:
Enter command (add/remove/print/exit): print
Current array: [10, 20, 30, 40, 50]

Main menu:
Enter command (add/remove/print/exit): add
Enter a number to add: 60
Array is full, cannot add more numbers.

Main menu:
Enter command (add/remove/print/exit): remove
Removed number: 50

Main menu:
Enter command (add/remove/print/exit): print
Current array: [10, 20, 30, 40, 0]

Main menu:
Enter command (add/remove/print/exit): remove
Removed number: 40

Main menu:
Enter command (add/remove/print/exit): remove
Removed number: 30

Main menu:
Enter command (add/remove/print/exit): remove
Removed number: 20

Main menu:
Enter command (add/remove/print/exit): remove
Removed number: 10

Main menu:
Enter command (add/remove/print/exit): remove
Array is empty, cannot remove numbers.

Main menu:
Enter command (add/remove/print/exit): print
Current array: [0, 0, 0, 0, 0]

Main menu:
Enter command (add/remove/print/exit): exit
Goodbye!
```

This example demonstrates:
- Adding numbers to the array sequentially
- Printing the current state showing both added numbers and empty positions (0s)
- Handling the "array full" condition
- Removing numbers from the end (last-in, first-out behavior)
- Handling the "array empty" condition
- Properly exiting the program

