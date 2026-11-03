# Quiz Recap

Check that you can read and build simple stream pipelines on lists.

## 1

Match each operation to what it does.

<Quiz>
{
  "Type": "MatchPair",
  "Title": "Match the stream operations",
  "Pairs": [
    {
      "Prompt": "filter",
      "Answer": "Keep or drop elements using a test"
    },
    {
      "Prompt": "map",
      "Answer": "Transform each element into something else"
    },
    {
      "Prompt": "forEach",
      "Answer": "Do something with each element (side effect)"
    },
    {
      "Prompt": "toList",
      "Answer": "Collect remaining elements into a new list"
    },
    {
      "Prompt": "anyMatch",
      "Answer": "Return true if at least one element passes a test"
    },
    {
      "Prompt": "count",
      "Answer": "Return how many elements remain"
    }
  ],
  "Hint": "filter keeps/drops, map changes values, forEach is for side effects, toList builds a list, anyMatch is a yes/no, count is a number."
}
</Quiz>

## 2

<Quiz>
{
  "Type": "SingleChoiceQuiz",
  "Question": "<p>How do you start a stream from a <code>List&lt;String&gt; names</code>?</p>",
  "Options": [
    {
      "Text": "<code>names.stream()</code>",
      "IsCorrect": true
    },
    {
      "Text": "<code>Stream(names)</code>",
      "IsCorrect": false
    },
    {
      "Text": "<code>new Stream&lt;String&gt;(names)</code>",
      "IsCorrect": false
    },
    {
      "Text": "<code>names.toStream()</code>",
      "IsCorrect": false
    }
  ],
  "Shuffle": true,
  "Hint": "See Creating Streams — call stream() on the list.",
  "Explanation": "The usual source is list.stream(), which returns a Stream with the list’s elements."
}
</Quiz>

## 3

Decide whether each statement is true or false.

<Quiz>
{
  "Type": "TrueFalseQuiz",
  "Statements": [
    {
      "Text": "Intermediate operations run only when a terminal operation starts the pipeline.",
      "IsCorrect": true
    },
    {
      "Text": "A stream is the same thing as a new List.",
      "IsCorrect": false
    },
    {
      "Text": "After filter and toList, the original list is unchanged.",
      "IsCorrect": true
    },
    {
      "Text": "You can call forEach twice on the same stream object.",
      "IsCorrect": false
    },
    {
      "Text": "forEach returns a new List with the results.",
      "IsCorrect": false
    },
    {
      "Text": "findFirst returns an Optional because there might be no element.",
      "IsCorrect": true
    }
  ],
  "Hint": "Review The Pipeline, Collecting Results, forEach, and Finding and Matching."
}
</Quiz>

## 4

Arrange the lines into a valid pipeline that keeps numbers greater than 10, doubles them, and collects a list.

<Quiz>
{
  "Type": "ParsonsProblem",
  "Question": "Arrange the lines so the pipeline filters n &gt; 10, maps to n * 2, and collects to a list.",
  "Lines": [
    { "Id": 1, "Content": "List&lt;Integer&gt; result = numbers.stream()" },
    { "Id": 2, "Content": "    .filter(n -&gt; n &gt; 10)" },
    { "Id": 3, "Content": "    .map(n -&gt; n * 2)" },
    { "Id": 4, "Content": "    .toList();" }
  ],
  "Hint": "Source and assignment first, then filter, then map, then the terminal toList()."
}
</Quiz>

## 5

<Quiz>
{
  "Type": "MultipleChoiceQuiz",
  "Question": "<p>Which of the following are <strong>terminal</strong> operations?</p>",
  "Options": [
    {
      "Text": "<code>forEach</code>",
      "IsCorrect": true
    },
    {
      "Text": "<code>filter</code>",
      "IsCorrect": false
    },
    {
      "Text": "<code>toList</code>",
      "IsCorrect": true
    },
    {
      "Text": "<code>map</code>",
      "IsCorrect": false
    },
    {
      "Text": "<code>count</code>",
      "IsCorrect": true
    },
    {
      "Text": "<code>sorted</code>",
      "IsCorrect": false
    }
  ],
  "Shuffle": true,
  "Hint": "Terminal operations end the pipeline and trigger the work. Intermediate ones return another stream.",
  "Explanation": "forEach, toList, and count are terminal. filter, map, and sorted are intermediate."
}
</Quiz>

## 6

Given this code:

```java
List<String> names = List.of("Ann", "Bob", "Clara");
boolean ok = names.stream().anyMatch(n -> n.length() > 4);
```

<Quiz>
{
  "Type": "SingleChoiceQuiz",
  "Question": "<p>What is the value of <code>ok</code>?</p>",
  "Options": [
    {
      "Text": "<code>true</code>",
      "IsCorrect": true
    },
    {
      "Text": "<code>false</code>",
      "IsCorrect": false
    },
    {
      "Text": "It does not compile",
      "IsCorrect": false
    },
    {
      "Text": "<code>Optional</code> with Clara inside",
      "IsCorrect": false
    }
  ],
  "Shuffle": true,
  "Hint": "anyMatch returns a boolean. Is there any name with length greater than 4?",
  "Explanation": "Clara has length 5, so at least one element matches and anyMatch returns true."
}
</Quiz>

## 7

Match each loop goal to the stream pipeline that does the same job.

<Quiz>
{
  "Type": "MatchPair",
  "Title": "Match loop goals to streams",
  "Pairs": [
    {
      "Prompt": "Print every element",
      "Answer": "stream().forEach(IO::println)"
    },
    {
      "Prompt": "New list of elements that pass a test",
      "Answer": "stream().filter(...).toList()"
    },
    {
      "Prompt": "New list after transforming each element",
      "Answer": "stream().map(...).toList()"
    },
    {
      "Prompt": "First match or a default value",
      "Answer": "stream().filter(...).findFirst().orElse(...)"
    }
  ],
  "Hint": "Printing uses forEach; building lists uses toList; a single find uses findFirst and orElse."
}
</Quiz>
