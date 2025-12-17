# Finding Entities by ID

When using foreign keys, you store IDs instead of object references. But at some point, you need to get the actual object. This is where **lookup methods** come in.

## The Problem

You have a `Mission` with `crewIds = [1, 2, 3]`. To display the crew members' names, you need to find the `Explorer` objects with those IDs.

```java
Mission apollo11 = loadMission(1);

// You have IDs, but you need Explorer objects
for (int explorerId : apollo11.getCrewIds()) 
{
    // How do we get the Explorer with this ID?
}
```

## The Solution: findById Methods

Create methods that search through your collection of entities and return the one with the matching ID. The below example uses a list for simplicity, but we will store the data in a file, and read it into a list.

### Basic Implementation

```java
public class ExplorerDataManager 
{
    private ArrayList<Explorer> explorers;
    
    public ExplorerDataManager() 
    {
        this.explorers = new ArrayList<>();
    }
    
    public void add(Explorer explorer) 
    {
        explorers.add(explorer);
    }
    
    public Explorer findById(int id) 
    {
        for (Explorer explorer : explorers) 
        {
            if (explorer.getId() == id) 
            {
                return explorer;
            }
        }
        return null;  // Not found
    }
}
```

**Usage:**
```java
ExplorerManager explorerManager = new ExplorerManager();

// Add some explorers
explorerManager.add(new Explorer("Neil Armstrong", 1));   // id = 1
explorerManager.add(new Explorer("Buzz Aldrin", 1));      // id = 2
explorerManager.add(new Explorer("Michael Collins", 1)); // id = 3

// Later, find by ID
Explorer neil = explorerManager.findById(1);
System.out.println(neil.getName());  // "Neil Armstrong"
```

## Handling Not Found

What should `findById` return if no entity has that ID? You have options:

### Option 1: Return null
```java
public Explorer findById(int id) 
{
    for (Explorer explorer : explorers) 
    {
        if (explorer.getId() == id) 
        {
            return explorer;
        }
    }
    return null;
}
```

The caller must check for null:
```java
Explorer e = explorerManager.findById(999);
if (e != null) 
{
    System.out.println(e.getName());
} 
else 
{
    System.out.println("Explorer not found");
}
```

### Option 2: Throw an Exception
```java
public Explorer findById(int id) 
{
    for (Explorer explorer : explorers) 
    {
        if (explorer.getId() == id) 
        {
            return explorer;
        }
    }
    throw new IllegalArgumentException("No explorer with ID: " + id);
}
```

The caller gets an exception if the ID doesn't exist:
```java
try 
{
    Explorer e = explorerManager.findById(999);
    System.out.println(e.getName());
} 
catch (IllegalArgumentException ex) 
{
    System.out.println(ex.getMessage());
}
```

**Which to choose?**
- Use **null** if not finding is a normal, expected case
- Use **exception** if not finding indicates a bug or data corruption



## Resolving Foreign Keys

Now we can "resolve" foreign keys to actual objects. Let's display a mission's crew:

```java
public class MissionDisplay 
{
    private MissionDataManager missionDataManager;
    private ExplorerDataManager explorerDataManager;
    private PlanetDataManager planetDataManager;
    
    public MissionDisplay(MissionDataManager missionDataManager,
                          ExplorerDataManager explorerDataManager, 
                          PlanetDataManager planetDataManager) 
    {
        this.missionDataManager = missionDataManager;
        this.explorerDataManager = explorerDataManager;
        this.planetDataManager = planetDataManager;
    }
    
    public void displayMission(int missionId) 
    {
        // First, find the mission by ID
        Mission mission = missionDataManager.findById(missionId);
        if (mission == null) 
        {
            System.out.println("Mission not found: " + missionId);
            return;
        }
        
        System.out.println("Mission: " + mission.getMissionName());
        System.out.println("Objective: " + mission.getObjective());
        
        // Resolve crew IDs to Explorer objects
        System.out.println("Crew:");
        for (int explorerId : mission.getCrewIds()) 
        {
            Explorer explorer = explorerDataManager.findById(explorerId);
            if (explorer != null) 
            {
                System.out.println("  - " + explorer.getName());
            }
        }
        
        // Resolve target planet IDs
        System.out.println("Target Planets:");
        for (int planetId : mission.getTargetPlanetIds()) 
        {
            Planet planet = planetDataManager.findById(planetId);
            if (planet != null) 
            {
                System.out.println("  - " + planet.getName());
            }
        }
    }
}
```

**Output:**
```
Mission: Apollo 11
Objective: Moon landing
Crew:
  - Neil Armstrong
  - Buzz Aldrin
  - Michael Collins
Target Planets:
  - Saturn
```

