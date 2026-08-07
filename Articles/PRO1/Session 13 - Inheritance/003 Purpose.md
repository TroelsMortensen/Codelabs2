# Purpose and Benefits of Inheritance

Why Use Inheritance?

Inheritance serves several important purposes in object-oriented programming. Understanding these benefits helps you know when and why to use inheritance in your programs.

## Primary Purposes

### 1. Code Reuse
**Problem**: Without inheritance, you'd have to write the same code multiple times.

**Example**: Consider a program with different types of vehicles:

```java
// Without inheritance - lots of duplicate code
class Car {
    private String brand;
    private int year;
    private boolean isRunning;
    
    public void start() { isRunning = true; }
    public void stop() { isRunning = false; }
    public void honk() { System.out.println("Beep beep!"); }
}

class Motorcycle {
    private String brand;  // Duplicate
    private int year;      // Duplicate
    private boolean isRunning; // Duplicate
    
    public void start() { isRunning = true; } // Duplicate
    public void stop() { isRunning = false; } // Duplicate
    public void rev() { System.out.println("Vroom!"); }
}
```

**Solution**: With inheritance, common code is written once.\
Notice the `extends` keyword. This is used to indicate that the `Car` and `Motorcycle` classes inherit from the `Vehicle` class. It is explained further on a later page.\
Notice also the `protected` keyword. This is also explained further on a later page.

```java
// With inheritance - no duplicate code
class Vehicle {
    protected String brand;
    protected int year;
    protected boolean isRunning;
    
    public void start() { isRunning = true; }
    public void stop() { isRunning = false; }
}

class Car extends Vehicle {
    public void honk() { System.out.println("Beep beep!"); }
}

class Motorcycle extends Vehicle {
    public void rev() { System.out.println("Vroom!"); }
}
```

### 2. Consistency
All classes in an inheritance hierarchy share the same "interface" for common operations, i.e. the methods that are defined in the superclass.

**Example**: All vehicles can start and stop the same way:
```java
Vehicle car = new Car();
Vehicle motorcycle = new Motorcycle();

car.start();        // Works the same way
motorcycle.start(); // Works the same way
```

### 3. Maintainability
Changes to the parent class automatically affect all child classes.

**Example**: If you need to add a `fuelLevel` property to all vehicles:
- **Without inheritance**: Update every vehicle class individually
- **With inheritance**: Add it once to the `Vehicle` class

### 4. Extensibility
Easy to add new types without modifying existing code.

**Example**: Adding a new `Truck` class:
```java
class Truck extends Vehicle {
    public void loadCargo() { 
        System.out.println("Loading cargo..."); 
    }
}
```

No changes needed to existing `Car` or `Motorcycle` classes!

## Benefits in Detail

### 1. **Reduced Code Duplication**
- Write common functionality once in the parent class
- Child classes inherit this functionality automatically
- Less code to write, test, and maintain

### 2. **Hierarchical Organization**
- Reflects real-world relationships
- Makes code easier to understand
- Provides logical structure to your program

### 4. **Specialization**
- Child classes can add specific features
- Each class can have unique behavior
- Maintains the common interface from parent

## Summary

Inheritance is a powerful tool that helps you:
1. **Write less code** by reusing common functionality
2. **Maintain consistency** across related classes
3. **Make changes easily** by updating parent classes
4. **Extend functionality** without breaking existing code
5. **Organize code logically** to match real-world relationships

The key is to use inheritance when it makes sense conceptually and provides real benefits to your code structure and maintainability.
