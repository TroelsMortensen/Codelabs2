# Quiz recap

Test your understanding of dependency relationships.

## 1

Match each code situation to the form of dependency.

<Quiz>
{
  "Type": "MatchPair",
  "Title": "Match the Dependency Form",
  "Pairs": [
    {
      "Prompt": "EmailValidator.isValidEmail(email)",
      "Answer": "Static method call"
    },
    {
      "Prompt": "calculateArea(Rectangle rectangle)",
      "Answer": "Method parameter"
    },
    {
      "Prompt": "Person p = new Person(\"Alice\", 30);",
      "Answer": "Local creation"
    },
    {
      "Prompt": "return new Address(...);",
      "Answer": "Return value"
    }
  ],
  "Hint": "See page 2 Dependency in code for the four forms."
}
</Quiz>

## 2

Decide whether each statement is true or false.

<Quiz>
{
  "Type": "TrueFalseQuiz",
  "Statements": [
    {
      "Text": "A dependency means one class stores another in a field variable.",
      "IsCorrect": false
    },
    {
      "Text": "All stronger relationships (association, aggregation, composition) are also kinds of dependency underneath.",
      "IsCorrect": true
    },
    {
      "Text": "Dependencies are always shown in every UML class diagram.",
      "IsCorrect": false
    },
    {
      "Text": "When both a dependency and an association exist, you should show the association.",
      "IsCorrect": true
    }
  ],
  "Hint": "Review pages 1 and 3 — dependency has no field, and diagrams show the strongest relationship."
}
</Quiz>

## 3

<Quiz>
{
    "Type": "SingleChoiceQuiz",
    "Question": "<p>Which UML arrow means dependency?</p>",
    "Options": [
        {
            "Text": "<code>A ..&gt; B</code> (dashed open arrow)",
            "IsCorrect": true
        },
        {
            "Text": "<code>A --&gt; B</code> (solid open arrow)",
            "IsCorrect": false
        },
        {
            "Text": "<code>A o--&gt; B</code> (empty diamond)",
            "IsCorrect": false
        },
        {
            "Text": "<code>A *--&gt; B</code> (filled diamond)",
            "IsCorrect": false
        }
    ],
    "Shuffle": true,
    "Hint": "See page 3 Dependency in UML.",
    "Explanation": "Dependency uses a dashed line with an open arrowhead."
}
</Quiz>

## 4

Select every line that creates a dependency (and not an association).

<Quiz>
{
  "Type": "MultipleChoiceQuiz",
  "Question": "<p>Which of the following create a dependency (no permanent field reference)?</p>",
  "Options": [
    {
      "Text": "<code>public void print(Person p) { ... }</code>",
      "IsCorrect": true
    },
    {
      "Text": "<code>private Person person;</code>",
      "IsCorrect": false
    },
    {
      "Text": "<code>boolean ok = EmailValidator.isValidEmail(email);</code>",
      "IsCorrect": true
    },
    {
      "Text": "<code>Person local = new Person(\"Bob\", 20);</code> inside a method, not stored in a field",
      "IsCorrect": true
    }
  ],
  "Shuffle": true,
  "Hint": "See page 4 Dependency vs association — a field means association; parameters, static calls, and locals alone are dependency.",
  "Explanation": "Method parameters, static calls, and local creation are dependencies. A field variable is an association."
}
</Quiz>

## 5

<Quiz>
{
    "Type": "SingleChoiceQuiz",
    "Question": "<p>In <code>Calculator ..&gt; Rectangle</code>, which class depends on which?</p>",
    "Options": [
        {
            "Text": "<code>Calculator</code> depends on <code>Rectangle</code>",
            "IsCorrect": true
        },
        {
            "Text": "<code>Rectangle</code> depends on <code>Calculator</code>",
            "IsCorrect": false
        },
        {
            "Text": "Both depend on each other",
            "IsCorrect": false
        },
        {
            "Text": "Neither depends on the other",
            "IsCorrect": false
        }
    ],
    "Shuffle": true,
    "Hint": "The arrow starts at the dependent class and points to the class it uses. See page 3.",
    "Explanation": "The dashed arrow starts at Calculator and points to Rectangle, so Calculator depends on Rectangle."
}
</Quiz>


## 6 

<Quiz>
{
    "Type": "SingleChoiceQuiz",
    "Question": "<p>Which UML arrow represents a dependency?</p>",
    "Options": [
        {
            "Text": "A dashed line with an open arrowhead (<code>..&gt;</code>)",
            "IsCorrect": true
        },
        {
            "Text": "A solid line with an open arrowhead (<code>--&gt;</code>)",
            "IsCorrect": false
        },
        {
            "Text": "A solid line with an empty diamond (<code>o--&gt;</code>)",
            "IsCorrect": false
        },
        {
            "Text": "A solid line with a filled diamond (<code>*--&gt;</code>)",
            "IsCorrect": false
        }
    ],
    "Shuffle": true,
    "Hint": "See the basic notation at the top of this page.",
    "Explanation": "Dependency uses a dashed open arrow. Solid open arrow is association; empty diamond is aggregation; filled diamond is composition."
}
</Quiz>

## 7


<Quiz>
{
    "Type": "SingleChoiceQuiz",
    "Question": "<p>Which change turns a dependency into an association?</p>",
    "Options": [
        {
            "Text": "Storing the other object in a field variable",
            "IsCorrect": true
        },
        {
            "Text": "Calling a static method on the other class",
            "IsCorrect": false
        },
        {
            "Text": "Passing the other object as a method parameter",
            "IsCorrect": false
        },
        {
            "Text": "Creating the other object as a local variable",
            "IsCorrect": false
        }
    ],
    "Shuffle": true,
    "Hint": "Compare Version 1 and Version 2 on this page.",
    "Explanation": "A field variable creates a permanent reference — that is association. Parameters, locals, and static calls alone are dependency."
}
</Quiz>
