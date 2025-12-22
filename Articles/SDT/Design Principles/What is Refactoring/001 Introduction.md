# Introduction to Refactoring

Welcome to **Refactoring**! This is a fundamental practice in software development that helps you maintain and improve code quality over time.

## What is Refactoring?

**Refactoring** is the process of improving the internal structure of code **without changing its external behavior**.

### The Core Idea

Refactoring means:
- **Improving code structure** - Making code cleaner, more readable, better organized
- **Without changing behavior** - The code does exactly the same thing before and after
- **Improving design** - Making code easier to understand, modify, and extend

## The Definition

Martin Fowler, in his book *Refactoring*, defines it as:

> **"Refactoring is a disciplined technique for restructuring an existing body of code, altering its internal structure without changing its external behavior."**

## What Refactoring Is NOT

It's important to understand what refactoring is not:

### Refactoring ≠ Adding Features

```java
// This is NOT refactoring - it adds new functionality
public class UserService {
    public void createUser(User user) {
        saveUser(user);
        sendWelcomeEmail(user);  // NEW FEATURE - not refactoring
    }
}
```

### Refactoring ≠ Fixing Bugs

```java
// This is NOT refactoring - it fixes a bug
public void calculateTotal(Order order) {
    // Before: Bug - missing tax
    double total = order.getSubtotal();
    
    // After: Bug fix - includes tax
    double total = order.getSubtotal() + order.getTax();  // BUG FIX
}
```

### Refactoring = Improving Structure

```java
// This IS refactoring - improves structure, same behavior
// Before:
public void processOrder(Order order) {
    if (order.getTotal() > 1000) {
        applyDiscount(order);
    }
}

// After:
private static final double DISCOUNT_THRESHOLD = 1000.0;

public void processOrder(Order order) {
    if (order.getTotal() > DISCOUNT_THRESHOLD) {
        applyDiscount(order);
    }
}
// Same behavior, better structure
```

## Why Refactor?

Refactoring helps you:

1. **Improve Readability** - Code becomes easier to understand
2. **Reduce Complexity** - Simplify complex code
3. **Improve Maintainability** - Make future changes easier
4. **Remove Duplication** - Eliminate copy-paste code
5. **Improve Design** - Apply design principles (SOLID, etc.)
6. **Reduce Technical Debt** - Pay down accumulated problems

## When to Refactor

### The "Rule of Three"

Refactor when you see the same pattern three times:
- First time: Write it
- Second time: Notice the duplication
- Third time: Refactor to remove it

### Common Triggers

- **Code smells** - Long methods, deep nesting, magic numbers
- **Duplication** - Copy-paste code appears
- **Complexity** - Code is hard to understand
- **Before adding features** - Clean up code before extending it
- **After fixing bugs** - Improve the area you just fixed
- **During code review** - Address issues found in review

## The Two Hats

Kent Beck describes the "Two Hats" metaphor:

1. **Adding Functionality Hat** - Write new features, fix bugs
2. **Refactoring Hat** - Improve code structure

**Important:** Don't wear both hats at once. Either add functionality OR refactor, not both in the same commit.

## Connection to Design Principles

Refactoring is how you apply design principles:

- **SOLID Principles** - Refactor to achieve Single Responsibility, Open/Closed, etc.
- **Coupling and Cohesion** - Refactor to reduce coupling, increase cohesion
- **Broken Window Principle** - Refactor to fix broken windows
- **Mountains and Islands** - Refactor to flatten nested code

## Summary

Refactoring is:
- **Improving code structure** without changing behavior
- **A disciplined practice** with specific techniques
- **Essential for maintainability** - Keeps code clean over time
- **Not adding features** - That's a different activity
- **Not fixing bugs** - That's also different

In the following sections, we'll explore common refactoring techniques and see practical examples.

