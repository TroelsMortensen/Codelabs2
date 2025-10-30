# Try-Catch Blocks

First, something important:

> Don't leave your catch blocks empty. Never. Ever. Please.

Now that you understand what exceptions are (right? You do understand, RIGHT?) and how to read stack traces, let's learn how to handle them using **try-catch blocks**. This is the fundamental mechanism for exception handling in Java.

## Basic Syntax

```java
try {
    // Code that might throw an exception
} catch (ExceptionType e) {
    // Code to handle the exception
}
```

## How Try-Catch Works

1. **Try block**: Contains code that might throw an exception, between the braces `{}`
2. **Catch block**: Contains code that handles the exception if it occurs, between the braces `{}`
3. **Exception object**: The caught exception is available as a variable in the catch block, in the above example, that variable is called `e`. You can give it any name you want, but `e` is a common convention.

## Simple Example

Let's start with a basic example. Below we declare a variable `name` and set it to `null`, line 4.\
Then, we try to call the `length` method on it, line 5. This will throw a `NullPointerException`. Because there is no String object to call the method on. The variable was assigned `null`, and you cannot call a method on a `null` object.\
When an exception occurs, the program execution jumps to the catch block, lines 7-9. That means the print out in line 6 is _skipped_. All the code in the try-block, _after_ the exception occurred, is skipped.

All the rest of the try-block is skipped, execution continues in the catch block, and then the program execution continues after the try-catch block.

```java
public class TryCatchDemo {
    public static void main(String[] args) {
        try {
            String name = null;
            int length = name.length();                 // This will throw NullPointerException
            System.out.println("Length: " + length);    // This line is skipped
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
3. **Catch block executes**: The exception is caught and "handled", by just printing something out, but at least the program does not crash
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

In the below example, the user is asked to enter their age, as a number. What if the user types a letter?\
We put the code that may throw an exception, inside the try-block, i.e. the `nextInt()` method, and the code that handles the exception, inside the catch block.

We also have a print out in the try-block, because this should only be printed if the input is valid. If an exception occurs, the program execution jumps to the catch block, and the print out in the try-block is skipped.

```java{10}
import java.util.Scanner;

public class SafeInputDemo {
    public static void main(String[] args) {
        Scanner scanner = new Scanner(System.in);

        System.out.print("Enter your age: ");

        try {
            int age = scanner.nextInt();
            System.out.println("You are " + age + " years old.");
        } catch (InputMismatchException e) {
            System.out.println("You did not enter a valid number for your age! ");
        }
        
        System.out.println("Thank you for using our program!");
        scanner.close();
    }
}
```


## The Exception Object

The exception object (`e` in our examples) contains useful information:

```java{4}
try {
    String text = "abc";
    int number = Integer.parseInt(text); // Throws NumberFormatException
} catch (NumberFormatException e) {
    System.out.println("Exception type: " + e.getClass().getSimpleName());
    System.out.println("Exception message: " + e.getMessage());
    System.out.println("Full exception: " + e);
}
```

The exception object exposes several methods, which can be used to get information about the exception.

**Output:**
```
Exception type: NumberFormatException
Exception message: For input string: "abc"
Full exception: java.lang.NumberFormatException: For input string: "abc"
```

## Common Exception Object Methods

### `getMessage()`

Returns a detailed message about the exception. This is often somewhat user friendly, and is a good place to start, when trying to give feedback to the user.

```java
catch (Exception e) {
    System.out.println("Error: " + e.getMessage());
}
```

### `printStackTrace()`

Prints the full stack trace. This should _always_ (nearly) be printed, as it is otherwise _very_ difficult to find the problem.

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

## Recap

### 1. **Try-catch prevents crashes**
Without try-catch, exceptions cause your program to terminate immediately.

### 2. **Only catch what you can handle**
Don't catch exceptions just to ignore them - always provide meaningful handling. For now, this usually means printing an error to the console. Later this will often include showing a message to the user.
_Sometimes_, you can try something else, in the case of a caught exception.

### 3. **Be specific with exception types**
Catch specific exceptions rather than the general `Exception` class when possible. We will see this on the next page.

### 4. **Provide helpful error messages**
Give users clear information about what went wrong and how to fix it. Consider if the user should be allowed to try again.

### 5. **Program continues after catch**
After an exception is caught and handled, execution continues normally.

> Don't leave your catch blocks empty
