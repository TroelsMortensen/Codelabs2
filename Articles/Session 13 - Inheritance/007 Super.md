# The `super` Keyword

## What is `super`?

The `super` keyword in Java is used to refer to the parent class from within a child class. It allows you to access parent class members and call parent class methods and constructors.

## Uses of `super`

### 1. **Calling Parent Constructor**
### 2. **Accessing Parent Class Methods**
### 3. **Accessing Parent Class Fields**

## 1. Calling Parent Constructor

The most common use of `super` is to call the parent class constructor:

```java
class Animal {
    protected String name;
    protected int age;
    
    public Animal(String name, int age) {
        this.name = name;
        this.age = age;
        System.out.println("Animal constructor called");
    }
}

class Dog extends Animal {
    private String breed;
    
    public Dog(String name, int age, String breed) {
        super(name, age);  // Call parent constructor
        this.breed = breed;
        System.out.println("Dog constructor called");
    }
}
```

**Usage:**
```java
Dog myDog = new Dog("Buddy", 3, "Golden Retriever");
// Output:
// Animal constructor called
// Dog constructor called
```

### Important Rules for `super()`:

1. **Must be the first statement** in the constructor
2. **Must match a parent constructor** (same parameters)
3. **If not called explicitly**, Java calls `super()` with no parameters

```java
class Child extends Parent {
    public Child() {
        // super(); // Java automatically adds this if you don't
        // other code
    }
}
```

## 2. Accessing Parent Class Methods

Use `super` to call parent class methods, especially when overriding:

```java
class Animal {
    protected String name;
    
    public void eat() {
        System.out.println(name + " is eating");
    }
    
    public void sleep() {
        System.out.println(name + " is sleeping");
    }
}

class Dog extends Animal {
    public void eat() {
        System.out.println(name + " is eating dog food");
    }
    
    public void doDailyRoutine() {
        super.eat();    // Call parent's eat() method
        this.eat();     // Call current class's eat() method
        super.sleep();  // Call parent's sleep() method
    }
}
```

**Usage:**
```java
Dog myDog = new Dog();
myDog.name = "Rex";
myDog.doDailyRoutine();

// Output:
// Rex is eating
// Rex is eating dog food
// Rex is sleeping
```

## 3. Accessing Parent Class Fields

Use `super` to access parent class fields when there might be naming conflicts:

```java
class Animal {
    protected String name = "Animal";
}

class Dog extends Animal {
    protected String name = "Dog";
    
    public void showNames() {
        System.out.println("Child name: " + this.name);    // "Dog"
        System.out.println("Parent name: " + super.name);  // "Animal"
    }
}
```

## Complete Example

```java
class Vehicle {
    protected String brand;
    protected int year;
    protected boolean isRunning;
    
    public Vehicle(String brand, int year) {
        this.brand = brand;
        this.year = year;
        this.isRunning = false;
        System.out.println("Vehicle created: " + brand + " " + year);
    }
    
    public void start() {
        isRunning = true;
        System.out.println(brand + " is starting");
    }
    
    public void stop() {
        isRunning = false;
        System.out.println(brand + " is stopping");
    }
    
    public void displayInfo() {
        System.out.println("Vehicle Info - Brand: " + brand + ", Year: " + year);
    }
}

class Car extends Vehicle {
    private int numberOfDoors;
    private boolean hasAirConditioning;
    
    public Car(String brand, int year, int doors, boolean ac) {
        super(brand, year);  // Call parent constructor
        this.numberOfDoors = doors;
        this.hasAirConditioning = ac;
        System.out.println("Car created with " + doors + " doors");
    }
    
    public void honk() {
        System.out.println(brand + " is honking: Beep! Beep!");
    }
    
    @Override
    public void displayInfo() {
        super.displayInfo();  // Call parent method first
        System.out.println("Car Info - Doors: " + numberOfDoors + 
                          ", AC: " + hasAirConditioning);
    }
    
    public void start() {
        super.start();  // Call parent start method
        System.out.println("Car engine is warming up");
    }
}

// Usage
public class Main {
    public static void main(String[] args) {
        Car myCar = new Car("Toyota", 2023, 4, true);
        
        System.out.println("\n--- Starting the car ---");
        myCar.start();
        
        System.out.println("\n--- Displaying info ---");
        myCar.displayInfo();
        
        System.out.println("\n--- Honking ---");
        myCar.honk();
    }
}
```

**Output:**
```
Vehicle created: Toyota 2023
Car created with 4 doors

--- Starting the car ---
Toyota is starting
Car engine is warming up

--- Displaying info ---
Vehicle Info - Brand: Toyota, Year: 2023
Car Info - Doors: 4, AC: true

--- Honking ---
Toyota is honking: Beep! Beep!
```

## Multiple Levels of Inheritance

When you have multiple levels, `super` always refers to the immediate parent:

```java
class Animal {
    protected String name;
    
    public Animal(String name) {
        this.name = name;
    }
    
    public void eat() {
        System.out.println(name + " is eating");
    }
}

class Mammal extends Animal {
    public Mammal(String name) {
        super(name);
    }
    
    public void giveBirth() {
        System.out.println(name + " is giving birth");
    }
}

class Dog extends Mammal {
    public Dog(String name) {
        super(name);  // Calls Mammal constructor
    }
    
    public void bark() {
        System.out.println(name + " is barking");
    }
    
    public void doEverything() {
        super.eat();        // Calls Mammal's eat() (which is Animal's eat())
        super.giveBirth();  // Calls Mammal's giveBirth()
        this.bark();        // Calls Dog's bark()
    }
}
```

## Common Patterns with `super`

### 1. **Constructor Chaining**
```java
class Parent {
    public Parent(String name) {
        this.name = name;
    }
}

class Child extends Parent {
    public Child(String name, int age) {
        super(name);  // Must call parent constructor
        this.age = age;
    }
}
```

### 2. **Method Overriding with Extension**
```java
class Parent {
    public void doSomething() {
        System.out.println("Parent doing something");
    }
}

class Child extends Parent {
    @Override
    public void doSomething() {
        super.doSomething();  // Do what parent does
        System.out.println("Child doing something extra");  // Add more
    }
}
```

### 3. **Accessing Hidden Fields**
```java
class Parent {
    protected int value = 10;
}

class Child extends Parent {
    protected int value = 20;
    
    public void showValues() {
        System.out.println("Child value: " + this.value);   // 20
        System.out.println("Parent value: " + super.value); // 10
    }
}
```

## Important Rules and Notes

### 1. **`super()` Must Be First**
```java
class Child extends Parent {
    public Child() {
        // Do something first - ERROR!
        super();  // Must be first statement
    }
}
```

### 2. **`super` vs `this`**
- `super` refers to the parent class
- `this` refers to the current class

```java
class Child extends Parent {
    public void method() {
        super.method();  // Parent's method
        this.method();   // Current class's method (same as just method())
    }
}
```

### 3. **Static Methods**
You cannot use `super` in static methods because `super` refers to an instance:

```java
class Child extends Parent {
    public static void staticMethod() {
        // super.instanceMethod(); // ERROR! Cannot use super in static context
    }
}
```

## Summary

The `super` keyword is essential for inheritance in Java:

1. **`super()`** - Calls parent constructor (must be first in constructor)
2. **`super.method()`** - Calls parent class method
3. **`super.field`** - Accesses parent class field
4. **Always refers to immediate parent** in inheritance chain
5. **Cannot be used in static methods**
6. **Enables proper constructor chaining** and method overriding

Understanding `super` is crucial for building proper inheritance hierarchies and maintaining the relationship between parent and child classes.
