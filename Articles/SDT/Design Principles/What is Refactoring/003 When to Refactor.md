# When to Refactor

Knowing when to refactor is as important as knowing how. Here are the key times to refactor.

## The "Rule of Three"

A simple guideline for when to refactor:

1. **First time:** Write the code
2. **Second time:** Notice the duplication
3. **Third time:** Refactor to remove it

### Example

```java
// First time: Write it
public void processOrder(Order order) {
    if (order.getTotal() > 1000) {
        applyDiscount(order);
    }
}

// Second time: Notice duplication
public void processPayment(Payment payment) {
    if (payment.getAmount() > 1000) {  // Same threshold!
        applyFee(payment);
    }
}

// Third time: Refactor
private static final double THRESHOLD = 1000.0;

public void processOrder(Order order) {
    if (order.getTotal() > THRESHOLD) {
        applyDiscount(order);
    }
}

public void processPayment(Payment payment) {
    if (payment.getAmount() > THRESHOLD) {
        applyFee(payment);
    }
}
```

## Before Adding Features

**Refactor before extending code.** Clean up the area you're about to modify.

### Example

```java
// You need to add email notification to order processing
// Before adding the feature, refactor the existing code:

// Current code (needs refactoring):
public void processOrder(Order order) {
    if (order.getTotal() > 1000) {
        applyDiscount(order);
    }
    calculateTax(order);
    saveOrder(order);
}

// Refactor first:
public void processOrder(Order order) {
    validateOrder(order);
    applyDiscounts(order);
    calculateTax(order);
    saveOrder(order);
}

// Then add the feature:
public void processOrder(Order order) {
    validateOrder(order);
    applyDiscounts(order);
    calculateTax(order);
    saveOrder(order);
    sendConfirmationEmail(order);  // New feature
}
```

**Why:** It's easier to add features to clean, well-structured code.

## After Fixing Bugs

**Refactor the area you just fixed.** Improve the code that had the bug.

### Example

```java
// You just fixed a bug in this method
public void calculateTotal(Order order) {
    double subtotal = 0;
    for (Item item : order.getItems()) {
        subtotal += item.getPrice();  // Bug: missing quantity
    }
    // Fixed:
    subtotal += item.getPrice() * item.getQuantity();
    return subtotal;
}

// Refactor to prevent future bugs:
public void calculateTotal(Order order) {
    double subtotal = calculateSubtotal(order);
    return subtotal;
}

private double calculateSubtotal(Order order) {
    return order.getItems().stream()
        .mapToDouble(item -> item.getPrice() * item.getQuantity())
        .sum();
}
```

**Why:** The area just had a bug - it likely needs improvement.

## When You See Code Smells

Refactor when you encounter common code smells:

### Long Methods

```java
// Smell: Method is 200 lines long
public void processOrder(Order order) {
    // 200 lines of code
}

// Refactor: Break it down
public void processOrder(Order order) {
    validateOrder(order);
    calculateTotals(order);
    applyDiscounts(order);
    saveOrder(order);
    sendConfirmation(order);
}
```

### Deep Nesting

```java
// Smell: Too many nested levels
public void process(Order order) {
    if (order != null) {
        if (order.getItems() != null) {
            if (!order.getItems().isEmpty()) {
                // Process
            }
        }
    }
}

// Refactor: Use guard clauses
public void process(Order order) {
    if (order == null) return;
    if (order.getItems() == null) return;
    if (order.getItems().isEmpty()) return;
    
    // Process
}
```

### Magic Numbers

```java
// Smell: Magic numbers
if (age >= 65) { }

// Refactor: Extract constant
private static final int SENIOR_CITIZEN_AGE = 65;
if (age >= SENIOR_CITIZEN_AGE) { }
```

### Duplication

```java
// Smell: Duplicated code
public void processOrder(Order order) {
    if (order.getTotal() > 1000) { }
}

public void processPayment(Payment payment) {
    if (payment.getAmount() > 1000) { }
}

// Refactor: Extract common logic
private static final double THRESHOLD = 1000.0;
```

## During Code Review

**Refactor issues found in code review** before merging.

### Common Review Comments

- "This method is too long" → Extract method
- "What does this number mean?" → Extract constant
- "This is duplicated" → Remove duplication
- "This class does too much" → Extract class

## When Understanding Code

**Refactor code you're trying to understand.** As you read and understand code, refactor it to make it clearer.

### Example

```java
// You're reading this to understand how it works:
public void process(Order o) {
    double t = 0;
    for (Item i : o.getItems()) {
        t += i.getPrice() * i.getQuantity();
    }
    if (t > 1000) {
        t = t * 0.9;
    }
    save(o, t);
}

// Refactor as you understand it:
public void processOrder(Order order) {
    double total = calculateSubtotal(order);
    if (exceedsDiscountThreshold(total)) {
        total = applyDiscount(total);
    }
    saveOrder(order, total);
}
```

**Why:** Refactoring helps you understand, and leaves the code better.

## The Boy Scout Rule

> **"Leave the code better than you found it."**

Every time you work on code:
- Fix at least one problem
- Improve at least one thing
- Don't make it worse

### Example

```java
// You're adding a feature to this class:
public class UserService {
    public void createUser(User user) {
        // TODO: Add validation  // Broken window!
        saveUser(user);
    }
}

// Apply Boy Scout Rule - fix the broken window:
public class UserService {
    public void createUser(User user) {
        validateUser(user);  // Fixed!
        saveUser(user);
    }
    
    private void validateUser(User user) {
        if (user == null) {
            throw new IllegalArgumentException("User cannot be null");
        }
    }
}
```

## When NOT to Refactor

Sometimes you should **not** refactor:

### Don't Refactor "Just Because"

- Don't refactor code that works and won't be touched
- Don't refactor everything you see
- Don't refactor without tests

### Don't Refactor During Feature Development

- Don't mix refactoring with adding features
- Either add features OR refactor, not both
- Use the "Two Hats" approach

### Don't Refactor Without Tests

- Always have tests before refactoring
- Tests ensure behavior doesn't change
- Without tests, refactoring is risky

## Summary

Refactor when:

1. **Rule of Three** - Same pattern appears three times
2. **Before adding features** - Clean up first
3. **After fixing bugs** - Improve the area
4. **Code smells appear** - Long methods, duplication, etc.
5. **During code review** - Fix issues found
6. **When understanding code** - Make it clearer as you learn
7. **Boy Scout Rule** - Leave it better than you found it

Don't refactor:
- Code that works and won't be touched
- Without tests
- While adding features (use separate commits)

**The key:** Refactor continuously, in small steps, with tests.

