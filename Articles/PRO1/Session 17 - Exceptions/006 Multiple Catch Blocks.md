# Multiple Catch Blocks

Often, a single try block can throw different types of exceptions. Java allows you to have multiple catch blocks to handle each type of exception appropriately.

Depending on the exception, you may want to handle it differently. Or, maybe all exceptions are handled the same way, which can be simplfied to a single catch block, later.

## Basic Syntax

```java
try {
    // Code that might throw different types of exceptions
} catch (SomeException e1) {
    // Handle SomeException
} catch (AnotherException e2) {
    // Handle AnotherException
} catch (AndThisException e3) {
    // Handle AndThisException
}
```

Maybe you want to show different messages to the user. Maybe some exceptions should be logged to a file. Maybe some exceptions should basically just be ignored. Maybe some can be handled right away, and others should cause a custom RuntimeException to be thrown, to be caught somewhere else.

## Simple Example

Let's create a program that can throw multiple different exceptions. We will use the `Scanner` class to get user input, and the `ArrayIndexOutOfBoundsException` and `ArithmeticException` exceptions.

Notice how the `nextInt()` method can throw an `InputMismatchException`, and the `[]` operator can throw an `ArrayIndexOutOfBoundsException`. Finally, the `/` operator can throw an `ArithmeticException`.

```java{9,12,15,17}
import java.util.Scanner;

public class MultipleExceptionsDemo {
    public static void main(String[] args) {
        Scanner scanner = new Scanner(System.in);
        
        try {
            System.out.print("Enter an array index (0-2): ");
            int index = scanner.nextInt();
            
            int[] numbers = {10, 20, 30};
            int value = numbers[index];
            
            System.out.print("Enter a divisor: ");
            int divisor = scanner.nextInt();
            
            int result = value / divisor;
            System.out.println("Result: " + result);
            
        } catch (InputMismatchException e) {
            System.out.println("Please enter a valid number!");
        } catch (ArrayIndexOutOfBoundsException e) {
            System.out.println("Index is out of bounds! Please enter 0, 1, or 2.");
        } catch (ArithmeticException e) {
            System.out.println("Cannot divide by zero!");
        }
        
        System.out.println("Program continues...");
    }
}
```

## How Multiple Catch Blocks Work

1. **Try block executes**: Code runs until an exception occurs
2. **First matching catch block**: Java looks for the first catch block that matches the exception type
3. **Only one catch block executes**: Once an exception is caught, no other catch blocks are checked
4. **Program continues**: After the catch block executes, the program continues

## Exception Hierarchy and Catch Order

**Important**: Catch blocks are checked in order, from top to bottom, and more specific exceptions must come before more general ones. This is because the first catch block that matches the exception type will be executed, and the rest of the catch blocks will be ignored.\
By specific and general exceptions, I mean inheritance. In the below, `Exception` is a superclass of the other exceptions. If I were to move that catch block (`Exception e`) up to be first, it will catch _all_ exceptions, including `FileNotFoundException`, and the other catch blocks will never be reached.

### Correct Order (Specific to General)
```java
try {
    // Some code
} catch (FileNotFoundException e) {
    // Handle file not found
} catch (IOException e) {
    // Handle other IO exceptions
} catch (Exception e) {
    // Handle any other exception
}
```


## Calculator Example

Consider the use of exceptions below, to handle:
- `InputMismatchException`. This is thrown when the user enters an invalid number.
- `ArithmeticException`. This is thrown when the user tries to divide by zero.
- `IllegalArgumentException`. This is thrown when the user enters an invalid operator.
- `Exception`. This is thrown when an unexpected error occurs, whatever that may be. It's just a catch all, similar to the `default` case in a switch statement.

```java
import java.util.Scanner;

public class Calculator {
    public static void main(String[] args) {
        Scanner scanner = new Scanner(System.in);
        
        try {
            System.out.print("Enter first number: ");
            double num1 = scanner.nextDouble();
            
            System.out.print("Enter operator (+, -, *, /): ");
            String operator = scanner.next();
            
            System.out.print("Enter second number: ");
            double num2 = scanner.nextDouble();
            
            double result = calculate(num1, operator, num2);
            System.out.println("Result: " + result);
            
        } catch (InputMismatchException e) {
            System.out.println("Please enter valid numbers!");
        } catch (ArithmeticException e) {
            System.out.println("Mathematical error: " + e.getMessage());
        } catch (IllegalArgumentException e) {
            System.out.println("Invalid operator: " + e.getMessage());
        } catch (Exception e) {
            System.out.println("An unexpected error occurred: " + e.getMessage());
        }
        
        scanner.close();
    }
    
    public static double calculate(double a, String op, double b) {
        switch (op) {
            case "+": return a + b;
            case "-": return a - b;
            case "*": return a * b;
            case "/": 
                if (b == 0) {
                    throw new ArithmeticException("Division by zero");
                }
                return a / b;
            default:
                throw new IllegalArgumentException("Unknown operator: " + op);
        }
    }
}
```

## Collapse catch blocks

If you find, you have to catch multiple exceptions, but they are handled the same way, you can collapse them into a single catch block. IntelliJ will sometimes suggest this.

```java
try {
    // Some code
} catch (InputMismatchException | ArithmeticException | IllegalArgumentException e) {
    // Handle all three exceptions the same way
}
```

This means "catch either an `InputMismatchException`, an `ArithmeticException`, or an `IllegalArgumentException`, and handle them all the same way".


## Best Practices

### 1. **Order Matters**
Always put more specific exceptions before more general ones.

### 2. **Be Specific**
Catch specific exceptions when you know what might go wrong.

### 3. **Provide Meaningful Messages**
Give users clear information about what went wrong and how to fix it.

### 4. **Don't Catch What You Can't Handle**
If you can't meaningfully handle an exception, let it propagate up (see Exception Propagation page). This can happen in two ways: if it is an unchecked exception, just don't catch it. If it is a checked exception, read about "throws" keyword in a few pages.
