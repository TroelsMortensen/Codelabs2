# Multiple Catch Blocks

Often, a single try block can throw different types of exceptions. Java allows you to have multiple catch blocks to handle each type of exception appropriately.

## Basic Syntax

```java
try {
    // Code that might throw different types of exceptions
} catch (ExceptionType1 e1) {
    // Handle ExceptionType1
} catch (ExceptionType2 e2) {
    // Handle ExceptionType2
} catch (ExceptionType3 e3) {
    // Handle ExceptionType3
}
```

## Simple Example

Let's create a program that can throw multiple different exceptions:

```java
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
        scanner.close();
    }
}
```

## How Multiple Catch Blocks Work

1. **Try block executes**: Code runs until an exception occurs
2. **First matching catch block**: Java looks for the first catch block that matches the exception type
3. **Only one catch block executes**: Once an exception is caught, no other catch blocks are checked
4. **Program continues**: After the catch block executes, the program continues

## Exception Hierarchy and Catch Order

**Important**: Catch blocks are checked in order, and more specific exceptions must come before more general ones.

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

### Incorrect Order (General to Specific)
```java
try {
    // Some code
} catch (Exception e) {
    // This will catch ALL exceptions, including FileNotFoundException!
} catch (FileNotFoundException e) {
    // This will NEVER be reached!
}
```

**Why this is wrong**: `FileNotFoundException` is a subclass of `Exception`, so the first catch block will always catch it, and the second catch block will never be reached.

## Real-World Example: File Processing

```java
import java.io.File;
import java.io.FileNotFoundException;
import java.util.Scanner;

public class FileProcessor {
    public static void main(String[] args) {
        try {
            File file = new File("data.txt");
            Scanner scanner = new Scanner(file);
            
            while (scanner.hasNextLine()) {
                String line = scanner.nextLine();
                int number = Integer.parseInt(line);
                System.out.println("Number: " + number);
            }
            
            scanner.close();
            
        } catch (FileNotFoundException e) {
            System.out.println("File 'data.txt' not found. Please create the file first.");
        } catch (NumberFormatException e) {
            System.out.println("Invalid number format in file: " + e.getMessage());
        } catch (Exception e) {
            System.out.println("An unexpected error occurred: " + e.getMessage());
        }
    }
}
```

## Array and String Processing Example

```java
public class DataProcessor {
    public static void main(String[] args) {
        String[] data = {"10", "20", "abc", "30"};
        
        for (int i = 0; i <= data.length; i++) { // Intentionally go one too far
            try {
                String text = data[i];
                int number = Integer.parseInt(text);
                System.out.println("Processed: " + number);
                
            } catch (ArrayIndexOutOfBoundsException e) {
                System.out.println("Reached end of array at index " + i);
                break; // Exit the loop
            } catch (NumberFormatException e) {
                System.out.println("Invalid number format: " + data[i]);
                // Continue processing other elements
            }
        }
        
        System.out.println("Processing complete.");
    }
}
```

## Calculator Example

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

## Common Patterns

### 1. **Input Validation**
```java
try {
    int age = scanner.nextInt();
    // Process age
} catch (InputMismatchException e) {
    System.out.println("Please enter a valid number for age.");
} catch (Exception e) {
    System.out.println("An unexpected error occurred.");
}
```

### 2. **File Operations**
```java
try {
    File file = new File(filename);
    Scanner scanner = new Scanner(file);
    // Process file
} catch (FileNotFoundException e) {
    System.out.println("File not found: " + filename);
} catch (IOException e) {
    System.out.println("Error reading file: " + e.getMessage());
}
```

### 3. **Array Operations**
```java
try {
    int value = array[index];
    // Process value
} catch (ArrayIndexOutOfBoundsException e) {
    System.out.println("Index " + index + " is out of bounds.");
} catch (NullPointerException e) {
    System.out.println("Array is null.");
}
```

## Best Practices

### 1. **Order Matters**
Always put more specific exceptions before more general ones.

### 2. **Be Specific**
Catch specific exceptions when you know what might go wrong.

### 3. **Provide Meaningful Messages**
Give users clear information about what went wrong and how to fix it.

### 4. **Don't Catch What You Can't Handle**
If you can't meaningfully handle an exception, let it propagate up.

### 5. **Use Finally for Cleanup**
We'll learn about the `finally` block next, which is perfect for cleanup operations.

## What's Next?

Now that you can handle multiple types of exceptions, let's learn about the `finally` block, which allows you to execute code regardless of whether an exception occurs!
