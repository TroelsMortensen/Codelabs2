# Mapping

`map` **transforms** each element into something else. The transformation is a **`Function`**: one value in, one value out.

Unlike `filter` (keep or drop), `map` keeps every element — but each one may change, and the type may change too.

## Loop vs stream

Turn each name into its length:

**Loop:**

```java
void main() {
    List<String> names = List.of("Alice", "Bob", "Charlie");
    List<Integer> lengths = new ArrayList<>();

    for (String name : names) {
        lengths.add(name.length());
    }

    IO.println(lengths);  // [5, 3, 7]
}
```

**Stream:**

```java
void main() {
    List<String> names = List.of("Alice", "Bob", "Charlie");

    List<Integer> lengths = names.stream()
                                 .map(name -> name.length())
                                 .toList();

    IO.println(lengths);  // [5, 3, 7]
}
```

The stream starts as `Stream<String>` and after `map` becomes `Stream<Integer>`.

## Method references

When the lambda only calls one method, use a method reference:

```java
void main() {
    List<String> names = List.of("Alice", "Bob", "Charlie");

    List<String> upper = names.stream()
                              .map(String::toUpperCase)
                              .toList();

    IO.println(upper);  // [ALICE, BOB, CHARLIE]
}

```

`String::toUpperCase` means the same as `name -> name.toUpperCase()`.

## Filter vs map

| Operation | Question it answers |
|-----------|---------------------|
| `filter`  | Should this element stay? |
| `map`     | What should this element become? |

## What to remember

- `map` is intermediate.
- Input type and output type can differ (`String` → `Integer`, and so on).
- Prefer a method reference when the lambda only calls one existing method.
