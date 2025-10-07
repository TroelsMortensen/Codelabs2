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

Let's see the `finally` block in action:

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

Now let's see what happens when an exception occurs:

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

## Real-World Example: File Operations

The most common use of `finally` is for resource cleanup:

```java
import java.io.File;
import java.io.FileNotFoundException;
import java.util.Scanner;

public class FileReaderWithFinally {
    public static void main(String[] args) {
        Scanner scanner = null;
        
        try {
            File file = new File("data.txt");
            scanner = new Scanner(file);
            
            while (scanner.hasNextLine()) {
                String line = scanner.nextLine();
                System.out.println(line);
            }
            
        } catch (FileNotFoundException e) {
            System.out.println("File not found: " + e.getMessage());
        } finally {
            // Always close the scanner, even if an exception occurs
            if (scanner != null) {
                scanner.close();
                System.out.println("Scanner closed successfully.");
            }
        }
        
        System.out.println("Program continues...");
    }
}
```

## Database Connection Example

```java
public class DatabaseExample {
    public static void main(String[] args) {
        // Simulating a database connection
        String connection = null;
        
        try {
            System.out.println("Connecting to database...");
            connection = "DatabaseConnection"; // Simulate connection
            System.out.println("Connected successfully!");
            
            // Simulate some database operations
            System.out.println("Performing database operations...");
            // This might throw an exception
            if (Math.random() > 0.5) {
                throw new RuntimeException("Database operation failed!");
            }
            
            System.out.println("Operations completed successfully!");
            
        } catch (RuntimeException e) {
            System.out.println("Database error: " + e.getMessage());
        } finally {
            // Always close the connection
            if (connection != null) {
                System.out.println("Closing database connection...");
                connection = null; // Simulate closing
                System.out.println("Connection closed.");
            }
        }
        
        System.out.println("Program continues...");
    }
}
```

## Multiple Scenarios Example

Let's see how `finally` behaves in different scenarios:

```java
public class FinallyScenarios {
    public static void main(String[] args) {
        System.out.println("=== Scenario 1: No Exception ===");
        scenario1();
        
        System.out.println("\n=== Scenario 2: Caught Exception ===");
        scenario2();
        
        System.out.println("\n=== Scenario 3: Uncaught Exception ===");
        try {
            scenario3();
        } catch (RuntimeException e) {
            System.out.println("Caught in main: " + e.getMessage());
        }
    }
    
    public static void scenario1() {
        try {
            System.out.println("  Try block - no exception");
        } finally {
            System.out.println("  Finally block executes");
        }
        System.out.println("  After try-finally");
    }
    
    public static void scenario2() {
        try {
            System.out.println("  Try block - about to throw exception");
            throw new RuntimeException("Test exception");
        } catch (RuntimeException e) {
            System.out.println("  Caught: " + e.getMessage());
        } finally {
            System.out.println("  Finally block executes");
        }
        System.out.println("  After try-catch-finally");
    }
    
    public static void scenario3() {
        try {
            System.out.println("  Try block - about to throw uncaught exception");
            throw new RuntimeException("Uncaught exception");
        } finally {
            System.out.println("  Finally block executes even with uncaught exception");
        }
        System.out.println("  This line will NOT execute");
    }
}
```

## Try-Finally Without Catch

You can use `try-finally` without a `catch` block:

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

**Output:**
```
Inside try block
Finally block executes
Exception in thread "main" java.lang.ArithmeticException: / by zero
    at TryFinallyOnly.main(TryFinallyOnly.java:4)
```

## Common Use Cases for Finally

### 1. **Closing Files**
```java
Scanner scanner = null;
try {
    scanner = new Scanner(new File("data.txt"));
    // Process file
} finally {
    if (scanner != null) {
        scanner.close();
    }
}
```

### 2. **Closing Database Connections**
```java
Connection conn = null;
try {
    conn = DriverManager.getConnection(url);
    // Database operations
} finally {
    if (conn != null) {
        conn.close();
    }
}
```

### 3. **Releasing Locks**
```java
Lock lock = new ReentrantLock();
try {
    lock.lock();
    // Critical section
} finally {
    lock.unlock();
}
```

### 4. **Cleanup Operations**
```java
try {
    // Some operation
} finally {
    // Cleanup temporary files
    // Reset variables
    // Log completion
}
```

## Important Notes

### 1. **Finally Always Executes**
The `finally` block executes in all scenarios:
- When no exception occurs
- When an exception is caught
- When an exception is not caught
- When a `return` statement is in the try block
- When a `return` statement is in the catch block

### 2. **Finally Can't Prevent Exception Propagation**
If an exception is not caught, it will still propagate even after the `finally` block executes.

### 3. **Don't Return from Finally**
Avoid using `return` statements in the `finally` block as it can mask exceptions.

### 4. **Resource Management**
The `finally` block is essential for proper resource management and preventing resource leaks.

## What's Next?

Now that you understand how to catch and handle exceptions with try-catch-finally, let's learn how to throw your own exceptions using the `throw` keyword!
