# Exception Propagation

Exception propagation is the process by which exceptions move up through the call stack when they are not caught. Understanding how exceptions propagate is crucial for designing robust error handling in your applications.

## What is Exception Propagation?

When an exception is thrown and not caught in the current method, it automatically propagates (bubbles up) to the calling method. This continues until either:
1. The exception is caught by a try-catch block
2. The exception reaches the `main` method and causes the program to terminate

## Simple Propagation Example

Let's trace how an exception propagates through multiple method calls:

```java
public class PropagationDemo {
    public static void main(String[] args) {
        System.out.println("Starting main method...");
        try {
            methodA();
        } catch (RuntimeException e) {
            System.out.println("Caught in main: " + e.getMessage());
        }
        System.out.println("Main method continues...");
    }
    
    public static void methodA() {
        System.out.println("In methodA");
        methodB();
        System.out.println("methodA continues..."); // This line will NOT execute
    }
    
    public static void methodB() {
        System.out.println("In methodB");
        methodC();
        System.out.println("methodB continues..."); // This line will NOT execute
    }
    
    public static void methodC() {
        System.out.println("In methodC");
        throw new RuntimeException("Error in methodC");
        System.out.println("methodC continues..."); // This line will NOT execute
    }
}
```

**Output:**
```
Starting main method...
In methodA
In methodB
In methodC
Caught in main: Error in methodC
Main method continues...
```

## Propagation with Different Exception Types

```java
public class DifferentExceptionTypes {
    public static void main(String[] args) {
        System.out.println("=== Test 1: RuntimeException ===");
        testRuntimeException();
        
        System.out.println("\n=== Test 2: Checked Exception ===");
        testCheckedException();
    }
    
    public static void testRuntimeException() {
        try {
            methodThatThrowsRuntimeException();
        } catch (RuntimeException e) {
            System.out.println("Caught RuntimeException: " + e.getMessage());
        }
        System.out.println("testRuntimeException continues...");
    }
    
    public static void testCheckedException() {
        try {
            methodThatThrowsCheckedException();
        } catch (Exception e) {
            System.out.println("Caught Exception: " + e.getMessage());
        }
        System.out.println("testCheckedException continues...");
    }
    
    public static void methodThatThrowsRuntimeException() {
        System.out.println("About to throw RuntimeException...");
        throw new RuntimeException("Runtime error occurred");
    }
    
    public static void methodThatThrowsCheckedException() throws Exception {
        System.out.println("About to throw checked Exception...");
        throw new Exception("Checked error occurred");
    }
}
```

## Propagation with `throws` Declaration

When a method declares that it throws an exception, the exception propagates to the caller:

```java
import java.io.File;
import java.io.FileNotFoundException;
import java.util.Scanner;

public class PropagationWithThrows {
    public static void main(String[] args) {
        try {
            readUserFile("data.txt");
        } catch (FileNotFoundException e) {
            System.out.println("File not found in main: " + e.getMessage());
        }
    }
    
    // This method declares that it might throw FileNotFoundException
    public static void readUserFile(String filename) throws FileNotFoundException {
        System.out.println("readUserFile called with: " + filename);
        processFile(filename);
        System.out.println("readUserFile continues..."); // This line will NOT execute
    }
    
    // This method also declares that it might throw FileNotFoundException
    public static void processFile(String filename) throws FileNotFoundException {
        System.out.println("processFile called with: " + filename);
        readFile(filename);
        System.out.println("processFile continues..."); // This line will NOT execute
    }
    
    // This method throws the actual exception
    public static void readFile(String filename) throws FileNotFoundException {
        System.out.println("readFile called with: " + filename);
        File file = new File(filename);
        Scanner scanner = new Scanner(file); // This will throw FileNotFoundException
        scanner.close();
    }
}
```

## Partial Propagation (Caught and Re-thrown)

Sometimes you want to catch an exception, do some processing, and then re-throw it:

```java
public class PartialPropagation {
    public static void main(String[] args) {
        try {
            processData("invalid-data");
        } catch (IllegalArgumentException e) {
            System.out.println("Caught in main: " + e.getMessage());
        }
    }
    
    public static void processData(String data) throws IllegalArgumentException {
        try {
            validateData(data);
        } catch (IllegalArgumentException e) {
            System.out.println("Caught in processData: " + e.getMessage());
            System.out.println("Logging error and re-throwing...");
            // Re-throw the same exception
            throw e;
        }
        System.out.println("Data processed successfully");
    }
    
    public static void validateData(String data) throws IllegalArgumentException {
        if (data == null || data.trim().isEmpty()) {
            throw new IllegalArgumentException("Data cannot be null or empty");
        }
        System.out.println("Data validation passed");
    }
}
```

## Exception Wrapping

You can catch one exception and throw a different one:

```java
public class ExceptionWrapping {
    public static void main(String[] args) {
        try {
            performOperation("test");
        } catch (BusinessException e) {
            System.out.println("Business error: " + e.getMessage());
            System.out.println("Original cause: " + e.getCause().getMessage());
        }
    }
    
    public static void performOperation(String input) throws BusinessException {
        try {
            riskyOperation(input);
        } catch (IllegalArgumentException e) {
            // Wrap the original exception in a new business exception
            throw new BusinessException("Operation failed due to invalid input", e);
        }
    }
    
    public static void riskyOperation(String input) throws IllegalArgumentException {
        if (input.length() < 3) {
            throw new IllegalArgumentException("Input too short: " + input);
        }
        System.out.println("Operation completed successfully");
    }
}

// Custom business exception
class BusinessException extends Exception {
    public BusinessException(String message, Throwable cause) {
        super(message, cause);
    }
}
```

## Propagation with Finally Blocks

The `finally` block executes even when exceptions propagate:

```java
public class PropagationWithFinally {
    public static void main(String[] args) {
        try {
            methodWithFinally();
        } catch (RuntimeException e) {
            System.out.println("Caught in main: " + e.getMessage());
        }
    }
    
    public static void methodWithFinally() throws RuntimeException {
        try {
            System.out.println("In try block");
            throw new RuntimeException("Error in try block");
        } finally {
            System.out.println("Finally block executes even with propagation");
        }
        System.out.println("This line will NOT execute");
    }
}
```

## Real-World Example: Database Operations

```java
import java.sql.Connection;
import java.sql.SQLException;

public class DatabasePropagation {
    public static void main(String[] args) {
        try {
            processUserData("user123");
        } catch (DatabaseException e) {
            System.out.println("Database operation failed: " + e.getMessage());
            if (e.getCause() != null) {
                System.out.println("Root cause: " + e.getCause().getMessage());
            }
        }
    }
    
    public static void processUserData(String userId) throws DatabaseException {
        Connection conn = null;
        try {
            conn = getConnection();
            updateUserProfile(userId, conn);
            logUserActivity(userId, conn);
        } catch (SQLException e) {
            throw new DatabaseException("Failed to process user data for: " + userId, e);
        } finally {
            if (conn != null) {
                try {
                    conn.close();
                } catch (SQLException e) {
                    System.out.println("Error closing connection: " + e.getMessage());
                }
            }
        }
    }
    
    public static void updateUserProfile(String userId, Connection conn) throws SQLException {
        // Simulate database operation that might fail
        if (userId.equals("invalid")) {
            throw new SQLException("Invalid user ID");
        }
        System.out.println("User profile updated for: " + userId);
    }
    
    public static void logUserActivity(String userId, Connection conn) throws SQLException {
        // Simulate logging operation
        System.out.println("User activity logged for: " + userId);
    }
    
    public static Connection getConnection() throws SQLException {
        // Simulate getting database connection
        throw new SQLException("Database connection failed");
    }
}

class DatabaseException extends Exception {
    public DatabaseException(String message, Throwable cause) {
        super(message, cause);
    }
}
```

## Key Points About Propagation

### 1. **Automatic Propagation**
Exceptions automatically propagate up the call stack when not caught.

### 2. **Method Execution Stops**
When an exception is thrown, the current method stops executing immediately.

### 3. **Call Stack Unwinding**
Java unwinds the call stack, looking for an appropriate catch block.

### 4. **Finally Blocks Always Execute**
Finally blocks execute even when exceptions propagate.

### 5. **Checked Exceptions Must Be Declared**
If a method might throw a checked exception, it must be declared with `throws`.

### 6. **Unchecked Exceptions Don't Need Declaration**
Runtime exceptions can propagate without being declared.

## Propagation Strategies

### 1. **Let It Propagate**
```java
public void methodA() throws IOException {
    methodB(); // Let IOException propagate up
}
```

### 2. **Catch and Handle**
```java
public void methodA() {
    try {
        methodB();
    } catch (IOException e) {
        // Handle the exception locally
        System.out.println("IO error handled: " + e.getMessage());
    }
}
```

### 3. **Catch and Re-throw**
```java
public void methodA() throws BusinessException {
    try {
        methodB();
    } catch (IOException e) {
        throw new BusinessException("Business operation failed", e);
    }
}
```

### 4. **Catch, Process, and Re-throw**
```java
public void methodA() throws IOException {
    try {
        methodB();
    } catch (IOException e) {
        logError(e); // Do some processing
        throw e;     // Re-throw the same exception
    }
}
```

## What's Next?

Now that you understand how exceptions propagate through your application, let's learn about best practices for exception handling to write robust and maintainable code!
