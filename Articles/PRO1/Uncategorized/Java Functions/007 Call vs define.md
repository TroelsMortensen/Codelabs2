# Call vs define

There are two different things you do with a function:

- **Define** it — write the recipe (return type, name, parameters, body)
- **Call** it — run that recipe from somewhere else (often from `main`)

```java
int doubleIt(int x) {   // definition — the recipe
    return x * 2;
}

void main() {
    int a = doubleIt(5);   // call — runs the recipe with 5
    int b = doubleIt(10);  // call again — same recipe, different argument
    IO.println(a);         // 10
    IO.println(b);         // 20
}
```

Defining the function does not run it. Only a **call** runs the body.

Calling the same function twice with different arguments shows why functions are useful: you write the rule once and reuse it.

## Four combinations

You have now seen all four combinations of input and output:

| | Has output | No output (`void`) |
|---|------------|---------------------|
| **Has input** | `int add(int a, int b)` | `void greet(String name)` |
| **No input** | `int answer()` | `void sayHello()` |

Remember:

- No input → empty `( )`, but parentheses are still required
- No output → return type `void`, and do not assign the call to a variable
