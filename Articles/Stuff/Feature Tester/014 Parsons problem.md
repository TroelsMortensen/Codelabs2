# Parsons problem

How to create a Parsons problem quiz.

```html
<Quiz>
{
  "Type": "ParsonsProblem",
  "Question": "Arrange the lines to create a valid Java method that returns the sum of two integers.",
  "Lines": [
    { "Id": 1, "Content": "public int sum(int a, int b) {" },
    { "Id": 2, "Content": "    int result = a + b;" },
    { "Id": 3, "Content": "    return result;" },
    { "Id": 4, "Content": "}" }
  ]
}
</Quiz>
```

And here is the rendered quiz:

<Quiz>
{
  "Type": "ParsonsProblem",
  "Question": "Arrange the lines to create a valid Java method that returns the sum of two integers.",
  "Lines": [
    { "Id": 1, "Content": "public int sum(int a, int b) {" },
    { "Id": 2, "Content": "    int result = a + b;" },
    { "Id": 3, "Content": "    return result;" },
    { "Id": 4, "Content": "}" }
  ]
}
</Quiz>
