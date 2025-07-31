# Exercises - round 2

## Exercise 1: Array Information Display

Write a Java program that creates three different arrays and displays information about each one:

1. Create an integer array of size 7
2. Create a String array with the values: {"Monday", "Tuesday", "Wednesday"}
3. Create a double array of size 4

For each array, print:
- The array's length
- The first element (index 0)
- The last element (using the length property to calculate the correct index)

### Example Output:
```
Integer array:
- Length: 7
- First element: 0
- Last element: 0

String array:
- Length: 3
- First element: Monday
- Last element: Wednesday

Double array:
- Length: 4
- First element: 0.0
- Last element: 0.0
```

<hint title="Hint 1">

To access the last element safely, use the index `arrayName.length - 1`. Remember that array indices start at 0, so the last valid index is always one less than the length.

</hint>

<hint title="Solution">

```java
public class ArrayInformation {
    public static void main(String[] args) {
        // Create three different arrays
        int[] numbers = new int[7];
        String[] days = {"Monday", "Tuesday", "Wednesday"};
        double[] values = new double[4];
        
        // Display information about integer array
        System.out.println("Integer array:");
        System.out.println("- Length: " + numbers.length);
        System.out.println("- First element: " + numbers[0]);
        System.out.println("- Last element: " + numbers[numbers.length - 1]);
        System.out.println();
        
        // Display information about String array
        System.out.println("String array:");
        System.out.println("- Length: " + days.length);
        System.out.println("- First element: " + days[0]);
        System.out.println("- Last element: " + days[days.length - 1]);
        System.out.println();
        
        // Display information about double array
        System.out.println("Double array:");
        System.out.println("- Length: " + values.length);
        System.out.println("- First element: " + values[0]);
        System.out.println("- Last element: " + values[values.length - 1]);
    }
}
```

</hint>

## Exercise 2: Safe Array Access

Write a program that creates an array of integers with the values {10, 20, 30, 40, 50}. Then demonstrate "safe array access" (using length, instead of explicit indices) by:

1. Printing the array's length
2. Accessing and printing elements at specific positions (0, 2, and the last position)
3. Showing what the last valid index is
4. Attempting to access an element at position equal to the array's length (this should cause an error)

### Example Output:
```
Array length: 5
Element at index 0: 10
Element at index 2: 30
Last valid index: 4
Element at last valid index: 50
Attempting to access index 5...
Exception in thread "main" java.lang.ArrayIndexOutOfBoundsException: Index 5 out of bounds for length 5
```

<hint title="Hint 1">

The last valid index is always `length - 1`. Trying to access an index equal to the length will throw an `ArrayIndexOutOfBoundsException`.

</hint>

<hint title="Hint 2">

You can demonstrate the exception by including the problematic line in your code. The program will crash when it tries to execute that line, showing the error message.

</hint>

<hint title="Solution">

```java
public class SafeArrayAccess {
    public static void main(String[] args) {
        // Create an array with predefined values
        int[] numbers = {10, 20, 30, 40, 50};
        
        // Print array information
        System.out.println("Array length: " + numbers.length);
        
        // Safe array access
        System.out.println("Element at index 0: " + numbers[0]);
        System.out.println("Element at index 2: " + numbers[2]);
        
        // Show last valid index
        int lastValidIndex = numbers.length - 1;
        System.out.println("Last valid index: " + lastValidIndex);
        System.out.println("Element at last valid index: " + numbers[lastValidIndex]);
        
        // Attempt unsafe access (this will cause an exception)
        System.out.println("Attempting to access index " + numbers.length + "...");
        System.out.println("Element at index " + numbers.length + ": " + numbers[numbers.length]);
        // The line above will throw ArrayIndexOutOfBoundsException
    }
}
```

</hint>

Understanding array length is fundamental for safe and effective array manipulation in Java. Always remember that the length property helps you avoid index-related errors and write more robust code.
