# Example: Refactoring in Practice

A complete example showing the refactoring process from messy code to clean code.

## The Starting Point: Messy Code

```java
// Initial code - works but has problems
public class OrderProcessor {
    public void process(Order o) {
        if (o != null) {
            if (o.getItems() != null) {
                if (!o.getItems().isEmpty()) {
                    double t = 0;
                    for (Item i : o.getItems()) {
                        t += i.getPrice() * i.getQuantity();
                    }
                    if (t > 1000) {
                        t = t * 0.9;
                    }
                    double tax = t * 0.1;
                    double final = t + tax;
                    Database db = new PostgreSQLDatabase();
                    db.save("orders", o.getId(), final);
                    EmailService email = new GmailEmailService();
                    email.send(o.getCustomer().getEmail(), "Order processed: " + final);
                }
            }
        }
    }
}
```

**Problems:**
- Deep nesting (hard to read)
- Magic numbers (1000, 0.9, 0.1)
- Poor variable names (o, t, i, final)
- Mixed responsibilities (calculation, persistence, email)
- Direct dependencies (creates database and email service)
- Long method (does too much)

## Step 1: Extract Variables and Constants

```java
public class OrderProcessor {
    private static final double DISCOUNT_THRESHOLD = 1000.0;
    private static final double DISCOUNT_RATE = 0.9;
    private static final double TAX_RATE = 0.1;
    
    public void process(Order order) {
        if (order != null) {
            if (order.getItems() != null) {
                if (!order.getItems().isEmpty()) {
                    double subtotal = 0;
                    for (Item item : order.getItems()) {
                        subtotal += item.getPrice() * item.getQuantity();
                    }
                    double total = subtotal;
                    if (total > DISCOUNT_THRESHOLD) {
                        total = total * DISCOUNT_RATE;
                    }
                    double tax = total * TAX_RATE;
                    double finalTotal = total + tax;
                    Database db = new PostgreSQLDatabase();
                    db.save("orders", order.getId(), finalTotal);
                    EmailService email = new GmailEmailService();
                    email.send(order.getCustomer().getEmail(), "Order processed: " + finalTotal);
                }
            }
        }
    }
}
```

**Improvements:**
- Extracted constants (magic numbers removed)
- Better variable names (order, subtotal, total, finalTotal)

## Step 2: Simplify Conditionals (Guard Clauses)

```java
public class OrderProcessor {
    private static final double DISCOUNT_THRESHOLD = 1000.0;
    private static final double DISCOUNT_RATE = 0.9;
    private static final double TAX_RATE = 0.1;
    
    public void process(Order order) {
        if (order == null) return;
        if (order.getItems() == null) return;
        if (order.getItems().isEmpty()) return;
        
        double subtotal = 0;
        for (Item item : order.getItems()) {
            subtotal += item.getPrice() * item.getQuantity();
        }
        double total = subtotal;
        if (total > DISCOUNT_THRESHOLD) {
            total = total * DISCOUNT_RATE;
        }
        double tax = total * TAX_RATE;
        double finalTotal = total + tax;
        Database db = new PostgreSQLDatabase();
        db.save("orders", order.getId(), finalTotal);
        EmailService email = new GmailEmailService();
        email.send(order.getCustomer().getEmail(), "Order processed: " + finalTotal);
    }
}
```

**Improvements:**
- Flattened nesting (guard clauses)
- Easier to read

## Step 3: Extract Methods

```java
public class OrderProcessor {
    private static final double DISCOUNT_THRESHOLD = 1000.0;
    private static final double DISCOUNT_RATE = 0.9;
    private static final double TAX_RATE = 0.1;
    
    public void process(Order order) {
        if (order == null) return;
        if (order.getItems() == null) return;
        if (order.getItems().isEmpty()) return;
        
        double subtotal = calculateSubtotal(order);
        double total = applyDiscount(subtotal);
        double finalTotal = addTax(total);
        saveOrder(order, finalTotal);
        sendConfirmation(order, finalTotal);
    }
    
    private double calculateSubtotal(Order order) {
        double subtotal = 0;
        for (Item item : order.getItems()) {
            subtotal += item.getPrice() * item.getQuantity();
        }
        return subtotal;
    }
    
    private double applyDiscount(double subtotal) {
        if (subtotal > DISCOUNT_THRESHOLD) {
            return subtotal * DISCOUNT_RATE;
        }
        return subtotal;
    }
    
    private double addTax(double total) {
        return total + (total * TAX_RATE);
    }
    
    private void saveOrder(Order order, double finalTotal) {
        Database db = new PostgreSQLDatabase();
        db.save("orders", order.getId(), finalTotal);
    }
    
    private void sendConfirmation(Order order, double finalTotal) {
        EmailService email = new GmailEmailService();
        email.send(order.getCustomer().getEmail(), "Order processed: " + finalTotal);
    }
}
```

**Improvements:**
- Extracted methods (each does one thing)
- Main method reads like a story
- Methods are testable independently

## Step 4: Extract Classes and Use Dependency Injection

```java
// Extracted calculation logic
public class OrderCalculator {
    private static final double DISCOUNT_THRESHOLD = 1000.0;
    private static final double DISCOUNT_RATE = 0.9;
    private static final double TAX_RATE = 0.1;
    
    public double calculateTotal(Order order) {
        double subtotal = calculateSubtotal(order);
        double total = applyDiscount(subtotal);
        return addTax(total);
    }
    
    private double calculateSubtotal(Order order) {
        return order.getItems().stream()
            .mapToDouble(item -> item.getPrice() * item.getQuantity())
            .sum();
    }
    
    private double applyDiscount(double subtotal) {
        if (subtotal > DISCOUNT_THRESHOLD) {
            return subtotal * DISCOUNT_RATE;
        }
        return subtotal;
    }
    
    private double addTax(double total) {
        return total + (total * TAX_RATE);
    }
}

// Main processor with dependency injection
public class OrderProcessor {
    private final OrderCalculator calculator;
    private final OrderRepository repository;
    private final EmailService emailService;
    
    public OrderProcessor(OrderCalculator calculator, OrderRepository repository, EmailService emailService) {
        this.calculator = calculator;
        this.repository = repository;
        this.emailService = emailService;
    }
    
    public void process(Order order) {
        if (order == null) return;
        if (order.getItems() == null || order.getItems().isEmpty()) return;
        
        double finalTotal = calculator.calculateTotal(order);
        repository.save(order, finalTotal);
        emailService.sendConfirmation(order, finalTotal);
    }
}
```

**Improvements:**
- Extracted `OrderCalculator` class (single responsibility)
- Dependency injection (loose coupling, testable)
- Clean, focused `OrderProcessor`
- Follows SOLID principles

## The Result: Clean, Maintainable Code

### Before vs After

**Before:**
- 1 class, 1 long method
- Deep nesting
- Magic numbers
- Poor names
- Mixed responsibilities
- Direct dependencies
- Hard to test

**After:**
- 2 focused classes
- Flat structure
- Named constants
- Clear names
- Single responsibilities
- Injected dependencies
- Easy to test

### Benefits

1. **Readable** - Code tells a clear story
2. **Testable** - Can test each part independently
3. **Maintainable** - Easy to modify
4. **Flexible** - Can swap implementations
5. **Follows SOLID** - Single responsibility, dependency inversion

## Key Takeaways

This example shows:

1. **Refactoring is incremental** - Small steps, not big rewrites
2. **Each step improves something** - Constants, names, structure
3. **Tests ensure safety** - Behavior doesn't change
4. **End result is much better** - Clean, maintainable code

**Remember:** Refactoring is about improving structure while maintaining behavior. The code does the same thing, but it's much better organized.

