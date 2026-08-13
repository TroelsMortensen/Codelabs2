# Documenting Methods

Method documentation is arguably the most important part of JavaDoc. It tells users **what** a method does, **what** it needs, and **what** it produces - without explaining **how** it does it.

## The Basic Structure

A complete method JavaDoc includes:
1. A description of what the method does
2. `@param` tags for each parameter
3. `@return` tag (if method returns something)
4. `@throws` tags for exceptions

```java
/**
 * Brief description of what the method does.
 * 
 * Optional longer description with more details about behavior,
 * constraints, or important notes.
 * 
 * @param paramName description of the parameter
 * @return description of what is returned
 * @throws ExceptionType when this exception is thrown
 */
public ReturnType methodName(ParamType paramName) throws ExceptionType {
    // implementation
}
```

## Simple Method Example

```java
/**
 * Calculates the total price including sales tax.
 * 
 * @param price the base price before tax
 * @param taxRate the tax rate as a decimal (e.g., 0.25 for 25%)
 * @return the total price including tax
 */
public double calculateTotalPrice(double price, double taxRate) {
    return price * (1 + taxRate);
}
```

## Void Method Example

For void methods, omit the `@return` tag:

```java
/**
 * Prints a greeting message to the console.
 * 
 * @param name the name of the person to greet
 */
public void greet(String name) {
    System.out.println("Hello, " + name + "!");
}
```

## Method with Exceptions

```java
/**
 * Transfers money from this account to another account.
 * 
 * This method will deduct the amount from the current account
 * and add it to the target account. The operation is atomic -
 * either both succeed or both fail.
 * 
 * @param targetAccount the account to transfer money to
 * @param amount the amount to transfer
 * @throws IllegalArgumentException if amount is negative or zero
 * @throws InsufficientFundsException if this account has insufficient balance
 * @throws IllegalStateException if either account is closed
 */
public void transferTo(BankAccount targetAccount, double amount) 
        throws IllegalArgumentException, InsufficientFundsException, IllegalStateException {
    if (amount <= 0) {
        throw new IllegalArgumentException("Amount must be positive");
    }
    if (amount > this.balance) {
        throw new InsufficientFundsException("Insufficient funds");
    }
    if (this.isClosed() || targetAccount.isClosed()) {
        throw new IllegalStateException("Cannot transfer to/from closed account");
    }
    
    this.balance -= amount;
    targetAccount.balance += amount;
}
```

## Constructor Documentation

Constructors are documented similarly to methods, but without `@return` tags:

```java
/**
 * Creates a new bank account with the specified initial balance.
 * 
 * The account is created in an active state and assigned a unique
 * account number automatically.
 * 
 * @param accountHolder the name of the account holder
 * @param initialBalance the starting balance
 * @throws IllegalArgumentException if initialBalance is negative
 * @throws IllegalArgumentException if accountHolder is null or empty
 */
public BankAccount(String accountHolder, double initialBalance) {
    if (initialBalance < 0) {
        throw new IllegalArgumentException("Initial balance cannot be negative");
    }
    if (accountHolder == null || accountHolder.isEmpty()) {
        throw new IllegalArgumentException("Account holder name is required");
    }
    
    this.accountHolder = accountHolder;
    this.balance = initialBalance;
    this.accountNumber = generateAccountNumber();
    this.status = AccountStatus.ACTIVE;
}
```

## What to Include in Method Descriptions

### Describe the Effect
Explain what the method does and what changes it makes:

```java
/**
 * Adds a student to the course enrollment list.
 * 
 * If the student is already enrolled, this method has no effect.
 * The course capacity is checked before enrollment.
 * 
 * @param student the student to enroll
 * @throws CourseFullException if the course has reached maximum capacity
 */
public void enrollStudent(Student student) throws CourseFullException {
    // implementation
}
```

### Describe Important Behavior

```java
/**
 * Searches for a customer by name.
 * 
 * The search is case-insensitive and matches partial names.
 * Results are sorted alphabetically by full name.
 * 
 * @param searchTerm the name or partial name to search for
 * @return a list of matching customers, or empty list if none found
 */
public List<Customer> searchByName(String searchTerm) {
    // implementation
}
```

### Describe Constraints and Preconditions

```java
/**
 * Reserves a vehicle for the specified date range.
 * 
 * The start date must be today or in the future. The end date
 * must be after the start date. The vehicle must be available
 * for the entire period.
 * 
 * @param vehicle the vehicle to reserve
 * @param startDate the first day of the reservation
 * @param endDate the last day of the reservation
 * @return the created reservation
 * @throws IllegalArgumentException if dates are invalid
 * @throws VehicleNotAvailableException if vehicle is not available
 */
public Reservation reserveVehicle(Vehicle vehicle, LocalDate startDate, LocalDate endDate) 
        throws IllegalArgumentException, VehicleNotAvailableException {
    // implementation
}
```

## What NOT to Include

### Don't Describe the Implementation

**Bad:**
```java
/**
 * Uses a for loop to iterate through the array and checks
 * each element against the target value using equals().
 */
public boolean contains(String target) {
    // implementation
}
```

**Good:**
```java
/**
 * Checks if the collection contains the specified element.
 * 
 * @param target the element to search for
 * @return true if the element is found, false otherwise
 */
public boolean contains(String target) {
    // implementation
}
```

### Don't Repeat What's Obvious

**Bad:**
```java
/**
 * Gets the name.
 * 
 * @return the name
 */
public String getName() {
    return name;
}
```

**Better:**
```java
/**
 * Returns the customer's full name.
 * 
 * @return the full name as "FirstName LastName"
 */
public String getName() {
    return name;
}
```

Or, for truly simple getters, you can keep it brief:
```java
/**
 * Returns the customer's full name.
 */
public String getName() {
    return name;
}
```

## Complete Example

```java
/**
 * Calculates the monthly payment for a loan.
 * 
 * This method uses the standard amortization formula to calculate
 * equal monthly payments over the loan period. The result is rounded
 * to two decimal places.
 * 
 * @param principal the loan amount (must be positive)
 * @param annualInterestRate the yearly interest rate as a decimal (e.g., 0.05 for 5%)
 * @param years the loan period in years (must be positive)
 * @return the monthly payment amount
 * @throws IllegalArgumentException if principal, interest rate, or years is not positive
 */
public double calculateMonthlyPayment(double principal, double annualInterestRate, int years) {
    if (principal <= 0 || annualInterestRate <= 0 || years <= 0) {
        throw new IllegalArgumentException("All parameters must be positive");
    }
    
    double monthlyRate = annualInterestRate / 12;
    int numberOfPayments = years * 12;
    
    double payment = principal * (monthlyRate * Math.pow(1 + monthlyRate, numberOfPayments)) 
                    / (Math.pow(1 + monthlyRate, numberOfPayments) - 1);
    
    return Math.round(payment * 100.0) / 100.0;
}
```

Remember: Good method documentation focuses on the **contract** (what the method promises to do), not the **implementation** (how it does it).

