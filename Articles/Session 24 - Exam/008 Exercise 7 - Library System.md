# Exercise 7 - Library System

Implement the following class diagram in Java:

```mermaid
classDiagram
    class Library {
        - name : String
        + addItem(item : LibraryItem) void
        + removeItem(itemId : String) void
        + getOverdueItems() ArrayList~LibraryItem~
        + totalLateFees() double
    }
    
    class _LibraryItem_ {
        - itemId : String
        - title : String
        - dueDate : LocalDate
        + LibraryItem(itemId : String, title : String, dueDate : LocalDate)
        + getItemId() String
        + getTitle() String
        + getDueDate() LocalDate
        + calculateLateFee()* double
        + isOverdue() boolean
    }
    
    class Book {
        - author : String
        - isbn : String
        + calculateLateFee() double
    }
    
    class Magazine {
        - issueNumber : int
        - year : int
        + calculateLateFee() double
    }
    
    class DVD {
        - duration : int
        + calculateLateFee() double
    }
    
    class Borrower {
        - borrowerId : String
        - name : String
        - email : String
        - phoneNumber : String
    }
    
    Library --> "*" _LibraryItem_
    Library --> "*" Borrower : members
    _LibraryItem_ --> "0..1" Borrower 
    _LibraryItem_ <|-- Book
    _LibraryItem_ <|-- Magazine
    _LibraryItem_ <|-- DVD
```

## Notes:
- Books have a late fee of 2 kr per day overdue
- Magazines have a late fee of 1 kr per day overdue
- DVDs have a late fee of 5 kr per day overdue
- Use `java.time.LocalDate` for date handling
- Use `ChronoUnit.DAYS.between()` to calculate days between dates

