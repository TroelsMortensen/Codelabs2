# DTOs in Java

Let's implement DTOs in Java using the Space Explorer domain as our example.

## Naming Convention

The standard naming convention for DTOs is:
- `EntityNameDTO`
- Examples: `PlanetDTO`, `ExplorerDTO`, `MissionDTO`

This makes it clear that the class is a DTO and which entity it represents.

And then, sometimes, you need different DTOs for the same entity, for different purposes. Then you should expand the name with the purpose. Examples: `PlanetSummaryDTO`, `PlanetDetailDTO`.

## Basic Structure

A DTO class typically has:
1. **Private fields** (often `final` for immutability)
2. **Constructor** (takes all fields as parameters)
3. **Getters** (one for each field)
4. **No setters** (if immutable) or simple setters (if mutable)

## Example 1: PlanetDTO

Here's a simple DTO for the `Planet` entity:

```java
public class PlanetDTO 
{
    private final int id;
    private final String name;
    private final String climateDescription;
    private final double distanceFromStarAU;
    private final boolean hasAtmosphere;
    private final boolean hasLife;
    
    public PlanetDTO(int id, String name, String climateDescription,
                     double distanceFromStarAU, boolean hasAtmosphere,
                     boolean hasLife) 
    {
        this.id = id;
        this.name = name;
        this.climateDescription = climateDescription;
        this.distanceFromStarAU = distanceFromStarAU;
        this.hasAtmosphere = hasAtmosphere;
        this.hasLife = hasLife;
    }
    
    // getters..
}
```

**Key points:**
- All fields are `final` (immutable)
- Constructor takes all fields
- Only getters, no setters
- No business logic methods

## Example 2: ExplorerDTO with Resolved Values

The `Explorer` entity has a foreign key to `Spacecraft`. The DTO should resolve this to a name:

```java
public class ExplorerDTO 
{
    private final int id;
    private final String name;
    private final String spacecraftName;  // Resolved from spacecraftId
    
    public ExplorerDTO(int id, String name, String spacecraftName) 
    {
        this.id = id;
        this.name = name;
        this.spacecraftName = spacecraftName;
    }

    // getters..
}
```

**Note:** The DTO contains `spacecraftName` (a resolved value), not `spacecraftId` (a foreign key). The business logic layer resolves the ID to a name before creating the DTO. This would require first fetching the Explorer entity, then fetching the Spacecraft entity, and getting its name. Then putting it all together in the DTO constructor.

## Example 3: MissionDTO with Collection

A `Mission` has multiple crew members (stored as IDs). The DTO could resolve these to names:

```java
import java.time.LocalDate;
import java.util.ArrayList;

public class MissionDTO 
{
    private final int id;
    private final String missionName;
    private final LocalDate startDate;
    private final LocalDate endDate;
    private final String objective;
    private final ArrayList<String> crewNames;  // Resolved from crewIds
    private final ArrayList<String> targetPlanetNames;  // Resolved from targetPlanetIds
    
    public MissionDTO(int id, String missionName, LocalDate startDate,
                      LocalDate endDate, String objective,
                      ArrayList<String> crewNames, ArrayList<String> targetPlanetNames) 
    {
        this.id = id;
        this.missionName = missionName;
        this.startDate = startDate;
        this.endDate = endDate;
        this.objective = objective;
        this.crewNames = crewNames;
        this.targetPlanetNames = targetPlanetNames;
    }
    
    // getters..
}
```

**Key points:**
- Collections are resolved (names instead of IDs)
- All fields are `final`


## Simplified DTOs for Specific Views

You might create different DTOs for different purposes:

```java
// DTO for planet list (minimal data)
public class PlanetSummaryDTO 
{
    private final int id;
    private final String name;
    
    public PlanetSummaryDTO(int id, String name) 
    {
        this.id = id;
        this.name = name;
    }

    // getters..
}

// DTO for planet details (all data)
public class PlanetDetailDTO 
{
    private final int id;
    private final String name;
    private final String climateDescription;
    private final double distanceFromStarAU;
    private final boolean hasAtmosphere;
    private final boolean hasLife;
    
    // ... constructor and getters ...
}
```

This allows the presentation layer to request only the data it needs.

## Summary

- Use naming convention: `EntityNameDTO`
- Prefer **immutable DTOs** with `final` fields
- Include **constructor** with all fields
- Provide **getters** for all fields
- **Resolve foreign keys** to names/values in DTOs
- Create **purpose-specific DTOs** for different views