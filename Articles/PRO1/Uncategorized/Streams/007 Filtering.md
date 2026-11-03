# Filtering

`filter` keeps only the elements that pass a test. The test is a **`Predicate`**: a lambda (or method reference) that takes one element and returns `true` or `false`.

## Loop vs stream

Keep only numbers greater than 10:

**Loop:**

```java
void main() {
    List<Integer> numbers = List.of(4, 15, 8, 22, 11);
    List<Integer> result = new ArrayList<>();

    for (Integer n : numbers) {
        if (n > 10) {
            result.add(n);
        }
    }

    IO.println(result);  // [15, 22, 11]
}
```

**Stream:**

```java
void main() {
    List<Integer> numbers = List.of(4, 15, 8, 22, 11);

    List<Integer> result = numbers.stream()
                                  .filter(n -> n > 10)
                                  .toList();

    IO.println(result);  // [15, 22, 11]
}
```

`n -> n > 10` is the predicate. If it returns `true`, the element stays in the stream; if `false`, it is dropped.

`toList()` gathers the remaining elements into a **new** list. You will study collecting in more detail soon; for filter examples, this is the usual way to get a list result.

## Another example

Keep only the long names:

```java
void main() {
    List<String> names = List.of("Ann", "Bob", "Charlie", "Jo");

    List<String> longNames = names.stream()
                                  .filter(n -> n.length() > 3)
                                  .toList();

    IO.println(longNames);  // [Charlie]
}
```

## What to remember

- `filter` is intermediate — it returns a stream.
- The lambda must return a `boolean` (a `Predicate`).
- The original list is unchanged; you get a new list when you collect.
