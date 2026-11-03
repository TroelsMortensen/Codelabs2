# The Pipeline

Stream code is usually written as a **pipeline**: a source, then zero or more intermediate steps, then one terminal step that finishes the work.

```text
List  →  stream()  →  intermediate…  →  terminal
```

## The three parts

1. **Source** — where the elements come from, usually `list.stream()`.
2. **Intermediate operations** — steps that return another stream (for example filter or map). You can chain several.
3. **Terminal operation** — the step that ends the pipeline (for example `forEach`, `toList`, or `count`). It triggers the actual work.

## Loop vs stream

Print only names with more than three letters:

**Loop:**

```java
void main() {
    List<String> names = List.of("Ann", "Bob", "Charlie", "Jo");

    for (String name : names) {
        if (name.length() > 3) {
            IO.println(name);
        }
    }
}
```

**Stream:**

```java
void main() {
    List<String> names = List.of("Ann", "Bob", "Charlie", "Jo");

    names.stream()                 // source
         .filter(n -> n.length() > 3)  // intermediate
         .forEach(IO::println);    // terminal
}
```

Both print `Charlie`. In the stream version:

- `stream()` is the source
- `filter(...)` is intermediate — it returns a stream of the matching names
- `forEach(...)` is terminal — it runs the pipeline and prints

## Lazy intermediates

Intermediate operations wait until a terminal operation runs. If you only write `names.stream().filter(...)`, nothing has filtered yet — you still need a terminal step.

## Remember

- Every useful pipeline ends with a **terminal** operation.
- Intermediate steps describe *what* to do; the terminal step makes it happen.
