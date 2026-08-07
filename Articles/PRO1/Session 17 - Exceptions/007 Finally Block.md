# Finally Block

The `finally` block is a special part of try-catch that **always executes**, regardless of whether an exception occurs or not. It's perfect for cleanup operations like closing files, releasing resources, or any code that must run no matter what happens.

## Basic Syntax

```java
try {
    // Code that might throw an exception
} catch (ExceptionType e) {
    // Handle the exception
} finally {
    // This code ALWAYS executes
}
```

## Simple Example

Let's see the `finally` block in action. This snippet will divide 10 by 2, and print the result. There are no problems, no exceptions thrown, and the `finally` block is executed.

```java
public class FinallyDemo {
    public static void main(String[] args) {
        try {
            System.out.println("Inside try block");
            int result = 10 / 2;
            System.out.println("Result: " + result);
        } catch (ArithmeticException e) {
            System.out.println("Caught exception: " + e.getMessage());
        } finally {
            System.out.println("Finally block always executes!");
        }
        
        System.out.println("Program continues...");
    }
}
```

**Output:**
```
Inside try block
Result: 5
Finally block always executes!
Program continues...
```

## Finally with Exception

Now let's see what happens when an exception occurs. This snippet will divide 10 by 0, and print the result. There is an exception thrown, and the `finally` block is executed.

```java
public class FinallyWithException {
    public static void main(String[] args) {
        try {
            System.out.println("Inside try block");
            int result = 10 / 0; // This will cause an exception
            System.out.println("Result: " + result);
        } catch (ArithmeticException e) {
            System.out.println("Caught exception: " + e.getMessage());
        } finally {
            System.out.println("Finally block still executes!");
        }
        
        System.out.println("Program continues...");
    }
}
```

**Output:**
```
Inside try block
Caught exception: / by zero
Finally block still executes!
Program continues...
```

## Finally with Uncaught Exception

Even if an exception is not caught, the `finally` block still executes:

```java
public class FinallyWithUncaughtException {
    public static void main(String[] args) {
        try {
            System.out.println("Inside try block");
            int result = 10 / 0; // This will cause an exception
            System.out.println("Result: " + result);
        } finally {
            System.out.println("Finally block executes even with uncaught exception!");
        }
        
        System.out.println("This line will NOT execute because exception wasn't caught");
    }
}
```

**Output:**
```
Inside try block
Finally block executes even with uncaught exception!
Exception in thread "main" java.lang.ArithmeticException: / by zero
    at FinallyWithUncaughtException.main(FinallyWithUncaughtException.java:4)
```

## Real-World Example: I/O Operations

The most common use of `finally` is for resource cleanup. Ideally, the Scanner object should actually be closed, when we are done with it.
We have not really done that in our small programs, as it is cleared when the program ends anyway.

But, below, the Scanner object is closed in the `finally` block, whether an exception occurs or not.

```java
import java.io.File;
import java.io.FileNotFoundException;
import java.util.InputMismatchException;
import java.util.Scanner;

public class FileReaderWithFinally {
    public static void main(String[] args) {
        Scanner scanner = null;
        
        try {
            scanner = new Scanner(System.in);
            
            int number = scanner.nextInt();
            System.out.println("You entered: " + number);
            
        } catch (InputMismatchException e) {
            System.out.println("Invalid input: " + e.getMessage());
        } finally {
            // Always close the scanner, even if an exception occurs
            if (scanner != null) {
                scanner.close();
                System.out.println("Scanner closed.");
            }
        }
        
        System.out.println("Program continues...");
    }
}
```

Okay, but... we could just close the scanner after the try-block, and then the `finally` block would not be needed. So, what's the point of the `finally` block?
Well, there may be cases, though I don't have that many great examples. But, look at the next example.

## Try-Finally Without Catch

You can use `try-finally` without a `catch` block. When you run this, you will see that the `finally` block is executed, but the exception is not caught, and the program crashes. So, there is something in the ordering of when things happens:
1. The exception is thrown
2. The `finally` block is executed
3. The exception "escapes" the try-block, and the program crashes

```java
public class TryFinallyOnly {
    public static void main(String[] args) {
        try {
            System.out.println("Inside try block");
            int result = 10 / 0; // This will cause an exception
        } finally {
            System.out.println("Finally block executes");
        }
        
        System.out.println("This line will NOT execute");
    }
}
```

This means, we could do some clean up in one place, e.g. close a scanner, and then actually catch the exception in another place, e.g. print an error message to the user.

**Output:**
```
Inside try block
Finally block executes
Exception in thread "main" java.lang.ArithmeticException: / by zero
    at TryFinallyOnly.main(TryFinallyOnly.java:4)
```


