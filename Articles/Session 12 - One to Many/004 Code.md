# Referencing many in code

In code, we can express a one-to-many relationship by using an ArrayList of the other class. Or some other collection type. But let's use an ArrayList for now.

Let's take the `SoccerTeam` class again, and update it to reference many players. Notice the field variable is now an ArrayList of Players.

```java{3}
public class SoccerTeam {
    private String teamName;
    private ArrayList<Player> players;
    
    public SoccerTeam(String teamName) {
        this.teamName = teamName;
        this.players = new ArrayList<>();
    }
    
    public void addPlayer(Player player) {
        players.add(player);
    }
    
    public ArrayList<Player> getPlayers() {
        return players;
    }
}

public class Player {
    private String name;
    private int jerseyNumber;
    
    public Player(String name, int jerseyNumber) {
        this.name = name;
        this.jerseyNumber = jerseyNumber;
    }
}
```

There is also a method for adding players to the team.

Now, the above code, is that an association, an aggregation, or a composition? We will discuss the details on the next few pages. The rules for each type of relationship still holds, so how do we manage that?