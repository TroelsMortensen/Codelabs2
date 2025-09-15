# Exercises - round 3

Below are exercises to practice array iteration.

## Exercise 0: Print Array Elements

Write a Java program that creates an int array with 5 predefined numbers of your choice. Use a for loop to print each element of the array along with its index position.

### Example Output:
```
Array elements:
Index 0: 42
Index 1: 17
Index 2: 85
Index 3: 3
Index 4: 99
```

<hint title="Hint 1">

Create an int array using array initialization syntax with braces, i.e. `int[] numbers = {42, 17, 85, 3, 99};`.\
Use a for loop with `i < array.length` and print both the index `i` and the array element `array[i]`.

</hint>

<hint title="Solution">

```java
public class ArrayPrinter {
    public static void main(String[] args) {
        int[] numbers = {42, 17, 85, 3, 99};

        System.out.println("Array elements:");
        for (int i = 0; i < numbers.length; i++) {
            System.out.println("Index " + i + ": " + numbers[i]);
        }
    }
}
```

</hint>

## Exercise 1: Calculate Sum and Average

Write a Java program that creates an array of 5 student grades: {85, 92, 78, 96, 88}. Use a for loop to calculate the total sum of all grades and then calculate the average grade. Print both the total sum and the average.

### Example Output:
```
Total sum: 439
Average: 87.8
```

<hint title="Hint 1">

Create an integer variable to store the sum, initialized to 0. Use a for loop to iterate through the array and add each grade to the sum. Calculate the average by dividing the sum by the array length.

</hint>

<hint title="Solution">

```java
public class GradeCalculator {
    public static void main(String[] args) {
        int[] grades = {85, 92, 78, 96, 88};
        int sum = 0;

        // Calculate sum using for loop
        for (int i = 0; i < grades.length; i++) {
            sum += grades[i];
        }

        // Calculate average
        double average = (double) sum / grades.length;

        System.out.println("Total sum: " + sum);
        System.out.println("Average: " + average);
    }
}
```

</hint>

## Exercise 2: Find Largest Number

Write a Java program that finds the largest number in an array of integers using a for loop. Use the array: {12, 45, 7, 89, 23, 3, 17, 16, 33}.

You may assume all integers are positive.

### Example Output:
```
The largest number is: 89
```

<hint title="Hint 1">

Initialize a variable with the first element of the array as the starting maximum. Then use a for loop starting from index 1 to compare each number with the current maximum.

</hint>

<hint title="Solution">

```java
public class LargestNumber {
    public static void main(String[] args) {
        int[] numbers = {12, 45, 7, 89, 23, 3, 17, 16, 33};
        int largest = numbers[0]; // Start with first element

        // Find largest using for loop
        for (int i = 1; i < numbers.length; i++) {
            if (numbers[i] > largest) {
                largest = numbers[i];
            }
        }

        System.out.println("The largest number is: " + largest);
    }
}
```

</hint>

### Challenge
Now, the integers in the array can be negative. How do you modify the code to find the largest number?

## Exercise 3: Print Fruit List with While Loop

Write a program that prints a numbered list of fruits using a while loop. Use the array: {"apple", "banana", "orange", "grape"}. Each fruit should be printed with its position number (starting from 1).

### Example Output:
```
Fruit 1: apple
Fruit 2: banana
Fruit 3: orange
Fruit 4: grape
```

<hint title="Hint 1">

Create an index variable initialized to 0. Use a while loop that continues while the index is less than the array length. Inside the loop, print the fruit and increment the index.

</hint>


## Exercise 4: Reverse Array

Write a Java program that prints out the elements of an integer array in reverse order. Use the array: {1, 2, 3, 4, 5, 6, 7, 8, 9}.

### Example Output:
```
Array in reverse order:
9 8 7 6 5 4 3 2 1
```

<hint title="Hint 1">

Use a for loop that starts from the last index (array.length - 1) and decrements the index until it reaches 0. Print each element during the loop.

</hint>

<hint title="Solution">

```java
public class ReverseArray {
    public static void main(String[] args) {
        int[] numbers = {1, 2, 3, 4, 5, 6, 7, 8, 9};

        System.out.println("Array in reverse order:");
        for (int i = numbers.length - 1; i >= 0; i--) {
            System.out.print(numbers[i] + " ");
        }
        System.out.println(); // New line at the end
    }
}
```

</hint>

## Exercise 5: Reverse array copy
Write a Java program that copies the elements of an array in reverse order to a new array. Use the array: {1, 2, 3, 4, 5, 6, 7, 8, 9}. After program execution the new array should contain the elements {9, 8, 7, 6, 5, 4, 3, 2, 1}.\
Print it out for verification.

## Exercise 6: Search in Array

Write a Java program that searches for a specific string in an array and prints its index if found. Use the array: {"apple", "banana", "cherry", "date", "elderberry", "fig", "grape", "honeydew", "kiwi"}.\
Let the user input the string to search for and print whether the string was found or not. If found, also print the index.

### Example Output:
```
Enter a fruit to search for: cherry
Found 'cherry' at index 2

Enter a fruit to search for: orange
'orange' not found in the array
```

<hint title="Hint 1">

Use Scanner to read user input. Create a boolean variable to track if the item was found. Use a for loop to iterate through the array and compare each element with the search string using .equals().

</hint>

<hint title="Solution">

```java
import java.util.Scanner;

public class ArraySearch {
    public static void main(String[] args) {
        String[] fruits = {"apple", "banana", "cherry", "date", "elderberry", "fig", "grape", "honeydew", "kiwi"};
        Scanner scanner = new Scanner(System.in);

        System.out.print("Enter a fruit to search for: ");
        String searchFruit = scanner.nextLine();

        boolean found = false;
        int foundIndex = -1;

        // Search for the fruit
        for (int i = 0; i < fruits.length; i++) {
            if (fruits[i].equals(searchFruit)) {
                found = true;
                foundIndex = i;
                break; // Exit loop when found
            }
        }

        // Print result
        if (found) {
            System.out.println("Found '" + searchFruit + "' at index " + foundIndex);
        } else {
            System.out.println("'" + searchFruit + "' not found in the array");
        }

        scanner.close();
    }
}
```

</hint>

## Exercise 7: Count Elements with Condition

Write a Java program that counts how many elements in an array are greater than a user-provided number. Use the array: {10, 20, 30, 40, 50, 60, 70, 80, 90}. Let the user input the number to compare against.

### Example Output:
```
Enter a number: 45
There are 5 numbers greater than 45

Enter a number: 100
There are 0 numbers greater than 100
```

<hint title="Hint 1">

Use Scanner to read user input. Create an integer counter initialized to 0. Use a for loop to iterate through the array and increment the counter each time you find an element greater than the user's input.

</hint>

<hint title="Solution">

```java
import java.util.Scanner;

public class CountElements {
    public static void main(String[] args) {
        int[] numbers = {10, 20, 30, 40, 50, 60, 70, 80, 90};
        Scanner scanner = new Scanner(System.in);

        System.out.print("Enter a number: ");
        int threshold = scanner.nextInt();

        int count = 0;

        // Count elements greater than threshold
        for (int i = 0; i < numbers.length; i++) {
            if (numbers[i] > threshold) {
                count++;
            }
        }

        System.out.println("There are " + count + " numbers greater than " + threshold);

        scanner.close();
    }
}
```

</hint>


