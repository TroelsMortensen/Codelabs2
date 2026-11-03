# Introduction

Streams give you a concise way to process the elements of a **list** — one step at a time — using the lambdas and method references you already know.

A stream is **not** a new list. It is a view over the elements of an existing list, with operations you can chain together.

## Why streams?

Many everyday list tasks follow the same pattern: walk every element, maybe skip some, maybe change some, then print or collect the result. You can do that with a `for` loop. Streams express the same idea in a shorter, more readable form.

## Loop vs stream

Print every name in a list:

**Loop:**

```java
void main() {
    List<String> names = List.of("Alice", "Bob", "Charlie");

    for (String name : names) {
        IO.println(name);
    }
}
```

**Stream:**

```java
void main() {
    List<String> names = List.of("Alice", "Bob", "Charlie");

    names.stream()
         .forEach(name -> IO.println(name));
}
```

Both print the same three names. The stream version says: take a stream of the list, then for each element, print it.

You can shorten the lambda with a method reference:

```java
names.stream().forEach(IO::println);
```

## What to remember

- You still have a `List`. The stream reads from it.
- Streams shine when you **filter**, **transform**, and **collect** results — you will learn those steps next.
- The lambdas you pass in are the same style you used with `forEach` on lists and with functional interfaces like `Consumer`, `Predicate`, and `Function`.
