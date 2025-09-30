# Interface vs Abstract Class

## The Key Differences

Understanding when to use interfaces versus abstract classes is crucial for good object-oriented design. Both serve similar purposes but have important differences that affect when and how you should use them.

## Comparison Table

| Feature | Abstract Class | Interface |
|---------|----------------|-----------|
| **Instantiation** | Cannot be instantiated | Cannot be instantiated |
| **Fields** | Can have instance variables | Only constants (public static final) |
| **Constructors** | Can have constructors | Cannot have constructors |
| **Methods** | Can have concrete and abstract methods | Only abstract methods (by default) |
| **Inheritance** | Single inheritance (extends one class) | Multiple inheritance (implements many interfaces) |
| **Access Modifiers** | Can have private, protected, public | All methods are public (by default) |
| **Purpose** | Share common implementation | Define contracts |

## When to Use Abstract Classes

### ✅ Use Abstract Classes When:

1. **You want to share common implementation**
```java
public abstract class Vehicle {
    protected String brand;
    protected int year;
    
    public Vehicle(String brand, int year) {
        this.brand = brand;
        this.year = year;
    }
    
    // Common implementation shared by all vehicles
    public void start() {
        System.out.println(brand + " is starting");
    }
    
    // Abstract method - must be implemented by subclasses
    public abstract void accelerate();
}

public class Car extends Vehicle {
    public Car(String brand, int year) {
        super(brand, year);
    }
    
    @Override
    public void accelerate() {
        System.out.println("Car is accelerating");
    }
}
```

2. **You have common state (fields)**
```java
public abstract class Employee {
    protected String name;
    protected double salary;
    
    public Employee(String name, double salary) {
        this.name = name;
        this.salary = salary;
    }
    
    // Common method using shared state
    public void displayInfo() {
        System.out.println("Name: " + name + ", Salary: " + salary);
    }
    
    public abstract void work();
}
```

3. **You want to provide a template method pattern**

This is an "advanced topic", but the core point is that you need to execute certain steps in a specific order. For example, you might need to validate the input, process the data, and format the output. You can define the order in an abstract class, and then let the subclasses implement the steps.

Next semester, you will learn about Design Patterns.

```java
public abstract class DataProcessor {
    protected String inputData;
    
    // Template method - defines the algorithm
    public final void process() {
        validateInput();
        processData();
        formatOutput();
    }
    
    // Abstract methods - must be implemented
    protected abstract void validateInput();
    protected abstract void processData();
    protected abstract void formatOutput();
}
```

## When to Use Interfaces

### ✅ Use Interfaces When:

1. **You want to define a contract**
```java
public interface Drawable {
    void draw();
    void setColor(String color);
}

public interface Movable {
    void move(int x, int y);
}

// A class can implement multiple interfaces
public class Circle implements Drawable, Movable {
    private String color;
    private int x, y;
    
    @Override
    public void draw() {
        System.out.println("Drawing circle at (" + x + ", " + y + ")");
    }
    
    @Override
    public void setColor(String color) {
        this.color = color;
    }
    
    @Override
    public void move(int x, int y) {
        this.x = x;
        this.y = y;
    }
}
```

2. **You need multiple inheritance**
```java
public interface Flyable {
    void fly();
}

public interface Swimmable {
    void swim();
}

public interface Walkable {
    void walk();
}

public class Duck implements Flyable, Swimmable, Walkable {
    @Override
    public void fly() {
        System.out.println("Duck is flying");
    }
    
    @Override
    public void swim() {
        System.out.println("Duck is swimming");
    }
    
    @Override
    public void walk() {
        System.out.println("Duck is walking");
    }
}
```

3. **You want loose coupling**
```java
public interface PaymentProcessor {
    boolean processPayment(double amount);
    String getPaymentMethod();
}

public class CreditCardProcessor implements PaymentProcessor {
    @Override
    public boolean processPayment(double amount) {
        // Credit card processing logic
        return true;
    }
    
    @Override
    public String getPaymentMethod() {
        return "Credit Card";
    }
}

public class PayPalProcessor implements PaymentProcessor {
    @Override
    public boolean processPayment(double amount) {
        // PayPal processing logic
        return true;
    }
    
    @Override
    public String getPaymentMethod() {
        return "PayPal";
    }
}

// The Order class depends on the interface, not concrete implementations
public class Order {
    private PaymentProcessor processor;
    
    public Order(PaymentProcessor processor) {
        this.processor = processor;
    }
    
    public boolean checkout(double amount) {
        return processor.processPayment(amount);
    }
}
```


## Why not both?

You can actually have a class, which both extends a class and implements an interface. It looks like below, first the inheritance is declared, then the interfaces.

```java
public class Duck extends Animal implements Flyable, Swimmable, Walkable {
    @Override
    public void fly() {
        System.out.println("Duck is flying");
    }
}
```

## Decision Guidelines

### Choose Abstract Class When:
- You want to share common implementation
- You have common state (fields) that subclasses need
- You want to provide a template method pattern
- You need constructors to initialize common state
- You want to control access with private/protected members

### Choose Interface When:
- You want to define a contract without implementation
- You need multiple inheritance
- You want loose coupling between components
- You're defining capabilities that unrelated classes might have
- You want to enable polymorphism across different class hierarchies

## Summary

Both abstract classes and interfaces are powerful tools:

- **Abstract classes** are great for sharing common implementation and state
- **Interfaces** are perfect for defining contracts and enabling multiple inheritance
- **Often, the best design uses both** - interfaces for contracts and abstract classes for common implementation

The key is to choose the right tool for the right job based on your specific requirements and design goals.
