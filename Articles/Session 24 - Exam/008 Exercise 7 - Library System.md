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
    
    class LibraryItem {
        - itemId : String
        - title : String
        - dueDate : LocalDate
        + LibraryItem(itemId : String, title : String, dueDate : LocalDate)
        + getItemId() String
        + getTitle() String
        + getDueDate() LocalDate
        + calculateLateFee() double
        + isOverdue() boolean
    }
    
    class Book {
        - author : String
        - isbn : String
        + calculateLateFee() double
    }
    
    class Magazine {
        - issueNumber : int
        + calculateLateFee() double
    }
    
    class DVD {
        - duration : int
        + calculateLateFee() double
    }
    
    Library --> "*" LibraryItem : items
    Book --|> LibraryItem
    Magazine --|> LibraryItem
    DVD --|> LibraryItem
```

## Notes:
- Books have a late fee of 2 kr per day overdue
- Magazines have a late fee of 1 kr per day overdue
- DVDs have a late fee of 5 kr per day overdue
- Use `java.time.LocalDate` for date handling
- Use `ChronoUnit.DAYS.between()` to calculate days between dates

