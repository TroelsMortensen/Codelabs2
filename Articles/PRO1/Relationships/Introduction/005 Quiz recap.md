# Quiz recap

Test your understanding of basic relationships before moving on to the detail paths.

## 1

Decide whether each statement is true or false.

<Quiz>
{
  "Type": "TrueFalseQuiz",
  "Statements": [
    {
      "Text": "Objects in a program often need to reference other objects to work together.",
      "IsCorrect": true
    },
    {
      "Text": "A one-to-one relationship is usually expressed with an ArrayList field.",
      "IsCorrect": false
    },
    {
      "Text": "A one-to-many relationship means one object references many objects of the same type.",
      "IsCorrect": true
    },
    {
      "Text": "Composition is a weaker relationship than dependency.",
      "IsCorrect": false
    }
  ],
  "Hint": "Review pages 1–4. One-to-one uses a single field; composition is the strongest relationship."
}
</Quiz>

## 2

<Quiz>
{
    "Type": "SingleChoiceQuiz",
    "Question": "<p>Which field creates a one-to-one relationship?</p>",
    "Options": [
        {
            "Text": "<code>private Address address;</code>",
            "IsCorrect": true
        },
        {
            "Text": "<code>private ArrayList&lt;Address&gt; addresses;</code>",
            "IsCorrect": false
        },
        {
            "Text": "<code>private String street;</code>",
            "IsCorrect": false
        },
        {
            "Text": "<code>public static void main(String[] args)</code>",
            "IsCorrect": false
        }
    ],
    "Shuffle": true,
    "Hint": "See page 2 One to one — a single reference field, not a collection.",
    "Explanation": "A one-to-one relationship is a field that holds one reference to another object, such as <code>private Address address;</code>."
}
</Quiz>



## 4

Select every correct statement.

<Quiz>
{
  "Type": "MultipleChoiceQuiz",
  "Question": "<p>Which of the following are one-to-many relationships?</p>",
  "Options": [
    {
      "Text": "A playlist contains many songs",
      "IsCorrect": true
    },
    {
      "Text": "A person has exactly one national ID number object",
      "IsCorrect": false
    },
    {
      "Text": "A library has many books",
      "IsCorrect": true
    },
    {
      "Text": "A shopping cart has many products",
      "IsCorrect": true
    }
  ],
  "Shuffle": true,
  "Hint": "See the examples on page 3 One to many — one object referencing many of the same type.",
  "Explanation": "Playlist–songs, library–books, and cart–products are one-to-many. A person with exactly one ID is one-to-one."
}
</Quiz>

## 5

<Quiz>
{
    "Type": "SingleChoiceQuiz",
    "Question": "<p>In UML, what does the star (<code>*</code>) at the arrow head mean?</p>",
    "Options": [
        {
            "Text": "Many — the class references multiple instances",
            "IsCorrect": true
        },
        {
            "Text": "The relationship is optional",
            "IsCorrect": false
        },
        {
            "Text": "The relationship is a dependency",
            "IsCorrect": false
        },
        {
            "Text": "Both classes know about each other",
            "IsCorrect": false
        }
    ],
    "Shuffle": true,
    "Hint": "See the SoccerTeam UML on page 3 One to many.",
    "Explanation": "The star at the arrow head is multiplicity: it means many instances of the class at that end."
}
</Quiz>

# 6

<Quiz>
{
    "Type": "SingleChoiceQuiz",
    "Question": "<p>How do you typically express a one-to-many relationship in Java?</p>",
    "Options": [
        {
            "Text": "With an <code>ArrayList</code> (or other collection) of the related class",
            "IsCorrect": true
        },
        {
            "Text": "With two identical field variables of the related class",
            "IsCorrect": false
        },
        {
            "Text": "With a static method that returns many objects",
            "IsCorrect": false
        },
        {
            "Text": "By making both classes extend the same parent",
            "IsCorrect": false
        }
    ],
    "Shuffle": true,
    "Hint": "Look at the players field in SoccerTeam on this page.",
    "Explanation": "A one-to-many relationship is usually a collection field, such as ArrayList, holding many references of the same type."
}
</Quiz>