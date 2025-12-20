# Example - Order Processing

Let's see a complete example of transforming a chain (rabbit hole) into orchestrated code (orchestrator pattern).

## The Chain (Violation)

Here's a method that processes orders using chaining. Notice how you have to dig deep to understand what happens:

```java
// ❌ THE CHAIN (Bad)
// You have to dig 3 layers deep to know what happens.

public void processOrder(Order order) {
    validate(order);  // Looks innocent...
}

private void validate(Order order) {
    if (order.isValid()) {
        save(order);  // Wait, validation saves?
    }
}

private void save(Order order) {
    db.insert(order);
    sendEmail(order);  // Wait, saving sends emails?
}

private void sendEmail(Order order) {
    emailService.sendConfirmation(order);
}
```


## Step-by-Step Refactoring

### Step 1: Make Helpers Return Values

**Before:**
```java
private void validate(Order order) {
    if (order.isValid()) {
        save(order);  // Calls next method
    }
}
```

**After:**
```java
private boolean validate(Order order) {
    return order.isValid();  // Returns value, doesn't call next
}
```

This breaks the chain - `validate()` no longer calls `save()`.

### Step 2: Remove Hidden Side Effects

**Before:**
```java
private void save(Order order) {
    db.insert(order);
    sendEmail(order);  // Hidden side effect
}
```

**After:**
```java
private void save(Order order) {
    db.insert(order);  // Just saves, returns result
}
```

This removes the hidden side effect - `save()` no longer sends emails.

### Step 3: Create the Orchestrator

**Before:**
```java
public void processOrder(Order order) {
    validate(order);  // Loses control here
}
```

**After:**
```java
public void processOrder(Order order) {
    // Step 1: Validation
    boolean isValid = validate(order);
    if (!isValid) return;
    
    // Step 2: Persistence
    Order savedOrder = save(order);
    
    // Step 3: Notification
    sendConfirmationEmail(savedOrder);
}
```

This creates the orchestrator - all steps visible, control maintained.


## Summary

This example demonstrates:
- **Transforming a 3-level chain into 1-level orchestration**
- **Making helpers return values** instead of calling next
- **Removing hidden side effects** from helper methods
- **Creating a visible flow** in the orchestrator
- **Improving testability** through isolation
- **Maintaining control** at the surface level

The code went from a deep rabbit hole to a clear orchestrator pattern. You can see the entire flow at the top level, and each step can be tested and understood independently.

## Connection to Mountains and Islands

This principle works hand-in-hand with "Make Islands, Not Mountains":

- **Mountains** = Deep nesting (vertical complexity) → Solved by creating islands
- **Chains** = Deep call stacks (horizontal complexity) → Solved by orchestration
- **Islands** = Flat methods (low altitude) → Each helper is an island
- **Orchestration** = Shallow stacks (helicopter view) → Orchestrator hovers above islands

Together, these principles help you create code that is:
- **Flat** (islands, not mountains)
- **Visible** (orchestration, not chains)
- **Testable** (isolated steps)
- **Maintainable** (clear flow)

Remember: **Keep your code at the surface. Be an orchestrator, not a chain link!**

