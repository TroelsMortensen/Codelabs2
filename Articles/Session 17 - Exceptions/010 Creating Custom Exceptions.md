# Creating Custom Exceptions

While Java provides many built-in exceptions, sometimes you need to create your own custom exceptions to represent specific error conditions in your application.Instead of using some of the more general purpose exceptions, with a not entirely clear purpose, you can create your own more specialized exceptions. Custom exceptions make your code more readable and allow for more specific error handling.

## Why Create Custom Exceptions?

### 1. **Specific Error Information**
Custom exceptions can carry specific information about what went wrong in your application.

### 2. **Better Error Handling**
You can catch and handle specific types of errors differently.

### 3. **Code Clarity**
Custom exceptions make your code more self-documenting and easier to understand.

### 4. **Business Logic**
They can represent business rule violations that are specific to your application.

## Basic Custom Exception

The simplest custom exception extends `Exception`. Here we define an `InvalidAgeException` that extends `Exception`. It is used in the `AgeValidator` class.

```java
// Custom exception class
class InvalidAgeException extends Exception {
    public InvalidAgeException(String message) {
        super(message);
    }
}

// Using the custom exception
public class AgeValidator {
    public static void validateAge(int age) throws InvalidAgeException {
        if (age < 0) {
            throw new InvalidAgeException("Age cannot be negative: " + age);
        }
        if (age > 150) {
            throw new InvalidAgeException("Age cannot be greater than 150: " + age);
        }
        System.out.println("Age " + age + " is valid.");
    }
    
    public static void main(String[] args) {
        try {
            validateAge(25);  // Valid
            validateAge(-5);  // Invalid
        } catch (InvalidAgeException e) {
            System.out.println("Age validation failed: " + e.getMessage());
        }
    }
}
```

## Checked vs Unchecked Custom Exceptions

You can extend `Exception` to create a new checked exception. Or, you can extend `RuntimeException` to create a new unchecked exception.

### Checked Exception (extends Exception)

Here is an example of a checked exception. It carries extra specific information about the error.

```java
class InsufficientFundsException extends Exception {
    private double balance;
    private double requestedAmount;
    
    public InsufficientFundsException(String message, double balance, double requestedAmount) {
        super(message);
        this.balance = balance;
        this.requestedAmount = requestedAmount;
    }
    
    public double getBalance() {
        return balance;
    }
    
    public double getRequestedAmount() {
        return requestedAmount;
    }
}
```

### Unchecked Exception (extends RuntimeException)

Here is an example of an unchecked exception, because it extends `RuntimeException`.

```java
class InvalidPasswordException extends RuntimeException {
    private String password;
    
    public InvalidPasswordException(String message, String password) {
        super(message);
        this.password = password;
    }
    
    public String getPassword() {
        return password;
    }
}
``` 

## Exception Hierarchy Example

You can create a hierarchy of custom exceptions. Maybe you have superclasses like `ValidationException`, `BusinessRuleViolationException`, and `ResourceNotFoundException`. And then further subclasses like `InvalidEmailException`, `BadInputException`, and `ResourceNotFoundError`.



```java
// Base exception for all banking operations
class BankingException extends Exception {
    public BankingException(String message) {
        super(message);
    }
}

// Specific exceptions for different banking operations
class InsufficientFundsException extends BankingException {
    public InsufficientFundsException(String message) {
        super(message);
    }
}

class InvalidAccountException extends BankingException {
    public InvalidAccountException(String message) {
        super(message);
    }
}

class TransactionLimitExceededException extends BankingException {
    public TransactionLimitExceededException(String message) {
        super(message);
    }
}
```

## Best Practices for Custom Exceptions

### 1. **Choose the Right Base Class**
- **Extend `Exception`** for checked exceptions (must be handled)
- **Extend `RuntimeException`** for unchecked exceptions (programming errors)

### 2. **Provide Constructors**
Always provide at least a constructor that takes a message:

```java
class MyException extends Exception {
    public MyException(String message) {
        super(message);
    }
    
    public MyException(String message, Throwable cause) {
        super(message, cause);
    }
}
```

### 3. **Include Relevant Information**
Add fields to store information that might be useful for error handling:

```java
class ValidationException extends Exception {
    private String fieldName;
    private Object invalidValue;
    
    public ValidationException(String message, String fieldName, Object invalidValue) {
        super(message);
        this.fieldName = fieldName;
        this.invalidValue = invalidValue;
    }
    
    // Getters for fieldName and invalidValue
}
```

### 4. **Override toString() for Better Debugging**
```java
@Override
public String toString() {
    return String.format("%s: %s (Field: %s, Value: %s)", 
                       getClass().getSimpleName(), getMessage(), fieldName, invalidValue);
}
```

### 5. **Use Meaningful Names**
Choose names that clearly indicate what went wrong:
- `InvalidEmailException` ✓
- `BadInputException` ✗ (too generic)

### 6. **Don't go overboard**
You can quickly end up creating a lot of custom exceptions, and then you will find that all your subclasses of RuntimeException are handled exactly the same way. So, you might end up with a lot of code duplication. This serves no purpose.

```java
/**
 * Thrown when a user attempts to perform an operation they don't have permission for.
 * 
 * @param message the detail message
 * @param userId the ID of the user who attempted the operation
 * @param operation the operation that was attempted
 */
public UnauthorizedOperationException(String message, String userId, String operation) {
    super(message);
    this.userId = userId;
    this.operation = operation;
}
```

## Common Custom Exception Patterns

### 1. **Validation Exceptions**
```java
class ValidationException extends Exception {
    private List<String> errors;
    
    public ValidationException(String message, List<String> errors) {
        super(message);
        this.errors = errors;
    }
    
    public List<String> getErrors() {
        return errors;
    }
}
```

### 2. **Business Logic Exceptions**
```java
class BusinessRuleViolationException extends Exception {
    private String ruleName;
    
    public BusinessRuleViolationException(String message, String ruleName) {
        super(message);
        this.ruleName = ruleName;
    }
}
```

### 3. **Resource Exceptions**
```java
class ResourceNotFoundException extends Exception {
    private String resourceType;
    private String resourceId;
    
    public ResourceNotFoundException(String message, String resourceType, String resourceId) {
        super(message);
        this.resourceType = resourceType;
        this.resourceId = resourceId;
    }
}
```

## What's Next?

Now that you can create custom exceptions, let's learn about exception propagation - how exceptions move up through the call stack when they're not caught!
