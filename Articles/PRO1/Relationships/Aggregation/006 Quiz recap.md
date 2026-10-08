# Quiz recap

Test your understanding of aggregation relationships.

## 1

<Quiz>
{
    "Type": "SingleChoiceQuiz",
    "Question": "<p>Which UML symbol is the empty diamond?</p>",
    "Options": [
        {
            "Text": "Aggregation (<code>o--&gt;</code>)",
            "IsCorrect": true
        },
        {
            "Text": "Composition (<code>*--&gt;</code>)",
            "IsCorrect": false
        },
        {
            "Text": "Association (<code>--&gt;</code>)",
            "IsCorrect": false
        },
        {
            "Text": "Dependency (<code>..&gt;</code>)",
            "IsCorrect": false
        }
    ],
    "Shuffle": true,
    "Hint": "See page 4 Aggregation in UML.",
    "Explanation": "The empty diamond marks aggregation. The filled diamond is composition."
}
</Quiz>

## 2

Decide whether each statement is true or false.

<Quiz>
{
  "Type": "TrueFalseQuiz",
  "Statements": [
    {
      "Text": "In aggregation, the part can exist independently of the whole.",
      "IsCorrect": true
    },
    {
      "Text": "Aggregation is stronger than composition.",
      "IsCorrect": false
    },
    {
      "Text": "Java enforces that an Engine cannot belong to two cars at once.",
      "IsCorrect": false
    },
    {
      "Text": "removeEngine / addBook style methods fit the idea of transferable ownership.",
      "IsCorrect": true
    }
  ],
  "Hint": "Review pages 1, 2, and 5."
}
</Quiz>

## 3

Select every scenario that fits aggregation.

<Quiz>
{
  "Type": "MultipleChoiceQuiz",
  "Question": "<p>Which scenarios are best modeled as aggregation?</p>",
  "Options": [
    {
      "Text": "A car has an engine that can later be moved to another car",
      "IsCorrect": true
    },
    {
      "Text": "A library holds books that can be transferred to another library",
      "IsCorrect": true
    },
    {
      "Text": "A calculator method takes a rectangle parameter and does not store it",
      "IsCorrect": false
    },
    {
      "Text": "A house creates rooms internally; rooms cannot exist outside that house",
      "IsCorrect": false
    }
  ],
  "Shuffle": true,
  "Hint": "Aggregation = whole-part with transferable / independent parts. Dependency has no field. Composition has exclusive ownership.",
  "Explanation": "Car–Engine and Library–Book are aggregation. Calculator–Rectangle is dependency. House–Room with exclusive ownership is composition."
}
</Quiz>

## 4

Match each scenario to association or aggregation.

<Quiz>
{
  "Type": "MatchPair",
  "Title": "Association or Aggregation?",
  "Pairs": [
    {
      "Prompt": "Person knows about an Address; addresses can be shared",
      "Answer": "Association"
    },
    {
      "Prompt": "Car has an Engine as a part; engine can be swapped",
      "Answer": "Aggregation"
    },
    {
      "Prompt": "SoccerTeam lists Players who may play for other teams",
      "Answer": "Association"
    },
    {
      "Prompt": "Library holds Books that can move to another library",
      "Answer": "Aggregation"
    }
  ],
  "Hint": "Association = knows about, no whole-part. Aggregation = whole-part with weak ownership."
}
</Quiz>

## 5

<Quiz>
{
    "Type": "SingleChoiceQuiz",
    "Question": "<p>Why is aggregation hard to enforce in code?</p>",
    "Options": [
        {
            "Text": "Nothing stops you from passing the same part instance to two wholes",
            "IsCorrect": true
        },
        {
            "Text": "ArrayList cannot store objects",
            "IsCorrect": false
        },
        {
            "Text": "UML does not have a symbol for aggregation",
            "IsCorrect": false
        },
        {
            "Text": "Java forbids field variables of other class types",
            "IsCorrect": false
        }
    ],
    "Shuffle": true,
    "Hint": "See page 5 Limits of aggregation and the two-car Engine example.",
    "Explanation": "If the part is created outside and passed in, the same reference can be given to multiple containers — the code looks like association."
}
</Quiz>


## 6

<Quiz>
{
    "Type": "SingleChoiceQuiz",
    "Question": "<p>What best describes aggregation?</p>",
    "Options": [
        {
            "Text": "A whole-part relationship where the part can exist independently",
            "IsCorrect": true
        },
        {
            "Text": "A temporary use of another class with no field variable",
            "IsCorrect": false
        },
        {
            "Text": "Exclusive ownership where the part cannot exist without the whole",
            "IsCorrect": false
        },
        {
            "Text": "Inheritance from a parent class",
            "IsCorrect": false
        }
    ],
    "Shuffle": true,
    "Hint": "Read the definition at the top of this page.",
    "Explanation": "Aggregation is whole-part with weak ownership — the part can exist alone and ownership can transfer."
}
</Quiz>

## 7

<Quiz>
{
    "Type": "SingleChoiceQuiz",
    "Question": "<p>Which UML symbol represents aggregation?</p>",
    "Options": [
        {
            "Text": "Empty diamond at the owner end (<code>o--&gt;</code>)",
            "IsCorrect": true
        },
        {
            "Text": "Filled diamond at the owner end (<code>*--&gt;</code>)",
            "IsCorrect": false
        },
        {
            "Text": "Dashed open arrow (<code>..&gt;</code>)",
            "IsCorrect": false
        },
        {
            "Text": "Solid open arrow with no diamond (<code>--&gt;</code>)",
            "IsCorrect": false
        }
    ],
    "Shuffle": true,
    "Hint": "See the diagrams on this page — empty diamond vs filled diamond.",
    "Explanation": "Aggregation uses an empty diamond. Filled diamond is composition. Dashed arrow is dependency. Solid open arrow without diamond is association."
}
</Quiz>