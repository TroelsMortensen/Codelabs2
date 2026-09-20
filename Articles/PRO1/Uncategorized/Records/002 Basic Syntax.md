# Declaring and Creating a Record

## Declaring a record

The basic shape looks like this:

```java
record Name(type field1, type field2, type field3) {}
```

- `Name` is the name of the container
- Inside the parentheses, you list each field with its type and name
- The empty braces `{}` close the declaration. For this learning path, they will remain empty, but they are required. You can do much more with records, than what I show here.

Using the book example:

```java
record Book(String title, String author, int year) {}
```

This says: a `Book` holds a title, an author, and a year. _All_ books have a title, an author, and a year. But not all _instances_ of books have the _same_ title, author, and year.

## Creating a record

You create a record with `new`, and pass the values in the **same order** as the fields in the declaration:

```java
void main() {
    Book book = new Book("The Hobbit", "J.R.R. Tolkien", 1937);
    IO.println(book);
}
```

- First value → `title`
- Second value → `author`
- Third value → `year`

If you mix up the order, the values end up in the wrong fields.

## Another example

Fields can have different types. Here is a small point on a grid:

```java
record Point(int x, int y) {}

void main() {
    Point start = new Point(3, 7);
    IO.println(start);
}
```

And here is a person with a boolean field:

```java
record Person(String name, int age, boolean isStudent) {}

void main() {
    Person mia = new Person("Mia", 20, true);
    IO.println(mia);
}
```

In the next page, you will learn how to read the values back out of a record.
