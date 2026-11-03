# Building a Pipeline

Now put the pieces together. A typical pipeline **filters**, **transforms**, maybe **sorts**, then **collects** into a new list.

Read a pipeline **from top to bottom** (or left to right if written on one line): each step receives what the previous step produced.

## Loop vs stream

From a list of names, keep those longer than 3 letters, make them uppercase, sort them, and collect the result:

**Loop:**

```java
void main() {
    List<String> names = List.of("Ann", "Bob", "Charlie", "Jo", "Diana");
    List<String> result = new ArrayList<>();

    for (String name : names) {
        if (name.length() > 3) {
            result.add(name.toUpperCase());
        }
    }
    Collections.sort(result);

    IO.println(result);  // [CHARLIE, DIANA]
}
```

**Stream:**

```java
void main() {
    List<String> names = List.of("Ann", "Bob", "Charlie", "Jo", "Diana");

    List<String> result = names.stream()
                               .filter(n -> n.length() > 3)
                               .map(String::toUpperCase)
                               .sorted()
                               .toList();

    IO.println(result);  // [CHARLIE, DIANA]
}
```

## Walk the stream version

1. `names.stream()` — source: every name  
2. `filter(n -> n.length() > 3)` — keep `Charlie` and `Diana`  
3. `map(String::toUpperCase)` — become `CHARLIE` and `DIANA`  
4. `sorted()` — alphabetical order (already sorted here)  
5. `toList()` — terminal: new list with the result  

`sorted()` is another intermediate operation. You will see a few more useful ones on the next concept page.

## Tip

If a pipeline is hard to read, write each call on its own line, as above. That matches how you think about the steps.
