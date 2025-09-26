# Casting Recap

## What is Casting?

**Casting** in Java is the process of converting one data type to another. When working with inheritance and polymorphism, you may need to cast objects from one type to another to access specific methods or properties. Generally, however, you should avoid casting, and instead use polymorphism to access the methods or properties you need. If you _do_ need to cast, your design is _probably_ flawed.

## The `instanceof` Operator

The `instanceof` operator checks if an object is an instance of a specific class. It returns `true` if the object is an instance of the specified type, `false` otherwise.

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

I now have two variables, `dog` and `animal`, both referring to the same object. However, if I access the object through the `animal` variable, I can only call methods that are available in the `Animal` class.

### Downcasting (Explicit)
Converting from a superclass to a subclass - requires explicit casting:

```java
Animal animal = new Dog("Buddy");
Dog dog = (Dog) animal;  // Downcasting - explicit cast required
```

This is only possible if the object is actually a `Dog`, otherwise you will get a `ClassCastException`. This is a runtime error, that crashes your program. _Maybe_ IntelliJ is able to give you a warning.

## Safe Casting with `instanceof`

I recommend using `instanceof` before casting to avoid `ClassCastException`:

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

First, a version of the `Animal`, `Dog`, and `Cat` classes, again. With some specific methods for each subclass.

```java{23-25,38-40}
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
```

And in the main method, I create an array of animals, and then loop through the array, and call the `fetch` or `climb` method, depending on the animal.

```java
public class Main {
    public static void main(String[] args) {
        Animal[] animals = {
            new Dog("Buddy"),
            new Cat("Whiskers"),
            new Dog("Rex")
        };
        
        for (Animal animal : animals) {
            // Safe casting to access specific methods. 
            // We are checking if the animal is a Dog or a Cat, and then casting to the appropriate class.
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