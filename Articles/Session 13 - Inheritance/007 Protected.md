# The `protected` Keyword


The `protected` access modifier in Java provides access to members within the same package and to subclasses (even if they're in different packages). It's more restrictive than `public` but less restrictive than `private`.

## Access Levels Comparison

| Modifier | Same Class | Same Package | Subclass | Different Package |
|----------|------------|--------------|----------|-------------------|
| `private` | ✅ | ❌ | ❌ | ❌ |
| `protected` | ✅ | ✅ | ✅ | ❌ |
| `public` | ✅ | ✅ | ✅ | ✅ |
| (default) | ✅ | ✅ | ❌ | ❌ |

The `default` access modifier is the same as `package-private`. This is what you get, if you _don't_ specify an access modifier:

```java
public class MyClass {
    String myString; // default access modifier
}
```

## Basic Example

This examples illustrates the different access levels of private, protected, and public.

Notice how the subclass, `Dog`, can access the protected field `age`, and the protected method `growOlder()`, of the super class, `Animal`.

The constructor of the `Dog` class uses the `super()` keyword to call the constructor of the `Animal` class. It is explained further on an upcoming page about "super".

```java{39-40}
public class Animal {
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

public class Dog extends Animal {
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

This example how the `Car` class can access the protected fields of the `Vehicle` class. This happens in the `displayInfo()` method.

First the `Vehicle` super class:

```java{2-3}
public class Vehicle {
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
```

Then the `Car` subclass, notice how `brand` and `year` are protected in `Vehicle`, and are therefore accessible in the `Car` class.

```java{11-12}
public class Car extends Vehicle {
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


## When to Use `protected`

### ✅ Good Uses of `protected`:

1. **Fields that subclasses need to access directly**
```java
public class Animal {
    protected String name;  // Subclasses need to access name
    protected int age;      // Subclasses need to access age
}
```

2. **Methods that subclasses should override**

Overriding a method means to provide a new implementation of the method in the subclass. You have already seen this with the `toString()` method.

```java
public class Shape {
    protected double calculateArea() {
        return 0;  // Default implementation
    }
}
```

1. **Internal methods that subclasses need**
```java
public class Vehicle {
    protected void startEngine() {
        // Internal method that subclasses need
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
