# Exercise - Calculator

Build a robust calculator that handles various mathematical operations and gracefully handles errors that might occur during calculations.

## Requirements

Create a `Calculator` class with the following methods:

### 1. Basic Arithmetic Operations
- `add(double a, double b)` - Addition
- `subtract(double a, double b)` - Subtraction  
- `multiply(double a, double b)` - Multiplication
- `divide(double a, double b)` - Division

### 2. Advanced Operations
- `power(double base, double exponent)` - Exponentiation
- `squareRoot(double number)` - Square root
- `factorial(int n)` - Factorial

### 3. Exception Handling
Handle the following exceptions appropriately:
- **Division by zero** - `ArithmeticException`
- **Invalid input for factorial** - `IllegalArgumentException`
- **Negative numbers for square root** - `IllegalArgumentException`
- **Invalid exponent for power** - `IllegalArgumentException`

## Implementation Guidelines

### Calculator Class Structure
```java
public class Calculator {
    // Basic arithmetic methods
    public double add(double a, double b) { /* implementation */ }
    public double subtract(double a, double b) { /* implementation */ }
    public double multiply(double a, double b) { /* implementation */ }
    public double divide(double a, double b) { /* implementation */ }
    
    // Advanced operations
    public double power(double base, double exponent) { /* implementation */ }
    public double squareRoot(double number) { /* implementation */ }
    public long factorial(int n) { /* implementation */ }
}
```

### Exception Handling Requirements

1. **Division by Zero**: Throw `ArithmeticException` with a meaningful message
2. **Factorial**: Throw `IllegalArgumentException` for negative numbers or numbers > 20
3. **Square Root**: Throw `IllegalArgumentException` for negative numbers
4. **Power**: Throw `IllegalArgumentException` for invalid combinations (e.g., 0^0)

### Method Implementations

#### Basic Operations
```java
public double divide(double a, double b) {
    if (b == 0) {
        throw new ArithmeticException("Cannot divide by zero");
    }
    return a / b;
}
```

#### Advanced Operations
```java
public double squareRoot(double number) {
    if (number < 0) {
        throw new IllegalArgumentException("Cannot calculate square root of negative number: " + number);
    }
    return Math.sqrt(number);
}

public long factorial(int n) {
    if (n < 0) {
        throw new IllegalArgumentException("Factorial is not defined for negative numbers: " + n);
    }
    if (n > 20) {
        throw new IllegalArgumentException("Factorial result too large for int: " + n);
    }
    
    long result = 1;
    for (int i = 2; i <= n; i++) {
        result *= i;
    }
    return result;
}
```

## Test Class

Create a `CalculatorTester` class with a main method that demonstrates all operations and exception handling:

```java
public class CalculatorTester {
    public static void main(String[] args) {
        Calculator calc = new Calculator();
        
        // Test basic operations
        testBasicOperations(calc);
        
        // Test advanced operations
        testAdvancedOperations(calc);
        
        // Test exception handling
        testExceptionHandling(calc);
    }
    
    public static void testBasicOperations(Calculator calc) {
        System.out.println("=== Testing Basic Operations ===");
        
        try {
            System.out.println("10 + 5 = " + calc.add(10, 5));
            System.out.println("10 - 5 = " + calc.subtract(10, 5));
            System.out.println("10 * 5 = " + calc.multiply(10, 5));
            System.out.println("10 / 5 = " + calc.divide(10, 5));
        } catch (Exception e) {
            System.out.println("Unexpected error in basic operations: " + e.getMessage());
        }
    }
    
    public static void testAdvancedOperations(Calculator calc) {
        System.out.println("\n=== Testing Advanced Operations ===");
        
        try {
            System.out.println("2^3 = " + calc.power(2, 3));
            System.out.println("√16 = " + calc.squareRoot(16));
            System.out.println("5! = " + calc.factorial(5));
        } catch (Exception e) {
            System.out.println("Unexpected error in advanced operations: " + e.getMessage());
        }
    }
    
    public static void testExceptionHandling(Calculator calc) {
        System.out.println("\n=== Testing Exception Handling ===");
        
        // Test division by zero
        try {
            System.out.println("10 / 0 = " + calc.divide(10, 0));
        } catch (ArithmeticException e) {
            System.out.println("Caught division by zero: " + e.getMessage());
        }
        
        // Test negative factorial
        try {
            System.out.println("(-5)! = " + calc.factorial(-5));
        } catch (IllegalArgumentException e) {
            System.out.println("Caught invalid factorial: " + e.getMessage());
        }
        
        // Test negative square root
        try {
            System.out.println("√(-4) = " + calc.squareRoot(-4));
        } catch (IllegalArgumentException e) {
            System.out.println("Caught invalid square root: " + e.getMessage());
        }
        
        // Test large factorial
        try {
            System.out.println("25! = " + calc.factorial(25));
        } catch (IllegalArgumentException e) {
            System.out.println("Caught large factorial: " + e.getMessage());
        }
    }
}
```

## Expected Output

```
=== Testing Basic Operations ===
10 + 5 = 15.0
10 - 5 = 5.0
10 * 5 = 50.0
10 / 5 = 2.0

=== Testing Advanced Operations ===
2^3 = 8.0
√16 = 4.0
5! = 120

=== Testing Exception Handling ===
Caught division by zero: Cannot divide by zero
Caught invalid factorial: Factorial is not defined for negative numbers: -5
Caught invalid square root: Cannot calculate square root of negative number: -4.0
Caught large factorial: Factorial result too large for int: 25
```

## Bonus Challenges

### 1. Interactive Calculator
Create an interactive version that prompts the user for input and handles `InputMismatchException`:

```java
import java.util.Scanner;
import java.util.InputMismatchException;

public class InteractiveCalculator {
    public static void main(String[] args) {
        Calculator calc = new Calculator();
        Scanner scanner = new Scanner(System.in);
        
        while (true) {
            try {
                System.out.print("Enter operation (+, -, *, /, ^, √, !) or 'quit': ");
                String operation = scanner.next();
                
                if (operation.equals("quit")) {
                    break;
                }
                
                // Get operands and perform operation
                // Handle InputMismatchException for invalid numbers
                
            } catch (InputMismatchException e) {
                System.out.println("Please enter valid numbers.");
                scanner.nextLine(); // Clear invalid input
            } catch (Exception e) {
                System.out.println("Error: " + e.getMessage());
            }
        }
        
        scanner.close();
    }
}
```

### 2. Custom Calculator Exceptions
Create custom exception classes for calculator-specific errors:

```java
class DivisionByZeroException extends Exception {
    public DivisionByZeroException(String message) {
        super(message);
    }
}

class InvalidFactorialException extends Exception {
    private int invalidValue;
    
    public InvalidFactorialException(String message, int invalidValue) {
        super(message);
        this.invalidValue = invalidValue;
    }
    
    public int getInvalidValue() {
        return invalidValue;
    }
}
```

### 3. Calculator History
Add functionality to keep a history of calculations and handle potential errors in history management.

## Learning Objectives

After completing this exercise, you should be able to:

1. **Handle multiple types of exceptions** in a single application
2. **Throw appropriate exceptions** for different error conditions
3. **Provide meaningful error messages** to help users understand what went wrong
4. **Use try-catch blocks** effectively for error handling
5. **Test exception handling** thoroughly
6. **Design robust methods** that validate input and handle edge cases
7. **Create user-friendly error handling** for interactive applications

## Tips

- **Test edge cases**: Try boundary values like 0, negative numbers, and very large numbers
- **Validate input early**: Check for invalid input before performing calculations
- **Provide helpful error messages**: Include the actual values that caused the error
- **Use appropriate exception types**: Choose the most specific exception type for each error condition
- **Handle user input errors**: Use try-catch for `InputMismatchException` in interactive versions

Good luck with your calculator implementation!
