# Quiz recap

Test your understanding of association relationships.

## 1

<Quiz>
{
    "Type": "SingleChoiceQuiz",
    "Question": "<p>Which code snippet is an association?</p>",
    "Options": [
        {
            "Text": "<code>private Address address;</code> inside class Person",
            "IsCorrect": true
        },
        {
            "Text": "<code>public void print(Address a) { ... }</code> with no Address field",
            "IsCorrect": false
        },
        {
            "Text": "<code>AddressValidator.isValid(street);</code> static call only",
            "IsCorrect": false
        },
        {
            "Text": "<code>class Person extends Address</code>",
            "IsCorrect": false
        }
    ],
    "Shuffle": true,
    "Hint": "See page 1 What is association — association means a field reference.",
    "Explanation": "A field of type Address is an association. A method parameter or static call alone is a dependency. Extending is inheritance, not association."
}
</Quiz>

## 2

Decide whether each statement is true or false.

<Quiz>
{
  "Type": "TrueFalseQuiz",
  "Statements": [
    {
      "Text": "In an association, both objects can exist independently.",
      "IsCorrect": true
    },
    {
      "Text": "Association implies exclusive ownership of the related object.",
      "IsCorrect": false
    },
    {
      "Text": "Two SoccerTeam objects may reference the same Player instance.",
      "IsCorrect": true
    },
    {
      "Text": "Associations can be changed at runtime, for example with changeAddress.",
      "IsCorrect": true
    }
  ],
  "Hint": "Review pages 1–3 on independence and shared references."
}
</Quiz>


## 5

<Quiz>
{
    "Type": "SingleChoiceQuiz",
    "Question": "<p>In UML, the association arrow points from Person to Address. What does that mean?</p>",
    "Options": [
        {
            "Text": "Person has a field of type Address",
            "IsCorrect": true
        },
        {
            "Text": "Address has a field of type Person",
            "IsCorrect": false
        },
        {
            "Text": "Both classes must have fields of each other's type",
            "IsCorrect": false
        },
        {
            "Text": "Person extends Address",
            "IsCorrect": false
        }
    ],
    "Shuffle": true,
    "Hint": "See page 4 — the arrow starts at the class with the field.",
    "Explanation": "The arrow starts at the class that holds the field and points to the field's type."
}
</Quiz>

## 6

<Quiz>
{
  "Type": "TrueFalseQuiz",
  "Statements": [
    {
      "Text": "With association, two Person objects can reference the same Address instance.",
      "IsCorrect": true
    },
    {
      "Text": "Association means the Person owns the Address and no other object may reference it.",
      "IsCorrect": false
    },
    {
      "Text": "changeAddress shows that associations can be changed at runtime.",
      "IsCorrect": true
    }
  ],
  "Hint": "Review the shared references section on this page."
}
</Quiz>

## 7

<Quiz>
{
  "Type": "MatchPair",
  "Title": "Match the UML Elements",
  "Pairs": [
    {
      "Prompt": "Solid open arrow (-->)",
      "Answer": "Association"
    },
    {
      "Prompt": "Arrow points to Address",
      "Answer": "Person has a field of type Address"
    },
    {
      "Prompt": "* at the arrow head",
      "Answer": "One-to-many multiplicity"
    },
    {
      "Prompt": "Arrows in both directions",
      "Answer": "Bidirectional association"
    }
  ],
  "Hint": "Review the direction and multiplicity sections on this page."
}
</Quiz>