# Exercise 25 - Aquarium Management System

Implement the following class diagram in Java:

```mermaid
classDiagram
    class Aquarium {
        - aquariumName : String
        - location : String
        - openingDate : LocalDate
        + addTank(tank : Tank) void
        + addAnimal(animal : MarineAnimal) void
        + getTotalVisitors() int
        + scheduleFeeding(feeding : FeedingSchedule) void
        + getTanksByType(type : String) ArrayList~Tank~
    }
    
    class Tank {
        - tankId : int
        - name : String
        - volumeLiters : double
        - waterType : String
        - temperature : double
        - capacity : int
        + Tank(tankId : int, name : String, volumeLiters : double, waterType : String, temperature : double, capacity : int)
        + getTankId() int
        + getName() String
        + addAnimal(animal : MarineAnimal) boolean
        + getCurrentPopulation() int
        + isFull() boolean
    }
    
    class MarineAnimal {
        - animalId : int
        - commonName : String
        - scientificName : String
        - dateAcquired : LocalDate
        - diet : String
        + MarineAnimal(animalId : int, commonName : String, scientificName : String, dateAcquired : LocalDate, diet : String)
        + getAnimalId() int
        + getCommonName() String
        + getDiet() String
        + getSpaceRequired() double
        + getFeedingAmount() double
    }
    
    class Fish {
        - schooling : boolean
        - length : double
        + getSpaceRequired() double
        + getFeedingAmount() double
    }
    
    class Mammal {
        - weight : double
        - breathingInterval : int
        + getSpaceRequired() double
        + getFeedingAmount() double
    }
    
    class Invertebrate {
        - hasShell : boolean
        - numberOfLegs : int
        + getSpaceRequired() double
        + getFeedingAmount() double
    }
    
    class FeedingSchedule {
        - scheduleId : int
        - animal : MarineAnimal
        - feedingTime : String
        - frequency : String
        - portionSize : double
        + FeedingSchedule(scheduleId : int, animal : MarineAnimal, feedingTime : String, frequency : String, portionSize : double)
        + getScheduleId() int
        + getFeedingTime() String
        + getNextFeedingDate() LocalDate
    }
    
    class MaintenanceLog {
        - logId : int
        - tank : Tank
        - maintenanceDate : LocalDate
        - maintenanceType : String
        - performedBy : String
        - notes : String
        + MaintenanceLog(logId : int, tank : Tank, maintenanceDate : LocalDate, maintenanceType : String, performedBy : String)
        + getLogId() int
        + getMaintenanceType() String
    }
    
    Aquarium --> "*" Tank : tanks
    Tank --> "*" MarineAnimal : animals
    Fish --|> MarineAnimal
    Mammal --|> MarineAnimal
    Invertebrate --|> MarineAnimal
    Aquarium --> "*" FeedingSchedule : feedingSchedules
    Tank --> "*" MaintenanceLog : maintenanceLogs
```

## Notes:
- Fish require 1 liter per cm of length, schooling fish need minimum 5 of same species
- Mammals require 1000 liters per kg of weight
- Invertebrates require 5 liters base space
- Fish feeding: 2% of body weight (estimated from length)
- Mammal feeding: 5% of body weight
- Invertebrate feeding: 10 grams per individual
- Water types: "Freshwater", "Saltwater", "Brackish"
- Maintenance types: "Water Change", "Filter Cleaning", "Temperature Check", "Health Inspection"
- Frequency: "Daily", "Weekly", "Monthly"
- Use `java.time.LocalDate` for dates

