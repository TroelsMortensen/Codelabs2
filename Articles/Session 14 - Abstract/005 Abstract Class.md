# Abstract Classes

## What is an Abstract Class?

An **abstract class** in Java is a class that cannot be instantiated directly. It serves as a blueprint or template for other classes and often contains abstract methods that must be implemented by subclasses.

Think of an abstract class like a recipe template - you can't eat the template itself, but it tells you how to build the actual dish.

## Creating Abstract Classes

### The `abstract` Keyword

Use the `abstract` keyword to declare an abstract class:

```java
abstract class Shape {
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
```java
abstract class Employee {
    protected String name;
    protected int employeeId;
    protected double salary;
    
    public Employee(String name, int employeeId, double salary) {
        this.name = name;
        this.employeeId = employeeId;
        this.salary = salary;
    }
    
    public abstract void work();
    public abstract void takeBreak();
}
```

## Extending Abstract Classes

### Creating Concrete Subclasses

```java
class Rectangle extends Shape {
    private double width, height;
    
    public Rectangle(double x, double y, double width, double height) {
        super(x, y);  // Call parent constructor
        this.width = width;
        this.height = height;
    }
    
    // Must implement abstract method
    @Override
    public double getArea() {
        return width * height;
    }
}

class Circle extends Shape {
    private double radius;
    
    public Circle(double x, double y, double radius) {
        super(x, y);  // Call parent constructor
        this.radius = radius;
    }
    
    // Must implement abstract method
    @Override
    public double getArea() {
        return Math.PI * radius * radius;
    }
}
```

### Using Abstract Classes

```java
public class Main {
    public static void main(String[] args) {
        // Can't instantiate abstract class directly
        // Shape shape = new Shape(0, 0);  // ❌ ERROR!
        
        // But can instantiate concrete subclasses
        Shape rectangle = new Rectangle(0, 0, 5, 3);
        Shape circle = new Circle(0, 0, 2);
        
        // Can call both abstract and concrete methods
        System.out.println("Rectangle area: " + rectangle.getArea());
        System.out.println("Circle area: " + circle.getArea());
        
        // Can call concrete methods
        rectangle.move(10, 10);
        circle.move(5, 5);
        
        System.out.println("Rectangle position: " + rectangle.getPosition());
        System.out.println("Circle position: " + circle.getPosition());
    }
}
```

## Real-World Example: Game Characters

```java
abstract class GameCharacter {
    protected String name;
    protected int health;
    protected int level;
    protected boolean isAlive;
    
    public GameCharacter(String name, int health, int level) {
        this.name = name;
        this.health = health;
        this.level = level;
        this.isAlive = true;
    }
    
    // Abstract methods - must be implemented by subclasses
    public abstract void attack();
    public abstract void defend();
    public abstract void specialAbility();
    
    // Concrete methods - shared by all characters
    public void takeDamage(int damage) {
        health -= damage;
        if (health <= 0) {
            health = 0;
            isAlive = false;
        }
        System.out.println(name + " takes " + damage + " damage. Health: " + health);
    }
    
    public void heal(int amount) {
        if (isAlive) {
            health += amount;
            System.out.println(name + " heals for " + amount + ". Health: " + health);
        }
    }
    
    public boolean isAlive() {
        return isAlive;
    }
    
    public void levelUp() {
        if (isAlive) {
            level++;
            health += 10;
            System.out.println(name + " leveled up to level " + level + "!");
        }
    }
}

class Warrior extends GameCharacter {
    private int strength;
    
    public Warrior(String name, int health, int level, int strength) {
        super(name, health, level);
        this.strength = strength;
    }
    
    @Override
    public void attack() {
        int damage = strength + level;
        System.out.println(name + " swings sword for " + damage + " damage!");
    }
    
    @Override
    public void defend() {
        System.out.println(name + " raises shield and blocks incoming attacks!");
    }
    
    @Override
    public void specialAbility() {
        System.out.println(name + " uses Berserker Rage! Attack power doubled!");
        strength *= 2;
    }
}

class Mage extends GameCharacter {
    private int mana;
    
    public Mage(String name, int health, int level, int mana) {
        super(name, health, level);
        this.mana = mana;
    }
    
    @Override
    public void attack() {
        if (mana >= 10) {
            int damage = level * 3;
            mana -= 10;
            System.out.println(name + " casts fireball for " + damage + " damage! Mana: " + mana);
        } else {
            System.out.println(name + " doesn't have enough mana to cast spells!");
        }
    }
    
    @Override
    public void defend() {
        System.out.println(name + " creates a magical barrier!");
    }
    
    @Override
    public void specialAbility() {
        System.out.println(name + " casts Meteor! Devastating area damage!");
        mana -= 20;
    }
}
```

## When to Use Abstract Classes

### ✅ Good Use Cases:

1. **Shared Implementation** - When subclasses share common code
2. **Common State** - When subclasses need access to shared fields
3. **Template Methods** - When you want to define a skeleton algorithm
4. **Forced Implementation** - When you want to ensure certain methods are implemented

### ❌ Avoid When:

1. **Only Data Sharing** - If you only need to share data, use regular classes
2. **Multiple Inheritance** - Java doesn't support multiple inheritance for classes
3. **Interface-like Behavior** - If you only need method signatures, consider interfaces

## Benefits of Abstract Classes

### 1. **Code Reuse**
```java
// Common functionality is written once
public void takeDamage(int damage) {
    health -= damage;
    if (health <= 0) {
        health = 0;
        isAlive = false;
    }
}
```

### 2. **Consistency**
All subclasses follow the same basic structure and behavior.

### 3. **Flexibility**
Subclasses can add their own unique features while maintaining the common interface.

### 4. **Maintainability**
Changes to the abstract class automatically affect all subclasses.

## Summary

Abstract classes are powerful tools that allow you to:

- **Define common structure** for related classes
- **Share implementation** among subclasses
- **Force specific behavior** through abstract methods
- **Create flexible, maintainable code**

In the next article, we'll dive deeper into abstract methods and see how they work in detail.
