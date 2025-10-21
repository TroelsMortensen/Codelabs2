# Abstract Methods

## What are Abstract Methods?

An **abstract method** is a method that is declared but not _implemented_ in an abstract class. It has no body and _must_ be implemented by any concrete subclass that extends the abstract class.

Think of abstract methods as "contracts" - they tell subclasses what they must do, but not how to do it. The "how" is up to the subclass to decide, and is provided with the implementation in the subclass.

In order to be a vehicle, you must be able to `drive`. How that driving then works, the vehicle neither knows nor cares. That is the responsibility of the subclass to figure out.

## Syntax of Abstract Methods

### Basic Syntax

Here is another version of the Shape class, with abstract methods. If some class extends Shape, it _must_ implement the abstract methods. Notice the two abstract methods, `getArea` and `getPerimeter`, which are declared but not implemented in the abstract class.

The `displayInfo` method is a concrete method, which has an implementation. Still, subclasses _may_ decide to `@Override` it, if they want to provide a different implementation. This method makes calls to the two abstract methods, `getArea` and `getPerimeter`, meaning that when the method is called on some subclass of Shape, it will call the implementation of the abstract methods in the subclass. This 

```java{3,6}
public abstract class Shape {
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
- **Must be in abstract class** - Cannot have abstract methods in concrete classes!
- **Must be implemented** - Subclasses must provide implementation
- **Can have access modifiers** - public, protected, package-private (but not private)

## Implementing Abstract Methods

### Example: Shape Hierarchy

Assume the following abstract class, with three abstract methods: `getArea`, `getPerimeter`, and `draw`.

```java{10-12}
public abstract class Shape {
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
```

And the following concrete classes, `Rectangle` and `Circle`, that extend the `Shape` class. Notice the `@Override` annotation, which is used to indicate that the method is overridden from the super class. These were the abstract methods in the super class, `Shape`.

```java
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

If you forget to implement one of the abstract methods, you will get a compilation error. This is powerful, as we cannot forget to implement one of the abstract methods, which might be the case, if the superclass is concrete, rather than abstract.

## Note
Abstract methods can of course have parameters, and return types. Even though this is not shown in the example above, it is perfectly valid to have abstract methods with parameters and return types.

## Using Abstract Methods

There isn't really much to say about using abstract methods. From the outside they look like regular methods.

### Polymorphism with Abstract Methods

The following example shows how to use abstract methods with polymorphism.\
First, we create an array of various shapes, and then loop through the array, and call the `draw` method. Notice that the `draw` method is implemented differently for each shape.

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
    }
}
```

## Rules for Abstract Methods

### 1. **Must be in Abstract Class**
If you declare a method as abstract, you must declare the class as abstract as well.

```java
// ❌ ERROR - Cannot have abstract methods in concrete class
public class ConcreteClass {
    public abstract void method();  // Compilation error
}

// ✅ CORRECT - Abstract methods must be in abstract class
public abstract class AbstractClass {
    public abstract void method();  // OK
}
```

### 2. **Must be Implemented by Subclasses**
If you declare a method as abstract, you must implement it in the subclass.

```java
public abstract class Parent {
    public abstract void method();
}

// ❌ ERROR - Must implement abstract method
public class Child extends Parent {
    // Missing implementation of method()
}

// ✅ CORRECT - Must implement abstract method
public class Child extends Parent {
    @Override
    public void method() {
        System.out.println("Implementation");
    }
}
```

### 3. **Cannot be Static**

Abstract methods cannot be static, because static methods are not bound to any specific object. They are bound to the class itself.

```java
public abstract class Example {
    // ❌ ERROR - Abstract methods cannot be static
    public abstract static void method();
}
```

### 4. **Cannot be Private**

Anything private is not known by any other class. The subclass cannot see the abstract method, and therefore cannot implement it.

```java
public abstract class Example {
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

### 5. **Ensures the abstract class is not instantiated**
An abstract class cannot be instantiated, so it cannot be used to create objects. You _can_ declare a variable of type abstract class, but you cannot create an object of that type.

```java
public abstract class Example {
}

public class SubExample extends Example {
}

public class Main {
    public static void main(String[] args) {
        // ❌ ERROR - Abstract class cannot be instantiated
        Example e = new Example();

        // ✅ CORRECT - Concrete class SubExample can be instantiated
        SubExample se = new SubExample();
        Example e2 = new SubExample();
    }
}
```
