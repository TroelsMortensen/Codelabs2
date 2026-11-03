# Collecting with toList

Often you do not want to print each element — you want a **new list** with the results. That is what `toList()` does at the end of a pipeline.

`toList()` is a **terminal** operation. It runs the pipeline and returns a `List` containing the remaining elements.

## Loop vs stream

Copy every name into a new list:

**Loop:**

```java
void main() {
    List<String> names = List.of("Alice", "Bob", "Charlie");
    List<String> result = new ArrayList<>();

    for (String name : names) {
        result.add(name);
    }

    IO.println(result);  // [Alice, Bob, Charlie]
}
```

**Stream:**

```java
void main() {
    List<String> names = List.of("Alice", "Bob", "Charlie");

    List<String> result = names.stream()
                               .toList();

    IO.println(result);  // [Alice, Bob, Charlie]
}
```

Both end with a new list. The stream version has no intermediate steps yet — only a source and a terminal. On the next pages you will add steps such as `filter` before `toList()`.

## The original list stays the same

```java
void main() {
    List<String> names = List.of("Alice", "Bob", "Charlie");

    List<String> copy = names.stream().toList();

    IO.println(names);  // [Alice, Bob, Charlie]
    IO.println(copy);   // [Alice, Bob, Charlie]
}
```

`toList()` creates a **new** list. The source list `names` is unchanged.

## forEach vs toList

| Goal | Use |
|------|-----|
| Do something with each element (e.g. print) | `forEach` |
| Get a `List` of results | `toList()` |

## What to remember

- `toList()` ends the pipeline and returns a new `List`.
- The source list is not modified.
- You will often write intermediate steps, then finish with `toList()`.
