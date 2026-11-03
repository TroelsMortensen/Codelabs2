# Collecting Results

Often you do not want to print — you want a **new list** with the results. That is what `toList()` does at the end of a pipeline.

`toList()` is a **terminal** operation. It runs the pipeline and returns a `List` containing the remaining elements.

## Loop vs stream

Build a list of names in uppercase:

**Loop:**

```java
void main() {
    List<String> names = List.of("Alice", "Bob", "Charlie");
    List<String> result = new ArrayList<>();

    for (String name : names) {
        result.add(name.toUpperCase());
    }

    IO.println(result);  // [ALICE, BOB, CHARLIE]
}
```

**Stream:**

```java
void main() {
    List<String> names = List.of("Alice", "Bob", "Charlie");

    List<String> result = names.stream()
                               .map(String::toUpperCase)
                               .toList();

    IO.println(result);  // [ALICE, BOB, CHARLIE]
}
```

## The original list stays the same

```java
void main() {
    List<String> names = List.of("Alice", "Bob", "Charlie");

    List<String> shortNames = names.stream()
                                   .filter(n -> n.length() <= 3)
                                   .toList();

    IO.println(names);       // [Alice, Bob, Charlie]
    IO.println(shortNames);  // [Bob]
}
```

Filtering and collecting create a **new** list. `names` is unchanged.

## forEach vs toList

| Goal | Use |
|------|-----|
| Do something with each element (e.g. print) | `forEach` |
| Get a `List` of results | `toList()` |

## What to remember

- `toList()` ends the pipeline and returns a new `List`.
- The source list is not modified.
- Chain `filter` / `map` (and friends) before `toList()` when you need a processed list.
