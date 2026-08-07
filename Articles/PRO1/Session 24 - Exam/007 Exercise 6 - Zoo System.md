# Exercise 6 - Zoo System

Implement the following class diagram in Java:

```mermaid
classDiagram
    class Zoo {
        + Zoo()
        + addAnimal(animal : Animal) void
        + removeAnimal(index : int) void
        + getAnimal(index : int) Animal
        + totalNumberOfLegs() int
        + allFurryMammals() ArrayList~Mammal~
        + getAllInsects() ArrayList~Insect~
    }
    
    class _Animal_ {
        - numberOfLegs : int
        + Animal(numberOfLegs : int)
        + getNumberOfLegs() int
        + setNumberOfLegs(numberOfLegs : int) void
        + toString() String
        + equals(obj : Object) boolean
    }
    
    class _Vertebrate_ {
        + Vertebrate(numberOfLegs : int)
        + givesLiveBirth()* boolean
    }
    
    class Insect {
        - numberOfLegs : int
        + Insect(numberOfLegs : int)
        + getNumberOfLegs() int
    }
    
    class Mammal {
        - furLength : double
        + Mammal(numberOfLegs : int, furLength : double)
        + givesLiveBirth() boolean
        + getFurLength() double
        + setFurLength(furLength : double) void
        + hasFur() boolean
    }
    
    class Fish {
        - liveBirth : boolean
        + Fish(numberOfLegs : int, liveBirth : boolean)
        + givesLiveBirth() boolean
        + isLiveBirth() boolean
    }
    
    Zoo --> "*" _Animal_ 
    _Animal_ <|-- _Vertebrate_
    _Animal_ <|-- Insect
    _Vertebrate_ <|-- Mammal
    _Vertebrate_ <|-- Fish
```

## Notes:
- Some fish (not all) gives livebirth
- `getAllInsects()` returns all animals that are instances of the Insect class
- Fish typically have 0 legs
- Insects have 6 legs
- Mammals typically have 4 legs (but can vary)

