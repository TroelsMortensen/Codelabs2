# The `extends` Keyword

The `extends` keyword in Java is used to create an inheritance relationship between classes. It tells Java that one class inherits from another class.

## Syntax

```java
public class ChildClass extends ParentClass {
    // child class code
}
```

## Basic Example

This example shows an `Animal` class, and a `Dog` class, which extends the `Animal` class. `protected` is covered on the next page.

```java{16}
// Parent class
public class Animal {
    protected String name;
    protected int age;
    
    public void eat() {
        System.out.println(name + " is eating");
    }
    
    public void sleep() {
        System.out.println(name + " is sleeping");
    }
}

// Child class using extends
public class Dog extends Animal {
    private String breed;
    
    public void bark() {
        System.out.println(name + " is barking: Woof! Woof!");
    }
    
    public void fetch() {
        System.out.println(name + " is fetching the ball");
    }
}
```

The `Dog` class is now a subclass of the `Animal` class. Therefore, the `Dog` class will have all the fields and methods from the `Animal` class.

## How `extends` Works

### 1. **Inheritance of Fields**
The child class automatically gets all the (protected or public) fields from the parent class:

```java
public class Dog extends Animal {
    // Dog automatically has:
    // - String name (from Animal)
    // - int age (from Animal)
    // - String breed (its own field)
}
```

### 2. **Inheritance of Methods**
The child class automatically gets all the (protected or public) methods from the parent class:

```java
Dog myDog = new Dog();
myDog.name = "Buddy";
myDog.age = 3;

// These methods come from Animal class
myDog.eat();    // "Buddy is eating"
myDog.sleep();  // "Buddy is sleeping"

// This method is specific to Dog class
myDog.bark();   // "Buddy is barking: Woof! Woof!"
```

## Multiple Levels of Inheritance

You can extend a class that already extends another class:

```java
public class Animal {
    protected String name;
    
    public void eat() {
        System.out.println(name + " is eating");
    }
}

public class Mammal extends Animal {
    protected boolean hasFur;
    
    public void giveBirth() {
        System.out.println(name + " is giving birth");
    }
}

public class Dog extends Mammal {
    private String breed;
    
    public void bark() {
        System.out.println(name + " is barking");
    }
}
```

**Inheritance Chain:**
- `Dog` extends `Mammal`
- `Mammal` extends `Animal`
- So `Dog` inherits from both `Mammal` and `Animal`

```
Dog ──▷ Mammal ──▷ Animal
```

```java
Dog myDog = new Dog();
myDog.name = "Rex";

// Methods from Animal
myDog.eat();        // "Rex is eating"

// Methods from Mammal
myDog.giveBirth();  // "Rex is giving birth"

// Methods from Dog
myDog.bark();       // "Rex is barking"
```

## Complete Example

Remember, in Java, each class generally gets its own file. Below, it is just easier to have them in the same "file".

```java
// Parent class
public class Vehicle {
    protected String brand;
    protected int year;
    protected boolean isRunning;
    
    public Vehicle(String brand, int year) {
        this.brand = brand;
        this.year = year;
        this.isRunning = false;
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
        System.out.println("Brand: " + brand + ", Year: " + year);
    }
}

// Child class
public class Car extends Vehicle {
    private int numberOfDoors;
    private boolean hasAirConditioning;
    
    public Car(String brand, int year, int doors, boolean ac) {
        super(brand, year);  // Call parent constructor
        this.numberOfDoors = doors;
        this.hasAirConditioning = ac;
    }
    
    public void honk() {
        System.out.println(brand + " is honking: Beep! Beep!");
    }
    
    public void openTrunk() {
        System.out.println("Opening trunk of " + brand);
    }
    
    @Override
    public void displayInfo() {
        super.displayInfo();  // Call parent method
        System.out.println("Doors: " + numberOfDoors + ", AC: " + hasAirConditioning);
    }
}

// Usage
public class Main {
    public static void main(String[] args) {
        Car myCar = new Car("Toyota", 2023, 4, true);
        
        // Methods inherited from Vehicle
        myCar.start();        // "Toyota is starting"
        myCar.stop();         // "Toyota is stopping"
        
        // Methods specific to Car
        myCar.honk();         // "Toyota is honking: Beep! Beep!"
        myCar.openTrunk();    // "Opening trunk of Toyota"
        
        // Overridden method
        myCar.displayInfo();  // Shows both parent and child info
    }
}
```

## Key Points About `extends`

### 1. **Single Inheritance Only**
Java only allows a class to extend **one** parent class:

```java
// ✅ This is allowed
public class Dog extends Animal {
    // code
}

// ❌ This is NOT allowed
public class Dog extends Animal, Mammal {
    // code - ERROR!
}
```

### 2. **All Classes Extend Object**
If you don't specify `extends`, your class automatically extends `Object`:

```java
// These are equivalent:
public class MyClass {
    // code
}

public class MyClass extends Object {
    // code
}
```

This is also why your classes, by default, have a `toString()` method. And `equals()` and `hashCode()` methods. You have previously seen we could "overwrite" these methods to provide a more meaningful representation of your objects. This is discussed in an upcoming page about "overriding" methods.

## Summary

The `extends` keyword is the foundation of inheritance in Java:

1. **Creates parent-child relationships** between classes
2. **Enables code reuse** by inheriting fields and methods
3. **Supports multiple levels** of inheritance
4. **Allows single inheritance only** (one parent per class)

Understanding `extends` is crucial for building well-structured, maintainable Java programs using inheritance.
