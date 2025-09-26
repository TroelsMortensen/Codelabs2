# Fixing the `equals` Method in Inheritance Hierarchies

## The Problem with `equals` in Inheritance

When working with inheritance hierarchies, implementing the `equals` method correctly becomes more complex. The main challenge is ensuring that the `equals` method works correctly when comparing objects of different types in the same hierarchy.

## Common Issues

### 1. **Symmetry Violation**
```java
// ❌ BAD - Violates symmetry
class Animal {
    protected String name;
    
    public Animal(String name) {
        this.name = name;
    }
    
    @Override
    public boolean equals(Object obj) {
        if (obj instanceof Animal) {
            Animal other = (Animal) obj;
            return this.name.equals(other.name);
        }
        return false;
    }
}

class Dog extends Animal {
    private String breed;
    
    public Dog(String name, String breed) {
        super(name);
        this.breed = breed;
    }
    
    @Override
    public boolean equals(Object obj) {
        if (obj instanceof Dog) {
            Dog other = (Dog) obj;
            return this.name.equals(other.name) && this.breed.equals(other.breed);
        }
        return false;
    }
}

// Problem: Symmetry is violated
Animal animal = new Animal("Buddy");
Dog dog = new Dog("Buddy", "Golden Retriever");

System.out.println(animal.equals(dog));  // true (Animal.equals)
System.out.println(dog.equals(animal));  // false (Dog.equals)
// This violates the symmetry requirement!
```

### 2. **Transitivity Violation**
```java
// ❌ BAD - Violates transitivity
class Point {
    protected int x, y;
    
    public Point(int x, int y) {
        this.x = x;
        this.y = y;
    }
    
    @Override
    public boolean equals(Object obj) {
        if (obj instanceof Point) {
            Point other = (Point) obj;
            return this.x == other.x && this.y == other.y;
        }
        return false;
    }
}

class ColorPoint extends Point {
    private String color;
    
    public ColorPoint(int x, int y, String color) {
        super(x, y);
        this.color = color;
    }
    
    @Override
    public boolean equals(Object obj) {
        if (obj instanceof ColorPoint) {
            ColorPoint other = (ColorPoint) obj;
            return super.equals(other) && this.color.equals(other.color);
        }
        if (obj instanceof Point) {
            return super.equals(obj);
        }
        return false;
    }
}

// Problem: Transitivity is violated
Point p1 = new Point(1, 2);
ColorPoint cp1 = new ColorPoint(1, 2, "red");
ColorPoint cp2 = new ColorPoint(1, 2, "blue");

System.out.println(p1.equals(cp1));  // true
System.out.println(p1.equals(cp2));  // true
System.out.println(cp1.equals(cp2)); // false
// This violates the transitivity requirement!
```

## The Solution: Proper `equals` Implementation

### 1. **Use `getClass()` Instead of `instanceof`**

```java
class Animal {
    protected String name;
    
    public Animal(String name) {
        this.name = name;
    }
    
    @Override
    public boolean equals(Object obj) {
        if (this == obj) return true;
        if (obj == null || getClass() != obj.getClass()) return false;
        
        Animal animal = (Animal) obj;
        return Objects.equals(name, animal.name);
    }
    
    @Override
    public int hashCode() {
        return Objects.hash(name);
    }
}

class Dog extends Animal {
    private String breed;
    
    public Dog(String name, String breed) {
        super(name);
        this.breed = breed;
    }
    
    @Override
    public boolean equals(Object obj) {
        if (this == obj) return true;
        if (obj == null || getClass() != obj.getClass()) return false;
        if (!super.equals(obj)) return false;
        
        Dog dog = (Dog) obj;
        return Objects.equals(breed, dog.breed);
    }
    
    @Override
    public int hashCode() {
        return Objects.hash(super.hashCode(), breed);
    }
}
```

### 2. **Complete Example: Shape Hierarchy**

```java
import java.util.Objects;

abstract class Shape {
    protected double x, y;
    
    public Shape(double x, double y) {
        this.x = x;
        this.y = y;
    }
    
    @Override
    public boolean equals(Object obj) {
        if (this == obj) return true;
        if (obj == null || getClass() != obj.getClass()) return false;
        
        Shape shape = (Shape) obj;
        return Double.compare(shape.x, x) == 0 && Double.compare(shape.y, y) == 0;
    }
    
    @Override
    public int hashCode() {
        return Objects.hash(x, y);
    }
    
    public abstract double getArea();
}

class Rectangle extends Shape {
    private double width, height;
    
    public Rectangle(double x, double y, double width, double height) {
        super(x, y);
        this.width = width;
        this.height = height;
    }
    
    @Override
    public boolean equals(Object obj) {
        if (this == obj) return true;
        if (obj == null || getClass() != obj.getClass()) return false;
        if (!super.equals(obj)) return false;
        
        Rectangle rectangle = (Rectangle) obj;
        return Double.compare(rectangle.width, width) == 0 && 
               Double.compare(rectangle.height, height) == 0;
    }
    
    @Override
    public int hashCode() {
        return Objects.hash(super.hashCode(), width, height);
    }
    
    @Override
    public double getArea() {
        return width * height;
    }
}

class Circle extends Shape {
    private double radius;
    
    public Circle(double x, double y, double radius) {
        super(x, y);
        this.radius = radius;
    }
    
    @Override
    public boolean equals(Object obj) {
        if (this == obj) return true;
        if (obj == null || getClass() != obj.getClass()) return false;
        if (!super.equals(obj)) return false;
        
        Circle circle = (Circle) obj;
        return Double.compare(circle.radius, radius) == 0;
    }
    
    @Override
    public int hashCode() {
        return Objects.hash(super.hashCode(), radius);
    }
    
    @Override
    public double getArea() {
        return Math.PI * radius * radius;
    }
}
```

### 3. **Testing the Implementation**

```java
public class Main {
    public static void main(String[] args) {
        // Test symmetry
        Shape shape1 = new Rectangle(0, 0, 5, 3);
        Shape shape2 = new Rectangle(0, 0, 5, 3);
        Shape shape3 = new Circle(0, 0, 2);
        
        System.out.println("Symmetry test:");
        System.out.println("shape1.equals(shape2): " + shape1.equals(shape2));  // true
        System.out.println("shape2.equals(shape1): " + shape2.equals(shape1));  // true
        
        System.out.println("\nDifferent types:");
        System.out.println("shape1.equals(shape3): " + shape1.equals(shape3));  // false
        System.out.println("shape3.equals(shape1): " + shape3.equals(shape1));  // false
        
        // Test transitivity
        Rectangle rect1 = new Rectangle(0, 0, 5, 3);
        Rectangle rect2 = new Rectangle(0, 0, 5, 3);
        Rectangle rect3 = new Rectangle(0, 0, 5, 3);
        
        System.out.println("\nTransitivity test:");
        System.out.println("rect1.equals(rect2): " + rect1.equals(rect2));  // true
        System.out.println("rect2.equals(rect3): " + rect2.equals(rect3));  // true
        System.out.println("rect1.equals(rect3): " + rect1.equals(rect3));  // true
        
        // Test with collections
        java.util.List<Shape> shapes = java.util.Arrays.asList(
            new Rectangle(0, 0, 5, 3),
            new Circle(0, 0, 2),
            new Rectangle(0, 0, 5, 3)
        );
        
        System.out.println("\nCollection test:");
        System.out.println("shapes.get(0).equals(shapes.get(2)): " + 
                          shapes.get(0).equals(shapes.get(2)));  // true
        System.out.println("shapes.contains(new Rectangle(0, 0, 5, 3)): " + 
                          shapes.contains(new Rectangle(0, 0, 5, 3)));  // true
    }
}
```

## The `equals` Method Template

### For Abstract Classes
```java
@Override
public boolean equals(Object obj) {
    if (this == obj) return true;
    if (obj == null || getClass() != obj.getClass()) return false;
    
    // Cast to the current class
    CurrentClass other = (CurrentClass) obj;
    
    // Compare all fields
    return Objects.equals(field1, other.field1) &&
           Objects.equals(field2, other.field2) &&
           // ... compare all fields
}

@Override
public int hashCode() {
    return Objects.hash(field1, field2, /* ... all fields */);
}
```

### For Concrete Classes
```java
@Override
public boolean equals(Object obj) {
    if (this == obj) return true;
    if (obj == null || getClass() != obj.getClass()) return false;
    if (!super.equals(obj)) return false;  // Check parent class equality
    
    // Cast to the current class
    CurrentClass other = (CurrentClass) obj;
    
    // Compare only the fields specific to this class
    return Objects.equals(specificField1, other.specificField1) &&
           Objects.equals(specificField2, other.specificField2);
}

@Override
public int hashCode() {
    return Objects.hash(super.hashCode(), specificField1, specificField2);
}
```

## Key Rules for `equals` in Inheritance

### 1. **Use `getClass()` Not `instanceof`**
- `getClass()` ensures exact type matching
- `instanceof` can lead to symmetry violations

### 2. **Always Call `super.equals()`**
- Ensures parent class fields are compared
- Maintains consistency across the hierarchy

### 3. **Override `hashCode()` Too**
- `equals` and `hashCode` must be consistent
- Use the same fields in both methods

### 4. **Handle `null` and Self-Reference**
- Always check for `null`
- Always check for self-reference (`this == obj`)

### 5. **Use `Objects.equals()` for Safety**
- Handles `null` values gracefully
- Prevents `NullPointerException`

## Advanced Example: Complex Hierarchy

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
    
    @Override
    public boolean equals(Object obj) {
        if (this == obj) return true;
        if (obj == null || getClass() != obj.getClass()) return false;
        
        Employee employee = (Employee) obj;
        return employeeId == employee.employeeId &&
               Double.compare(employee.salary, salary) == 0 &&
               Objects.equals(name, employee.name);
    }
    
    @Override
    public int hashCode() {
        return Objects.hash(name, employeeId, salary);
    }
}

class Manager extends Employee {
    private String department;
    private int teamSize;
    
    public Manager(String name, int employeeId, double salary, String department, int teamSize) {
        super(name, employeeId, salary);
        this.department = department;
        this.teamSize = teamSize;
    }
    
    @Override
    public boolean equals(Object obj) {
        if (this == obj) return true;
        if (obj == null || getClass() != obj.getClass()) return false;
        if (!super.equals(obj)) return false;
        
        Manager manager = (Manager) obj;
        return teamSize == manager.teamSize &&
               Objects.equals(department, manager.department);
    }
    
    @Override
    public int hashCode() {
        return Objects.hash(super.hashCode(), department, teamSize);
    }
}

class Developer extends Employee {
    private String programmingLanguage;
    private int yearsOfExperience;
    
    public Developer(String name, int employeeId, double salary, String programmingLanguage, int yearsOfExperience) {
        super(name, employeeId, salary);
        this.programmingLanguage = programmingLanguage;
        this.yearsOfExperience = yearsOfExperience;
    }
    
    @Override
    public boolean equals(Object obj) {
        if (this == obj) return true;
        if (obj == null || getClass() != obj.getClass()) return false;
        if (!super.equals(obj)) return false;
        
        Developer developer = (Developer) obj;
        return yearsOfExperience == developer.yearsOfExperience &&
               Objects.equals(programmingLanguage, developer.programmingLanguage);
    }
    
    @Override
    public int hashCode() {
        return Objects.hash(super.hashCode(), programmingLanguage, yearsOfExperience);
    }
}
```

## Summary

Implementing `equals` correctly in inheritance hierarchies requires:

1. **Using `getClass()` instead of `instanceof`** to ensure exact type matching
2. **Calling `super.equals()`** to check parent class fields
3. **Overriding `hashCode()`** to maintain consistency
4. **Handling edge cases** like `null` and self-reference
5. **Using `Objects.equals()`** for safe field comparison

This approach ensures that your `equals` method follows all the required properties (reflexivity, symmetry, transitivity, and consistency) while working correctly in inheritance hierarchies.
