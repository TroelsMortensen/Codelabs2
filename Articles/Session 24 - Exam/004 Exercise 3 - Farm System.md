# Exercise 3 - Farm System

Implement the following class diagram in Java:

```mermaid
classDiagram
    class Farm {
        + addField(field : Field) void
        + numberOfFields() int
        + totalSize() int
    }
    
    class _Field_ {
        # sizeInSqMeters : int
        + getSizeInSqMeters() int
    }
    
    class _GrainField_ {
        + yieldPrSqMeterInKg()* double
    }
    
    class CornField {
        + yieldPrSqMeterInKg() double
    }
    
    class WheatField {
        - WheatType : String
        + yieldPrSqMeterInKg() double
    }
    
    class LettuceField {
        - lettucesPrSqMeter : int
    }
    
    Farm --> "*" _Field_ 
    _Field_ <|-- _GrainField_
    _Field_ <|-- LettuceField
    _GrainField_ <|-- CornField
    _GrainField_ <|-- WheatField
```

## Notes:
- A cornfield yields 10 kg pr square meter
- A wheatfield yields depending on the wheat type: common wheat yields 8 kg pr square meter, whereas spelt only yields 7 kg pr square meter
- This exercise does not require date handling

