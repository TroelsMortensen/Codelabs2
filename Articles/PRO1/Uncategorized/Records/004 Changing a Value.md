# Changing a Value

Sometimes you want a record that is almost the same as an existing one, but with one field different — for example, a book with a corrected year.

You **cannot** change the fields of a record after it has been created. The contents stay as they were given.

## Create a new record instead

When you need different values, you create a **new** record. You can reuse values from the existing one by reading them with accessors, and put the new value where it differs:

```java
record Book(String title, String author, int year) {}

void main() {
    Book book = new Book("The Hobbit", "J.R.R. Tolkien", 1937);

    Book updated = new Book(book.title(), book.author(), 1938);

    IO.println(book);    // still year 1937
    IO.println(updated); // year 1938
}
```

- `book` is unchanged
- `updated` is a new record: same title and author, different year

## Reassigning the variable

You can also store the new record in the same variable:

```java
book = new Book(book.title(), book.author(), 1938);
```

This does **not** edit the old contents. The variable `book` now refers to a new record. The previous values are no longer used.