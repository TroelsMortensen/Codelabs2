# Quiz recap

Test your understanding of composition and how it relates to the other relationships.

## 1

Arrange the lines to create a `getRooms()` method that returns a deep copy of the list.

<Quiz>
{
  "Type": "ParsonsProblem",
  "Question": "Arrange the lines for a safe getRooms that preserves composition.",
  "Lines": [
    { "Id": 1, "Content": "public ArrayList&lt;Room&gt; getRooms() {" },
    { "Id": 2, "Content": "    ArrayList&lt;Room&gt; copy = new ArrayList&lt;&gt;();" },
    { "Id": 3, "Content": "    for (Room room : rooms) {" },
    { "Id": 4, "Content": "        copy.add(room.createCopy());" },
    { "Id": 5, "Content": "    }" },
    { "Id": 6, "Content": "    return copy;" },
    { "Id": 7, "Content": "}" }
  ],
  "Hint": "See page 4 Returning children safely — copy the list and each Room."
}
</Quiz>

## 2

<Quiz>
{
    "Type": "SingleChoiceQuiz",
    "Question": "<p>Which method breaks composition?</p>",
    "Options": [
        {
            "Text": "<code>public Room getLivingRoom() { return livingRoom; }</code>",
            "IsCorrect": true
        },
        {
            "Text": "<code>public Room getLivingRoom() { return livingRoom.createCopy(); }</code>",
            "IsCorrect": false
        },
        {
            "Text": "<code>public void addRoom(String type, double area, boolean w) { rooms.add(new Room(type, area, w)); }</code>",
            "IsCorrect": false
        },
        {
            "Text": "Creating rooms inside the House constructor",
            "IsCorrect": false
        }
    ],
    "Shuffle": true,
    "Hint": "See page 3 Copying to protect ownership.",
    "Explanation": "Returning the original child reference lets outsiders share ownership and breaks composition."
}
</Quiz>

## 3

Decide whether each statement is true or false.

<Quiz>
{
  "Type": "TrueFalseQuiz",
  "Statements": [
    {
      "Text": "In composition, the child cannot exist independently of the parent.",
      "IsCorrect": true
    },
    {
      "Text": "return new ArrayList&lt;&gt;(rooms) alone is enough when Room is mutable.",
      "IsCorrect": false
    },
    {
      "Text": "Composition uses a filled diamond in UML.",
      "IsCorrect": true
    },
    {
      "Text": "Aggregation is stronger than composition.",
      "IsCorrect": false
    }
  ],
  "Hint": "Review pages 1, 4, 6, and 7."
}
</Quiz>

## 4

Match each UML arrow to its relationship name.

<Quiz>
{
  "Type": "MatchPair",
  "Title": "Match the Four Arrows",
  "Pairs": [
    {
      "Prompt": "A ..&gt; B",
      "Answer": "Dependency"
    },
    {
      "Prompt": "C --&gt; D",
      "Answer": "Association"
    },
    {
      "Prompt": "E o--&gt; F",
      "Answer": "Aggregation"
    },
    {
      "Prompt": "G *--&gt; H",
      "Answer": "Composition"
    }
  ],
  "Hint": "See page 7 All four compared."
}
</Quiz>

## 5

Select every composition scenario.

<Quiz>
{
  "Type": "MultipleChoiceQuiz",
  "Question": "<p>Which scenarios are composition?</p>",
  "Options": [
    {
      "Text": "A house creates rooms internally; rooms have no meaning outside that house",
      "IsCorrect": true
    },
    {
      "Text": "A flying carpet binds enchantments that cannot exist apart from the carpet",
      "IsCorrect": true
    },
    {
      "Text": "A team lists players who may also play for another team",
      "IsCorrect": false
    },
    {
      "Text": "A calculator takes a rectangle as a method parameter only",
      "IsCorrect": false
    }
  ],
  "Shuffle": true,
  "Hint": "Composition = exclusive ownership and dependent lifecycle.",
  "Explanation": "House–Room and Carpet–Enchantment are composition. Team–Player is association. Calculator–Rectangle is dependency."
}
</Quiz>

## 6

Explore these scenarios. Expand each to see a suggested relationship type. (This block is for reflection — it is not scored.)

<Quiz>
{
    "Type": "ExpandableDetails",
    "Details": [
        {
            "Header": "Mountaineer and climbing gear",
            "Content": "<p>Gear can be lent, replaced, or acquired from elsewhere. That is usually <strong>aggregation</strong> (or association): whole-part / ownership that can transfer. Multiplicity: Mountaineer → * ClimbingGear.</p>"
        },
        {
            "Header": "Submarine and fish observations",
            "Content": "<p>Observations are created during the dive and lost if the expedition data is deleted. That is <strong>composition</strong>. Multiplicity: Submarine → * FishObservation.</p>"
        },
        {
            "Header": "Planet and moons",
            "Content": "<p>Moons are bound to a planet but could be argued either way; often modeled as <strong>aggregation</strong> (natural satellites as parts). Multiplicity: Planet → * Moon.</p>"
        },
        {
            "Header": "Car and serial number vs tires",
            "Content": "<p>Tires, seats, and engine can be swapped → <strong>aggregation</strong>. A serial number stamped on the chassis that cannot transfer → <strong>composition</strong>.</p>"
        },
        {
            "Header": "Space station: astronauts and modules",
            "Content": "<p>Astronauts transfer between stations → <strong>association</strong>. Detachable modules → <strong>aggregation</strong>. Internal modules built into the structure → <strong>composition</strong>.</p>"
        },
        {
            "Header": "Time machine and historical event records",
            "Content": "<p>Events exist independently in the timeline and can be observed by different machines → <strong>association</strong> (or dependency if only used temporarily). Multiplicity: TimeMachine → * HistoricalEventRecord.</p>"
        }
    ]
}
</Quiz>
