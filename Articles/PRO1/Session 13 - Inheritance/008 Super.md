# The `super` Keyword

What is `super`?

You havbe previously seen the `this` keyword, which is used to refer to the current object.\
The `super` keyword in Java is used to refer to the parent class from within a child class. It allows you to access parent class members and call parent class methods and constructors.

## Uses of `super`

1. **Calling constructor of super class**
2. **Accessing super class methods**
3. **Accessing super class fields**

## 1. Calling Parent Constructor

The most common use of `super` is to call the super class constructor, from a subclass. Sometime the subclass receives arguments, which must be passed to the superclass.

```java{16}
class Animal {
    protected String name;
    protected int age;
    
    public Animal(String name, int age) {
        this.name = name;
        this.age = age;
        System.out.println("Animal constructor called");
    }
}

class Dog extends Animal {
    private String breed;
    
    public Dog(String name, int age, String breed) {
        super(name, age);  // Call parent constructor
        this.breed = breed;
        System.out.println("Dog constructor called");
    }
}
```

**Usage:**
```java
Dog myDog = new Dog("Buddy", 3, "Golden Retriever");
// Output:
// Animal constructor called
// Dog constructor called
```

### Important Rules for `super()`:

1. **Must be the first statement** in the constructor
2. **Must match a parent constructor** (same parameters)
3. **If not called explicitly**, Java calls `super()` with no parameters. This assumes the super class has a default constructor.

```java
class Child extends Parent {
    public Child() {
        // super(); // Java automatically adds this if you don't
        // other code
    }
}
```

## 2. Accessing Parent Class Methods

Use `super` to call parent class methods, including when overriding:

```java
class Animal {
    protected String name;
    
    public void eat() {
        System.out.println(name + " is eating");
    }
    
    public void sleep() {
        System.out.println(name + " is sleeping");
    }
}

class Dog extends Animal {

    @Override
    public void eat() {
        System.out.println(name + " is eating dog food");
    }
    
    public void doDailyRoutine() {
        super.eat();    // Call parent's eat() method
        this.eat();     // Call current class's eat() method
        super.sleep();  // Call parent's sleep() method
    }
}
```

**Usage:**
```java
Dog myDog = new Dog();
myDog.name = "Rex";
myDog.doDailyRoutine();

// Output:
// Rex is eating
// Rex is eating dog food
// Rex is sleeping
```

## 3. Accessing Parent Class Fields

Use `super` to explicitly and clearly access parent class fields. It is also relevant when the superclass has a protected field, and the subclass has a field with the same name (this, however, leads to confusion, and should be avoided):

```java
class Animal {
    protected String name = "Animal";
}

class Dog extends Animal {

    private String name = "Dog";

    public void showNames() {
        System.out.println("Child name: " + this.name);    // "Dog"
        System.out.println("Parent name: " + super.name);  // "Animal"
    }
}
```


## Multiple Levels of Inheritance

When you have multiple levels, `super` always refers to the immediate parent:

```java
class Animal {
    protected String name;
    
    public Animal(String name) {
        this.name = name;
    }
    
    public void eat() {
        System.out.println(name + " is eating");
    }
}

class Mammal extends Animal {
    public Mammal(String name) {
        super(name);
    }
    
    public void giveBirth() {
        System.out.println(name + " is giving birth");
    }
}

class Dog extends Mammal {
    public Dog(String name) {
        super(name);  // Calls Mammal constructor
    }
    
    public void bark() {
        System.out.println(name + " is barking");
    }
    
    public void doEverything() {
        super.eat();        // Calls Mammal's eat() (which is Animal's eat())
        super.giveBirth();  // Calls Mammal's giveBirth()
        this.bark();        // Calls Dog's bark()
    }
}
```


## Summary

The `super` keyword is essential for inheritance in Java:

1. **`super()`** - Calls super class constructor (must be first in constructor)
2. **`super.method()`** - Calls parent class method
3. **`super.field`** - Accesses parent class field
4. **Always refers to immediate super class** in inheritance chain

Understanding `super` is crucial for building proper inheritance hierarchies and maintaining the relationship between super class and subclass.


## Video

John explains the `super` keyword in 11 minutes, if you need to learn about it in a different way:



<video src="https://youtu.be/Qb_NUn0TSAU"></video>

