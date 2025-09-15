# Exercises - round 4

These exercises are extra, just more practice in various aspects of arrays.

## Exercise 1: Search in Array

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


## Exercise 2: Count Elements with Condition

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


## Exercise 3: Double Array Values

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

## Exercise 4: String Array Information

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

## Exercise 5: Format Fruit Array to String

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

