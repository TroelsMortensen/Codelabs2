# More Operations

Here are four more operations you will use often. Three are intermediate; `count` is terminal.

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

## Quick reference

| Operation   | Kind         | Role                          |
|-------------|--------------|-------------------------------|
| `sorted()`  | Intermediate | Order the elements            |
| `distinct()`| Intermediate | Remove duplicates             |
| `limit(n)`  | Intermediate | Keep only the first n         |
| `count()`   | Terminal     | How many elements remain      |
