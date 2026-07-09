# Quiz Structure

In the learning paths (or articles), various types of quizzes can be used to test the user's knowledge.

These have a specific format in the markdown files. Below, the available quiz types are described.

## Single Choice Quiz

This is the most basic quiz type. It consists of a question and a list of options. The user can select only one option.

Here is a custom Quiz element with example json data for a single choice quiz:

```html
<Quiz>
{
    "Type": "SingleChoiceQuiz",
    "Question": "<p>Which principle states that software entities should be open for extension but closed for modification?</p>",
    "Options": [
        {
            "Text": "SRP",
            "IsCorrect": false
        },
        {
            "Text": "OCP",
            "IsCorrect": true
        },
        {
            "Text": "LSP",
            "IsCorrect": false
        }
    ],
    "Shuffle": true,
    "Hint": "Think about adding new functionality without touching existing code.",
    "Explanation": "The Open/Closed Principle (OCP) is the second of the SOLID principles."
}
</Quiz>
```

The `Type` property is required and must be set to `SingleChoiceQuiz`.
The `Question` property is required and must be set to a string, it can contain HTML.
The `Options` property is required and must be set to an array of objects. Each object must have a `Text` property and a `IsCorrect` property. The `Text` property is the text of the option and can contain HTML. The `IsCorrect` property is a boolean indicating if the option is correct. There can only be one correct option. There can be any number of options.
The `Shuffle` property is optional and is a boolean indicating if the options should be shuffled. If not set, the options will not be shuffled.
The `Hint` property is optional and is a string containing a hint for the user. It can contain HTML.
The `Explanation` property is optional and is a string containing an explanation for the user. It can contain HTML.

## Multiple Choice Quiz

This quiz type is similar to the Single Choice Quiz: it consists of a question and a list of options. The difference is that the user can select multiple options, and more than one option can be correct. The answer is only counted as correct when all correct options are selected and no incorrect options are selected.

Here is a custom Quiz element with example json data for a multiple choice quiz:

```html
<Quiz>
{
    "Type": "MultipleChoiceQuiz",
    "Question": "<p>Which of the following are SOLID principles?</p>",
    "Options": [
        {
            "Text": "Single Responsibility Principle",
            "IsCorrect": true
        },
        {
            "Text": "Open/Closed Principle",
            "IsCorrect": true
        },
        {
            "Text": "Dependency Inversion Pattern",
            "IsCorrect": false
        },
        {
            "Text": "Don't Repeat Yourself",
            "IsCorrect": false
        }
    ],
    "Shuffle": true,
    "Hint": "Two of these are named principles from the SOLID acronym.",
    "Explanation": "SRP and OCP are SOLID principles. DIP is close in name but the SOLID principle is Dependency Inversion Principle. DRY is a general guideline, not part of SOLID."
}
</Quiz>
```

The `Type` property is required and must be set to `MultipleChoiceQuiz`.
The `Question` property is required and must be set to a string, it can contain HTML.
The `Options` property is required and must be set to an array of objects. Each object must have a `Text` property and a `IsCorrect` property. The `Text` property is the text of the option and can contain HTML. The `IsCorrect` property is a boolean indicating if the option is correct. One or more options can be correct, unlike the Single Choice Quiz which allows exactly one. There can be any number of options.
The `Shuffle` property is optional and is a boolean indicating if the options should be shuffled. If not set, the options will not be shuffled.
The `Hint` property is optional and is a string containing a hint for the user. It can contain HTML.
The `Explanation` property is optional and is a string containing an explanation for the user. It can contain HTML.

## Flash Card Set

This quiz type is a set of flash cards. Each card shows a question or phrase on the front; the user clicks the card to flip it and reveal the answer on the back. Cards are displayed in a responsive grid (three columns by default, fewer on narrower screens).

Here is a custom Quiz element with example json data for a flash card set:

```html
<Quiz>
{
  "Type": "FlashCardSet",
  "Title": "General Knowledge",
  "Cards": [
    {
      "Front": "What is the capital of France?",
      "Back": "Paris"
    },
    {
      "Front": "What is the result of 2 + 2?",
      "Back": "4"
    },
    {
      "Front": "What language runs in the browser?",
      "Back": "JavaScript"
    }
  ]
}
</Quiz>
```

The `Type` property is required and must be set to `FlashCardSet`.
The `Cards` property is required and must be set to an array of objects. Each object must have a `Front` property and a `Back` property. The `Front` property is the text shown on the front of the card and can contain HTML. The `Back` property is the text shown on the back of the card and can contain HTML. At least one card is required. There can be any number of cards, more than one.
The `Title` property is optional and is a string displayed above the card grid. It can contain HTML.

## Expandable Details

This type renders a stack of expandable detail rows. Each row has a header and hidden content that can be expanded by the user.

Here is a custom Quiz element with example json data for an expandable details block:

```html
<Quiz>
{
    "Type": "ExpandableDetails",
    "Details": [
        {
            "Header": "What is the capital of France?",
            "Content": "<p>Paris</p>"
        },
        {
            "Header": "What does SOLID stand for?",
            "Content": "<p>Single Responsibility, Open/Closed, Liskov Substitution, Interface Segregation, and Dependency Inversion.</p>"
        }
    ]
}
</Quiz>
```

The `Type` property is required and must be set to `ExpandableDetails`.
The `Details` property is required and must be an array of objects.
Each detail object must have a `Header` property and a `Content` property. Both are strings and can contain HTML.
At least one detail item is required. There can be any number of detail items.

## StepGuide

This type renders a guided, step-by-step information block. It includes a centered title and a sequence of details where each item has a header and content. The UI treats the first item as an introduction and the last item as a conclusion based on position.

Here is a custom Quiz element with example json data for a step guide block:

```html
<Quiz>
{
    "Type": "StepGuide",
    "Title": "World Capitals",
    "Details": [
        {
            "Header": "This is the introduction to the quiz block.",
            "Content": "<p>This guide introduces the reader to different capital cities of the world.</p>"
        },
        {
            "Header": "Berlin",
            "Content": "<p>Berlin is the capital of Germany.</p>"
        },
        {
            "Header": "Paris",
            "Content": "<p>Paris is the capital of France.</p>"
        },
        {
            "Header": "London",
            "Content": "<p>London is the capital of England.</p>"
        },
        {
            "Header": "Conclusion",
            "Content": "<p>This guide has introduced the reader to different capital cities of the world.</p>"
        }
    ]
}
</Quiz>
```

The `Type` property is required and must be set to `StepGuide`.
The `Title` property is required and must be a string. It is displayed above the step panel and can contain HTML.
The `Details` property is required and must be an array of objects.
Each detail object must have a `Header` property and a `Content` property. Both are strings and can contain HTML.
At least one detail item is required. There can be any number of detail items.
The first and last detail items are not a different data shape. Their introduction/conclusion behavior is determined by their position in the list.

## MatchPair

This quiz type presents a set of prompt/answer pairs that the user must match. Prompts appear in the left column and answers in the right column, both shuffled. The user selects a prompt and an answer to combine them into a pair. Paired items move to the bottom of the board and can be clicked to undo. When all pairs are made, the user can submit to check their answers.

Here is a custom Quiz element with example json data for a match pair quiz:

```html
<Quiz>
{
  "Type": "MatchPair",
  "Title": "Match the Java Concepts",
  "Pairs": [
    {
      "Prompt": "int",
      "Answer": "A 32-bit signed integer"
    },
    {
      "Prompt": "boolean",
      "Answer": "Represents true or false"
    },
    {
      "Prompt": "char",
      "Answer": "A single 16-bit Unicode character"
    }
  ]
}
</Quiz>
```

The `Type` property is required and must be set to `MatchPair`.
The `Title` property is required and must be a string displayed above the matching board. It can contain HTML.
The `Pairs` property is required and must be an array of objects. Each object must have a `Prompt` property and an `Answer` property. Both are strings and can contain HTML. At least one pair is required. There can be any number of pairs.

## TrueFalseQuiz

This quiz type presents a set of statements. The user must choose whether each statement is true or false. The quiz is only submittable once all statements are answered, and results show which statements were correct or incorrect.

Here is a custom Quiz element with example json data for a true/false quiz:

```html
<Quiz>
{
  "Type": "TrueFalseQuiz",
  "Statements": [
    {
      "Text": "boolean represents true or false.",
      "IsCorrect": true
    },
    {
      "Text": "char is a single 16-bit Unicode character.",
      "IsCorrect": false
    },
    {
      "Text": "decimal is a floating-point type with binary precision only.",
      "IsCorrect": false
    }
  ]
}
</Quiz>
```

The `Type` property is required and must be set to `TrueFalseQuiz`.
The `Statements` property is required and must be an array of objects.
Each statement object must have a `Text` property and an `IsCorrect` property. The `Text` property is the statement shown to the user and can contain HTML. The `IsCorrect` property is a boolean that marks the expected answer (`true` means the statement is true, `false` means the statement is false).
At least one statement is required. There can be any number of statements.

## ParsonsProblem

This quiz type presents a shuffled list of lines. The user drags lines to reorder them in a single Solution area, then submits to check whether each line is in the correct position.

Here is a custom Quiz element with example json data for a Parsons problem:

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

The `Type` property is required and must be set to `ParsonsProblem`.
The `Question` property is required and must be a string shown above the line list. It can contain HTML.
The `Lines` property is required and must be an array of objects.
Each line object must have an `Id` property and a `Content` property. The `Id` property is an integer used to define the intended correct order. The `Content` property is the displayed line text and can contain HTML.
At least one line is required. There can be any number of lines.
