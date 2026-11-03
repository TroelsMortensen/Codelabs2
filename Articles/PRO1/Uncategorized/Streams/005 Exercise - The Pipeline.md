# Exercise — The Pipeline

## Exercise 1 — Name the parts

Look at this pipeline:

```java
List<String> words = List.of("hi", "stream", "java", "api");

words.stream()
     .filter(w -> w.length() > 3)
     .forEach(IO::println);
```

Match each part of the pipeline to its role.

<Quiz>
{
  "Type": "MatchPair",
  "Title": "Match the pipeline parts",
  "Pairs": [
    {
      "Prompt": "<code>words.stream()</code>",
      "Answer": "Source"
    },
    {
      "Prompt": "<code>.filter(w -&gt; w.length() &gt; 3)</code>",
      "Answer": "Intermediate"
    },
    {
      "Prompt": "<code>.forEach(IO::println)</code>",
      "Answer": "Terminal"
    }
  ],
  "Hint": "The source creates the stream, intermediate steps return another stream, and the terminal ends the pipeline."
}
</Quiz>

## Exercise 2 — Missing terminal

This code does not print anything useful by itself:

```java
void main() {
    List<String> words = List.of("hi", "stream", "java", "api");
    words.stream().filter(w -> w.length() > 3);
}
```

Fix it so it prints the filtered words. Which kind of operation did you add?

## Exercise 3 — Loop to pipeline

Rewrite this loop as a stream pipeline that prints the same lines:

```java
void main() {
    List<Integer> nums = List.of(2, 5, 8, 11, 14);
    for (Integer n : nums) {
        if (n % 2 == 0) {
            IO.println(n);
        }
    }
}
```
