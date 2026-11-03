# Creating Streams

To use stream operations, you first need a stream. The most common way is to create one from a list you already have.

## From a list

Call `stream()` on the list:

```java
void main() {
    List<String> names = List.of("Alice", "Bob", "Charlie");

    var stream = names.stream();
}
```

`names.stream()` gives you a `Stream<String>` — one element for each string in the list, in order.

Creating the stream does **not** process the elements yet. Work starts only when you add a **terminal** operation (you will see that on the next concept page). For example, nothing is printed here until `forEach` runs:

```java
void main() {
    List<String> names = List.of("Alice", "Bob", "Charlie");

    names.stream()
         .forEach(IO::println);
}
```

## From a few values

If you only have a handful of values and no list yet, you can use `Stream.of`:

```java
void main() {
    Stream.of("Alice", "Bob", "Charlie")
          .forEach(IO::println);
}
```

For this learning path, you will almost always start from a `List` with `list.stream()`.

## One stream, one use

A stream can be consumed only **once**. After a terminal operation finishes, you cannot reuse that same stream object. If you need to process the list again, call `stream()` on the list a second time.

```java
void main() {
    List<Integer> numbers = List.of(1, 2, 3);

    numbers.stream().forEach(IO::println);  // ok
    numbers.stream().forEach(IO::println);  // ok — new stream from the list
}
```
