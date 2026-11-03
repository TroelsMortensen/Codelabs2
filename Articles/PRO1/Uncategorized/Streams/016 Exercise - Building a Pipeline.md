# Exercise — Building a Pipeline

## Exercise 1 — Rewrite the loop

Rewrite this as a stream pipeline. Keep the same steps and the same result:

```java
void main() {
    List<String> titles = List.of("jaws", "up", "inception", "it", "dune");
    List<String> result = new ArrayList<>();

    for (String title : titles) {
        if (title.length() > 2) {
            result.add(title.toUpperCase());
        }
    }
    Collections.sort(result);
    IO.println(result);
}
```

## Exercise 2 — Read a pipeline

What does this print? Figure it out **before** running it, then verify:

```java
void main() {
    List<Integer> nums = List.of(9, 2, 7, 2, 5, 9, 1);

    List<Integer> result = nums.stream()
                               .filter(n -> n > 3)
                               .distinct()
                               .sorted()
                               .toList();

    IO.println(result);
}
```

## Exercise 3 — Your own pipeline

Start from:

```java
List<String> names = List.of("Mia", "Noah", "Olivia", "Liam", "Eve");
```

Build a pipeline that:

1. Keeps names with length ≥ 4  
2. Maps them to lowercase (they may already be mixed — use `String::toLowerCase`)  
3. Sorts them  
4. Collects to a list  

Print the result.
