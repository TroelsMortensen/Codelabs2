# Exercise 4 - Grocery Store System

Implement the following class diagram in Java:

```mermaid
classDiagram
    class GroceryStore {
        + GroceryStore()
        + getExpiredPerishableFood() ArrayList~PerishableFood~
    }
    
    class Aisle {
        - aisleNumber : int
        - category : String
        + Aisle(aisleNumber : int, category : String)
        + getAisleNumber() int
        + getCategory() String
        + getProducts() ArrayList~Product~
        + getProductsByShelf(shelf : Shelf) ArrayList~Product~
    }
    
    class _Product_ {
        - barcode : int
        - type : String
        - price : double
        + Product(barcode : int, type : String, price : double)
        + getBarcode() int
        + getType() String
        + getPrice() double
        + setPrice(price : double) void
    }
    
    class Placement {
        - shelf : Shelf
        - section : char
        + Placement(shelf : Shelf, section : char)
        + getShelf() Shelf
        + getSection() char
    }
    
    class Shelf {
        <<enumeration>>
        BOTTOM
        MIDDLE
        TOP
    }
    
    class PerishableFood {
        - expirationDate : LocalDate
        + PerishableFood(barcode : int, type : String, price : double, expirationDate : LocalDate)
        + getExpirationDate() LocalDate
    }
    
    class NonFood {
        - isFragile : boolean
        + NonFood(barcode : int, type : String, price : double, isFragile : boolean)
        + isFragile() boolean
    }
    
    GroceryStore --> "*" Aisle
    Aisle --> "*" _Product_
    _Product_ --> Placement
    Placement --> Shelf
    _Product_ <|-- PerishableFood
    _Product_ <|-- NonFood
```

## Notes:
- `section` is a single character (e.g., 'A', 'B', 'C') that represents a horizontal section within the aisle, allowing products to be organized both by shelf (vertical: BOTTOM, MIDDLE, TOP) and section (horizontal: A, B, C, etc.)
- `getProductsByShelf(shelf : Shelf)` returns all products in the aisle that are on the specified shelf
- Use `LocalDate.now()` to get the current date
- Use `java.time.LocalDate` for date handling
- Perishable food is expired if the expiration date is before the current date

