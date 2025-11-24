# Exercise 31 - Wildlife Sanctuary System

Implement the following class diagram in Java:

```mermaid
classDiagram
    class WildlifeSanctuary {
        - sanctuaryName : String
        - location : String
        - established : LocalDate
        - totalArea : double
        + addAnimal(animal : Animal) void
        + addZone(zone : Zone) void
        + scheduleFeeding(schedule : FeedingSchedule) void
        + getAnimalsByStatus(status : String) ArrayList~Animal~
        + getTotalPopulation() int
    }
    
    class Animal {
        - animalId : int
        - name : String
        - species : String
        - age : int
        - arrivalDate : LocalDate
        - healthStatus : String
        - conservationStatus : String
        + Animal(animalId : int, name : String, species : String, age : int, arrivalDate : LocalDate, conservationStatus : String)
        + getAnimalId() int
        + getName() String
        + getHealthStatus() String
        + setHealthStatus(status : String) void
        + getDailyFoodRequirement() double
        + getHabitatRequirement() String
    }
    
    class Mammal {
        - furColor : String
        - weight : double
        + getDailyFoodRequirement() double
    }
    
    class Bird {
        - wingspan : double
        - canFly : boolean
        + getDailyFoodRequirement() double
    }
    
    class Reptile {
        - length : double
        - isPoisonous : boolean
        + getDailyFoodRequirement() double
    }
    
    class Zone {
        - zoneId : int
        - zoneName : String
        - area : double
        - habitat : String
        - capacity : int
        + Zone(zoneId : int, zoneName : String, area : double, habitat : String, capacity : int)
        + getZoneId() int
        + addAnimal(animal : Animal) boolean
        + getAnimals() ArrayList~Animal~
        + isFull() boolean
    }
    
    class Caretaker {
        - caretakerId : int
        - name : String
        - specialization : String
        - yearsExperience : int
        + Caretaker(caretakerId : int, name : String, specialization : String, yearsExperience : int)
        + getCaretakerId() int
        + getName() String
        + canCareFor(animal : Animal) boolean
    }
    
    class FeedingSchedule {
        - scheduleId : int
        - animal : Animal
        - feedingTimes : ArrayList~String~
        - foodType : String
        - portionSize : double
        + FeedingSchedule(scheduleId : int, animal : Animal, foodType : String, portionSize : double)
        + getScheduleId() int
        + addFeedingTime(time : String) void
        + getDailyTotal() double
    }
    
    class MedicalRecord {
        - recordId : int
        - animal : Animal
        - checkupDate : LocalDate
        - veterinarian : String
        - diagnosis : String
        - treatment : String
        + MedicalRecord(recordId : int, animal : Animal, checkupDate : LocalDate, veterinarian : String, diagnosis : String)
        + getRecordId() int
        + getDiagnosis() String
    }
    
    WildlifeSanctuary --> "*" Animal : animals
    WildlifeSanctuary --> "*" Zone : zones
    WildlifeSanctuary --> "*" Caretaker : staff
    Mammal --|> Animal
    Bird --|> Animal
    Reptile --|> Animal
    Zone --> "*" Animal : residents
    Animal --> "*" FeedingSchedule : feedingSchedules
    Animal --> "*" MedicalRecord : medicalHistory
    Zone --> "*" Caretaker : assignedCaretakers
```

## Notes:
- Mammals: daily food = 3% of body weight (kg)
- Birds: daily food = 10% of body weight (estimated 1kg per 50cm wingspan)
- Reptiles: daily food = 5% of body weight (estimated 2kg per meter)
- Conservation status: "Extinct in Wild", "Critically Endangered", "Endangered", "Vulnerable", "Near Threatened", "Least Concern"
- Health status: "Excellent", "Good", "Fair", "Poor", "Critical"
- Habitat types: "Forest", "Grassland", "Wetland", "Desert", "Mountain"
- Caretaker specializations must match habitat type
- Endangered animals require caretakers with 5+ years experience
- Zone capacity based on animal size and habitat requirements
- Use `java.time.LocalDate` for dates

