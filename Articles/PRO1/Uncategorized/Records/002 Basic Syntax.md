# Declaring and Creating a Record

## Declaring a record

The basic shape looks like this:

```java
record Name(type field1, type field2, type field3) {}
```

- `Name` is the name of the container
- Inside the parentheses, you list each field with its type and name
- The empty braces `{}` close the declaration

Using the book example:

```java
record Book(String title, String author, int year) {}
```

This says: a `Book` holds a title, an author, and a year.

## Creating a record

You create a record with `new`, and pass the values in the **same order** as the fields in the declaration:

```java
Book book = new Book("The Hobbit", "J.R.R. Tolkien", 1937);
```

- First value → `title`
- Second value → `author`
- Third value → `year`

If you mix up the order, the values end up in the wrong fields.

## Another example

Fields can have different types. Here is a small point on a grid:

```java
record Point(int x, int y) {}

Point start = new Point(3, 7);
```

And here is a person with a boolean field:

```java
record Person(String name, int age, boolean isStudent) {}

Person mia = new Person("Mia", 20, true);
```

In the next page, you will learn how to read the values back out of a record.
