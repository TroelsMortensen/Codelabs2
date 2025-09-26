# Casting Recap

## What is Casting?

**Casting** in Java is the process of converting one data type to another. When working with inheritance and polymorphism, you often need to cast objects from one type to another to access specific methods or properties.

## The `instanceof` Operator

The `instanceof` operator checks if an object is an instance of a specific class or interface. It returns `true` if the object is an instance of the specified type, `false` otherwise.

### Syntax
```java
object instanceof ClassName
```

### Example
```java
Animal animal = new Dog("Buddy");

if (animal instanceof Dog) {
    System.out.println("animal is a Dog");
} else {
    System.out.println("animal is not a Dog");
}
// Output: animal is a Dog
```

## Type Casting

### Upcasting (Implicit)
Converting from a subclass to a superclass - happens automatically:

```java
Dog dog = new Dog("Buddy");
Animal animal = dog;  // Upcasting - automatic
```

### Downcasting (Explicit)
Converting from a superclass to a subclass - requires explicit casting:

```java
Animal animal = new Dog("Buddy");
Dog dog = (Dog) animal;  // Downcasting - explicit cast required
```

## Safe Casting with `instanceof`

Always use `instanceof` before casting to avoid `ClassCastException`:

```java
Animal animal = new Dog("Buddy");

// Safe casting
if (animal instanceof Dog) {
    Dog dog = (Dog) animal;  // Safe to cast
    dog.fetch();  // Now we can call Dog-specific methods
}

// Unsafe casting (will cause ClassCastException)
// Cat cat = (Cat) animal;  // ERROR! animal is a Dog, not a Cat
```

## Practical Example

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
    
    public void climb() {
        System.out.println(name + " is climbing the tree");
    }
}

public class Main {
    public static void main(String[] args) {
        Animal[] animals = {
            new Dog("Buddy"),
            new Cat("Whiskers"),
            new Dog("Rex")
        };
        
        for (Animal animal : animals) {
            animal.makeSound();  // Polymorphism - each makes its own sound
            
            // Safe casting to access specific methods
            if (animal instanceof Dog) {
                Dog dog = (Dog) animal;
                dog.fetch();
            } else if (animal instanceof Cat) {
                Cat cat = (Cat) animal;
                cat.climb();
            }
        }
    }
}
```

## Common Patterns

### 1. **Method Parameter Casting**
```java
public void handleAnimal(Animal animal) {
    if (animal instanceof Dog) {
        Dog dog = (Dog) animal;
        dog.fetch();
    } else if (animal instanceof Cat) {
        Cat cat = (Cat) animal;
        cat.climb();
    }
}
```

### 2. **Collection Processing**
```java
List<Animal> animals = Arrays.asList(
    new Dog("Buddy"),
    new Cat("Whiskers"),
    new Dog("Rex")
);

for (Animal animal : animals) {
    if (animal instanceof Dog) {
        Dog dog = (Dog) animal;
        System.out.println("Dog: " + dog.name);
    }
}
```

### 3. **Factory Pattern with Casting**
```java
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

// Usage
Animal animal = createAnimal("dog", "Buddy");
if (animal instanceof Dog) {
    Dog dog = (Dog) animal;
    dog.fetch();
}
```

## Important Notes

### 1. **Always Check Before Casting**
```java
// Good
if (animal instanceof Dog) {
    Dog dog = (Dog) animal;
}

// Bad - can cause ClassCastException
Dog dog = (Dog) animal;  // Unsafe!
```

### 2. **Casting Doesn't Change the Object**
```java
Animal animal = new Dog("Buddy");
Dog dog = (Dog) animal;  // dog and animal refer to the same object
// Both variables point to the same Dog object in memory
```

### 3. **Null Safety**
```java
Animal animal = null;
if (animal instanceof Dog) {  // Returns false for null
    // This won't execute
}
```

## Why This Matters for Abstract Classes

Understanding casting is crucial when working with abstract classes because:

- **Abstract classes cannot be instantiated** - You'll always work with concrete subclasses
- **Polymorphism is common** - You'll often store subclasses in abstract class references
- **Specific methods need casting** - To access subclass-specific functionality
- **Type safety is important** - `instanceof` helps prevent runtime errors

In the next article, we'll explore the conceptual foundation of abstract programming and why it's so powerful in object-oriented design.
