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

## Existing Functional Interfaces

Java provides many functional interfaces in `java.util.function`. You can use these with lambdas instead of defining your own interfaces. Here are some of the most important ones.

| Interface | Abstract method | Use when you need to… |
| --------- | --------------- | --------------------- |
| **`Consumer<T>`** | `void accept(T t)` | Take one value and do something with it (e.g. print it, add to a list). No return value. |
| **`Supplier<T>`** | `T get()` | Provide a value when asked. Takes no arguments, returns a value (e.g. lazy creation, default values). |
| **`Function<T, R>`** | `R apply(T t)` | Transform one value into another. Takes one argument, returns a result (e.g. convert, map). |
| **`Predicate<T>`** | `boolean test(T t)` | Decide yes or no for a value. Takes one argument, returns true or false (e.g. filter conditions). |
| **`UnaryOperator<T>`** | `T apply(T t)` | Transform a value into another value of the same type. Same in and out type (e.g. double a number). |

**Examples in code:**

- **Consumer**: `list.forEach(x -> System.out.println(x));` — for each element, do something.
- **Supplier**: `Supplier<Double> random = () -> Math.random();` — get a value when you call `random.get()`.
- **Function**: `Function<String, Integer> length = s -> s.length();` — string in, integer out.
- **Predicate**: `list.removeIf(x -> x < 0);` — keep only elements that pass the test.
- **UnaryOperator**: `UnaryOperator<Integer> doubleIt = n -> n * 2;` — one integer in, one integer out.

There are also **two-argument** variants: `BiConsumer<T, U>`, `BiFunction<T, U, R>`, `BiPredicate<T, U>`. They follow the same idea but take two parameters. You will see these interfaces often when using the Stream API, `Optional`, or UI event handlers.
