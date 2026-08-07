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



## Key Points About Propagation

### 1. **Automatic Propagation**
Exceptions automatically propagate up the call stack when not caught.

### 2. **Method Execution Stops**
When an exception is thrown, the current method stops executing immediately.

### 3. **Call Stack Unwinding**
Java unwinds the call stack, looking for an appropriate catch block.

### 4. **Finally Blocks Always Execute**
Finally blocks execute even when exceptions propagate. You could have multiple try-finally (without catch) blocks, and the finally blocks will execute in the order they are written.

### 5. **Checked Exceptions Must Be Declared**
If a method might throw a _checked exception_ (i.e. not a RuntimeException), it must be declared with `throws`.

### 6. **Unchecked Exceptions Don't Need Declaration**
Runtime exceptions can propagate without being declared with `throws`.


### 7. **Careful when rethrowing exceptions**
Potential loss of information happens when you rethrow, or catch-and-throw another exception.

## Propagation Strategies

In larger application, you may find that all your own error exceptions, are actually handled the exact same way: Catch it and show a message to the user. No matter where the exception happened, or what happened.

This means at the top level, i.e. the method handling the button click, or console input, should have a try-catch(Exception e) block, to just catch all exceptions, and show a message.

You can then use RuntimeExceptions (or sub-types) for most error messaging in your system.

With this approach, you will catch checked exceptions, as soon as possible, and throw a RuntimeException instead.