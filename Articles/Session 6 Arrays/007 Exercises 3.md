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

Create an int array using array literal syntax with curly braces. Use a for loop with `i < array.length` and print both the index `i` and the array element `array[i]`.

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

<hint title="Solution">

```java
public class FruitList {
    public static void main(String[] args) {
        String[] fruits = {"apple", "banana", "orange", "grape"};

        // Print fruits using for loop
        for (int i = 0; i < fruits.length; i++) {
            System.out.println("Fruit " + (i + 1) + ": " + fruits[i]);
        }
    }
}
```

</hint>


```java
// Example: Doubling all values (modifying array)
int[] values = {1, 2, 3, 4, 5};

for (int i = 0; i < values.length; i++) {
    values[i] = values[i] * 2; // Modify the array element
}
```

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

## Exercise 5: Search in Array

Write a Java program that searches for a specific string in an array and prints its index if found. Use the array: {"apple", "banana", "cherry", "date", "elderberry", "fig", "grape", "honeydew", "kiwi"}. Let the user input the string to search for and print whether the string was found or not. If found, also print the index.

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

## Exercise 6: Count Elements with Condition

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

## Exercise 7: Double Array Values

Write a Java program that doubles each element in an array of five integers and then prints out the modified array. Use the array: {5, 10, 15, 20, 25}.

### Example Output:
```
Original array: 5 10 15 20 25
Doubled array: 10 20 30 40 50
```

<hint title="Hint 1">

Use a for loop to iterate through the array and multiply each element by 2. Assign this new value back to the array at the same index.Then use another loop (or the same loop) to print all the elements.

</hint>

<hint title="Solution">

```java
public class DoubleArray {
    public static void main(String[] args) {
        int[] numbers = {5, 10, 15, 20, 25};

        // Print original array
        System.out.print("Original array: ");
        for (int i = 0; i < numbers.length; i++) {
            System.out.print(numbers[i] + " ");
        }
        System.out.println();

        // Double each element
        for (int i = 0; i < numbers.length; i++) {
            numbers[i] = numbers[i] * 2;
        }

        // Print doubled array
        System.out.print("Doubled array: ");
        for (int i = 0; i < numbers.length; i++) {
            System.out.print(numbers[i] + " ");
        }
        System.out.println();
    }
}
```

</hint>

## Exercise 8: String Array Information

Write a Java program that creates an array of fruit names and prints information about each string, including its length and first character. Use the array: {"apple", "banana", "cherry", "date", "elderberry"}.

### Example Output:
```
Fruit information:
apple - Length: 5, First character: a
banana - Length: 6, First character: b
cherry - Length: 6, First character: c
date - Length: 4, First character: d
elderberry - Length: 10, First character: e
```

<hint title="Hint 1">

Use a for loop to iterate through the string array. For each string, use the .length() method to get its length and .charAt(0) to get the first character.

</hint>

<hint title="Solution">

```java
public class StringArrayInfo {
    public static void main(String[] args) {
        String[] fruits = {"apple", "banana", "cherry", "date", "elderberry"};

        System.out.println("Fruit information:");
        for (int i = 0; i < fruits.length; i++) {
            String fruit = fruits[i];
            int length = fruit.length();
            char firstChar = fruit.charAt(0);
            
            System.out.println(fruit + " - Length: " + length + ", First character: " + firstChar);
        }
    }
}
```

</hint>

## Exercise 9: Format Fruit Array to String

Write a Java program that takes an array of fruit names and formats them into a single string where each fruit name is capitalized and separated by periods. Use the array: {"apple", "banana", "cherry", "date", "elderberry"}.

### Example Output:
```
Formatted fruits: Apple. Banana. Cherry. Date. Elderberry.
```

<hint title="Hint - upper case">

Capitalize the first letter using .substring() and .toUpperCase().

</hint>

<hint title="Hint - string concatenation">

You can concatenate strings using the `+=` operator. Remember to add a period and space after each fruit.

```java
String formattedString = "";
String a = "a";
String b = "b";
formattedString += a + ". ";
formattedString += b + ". ";
// formattedString now contains "a. b. "
```

</hint>


<hint title="Solution">

```java
public class FormatFruits {
    public static void main(String[] args) {
        String[] fruits = {"apple", "banana", "cherry", "date", "elderberry"};
        String formattedString = "";

        for (int i = 0; i < fruits.length; i++) {
            String fruit = fruits[i];
            // Capitalize first letter and add the rest
            String capitalizedFruit = fruit.substring(0, 1).toUpperCase() + fruit.substring(1);
            
            formattedString += capitalizedFruit;
            
            // Add period and space after each fruit
            if (i < fruits.length - 1) {
                formattedString += ". ";
            } else {
                formattedString += ".";
            }
        }

        System.out.println("Formatted fruits: " + formattedString);
    }
}
```

</hint>
