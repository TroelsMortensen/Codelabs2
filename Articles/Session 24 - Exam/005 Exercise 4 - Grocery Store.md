# Exercise 4 - Grocery Store System

Implement the following class diagram in Java:

```mermaid
classDiagram
    class GroceryStore {
        + getExpiredPerishableFood() ArrayList~PerishableFood~
    }
    
    class Aisle {
        - aisleNumber : int
        - category : String
        + getAisleNumber() int
        + getProducts() ArrayList~Product~
    }
    
    class Product {
        - barcode : int
        - type : String
        - price : double
    }
    
    class Placement {
        - shelf : Shelf
        + Placement(shelf : Shelf)
        + getShelf() Shelf
    }
    
    class Shelf {
        <<enumeration>>
        BOTTOM
        MIDDLE
        TOP
    }
    
    class PerishableFood {
        - expirationDate : LocalDate
        + getExpirationDate() LocalDate
    }
    
    class NonFood {
        - isFragile : boolean
        + isFragile() boolean
    }
    
    class Toy {
        - recommendedAge : int
        + getRecommendedAge() int
    }
    
    GroceryStore --> "*" Aisle
    Aisle --> "*" Product
    Product --> Placement
    Placement --> Shelf
    Product <|-- PerishableFood
    Product <|-- NonFood
    Product <|-- Toy
```

## Notes:
- Use `LocalDate.now()` to get the current date
- Use `java.time.LocalDate` for date handling

