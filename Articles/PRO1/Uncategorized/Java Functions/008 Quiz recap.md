# Quiz recap

Check that you can recognize the parts of a function, and what happens when input or output is missing.

## 1

Match each part of a function to its role.

<Quiz>
{
  "Type": "MatchPair",
  "Title": "Match the function parts",
  "Pairs": [
    {
      "Prompt": "Return type",
      "Answer": "What kind of value comes out (or void)"
    },
    {
      "Prompt": "Parameter",
      "Answer": "An input name in the definition"
    },
    {
      "Prompt": "Argument",
      "Answer": "A value passed in a call"
    },
    {
      "Prompt": "Body",
      "Answer": "The code inside the curly braces"
    }
  ],
  "Hint": "Parameters are in the definition; arguments are in the call."
}
</Quiz>

## 2

<Quiz>
{
  "Type": "SingleChoiceQuiz",
  "Question": "<p>What does <code>void</code> mean as a return type?</p>",
  "Options": [
    {
      "Text": "The function has no output value",
      "IsCorrect": true
    },
    {
      "Text": "The function has no input",
      "IsCorrect": false
    },
    {
      "Text": "The function cannot be called",
      "IsCorrect": false
    },
    {
      "Text": "The function must return the number 0",
      "IsCorrect": false
    }
  ],
  "Shuffle": true,
  "Hint": "void is about output, not about parameters.",
  "Explanation": "void means the function does not give a value back to the caller."
}
</Quiz>

## 3

<Quiz>
{
  "Type": "MultipleChoiceQuiz",
  "Question": "<p>Which of the following are true about a function with no input?</p>",
  "Options": [
    {
      "Text": "It is defined with empty parentheses, like <code>int answer()</code>",
      "IsCorrect": true
    },
    {
      "Text": "It is called with empty parentheses, like <code>answer()</code>",
      "IsCorrect": true
    },
    {
      "Text": "You leave out the parentheses completely when calling it",
      "IsCorrect": false
    },
    {
      "Text": "It cannot have a return type other than void",
      "IsCorrect": false
    }
  ],
  "Shuffle": true,
  "Hint": "Empty parentheses still count as a parameter list — just with nothing inside.",
  "Explanation": "No input means empty ( ). You can still return a value, as in <code>int answer() { return 42; }</code>."
}
</Quiz>

## 4

<Quiz>
{
  "Type": "TrueFalseQuiz",
  "Statements": [
    {
      "Text": "Defining a function runs its body immediately.",
      "IsCorrect": false
    },
    {
      "Text": "You can call the same function more than once with different arguments.",
      "IsCorrect": true
    },
    {
      "Text": "After return runs, the function stops and sends a value back to the caller.",
      "IsCorrect": true
    },
    {
      "Text": "You should write int x = greet(\"Ada\"); if greet is void.",
      "IsCorrect": false
    }
  ],
  "Hint": "Definition is the recipe; a call runs the recipe."
}
</Quiz>

## 5

Arrange the lines to define a function with input and output that doubles its parameter.

<Quiz>
{
  "Type": "ParsonsProblem",
  "Question": "Arrange the lines to create a function that returns twice its int input.",
  "Lines": [
    { "Id": 1, "Content": "int doubleIt(int x) {" },
    { "Id": 2, "Content": "    return x * 2;" },
    { "Id": 3, "Content": "}" }
  ],
  "Hint": "Signature, then return the doubled value, then closing brace."
}
</Quiz>

## 6

<Quiz>
{
  "Type": "SingleChoiceQuiz",
  "Question": "<p>Which function has input but no output?</p>",
  "Options": [
    {
      "Text": "<code>void greet(String name) { IO.println(name); }</code>",
      "IsCorrect": true
    },
    {
      "Text": "<code>int answer() { return 42; }</code>",
      "IsCorrect": false
    },
    {
      "Text": "<code>int add(int a, int b) { return a + b; }</code>",
      "IsCorrect": false
    },
    {
      "Text": "<code>void sayHello() { IO.println(\"Hi\"); }</code>",
      "IsCorrect": false
    }
  ],
  "Shuffle": true,
  "Hint": "Look for a parameter list that is not empty, and a void return type.",
  "Explanation": "greet has a String parameter (input) and void (no output). sayHello has neither input; answer and add both have output."
}
</Quiz>

## 7

Match each example to the correct combination of input and output.

<Quiz>
{
  "Type": "MatchPair",
  "Title": "Match input/output combinations",
  "Pairs": [
    {
      "Prompt": "int add(int a, int b)",
      "Answer": "Has input and has output"
    },
    {
      "Prompt": "void greet(String name)",
      "Answer": "Has input, no output"
    },
    {
      "Prompt": "int answer()",
      "Answer": "No input, has output"
    },
    {
      "Prompt": "void sayHello()",
      "Answer": "No input, no output"
    }
  ],
  "Hint": "Look at the parentheses for input, and the return type for output."
}
</Quiz>
