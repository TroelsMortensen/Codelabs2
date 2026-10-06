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

## 3

Arrange the lines to create a valid `SoccerTeam` class with an `ArrayList` of players and an `addPlayer` method.

<Quiz>
{
  "Type": "ParsonsProblem",
  "Question": "Arrange the lines to create a SoccerTeam that holds many Players.",
  "Lines": [
    { "Id": 1, "Content": "public class SoccerTeam {" },
    { "Id": 2, "Content": "    private String teamName;" },
    { "Id": 3, "Content": "    private ArrayList&lt;Player&gt; players;" },
    { "Id": 4, "Content": "    public SoccerTeam(String teamName) {" },
    { "Id": 5, "Content": "        this.teamName = teamName;" },
    { "Id": 6, "Content": "        this.players = new ArrayList&lt;&gt;();" },
    { "Id": 7, "Content": "    }" },
    { "Id": 8, "Content": "    public void addPlayer(Player player) {" },
    { "Id": 9, "Content": "        players.add(player);" },
    { "Id": 10, "Content": "    }" },
    { "Id": 11, "Content": "}" }
  ],
  "Hint": "See page 3 One to many — create the list in the constructor, then add players in a method."
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
