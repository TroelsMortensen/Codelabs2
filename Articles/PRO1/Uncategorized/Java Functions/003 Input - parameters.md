# Input — parameters

The **inputs** of a function are called **parameters**. You declare them inside the parentheses when you define the function.

```java
int addOne(int x) {
    return x + 1;
}
```

Here, `int x` is a parameter: the function expects one `int`, and inside the body you can use the name `x`. 

This function expects two parameters: first name and last name, and produces a full name:

```java
String fullName(String firstName, String lastName) {
    return firstName + " " + lastName;
}
```

Notice the return type is `String`, because that is the _type_ of the output.

## Calling with an argument

When you **call** the function, you pass a value into that parameter. That _value_ is called an **argument**.

Below we see the `addOne` function, which is called by the main method in line 2. We pass the argument `4` as the argument, and the output of the function is captured in the variable `result`, which is then printed.

```java
void main() {
    int result = addOne(4);  // 4 is the argument
    IO.println(result);      // prints 5
}

int addOne(int x) {
    return x + 1;
}
```

- **Parameter**: the name in the definition (`x`)
- **Argument**: the value you pass in the call (`4`)

## More than one parameter

You can list several parameters, separated by commas. Order and types must match when you call.

```java
int add(int a, int b) {
    return a + b;
}

void main() {
    int result = add(3, 7);  // a gets 3, b gets 7
    IO.println(result);      // prints 10
}
```

If you swap the order, the wrong values go into the wrong parameters. If the types do not match, the program will not compile.

<Quiz>
{
  "Type": "SingleChoiceQuiz",
  "Question": "<p>In <code>addOne(4)</code>, what is <code>4</code>?</p>",
  "Options": [
    {
      "Text": "A parameter",
      "IsCorrect": false
    },
    {
      "Text": "An argument",
      "IsCorrect": true
    },
    {
      "Text": "A return type",
      "IsCorrect": false
    },
    {
      "Text": "The function body",
      "IsCorrect": false
    }
  ],
  "Shuffle": true,
  "Hint": "Parameters are in the definition; arguments are the values you pass when calling.",
  "Explanation": "The parameter is <code>x</code> in the definition. The argument is the value <code>4</code> passed in the call."
}
</Quiz>

Arrange the lines to define a function that takes one `int` parameter and returns that number plus one.

<Quiz>
{
  "Type": "ParsonsProblem",
  "Question": "Arrange the lines to create a function that adds one to its input.",
  "Lines": [
    { "Id": 1, "Content": "int addOne(int x) {" },
    { "Id": 2, "Content": "    return x + 1;" },
    { "Id": 3, "Content": "}" }
  ],
  "Hint": "Signature first, then the return statement, then the closing brace."
}
</Quiz>
