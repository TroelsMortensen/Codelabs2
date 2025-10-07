# Exception Best Practices

Now that you understand the fundamentals of exception handling, let's learn the best practices that will help you write robust, maintainable, and user-friendly code. Following these practices will make your applications more reliable and easier to debug.

## 1. Catch Specific Exceptions

### ❌ Bad Practice
```java
try {
    // Some operations
} catch (Exception e) {
    // Too generic - catches everything
    System.out.println("Something went wrong");
}
```

### ✅ Good Practice
```java
try {
    // Some operations
} catch (FileNotFoundException e) {
    System.out.println("File not found: " + e.getMessage());
} catch (IOException e) {
    System.out.println("IO error: " + e.getMessage());
} catch (NumberFormatException e) {
    System.out.println("Invalid number format: " + e.getMessage());
}
```

**Why**: Specific exceptions allow for targeted error handling and better user experience.

## 2. Don't Ignore Exceptions

### ❌ Bad Practice
```java
try {
    riskyOperation();
} catch (Exception e) {
    // Empty catch block - silently ignores the exception
}
```

### ✅ Good Practice
```java
try {
    riskyOperation();
} catch (Exception e) {
    // Log the exception for debugging
    System.err.println("Error in riskyOperation: " + e.getMessage());
    e.printStackTrace();
    
    // Or provide meaningful feedback to user
    System.out.println("Operation failed. Please try again.");
}
```

**Why**: Ignoring exceptions makes debugging nearly impossible and can lead to silent failures.

## 3. Provide Meaningful Error Messages

### ❌ Bad Practice
```java
public void validateAge(int age) {
    if (age < 0) {
        throw new IllegalArgumentException("Invalid age");
    }
}
```

### ✅ Good Practice
```java
public void validateAge(int age) {
    if (age < 0) {
        throw new IllegalArgumentException("Age cannot be negative: " + age);
    }
    if (age > 150) {
        throw new IllegalArgumentException("Age cannot be greater than 150: " + age);
    }
}
```

**Why**: Detailed error messages help users understand what went wrong and how to fix it.

## 4. Use Finally for Resource Cleanup

### ❌ Bad Practice
```java
public void readFile(String filename) {
    Scanner scanner = new Scanner(new File(filename));
    // Process file
    scanner.close(); // This might not execute if an exception occurs
}
```

### ✅ Good Practice
```java
public void readFile(String filename) {
    Scanner scanner = null;
    try {
        scanner = new Scanner(new File(filename));
        // Process file
    } catch (FileNotFoundException e) {
        System.out.println("File not found: " + e.getMessage());
    } finally {
        if (scanner != null) {
            scanner.close();
        }
    }
}
```

**Why**: Finally blocks ensure resources are always cleaned up, preventing resource leaks.

## 5. Don't Catch What You Can't Handle

### ❌ Bad Practice
```java
public void processData() {
    try {
        connectToDatabase();
        performComplexOperation();
        saveResults();
    } catch (Exception e) {
        // Can't meaningfully handle all possible exceptions
        System.out.println("Error occurred");
    }
}
```

### ✅ Good Practice
```java
public void processData() throws DatabaseException, ProcessingException {
    try {
        connectToDatabase();
    } catch (SQLException e) {
        throw new DatabaseException("Failed to connect to database", e);
    }
    
    try {
        performComplexOperation();
    } catch (IllegalArgumentException e) {
        throw new ProcessingException("Invalid data for processing", e);
    }
    
    saveResults();
}
```

**Why**: Only catch exceptions that you can meaningfully handle. Let others propagate to appropriate handlers.

## 6. Use Appropriate Exception Types

### ❌ Bad Practice
```java
public void withdraw(double amount) {
    if (amount > balance) {
        throw new Exception("Insufficient funds"); // Too generic
    }
}
```

### ✅ Good Practice
```java
public void withdraw(double amount) throws InsufficientFundsException {
    if (amount > balance) {
        throw new InsufficientFundsException("Insufficient funds. Balance: " + balance + ", Requested: " + amount);
    }
}
```

**Why**: Specific exception types make error handling more precise and code more self-documenting.

## 7. Log Exceptions Appropriately

### ✅ Good Practice
```java
import java.util.logging.Logger;

public class DataProcessor {
    private static final Logger logger = Logger.getLogger(DataProcessor.class.getName());
    
    public void processData(String data) {
        try {
            validateData(data);
            performProcessing(data);
        } catch (ValidationException e) {
            logger.warning("Data validation failed: " + e.getMessage());
            throw e; // Re-throw for caller to handle
        } catch (ProcessingException e) {
            logger.severe("Processing failed: " + e.getMessage());
            e.printStackTrace();
            throw e;
        }
    }
}
```

**Why**: Proper logging helps with debugging and monitoring application health.

## 8. Handle Exceptions at the Right Level

### ❌ Bad Practice
```java
public class UserService {
    public void createUser(String name, String email) {
        try {
            validateEmail(email);
            saveToDatabase(name, email);
            sendWelcomeEmail(email);
        } catch (Exception e) {
            // Handling all exceptions at the lowest level
            System.out.println("User creation failed");
        }
    }
}
```

### ✅ Good Practice
```java
public class UserService {
    public void createUser(String name, String email) throws UserCreationException {
        try {
            validateEmail(email);
            saveToDatabase(name, email);
            sendWelcomeEmail(email);
        } catch (ValidationException e) {
            throw new UserCreationException("Invalid user data", e);
        } catch (DatabaseException e) {
            throw new UserCreationException("Failed to save user", e);
        } catch (EmailException e) {
            // Email failure shouldn't prevent user creation
            logger.warning("Failed to send welcome email: " + e.getMessage());
        }
    }
}
```

**Why**: Handle exceptions at the level where you have the most context and can make the best decisions.

## 9. Use Try-With-Resources for Automatic Cleanup

### ❌ Bad Practice
```java
public void readFile(String filename) {
    Scanner scanner = null;
    try {
        scanner = new Scanner(new File(filename));
        // Process file
    } catch (FileNotFoundException e) {
        System.out.println("File not found");
    } finally {
        if (scanner != null) {
            scanner.close();
        }
    }
}
```

### ✅ Good Practice
```java
public void readFile(String filename) {
    try (Scanner scanner = new Scanner(new File(filename))) {
        // Process file
        // Scanner is automatically closed when try block exits
    } catch (FileNotFoundException e) {
        System.out.println("File not found: " + e.getMessage());
    }
}
```

**Why**: Try-with-resources automatically handles resource cleanup, reducing boilerplate code and preventing resource leaks.

## 10. Don't Use Exceptions for Control Flow

### ❌ Bad Practice
```java
public boolean isUserValid(String userId) {
    try {
        findUser(userId);
        return true;
    } catch (UserNotFoundException e) {
        return false;
    }
}
```

### ✅ Good Practice
```java
public boolean isUserValid(String userId) {
    return findUser(userId) != null;
}

public User findUser(String userId) {
    // Return null if not found, or use Optional<User>
    return userRepository.findById(userId);
}
```

**Why**: Exceptions should represent exceptional conditions, not normal program flow.

## 11. Validate Input Early

### ❌ Bad Practice
```java
public void processUserData(String name, int age, String email) {
    // Process data first
    saveToDatabase(name, age, email);
    
    // Validate later (too late!)
    if (age < 0) {
        throw new IllegalArgumentException("Invalid age");
    }
}
```

### ✅ Good Practice
```java
public void processUserData(String name, int age, String email) {
    // Validate input first
    if (name == null || name.trim().isEmpty()) {
        throw new IllegalArgumentException("Name cannot be null or empty");
    }
    if (age < 0 || age > 150) {
        throw new IllegalArgumentException("Age must be between 0 and 150");
    }
    if (email == null || !email.contains("@")) {
        throw new IllegalArgumentException("Invalid email format");
    }
    
    // Process validated data
    saveToDatabase(name, age, email);
}
```

**Why**: Early validation prevents processing invalid data and provides faster feedback.

## 12. Use Custom Exceptions for Business Logic

### ✅ Good Practice
```java
// Custom exceptions for business logic
class InsufficientFundsException extends Exception {
    private double balance;
    private double requestedAmount;
    
    public InsufficientFundsException(double balance, double requestedAmount) {
        super(String.format("Insufficient funds. Balance: %.2f, Requested: %.2f", 
                           balance, requestedAmount));
        this.balance = balance;
        this.requestedAmount = requestedAmount;
    }
    
    public double getBalance() { return balance; }
    public double getRequestedAmount() { return requestedAmount; }
}

class InvalidAccountException extends Exception {
    public InvalidAccountException(String accountId) {
        super("Invalid account ID: " + accountId);
    }
}

// Usage
public void transferMoney(String fromAccount, String toAccount, double amount) 
        throws InsufficientFundsException, InvalidAccountException {
    
    Account from = validateAccount(fromAccount);
    Account to = validateAccount(toAccount);
    
    if (from.getBalance() < amount) {
        throw new InsufficientFundsException(from.getBalance(), amount);
    }
    
    // Perform transfer
}
```

**Why**: Custom exceptions make business logic errors explicit and easier to handle.

## 13. Document Exception Behavior

### ✅ Good Practice
```java
/**
 * Transfers money between two accounts.
 * 
 * @param fromAccount the source account ID
 * @param toAccount the destination account ID
 * @param amount the amount to transfer
 * @throws InsufficientFundsException if the source account has insufficient funds
 * @throws InvalidAccountException if either account ID is invalid
 * @throws IllegalArgumentException if the amount is negative or zero
 */
public void transferMoney(String fromAccount, String toAccount, double amount) 
        throws InsufficientFundsException, InvalidAccountException {
    // Implementation
}
```

**Why**: Documentation helps other developers understand what exceptions a method might throw and when.

## Summary of Best Practices

1. **Catch specific exceptions** rather than generic ones
2. **Never ignore exceptions** - always handle them meaningfully
3. **Provide detailed error messages** with context
4. **Use finally blocks** for resource cleanup
5. **Only catch what you can handle** - let others propagate
6. **Use appropriate exception types** for different error conditions
7. **Log exceptions** for debugging and monitoring
8. **Handle exceptions at the right level** in your application
9. **Use try-with-resources** for automatic cleanup
10. **Don't use exceptions for control flow** - use return values instead
11. **Validate input early** to prevent processing invalid data
12. **Create custom exceptions** for business logic errors
13. **Document exception behavior** in your method signatures

Following these practices will make your code more robust, maintainable, and user-friendly!

## What's Next?

Now that you know the best practices, let's look at some common exception scenarios you'll encounter in real-world applications!
