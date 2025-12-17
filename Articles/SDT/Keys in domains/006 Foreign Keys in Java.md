# Foreign Keys in Java

Let's implement foreign keys in our Java entity classes. We'll explore two approaches and understand when to use each.

## Approach 1: Object References (Traditional)

This is what you've likely been doing already - storing a reference to the actual object:

```java
public class Explorer 
{
    private int id;
    private String name;
    private Spacecraft spacecraft;  // Direct object reference
    
    public Explorer(String name, Spacecraft spacecraft) 
    {
        this.id = nextId++;
        this.name = name;
        this.spacecraft = spacecraft;
    }
    
    public Spacecraft getSpacecraft() 
    {
        return spacecraft;
    }
}
```

**Usage:**
```java
Spacecraft apollo = new Spacecraft("Apollo", "CSM", 3);
Explorer neil = new Explorer("Neil Armstrong", apollo);

// Easy to navigate
String shipName = neil.getSpacecraft().getName();  // "Apollo"
```

**Pros:**
- Simple and intuitive
- Easy navigation between objects
- Type-safe (compiler ensures you reference a Spacecraft)

**Cons:**
- Can't easily save to a file (what do you write for the spacecraft field?)
- All related objects must be in memory
- Can create complex object graphs

## Approach 2: Foreign Key (ID Reference)

Store only the ID of the related entity:

```java
public class Explorer 
{
    private int id;
    private String name;
    private int spacecraftId;  // Foreign key - just the ID
    
    public Explorer(String name, int spacecraftId) 
    {
        this.id = nextId++;
        this.name = name;
        this.spacecraftId = spacecraftId;
    }
    
    public int getSpacecraftId() 
    {
        return spacecraftId;
    }
}
```

**Usage:**
```java
Spacecraft apollo = new Spacecraft("Apollo", "CSM", 3);  // apollo.getId() = 1
Explorer neil = new Explorer("Neil Armstrong", apollo.getId());

// To get the spacecraft, you need a lookup
int shipId = neil.getSpacecraftId();  // 1
// Then find the Spacecraft with id = 1 (we'll cover this in the next page)
```

**Pros:**
- Easy to save to files (just save the integer)
- Entities are independent - can be loaded separately
- Works well with databases

**Cons:**
- Extra step to get the related object, requires potentially many data manager lookups to get all the related objects
- Less convenient for in-memory navigation

## Example: Mission with Collection of Foreign Keys

A `Mission` has multiple crew members. With foreign keys, we store a list of IDs:

```java
import java.time.LocalDate;
import java.util.ArrayList;

public class Mission 
{
    private int id;
    private String missionName;
    private LocalDate startDate;
    private LocalDate endDate;
    private String objective;
    private ArrayList<Integer> crewIds;         // FKs to Explorers
    private ArrayList<Integer> targetPlanetIds; // FKs to Planets
    
    public Mission(String missionName, LocalDate startDate, String objective) 
    {
        this.missionName = missionName;
        this.startDate = startDate;
        this.endDate = null;  // Not ended yet
        this.objective = objective;
        this.crewIds = new ArrayList<>();
        this.targetPlanetIds = new ArrayList<>();
    }
    
    // Constructor for loading
    public Mission(int id, String missionName, LocalDate startDate, 
                   LocalDate endDate, String objective,
                   ArrayList<Integer> crewIds, ArrayList<Integer> targetPlanetIds) 
    {
        this.id = id;
        this.missionName = missionName;
        this.startDate = startDate;
        this.endDate = endDate;
        this.objective = objective;
        this.crewIds = crewIds;
        this.targetPlanetIds = targetPlanetIds;
    }
    
    public void setId(int id)
    {
        this.id = id;
    }

    public void addCrewMember(int explorerId) 
    {
        if (!crewIds.contains(explorerId)) 
        {
            crewIds.add(explorerId);
        }
    }
    
    public void addTargetPlanet(int planetId) 
    {
        if (!targetPlanetIds.contains(planetId)) 
        {
            targetPlanetIds.add(planetId);
        }
    }
    
    public ArrayList<Integer> getCrewIds() 
    {
        return new ArrayList<>(crewIds);  // Return a copy, to prevent external modification
    }
    
    public ArrayList<Integer> getTargetPlanetIds() 
    {
        return new ArrayList<>(targetPlanetIds);  // Return a copy, to prevent external modification
    }
    
    public int getId() 
    {
        return id;
    }
    
    public String getMissionName() 
    {
        return missionName;
    }
    
    // ... other getters
}
```

**Usage:**
```java
// Create explorers
Explorer neil = new Explorer("Neil Armstrong", 1);      // id = 1
Explorer buzz = new Explorer("Buzz Aldrin", 1);         // id = 2
Explorer michael = new Explorer("Michael Collins", 1);  // id = 3

// Create mission with crew
Mission apollo11 = new Mission("Apollo 11", LocalDate.of(1969, 7, 16), "Moon landing");
apollo11.addCrewMember(neil.getId());     // Add explorer 1
apollo11.addCrewMember(buzz.getId());     // Add explorer 2
apollo11.addCrewMember(michael.getId());  // Add explorer 3

// The mission stores [1, 2, 3] as crew IDs
```

## Hybrid Approach: Both Object and ID

Sometimes you want the convenience of object references during runtime, but foreign keys for persistence. You can have both.

The `spacecraft` field is _transient_, it _will not_ be saved to the file. You will control the file writing manually, so you can just ignore it when writing to the file.\
The `spacecraftId` field _is_ saved to the file.

```java
public class Explorer 
{
    private int id;
    private String name;
    
    // For persistence
    private int spacecraftId;
    
    // For runtime convenience (transient - not saved)
    private Spacecraft spacecraft;
    
    public void setSpacecraft(Spacecraft spacecraft) 
    {
        this.spacecraft = spacecraft;
        this.spacecraftId = spacecraft.getId();
    }
    
    public Spacecraft getSpacecraft() 
    {
        return spacecraft;
    }
    
    public int getSpacecraftId() 
    {
        return spacecraftId;
    }
}
```

When saving, use `spacecraftId`. When loading, first load all Spacecraft objects, then "resolve" the references.

## Summary

- **Object references** are convenient but don't persist well
- **Foreign keys** (storing IDs) are essential for persistence
- For collections, use `ArrayList<Integer>` to store multiple foreign keys
- You can combine both approaches for convenience
- The add methods should check for duplicates to prevent adding the same ID twice
