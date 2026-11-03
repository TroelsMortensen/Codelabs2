# forEach

`forEach` is a **terminal** operation. It takes each remaining element and **does something** with it — usually print, or later trigger UI behaviour. That “do something” is a **`Consumer`**: one argument, no return value.

`forEach` does **not** produce a new list. When you need a list result, you will use `toList()` instead — that comes a few pages later.

## Loop vs stream

Print every score:

**Loop:**

```java
void main() {
    List<Integer> scores = List.of(7, 9, 4, 10);

    for (Integer score : scores) {
        IO.println(score);
    }
}
```

**Stream:**

```java
void main() {
    List<Integer> scores = List.of(7, 9, 4, 10);

    scores.stream()
          .forEach(score -> IO.println(score));
}
```

With a method reference:

```java
scores.stream().forEach(IO::println);
```

## Combined with filter

Print only the passing scores:

```java
void main() {
    List<Integer> scores = List.of(7, 9, 4, 10);

    scores.stream()
          .filter(s -> s >= 5)
          .forEach(IO::println);
}
```

This prints `7`, `9`, and `10`. There is no new list — only printing.

## What to remember

- `forEach` ends the pipeline (terminal).
- Use it for side effects such as printing.
- If you need the results as a `List`, do not use `forEach` — collect instead.
