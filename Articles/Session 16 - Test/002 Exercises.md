# Exercises

These exercises are borrowed from a colleague, he uses them for a midterm exam.


## Exercise 1 - Colour Palette

Implement the following UML class diagram in Java.

![Colour Palette](Resources/ColourPalette.png)

Also, include a class with a main method, to test the functionality.

## Exercise 2 - Apartment Complex

![Apartment Complex](Resources/ApartmentComplex.png)

I am not entirely sure, the relationships here are correct. But, I will leave it as is. Or let you decide how to interpret it.

## Exercise 3 - Football Club

Implement the following UML class diagram in Java.

```mermaid
classDiagram
    class FootballClub {
        - name : String
        + FootballClub(name : String)
        + signPlayer(player : FootballPlayer, fieldPosition : String, number : int) void
        + trainGoalkeepers() void
        + trainOutfieldPlayers() void
        + getCaptain() FootballPlayer
        + setNewCaptain(number : int) void
        + getPlayersInPosition(fieldPosition : String) ArrayList~FootballPlayer~
        + toString() String
    }
    
    class FootballPlayer {
        - name : String
        - skill : int
        - number : int
        - fieldPosition : String
        - isCaptain : boolean
        + FootballPlayer(name : String, skill : int)
        + getName() String
        + getNumber() int
        + assignNumber(number : int) void
        + getSkill() int
        + train() void
        + getFieldPosition() String
        + setFieldPosition(position : String) void
        + getIsCaptain() boolean
        + setIsCaptain(isCaptain : boolean) void
        + toString() String
    }
    
    FootballClub o--> FootballPlayer
```

Also, include a class with a main method to test the functionality.

## Exercise 4 - Tv Series

Implement the following UML class diagram in Java.

![Tv Series](Resources/TvSeries.png)

