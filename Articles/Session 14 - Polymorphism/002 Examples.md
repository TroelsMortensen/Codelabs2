# Polymorphism Examples

Let's see polymorphism in action with both regular inheritance and abstract classes.

## Example 1: Polymorphism with Inheritance

Here's a simple example with regular classes:

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
}
```

### Using Polymorphism

```java
public class Main {
    public static void main(String[] args) {
        // Treating subclasses as superclass
        Animal animal1 = new Dog("Buddy");
        Animal animal2 = new Cat("Whiskers");
        Animal animal3 = new Animal("Generic Animal");
        
        // Same method call, different behaviors
        animal1.makeSound();  // "Buddy barks: Woof! Woof!"
        animal2.makeSound();  // "Whiskers meows: Meow! Meow!"
        animal3.makeSound();  // "Generic Animal makes a sound"
    }
}
```

Each object behaves according to its actual type, not its reference type. This demonstrates polymorphism's flexibility - one method call works with different types.

## Example 2: Polymorphism with Abstract Classes

Abstract classes work the same way. Here's a `Shape` hierarchy:

```java
public abstract class Shape {
    protected double x, y;
    
    public Shape(double x, double y) {
        this.x = x;
        this.y = y;
    }
    
    // Abstract method - must be implemented by subclasses
    public abstract double getArea();
    
    public abstract void draw();
    
    // Concrete method - shared by all shapes
    public void move(double newX, double newY) {
        this.x = newX;
        this.y = newY;
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
    
    @Override
    public void draw() {
        System.out.println("Drawing rectangle at (" + x + ", " + y + 
                         ") with width " + width + " and height " + height);
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
    
    @Override
    public void draw() {
        System.out.println("Drawing circle at (" + x + ", " + y + 
                         ") with radius " + radius);
    }
}
```

### Using Polymorphism with Abstract Classes

```java
public class Main {
    public static void main(String[] args) {
        // Treating concrete subclasses as abstract superclass
        Shape[] shapes = {
            new Rectangle(0, 0, 5, 3),
            new Circle(0, 0, 2),
            new Rectangle(10, 10, 4, 6)
        };
        
        // Same method calls, different behaviors
        for (Shape shape : shapes) {
            shape.draw();  // Each shape draws itself differently
            System.out.println("Area: " + shape.getArea());
            System.out.println("---");
        }
    }
}
```

Abstract classes work exactly like regular classes for polymorphism - you can treat concrete subclasses as the abstract superclass type.

## Example 3: Polymorphism with Collections

Polymorphism is especially useful with collections:

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
        
        // One loop works with all types
        for (Animal animal : animals) {
            animal.makeSound();  // Each makes its own sound
        }
    }
}
```

This demonstrates code reuse - one loop handles all animal types, and you can easily add new animal types without changing the loop code.

## Example 4: Polymorphism with Method Parameters

Methods can accept superclass types, enabling polymorphism:

```java
public static void feedAnimal(Animal animal) {
    animal.eat();  // Works with Dog, Cat, or any Animal
}

public static void main(String[] args) {
    feedAnimal(new Dog("Buddy"));      // Works
    feedAnimal(new Cat("Whiskers"));   // Works
    feedAnimal(new Animal("Generic")); // Works
}
```

This shows flexibility - one method works with any subclass of the parameter type.

## Key Takeaways

- **Inheritance and abstract classes** both enable polymorphism the same way
- **Same method call, different behaviors** - the actual object type determines behavior
- **Collections benefit** - can store different subclasses in one collection
- **Method parameters** - accepting superclass types enables polymorphism
- **Easy to extend** - add new subclasses without changing existing code

Note: Later you'll learn that interfaces also enable polymorphism, providing even more flexibility for designing your code.
