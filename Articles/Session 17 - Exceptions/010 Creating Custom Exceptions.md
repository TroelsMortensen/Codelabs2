# Creating Custom Exceptions

While Java provides many built-in exceptions, sometimes you need to create your own custom exceptions to represent specific error conditions in your application. Custom exceptions make your code more readable and allow for more specific error handling.

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

The simplest custom exception extends `Exception`:

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

### Checked Exception (extends Exception)
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

public class BankAccount {
    private double balance;
    
    public BankAccount(double initialBalance) {
        this.balance = initialBalance;
    }
    
    public void withdraw(double amount) throws InsufficientFundsException {
        if (amount > balance) {
            throw new InsufficientFundsException(
                "Insufficient funds", balance, amount);
        }
        balance -= amount;
    }
    
    public static void main(String[] args) {
        BankAccount account = new BankAccount(1000.0);
        
        try {
            account.withdraw(1500.0); // This will throw InsufficientFundsException
        } catch (InsufficientFundsException e) {
            System.out.println("Withdrawal failed: " + e.getMessage());
            System.out.println("Current balance: " + e.getBalance());
            System.out.println("Requested amount: " + e.getRequestedAmount());
        }
    }
}
```

### Unchecked Exception (extends RuntimeException)
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

public class UserValidator {
    public static void validatePassword(String password) {
        if (password == null || password.length() < 8) {
            throw new InvalidPasswordException(
                "Password must be at least 8 characters long", password);
        }
        if (!password.matches(".*[0-9].*")) {
            throw new InvalidPasswordException(
                "Password must contain at least one number", password);
        }
        System.out.println("Password is valid.");
    }
    
    public static void main(String[] args) {
        try {
            validatePassword("weak"); // This will throw InvalidPasswordException
        } catch (InvalidPasswordException e) {
            System.out.println("Password validation failed: " + e.getMessage());
            System.out.println("Invalid password: " + e.getPassword());
        }
    }
}
```

## Complex Custom Exception with Additional Data

```java
class StudentRegistrationException extends Exception {
    private String studentId;
    private String courseId;
    private String reason;
    
    public StudentRegistrationException(String message, String studentId, 
                                     String courseId, String reason) {
        super(message);
        this.studentId = studentId;
        this.courseId = courseId;
        this.reason = reason;
    }
    
    public String getStudentId() {
        return studentId;
    }
    
    public String getCourseId() {
        return courseId;
    }
    
    public String getReason() {
        return reason;
    }
    
    @Override
    public String toString() {
        return String.format("StudentRegistrationException: %s (Student: %s, Course: %s, Reason: %s)",
                           getMessage(), studentId, courseId, reason);
    }
}

public class CourseRegistration {
    public static void registerStudent(String studentId, String courseId, int credits) 
            throws StudentRegistrationException {
        
        // Simulate various validation checks
        if (studentId == null || studentId.trim().isEmpty()) {
            throw new StudentRegistrationException(
                "Invalid student ID", studentId, courseId, "Student ID is null or empty");
        }
        
        if (credits > 18) {
            throw new StudentRegistrationException(
                "Too many credits", studentId, courseId, "Exceeds maximum credit limit of 18");
        }
        
        if (courseId.equals("MATH101") && credits < 3) {
            throw new StudentRegistrationException(
                "Insufficient credits for course", studentId, courseId, 
                "MATH101 requires at least 3 credits");
        }
        
        System.out.println("Student " + studentId + " successfully registered for " + courseId);
    }
    
    public static void main(String[] args) {
        try {
            registerStudent("S123", "MATH101", 2); // This will throw exception
        } catch (StudentRegistrationException e) {
            System.out.println("Registration failed:");
            System.out.println("  Student: " + e.getStudentId());
            System.out.println("  Course: " + e.getCourseId());
            System.out.println("  Reason: " + e.getReason());
            System.out.println("  Full details: " + e);
        }
    }
}
```

## Exception Hierarchy Example

You can create a hierarchy of custom exceptions:

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

public class BankingSystem {
    public static void processTransaction(String accountId, double amount) 
            throws BankingException {
        
        if (accountId == null || accountId.trim().isEmpty()) {
            throw new InvalidAccountException("Account ID cannot be null or empty");
        }
        
        if (amount > 10000) {
            throw new TransactionLimitExceededException(
                "Transaction amount exceeds daily limit: " + amount);
        }
        
        // Simulate insufficient funds check
        double balance = 5000.0; // Simulated balance
        if (amount > balance) {
            throw new InsufficientFundsException(
                "Insufficient funds. Balance: " + balance + ", Requested: " + amount);
        }
        
        System.out.println("Transaction processed successfully: " + amount);
    }
    
    public static void main(String[] args) {
        try {
            processTransaction("ACC123", 15000.0); // This will throw TransactionLimitExceededException
        } catch (InsufficientFundsException e) {
            System.out.println("Insufficient funds: " + e.getMessage());
        } catch (InvalidAccountException e) {
            System.out.println("Invalid account: " + e.getMessage());
        } catch (TransactionLimitExceededException e) {
            System.out.println("Transaction limit exceeded: " + e.getMessage());
        } catch (BankingException e) {
            System.out.println("Banking error: " + e.getMessage());
        }
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

### 6. **Document Your Exceptions**
Use JavaDoc to document when and why exceptions are thrown:

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
