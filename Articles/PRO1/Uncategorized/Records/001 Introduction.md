# What is a Record?

Sometimes one value is not enough.

A book title alone does not tell you much. You usually also care about the **author** and the **year**. Those pieces of data belong together.

## A container for related values

A **record** is a named container that holds several related pieces of data.

Think of it like a labeled box with compartments: each compartment has a name and stores one value.

## A first look

Here is a record that holds three values about a book:

```java
record Book(String title, String author, int year) {}

Book book = new Book("The Hobbit", "J.R.R. Tolkien", 1937);

System.out.println(book);
```

This declares a `Book` container with three fields (`title`, `author`, and `year`), creates one book, and prints it.

Once you create a record, its contents stay as they were given. You read the values; you do not change them later.

In the next pages, you will learn how to declare records, create them, and read their values.
