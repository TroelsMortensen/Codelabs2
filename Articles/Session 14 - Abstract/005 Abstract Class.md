# Abstract Classes

## What is an Abstract Class?

An **abstract class** in Java is a class that cannot be instantiated directly. It serves as a blueprint, or template, for other classes and often contains abstract methods that must be implemented by subclasses.\
Abstract classes only make sense, if they are extended by other classes.

For example, a `Vehicle` class is abstract, because you cannot create a `Vehicle` object. You can only create a `Car`, `Motorcycle`, `Bicycle`, or `Boat` object.


## Creating Abstract Classes

### The `abstract` Keyword

Use the `abstract` keyword to declare an abstract class, in the class declaration. Abstact methods are discussed on the next page, so ignore those for now.

```java
public abstract class Shape {
    // position in 2D space
    protected double x, y;
    
    public Shape(double x, double y) {
        this.x = x;
        this.y = y;
    }
    
    // Abstract method - must be implemented by subclasses
    public abstract double getArea();
    
    // Concrete method - can be used by all subclasses
    public void move(double newX, double newY) {
        this.x = newX;
        this.y = newY;
    }
    
    public String getPosition() {
        return "(" + x + ", " + y + ")";
    }
}
```

## Key Characteristics of Abstract Classes

### 1. **Cannot be Instantiated**
```java
// This will cause a compilation error
Shape shape = new Shape(0, 0);  // ❌ ERROR!
```

### 2. **Can Have Constructors**
```java
abstract class Animal {
    protected String name;
    
    public Animal(String name) {  // Constructor is allowed
        this.name = name;
    }
    
    public abstract void makeSound();
}
```

### 3. **Can Have Both Abstract and Concrete Methods**

Concrete methods are methods that have a body, i.e. they are implemented.

Abstract methods are methods that have no body, i.e. they are not implemented. Notice that the `accelerate` method is abstract, and does not have a body. There are no `{ }` after the method name, instead there is a semicolon `;`.

```java
abstract class Vehicle {
    protected String brand;
    protected boolean isRunning;
    
    public Vehicle(String brand) {
        this.brand = brand;
        this.isRunning = false;
    }
    
    // Abstract method - must be implemented
    public abstract void accelerate();
    
    // Concrete method - shared by all subclasses
    public void start() {
        isRunning = true;
        System.out.println(brand + " is starting");
    }
    
    public void stop() {
        isRunning = false;
        System.out.println(brand + " is stopping");
    }
}
```

### 4. **Can Have Fields**
The abstract class can have fields, just like a regular class. These can be both public, protected, or private.

```java
abstract class Employee {
    protected String name;
    protected int employeeId;
    protected double salary;
    private String department;
    
    public Employee(String name, int employeeId, double salary, String department) {
        this.name = name;
        this.employeeId = employeeId;
        this.salary = salary;
        this.department = department;
    }
    
    public abstract void work();
    public abstract void takeBreak();
}
```


## When to Use Abstract Classes

### ✅ Good Use Cases:

1. **Shared Implementation** - When subclasses share common code
2. **Common State** - When subclasses need access to shared fields
3. **Template Methods** - When you want to define a skeleton algorithm
4. **Forced Implementation** - When you want to ensure certain methods are implemented
5. **No objects should be created from this class** - When you want to prevent objects from being created from this class

