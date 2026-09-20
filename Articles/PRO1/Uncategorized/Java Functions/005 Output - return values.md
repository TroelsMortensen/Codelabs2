# Output — return values

The **output** of a function is the value it gives back. You declare what kind of value that is with the **return type**, and you send the value with a **`return`** statement.

```java
double half(double n) {
    return n / 2;
}
```

- Return type: `double` — the function promises to give back a `double`
- `return n / 2;` — this is the actual output

## Using the result

The caller can store the result in a variable, or use it directly.

```java
double half(double n) {
    return n / 2;
}

void main() {
    double result = half(10);  // result is 5.0
    IO.println(result);
    IO.println(half(8));       // prints 4.0
}
```

When `return` runs, the function stops and sends that value back to the caller, which above is the main method.

Keep the return type and the value after `return` in sync: if the type is `int`, return an `int`; if it is `double`, return a `double`.

Arrange the lines for a function that returns the sum of two integers.

<Quiz>
{
  "Type": "ParsonsProblem",
  "Question": "Arrange the lines to create a function that returns the sum of two ints.",
  "Lines": [
    { "Id": 1, "Content": "int add(int a, int b) {" },
    { "Id": 2, "Content": "    return a + b;" },
    { "Id": 3, "Content": "}" }
  ],
  "Hint": "Signature first, then return the sum, then close the brace."
}
</Quiz>

<Quiz>
{
  "Type": "SingleChoiceQuiz",
  "Question": "<p>After <code>int result = add(3, 7);</code>, what does <code>result</code> hold if <code>add</code> returns <code>a + b</code>?</p>",
  "Options": [
    {
      "Text": "10",
      "IsCorrect": true
    },
    {
      "Text": "3",
      "IsCorrect": false
    },
    {
      "Text": "7",
      "IsCorrect": false
    },
    {
      "Text": "Nothing — you cannot store a function result",
      "IsCorrect": false
    }
  ],
  "Shuffle": true,
  "Hint": "The value after return becomes the result of the call.",
  "Explanation": "add(3, 7) returns 3 + 7, which is 10, so result holds 10."
}
</Quiz>
