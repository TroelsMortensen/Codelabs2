# Exercise — Introduction

Use this list in the exercises below:

```java
List<String> cities = List.of("London", "Paris", "Rome", "Oslo");
```

## Exercise 1 — Print with a loop

In `void main()`, print each city on its own line using a normal `for` loop.

## Exercise 2 — Print with a stream

Print the same cities using `cities.stream()` and `forEach`. Try both a lambda and the method reference `IO::println`.

## Exercise 3 — Same result?

Does the stream version change the `cities` list? Print `cities` after the stream call and check.
