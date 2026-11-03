# Filtering

`filter` keeps only the elements that pass a test. You saw it briefly in The Pipeline; here are the details. The test is a **`Predicate`**: a lambda (or method reference) that takes one element and returns `true` or `false`.

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

`filter` is intermediate; `toList()` is the terminal that gathers the remaining elements into a **new** list — the same idea as the loop’s `result` list.

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
- The original list is unchanged; `toList()` gives you a new list of the matches.
