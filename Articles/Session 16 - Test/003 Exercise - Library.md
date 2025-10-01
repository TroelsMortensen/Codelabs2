# Exercise: Library Management System

## Description

Create a library management system that models different types of library items and library members. The system should handle borrowing and returning items, track due dates, and manage different member types with varying borrowing privileges.

This exercise focuses on:
- Creating an abstract base class for library items
- Implementing inheritance for different item types and member types
- Modeling real-world entities as objects
- Managing relationships between objects (members borrowing items)
- Calculating due dates and overdue status

## Class Diagram

```mermaid
classDiagram

    namespace items {
        class _LibraryItem_ {
            - id : String
            - title : String
            - isAvailable : boolean
            - borrowedBy : Member
            - dueDate : LocalDate
            + LibraryItem(id : String, title : String)
            + getId() String
            + getTitle() String
            + isAvailable() boolean
            + borrow(member : Member) boolean
            + returnItem() void
            + getDueDate() LocalDate
            + isOverdue() boolean
            + getBorrowingPeriodDays()* int
            + getItemType()* String
            + toString() String
        }
        
        class Book {
            - author : String
            - isbn : String
            - pageCount : int
            + Book(id : String, title : String, author : String, isbn : String, pageCount : int)
            + getAuthor() String
            + getIsbn() String
            + getPageCount() int
        }
        
        class DVD {
            - director : String
            - duration : int
            - genre : String
            + DVD(id : String, title : String, director : String, duration : int, genre : String)
            + getDirector() String
            + getDuration() int
            + getGenre() String
        }
        
        class Magazine {
            - issueNumber : int
            - month : String
            - year : int
            + Magazine(id : String, title : String, issueNumber : int, month : String, year : int)
            + getIssueNumber() int
            + getMonth() String
            + getYear() int
        }
    }

    namespace members {
        class _Member_ {
            <<abstract>>
            - memberId : String
            - name : String
            - borrowedItems : ArrayList~LibraryItem~
            + Member(memberId : String, name : String)
            + getMemberId() String
            + getName() String
            + getBorrowedItems() ArrayList~LibraryItem~
            + borrowItem(item : LibraryItem) boolean
            + returnItem(item : LibraryItem) void
            + getMaxBorrowLimit()* int
            + getMemberType()* String
            + hasOverdueItems() boolean
            + canBorrow() boolean
            + toString() String
        }
        
        class RegularMember {
            + RegularMember(memberId : String, name : String)
        }
        
        class StudentMember {
            - studentId : String
            - school : String
            + StudentMember(memberId : String, name : String, studentId : String, school : String)
            + getStudentId() String
            + getSchool() String
        }
    }
    
    class Library {
        - name : String
        - items : ArrayList~LibraryItem~
        - members : ArrayList~Member~
        + Library(name : String)
        + addItem(item : LibraryItem) void
        + addMember(member : Member) void
        + findItem(id : String) LibraryItem
        + findMember(memberId : String) Member
        + getAllItems() ArrayList~LibraryItem~
        + getAllMembers() ArrayList~Member~
        + getAvailableItems() ArrayList~LibraryItem~
        + getOverdueItems() ArrayList~LibraryItem~
        + showLibraryStatus() void
    }
    
    class LibraryTester {
        + main(args : String[]) void
    }
    
    _LibraryItem_ <|-- Book
    _LibraryItem_ <|-- DVD
    _LibraryItem_ <|-- Magazine
    _Member_ <|-- RegularMember
    _Member_ <|-- StudentMember
    Library o--> _LibraryItem_
    Library -->  _Member_
    _LibraryItem_ --> "..1" _Member_
    LibraryTester --> Library
```

## Hint: Working with LocalDate

For this exercise, you'll need to work with dates to track due dates and overdue items. Java provides the `LocalDate` class for this purpose.

**Import statement:**
```java
import java.time.LocalDate;
```

**Common operations:**
```java
// Get today's date
LocalDate today = LocalDate.now();

// Add days to a date (for calculating due dates)
LocalDate dueDate = today.plusDays(21);  // 21 days from now

// Compare dates (check if overdue)
boolean isOverdue = today.isAfter(dueDate);

// Calculate days between dates
long daysBetween = ChronoUnit.DAYS.between(startDate, endDate);
```

**Example in context:**
```java
public void borrow(Member member) {
    this.dueDate = LocalDate.now().plusDays(getBorrowingPeriodDays());
    // other code...
}

public boolean isOverdue() {
    if (dueDate == null) {
        return false;
    }
    return LocalDate.now().isAfter(dueDate);
}
```

## Class Descriptions

### Abstract Class: LibraryItem

The base class for all library items.

**Fields:**
- `id` - Unique identifier for the item
- `title` - Title of the item
- `isAvailable` - Whether the item is currently available
- `borrowedBy` - The member who currently has the item (null if available)
- `dueDate` - The date when the item is due to be returned (null if not borrowed)

**Methods:**
- `LibraryItem(id, title)` - Constructor to initialize basic item information
- `getId()` - Returns the item ID
- `getTitle()` - Returns the item title
- `isAvailable()` - Returns true if the item is available for borrowing
- `borrow(member)` - Borrows the item to the given member, sets due date, returns success status
- `returnItem()` - Returns the item, makes it available again
- `getDueDate()` - Returns the due date (or null if not borrowed)
- `isOverdue()` - Returns true if the item is overdue (current date is after due date)
- `getBorrowingPeriodDays()` - Abstract method that returns the borrowing period in days (implemented by subclasses)
- `getItemType()` - Abstract method that returns the type of item (implemented by subclasses)
- `toString()` - Returns a string representation of the item

### Class: Book extends LibraryItem

Represents a book in the library.

**Fields:**
- `author` - Author of the book
- `isbn` - ISBN number
- `pageCount` - Number of pages

**Methods:**
- `Book(id, title, author, isbn, pageCount)` - Constructor
- `getAuthor()` - Returns the author
- `getIsbn()` - Returns the ISBN
- `getPageCount()` - Returns the page count
- `getBorrowingPeriodDays()` - Returns 21 days (3 weeks)
- `getItemType()` - Returns "Book"
- `toString()` - Returns formatted string with book details

### Class: DVD extends LibraryItem

Represents a DVD in the library.

**Fields:**
- `director` - Director of the DVD
- `duration` - Duration in minutes
- `genre` - Genre of the DVD

**Methods:**
- `DVD(id, title, director, duration, genre)` - Constructor
- `getDirector()` - Returns the director
- `getDuration()` - Returns the duration
- `getGenre()` - Returns the genre
- `getBorrowingPeriodDays()` - Returns 7 days (1 week)
- `getItemType()` - Returns "DVD"
- `toString()` - Returns formatted string with DVD details

### Class: Magazine extends LibraryItem

Represents a magazine in the library.

**Fields:**
- `issueNumber` - Issue number of the magazine
- `month` - Month of publication
- `year` - Year of publication

**Methods:**
- `Magazine(id, title, issueNumber, month, year)` - Constructor
- `getIssueNumber()` - Returns the issue number
- `getMonth()` - Returns the month
- `getYear()` - Returns the year
- `getBorrowingPeriodDays()` - Returns 14 days (2 weeks)
- `getItemType()` - Returns "Magazine"
- `toString()` - Returns formatted string with magazine details

### Abstract Class: Member

The base class for all library members.

**Fields:**
- `memberId` - Unique member identifier
- `name` - Member's name
- `borrowedItems` - List of currently borrowed items

**Methods:**
- `Member(memberId, name)` - Constructor
- `getMemberId()` - Returns the member ID
- `getName()` - Returns the member name
- `getBorrowedItems()` - Returns the list of borrowed items
- `borrowItem(item)` - Borrows an item if allowed, returns success status
- `returnItem(item)` - Returns a borrowed item
- `getMaxBorrowLimit()` - Abstract method that returns the maximum number of items this member can borrow
- `getMemberType()` - Abstract method that returns the member type
- `hasOverdueItems()` - Returns true if the member has any overdue items
- `canBorrow()` - Returns true if the member can borrow more items (hasn't reached limit and has no overdue items)
- `toString()` - Returns formatted string with member details

### Class: RegularMember extends Member

Represents a regular library member.

**Methods:**
- `RegularMember(memberId, name)` - Constructor
- `getMaxBorrowLimit()` - Returns 3 (regular members can borrow up to 3 items)
- `getMemberType()` - Returns "Regular"

### Class: PremiumMember extends Member

Represents a premium library member with extended privileges.

**Fields:**
- `joinDate` - Date when the member joined as premium

**Methods:**
- `PremiumMember(memberId, name, joinDate)` - Constructor
- `getJoinDate()` - Returns the join date
- `getMaxBorrowLimit()` - Returns 7 (premium members can borrow up to 7 items)
- `getMemberType()` - Returns "Premium"

### Class: StudentMember extends Member

Represents a student library member.

**Fields:**
- `studentId` - Student ID number
- `school` - Name of the school

**Methods:**
- `StudentMember(memberId, name, studentId, school)` - Constructor
- `getStudentId()` - Returns the student ID
- `getSchool()` - Returns the school name
- `getMaxBorrowLimit()` - Returns 5 (student members can borrow up to 5 items)
- `getMemberType()` - Returns "Student"

### Class: Library

Manages all library items and members.

**Fields:**
- `name` - Name of the library
- `items` - List of all library items
- `members` - List of all library members

**Methods:**
- `Library(name)` - Constructor
- `addItem(item)` - Adds a new item to the library
- `addMember(member)` - Adds a new member to the library
- `findItem(id)` - Finds and returns an item by ID (returns null if not found)
- `findMember(memberId)` - Finds and returns a member by ID (returns null if not found)
- `getAllItems()` - Returns all items in the library
- `getAllMembers()` - Returns all members
- `getAvailableItems()` - Returns only available items
- `getOverdueItems()` - Returns items that are currently overdue
- `showLibraryStatus()` - Prints a summary of the library status (total items, available items, total members, overdue items)

### Class: LibraryTester

Main testing class to demonstrate the library system.

**Methods:**
- `main(args)` - Creates library, items, members, performs various operations (borrowing, returning, checking status), and displays results

## Testing Requirements

The `LibraryTester` class should demonstrate:
1. Creating a library with a name
2. Creating various types of library items (books, DVDs, magazines)
3. Adding items to the library
4. Creating different types of members (regular, premium, student)
5. Adding members to the library
6. Borrowing items (successful and unsuccessful attempts)
7. Checking item availability
8. Returning items
9. Testing borrowing limits
10. Testing overdue item detection
11. Displaying library status

## Expected Output Example

```
=== Library Management System ===

Creating library: City Central Library

Adding items to library...
Added: Book - "The Great Gatsby" by F. Scott Fitzgerald
Added: DVD - "Inception" directed by Christopher Nolan
Added: Magazine - "National Geographic" Issue 5, May 2024

Adding members...
Added: Regular Member - John Doe (ID: M001)
Added: Premium Member - Jane Smith (ID: M002)
Added: Student Member - Alice Johnson (ID: M003)

=== Testing Borrowing ===
John Doe borrowed "The Great Gatsby" - Due: 2024-06-15
Jane Smith borrowed "Inception" - Due: 2024-06-01
Alice Johnson borrowed "National Geographic" - Due: 2024-06-08

=== Library Status ===
Library: City Central Library
Total Items: 3
Available Items: 0
Total Members: 3
Overdue Items: 0

=== Testing Returns ===
John Doe returned "The Great Gatsby"

=== Final Library Status ===
Available Items: 1
```

This exercise provides comprehensive practice with inheritance, abstract classes, and object modeling!


## Optional: CLI Application

You may expand this exercise by adding a command line application, i.e. print some menus, and let the user interactict with the sysstem to add books, remove, borrow, return, etc.