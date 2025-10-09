# Exception Propagation

This page is sort of a continuation of the rethrow concept you read previously, just explaning what actually happens.

Exception propagation is the process by which exceptions move up through the call stack when they are not caught. Understanding how exceptions propagate is crucial for designing robust error handling in your applications.

## What is Exception Propagation?

When an exception is thrown and not caught in the current method, it automatically propagates (bubbles up) to the calling method. This continues until either:
1. The exception is caught by a try-catch block
2. The exception reaches the `main` method and causes the program to terminate

## Simple Propagation Example

Let's trace how an exception propagates through multiple method calls:

```java{5,14,20,26}
public class PropagationDemo {
    public static void main(String[] args) {
        System.out.println("Starting main method...");
        try {
            methodA();
        } catch (RuntimeException e) {
            System.out.println("Caught in main: " + e.getMessage());
            e.printStackTrace();
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

In the output, you can see the stack trace, which shows the method calls that led to the exception. This sequence of methods is called the **"call stack"**.

## Partial Propagation (Caught and Re-thrown)

Sometimes you want to catch an exception, do some processing, and then re-throw it:

```java{17}
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

You can catch one exception and throw a different one, notice the last argument to the `BusinessException` constructor is the original exception.

```java{14}
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

### 7. **Careful when wrapping exceptions**
When you wrap an exception, the original exception is lost. This is why you should only wrap exceptions if you are sure you can handle the original exception. When you lose the original exception, you potentially also lose crucial information.

### 8. **Careful when rethrowing exceptions**
The same potential loss of information happens when you rethrow, or catch-and-throw another exception.

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
        e.printStackTrace();
        throw e;     // Re-throw the same exception
    }
}
```
