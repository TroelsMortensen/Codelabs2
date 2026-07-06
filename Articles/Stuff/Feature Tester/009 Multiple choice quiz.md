# Multiple choice quiz

How to create a multiple choice quiz.

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

And here is the rendered quiz:


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
