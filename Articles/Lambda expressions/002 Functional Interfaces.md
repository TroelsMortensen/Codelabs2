# Functional Interfaces

Lambda expressions can only be used with **functional interfaces**. Understanding functional interfaces is key to understanding lambdas.

## What is a Functional Interface?

A functional interface is an interface that has **exactly one abstract method**. This single method is what the lambda expression will implement.

A lambda expression represents an implementation of such an interface. 

## Example of a Functional Interface

```java
@FunctionalInterface
public interface Greeting {
    void sayHello(String name);
}
```

This is a functional interface because it has only one abstract method: `sayHello`.


## Using a Functional Interface with Lambda

Here's how you can use the `Greeting` interface with an anonymous class (the old approach):

**Traditional approach:**

```java
Greeting greeting = new Greeting() {
    @Override
    public void sayHello(String name) {
        System.out.println("Hello, " + name);
    }
};

greeting.sayHello("Alice");
```

And the same code, but with a lambda expression (the new approach):

**Lambda approach:**

```java
Greeting greeting = name -> System.out.println("Hello, " + name);

greeting.sayHello("Alice");
```

Both print: `Hello, Alice`

