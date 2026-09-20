# No input

Sometimes a function needs **no input**. The parameter list is then empty — but you still write the parentheses. The parentheses define the list of parameters, and now it is just an empty list.

```java
int answer() {
    return 42;
}

void main() {
    int result = answer();  // still need ()
    IO.println(result);     // prints 42
}
```

## Empty parentheses are still required

- When you **define** the function: `int answer()`
- When you **call** the function: `answer()`

Leaving out `()` on a call is a mistake. The parentheses tell Java that you are calling the function.

<Quiz>
{
  "Type": "TrueFalseQuiz",
  "Statements": [
    {
      "Text": "A function with no input is written with empty parentheses: ( ).",
      "IsCorrect": true
    },
    {
      "Text": "You can call a no-input function without parentheses, like answer instead of answer().",
      "IsCorrect": false
    },
    {
      "Text": "Empty parentheses mean the function has no parameters.",
      "IsCorrect": true
    }
  ],
  "Hint": "Parentheses are always part of defining and calling a function — they may just be empty."
}
</Quiz>

<Quiz>
{
  "Type": "SingleChoiceQuiz",
  "Question": "<p>Which call is correct for a function defined as <code>int answer()</code>?</p>",
  "Options": [
    {
      "Text": "<code>answer()</code>",
      "IsCorrect": true
    },
    {
      "Text": "<code>answer</code>",
      "IsCorrect": false
    },
    {
      "Text": "<code>answer[]</code>",
      "IsCorrect": false
    },
    {
      "Text": "<code>answer{}</code>",
      "IsCorrect": false
    }
  ],
  "Shuffle": true,
  "Hint": "Calling always uses parentheses, even when there are no arguments.",
  "Explanation": "You call it with <code>answer()</code>. The empty parentheses show there are no arguments."
}
</Quiz>
