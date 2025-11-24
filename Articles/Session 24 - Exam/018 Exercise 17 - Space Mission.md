# Exercise 17 - Space Mission System

Implement the following class diagram in Java:

```mermaid
classDiagram
    class SpaceAgency {
        - agencyName : String
        - budget : double
        + addMission(mission : Mission) void
        + getActiveMissions() ArrayList~Mission~
        + getTotalCost() double
        + assignCrewMember(missionId : int, crewMember : CrewMember) boolean
    }
    
    class Mission {
        - missionId : int
        - missionName : String
        - launchDate : LocalDate
        - duration : int
        - status : String
        + Mission(missionId : int, missionName : String, launchDate : LocalDate, duration : int)
        + getMissionId() int
        + getMissionName() String
        + getStatus() String
        + setStatus(status : String) void
        + getCost() double
        + isActive() boolean
    }
    
    class CrewMember {
        - memberId : int
        - name : String
        - nationality : String
        - trainingHours : int
        + CrewMember(memberId : int, name : String, nationality : String, trainingHours : int)
        + getMemberId() int
        + getName() String
        + isQualified() boolean
    }
    
    class Spacecraft {
        - name : String
        - model : String
        - maxCrewCapacity : int
        - fuelCapacity : double
        + Spacecraft(name : String, model : String, maxCrewCapacity : int, fuelCapacity : double)
        + getName() String
        + getMaxCrewCapacity() int
    }
    
    class SatelliteDeployment {
        - satelliteName : String
        - orbit : String
        + getCost() double
    }
    
    class SpaceWalk {
        - plannedDuration : int
        - objective : String
        + getCost() double
    }
    
    class PlanetaryLanding {
        - targetPlanet : String
        - landingSite : String
        + getCost() double
    }
    
    SpaceAgency --> "*" Mission : missions
    Mission --> "1" Spacecraft : spacecraft
    Mission --> "*" CrewMember : crew
    SatelliteDeployment --|> Mission
    SpaceWalk --|> Mission
    PlanetaryLanding --|> Mission
```

## Notes:
- Satellite deployment missions cost 500 million kr
- Space walk missions cost 200 million kr plus 10 million kr per hour of duration
- Planetary landing missions cost 2 billion kr for Mars, 5 billion kr for other planets
- Crew members need at least 1000 training hours to be qualified
- Mission status can be: "Planned", "Active", "Completed", "Aborted"
- Use `java.time.LocalDate` for launch dates

