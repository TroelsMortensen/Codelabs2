# Introduction

Lambda expressions were introduced in Java 8 to make code more concise and readable, especially when working with collections and functional programming concepts. It is this concise nature that we shall focus on, in relation to JavaFX.

## What is a Lambda Expression?

A lambda expression is a short, anonymous function that can be passed as an argument to methods. It's a way to write less code when you need simple functionality.

## Why Use Lambda Expressions?

Before Java 8, if you wanted to sort a list or filter items, you had to write verbose _anonymous classes_. These look like calling a constructor, but that constructor call has a method body implementing one or more methods. See below.\
Lambda expressions make this much simpler.

## Traditional Approach vs Lambda

Let's see the difference with a simple example - printing each item in a list:

**Traditional approach (using anonymous class):**

```java
List<String> names = Arrays.asList("Alice", "Bob", "Charlie");

names.forEach(new Consumer<String>() {
    @Override
    public void accept(String name) {
        System.out.println(name);
    }
});
```

**Lambda approach:**

```java
List<String> names = Arrays.asList("Alice", "Bob", "Charlie");

names.forEach(name -> System.out.println(name));
```

Notice the `name` variable to the left of the `->` symbol. This is the parameter of the lambda expression. It is the same as the parameter of the above `accept` method.

Both do exactly the same thing, but the lambda version is much shorter and easier to read.


