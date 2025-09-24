# Constructors in Inheritance

## How Constructors Work with Inheritance

When you create an object of a child class, both the parent and child constructors are called. Understanding how this works is crucial for proper inheritance implementation.

## Constructor Call Order

### 1. **Parent Constructor First**
When you create a child object, the parent constructor is called first, then the child constructor.

```java
class Animal {
    protected String name;
    
    public Animal(String name) {
        this.name = name;
        System.out.println("Animal constructor: " + name);
    }
}

class Dog extends Animal {
    private String breed;
    
    public Dog(String name, String breed) {
        super(name);  // Call parent constructor
        this.breed = breed;
        System.out.println("Dog constructor: " + breed);
    }
}
```

**Usage:**
```java
Dog myDog = new Dog("Buddy", "Golden Retriever");
```

**Output:**
```
Animal constructor: Buddy
Dog constructor: Golden Retriever
```

## Automatic `super()` Call

If you don't explicitly call `super()`, Java automatically calls the parent's no-argument constructor:

```java
class Animal {
    protected String name;
    
    public Animal() {
        this.name = "Unknown";
        System.out.println("Animal default constructor");
    }
    
    public Animal(String name) {
        this.name = name;
        System.out.println("Animal constructor: " + name);
    }
}

class Dog extends Animal {
    private String breed;
    
    public Dog(String breed) {
        // super(); // Java automatically adds this
        this.breed = breed;
        System.out.println("Dog constructor: " + breed);
    }
}
```

**Usage:**
```java
Dog myDog = new Dog("Labrador");
```

**Output:**
```
Animal default constructor
Dog constructor: Labrador
```

## Constructor Chaining

Constructors can call other constructors in the same class using `this()`, and parent constructors using `super()`:

```java
class Vehicle {
    protected String brand;
    protected int year;
    
    public Vehicle() {
        this("Unknown", 0);  // Call other constructor
        System.out.println("Vehicle default constructor");
    }
    
    public Vehicle(String brand, int year) {
        this.brand = brand;
        this.year = year;
        System.out.println("Vehicle constructor: " + brand + " " + year);
    }
}

class Car extends Vehicle {
    private int doors;
    
    public Car() {
        this("Unknown", 0, 4);  // Call other Car constructor
        System.out.println("Car default constructor");
    }
    
    public Car(String brand, int year, int doors) {
        super(brand, year);  // Call parent constructor
        this.doors = doors;
        System.out.println("Car constructor: " + doors + " doors");
    }
}
```

**Usage:**
```java
Car myCar = new Car();
```

**Output:**
```
Vehicle constructor: Unknown 0
Car constructor: 4 doors
Car default constructor
```

## Complete Example

```java
class Person {
    protected String name;
    protected int age;
    
    public Person() {
        this("Unknown", 0);
        System.out.println("Person default constructor");
    }
    
    public Person(String name, int age) {
        this.name = name;
        this.age = age;
        System.out.println("Person constructor: " + name + ", " + age);
    }
}

class Student extends Person {
    private String studentId;
    private double gpa;
    
    public Student() {
        this("Unknown", 0, "N/A", 0.0);
        System.out.println("Student default constructor");
    }
    
    public Student(String name, int age, String studentId, double gpa) {
        super(name, age);  // Call parent constructor
        this.studentId = studentId;
        this.gpa = gpa;
        System.out.println("Student constructor: " + studentId + ", GPA: " + gpa);
    }
    
    public Student(String name, String studentId) {
        this(name, 18, studentId, 0.0);  // Call other Student constructor
        System.out.println("Student constructor (name, ID only)");
    }
}

class GraduateStudent extends Student {
    private String thesis;
    
    public GraduateStudent(String name, int age, String studentId, 
                          double gpa, String thesis) {
        super(name, age, studentId, gpa);  // Call parent constructor
        this.thesis = thesis;
        System.out.println("GraduateStudent constructor: " + thesis);
    }
}
```

**Usage:**
```java
public class Main {
    public static void main(String[] args) {
        System.out.println("=== Creating Student ===");
        Student student = new Student("Alice", 20, "S12345", 3.8);
        
        System.out.println("\n=== Creating Graduate Student ===");
        GraduateStudent grad = new GraduateStudent("Bob", 25, "G67890", 3.9, 
                                                  "Machine Learning Applications");
        
        System.out.println("\n=== Creating Default Student ===");
        Student defaultStudent = new Student();
    }
}
```

**Output:**
```
=== Creating Student ===
Person constructor: Alice, 20
Student constructor: S12345, GPA: 3.8

=== Creating Graduate Student ===
Person constructor: Bob, 25
Student constructor: G67890, GPA: 3.9
GraduateStudent constructor: Machine Learning Applications

=== Creating Default Student ===
Person constructor: Unknown, 0
Student constructor: N/A, GPA: 0.0
Student default constructor
```

## Common Constructor Patterns

### 1. **Default Constructor Pattern**
```java
class Parent {
    protected String name;
    
    public Parent() {
        this("Default");
    }
    
    public Parent(String name) {
        this.name = name;
    }
}

class Child extends Parent {
    private int value;
    
    public Child() {
        this(0);
    }
    
    public Child(int value) {
        super();  // Call parent default constructor
        this.value = value;
    }
}
```

### 2. **Parameterized Constructor Pattern**
```java
class Parent {
    protected String name;
    
    public Parent(String name) {
        this.name = name;
    }
}

class Child extends Parent {
    private int value;
    
    public Child(String name, int value) {
        super(name);  // Must call parent constructor
        this.value = value;
    }
}
```

### 3. **Multiple Constructor Pattern**
```java
class Parent {
    protected String name;
    protected int age;
    
    public Parent() {
        this("Unknown", 0);
    }
    
    public Parent(String name) {
        this(name, 0);
    }
    
    public Parent(String name, int age) {
        this.name = name;
        this.age = age;
    }
}

class Child extends Parent {
    private String id;
    
    public Child() {
        this("Unknown", 0, "N/A");
    }
    
    public Child(String name) {
        this(name, 0, "N/A");
    }
    
    public Child(String name, int age, String id) {
        super(name, age);
        this.id = id;
    }
}
```

## Important Rules

### 1. **`super()` Must Be First**
```java
class Child extends Parent {
    public Child() {
        // Do something first - ERROR!
        super();  // Must be first statement
    }
}
```

### 2. **Must Call Parent Constructor**
If the parent class doesn't have a no-argument constructor, you must call `super()` with parameters:

```java
class Parent {
    public Parent(String name) {
        // Only has parameterized constructor
    }
}

class Child extends Parent {
    public Child() {
        super("Default");  // Must provide parameter
    }
}
```

### 3. **Cannot Call Both `this()` and `super()`**
You can only call one constructor in the first line:

```java
class Child extends Parent {
    public Child() {
        super();  // OR this(), but not both
        // this("something"); // ERROR!
    }
}
```

## Constructor Inheritance Rules

### ❌ **Constructors Are NOT Inherited**
```java
class Parent {
    public Parent(String name) {
        // constructor
    }
}

class Child extends Parent {
    // Child does NOT automatically get Parent(String name) constructor
    // You must create your own constructors
}
```

### ✅ **You Must Create Child Constructors**
```java
class Child extends Parent {
    public Child(String name) {
        super(name);  // Call parent constructor
    }
}
```

## Summary

Understanding constructors in inheritance is crucial:

1. **Parent constructor is called first** when creating child objects
2. **`super()` must be the first statement** in child constructors
3. **Java automatically calls `super()`** if you don't specify it
4. **Constructors are not inherited** - you must create them
5. **Constructor chaining** allows calling other constructors
6. **Must match parent constructor signature** when calling `super()`

Proper constructor handling ensures that parent class initialization happens correctly and that all objects are properly constructed in the inheritance hierarchy.
