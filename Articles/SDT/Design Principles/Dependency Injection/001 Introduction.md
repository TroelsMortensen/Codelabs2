# Introduction to Dependency Injection

Welcome to **Dependency Injection (DI)**! This is a fundamental technique in software design that helps you create flexible, testable, and maintainable code.

## What is Dependency Injection?

**Dependency Injection** is a design pattern where an object receives its dependencies from an external source rather than creating them itself.

### The Core Idea

Instead of a class creating its own dependencies (using `new`), dependencies are **injected** into the class from the outside. The class doesn't know how to create its dependencies - it only knows how to use them.

## The Problem: Direct Dependencies

Without dependency injection, classes create their own dependencies:

```java
// Bad: Class creates its own dependencies
public class UserService {
    private Database database;
    
    public UserService() {
        this.database = new PostgreSQLDatabase();  // Creates dependency itself
    }
    
    public void saveUser(User user) {
        database.save(user);
    }
}
```

**Problems:**
- **Hard to test** - Cannot replace database with a mock
- **Tight coupling** - Tightly coupled to `PostgreSQLDatabase`
- **Hard to change** - Must modify code to switch databases
- **Violates Dependency Inversion Principle** - Depends on concrete class, not abstraction

## The Solution: Dependency Injection

With dependency injection, dependencies are provided from outside:

```java
// Good: Dependencies are injected
public class UserService {
    private Database database;  // Interface, not concrete class
    
    public UserService(Database database) {  // Dependency injected via constructor
        this.database = database;
    }
    
    public void saveUser(User user) {
        database.save(user);
    }
}
```

**Benefits:**
- **Easy to test** - Can inject a mock database
- **Loose coupling** - Depends on interface, not implementation
- **Easy to change** - Can swap implementations without modifying code
- **Follows Dependency Inversion Principle** - Depends on abstraction

## The Visual Metaphor

Think of dependency injection like a lamp:

### Without Dependency Injection (Hardwired)

```
Lamp → Hardwired directly into wall
- Cannot move lamp to another room
- Cannot test lamp without wall wiring
- Cannot use lamp with battery
```

### With Dependency Injection (Plugged In)

```
Lamp → Plug → Wall Outlet (Production)
Lamp → Plug → Battery Pack (Testing)
- Can move lamp anywhere
- Can test lamp independently
- Can use different power sources
```

## Connection to SOLID Principles

Dependency Injection is closely related to SOLID:

### Dependency Inversion Principle (D)

**DIP states:** High-level modules should not depend on low-level modules. Both should depend on abstractions.

Dependency Injection is the **primary mechanism** for achieving DIP. By injecting dependencies through interfaces, you invert the dependency direction.

```java
// High-level module (UserService) depends on abstraction (Database interface)
// Low-level module (PostgreSQLDatabase) implements the abstraction
public class UserService {
    private Database database;  // Abstraction
    
    public UserService(Database database) {
        this.database = database;  // Injected dependency
    }
}
```

### Single Responsibility Principle (S)

Dependency Injection helps maintain SRP by allowing classes to focus on their core responsibility without worrying about creating dependencies.

### Open/Closed Principle (O)

With DI, you can extend functionality by injecting different implementations without modifying existing code.

### Interface Segregation Principle (I)

DI encourages using focused interfaces, as you inject specific interfaces rather than large, fat ones.

## Why Dependency Injection Matters

Dependency Injection provides:

1. **Testability** - The #1 reason. You can inject mocks for testing
2. **Flexibility** - Easy to swap implementations
3. **Maintainability** - Changes are isolated
4. **Loose Coupling** - Classes depend on abstractions
5. **Reusability** - Classes can be used in different contexts

## Summary

Dependency Injection is:
- **A pattern** - Dependencies are provided from outside
- **A technique** - For achieving loose coupling
- **A practice** - That enables testability and flexibility
- **A mechanism** - For implementing Dependency Inversion Principle

In the following sections, we'll explore how to implement dependency injection, different injection methods, and see practical examples.

