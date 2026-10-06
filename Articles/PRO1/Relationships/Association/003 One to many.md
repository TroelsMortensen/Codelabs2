# One to many association

A one-to-many association means one object knows about many objects of the same type through a collection field. There is still no ownership — other objects may also know about those same instances.

## Example: SoccerTeam and Player

A player can sometimes play for multiple teams — for example a local team and a national team. Two teams can reference the same player. That sounds like an association.

```java{3}
public class SoccerTeam
{
    private String teamName;
    private ArrayList<Player> players;

    public SoccerTeam(String teamName)
    {
        this.teamName = teamName;
        this.players = new ArrayList<>();
    }

    public void addPlayer(Player player)
    {
        players.add(player);
    }

    public ArrayList<Player> getPlayers()
    {
        return players;
    }
}

public class Player
{
    private String name;
    private int jerseyNumber;

    public Player(String name, int jerseyNumber)
    {
        this.name = name;
        this.jerseyNumber = jerseyNumber;
    }
}
```

### Usage — shared player

```java
Player star = new Player("Alex", 9);

SoccerTeam local = new SoccerTeam("Local FC");
SoccerTeam national = new SoccerTeam("National Team");

local.addPlayer(star);
national.addPlayer(star);
// Both teams know about the same Player instance
```

### Conceptual meaning

For association, the related object (here `Player`) is _not_ part of the parent object (here `SoccerTeam`). It is a separate object that the parent knows about. Other objects can also know about the same child object. There is no strong ownership.

```mermaid
classDiagram
    class SoccerTeam {
        - teamName : String
        - players : ArrayList~Player~
        + SoccerTeam(teamName : String)
        + addPlayer(player : Player) void
    }

    class Player {
        - name : String
        - jerseyNumber : int
        + Player(name : String, jerseyNumber : int)
    }
    SoccerTeam --> "*" Player
```

<Quiz>
{
    "Type": "SingleChoiceQuiz",
    "Question": "<p>Why is SoccerTeam–Player an association rather than composition?</p>",
    "Options": [
        {
            "Text": "Players can exist independently and can be referenced by multiple teams",
            "IsCorrect": true
        },
        {
            "Text": "Because an ArrayList is used",
            "IsCorrect": false
        },
        {
            "Text": "Because Player has a jersey number",
            "IsCorrect": false
        },
        {
            "Text": "Because the team creates players inside its constructor",
            "IsCorrect": false
        }
    ],
    "Shuffle": true,
    "Hint": "Look at the shared player example on this page.",
    "Explanation": "Association has no ownership. The same player can belong to more than one team, and players exist independently."
}
</Quiz>
