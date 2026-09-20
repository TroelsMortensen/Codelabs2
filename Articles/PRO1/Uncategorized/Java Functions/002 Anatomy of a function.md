# Anatomy of a function

A Java function has a few named parts. Look at this example:

```java
int addOne(int x) {
    return x + 1;
}
```

| Part | In the example | What it means |
|------|----------------|---------------|
| **Return type** | `int` | What kind of value the function gives back, could also be `String`, `boolean`, etc. |
| **Name** | `addOne` | How you refer to the function when you call it. All functions must have a name. |
| **Parameter list** | `(int x)` or `(int x, int y)` | The inputs, written inside parentheses, we must declare the type of each input. Several inputs are comma-separated. |
| **Body** | `{ return x + 1; }` | The code that runs — the rule |

Putting it together, the syntax is:

```text
returnType  name  ( parameters )  { body }

     int   addOne (   int x    )  { return x + 1; }
```

The curly braces `{ }` mark the start and end of the body. Everything inside them runs when the function is called.

You will learn more about return types and parameters on the next pages. For now, focus on recognizing the four parts.

<Quiz>
{
  "Type": "MatchPair",
  "Title": "Match the function parts",
  "Pairs": [
    {
      "Prompt": "Return type",
      "Answer": "What kind of value comes out"
    },
    {
      "Prompt": "Name",
      "Answer": "How you call the function"
    },
    {
      "Prompt": "Parameter list",
      "Answer": "The inputs inside ( )"
    },
    {
      "Prompt": "Body",
      "Answer": "The code inside { }"
    }
  ],
  "Hint": "Look at the table on this page: return type, name, parameters, body."
}
</Quiz>
