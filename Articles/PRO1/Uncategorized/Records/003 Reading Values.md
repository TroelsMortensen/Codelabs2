# Reading Values from a Record

Once you have created a record, you can read each field by using its name followed by `()`.

```java
record Book(String title, String author, int year) {}

void main() {
    Book book = new Book("The Hobbit", "J.R.R. Tolkien", 1937);

    IO.println(book.title());   // The Hobbit
    IO.println(book.author());  // J.R.R. Tolkien
    IO.println(book.year());    // 1937
}
```

The name of the field is also the name you use to read it:
- `title` → `book.title()`
- `author` → `book.author()`
- `year` → `book.year()`

## Using values

You can store a value in a variable, or use it in a condition:

```java
String theTitle = book.title();
System.out.println("Title: " + theTitle);

if (book.year() < 1950)
{
    System.out.println("This is an older book.");
}
```

You **read** values from a record. You do not change them after the record has been created.

In the next page, you will see what happens when you print a record, and how two records can be compared.
