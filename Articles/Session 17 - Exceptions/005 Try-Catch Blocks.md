# Try-Catch Blocks

Now that you understand what exceptions are and how to read stack traces, let's learn how to handle them using **try-catch blocks**. This is the fundamental mechanism for exception handling in Java.

## Basic Syntax

```java
try {
    // Code that might throw an exception
} catch (ExceptionType e) {
    // Code to handle the exception
}
```

## How Try-Catch Works

1. **Try block**: Contains code that might throw an exception
2. **Catch block**: Contains code that handles the exception if it occurs
3. **Exception object**: The caught exception is available as a variable in the catch block

## Simple Example

Let's start with a basic example:

```java
public class TryCatchDemo {
    public static void main(String[] args) {
        try {
            String name = null;
            int length = name.length(); // This will throw NullPointerException
            System.out.println("Length: " + length);
        } catch (NullPointerException e) {
            System.out.println("Oops! Something was null: " + e.getMessage());
        }
        
        System.out.println("Program continues after the exception was handled!");
    }
}
```

**Output:**
```
Oops! Something was null: null
Program continues after the exception was handled!
```

## What Happens Step by Step

1. **Try block executes**: Code runs normally until an exception occurs
2. **Exception thrown**: When `name.length()` is called, a `NullPointerException` is thrown
3. **Catch block executes**: The exception is caught and handled
4. **Program continues**: Execution continues after the try-catch block

## Without Try-Catch (Program Crashes)

```java
public class WithoutTryCatch {
    public static void main(String[] args) {
        String name = null;
        int length = name.length(); // CRASH!
        System.out.println("Length: " + length); // This line never executes
        System.out.println("Program continues..."); // This line never executes
    }
}
```

**Output:**
```
Exception in thread "main" java.lang.NullPointerException
    at WithoutTryCatch.main(WithoutTryCatch.java:3)
```

## Practical Example: User Input

Let's handle the `InputMismatchException` we saw earlier:

```java
import java.util.Scanner;

public class SafeInputDemo {
    public static void main(String[] args) {
        Scanner scanner = new Scanner(System.in);
        
        try {
            System.out.print("Enter your age: ");
            int age = scanner.nextInt();
            System.out.println("You are " + age + " years old.");
        } catch (InputMismatchException e) {
            System.out.println("Please enter a valid number for your age!");
        }
        
        System.out.println("Thank you for using our program!");
        scanner.close();
    }
}
```

## Array Access Example

```java
public class SafeArrayAccess {
    public static void main(String[] args) {
        int[] numbers = {10, 20, 30};
        
        try {
            int index = 5; // This index doesn't exist
            int value = numbers[index];
            System.out.println("Value at index " + index + ": " + value);
        } catch (ArrayIndexOutOfBoundsException e) {
            System.out.println("Index is out of bounds! Array has " + numbers.length + " elements.");
        }
        
        System.out.println("Program continues normally.");
    }
}
```

## Division by Zero Example

```java
public class SafeDivision {
    public static void main(String[] args) {
        int a = 10;
        int b = 0;
        
        try {
            int result = a / b;
            System.out.println("Result: " + result);
        } catch (ArithmeticException e) {
            System.out.println("Cannot divide by zero!");
        }
        
        System.out.println("Calculation complete.");
    }
}
```

## The Exception Object

The exception object (`e` in our examples) contains useful information:

```java
try {
    String text = "abc";
    int number = Integer.parseInt(text); // Throws NumberFormatException
} catch (NumberFormatException e) {
    System.out.println("Exception type: " + e.getClass().getSimpleName());
    System.out.println("Exception message: " + e.getMessage());
    System.out.println("Full exception: " + e);
}
```

**Output:**
```
Exception type: NumberFormatException
Exception message: For input string: "abc"
Full exception: java.lang.NumberFormatException: For input string: "abc"
```

## Common Exception Object Methods

### `getMessage()`
Returns a detailed message about the exception:
```java
catch (Exception e) {
    System.out.println("Error: " + e.getMessage());
}
```

### `printStackTrace()`
Prints the full stack trace:
```java
catch (Exception e) {
    System.out.println("Something went wrong:");
    e.printStackTrace();
}
```

### `getClass().getSimpleName()`
Gets the simple name of the exception class:
```java
catch (Exception e) {
    System.out.println("Exception type: " + e.getClass().getSimpleName());
}
```

## Real-World Example: File Reading

```java
import java.io.File;
import java.io.FileNotFoundException;
import java.util.Scanner;

public class FileReader {
    public static void main(String[] args) {
        try {
            File file = new File("data.txt");
            Scanner scanner = new Scanner(file);
            
            while (scanner.hasNextLine()) {
                String line = scanner.nextLine();
                System.out.println(line);
            }
            
            scanner.close();
            System.out.println("File read successfully!");
            
        } catch (FileNotFoundException e) {
            System.out.println("File not found: " + e.getMessage());
            System.out.println("Please make sure 'data.txt' exists in the current directory.");
        }
    }
}
```

## Key Points to Remember

### 1. **Try-catch prevents crashes**
Without try-catch, exceptions cause your program to terminate immediately.

### 2. **Only catch what you can handle**
Don't catch exceptions just to ignore them - always provide meaningful handling.

### 3. **Be specific with exception types**
Catch specific exceptions rather than the general `Exception` class when possible.

### 4. **Provide helpful error messages**
Give users clear information about what went wrong and how to fix it.

### 5. **Program continues after catch**
After an exception is caught and handled, execution continues normally.

## What's Next?

Now that you understand basic try-catch blocks, let's learn how to handle multiple different types of exceptions in the same try block!
