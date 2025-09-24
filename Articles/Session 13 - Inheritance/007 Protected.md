# The `protected` Keyword

## What is `protected`?

The `protected` access modifier in Java provides access to members within the same package and to subclasses (even if they're in different packages). It's more restrictive than `public` but less restrictive than `private`.

## Access Levels Comparison

| Modifier | Same Class | Same Package | Subclass | Different Package |
|----------|------------|--------------|----------|-------------------|
| `private` | ✅ | ❌ | ❌ | ❌ |
| `protected` | ✅ | ✅ | ✅ | ❌ |
| `public` | ✅ | ✅ | ✅ | ✅ |
| (default) | ✅ | ✅ | ❌ | ❌ |

## Basic Example

```java
class Animal {
    private String name;        // Only accessible within Animal class
    protected int age;          // Accessible within Animal and subclasses
    public String species;      // Accessible everywhere
    
    public Animal(String name, int age, String species) {
        this.name = name;
        this.age = age;
        this.species = species;
    }
    
    // Private method - only accessible within Animal
    private void internalMethod() {
        System.out.println("Internal animal method");
    }
    
    // Protected method - accessible within Animal and subclasses
    protected void growOlder() {
        age++;
        System.out.println(name + " is now " + age + " years old");
    }
    
    // Public method - accessible everywhere
    public void makeSound() {
        System.out.println(name + " makes a sound");
    }
}

class Dog extends Animal {
    private String breed;
    
    public Dog(String name, int age, String breed) {
        super(name, age, "Canine");
        this.breed = breed;
    }
    
    public void celebrateBirthday() {
        // Can access protected field and method from parent
        growOlder();  // Calls protected method from Animal
        System.out.println("Happy birthday! " + name + " is now " + age);
    }
    
    public void showInfo() {
        // Can access protected field
        System.out.println("Dog: " + name + ", Age: " + age + ", Breed: " + breed);
        
        // Cannot access private field directly
        // System.out.println(name);  // ERROR! name is private in Animal
        
        // Cannot access private method
        // internalMethod();  // ERROR! internalMethod is private in Animal
    }
}
```

## Protected Fields

### Example with Protected Fields
```java
class Vehicle {
    protected String brand;     // Accessible to subclasses
    protected int year;         // Accessible to subclasses
    private String vin;         // Not accessible to subclasses
    
    public Vehicle(String brand, int year, String vin) {
        this.brand = brand;
        this.year = year;
        this.vin = vin;
    }
    
    public String getVin() {
        return vin;  // Public method to access private field
    }
}

class Car extends Vehicle {
    private int doors;
    
    public Car(String brand, int year, String vin, int doors) {
        super(brand, year, vin);
        this.doors = doors;
    }
    
    public void displayInfo() {
        // Can access protected fields directly
        System.out.println("Brand: " + brand);
        System.out.println("Year: " + year);
        
        // Cannot access private field directly
        // System.out.println("VIN: " + vin);  // ERROR!
        
        // Must use public method to access private field
        System.out.println("VIN: " + getVin());
    }
}
```

## Protected Methods

### Example with Protected Methods
```java
class Shape {
    protected double x, y;  // Position
    
    public Shape(double x, double y) {
        this.x = x;
        this.y = y;
    }
    
    // Protected method - can be overridden by subclasses
    protected double calculateArea() {
        return 0;  // Default implementation
    }
    
    // Public method that uses protected method
    public void displayArea() {
        System.out.println("Area: " + calculateArea());
    }
}

class Rectangle extends Shape {
    private double width, height;
    
    public Rectangle(double x, double y, double width, double height) {
        super(x, y);
        this.width = width;
        this.height = height;
    }
    
    // Override protected method
    @Override
    protected double calculateArea() {
        return width * height;
    }
    
    // Can call parent's protected method
    public void showDetails() {
        System.out.println("Rectangle at (" + x + ", " + y + ")");
        System.out.println("Size: " + width + " x " + height);
        System.out.println("Area: " + calculateArea());
    }
}

class Circle extends Shape {
    private double radius;
    
    public Circle(double x, double y, double radius) {
        super(x, y);
        this.radius = radius;
    }
    
    // Override protected method
    @Override
    protected double calculateArea() {
        return Math.PI * radius * radius;
    }
}
```

## Complete Example

```java
class Person {
    private String name;        // Private - only within Person
    protected int age;          // Protected - accessible to subclasses
    public String address;      // Public - accessible everywhere
    
    public Person(String name, int age, String address) {
        this.name = name;
        this.age = age;
        this.address = address;
    }
    
    // Private method
    private void validateAge() {
        if (age < 0) {
            age = 0;
        }
    }
    
    // Protected method
    protected void haveBirthday() {
        age++;
        validateAge();  // Can call private method within same class
        System.out.println(name + " is now " + age + " years old");
    }
    
    // Public method
    public void introduce() {
        System.out.println("Hello, I'm " + name + " and I'm " + age + " years old");
    }
    
    // Public getter for private field
    public String getName() {
        return name;
    }
}

class Student extends Person {
    private String studentId;
    protected double gpa;  // Protected - accessible to subclasses
    
    public Student(String name, int age, String address, String studentId, double gpa) {
        super(name, age, address);
        this.studentId = studentId;
        this.gpa = gpa;
    }
    
    // Can access protected method from parent
    public void celebrateBirthday() {
        haveBirthday();  // Calls protected method from Person
        System.out.println("Happy birthday, " + getName() + "!");
    }
    
    // Can access protected field from parent
    public void showAge() {
        System.out.println("Age: " + age);  // age is protected in Person
    }
    
    // Protected method - can be overridden by subclasses
    protected void updateGPA(double newGPA) {
        gpa = newGPA;
        System.out.println("GPA updated to: " + gpa);
    }
}

class GraduateStudent extends Student {
    private String thesis;
    
    public GraduateStudent(String name, int age, String address, 
                          String studentId, double gpa, String thesis) {
        super(name, age, address, studentId, gpa);
        this.thesis = thesis;
    }
    
    // Can access protected field from parent
    public void showGPA() {
        System.out.println("GPA: " + gpa);  // gpa is protected in Student
    }
    
    // Override protected method
    @Override
    protected void updateGPA(double newGPA) {
        super.updateGPA(newGPA);  // Call parent's method
        System.out.println("Graduate student GPA updated");
    }
}
```

## When to Use `protected`

### ✅ Good Uses of `protected`:

1. **Fields that subclasses need to access directly**
```java
class Animal {
    protected String name;  // Subclasses need to access name
    protected int age;      // Subclasses need to access age
}
```

2. **Methods that subclasses should override**
```java
class Shape {
    protected double calculateArea() {
        return 0;  // Default implementation
    }
}
```

3. **Internal methods that subclasses need**
```java
class Vehicle {
    protected void startEngine() {
        // Internal method that subclasses need
    }
}
```

### ❌ Avoid `protected` When:

1. **Fields that should be encapsulated**
```java
class BankAccount {
    protected double balance;  // BAD! Balance should be private
    // Better: private double balance; with public methods
}
```

2. **Methods that shouldn't be overridden**
```java
class Person {
    protected void validateAge() {  // BAD! Should be private
        // validation logic
    }
}
```

## Best Practices

### 1. **Use `protected` for Template Method Pattern**
```java
abstract class Game {
    public final void play() {  // Template method
        initialize();
        playGame();
        endGame();
    }
    
    protected abstract void initialize();    // Subclasses must implement
    protected abstract void playGame();      // Subclasses must implement
    protected void endGame() {               // Subclasses can override
        System.out.println("Game ended");
    }
}
```

### 2. **Use `protected` for Internal State**
```java
class Animal {
    protected boolean isAlive = true;  // Subclasses need to know this
    protected int energy = 100;        // Subclasses need to modify this
    
    public boolean isAlive() {
        return isAlive;
    }
}
```

### 3. **Use `protected` for Utility Methods**
```java
class Shape {
    protected double distance(double x1, double y1, double x2, double y2) {
        return Math.sqrt((x2-x1)*(x2-x1) + (y2-y1)*(y2-y1));
    }
}
```

## Summary

The `protected` keyword provides a middle ground between `private` and `public`:

1. **Accessible within the same class** (like `private`)
2. **Accessible within the same package** (like default)
3. **Accessible to subclasses** (even in different packages)
4. **Not accessible to unrelated classes** in different packages

**Use `protected` when:**
- Subclasses need direct access to fields or methods
- You want to allow method overriding
- You need to share internal state with subclasses
- You're implementing the Template Method pattern

**Avoid `protected` when:**
- Fields should be properly encapsulated
- Methods shouldn't be overridden
- You want to maintain strict control over access
