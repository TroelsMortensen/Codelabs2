# Polymorphism

## What is Polymorphism?

Polymorphism is one of the four fundamental principles of object-oriented programming. The word "polymorphism" comes from Greek and means "many forms." In programming, it refers to the ability of objects of different types to be treated as objects of a common type, while each object can behave differently based on its actual type.

## Types of Polymorphism

### 1. **Compile-time Polymorphism (Method Overloading)**
### 2. **Runtime Polymorphism (Method Overriding)**

This chapter focuses on **runtime polymorphism** through inheritance and method overriding.

## Basic Polymorphism Example

```java
class Animal {
    protected String name;
    
    public Animal(String name) {
        this.name = name;
    }
    
    public void makeSound() {
        System.out.println(name + " makes a sound");
    }
    
    public void eat() {
        System.out.println(name + " is eating");
    }
}

class Dog extends Animal {
    public Dog(String name) {
        super(name);
    }
    
    @Override
    public void makeSound() {
        System.out.println(name + " barks: Woof! Woof!");
    }
    
    public void fetch() {
        System.out.println(name + " is fetching the ball");
    }
}

class Cat extends Animal {
    public Cat(String name) {
        super(name);
    }
    
    @Override
    public void makeSound() {
        System.out.println(name + " meows: Meow! Meow!");
    }
    
    public void climb() {
        System.out.println(name + " is climbing the tree");
    }
}
```

## Polymorphism in Action

```java
public class Main {
    public static void main(String[] args) {
        // Create objects of different types
        Animal animal1 = new Dog("Buddy");
        Animal animal2 = new Cat("Whiskers");
        Animal animal3 = new Animal("Generic Animal");
        
        // Polymorphism: same method call, different behaviors
        animal1.makeSound();  // "Buddy barks: Woof! Woof!"
        animal2.makeSound();  // "Whiskers meows: Meow! Meow!"
        animal3.makeSound();  // "Generic Animal makes a sound"
        
        // All animals can eat (inherited method)
        animal1.eat();  // "Buddy is eating"
        animal2.eat();  // "Whiskers is eating"
        animal3.eat();  // "Generic Animal is eating"
    }
}
```

## Key Concepts

### 1. **Reference Type vs Object Type**
```java
Animal animal = new Dog("Buddy");
// Reference type: Animal
// Object type: Dog
```

### 2. **Method Resolution**
The method that gets called depends on the **object type** (runtime type), not the reference type:

```java
Animal animal = new Dog("Buddy");
animal.makeSound();  // Calls Dog's makeSound(), not Animal's
```

### 3. **Access to Methods**
You can only call methods that are available in the reference type:

```java
Animal animal = new Dog("Buddy");
animal.makeSound();  // ✅ OK - makeSound() is in Animal
// animal.fetch();   // ❌ ERROR - fetch() is not in Animal
```

## Polymorphism with Collections

```java
import java.util.ArrayList;
import java.util.List;

public class Main {
    public static void main(String[] args) {
        List<Animal> animals = new ArrayList<>();
        
        // Add different types of animals
        animals.add(new Dog("Buddy"));
        animals.add(new Cat("Whiskers"));
        animals.add(new Animal("Generic"));
        animals.add(new Dog("Rex"));
        animals.add(new Cat("Fluffy"));
        
        // Polymorphism: same method call, different behaviors
        for (Animal animal : animals) {
            animal.makeSound();
        }
        
        // Output:
        // Buddy barks: Woof! Woof!
        // Whiskers meows: Meow! Meow!
        // Generic makes a sound
        // Rex barks: Woof! Woof!
        // Fluffy meows: Meow! Meow!
    }
}
```

## Polymorphism with Methods

```java
class Animal {
    protected String name;
    
    public Animal(String name) {
        this.name = name;
    }
    
    public void makeSound() {
        System.out.println(name + " makes a sound");
    }
}

class Dog extends Animal {
    public Dog(String name) {
        super(name);
    }
    
    @Override
    public void makeSound() {
        System.out.println(name + " barks: Woof! Woof!");
    }
}

class Cat extends Animal {
    public Cat(String name) {
        super(name);
    }
    
    @Override
    public void makeSound() {
        System.out.println(name + " meows: Meow! Meow!");
    }
}

public class Main {
    // Method that accepts any Animal
    public static void makeAnimalSound(Animal animal) {
        animal.makeSound();  // Polymorphism in action
    }
    
    // Method that works with arrays of Animals
    public static void makeAllAnimalsSound(Animal[] animals) {
        for (Animal animal : animals) {
            animal.makeSound();  // Each animal makes its own sound
        }
    }
    
    public static void main(String[] args) {
        // Different types of animals
        Animal dog = new Dog("Buddy");
        Animal cat = new Cat("Whiskers");
        Animal generic = new Animal("Generic");
        
        // Same method call, different behaviors
        makeAnimalSound(dog);     // "Buddy barks: Woof! Woof!"
        makeAnimalSound(cat);     // "Whiskers meows: Meow! Meow!"
        makeAnimalSound(generic); // "Generic makes a sound"
        
        // Array of different animal types
        Animal[] animals = {dog, cat, generic};
        makeAllAnimalsSound(animals);
    }
}
```

## Polymorphism with Shapes

```java
abstract class Shape {
    protected double x, y;
    
    public Shape(double x, double y) {
        this.x = x;
        this.y = y;
    }
    
    // Abstract method - must be implemented by subclasses
    public abstract double getArea();
    
    // Concrete method
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
    
    @Override
    public double getArea() {
        return width * height;
    }
    
    public String getDimensions() {
        return width + " x " + height;
    }
}

class Circle extends Shape {
    private double radius;
    
    public Circle(double x, double y, double radius) {
        super(x, y);
        this.radius = radius;
    }
    
    @Override
    public double getArea() {
        return Math.PI * radius * radius;
    }
    
    public double getRadius() {
        return radius;
    }
}

class Triangle extends Shape {
    private double base, height;
    
    public Triangle(double x, double y, double base, double height) {
        super(x, y);
        this.base = base;
        this.height = height;
    }
    
    @Override
    public double getArea() {
        return 0.5 * base * height;
    }
    
    public String getDimensions() {
        return "base: " + base + ", height: " + height;
    }
}
```

## Polymorphism in Action with Shapes

```java
public class Main {
    public static void main(String[] args) {
        // Create different shapes
        Shape[] shapes = {
            new Rectangle(0, 0, 5, 3),
            new Circle(0, 0, 2),
            new Triangle(0, 0, 4, 6),
            new Rectangle(10, 10, 2, 8)
        };
        
        // Polymorphism: same method call, different calculations
        for (Shape shape : shapes) {
            System.out.println("Shape at " + shape.getPosition() + 
                             " has area: " + shape.getArea());
        }
        
        // Output:
        // Shape at (0.0, 0.0) has area: 15.0
        // Shape at (0.0, 0.0) has area: 12.566370614359172
        // Shape at (0.0, 0.0) has area: 12.0
        // Shape at (10.0, 10.0) has area: 16.0
    }
}
```

## Benefits of Polymorphism

### 1. **Code Reusability**
```java
// One method works with any Animal
public static void feedAnimal(Animal animal) {
    animal.eat();  // Works with Dog, Cat, or any Animal
}
```

### 2. **Flexibility**
```java
// Easy to add new types without changing existing code
class Bird extends Animal {
    @Override
    public void makeSound() {
        System.out.println(name + " chirps: Tweet! Tweet!");
    }
}

// The existing code still works
Animal bird = new Bird("Tweety");
bird.makeSound();  // "Tweety chirps: Tweet! Tweet!"
```

### 3. **Maintainability**
```java
// Change behavior by changing the object type
Animal pet = new Dog("Buddy");  // Dog behavior
pet = new Cat("Whiskers");      // Cat behavior
pet.makeSound();  // Now makes cat sound
```

## Polymorphism with Interfaces

```java
interface Drawable {
    void draw();
}

class Circle implements Drawable {
    @Override
    public void draw() {
        System.out.println("Drawing a circle");
    }
}

class Rectangle implements Drawable {
    @Override
    public void draw() {
        System.out.println("Drawing a rectangle");
    }
}

public class Main {
    public static void main(String[] args) {
        Drawable[] drawables = {
            new Circle(),
            new Rectangle(),
            new Circle()
        };
        
        // Polymorphism: same method call, different implementations
        for (Drawable drawable : drawables) {
            drawable.draw();
        }
    }
}
```

## Common Polymorphism Patterns

### 1. **Factory Pattern**
```java
class AnimalFactory {
    public static Animal createAnimal(String type, String name) {
        switch (type.toLowerCase()) {
            case "dog":
                return new Dog(name);
            case "cat":
                return new Cat(name);
            default:
                return new Animal(name);
        }
    }
}

// Usage
Animal pet = AnimalFactory.createAnimal("dog", "Buddy");
pet.makeSound();  // "Buddy barks: Woof! Woof!"
```

### 2. **Strategy Pattern**
```java
abstract class PaymentMethod {
    public abstract void pay(double amount);
}

class CreditCard extends PaymentMethod {
    @Override
    public void pay(double amount) {
        System.out.println("Paying $" + amount + " with credit card");
    }
}

class PayPal extends PaymentMethod {
    @Override
    public void pay(double amount) {
        System.out.println("Paying $" + amount + " with PayPal");
    }
}

class PaymentProcessor {
    public void processPayment(PaymentMethod method, double amount) {
        method.pay(amount);  // Polymorphism
    }
}
```

## Important Notes

### 1. **Method Resolution**
- The method called depends on the **object type** (runtime type)
- Not the **reference type** (compile-time type)

### 2. **Access Limitations**
- You can only call methods available in the reference type
- To call subclass-specific methods, you need to cast

### 3. **Casting**
```java
Animal animal = new Dog("Buddy");
// animal.fetch();  // ERROR - fetch() not in Animal

if (animal instanceof Dog) {
    Dog dog = (Dog) animal;  // Cast to Dog
    dog.fetch();  // Now we can call fetch()
}
```

## Summary

Polymorphism is a powerful feature that allows:

1. **Same interface, different implementations** - objects of different types can be treated uniformly
2. **Runtime method resolution** - the correct method is called based on the actual object type
3. **Code flexibility** - easy to add new types without changing existing code
4. **Better maintainability** - changes to one class don't affect others
5. **Cleaner code** - one method can work with many different types

Polymorphism, combined with inheritance and method overriding, is essential for creating flexible, maintainable object-oriented programs.
