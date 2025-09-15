# Exercises - round 4

## Exercise 1: Double Array Values

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

## Exercise 2: String Array Information

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

## Exercise 3: Format Fruit Array to String

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