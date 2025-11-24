# Exercise 3 - Farm System

Implement the following class diagram in Java:

```mermaid
classDiagram
    class Farm {
        + addField(field : Field) void
        + numberOfFields() int
        + totalSize() int
    }
    
    class Field {
        - sizeInSqMeters : int
        + getSizeInSqMeters() int
    }
    
    class GrainField {
        + yieldPrSqMeterInKg() double
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
    
    Farm --> "*" Field : fields
    GrainField --|> Field
    LettuceField --|> Field
    CornField --|> GrainField
    WheatField --|> GrainField
```

## Notes:
- A cornfield yields 10 kg pr square meter
- A wheatfield yields depending on the wheat type: common wheat yields 8 kg pr square meter, whereas spelt only yields 7 kg pr square meter
- This exercise does not require date handling

