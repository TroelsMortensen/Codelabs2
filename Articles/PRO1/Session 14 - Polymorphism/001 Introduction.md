# Introduction to Polymorphism

Welcome to **Polymorphism**! This is one of the four fundamental principles of object-oriented programming, and it's where inheritance really shows its power.

## What is Polymorphism?

**Polymorphism** comes from Greek and means "many forms." In Java, it refers to the ability of objects of different types to be treated as objects of a common type, while each object behaves differently based on its actual type.

In short, we can treat subclasses as their superclass, and the subclasses will behave differently based on their actual type. Similar things behave differently.

## The Core Idea

Polymorphism allows you to write code that works with a superclass type, but the actual behavior depends on the specific subclass that's being used. The same method call can produce different results depending on the actual object type.

## Key Concepts

### 1. Reference Type vs Object Type

The type of the variable (reference type) and the type of the actual object (object type) can be different, as long as the object type is a subclass of the reference type.

```java
Animal animal = new Dog("Buddy");
// Reference type: Animal (the variable type)
// Object type: Dog (the actual object type)
```

### 2. Method Resolution

The method that gets called depends on the **object type** (runtime type), not the reference type (compile-time type). Java finds the most specific implementation in the class hierarchy.

```java
Animal animal = new Dog("Buddy");
animal.makeSound();  // Calls Dog's makeSound(), not Animal's
```

Java searches from the object's class upward in the hierarchy until it finds an implementation.

### 3. Access Limitations

You can only call methods that are available in the reference type, not methods specific to the object type.

```java
Animal animal = new Dog("Buddy");
animal.makeSound();  // ✅ OK - makeSound() is in Animal
// animal.fetch();   // ❌ ERROR - fetch() is not in Animal
```

Even though the object is actually a `Dog`, you can only access methods defined in the `Animal` class through the `Animal` reference.

## Why Polymorphism Matters

Polymorphism provides:
- **Flexibility** - One method can work with many different types
- **Code reuse** - Write code once, use it with different object types
- **Maintainability** - Easy to add new types without changing existing code

## What's Next?

In the next section, we'll see polymorphism in action with both regular inheritance and abstract classes. We'll also see how polymorphism works with collections and method parameters.

Note: Later in the course, you'll learn that interfaces also enable polymorphism, providing even more flexibility. For now, we'll focus on polymorphism with inheritance and abstract classes.
