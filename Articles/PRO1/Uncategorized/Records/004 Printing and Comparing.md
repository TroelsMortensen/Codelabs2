# Printing and Comparing Records

## Printing a record

When you print a record, Java shows its contents in a readable way:

```java
record Book(String title, String author, int year) {}

Book book = new Book("The Hobbit", "J.R.R. Tolkien", 1937);

System.out.println(book);
```

Typical output:

```text
Book[title=The Hobbit, author=J.R.R. Tolkien, year=1937]
```

You see the record name and each field with its value. That makes it easy to check what is inside the container.

## Comparing records

Two records with the **same field values** count as equal. Different values mean they are not equal.

```java
Book book1 = new Book("The Hobbit", "J.R.R. Tolkien", 1937);
Book book2 = new Book("The Hobbit", "J.R.R. Tolkien", 1937);
Book book3 = new Book("Dune", "Frank Herbert", 1965);

System.out.println(book1.equals(book2)); // true
System.out.println(book1.equals(book3)); // false
```

`book1` and `book2` hold the same title, author, and year, so they are equal.  
`book3` holds different values, so it is not equal to `book1`.

On the next page, you can check what you have learned with a short quiz.
