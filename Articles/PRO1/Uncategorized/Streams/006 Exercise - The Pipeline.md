# Exercise — The Pipeline

## Exercise 1 — Name the parts

Look at this pipeline:

```java
List<String> words = List.of("hi", "stream", "java", "api");

words.stream()
     .filter(w -> w.length() > 3)
     .forEach(IO::println);
```

Write down which part is the **source**, which is **intermediate**, and which is **terminal**.

## Exercise 2 — Missing terminal

This code does not print anything useful by itself:

```java
void main() {
    List<String> words = List.of("hi", "stream", "java", "api");
    words.stream().filter(w -> w.length() > 3);
}
```

Fix it so it prints the filtered words. Which kind of operation did you add?

## Exercise 3 — Loop to pipeline

Rewrite this loop as a stream pipeline that prints the same lines:

```java
void main() {
    List<Integer> nums = List.of(2, 5, 8, 11, 14);
    for (Integer n : nums) {
        if (n % 2 == 0) {
            IO.println(n);
        }
    }
}
```
