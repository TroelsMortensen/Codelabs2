# Exercise 2

Draw a sequence diagram based on the following Java code:

```java
public class Main {
    
    public static void main(String[] args) {
        Library library = new Library();
        
        Book book = new Book("The Hobbit", "J.R.R. Tolkien");
        
        library.addBook(book);
        
        String info = library.getBookInfo("The Hobbit");
        System.out.println(info);
    }
}

public class Library {
    
    private Book[] books;
    private int bookCount;
    
    public void addBook(Book book) {
        books[bookCount] = book;
        bookCount++;
    }
    
    public String getBookInfo(String title) {
        Book foundBook = findBook(title);
        
        if (foundBook != null) {
            return foundBook.getDetails();
        }
        return "Book not found";
    }
    
    private Book findBook(String title) {
        for (int i = 0; i < bookCount; i++) {
            String bookTitle = books[i].getTitle();
            if (bookTitle.equals(title)) {
                return books[i];
            }
        }
        return null;
    }
}

public class Book {
    
    private String title;
    private String author;
    
    public Book(String title, String author) {
        this.title = title;
        this.author = author;
    }
    
    public String getTitle() {
        return title;
    }
    
    public String getDetails() {
        return title + " by " + author;
    }
}
```

**Tasks:**
1. Draw a sequence diagram showing all method calls
2. Include both object creations (`<<create>>` for Library and Book)
3. Show the call to `addBook()` passing the Book object
4. Show `getBookInfo()` which calls the private helper `findBook()`
5. Show `findBook()` calling `getTitle()` on Book objects (this happens in a loop)
6. Show the final call to `getDetails()` on the found Book
7. Use nested activation bars for self-calls (e.g., `getBookInfo()` calling `findBook()`)
8. Include return arrows (dashed lines) for all methods that return values

