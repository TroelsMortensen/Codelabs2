# Method Overriding

## What is Method Overriding?

Method overriding occurs when a child class provides its own implementation of a method that already exists in the parent class. The child class "overrides" the parent's method with its own version.

## Basic Overriding Example

```java
class Animal {
    protected String name;
    
    public void makeSound() {
        System.out.println(name + " makes a sound");
    }
    
    public void eat() {
        System.out.println(name + " is eating");
    }
}

class Dog extends Animal {
    @Override
    public void makeSound() {
        System.out.println(name + " barks: Woof! Woof!");
    }
    
    // eat() method is inherited from Animal (not overridden)
}

class Cat extends Animal {
    @Override
    public void makeSound() {
        System.out.println(name + " meows: Meow! Meow!");
    }
    
    @Override
    public void eat() {
        System.out.println(name + " is eating cat food");
    }
}
```

**Usage:**
```java
Animal animal = new Animal();
animal.name = "Generic Animal";
animal.makeSound();  // "Generic Animal makes a sound"

Dog dog = new Dog();
dog.name = "Buddy";
dog.makeSound();  // "Buddy barks: Woof! Woof!"
dog.eat();        // "Buddy is eating" (inherited from Animal)

Cat cat = new Cat();
cat.name = "Whiskers";
cat.makeSound();  // "Whiskers meows: Meow! Meow!"
cat.eat();        // "Whiskers is eating cat food" (overridden)
```

## The `@Override` Annotation

The `@Override` annotation is optional but highly recommended. It tells the compiler that you intend to override a method:

### Benefits of `@Override`:
1. **Compiler checks** that you're actually overriding a method
2. **Prevents typos** in method names
3. **Makes intent clear** to other developers
4. **Helps with refactoring** - if parent method changes, compiler will warn you

```java
class Parent {
    public void doSomething() {
        System.out.println("Parent doing something");
    }
}

class Child extends Parent {
    @Override
    public void doSomething() {
        System.out.println("Child doing something");
    }
    
    // This would cause a compiler error:
    // @Override
    // public void doSomethingElse() {  // ERROR! Method doesn't exist in parent
    //     System.out.println("This won't compile");
    // }
}
```

## Overriding Object Methods

All classes in Java inherit from the `Object` class, so you can override its methods:

### 1. **toString() Method**
```java
class Person {
    private String name;
    private int age;
    
    public Person(String name, int age) {
        this.name = name;
        this.age = age;
    }
    
    @Override
    public String toString() {
        return "Person{name='" + name + "', age=" + age + "}";
    }
}
```

**Usage:**
```java
Person person = new Person("Alice", 25);
System.out.println(person);  // Calls toString() automatically
// Output: Person{name='Alice', age=25}
```

### 2. **equals() Method**
```java
class Person {
    private String name;
    private int age;
    
    public Person(String name, int age) {
        this.name = name;
        this.age = age;
    }
    
    @Override
    public boolean equals(Object obj) {
        if (this == obj) return true;
        if (obj == null || getClass() != obj.getClass()) return false;
        
        Person person = (Person) obj;
        return age == person.age && Objects.equals(name, person.name);
    }
    
    @Override
    public int hashCode() {
        return Objects.hash(name, age);
    }
}
```

### 3. **hashCode() Method**
Always override `hashCode()` when you override `equals()`:

```java
@Override
public int hashCode() {
    return Objects.hash(name, age);
}
```

## Complete Example with Object Methods

```java
import java.util.Objects;

class Vehicle {
    protected String brand;
    protected int year;
    
    public Vehicle(String brand, int year) {
        this.brand = brand;
        this.year = year;
    }
    
    public void start() {
        System.out.println(brand + " is starting");
    }
    
    @Override
    public String toString() {
        return "Vehicle{brand='" + brand + "', year=" + year + "}";
    }
    
    @Override
    public boolean equals(Object obj) {
        if (this == obj) return true;
        if (obj == null || getClass() != obj.getClass()) return false;
        
        Vehicle vehicle = (Vehicle) obj;
        return year == vehicle.year && Objects.equals(brand, vehicle.brand);
    }
    
    @Override
    public int hashCode() {
        return Objects.hash(brand, year);
    }
}

class Car extends Vehicle {
    private int doors;
    
    public Car(String brand, int year, int doors) {
        super(brand, year);
        this.doors = doors;
    }
    
    @Override
    public void start() {
        System.out.println(brand + " car is starting with " + doors + " doors");
    }
    
    @Override
    public String toString() {
        return "Car{brand='" + brand + "', year=" + year + ", doors=" + doors + "}";
    }
    
    @Override
    public boolean equals(Object obj) {
        if (!super.equals(obj)) return false;
        
        Car car = (Car) obj;
        return doors == car.doors;
    }
    
    @Override
    public int hashCode() {
        return Objects.hash(super.hashCode(), doors);
    }
}
```

## Rules for Method Overriding

### 1. **Same Method Signature**
The method signature (name, parameters, return type) must be exactly the same:

```java
class Parent {
    public void method(int x) {
        // method body
    }
}

class Child extends Parent {
    @Override
    public void method(int x) {  // Same signature
        // overridden method body
    }
    
    // This is NOT overriding - different parameter type
    public void method(String x) {
        // This is method overloading, not overriding
    }
}
```

### 2. **Access Modifier Cannot Be More Restrictive**
```java
class Parent {
    protected void method() {
        // method body
    }
}

class Child extends Parent {
    @Override
    public void method() {  // OK - public is less restrictive than protected
        // overridden method body
    }
    
    // @Override
    // private void method() {  // ERROR - private is more restrictive than protected
    //     // This won't compile
    // }
}
```

### 3. **Return Type Must Be Compatible**
For reference types, the return type can be a subclass of the parent's return type:

```java
class Parent {
    public Object getValue() {
        return new Object();
    }
}

class Child extends Parent {
    @Override
    public String getValue() {  // OK - String is a subclass of Object
        return "Hello";
    }
}
```

### 4. **Cannot Override Static Methods**
```java
class Parent {
    public static void staticMethod() {
        System.out.println("Parent static method");
    }
}

class Child extends Parent {
    // This is NOT overriding - it's hiding the parent method
    public static void staticMethod() {
        System.out.println("Child static method");
    }
}
```

### 5. **Cannot Override Final Methods**
```java
class Parent {
    public final void finalMethod() {
        System.out.println("This cannot be overridden");
    }
}

class Child extends Parent {
    // @Override
    // public void finalMethod() {  // ERROR - cannot override final method
    //     System.out.println("This won't compile");
    // }
}
```

## Using `super` with Overridden Methods

You can call the parent's overridden method using `super`:

```java
class Parent {
    public void method() {
        System.out.println("Parent method");
    }
}

class Child extends Parent {
    @Override
    public void method() {
        super.method();  // Call parent's method
        System.out.println("Child method");
    }
}
```

**Usage:**
```java
Child child = new Child();
child.method();
```

**Output:**
```
Parent method
Child method
```

## Common Overriding Patterns

### 1. **Extension Pattern**
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

### 2. **Replacement Pattern**
```java
class Parent {
    public void doSomething() {
        System.out.println("Parent doing something");
    }
}

class Child extends Parent {
    @Override
    public void doSomething() {
        System.out.println("Child doing something completely different");
        // Don't call super.doSomething()
    }
}
```

### 3. **Conditional Pattern**
```java
class Parent {
    public void doSomething() {
        System.out.println("Parent doing something");
    }
}

class Child extends Parent {
    @Override
    public void doSomething() {
        if (someCondition) {
            super.doSomething();  // Call parent method
        } else {
            System.out.println("Child doing something else");
        }
    }
}
```

## Summary

Method overriding is a powerful feature of inheritance:

1. **Allows child classes** to provide their own implementation of parent methods
2. **Uses `@Override` annotation** for safety and clarity
3. **Must follow strict rules** about method signatures and access modifiers
4. **Commonly used with Object methods** like `toString()`, `equals()`, and `hashCode()`
5. **Can use `super`** to call the parent's overridden method
6. **Enables polymorphism** - different objects can respond differently to the same method call

Understanding method overriding is essential for creating flexible, maintainable object-oriented programs.
