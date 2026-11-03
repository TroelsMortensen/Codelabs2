# Exercise — More Operations

Use this list where needed:

```java
List<Integer> data = List.of(5, 1, 5, 3, 9, 1, 7, 3);
```

## Exercise 1 — sorted

Create a sorted list from `data` with a stream. Print it.

## Exercise 2 — distinct

Create a list of unique values from `data` (no duplicates). Print it. Then chain `distinct()` and `sorted()` and print that result too.

## Exercise 3 — limit

From the sorted unique values, keep only the **first three** using `limit`. Collect and print.

## Exercise 4 — count

How many values in `data` are greater than 4? Solve with a loop and with `filter` + `count`. Print both answers.

## Exercise 5 — Mini pipeline

```java
List<String> words = List.of("one", "two", "three", "two", "four", "three", "five");
```

Produce a sorted list of the **distinct** words, but only the first **4** of that sorted distinct sequence. Print it.
