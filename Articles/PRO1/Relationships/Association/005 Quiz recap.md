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

## 3

Match each UML element to its meaning.

<Quiz>
{
  "Type": "MatchPair",
  "Title": "Association UML",
  "Pairs": [
    {
      "Prompt": "Person --> Address",
      "Answer": "Person knows about Address via a field"
    },
    {
      "Prompt": "SoccerTeam --> \"*\" Player",
      "Answer": "Team references many players"
    },
    {
      "Prompt": "Solid open arrow",
      "Answer": "Association notation"
    },
    {
      "Prompt": "Dashed open arrow",
      "Answer": "Dependency (not association)"
    }
  ],
  "Hint": "See page 4 Association in UML."
}
</Quiz>

## 4

Select every valid association scenario.

<Quiz>
{
  "Type": "MultipleChoiceQuiz",
  "Question": "<p>Which scenarios are associations?</p>",
  "Options": [
    {
      "Text": "A person knows about an address, and that address could also be used by someone else",
      "IsCorrect": true
    },
    {
      "Text": "A team holds a list of players who can also play for another team",
      "IsCorrect": true
    },
    {
      "Text": "A calculator method takes a rectangle as a parameter and does not store it",
      "IsCorrect": false
    },
    {
      "Text": "A house creates rooms internally and never shares those room instances",
      "IsCorrect": false
    }
  ],
  "Shuffle": true,
  "Hint": "Association = field reference, no ownership. Dependency has no field. Composition has exclusive ownership.",
  "Explanation": "Person–Address and Team–Player are associations. Calculator–Rectangle is a dependency. House–Room with exclusive ownership is composition."
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
