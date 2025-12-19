# Chaining - The Rabbit Hole

Let's examine what "chaining" looks like in code and understand why it creates a "Rabbit Hole" problem.

## What is Chaining?

**Chaining** occurs when methods call each other in sequence, passing control down a chain:

```java
Method A → calls → Method B → calls → Method C → calls → Method D
```

To understand what `Method A` does, you must follow the entire chain down to `Method D`. This is like falling down a rabbit hole - you keep going deeper and deeper.

## The Visual: Falling Dominoes

Chaining is like a line of falling dominoes:

```
[Method A] → [Method B] → [Method C] → [Method D]
    ↓           ↓           ↓           ↓
  Push        Falls       Falls       Falls
```

You push the first one (call Method A), and you lose control until the last one falls. You can't see what will happen until you follow the entire chain.

## Example: The Rabbit Hole

Here's a common example of chaining:

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

## The Problem: Hidden Flow

When you read `processOrder()`, it looks simple:
- "Oh, it just validates the order."

But to understand what actually happens, you must:
1. Look at `validate()` - "It validates and then saves?"
2. Look at `save()` - "It saves and then sends an email?"
3. Look at `sendEmail()` - "Finally, the actual email sending"

You've fallen down a rabbit hole - three levels deep just to understand what `processOrder()` does!

## Problems Caused by Chaining

### 1. Temporal Coupling

**Temporal coupling** means methods depend on being called in a specific order, but this dependency is hidden in the chain.

In the example above:
- `validate()` must be called before `save()`
- `save()` must be called before `sendEmail()`
- But this dependency is hidden - `processOrder()` doesn't show it

If someone refactors and changes the chain, the order might break.

### 2. Hard to Test in Isolation

You cannot test `validate()` without triggering the entire chain:

```java
@Test
public void testValidate() {
    Order order = new Order();
    processor.validate(order);  // This also saves and sends email!
    // How do you test just validation?
}
```

You can't test validation without:
- Setting up a database
- Setting up an email service
- Dealing with side effects

### 3. Hidden Side Effects

A method that looks innocent might trigger unexpected side effects:

```java
public void validate(Order order) {
    if (order.isValid()) {
        save(order);  // Hidden: This also sends an email!
    }
}
```

From the name `validate()`, you'd expect it to only validate. But it also saves and sends emails!

### 4. Loss of Control

Once you call the first method, you lose control:

```java
public void processOrder(Order order) {
    validate(order);  // Control is lost here
    // Can't stop the chain
    // Can't skip steps
    // Can't handle errors between steps
}
```

You can't:
- Stop after validation if you want
- Skip saving if needed
- Handle errors between steps
- See what's happening at each step

### 5. Deep Call Stacks

Chaining creates deep call stacks:

```
processOrder()        (Level 0)
  → validate()        (Level 1)
    → save()          (Level 2)
      → sendEmail()   (Level 3)
```

This makes debugging harder - you must navigate through multiple stack frames.

### 6. Hard to Understand the Full Flow

To understand the complete operation, you must:
- Read `processOrder()`
- Follow to `validate()`
- Follow to `save()`
- Follow to `sendEmail()`
- Remember all the steps
- Understand how they connect

This is mentally exhausting!

## Connection to Mountains and Islands

If we use the topographical map analogy from the Mountains and Islands principle:

**Chaining is "Island Hopping":**
- You swim to Island A
- Once there, you find a map telling you to swim to Island B
- On Island B, you find a map telling you to swim to Island C
- You can't see the destination from the start
- You must visit each island to know where to go next

This is like following a chain of method calls - you can't see the full journey until you've made it.

## Real-World Example

Here's another common chaining pattern:

```java
public void handleUserRegistration(String username, String email, String password) {
    createUser(username, email, password);
}

private void createUser(String username, String email, String password) {
    User user = new User(username, email, password);
    saveUser(user);
}

private void saveUser(User user) {
    userRepository.save(user);
    sendWelcomeEmail(user);  // Hidden side effect!
    logRegistration(user);   // Another hidden side effect!
}

private void sendWelcomeEmail(User user) {
    emailService.send(user);
}

private void logRegistration(User user) {
    logger.log("User registered: " + user.getUsername());
}
```

**Problems:**
- `handleUserRegistration()` looks simple but does 4 things
- `createUser()` doesn't just create - it also saves and sends emails
- `saveUser()` doesn't just save - it also sends emails and logs
- Can't test creation without triggering emails and logging
- Can't see the full flow without reading 4 methods

## Recognizing Chaining

Signs that you have chaining:

1. **Method A calls B, B calls C, C calls D** - Deep call chains
2. **Can't see the full flow** - Must read multiple methods to understand
3. **Hidden side effects** - Methods do more than their names suggest
4. **Hard to test** - Can't test one method without triggering the chain
5. **Loss of control** - Once you call the first method, you lose control
6. **Temporal coupling** - Order matters but isn't visible

## The Rabbit Hole Effect

When you have chaining:
1. You start at the surface (Method A)
2. You fall down one level (Method B)
3. You fall down another level (Method C)
4. You keep falling (Method D, E, F...)
5. You lose track of where you started
6. You can't see the big picture

This is the "Rabbit Hole" - you keep going deeper and deeper, losing sight of the surface.

## Summary

Chaining is characterized by:
- **Method calls method calls method** - Deep call chains
- **Hidden flow** - Must follow chain to see what happens
- **Temporal coupling** - Order dependencies are hidden
- **Hard to test** - Can't test in isolation
- **Hidden side effects** - Methods do more than expected
- **Loss of control** - Can't control the sequence

The deeper the chain, the deeper the rabbit hole, and the harder it is to understand and maintain the code. Next, we'll learn how to transform chains into orchestrated code.

