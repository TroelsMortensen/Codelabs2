# Implement a "List"

Some of these will be very tough, I don't expect you to do them, but it's a good challenge to try.

The purpose of these exercises is to task you to implement common operations on arrays in Java. It is annoying to manually implement these operations, so next week, we will look at how Java makes working with arrays easier.\
But for now, you will have to implement these operations yourself. It is a good exercise to understand how arrays work in Java.

These exercises will use helper methods to simplify the tasks. You have briefly seen the idea previously, but when relevant below, I will remind you how to use them.


## Exercise 0: Insert at specific positions in the array.
Sometimes you have an array, with numbers in it already, and you want to insert a new number at a specific position in the array.

For example:


| Index | 0 | 1 | 2 | 3 | 4 | 5 | 6 |
|-------|---|---|---|---|---|---|---|
| Value | 5 | 10| 15| 20| 25|  0|  0|

Above you have an array with room for 7 elements, but only 5 of them are filled with values. The last two are empty (0).

You want to insert a new number, 30, at index 2, so the array should look like this after the insertion:
| Index | 0 | 1 | 2 | 3 | 4 | 5 | 6 |
|-------|---|---|---|---|---|---|---|
| Value | 5 | 10| 30| 15| 20| 25|  0|

Notice how the numbers after index 2 have been shifted one position to the right, to make room for the new number.

Write a program that does the following:
1. Create an array of integers with size 7.
2. Fill the first 5 elements with values (5, 10, 15, 20, 25).

You may assume that the user does not misuse your program, or you can try to handle the errors. E.g. what happens if the chosen index is out of bounds? Or if the array is full, i.e. has no default values?

Then, to simplify things a bit, we will use a helper method. This concept was introduced a while ago, but hopefully you remember it. The initial code will look like this.

```java
import java.util.Arrays;
public class InsertAtPosition {
    public static void main(String[] args) {
        int[] numbers = {5, 10, 15, 20, 25, 0, 0}; // Initial array with room for 7 elements

        // Insert a new number at index 2
        int newNumber = 30;
        int position = 2;

        insertAtPosition(numbers, newNumber, position);

        // Print the updated array
        System.out.println("Updated array: " + Arrays.toString(numbers));
    }

    public static void insertAtPosition(int[] array, int value, int index) {
        // your cocde here
    }
}
```

The above helper method `insertAtPosition` will take an array variable, called `array`, a value to insert, called `value`, and an index where to insert the value, called `index`.\
In the method, use these three variables to insert the value into the array at the specified index. 

After the execution of the method, in the main method, the print out still knows about the now updated array, so you can print it out using `Arrays.toString(array)`.

### Version two
Allow the user to input the new number and the index where to insert it, by reading from the console.

## Exercise 1: Remove Element from Array

Write a helper method that can remove an element at a specific index from an array and shift all values to the right of that index one position to the left. The method should have the signature:

```java
public static void removeAtIndex(int[] array, int index)
```

For example, if you have an array like this:

| Index | 0 | 1 | 2 | 3 | 4 |
|-------|---|---|---|---|---|
| Value | 10| 20| 30| 40| 50|

And you want to remove the element at index 2 (value 30), the array should look like this after the removal:

| Index | 0 | 1 | 2 | 3 | 4 |
|-------|---|---|---|---|---|
| Value | 10| 20| 40| 50| 0 |

Notice how the values after index 2 have been shifted one position to the left, and the last position is now 0 (or empty).

Create a main method that demonstrates this functionality with an array containing values {10, 20, 30, 40, 50} and removes the element at index 2.

## Exercise 2: Index Of Element

Write a program with a helper method that finds the index of a specific element in an array. If the element is found, print its index. If the element is not found, print -1. The helper method should have the signature:

```java
public static void indexOf(int[] array, int value)
```

Create a main method that demonstrates this functionality by searching for different values in an array.

## Exercise 3: Contains Element

Write a helper method that checks if a given element exists in an array. Print true if the element is found, false if it is not found. The method should have the signature:

```java
public static void contains(int[] array, int value)
```

Create a main method that demonstrates this functionality by checking for the existence of different values in an array.

## Exercise 4: Reverse Array

Write a helper method that reverses the elements of an array and prints the reversed array. The method should have the signature:

```java
public static void reverseAndPrint(int[] array)
```

This means, you should modify the original array, not create a new one. Swap the first and last elements, the second and second last elements, etc.

Create a main method that demonstrates this functionality with an array of your choice.

## Exercise 5: Copy Array

Write a helper method that copies all values from one array to another array. The method should have the signature:

```java
public static void copyArray(int[] source, int[] destination)
```

Create a main method that demonstrates this functionality by copying values from one array to another and printing both arrays. The `destination` array should be created with the same size as the `source` array.

## Exercise 6: Dynamic Array Addition

Create a program that instantiates an array of size 10 and continuously requests the user for numbers to input into the array. Each number should be added at the next available position, so keep track of this position. Provide the user with options to either add a new number or print the current array contents. Continue until the user chooses to exit.

## Exercise 7: Expandable Array

Expand on Exercise 6, but when there is no more room in the array, create a new array of double the size and copy all elements over so the user can continue to input numbers. Provide the user with options to either add a new number or print the current array contents. Continue until the user chooses to exit. Notice you may use exercise 5 to help you.

## Exercise 8: putting it all together
Create a program that combines all the above exercises. That means the program should create an initial int array of size 5, then start a menu (in a while loop), requesting the user to choose an operation:
* add - to add a number to the array
* removeAtIndex - to remove a number from the array
* print - to print the current state of the array
* contains - to check if a number is in the array
* indexOf - to find the index of a number in the array
* reverse - to reverse the array
* exit - to exit the program

As needed copy your previous helper methods into the new file.

Feel free to expand, for example:
* let the user define the initial size
* find minimum and maximum values in the array
* get the average of all numbers in the array
* etc