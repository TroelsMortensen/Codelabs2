# Single choice quiz

How to create a single choice quiz.

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

And here is the rendered quiz:


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