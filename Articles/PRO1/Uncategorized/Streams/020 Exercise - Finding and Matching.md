# Exercise — Finding and Matching

```java
List<Integer> scores = List.of(4, 7, 2, 9, 5);
```

## Exercise 1 — anyMatch (loop and stream)

Is there any score of **10 or more**? Answer with a loop (boolean flag + `break`) and with `anyMatch`. Print both results.

## Exercise 2 — allMatch

Do **all** scores pass ( ≥ 5 )? Use `allMatch` and print the boolean.

## Exercise 3 — findFirst

Find the first score that is greater than 6. Use `filter`, `findFirst`, and `orElse(-1)`. Print the value.

## Exercise 4 — No match

Change the predicate so nothing matches (for example `s > 100`). What does your `orElse(-1)` return? Print it.

## Exercise 5 — Rewrite

Rewrite this loop with `findFirst` and `orElse`:

```java
void main() {
    List<String> names = List.of("Bea", "Amy", "Clara");
    String found = "nobody";
    for (String name : names) {
        if (name.startsWith("C")) {
            found = name;
            break;
        }
    }
    IO.println(found);
}
```
