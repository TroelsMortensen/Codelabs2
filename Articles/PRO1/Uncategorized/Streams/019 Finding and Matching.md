# Finding and Matching

Sometimes you do not need a whole new list. You only need to know **whether** something matches, or to **find the first** match.

## anyMatch

`anyMatch` is terminal. It returns `true` if **at least one** element passes the predicate, otherwise `false`.

**Loop vs stream:**

```java
void main() {
    List<Integer> scores = List.of(3, 7, 4, 9);

    // Loop
    boolean foundLoop = false;
    for (Integer s : scores) {
        if (s >= 10) {
            foundLoop = true;
            break;
        }
    }

    // Stream
    boolean foundStream = scores.stream()
                                .anyMatch(s -> s >= 10);

    IO.println(foundLoop);    // false
    IO.println(foundStream);  // false
}
```

Related terminals (same idea, different question):

- `allMatch(predicate)` — are **all** elements matching?
- `noneMatch(predicate)` — are **no** elements matching?

## findFirst

`findFirst` is terminal. It returns the first element left in the stream — but wrapped in an **`Optional`**, because the stream might be empty.

Think of `Optional` as a box that either contains a value or is empty. For now you only need `orElse` to unwrap it:

```java
optional.orElse(defaultValue)
```

If the box has a value, you get that value; if empty, you get the default.

**Loop vs stream:**

```java
void main() {
    List<String> names = List.of("Ann", "Bob", "Charlie", "Jo");

    // Loop
    String foundLoop = null;
    for (String name : names) {
        if (name.length() > 3) {
            foundLoop = name;
            break;
        }
    }
    if (foundLoop == null) {
        foundLoop = "none";
    }

    // Stream
    String foundStream = names.stream()
                              .filter(n -> n.length() > 3)
                              .findFirst()
                              .orElse("none");

    IO.println(foundLoop);    // Charlie
    IO.println(foundStream);  // Charlie
}
```

## When to use which

| Goal | Operation |
|------|-----------|
| Yes/no: does any element match? | `anyMatch` |
| Yes/no: do all match? | `allMatch` |
| Get the first match (or a default) | `filter` + `findFirst` + `orElse` |
| Get all matches as a list | `filter` + `toList` |

## What to remember

- Matching operations return a `boolean`.
- `findFirst` returns an `Optional` — use `orElse` when you want a plain value.
- These are terminal: they end the pipeline.
