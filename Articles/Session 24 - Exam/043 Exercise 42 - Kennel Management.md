# Exercise 42 - Kennel Management System

Implement the following class diagram in Java:

```mermaid
classDiagram
    class Kennel {
        + Kennel(owner : Person)
        + sellTo(newOwner : Person) void
        + addPet(pet : Pet) void
        + hasPet(id : String) Pet
        + sellPet(id : String) Pet
        + getPetsByBirthDates(int year : int, month : int) ArrayList~Pet~
        + isPureDogKennel() boolean
        + getAChippedCat() Cat
        + getPetsBySpecies(species : String) ArrayList~String~
        + getDogsByBirthYear(year : int) Dog[]
    }
    
    class Person {
        - name : String
        + Person(name : String, birthDate : Date)
        + getName() String
        + getBirthDate() Date
    }
    
    class Pet {
        - id : String
        - species : String
        - running_ID : int
        + Pet(birthDate : Date, species : String, prefixId : String)
        + getId() String
        + getSpecies() String
        + getBirthDate() Date
        + toString() String
    }
    
    class Cat {
        - isChipped : boolean
        + isChipped() boolean
        + toString() String
    }
    
    class Dog {
        + toString() String
    }
    
    class Date {
        - day : int
        - month : int
        - year : int
        + Date(day : int, month : int, year : int)
        + set(day : int, month : int, year : int) void
        + getDay() int
        + getMonth() int
        + getYear() int
        + copy() Date
        + toString() String
        + equals(obj : Object) boolean
    }
    
    Kennel --> "1" Person
    Kennel --> "0..*" Pet
    Pet --> "1" Date
    Pet <|-- Cat
    Pet <|-- Dog
```

## Notes:
- The `id` is generated using a prefix and a running ID counter (e.g., "Cat0001", "Dog0003")
- The prefix should be based on the species (e.g., "Cat" for cats, "Dog" for dogs)
- `running_ID` is a static counter that increments for each new pet (shared across all pets)
- `isPureDogKennel()` returns true if the kennel contains only dogs (no cats or other species)
- `getAChippedCat()` returns any one cat that is chipped, or null if none exist
- `getPetsByBirthDates()` returns pets born in the specified month and year
- `getDogsByBirthYear()` returns an array of all dogs born in the specified year
- Use `java.time.LocalDate` for date handling in your implementation (the Date class in the diagram is a custom class for practice)

