# Exercise — Creating Streams

## Exercise 1 — Stream from a list

Given:

```java
List<Integer> numbers = List.of(10, 20, 30, 40);
```

Create a stream from `numbers` and print each value with `forEach`.

## Exercise 2 — Stream.of

Use `Stream.of` with the values `"red"`, `"green"`, and `"blue"`. Print each colour on its own line.

## Exercise 3 — Two passes

Using the `numbers` list from exercise 1, print all values with a stream, then print them again with a **second** call to `numbers.stream()`. Confirm both runs work.

What goes wrong if you store `var s = numbers.stream();`, call `s.forEach(...)`, and then call `s.forEach(...)` again? Try it and see.
