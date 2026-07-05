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
The `Options` property is required and must be set to an array of objects. Each object must have a `Text` property and a `IsCorrect` property. The `Text` property is the text of the option and can contain HTML. The `IsCorrect` property is a boolean indicating if the option is correct. There can only be one correct option.
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
The `Cards` property is required and must be set to an array of objects. Each object must have a `Front` property and a `Back` property. The `Front` property is the text shown on the front of the card and can contain HTML. The `Back` property is the text shown on the back of the card and can contain HTML. At least one card is required.
The `Title` property is optional and is a string displayed above the card grid. It can contain HTML.
