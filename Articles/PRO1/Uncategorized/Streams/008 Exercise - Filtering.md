# Exercise — Filtering

Use this list:

```java
List<Integer> temperatures = List.of(12, 5, 18, 3, 21, 9);
```

## Exercise 1 — Warm days (loop)

With a `for` loop, build a new list of temperatures that are **at least 10**. Print the result.

## Exercise 2 — Warm days (stream)

Solve the same task with `filter` and `toList()`. Compare the printed results.

## Exercise 3 — Short names

Given:

```java
List<String> names = List.of("Ann", "Alexander", "Bo", "Christina", "Li");
```

Use a stream to keep only names with **length ≤ 3**. Store them in a `List<String>` and print it.

## Exercise 4 — Predicate as method

Write a method `boolean isEven(int n)` and filter a list of integers with a **method reference** to that method. Print the even numbers as a list.
