# Expandable details

How to create an expandable details block.

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
        },
        {
            "Header": "Why use expandable sections?",
            "Content": "<p>They help keep pages scannable while still making detailed explanations available on demand.</p>"
        }
    ]
}
</Quiz>
```

And here is the rendered block:

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
        },
        {
            "Header": "Why use expandable sections?",
            "Content": "<p>They help keep pages scannable while still making detailed explanations available on demand.</p>"
        }
    ]
}
</Quiz>
