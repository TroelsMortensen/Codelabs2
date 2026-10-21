# One to many aggregation

A library can have many books, and books can be transferred between libraries. Only one library at a time has a specific physical copy of a specific book. That sounds like an aggregation.

## Example: Library and Book

```java{4}
public class Library
{
    private String libraryName;
    private ArrayList<Book> books;

    public Library(String libraryName)
    {
        this.libraryName = libraryName;
        this.books = new ArrayList<>();
    }

    public void addBook(Book book)
    {
        books.add(book);
    }

    public Book removeBook(String isbn)
    {
        // remove book from list by ISBN
        Book book = books.stream()
            .filter(b -> b.getIsbn().equals(isbn))
            .findFirst()
            .orElse(null);
        
        if (book != null) {
            books.remove(book);
        }

        return book;
    }

    public ArrayList<Book> getBooks()
    {
        return books;
    }
}

public class Book
{
    ... // other fields and methods
}
```

Glancing at the code, it looks very much like an association. And again, aggregation is difficult to actually enforce in code. I try to "simulate" it by actually _removing_ the book from the library when it is transferred to another library. See line 17 above.

### Transferring ownership

```java
Book novel = new Book("Dune", "Frank Herbert", "978-0441172719");

Library downtown = new Library("Downtown Library");
Library campus = new Library("Campus Library");

downtown.addBook(novel);
// Transfer to another library
Book toBeTransferred = downtown.removeBook("978-0441172719");
campus.addBook(toBeTransferred);
```

### Conceptual meaning

The child objects (`Book`) are components of the parent (`Library`), but they can exist independently. Ownership can be transferred. Ownership is stronger than association, but weaker than composition.

```mermaid
classDiagram
    class Library {
        - libraryName : String
        - books : ArrayList~Book~
        + Library(libraryName : String)
        + addBook(book : Book) void
        + removeBook(isbn : String) Book
    }

    class Book {
        - title : String
        - author : String
        - isbn : String
        + Book(title : String, author : String, isbn : String)
    }
    Library o--> "*" Book
```

