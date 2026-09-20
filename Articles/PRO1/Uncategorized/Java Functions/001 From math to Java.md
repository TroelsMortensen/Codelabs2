# From math to Java

In mathematics, a **function** takes an input, applies a rule, and produces an output.

For example:

```text
f(x) = x + 1
```

- The **input** is `x`
- The **rule** is “add one”
- The **output** is `x + 1`

If you give the function the input `4`, the output is `5`:

```text
f(4) = 4 + 1 = 5
```

Another function may take two inputs, apply a rule, and produce an output:

```text
g(x, y) = x + y
```

The above is just a function, which adds two numbers together. For example:

```text
g(2, 3) = 2 + 3 = 5
```

And so, a mathematical function always takes one or more inputs, and always produces an output.

## The same idea in Java

A Java **function** works in a similar way (with a bit more wiggle room): you give it something (or nothing), it runs some code, and it may give something back.

Here is a rough side-by-side of the math idea and a Java function:

| Math | Java |
|------|------|
| `f(x) = x + 1` | `int addOne(int x) { return x + 1; }` |
| Input: `x` | Input: parameter `x` |
| Output: `x + 1` | Output: the value after `return` |

You do not need to memorize the Java syntax yet. The important idea is:

**input → rule → output**

On the next pages you will learn how to write and call functions in Java.

<Quiz>
{
  "Type": "TrueFalseQuiz",
  "Statements": [
    {
      "Text": "A function takes an input, applies a rule, and can produce an output.",
      "IsCorrect": true
    },
    {
      "Text": "In math, f(x) = x + 1 means the rule is “multiply by one”.",
      "IsCorrect": false
    },
    {
      "Text": "A Java function is the same idea as a mathematical function: input, rule, and possibly an output.",
      "IsCorrect": true
    }
  ],
  "Hint": "Think of input → rule → output."
}
</Quiz>
