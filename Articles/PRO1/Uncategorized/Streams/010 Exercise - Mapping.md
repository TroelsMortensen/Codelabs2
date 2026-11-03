# Exercise — Mapping

## Exercise 1 — Lengths (loop)

Given:

```java
List<String> animals = List.of("cat", "elephant", "dog", "hippo");
```

Use a loop to build a `List<Integer>` of each animal name’s length. Print it.

## Exercise 2 — Lengths (stream)

Solve the same task with `map` and `toList()`. Try `name -> name.length()` and then `String::length`.

## Exercise 3 — Uppercase

Using the same `animals` list, create a new list where every name is uppercase. Use a stream and a method reference.

## Exercise 4 — Filter then map

From `animals`, keep only names longer than 3 letters, then map them to uppercase, then collect to a list. Print the result.

Expected idea: `[ELEPHANT, HIPPO]` (order preserved from the source list).
