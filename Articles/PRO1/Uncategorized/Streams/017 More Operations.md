# More Operations

Here are more operations you will use often. Some are intermediate; others are terminal and finish the pipeline with a single result.

## sorted

Puts elements in natural order (alphabetically for strings, numerically for integers).

**Loop idea:** copy into a new list, then `Collections.sort`.

**Stream:**

```java
void main() {
    List<String> names = List.of("Charlie", "Alice", "Bob");

    List<String> sorted = names.stream()
                               .sorted()
                               .toList();

    IO.println(sorted);  // [Alice, Bob, Charlie]
}
```

## distinct

Keeps only unique elements (duplicates are removed). Order of first appearance is kept.

**Loop vs stream:**

```java
void main() {
    List<Integer> numbers = List.of(1, 2, 2, 3, 1, 4);

    // Loop
    List<Integer> uniqueLoop = new ArrayList<>();
    for (Integer n : numbers) {
        if (!uniqueLoop.contains(n)) {
            uniqueLoop.add(n);
        }
    }

    // Stream
    List<Integer> uniqueStream = numbers.stream()
                                        .distinct()
                                        .toList();

    IO.println(uniqueLoop);    // [1, 2, 3, 4]
    IO.println(uniqueStream);  // [1, 2, 3, 4]
}
```

## limit

Keeps only the first *n* elements.

```java
void main() {
    List<String> names = List.of("Alice", "Bob", "Charlie", "Diana");

    List<String> firstTwo = names.stream()
                                 .limit(2)
                                 .toList();

    IO.println(firstTwo);  // [Alice, Bob]
}
```

## skip

Drops the first *n* elements and keeps the rest.

```java
void main() {
    List<String> names = List.of("Alice", "Bob", "Charlie", "Diana");

    List<String> withoutFirstTwo = names.stream()
                                        .skip(2)
                                        .toList();

    IO.println(withoutFirstTwo);  // [Charlie, Diana]
}
```

### Using skip and limit together

Together they let you take a **slice** of the stream — useful for “page 2”, “page 3”, and so on.

- `skip(n)` — ignore the first *n* elements  
- `limit(m)` — then take the next *m* elements  

Example: page size 2. Page 1 is the first two names; page 2 skips those two and takes the next two:

```java
void main() {
    List<String> names = List.of("Alice", "Bob", "Charlie", "Diana", "Eve");

    int pageSize = 2;
    int pageNumber = 2;  // second page (1-based)

    List<String> page = names.stream()
                             .skip((pageNumber - 1) * pageSize)
                             .limit(pageSize)
                             .toList();

    IO.println(page);  // [Charlie, Diana]
}
```

Order matters: **skip first, then limit**. If you limit first, you only ever look at the beginning of the list, and skip has little left to work with.

## count

Terminal operation: returns how many elements are left in the stream, as a `long`.

**Loop vs stream:**

```java
void main() {
    List<Integer> numbers = List.of(4, 15, 8, 22, 11);

    // Loop
    int countLoop = 0;
    for (Integer n : numbers) {
        if (n > 10) {
            countLoop++;
        }
    }

    // Stream
    long countStream = numbers.stream()
                              .filter(n -> n > 10)
                              .count();

    IO.println(countLoop);    // 3
    IO.println(countStream);  // 3
}
```

You do not need `toList()` when you only care about the number.

## sum, average, min, max

For numeric summaries on a `List<Integer>`, first turn the stream into an **`IntStream`** with `mapToInt`. Then you can call `sum`, `average`, `min`, and `max`.

```java
void main() {
    List<Integer> numbers = List.of(4, 15, 8, 22, 11);

    int sum = numbers.stream()
                     .mapToInt(n -> n)
                     .sum();

    double average = numbers.stream()
                            .mapToInt(n -> n)
                            .average()
                            .orElse(0);

    int min = numbers.stream()
                     .mapToInt(n -> n)
                     .min()
                     .orElse(0);

    int max = numbers.stream()
                     .mapToInt(n -> n)
                     .max()
                     .orElse(0);

    IO.println(sum);      // 60
    IO.println(average);  // 12.0
    IO.println(min);      // 4
    IO.println(max);      // 22
}
```

`sum()` always returns an `int` (or `0` if the stream is empty).

`average()`, `min()`, and `max()` may have no value if the stream is empty, so use `.orElse(...)` to pick a fallback — the same idea as with `findFirst` later in this path.

You can still filter first, then summarise:

```java
void main() {
    List<Integer> numbers = List.of(4, 15, 8, 22, 11);

    int maxAboveTen = numbers.stream()
                             .filter(n -> n > 10)
                             .mapToInt(n -> n)
                             .max()
                             .orElse(0);

    IO.println(maxAboveTen);  // 22
}
```

## Quick reference

| Operation    | Kind         | Role                                      |
|--------------|--------------|-------------------------------------------|
| `sorted()`   | Intermediate | Order the elements                        |
| `distinct()` | Intermediate | Remove duplicates                         |
| `limit(n)`   | Intermediate | Keep only the first n                     |
| `skip(n)`    | Intermediate | Drop the first n                          |
| `count()`    | Terminal     | How many elements remain                  |
| `mapToInt`   | Intermediate | Turn values into an `IntStream`           |
| `sum()`      | Terminal     | Add the numbers (`IntStream`)             |
| `average()`  | Terminal     | Mean of the numbers (`IntStream`)         |
| `min()`      | Terminal     | Smallest number (`IntStream`)             |
| `max()`      | Terminal     | Largest number (`IntStream`)              |
