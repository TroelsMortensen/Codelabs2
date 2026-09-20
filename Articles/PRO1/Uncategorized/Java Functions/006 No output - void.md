# No output — void

Sometimes a function does useful work but has **nothing to give back**. In that case the return type is **`void`**, and the function body does not require a `return` statement.

```java
void greet(String name) {
    IO.println("Hello, " + name + "!");
}

void main() {
    greet("Alice");  // prints Hello, Alice!
}
```

`greet` takes input and prints a message. It does not return a value, so you do not assign the call to a variable.

Notice there is no variable in front of the `greet("Alice")` call in line 6, the main method. Since nothing is returned, there is no value to capture in a variable.

## Return "nothing"

Even if the return type is `void`, you can still return "nothing" with a `return` statement. This actively exits the function, sometimes early. For example:

```java
void greet(String name) {
    if (name == null) {
        return; // potentially exit the function early
    }
    IO.println("Hello, " + name + "!");
}
```

In the above example, if the name is `null`, i.e. we called the function with `greet(null)`, the function will exit early and not print anything.

## Contrast with a returning function

| Has output | No output |
|------------|-----------|
| `int add(int a, int b) { return a + b; }` | `void greet(String name) { IO.println(...); }` |
| Caller can use the result: `int x = add(1, 2);` | Caller just runs it: `greet("Bob");` |
| Return type is a type like `int` or `double` | Return type is `void` |

This would be wrong:

```java
int x = greet("Alice");  // error — greet is void, nothing to store
```

Use `void` when the function’s job is to **do** something (print, update a value later in the course, and so on), not to **compute a value** for the caller.

<Quiz>
{
  "Type": "MatchPair",
  "Title": "Match return type to purpose",
  "Pairs": [
    {
      "Prompt": "int",
      "Answer": "Gives back a whole number"
    },
    {
      "Prompt": "double",
      "Answer": "Gives back a decimal number"
    },
    {
      "Prompt": "void",
      "Answer": "Gives back nothing"
    }
  ],
  "Hint": "void means no output value for the caller."
}
</Quiz>

<Quiz>
{
  "Type": "TrueFalseQuiz",
  "Statements": [
    {
      "Text": "A void function can still have parameters.",
      "IsCorrect": true
    },
    {
      "Text": "You should store the result of a void function in a variable.",
      "IsCorrect": false
    },
    {
      "Text": "void means the function has no output value.",
      "IsCorrect": true
    }
  ],
  "Hint": "void is about output, not about input."
}
</Quiz>
