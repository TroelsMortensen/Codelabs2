# Advanced Features

Records can handle more complex scenarios, including collections and custom behavior.

## Records with Collections

Records can have more complex types like collections:

```java
import java.time.LocalDate;
import java.util.ArrayList;

public record MissionDTO(
    int id,
    String missionName,
    LocalDate startDate,
    LocalDate endDate,
    String objective,
    ArrayList<String> crewNames,
    ArrayList<String> targetPlanetNames
) {}
```

This works, but there's a potential issue: the collections are mutable, and external code could modify them. For DTOs, we typically want defensive copying (remember composition? No shared object references).

## Compact Constructors

You can customize the constructor using a **compact constructor** (runs after field assignment). Do pay attention to the syntax, this constructor has no parentheses for parameters.

```java{11-16}
public record MissionDTO(
    int id,
    String missionName,
    LocalDate startDate,
    LocalDate endDate,
    String objective,
    ArrayList<String> crewNames,
    ArrayList<String> targetPlanetNames
) {
    // Compact constructor (runs after field assignment)
    public MissionDTO 
    {
        // Defensive copies
        crewNames = new ArrayList<>(crewNames);
        targetPlanetNames = new ArrayList<>(targetPlanetNames);
    }
}
```

The compact constructor receives the parameters, and you can modify them before they're assigned to the fields. This ensures that any `ArrayList` passed in is copied, preventing external modification.

## Custom Accessor Methods

You can also override the accessor methods to return defensive copies:

```java
public record MissionDTO(
    int id,
    String missionName,
    LocalDate startDate,
    LocalDate endDate,
    String objective,
    ArrayList<String> crewNames,
    ArrayList<String> targetPlanetNames
) {
    // Compact constructor for defensive copying
    public MissionDTO 
    {
        crewNames = new ArrayList<>(crewNames);
        targetPlanetNames = new ArrayList<>(targetPlanetNames);
    }
    
    // Custom accessor to return defensive copy
    public ArrayList<String> crewNames() 
    {
        return new ArrayList<>(crewNames);
    }
    
    public ArrayList<String> targetPlanetNames() 
    {
        return new ArrayList<>(targetPlanetNames);
    }
}
```

This provides **double protection**: the constructor makes a copy when creating the record, and the accessor makes another copy when retrieving the data.

## Additional Methods

Records can have additional methods beyond the generated ones:

```java
public record PlanetDTO(
    int id,
    String name,
    String climateDescription,
    double distanceFromStarAU,
    boolean hasAtmosphere,
    boolean hasLife
) {
    // Additional method
    public String getDisplayName() 
    {
        return name + " (ID: " + id + ")";
    }
    
    // Another example
    public boolean isCloseToStar() 
    {
        return distanceFromStarAU < 1.0;
    }
}
```

**Note:** These are just convenience methods. They don't add state or change the record's immutability.

## Summary

- Records can handle **collections** and complex types
- Use **compact constructors** for defensive copying
- Override **accessor methods** to return defensive copies
- Add **additional methods** for convenience (but keep them simple)
- Records remain **immutable** even with these features

