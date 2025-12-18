# What are DTOs?

A **Data Transfer Object (DTO)** is a simple object designed to carry data between different parts of an application, between layers, or between a client program and a server program. It's a "data container" with no business logic, just field variables, a constructor, and getters (and setters).

## Definition

A DTO is:
- A **simple class** with fields and getters (maybe setters)
- **No business logic** - just data
- **No behavior** - no complex methods
- **Purpose-built** - designed for a specific data transfer need

## Characteristics of DTOs

### 1. Only Data, No Logic

DTOs contain fields and simple accessors. They don't have business methods:

```java
// ✅ Good DTO
public class PlanetDTO 
{
    private int id;
    private String name;
    private String climateDescription;
    
    public PlanetDTO(int id, String name, String climateDescription) 
    {
        this.id = id;
        this.name = name;
        this.climateDescription = climateDescription;
    }
    
    public int getId() { return id; }
    public String getName() { return name; }
    public String getClimateDescription() { return climateDescription; }
}

// ❌ Bad DTO (has business logic)
public class PlanetDTO 
{
    // ... fields ...
    
    public boolean isHabitable()  // ❌ Business logic!
    {
        return hasAtmosphere && hasLife;
    }
}
```

### 2. Simple Getters and Setters

DTOs typically have straightforward getters. Setters are rarely needed (DTOs can be immutable):

```java
// Immutable DTO (recommended)
public class PlanetDTO 
{
    private final int id;
    private final String name;
    private final String climateDescription;
    
    public PlanetDTO(int id, String name, String climateDescription) 
    {
        this.id = id;
        this.name = name;
        this.climateDescription = climateDescription;
    }
    
    // Only getters, no setters
    public int getId() { return id; }
    public String getName() { return name; }
    public String getClimateDescription() { return climateDescription; }
}
```

### 3. No Entity Relationships

DTOs don't contain references to other entities. Instead, they contain:
- **IDs** (foreign keys) if needed for reference
- **Resolved values** (names, descriptions) instead of entity references

```java
// Domain Entity (has relationships)
public class Explorer 
{
    private int id;
    private String name;
    private int spacecraftId;  // Foreign key
    // ...
}

// DTO (no relationships, just resolved data)
public class ExplorerDTO 
{
    private int id;
    private String name;
    private String spacecraftName;  // ✅ Resolved value, not an ID or reference
    // ...
}
```

### 4. Purpose-Specific

A DTO is designed for a specific use case. You might have different DTOs for different purposes:

```java
// DTO for displaying planet in a list
public class PlanetSummaryDTO 
{
    private int id;
    private String name;
    // Only essential fields for a list view
}

// DTO for displaying planet details
public class PlanetDetailDTO 
{
    private int id;
    private String name;
    private String climateDescription;
    private double distanceFromStarAU;
    private boolean hasAtmosphere;
    private boolean hasLife;
    // All fields for a detail view
}
```

## DTOs vs Domain Entities

Let's compare DTOs with domain entities:

| Aspect | Domain Entity | DTO |
|--------|--------------|-----|
| **Purpose** | Represents a business concept | Transfers data |
| **Business Logic** | Contains business methods | No business logic |
| **Relationships** | Has foreign keys, references other entities | Has IDs or resolved values |
| **Complexity** | Can be complex with methods | Simple, flat structure |
| **Mutability** | Often mutable (can change state) | Often immutable |
| **Lifecycle** | Managed by business logic | Created, used, discarded |
| **Location** | Business Logic layer | Passed between layers |

### Example: Planet Entity vs PlanetDTO

```java
// Domain Entity (Business Logic Layer)
public class Planet 
{
    private int id;
    private String name;
    private String climateDescription;
    private double distanceFromStarAU;
    private boolean hasAtmosphere;
    private boolean hasLife;
    
    // Business logic methods
    public boolean isHabitable() 
    {
        return hasAtmosphere && hasLife && distanceFromStarAU < 2.0;
    }
    
    public double calculateTravelTime(double speed) 
    {
        return distanceFromStarAU * 149.6 / speed;  // AU to km conversion
    }
    
    // Foreign keys (relationships)
    private int starSystemId;  // References another entity
}

// DTO (Transfer between layers)
public class PlanetDTO 
{
    private int id;
    private String name;
    private String climateDescription;
    private double distanceFromStarAU;
    private boolean hasAtmosphere;
    private boolean hasLife;
    private String starSystemName;  // Resolved value, not an ID
    
    // Constructor
    public PlanetDTO(int id, String name, String climateDescription,
                     double distanceFromStarAU, boolean hasAtmosphere,
                     boolean hasLife, String starSystemName) 
    {
        this.id = id;
        this.name = name;
        this.climateDescription = climateDescription;
        this.distanceFromStarAU = distanceFromStarAU;
        this.hasAtmosphere = hasAtmosphere;
        this.hasLife = hasLife;
        this.starSystemName = starSystemName;
    }
    
    // Only getters - no business logic, no setters
    public int getId() { return id; }
    public String getName() { return name; }
    // ... other getters
}
```

## When to Use DTOs

Use DTOs when:
- ✅ Passing data between layers (especially to presentation layer)
- ✅ You want to hide domain structure from other layers
- ✅ You need to combine data from multiple entities
- ✅ You need to format data differently for display
- ✅ You're building APIs (client-server communication)

Don't use DTOs when:
- ❌ You're working entirely within one layer
- ❌ The data structure is exactly what you need (rare)
- ❌ You're over-engineering a simple application

## Summary

- DTOs are **simple data containers** with no business logic
- They contain **only fields and getters** (often immutable)
- They have **no entity relationships** (just IDs or resolved values)
- They are **purpose-specific** for data transfer
- They differ from entities: entities have logic, DTOs are just data

