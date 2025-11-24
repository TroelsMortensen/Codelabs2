# Exercise 6 - Zoo System

Implement the following class diagram in Java:

```mermaid
classDiagram
    class Zoo {
        + addAnimal(animal : Animal) void
        + removeAnimal(index : int) void
        + getAnimal(index : int) Animal
        + totalNumberOfLegs() int
        + allFurryMammals() ArrayList~Mammal~
    }
    
    class _Animal_ {
        - numberOfLegs : int
        + getNumberOfLegs() int
        + toString() String
        + equals(obj : Object) boolean
    }
    
    class _Vertebrate_ {
        + givesLiveBirth()* boolean
    }
    
    class Insect {
        - numberOfLegs : int
    }
    
    class Mammal {
        - furLength : double
        + givesLiveBirth() boolean
        + getFurLength() double
        + hasFur() boolean
    }
    
    class Fish {
        - liveBirth : boolean
        + givesLiveBirth() boolean
    }
    
    Zoo --> "*" _Animal_ 
    _Animal_ <|-- _Vertebrate_
    _Animal_ <|-- Insect
    _Vertebrate_ <|-- Mammal
    _Vertebrate_ <|-- Fish
```

## Notes:
- Some fish (not all) gives livebirth

