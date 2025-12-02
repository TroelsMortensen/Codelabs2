# Exercise 17 - Space Mission System

Implement the following class diagram in Java:

```mermaid
classDiagram
    class SpaceAgency {
        - agencyName : String
        - budget : double
        + SpaceAgency(agencyName : String, budget : double)
        + getAgencyName() String
        + getBudget() double
        + setBudget(budget : double) void
        + addMission(mission : Mission) void
        + getActiveMissions() ArrayList~Mission~
        + getTotalCost() double
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
        + getLaunchDate() LocalDate
        + getDuration() int
        + getStatus() String
        + setStatus(status : String) void
        + assignCrewMember(crewMember : CrewMember) boolean
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
        + getNationality() String
        + getTrainingHours() int
        + isQualified() boolean
    }
    
    class Spacecraft {
        - name : String
        - model : String
        - maxCrewCapacity : int
        - fuelCapacity : double
        + Spacecraft(name : String, model : String, maxCrewCapacity : int, fuelCapacity : double)
        + getName() String
        + getModel() String
        + getMaxCrewCapacity() int
        + getFuelCapacity() double
    }
    
    class SatelliteDeployment {
        - satelliteName : String
        - orbit : String
        + SatelliteDeployment(missionId : int, missionName : String, launchDate : LocalDate, duration : int, satelliteName : String, orbit : String)
        + getSatelliteName() String
        + getOrbit() String
        + getCost() double
    }
    
    class SpaceWalk {
        - plannedDuration : int
        - objective : String
        + SpaceWalk(missionId : int, missionName : String, launchDate : LocalDate, duration : int, plannedDuration : int, objective : String)
        + getPlannedDuration() int
        + getObjective() String
        + getCost() double
    }
    
    SpaceAgency --> "*" _Mission_
    Spacecraft <-- _Mission_
    CrewMember "*" <-- _Mission_
    _Mission_ <|-- SatelliteDeployment
    _Mission_ <|-- SpaceWalk
```

## Notes:
- `getCost()` in `Mission` is abstract (marked with *)
- Satellite deployment missions cost 500 million kr
- Space walk missions cost 200 million kr plus 10 million kr per hour of planned duration
- Crew members need at least 1000 training hours to be qualified
- Mission status can be: "Planned", "Active", "Completed", "Aborted"
- Use `java.time.LocalDate` for launch dates

## Extensions:

### SpaceAgency
- **Current fields:** `agencyName : String`, `budget : double`
- **Possible extensions:** `foundedYear : int`, `country : String`, `totalMissions : int`, `successfulMissions : int`, `headquarters : String`, `director : String`, `partnerships : ArrayList<String>`

### Mission (abstract)
- **Current fields:** `missionId : int`, `missionName : String`, `launchDate : LocalDate`, `duration : int`, `status : String`
- **Possible extensions:** `endDate : LocalDate`, `budget : double`, `priority : String`, `objectives : ArrayList<String>`, `risks : ArrayList<String>`, `backupPlan : String`
- **Current subclasses:** `SatelliteDeployment`, `SpaceWalk`
- **Possible subclasses:** `PlanetaryExploration`, `SpaceStationResupply`, `AsteroidMining`, `TelescopeDeployment`, `MarsColonization`, `LunarLanding`

### CrewMember
- **Current fields:** `memberId : int`, `name : String`, `nationality : String`, `trainingHours : int`
- **Possible extensions:** `dateOfBirth : LocalDate`, `role : String`, `specialization : String`, `missionsCompleted : int`, `certifications : ArrayList<String>`, `medicalClearance : boolean`, `emergencyContact : String`

### Spacecraft
- **Current fields:** `name : String`, `model : String`, `maxCrewCapacity : int`, `fuelCapacity : double`
- **Possible extensions:** `manufacturer : String`, `launchYear : int`, `status : String`, `totalMissions : int`, `weight : double`, `maxSpeed : double`, `equipment : ArrayList<String>`

### SatelliteDeployment
- **Current fields:** `satelliteName : String`, `orbit : String`
- **Possible extensions:** `satelliteType : String`, `purpose : String`, `expectedLifespan : int`, `powerSource : String`, `communicationBand : String`

### SpaceWalk
- **Current fields:** `plannedDuration : int`, `objective : String`
- **Possible extensions:** `actualDuration : int`, `safetyRating : int`, `equipmentUsed : ArrayList<String>`, `challengesEncountered : String`, `suitType : String`


