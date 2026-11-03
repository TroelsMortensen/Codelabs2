# Exercise — Collecting Results

## Exercise 1 — Collect uppercase

```java
List<String> products = List.of("tea", "coffee", "milk", "sugar");
```

Use a stream to create a new list of uppercase product names. Print both the new list and `products` afterward. Did `products` change?

## Exercise 2 — Loop vs stream

Rewrite this loop with a stream that ends in `toList()`:

```java
void main() {
    List<Integer> values = List.of(1, 2, 3, 4, 5);
    List<Integer> doubled = new ArrayList<>();
    for (Integer v : values) {
        doubled.add(v * 2);
    }
    IO.println(doubled);
}
```

## Exercise 3 — Filter and collect

From `products`, collect a list of names that start with a letter **before** `"n"` in the alphabet (e.g. use `p.charAt(0) < 'n'`). Print the list.

## Exercise 4 — Choose the terminal

When would you end a pipeline with `forEach`, and when with `toList()`? Write one sentence for each.
