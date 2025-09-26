# Polymorphism

It is time. The great purpose for inheritance. Finally. At last. The time has come. The real benefits. The true power. The magic. The one thing you have been waiting for, without even knowing it. I present to you, polymorphism.

What even is Polymorphism? Why the hell should I care? Why all this fanfare? 

**Polymorphism** is one of the [four fundamental principles of object-oriented programming](https://khalilstemmler.com/articles/object-oriented/programming/4-principles/). The word "polymorphism" comes from Greek and means "many forms." In programming, it refers to the ability of objects of different types to be treated as objects of a common type, while each object can behave differently based on its actual type.

It is the next part of inheritance, and in short, it means we can treat subclasses as their superclass, and the subclasses will behave differently based on their actual type. Or, similar things behave differently.

## Types of Polymorphism

1. **Compile-time Polymorphism (Method Overloading)**
2. **Runtime Polymorphism (Method Overriding)**

This chapter focuses on **runtime polymorphism** through inheritance and method overriding.

## Basic Polymorphism Example

Let's start with a simple example. We have an `Animal` class, and two subclasses, `Dog` and `Cat`. You have seen this one before, the `Animal` class provides some general behaviour, and the subclasses provide more specific behaviour.\
For example, the `Animal` class provides a `makeSound` method, which will print out "Animal makes a sound". The `Dog` class overrides the `makeSound` method to print out "Dog makes a sound", and the `Cat` class overrides the `makeSound` method to print out "Cat makes a sound".

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

Here we see a main method that creates instances of the different animals, and calls their methods. An important thing to notice here is the _type_ of the three variables.\
Because the `Dog` and `Cat` classes are subclasses of the `Animal` class, we can treat them as `Animal` objects.

The methods available on the `animal1` variable are then the methods on the `Animal` (not the `Dog`). However! Any method that is overridden by the `Dog` will be used. This is the polymorphism, what _looks_ like an Animal, is actually a Dog.\
Similarly, the `animal2` variable is an `Animal`, but it is actually a `Cat`.

```java{4-6}
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

Consider another example, where the _actual_ type is slightly less clear:

```java
public void callTheSoundMethod(Animal animal) {
    animal.makeSound();
}
```

What will happen here? Well, that depends on the actual type of the `animal` parameter. If it is a `Dog`, the `Dog`'s `makeSound` method will be called. If it is a `Cat`, the `Cat`'s `makeSound` method will be called. If it is a `Animal`, the `Animal`'s `makeSound` method will be called.

This could be a main method, calling the above method with different types of animals:

```java
public class Main {
    public static void main(String[] args) {
        Animal animal = new Animal("Generic Animal");
        callTheSoundMethod(animal);
        callTheSoundMethod(new Dog("Buddy"));
        callTheSoundMethod(new Cat("Whiskers"));
    }
}
```

And so the output will be:
```
Generic Animal makes a sound
Buddy barks: Woof! Woof!
Whiskers meows: Meow! Meow!
```

# We can treat a class as its superclass

## Key Concepts

### 1. **Variable Type vs Object Type**
The type of the variable, and the type of the value it contains, can be different. Assuming the latter is a subclass of the former.

```java
Animal animal = new Dog("Buddy");
// Variable type: Animal
// Object type: Dog (subclass of Animal)
```

### 2. **Method Resolution**
The method that gets called depends on the **object type** (runtime type), not the variable type:

```java
Animal animal = new Dog("Buddy");
animal.makeSound();  // Calls Dog's makeSound(), not Animal's
```

### 3. **Access to Methods**
You can only call methods that are available in the variable type, i.e. left hand side of the assignment, here `Animal`	:

```java
Animal animal = new Dog("Buddy");
animal.makeSound();  // ✅ OK - makeSound() is in Animal
// animal.fetch();   // ❌ ERROR - fetch() is not in Animal
```

We cannot call `animal.fetch();` because `fetch()` is not in the `Animal` class. Even though the underlying value is a `Dog`, we cannot call `fetch()` on it, because it is not in the `Animal` class.

## Polymorphism with Collections

Let's say we have an `ArrayList` of `Animal` objects, and we add different types of animals to it. This is possible, because the type contained in the ArrayList is `Animal`, and we can add any subclass of `Animal` to it.

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


## Important Notes

### 1. **Method Resolution**
- The method called depends on the **object type** (runtime type), i.e. what the _actual_ type of the object is. Not what the variable type is.
- Not the **variable type** (compile-time type)

### 2. **Access Limitations**
- You can only call methods available in the variable type, i.e. left hand side of the assignment, here `Animal`
- To call subclass-specific methods, you need to cast

### 3. **Casting**

When you have a variable of a superclass type, but you _know_ what the actual type is, you can force the variable to be of the actual type, using a cast.\
Casting is done using the `(type)` syntax.

The `instanceof` operator is used to check if an object is of a certain type.

```java{6}
Animal animal = new Dog("Buddy");
// animal.fetch();  // ERROR - fetch() not in Animal
// We know it is a Dog, so we can cast it to a Dog
// The `instanceof` operator is used to check if an object is of a certain type.
if (animal instanceof Dog) {
    Dog dog = (Dog) animal;  // Cast to Dog
    dog.fetch();  // Now we can call fetch()
}
```

If I try to cast an object to a type that it is not, I will get a `ClassCastException`.

## Summary

Polymorphism is a powerful feature that allows:

1. **Same interface, different implementations** - objects of different types can be treated uniformly
2. **Runtime method resolution** - the correct method is called based on the actual object type
3. **Code flexibility** - easy to add new types without changing existing code
4. **Better maintainability** - changes to one class don't affect others
5. **Cleaner code** - one method can work with many different types

Polymorphism, combined with inheritance and method overriding, is essential for creating flexible, maintainable object-oriented programs.
