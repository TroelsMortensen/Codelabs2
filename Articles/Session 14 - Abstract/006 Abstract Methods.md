# Abstract Methods

## What are Abstract Methods?

An **abstract method** is a method that is declared but not implemented in an abstract class. It has no body and must be implemented by any concrete subclass that extends the abstract class.

Think of abstract methods as "contracts" - they tell subclasses what they must do, but not how to do it.

## Syntax of Abstract Methods

### Basic Syntax
```java
abstract class Shape {
    // Abstract method - no implementation
    public abstract double getArea();
    
    // Abstract method - no implementation
    public abstract double getPerimeter();
    
    // Concrete method - has implementation
    public void displayInfo() {
        System.out.println("Area: " + getArea());
        System.out.println("Perimeter: " + getPerimeter());
    }
}
```

### Key Points:
- **No method body** - Ends with semicolon, no curly braces
- **Must be in abstract class** - Cannot have abstract methods in concrete classes
- **Must be implemented** - Subclasses must provide implementation
- **Can have access modifiers** - public, protected, package-private

## Implementing Abstract Methods

### Example: Shape Hierarchy

```java
abstract class Shape {
    protected double x, y;
    
    public Shape(double x, double y) {
        this.x = x;
        this.y = y;
    }
    
    // Abstract methods - must be implemented
    public abstract double getArea();
    public abstract double getPerimeter();
    public abstract void draw();
    
    // Concrete method - shared by all shapes
    public void move(double newX, double newY) {
        this.x = newX;
        this.y = newY;
    }
    
    public String getPosition() {
        return "(" + x + ", " + y + ")";
    }
}

class Rectangle extends Shape {
    private double width, height;
    
    public Rectangle(double x, double y, double width, double height) {
        super(x, y);
        this.width = width;
        this.height = height;
    }
    
    // Must implement all abstract methods
    @Override
    public double getArea() {
        return width * height;
    }
    
    @Override
    public double getPerimeter() {
        return 2 * (width + height);
    }
    
    @Override
    public void draw() {
        System.out.println("Drawing rectangle at " + getPosition() + 
                         " with width " + width + " and height " + height);
    }
}

class Circle extends Shape {
    private double radius;
    
    public Circle(double x, double y, double radius) {
        super(x, y);
        this.radius = radius;
    }
    
    // Must implement all abstract methods
    @Override
    public double getArea() {
        return Math.PI * radius * radius;
    }
    
    @Override
    public double getPerimeter() {
        return 2 * Math.PI * radius;
    }
    
    @Override
    public void draw() {
        System.out.println("Drawing circle at " + getPosition() + 
                         " with radius " + radius);
    }
}
```

## Abstract Methods with Parameters

### Example: Animal Hierarchy

```java
abstract class Animal {
    protected String name;
    protected int age;
    
    public Animal(String name, int age) {
        this.name = name;
        this.age = age;
    }
    
    // Abstract methods with parameters
    public abstract void makeSound(String intensity);
    public abstract void move(String direction);
    public abstract void eat(String food);
    
    // Concrete method
    public void sleep() {
        System.out.println(name + " is sleeping");
    }
}

class Dog extends Animal {
    private String breed;
    
    public Dog(String name, int age, String breed) {
        super(name, age);
        this.breed = breed;
    }
    
    @Override
    public void makeSound(String intensity) {
        switch (intensity.toLowerCase()) {
            case "loud":
                System.out.println(name + " barks loudly: WOOF! WOOF!");
                break;
            case "quiet":
                System.out.println(name + " whimpers softly: woof...");
                break;
            default:
                System.out.println(name + " barks: Woof! Woof!");
        }
    }
    
    @Override
    public void move(String direction) {
        System.out.println(name + " runs " + direction + " on four legs");
    }
    
    @Override
    public void eat(String food) {
        System.out.println(name + " eagerly devours " + food);
    }
}

class Cat extends Animal {
    private boolean isIndoor;
    
    public Cat(String name, int age, boolean isIndoor) {
        super(name, age);
        this.isIndoor = isIndoor;
    }
    
    @Override
    public void makeSound(String intensity) {
        switch (intensity.toLowerCase()) {
            case "loud":
                System.out.println(name + " meows loudly: MEOOW! MEOOW!");
                break;
            case "quiet":
                System.out.println(name + " purrs softly: purr... purr...");
                break;
            default:
                System.out.println(name + " meows: Meow! Meow!");
        }
    }
    
    @Override
    public void move(String direction) {
        if (isIndoor) {
            System.out.println(name + " walks " + direction + " around the house");
        } else {
            System.out.println(name + " prowls " + direction + " in the garden");
        }
    }
    
    @Override
    public void eat(String food) {
        System.out.println(name + " delicately nibbles on " + food);
    }
}
```

## Abstract Methods with Return Types

### Example: Calculator System

```java
abstract class Calculator {
    protected double result;
    
    public Calculator() {
        this.result = 0;
    }
    
    // Abstract methods with different return types
    public abstract double calculate(double a, double b);
    public abstract String getOperationName();
    public abstract boolean isValidInput(double a, double b);
    
    // Concrete method
    public void displayResult() {
        System.out.println(getOperationName() + " result: " + result);
    }
}

class AdditionCalculator extends Calculator {
    @Override
    public double calculate(double a, double b) {
        result = a + b;
        return result;
    }
    
    @Override
    public String getOperationName() {
        return "Addition";
    }
    
    @Override
    public boolean isValidInput(double a, double b) {
        return true; // Addition works with any numbers
    }
}

class DivisionCalculator extends Calculator {
    @Override
    public double calculate(double a, double b) {
        if (isValidInput(a, b)) {
            result = a / b;
            return result;
        } else {
            throw new IllegalArgumentException("Cannot divide by zero");
        }
    }
    
    @Override
    public String getOperationName() {
        return "Division";
    }
    
    @Override
    public boolean isValidInput(double a, double b) {
        return b != 0; // Cannot divide by zero
    }
}
```

## Using Abstract Methods

### Polymorphism with Abstract Methods

```java
public class Main {
    public static void main(String[] args) {
        // Create different shapes
        Shape[] shapes = {
            new Rectangle(0, 0, 5, 3),
            new Circle(0, 0, 2),
            new Rectangle(10, 10, 4, 6)
        };
        
        // Polymorphism: same method calls, different behaviors
        for (Shape shape : shapes) {
            shape.draw();  // Each shape draws itself differently
            System.out.println("Area: " + shape.getArea());
            System.out.println("Perimeter: " + shape.getPerimeter());
            System.out.println("---");
        }
        
        // Create different animals
        Animal[] animals = {
            new Dog("Buddy", 3, "Golden Retriever"),
            new Cat("Whiskers", 2, true),
            new Dog("Rex", 5, "German Shepherd")
        };
        
        // Polymorphism: same method calls, different behaviors
        for (Animal animal : animals) {
            animal.makeSound("loud");
            animal.move("forward");
            animal.eat("treats");
            System.out.println("---");
        }
    }
}
```

## Rules for Abstract Methods

### 1. **Must be in Abstract Class**
```java
// ❌ ERROR - Cannot have abstract methods in concrete class
class ConcreteClass {
    public abstract void method();  // Compilation error
}

// ✅ CORRECT - Abstract methods must be in abstract class
abstract class AbstractClass {
    public abstract void method();  // OK
}
```

### 2. **Must be Implemented by Subclasses**
```java
abstract class Parent {
    public abstract void method();
}

// ❌ ERROR - Must implement abstract method
class Child extends Parent {
    // Missing implementation of method()
}

// ✅ CORRECT - Must implement abstract method
class Child extends Parent {
    @Override
    public void method() {
        System.out.println("Implementation");
    }
}
```

### 3. **Cannot be Static**
```java
abstract class Example {
    // ❌ ERROR - Abstract methods cannot be static
    public abstract static void method();
}
```

### 4. **Cannot be Private**
```java
abstract class Example {
    // ❌ ERROR - Abstract methods cannot be private
    private abstract void method();
}
```

## Benefits of Abstract Methods

### 1. **Forces Implementation**
Ensures all subclasses implement required functionality.

### 2. **Defines Contracts**
Clearly specifies what subclasses must do.

### 3. **Enables Polymorphism**
Allows different implementations to be treated uniformly.

### 4. **Improves Maintainability**
Changes to abstract methods automatically affect all subclasses.

## Summary

Abstract methods are powerful tools that:

- **Define contracts** that subclasses must follow
- **Force implementation** of specific functionality
- **Enable polymorphism** through method overriding
- **Improve code organization** and maintainability

In the next article, we'll see how to represent abstract classes and methods in UML diagrams using Mermaid.
