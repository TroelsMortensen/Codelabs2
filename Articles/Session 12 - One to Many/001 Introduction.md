# More relationships

In the previous session, you learned about different types of relationships between objects:

- depedency
- association
- aggregation
- composition

And you learned about how these were expressed in code and UML.

Another point was, that each relationship was a one-to-one relationship. Meaning an object referenced another single object. There were some situations, with associations, where multiple objects referenced the same object. But still, each object referenced only one other object. And in the code, it looked something like this, with the field variable being a single object:

```java{3}
public class Person {
    private String name;
    private Address livesAt;

    public Person(String name, Address livesAt) {
        this.name = name;
        this.livesAt = livesAt;
    }
}
```

But, this is not always enough. 

Consider this example: A soccer-team has many players. How would we express this in code? Sure, we could flip it, and say that a player plays on a soccer team. Then I might do this code:

```java{2}
public class Player {
    private String name;
    private SoccerTeam playsFor;

    public Player(String name, SoccerTeam playsFor) {
        this.name = name;
        this.playsFor = playsFor;
    }
}

public class SoccerTeam {
    private String name;

    public SoccerTeam(String name) {
        this.name = name;
    }
}
```

Notice the association in line 3. The `Player` class knows which team they play for. But the `SoccerTeam` class does not know which players play for it.

So, in this learning path, we expand our understanding of relationships.