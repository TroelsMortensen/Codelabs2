# Exercise — forEach

## Exercise 1 — Print prices

```java
List<Integer> prices = List.of(50, 120, 15, 80);
```

Print each price with `prices.stream().forEach(...)`. Use a method reference.

## Exercise 2 — Print with text

Print each price on a line like `Price: 50`. Can you use a plain method reference for the whole line, or do you need a lambda? Try both approaches and decide.

## Exercise 3 — Filter and forEach

Using `prices`, print only the prices that are **at least 50**. Do not build a new list — end the pipeline with `forEach`.

## Exercise 4 — Contrast

Change exercise 3 so it **collects** the expensive prices into a `List<Integer>` and prints the list once. Which terminal operation did you switch to?
