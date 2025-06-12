# Exercises

### Exercise: Simple Calculator
Write a program that acts as a simple calculator. The program should:
1. Ask the user to enter two numbers.
2. Ask the user to enter a math operator (`+`, `-`, `*`, `/`).
3. Perform the operation and print the result.

Example Output:
```
Enter the first number:
10
Enter the second number:
5
Enter an operator (+, -, *, /):
+
The result is: 15
```

<hint title="Solution">

```java
import java.util.Scanner;

public class SimpleCalculator {
    public static void main(String[] args) {
        Scanner scanner = new Scanner(System.in);

        System.out.print("Enter the first number: ");
        double num1 = scanner.nextDouble();

        System.out.print("Enter the second number: ");
        double num2 = scanner.nextDouble();

        System.out.print("Enter an operator (+, -, *, /): ");
        char operator = scanner.next().charAt(0);

        double result;

        if (operator == '+') {
            result = num1 + num2;
        } else if (operator == '-') {
            result = num1 - num2;
        } else if (operator == '*') {
            result = num1 * num2;
        } else if (operator == '/') {
            result = num1 / num2;
        } 

        System.out.println("The result is: " + result);
    }
}
```

</hint>

### Exercise: Handle errors

In the previous exercise, what happens if the user inputs an invalid operator?\
What happens if the user tries to divide by zero?

Expand your program to handle these cases, by printing an error message if the operator is invalid or if the user tries to divide by zero.




<hint title="Hint 1">

You can terminate (exit) a method early using the `return` keyword. This is useful for stopping execution when an error occurs or when a specific condition is met.

### Example:

```java
public class EarlyReturnExample {
    public static void main(String[] args) {
        int number = -1;

        if (number < 0) {
            System.out.println("Error: Number cannot be negative.");
            return; // Exit the method early
        }

        System.out.println("The number is: " + number);
    }
}

```

In this example, the program exits early if the number is negative, skipping the rest of the method.

</hint>