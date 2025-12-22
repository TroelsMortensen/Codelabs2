# Introduction to the Law of Demeter

Welcome to the **Law of Demeter (LoD)**! Also known as the **Principle of Least Knowledge**, this is a design guideline that helps reduce coupling and create more maintainable code.

## What is the Law of Demeter?

The **Law of Demeter** states that an object should only talk to its **immediate friends**, not to friends of friends.

### The Core Rule

> **"Only talk to your immediate neighbors."**

An object should only call methods on:
1. **Itself** - Methods on the same object
2. **Objects passed as parameters** - Method parameters
3. **Objects it creates** - Objects created within the method
4. **Its direct component objects** - Objects stored in instance variables

An object should **NOT** call methods on objects returned by other method calls.

## The Formal Definition

More formally, the Law of Demeter states that a method `m` of an object `O` should only call methods of:
- `O` itself
- Objects passed as parameters to `m`
- Objects created within `m`
- Objects stored in instance variables of `O`
- Objects in global variables accessible by `O`

## The "Don't Talk to Strangers" Principle

A simpler way to remember it:

> **"Don't talk to strangers."**

You can talk to:
- Yourself
- Your friends (objects you know directly)
- Objects you create

You should **NOT** talk to:
- Friends of friends (objects returned by method calls)
- Strangers (objects you don't know directly)

## The Visual Metaphor

Think of it like a conversation:

### Good: Talking to Friends

```
You → Your Friend
"Can you help me?"
```

### Bad: Talking Through Friends

```
You → Your Friend → Friend's Friend
"Can you ask your friend to help me?"
```

In code, this becomes:

### Good: Direct Communication

```java
// You talk directly to the object you need
String city = order.getCustomerCity();
```

### Bad: Talking Through Chains

```java
// You talk through multiple objects
String city = order.getCustomer().getAddress().getCity();  // Chain!
```

## Why It Matters

The Law of Demeter helps you:

1. **Reduce Coupling** - Objects depend on fewer other objects
2. **Improve Encapsulation** - Internal structure is hidden
3. **Increase Flexibility** - Changes are isolated
4. **Improve Maintainability** - Code is easier to understand and modify

## Connection to Other Principles

The Law of Demeter relates to:

- **Coupling** - Reduces coupling by limiting dependencies
- **Encapsulation** - Preserves encapsulation by not exposing internal structure
- **Single Responsibility Principle** - Objects focus on their own responsibilities
- **Dependency Inversion Principle** - Encourages depending on abstractions

## The Classic Example

The most common violation is the "train wreck" or "chain of calls":

```java
// Violation: Chain of method calls
String city = order.getCustomer().getAddress().getCity();
//     ↑         ↑          ↑          ↑
//   result   method    method    method
//           call      call      call
```

This violates the Law of Demeter because:
- `order` calls `getCustomer()` (OK - immediate friend)
- Then calls `getAddress()` on the result (NOT OK - friend of friend)
- Then calls `getCity()` on that result (NOT OK - friend of friend of friend)

## Summary

The Law of Demeter:
- **Limits communication** - Only talk to immediate friends
- **Reduces coupling** - Fewer dependencies
- **Improves encapsulation** - Internal structure stays hidden
- **Prevents "train wrecks"** - Avoids long chains of method calls

In the following sections, we'll explore violations, solutions, and practical examples.

