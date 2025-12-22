# Common Refactoring Techniques

Here are some of the most common and useful refactoring techniques you'll use regularly.

## Extract Method

**Problem:** A method is too long or does too many things.

**Solution:** Extract part of the method into a separate method.

### Example

```java
// Before: Long method
public void processOrder(Order order) {
    // Validation
    if (order == null) {
        throw new IllegalArgumentException("Order cannot be null");
    }
    if (order.getItems().isEmpty()) {
        throw new IllegalArgumentException("Order must have items");
    }
    if (order.getTotal() <= 0) {
        throw new IllegalArgumentException("Order total must be positive");
    }
    
    // Processing
    calculateTax(order);
    applyDiscount(order);
    saveOrder(order);
}

// After: Extracted validation
public void processOrder(Order order) {
    validateOrder(order);
    calculateTax(order);
    applyDiscount(order);
    saveOrder(order);
}

private void validateOrder(Order order) {
    if (order == null) {
        throw new IllegalArgumentException("Order cannot be null");
    }
    if (order.getItems().isEmpty()) {
        throw new IllegalArgumentException("Order must have items");
    }
    if (order.getTotal() <= 0) {
        throw new IllegalArgumentException("Order total must be positive");
    }
}
```

## Extract Variable (Introduce Explaining Variable)

**Problem:** A complex expression is hard to understand.

**Solution:** Extract the expression into a well-named variable.

### Example

```java
// Before: Magic number and complex expression
public void applyDiscount(Order order) {
    if (order.getTotal() > 1000 && order.getCustomer().getMembershipLevel() == MembershipLevel.PREMIUM) {
        order.setDiscount(0.1);
    }
}

// After: Extracted variables
private static final double DISCOUNT_THRESHOLD = 1000.0;
private static final double DISCOUNT_RATE = 0.1;

public void applyDiscount(Order order) {
    boolean exceedsThreshold = order.getTotal() > DISCOUNT_THRESHOLD;
    boolean isPremiumMember = order.getCustomer().getMembershipLevel() == MembershipLevel.PREMIUM;
    
    if (exceedsThreshold && isPremiumMember) {
        order.setDiscount(DISCOUNT_RATE);
    }
}
```

## Rename Variable/Method

**Problem:** A name doesn't clearly express what it does.

**Solution:** Rename it to something more descriptive.

### Example

```java
// Before: Unclear name
public void process(Order o) {
    double t = calculateTotal(o);
    save(o, t);
}

// After: Clear names
public void processOrder(Order order) {
    double total = calculateTotal(order);
    saveOrder(order, total);
}
```

## Extract Constant

**Problem:** Magic numbers or strings appear in code.

**Solution:** Extract them into named constants.

### Example

```java
// Before: Magic numbers
public void calculateShipping(Order order) {
    if (order.getWeight() > 10) {
        return order.getWeight() * 0.5;
    }
    return order.getWeight() * 0.3;
}

// After: Named constants
private static final double HEAVY_PACKAGE_WEIGHT_KG = 10.0;
private static final double HEAVY_SHIPPING_RATE = 0.5;
private static final double STANDARD_SHIPPING_RATE = 0.3;

public void calculateShipping(Order order) {
    if (order.getWeight() > HEAVY_PACKAGE_WEIGHT_KG) {
        return order.getWeight() * HEAVY_SHIPPING_RATE;
    }
    return order.getWeight() * STANDARD_SHIPPING_RATE;
}
```

## Remove Dead Code

**Problem:** Code that is no longer used.

**Solution:** Delete it.

### Example

```java
// Before: Dead code
public class UserService {
    public void createUser(User user) {
        saveUser(user);
    }
    
    // Dead code - never called
    public void oldCreateUser(User user) {
        // 50 lines of old implementation
    }
}

// After: Removed
public class UserService {
    public void createUser(User user) {
        saveUser(user);
    }
}
```

## Extract Class

**Problem:** A class has too many responsibilities.

**Solution:** Extract some responsibilities into a new class.

### Example

```java
// Before: Class does too much
public class Order {
    private String id;
    private List<Item> items;
    private Customer customer;
    
    // Order data
    public String getId() { return id; }
    
    // Order calculation (should be separate)
    public double calculateTotal() {
        double subtotal = items.stream()
            .mapToDouble(item -> item.getPrice() * item.getQuantity())
            .sum();
        return subtotal * 1.1; // Tax
    }
    
    // Order validation (should be separate)
    public boolean isValid() {
        return items != null && !items.isEmpty() && customer != null;
    }
}

// After: Extracted responsibilities
public class Order {
    private String id;
    private List<Item> items;
    private Customer customer;
    
    public String getId() { return id; }
    // Just data
}

public class OrderCalculator {
    public double calculateTotal(Order order) {
        double subtotal = order.getItems().stream()
            .mapToDouble(item -> item.getPrice() * item.getQuantity())
            .sum();
        return subtotal * 1.1;
    }
}

public class OrderValidator {
    public boolean isValid(Order order) {
        return order.getItems() != null 
            && !order.getItems().isEmpty() 
            && order.getCustomer() != null;
    }
}
```

## Replace Magic Number with Constant

**Problem:** Numbers appear in code without explanation.

**Solution:** Replace with named constants.

### Example

```java
// Before: Magic number
public boolean isEligibleForDiscount(User user) {
    return user.getAge() >= 65;
}

// After: Named constant
private static final int SENIOR_CITIZEN_AGE = 65;

public boolean isEligibleForDiscount(User user) {
    return user.getAge() >= SENIOR_CITIZEN_AGE;
}
```

## Simplify Conditional

**Problem:** Complex if-else statements are hard to understand.

**Solution:** Simplify using early returns, guard clauses, or extract methods.

### Example

```java
// Before: Nested conditionals
public void processOrder(Order order) {
    if (order != null) {
        if (order.getItems() != null) {
            if (!order.getItems().isEmpty()) {
                // Process order
                saveOrder(order);
            }
        }
    }
}

// After: Guard clauses (early returns)
public void processOrder(Order order) {
    if (order == null) return;
    if (order.getItems() == null) return;
    if (order.getItems().isEmpty()) return;
    
    // Process order
    saveOrder(order);
}
```

## Move Method

**Problem:** A method is in the wrong class.

**Solution:** Move it to a more appropriate class.

### Example

```java
// Before: Method in wrong class
public class Order {
    private Customer customer;
    
    public String getCustomerFullName() {  // Should be in Customer
        return customer.getFirstName() + " " + customer.getLastName();
    }
}

// After: Moved to correct class
public class Customer {
    private String firstName;
    private String lastName;
    
    public String getFullName() {
        return firstName + " " + lastName;
    }
}
```

## Summary

Common refactoring techniques:

1. **Extract Method** - Break down long methods
2. **Extract Variable** - Make expressions clear
3. **Rename** - Use descriptive names
4. **Extract Constant** - Remove magic numbers
5. **Remove Dead Code** - Delete unused code
6. **Extract Class** - Separate responsibilities
7. **Simplify Conditional** - Make logic clear
8. **Move Method** - Put code in the right place

These techniques help you improve code structure while maintaining behavior.

