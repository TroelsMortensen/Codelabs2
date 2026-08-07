# Exercise 7 - Library System

Implement the following class diagram in Java:

```mermaid
classDiagram
    class Library {
        - name : String
        + Library(name : String)
        + getName() String
        + addItem(item : LibraryItem) void
        + removeItem(itemId : String) void
        + getOverdueItems() ArrayList~LibraryItem~
        + getAllBooks() ArrayList~Book~
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
        + setDueDate(dueDate : LocalDate) void
        + calculateLateFee()* double
        + isOverdue() boolean
    }
    
    class Book {
        - author : String
        - isbn : String
        + Book(itemId : String, title : String, dueDate : LocalDate, author : String, isbn : String)
        + getAuthor() String
        + getIsbn() String
        + calculateLateFee() double
    }
    
    class Magazine {
        - issueNumber : int
        - year : int
        + Magazine(itemId : String, title : String, dueDate : LocalDate, issueNumber : int, year : int)
        + getIssueNumber() int
        + getYear() int
        + calculateLateFee() double
    }
    
    class Borrower {
        - borrowerId : String
        - name : String
        - email : String
        - phoneNumber : String
        + Borrower(borrowerId : String, name : String, email : String, phoneNumber : String)
        + getBorrowerId() String
        + getName() String
        + getEmail() String
        + setEmail(email : String) void
        + getPhoneNumber() String
        + setPhoneNumber(phoneNumber : String) void
    }
    
    Library --> "*" _LibraryItem_
    Library --> "*" Borrower
    _LibraryItem_ --> "0..1" Borrower 
    _LibraryItem_ <|-- Book
    _LibraryItem_ <|-- Magazine
```

## Notes:
- `getAllBooks()` returns all library items that are instances of the Book class
- Books have a late fee of 2 kr per day overdue
- Magazines have a late fee of 1 kr per day overdue
- Use `java.time.LocalDate` for date handling
- Use `ChronoUnit.DAYS.between()` to calculate days between dates

