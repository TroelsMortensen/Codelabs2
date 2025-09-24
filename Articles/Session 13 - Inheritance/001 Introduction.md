# Introduction to Inheritance

## What is Inheritance?

Inheritance is one of the fundamental concepts in object-oriented programming. It allows a class to inherit properties and methods from another class, creating a parent-child relationship between classes.

Think of inheritance like a family tree. Just as children inherit characteristics from their parents, classes can inherit features from other classes.

## Real-World Examples

### People and Professions
- **Person** (parent class)
  - **Student** (child class) - inherits basic person properties like name, age
  - **Teacher** (child class) - inherits basic person properties like name, age
  - **Doctor** (child class) - inherits basic person properties like name, age

### Animals
- **Bird** (parent class)
  - **Pigeon** (child class) - inherits bird properties like wings, ability to fly
  - **Eagle** (child class) - inherits bird properties like wings, ability to fly
  - **Penguin** (child class) - inherits bird properties but may not fly

### Shapes
- **Shape** (parent class)
  - **Square** (child class) - inherits shape properties like area calculation
  - **Triangle** (child class) - inherits shape properties like area calculation
  - **Circle** (child class) - inherits shape properties like area calculation

## Key Concepts

### Parent Class (Superclass)
- The class that is being inherited from
- Contains common properties and methods
- Also called the "base class" or "superclass"

### Child Class (Subclass)
- The class that inherits from another class
- Gets all the properties and methods from the parent
- Can add its own unique properties and methods
- Can override (replace) methods from the parent

## Benefits of Inheritance

1. **Code Reuse**: Write common code once in the parent class
2. **Consistency**: All child classes share the same interface
3. **Maintainability**: Changes to parent class affect all children
4. **Extensibility**: Easy to add new types without changing existing code

## Example Structure

```
Vehicle (parent)
├── Car (child)
├── Motorcycle (child)
└── Truck (child)
```

All vehicles might have:
- Engine
- Wheels
- Start method
- Stop method

But each type can have unique features:
- Car: 4 doors, air conditioning
- Motorcycle: 2 wheels, handlebars
- Truck: cargo bed, towing capacity

Inheritance helps us organize our code in a logical, hierarchical way that mirrors how we think about the real world.
