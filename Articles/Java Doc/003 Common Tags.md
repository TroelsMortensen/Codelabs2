# Common JavaDoc Tags

JavaDoc tags start with `@` and provide structured information about parameters, return values, exceptions, and more. They are placed after the description in a JavaDoc comment.

## @param - Describing Parameters

The `@param` tag describes a method or constructor parameter.

**Syntax:** `@param parameterName description`

```java
/**
 * Calculates the area of a rectangle.
 * 
 * @param width the width of the rectangle
 * @param height the height of the rectangle
 */
public double calculateArea(double width, double height) {
    return width * height;
}
```

**Best practices:**
- Include one `@param` tag for each parameter
- Start the description with a lowercase letter
- Describe what the parameter represents, not its type (the type is already visible)

## @return - Describing Return Values

The `@return` tag describes what a method returns.

**Syntax:** `@return description`

```java
/**
 * Calculates the area of a rectangle.
 * 
 * @param width the width of the rectangle
 * @param height the height of the rectangle
 * @return the area of the rectangle in square units
 */
public double calculateArea(double width, double height) {
    return width * height;
}
```

**Best practices:**
- Don't use `@return` for void methods or constructors
- Start the description with a lowercase letter
- Describe what is returned, not just repeat "returns X"

## @throws or @exception - Documenting Exceptions

The `@throws` tag (or its synonym `@exception`) documents exceptions that a method might throw.

**Syntax:** `@throws ExceptionType description`

```java
/**
 * Withdraws money from the account.
 * 
 * @param amount the amount to withdraw
 * @throws IllegalArgumentException if amount is negative
 * @throws InsufficientFundsException if balance is too low
 */
public void withdraw(double amount) 
        throws IllegalArgumentException, InsufficientFundsException {
    if (amount < 0) {
        throw new IllegalArgumentException("Amount cannot be negative");
    }
    if (amount > balance) {
        throw new InsufficientFundsException("Insufficient funds");
    }
    balance -= amount;
}
```

**Best practices:**
- Document both checked and unchecked exceptions
- Explain under what conditions the exception is thrown
- Use `@throws` (it's more commonly used than `@exception`)

## Complete Example

Here's a method using all three common tags:

```java
/**
 * Divides two numbers and returns the result.
 * 
 * This method performs division and rounds the result to
 * two decimal places.
 * 
 * @param dividend the number to be divided
 * @param divisor the number to divide by
 * @return the result of the division, rounded to 2 decimal places
 * @throws ArithmeticException if divisor is zero
 */
public double divide(double dividend, double divisor) {
    if (divisor == 0) {
        throw new ArithmeticException("Cannot divide by zero");
    }
    double result = dividend / divisor;
    return Math.round(result * 100.0) / 100.0;
}
```

## Another Example - Constructor

```java
/**
 * Creates a new user account with the specified credentials.
 * 
 * The password will be encrypted before storage. The username
 * must be unique in the system.
 * 
 * @param username the unique username for this account
 * @param password the password in plain text (will be encrypted)
 * @param email the user's email address for notifications
 * @throws IllegalArgumentException if username is empty or null
 * @throws IllegalArgumentException if password is less than 8 characters
 * @throws DuplicateUsernameException if username already exists
 */
public UserAccount(String username, String password, String email) 
        throws IllegalArgumentException, DuplicateUsernameException {
    // implementation
}
```

These three tags - `@param`, `@return`, and `@throws` - are the most commonly used JavaDoc tags. They provide the essential information needed to understand and use a method correctly.

