# JavaDoc Best Practices

Writing good JavaDoc is an art. Follow these best practices to create documentation that is clear, useful, and maintainable.

## Write Clear, Concise Descriptions

### Be Direct and Specific

**Bad:**
```java
/**
 * This method does something with the account.
 */
public void process() {
    // implementation
}
```

**Good:**
```java
/**
 * Processes pending transactions and updates the account balance.
 */
public void processTransactions() {
    // implementation
}
```

### Use Complete Sentences

Start with a capital letter and end with a period:

**Bad:**
```java
/**
 * gets the name
 */
public String getName() {
    return name;
}
```

**Good:**
```java
/**
 * Returns the customer's full name.
 */
public String getName() {
    return name;
}
```

### Make the First Sentence Count

The first sentence (up to the first period) appears in summary tables. Make it descriptive and complete:

**Bad:**
```java
/**
 * Account. This class represents a bank account with various
 * operations for managing money.
 */
```

**Good:**
```java
/**
 * Represents a bank account with operations for deposits and withdrawals.
 * This class maintains the account balance and transaction history.
 */
```

## Document the "What" and "Why", Not the "How"

JavaDoc describes the contract and purpose, not the implementation.

### Focus on What the Method Does

**Bad:**
```java
/**
 * Uses a for loop to iterate through the array and adds
 * each element to a sum variable, then returns that sum.
 */
public int calculateTotal() {
    // implementation
}
```

**Good:**
```java
/**
 * Calculates the sum of all elements in the array.
 * 
 * @return the sum of all elements, or 0 if the array is empty
 */
public int calculateTotal() {
    // implementation
}
```

### Explain Why When Necessary

Sometimes the "why" is important:

```java
/**
 * Validates the user's password strength.
 * <p>
 * Strong passwords are required to protect against brute-force
 * attacks and meet security compliance requirements.
 * 
 * @param password the password to validate
 * @return true if the password meets all requirements
 */
public boolean isStrongPassword(String password) {
    // implementation
}
```

## Keep Documentation Up to Date

### Update JavaDoc When Code Changes

When you modify a method, immediately update its JavaDoc:

```java
// Before code change:
/**
 * Sends an email to the customer.
 * 
 * @param customer the recipient
 * @param message the email content
 */
public void sendEmail(Customer customer, String message) {
    // old implementation
}

// After adding subject parameter - UPDATE JAVADOC:
/**
 * Sends an email to the customer.
 * 
 * @param customer the recipient
 * @param subject the email subject line
 * @param message the email content
 */
public void sendEmail(Customer customer, String subject, String message) {
    // new implementation
}
```

### Remove Outdated Information

Don't leave obsolete documentation:

**Bad:**
```java
/**
 * Calculates tax based on the customer's country.
 * Currently supports USA only. EU support coming in version 2.0.
 * 
 * [Note: This was written in 2020 and never updated]
 */
public double calculateTax(Customer customer) {
    // Now supports 50+ countries
}
```

## Document Public APIs Thoroughly

### Public and Protected Members

All public and protected classes, methods, and fields should have JavaDoc:

```java
public class ShoppingCart {
    
    /**
     * Maximum number of items allowed in a cart.
     */
    public static final int MAX_ITEMS = 100;
    
    /**
     * Adds an item to the shopping cart.
     * 
     * @param item the item to add
     * @throws CartFullException if cart is at maximum capacity
     */
    public void addItem(Item item) throws CartFullException {
        // implementation
    }
}
```

### Private Members - Optional

Private methods and fields can have JavaDoc if they're complex, but it's optional:

```java
/**
 * Validates credit card number using Luhn algorithm.
 * Used internally by payment processing methods.
 */
private boolean isValidCardNumber(String cardNumber) {
    // implementation
}
```

Often a simple comment is enough for private methods:

```java
// Calculates shipping cost based on weight and distance
private double calculateShipping(double weight, int distance) {
    // implementation
}
```

## Use Consistent Formatting

### Parameter Descriptions

Be consistent in how you describe parameters:

**Good - Consistent style:**
```java
/**
 * Creates a new user account.
 * 
 * @param username the unique username (3-20 characters)
 * @param password the password (minimum 8 characters)
 * @param email the user's email address
 */
```

**Bad - Inconsistent style:**
```java
/**
 * Creates a new user account.
 * 
 * @param username This is the username
 * @param password min 8 chars
 * @param email email address for the user
 */
```

### Return Descriptions

Start return descriptions consistently:

```java
/**
 * Finds a customer by ID.
 * 
 * @param id the customer ID to search for
 * @return the customer if found, null otherwise
 */
public Customer findById(int id) {
    // implementation
}
```

## Avoid Redundant Comments

Don't state what's already obvious from the method signature.

### Simple Getters and Setters

**Bad - Too verbose:**
```java
/**
 * Gets the name.
 * 
 * @return the name
 */
public String getName() {
    return name;
}

/**
 * Sets the name.
 * 
 * @param name the name to set
 */
public void setName(String name) {
    this.name = name;
}
```

**Better - Concise:**
```java
/**
 * Returns the customer's full name.
 */
public String getName() {
    return name;
}

/**
 * Sets the customer's full name.
 */
public void setName(String name) {
    this.name = name;
}
```

**Even better - Add value:**
```java
/**
 * Returns the customer's full name in "FirstName LastName" format.
 */
public String getName() {
    return name;
}

/**
 * Sets the customer's full name.
 * 
 * @param name the full name (will be stored as provided)
 */
public void setName(String name) {
    this.name = name;
}
```

## Document Assumptions and Constraints

Make assumptions explicit:

```java
/**
 * Calculates the distance between two points.
 * <p>
 * Assumes a flat plane (Euclidean geometry). For geographic
 * coordinates, use calculateGeoDistance() instead.
 * 
 * @param x1 the x-coordinate of the first point
 * @param y1 the y-coordinate of the first point
 * @param x2 the x-coordinate of the second point
 * @param y2 the y-coordinate of the second point
 * @return the distance between the points
 */
public double calculateDistance(double x1, double y1, double x2, double y2) {
    // implementation
}
```

Document important constraints:

```java
/**
 * Resizes the image to the specified dimensions.
 * <p>
 * The aspect ratio is not preserved. Both width and height
 * must be between 1 and 5000 pixels.
 * 
 * @param width the new width in pixels
 * @param height the new height in pixels
 * @throws IllegalArgumentException if width or height is out of range
 */
public void resize(int width, int height) {
    // implementation
}
```

## Document Null Handling

Be explicit about null parameters and return values:

```java
/**
 * Searches for a user by email address.
 * 
 * @param email the email to search for (cannot be null)
 * @return the user if found, null if not found
 * @throws IllegalArgumentException if email is null
 */
public User findByEmail(String email) {
    // implementation
}
```

```java
/**
 * Returns the user's middle name.
 * 
 * @return the middle name, or null if the user has no middle name
 */
public String getMiddleName() {
    return middleName;
}
```

## Summary of Best Practices

1. ✅ Write clear, concise descriptions
2. ✅ Document what and why, not how
3. ✅ Keep documentation up to date with code changes
4. ✅ Document all public APIs thoroughly
5. ✅ Use consistent formatting and style
6. ✅ Avoid redundant or obvious comments
7. ✅ Document assumptions, constraints, and edge cases
8. ✅ Be explicit about null handling
9. ✅ Use proper grammar and complete sentences
10. ✅ Make the first sentence meaningful

Good JavaDoc helps other developers (and your future self) understand and use your code effectively. Invest the time to write it well!

