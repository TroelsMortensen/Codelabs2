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
    
    class _Mission_ {
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
        + getCost()* double
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
    
    SpaceAgency --> "*" _Mission_
    _Mission_ --> "1" Spacecraft
    _Mission_ --> "*" CrewMember
    _Mission_ <|-- SatelliteDeployment
    _Mission_ <|-- SpaceWalk
    _Mission_ <|-- PlanetaryLanding
```

## Notes:
- Satellite deployment missions cost 500 million kr
- Space walk missions cost 200 million kr plus 10 million kr per hour of duration
- Planetary landing missions cost 2 billion kr for Mars, 5 billion kr for other planets
- Crew members need at least 1000 training hours to be qualified
- Mission status can be: "Planned", "Active", "Completed", "Aborted"
- Use `java.time.LocalDate` for launch dates

