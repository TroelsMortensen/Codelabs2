# Throwing Exceptions

So far, we've learned how to catch and handle exceptions that Java throws automatically. Now let's learn how to throw our own exceptions using the `throw` keyword. This allows you to signal that something has gone wrong in your code and let other parts of your program handle it.

## The `throw` Keyword

The `throw` keyword is used to explicitly throw an exception. You can throw either:
- **Built-in exceptions** (like `IllegalArgumentException`, `RuntimeException`)
- **Custom exceptions** (which we'll learn about later)

## Basic Syntax

```java
throw new ExceptionType("Error message");
```

## Simple Examples

### Throwing IllegalArgumentException

```java
public class AgeValidator {
    public static void validateAge(int age) {
        if (age < 0) {
            throw new IllegalArgumentException("Age cannot be negative: " + age);
        }
        if (age > 150) {
            throw new IllegalArgumentException("Age cannot be greater than 150: " + age);
        }
        System.out.println("Age " + age + " is valid.");
    }
    
    public static void main(String[] args) {
        try {
            validateAge(25);  // Valid
            validateAge(-5);  // Invalid - will throw exception
        } catch (IllegalArgumentException e) {
            System.out.println("Invalid age: " + e.getMessage());
        }
    }
}
```

### Throwing RuntimeException

```java
public class Calculator {
    public static double divide(double a, double b) {
        if (b == 0) {
            throw new RuntimeException("Cannot divide by zero!");
        }
        return a / b;
    }
    
    public static void main(String[] args) {
        try {
            double result1 = divide(10, 2);
            System.out.println("10 / 2 = " + result1);
            
            double result2 = divide(10, 0); // This will throw an exception
            System.out.println("10 / 0 = " + result2);
        } catch (RuntimeException e) {
            System.out.println("Error: " + e.getMessage());
        }
    }
}
```

## Real-World Example: Bank Account

```java
public class BankAccount {
    private double balance;
    private String accountNumber;
    
    public BankAccount(String accountNumber, double initialBalance) {
        if (accountNumber == null || accountNumber.trim().isEmpty()) {
            throw new IllegalArgumentException("Account number cannot be null or empty");
        }
        if (initialBalance < 0) {
            throw new IllegalArgumentException("Initial balance cannot be negative");
        }
        
        this.accountNumber = accountNumber;
        this.balance = initialBalance;
    }
    
    public void withdraw(double amount) {
        if (amount <= 0) {
            throw new IllegalArgumentException("Withdrawal amount must be positive");
        }
        if (amount > balance) {
            throw new RuntimeException("Insufficient funds. Balance: " + balance + ", Requested: " + amount);
        }
        
        balance -= amount;
        System.out.println("Withdrew " + amount + ". New balance: " + balance);
    }
    
    public void deposit(double amount) {
        if (amount <= 0) {
            throw new IllegalArgumentException("Deposit amount must be positive");
        }
        
        balance += amount;
        System.out.println("Deposited " + amount + ". New balance: " + balance);
    }
    
    public double getBalance() {
        return balance;
    }
    
    public static void main(String[] args) {
        try {
            // Valid account creation
            BankAccount account = new BankAccount("12345", 1000.0);
            System.out.println("Account created with balance: " + account.getBalance());
            
            // Valid operations
            account.deposit(500.0);
            account.withdraw(200.0);
            
            // Invalid operations that will throw exceptions
            account.withdraw(2000.0); // Insufficient funds
            
        } catch (IllegalArgumentException e) {
            System.out.println("Invalid input: " + e.getMessage());
        } catch (RuntimeException e) {
            System.out.println("Operation failed: " + e.getMessage());
        }
    }
}
```

## String Validation Example

```java
public class StringValidator {
    public static void validateEmail(String email) {
        if (email == null) {
            throw new IllegalArgumentException("Email cannot be null");
        }
        if (email.trim().isEmpty()) {
            throw new IllegalArgumentException("Email cannot be empty");
        }
        if (!email.contains("@")) {
            throw new IllegalArgumentException("Email must contain @ symbol");
        }
        if (email.length() < 5) {
            throw new IllegalArgumentException("Email must be at least 5 characters long");
        }
        
        System.out.println("Email '" + email + "' is valid.");
    }
    
    public static void main(String[] args) {
        String[] emails = {
            "user@example.com",    // Valid
            "",                    // Invalid - empty
            "invalid-email",       // Invalid - no @
            "a@b",                 // Invalid - too short
            null                   // Invalid - null
        };
        
        for (String email : emails) {
            try {
                validateEmail(email);
            } catch (IllegalArgumentException e) {
                System.out.println("Invalid email '" + email + "': " + e.getMessage());
            }
        }
    }
}
```

## Array Operations Example

```java
public class ArrayOperations {
    public static int getElement(int[] array, int index) {
        if (array == null) {
            throw new IllegalArgumentException("Array cannot be null");
        }
        if (index < 0) {
            throw new IllegalArgumentException("Index cannot be negative: " + index);
        }
        if (index >= array.length) {
            throw new IllegalArgumentException("Index " + index + " is out of bounds for array of length " + array.length);
        }
        
        return array[index];
    }
    
    public static void main(String[] args) {
        int[] numbers = {10, 20, 30, 40, 50};
        
        try {
            System.out.println("Element at index 2: " + getElement(numbers, 2));
            System.out.println("Element at index 5: " + getElement(numbers, 5)); // Out of bounds
        } catch (IllegalArgumentException e) {
            System.out.println("Error: " + e.getMessage());
        }
        
        try {
            System.out.println("Element from null array: " + getElement(null, 0)); // Null array
        } catch (IllegalArgumentException e) {
            System.out.println("Error: " + e.getMessage());
        }
    }
}
```

## When to Throw Exceptions

### 1. **Input Validation**
Throw exceptions when input doesn't meet your requirements:

```java
public void setAge(int age) {
    if (age < 0 || age > 150) {
        throw new IllegalArgumentException("Age must be between 0 and 150");
    }
    this.age = age;
}
```

### 2. **Business Logic Violations**
Throw exceptions when business rules are violated:

```java
public void withdraw(double amount) {
    if (amount > balance) {
        throw new RuntimeException("Insufficient funds");
    }
    balance -= amount;
}
```

### 3. **Resource Unavailability**
Throw exceptions when required resources aren't available:

```java
public void connectToDatabase() {
    if (!isNetworkAvailable()) {
        throw new RuntimeException("Network connection required");
    }
    // Connect to database
}
```

### 4. **State Validation**
Throw exceptions when an object is in an invalid state:

```java
public void startEngine() {
    if (isEngineRunning) {
        throw new RuntimeException("Engine is already running");
    }
    isEngineRunning = true;
}
```

## Common Built-in Exceptions to Throw

### IllegalArgumentException
Use when method parameters are invalid:
```java
if (value < 0) {
    throw new IllegalArgumentException("Value cannot be negative: " + value);
}
```

### IllegalStateException
Use when an object is in an invalid state:
```java
if (!isInitialized) {
    throw new IllegalStateException("Object must be initialized first");
}
```

### UnsupportedOperationException
Use when an operation is not supported:
```java
public void remove() {
    throw new UnsupportedOperationException("Remove operation not supported");
}
```

### RuntimeException
Use for general runtime errors:
```java
if (connection == null) {
    throw new RuntimeException("Database connection not available");
}
```

## Best Practices

### 1. **Provide Meaningful Messages**
Always include descriptive error messages:

```java
// Good
throw new IllegalArgumentException("Age cannot be negative: " + age);

// Bad
throw new IllegalArgumentException("Invalid input");
```

### 2. **Choose Appropriate Exception Types**
Use the most specific exception type that fits your situation.

### 3. **Throw Early, Catch Late**
Validate inputs and throw exceptions as early as possible.

### 4. **Don't Throw for Expected Conditions**
Don't throw exceptions for normal program flow - use return values or other mechanisms instead.

### 5. **Document Exceptions**
If your method can throw exceptions, document them in comments or method signatures.

## What's Next?

Now that you can throw exceptions, let's learn about the `throws` keyword, which allows you to declare that a method might throw certain exceptions!
