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

I have spent unreasonable amounts of time helping students debug code, because something did not happen as expected, but no errors were shown in the console. They left a catch block empty, and just ignored the exception.

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

## 7. Validate Input Early

### ❌ Bad Practice
```java
public void processUserData(String name, int age, String email) {
    // Process data first
    saveData(name, age, email);
    
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
    saveData(name, age, email);
}
```

**Why**: Early validation prevents processing invalid data and provides faster feedback.

## 8. Use Custom Exceptions for Business Logic

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
