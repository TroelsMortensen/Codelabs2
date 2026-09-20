# What is a Record?

Up until now, you have probably just worked with a single value at a time. For example, you have worked with numbers, strings, and booleans. You would declare a variable to store one of these values, maybe a student name here:

```java
String studentName = "Alice";
```

Sometimes one value is not enough. What if a student also has an age? A student number?

Or, a book title alone does not tell you much. You usually also care about the **author** and the **year**. Those pieces of data belong together. We must put them together into a data container.

## A container for related values

A **record** is a named container that holds several related pieces of data.

Think of it like a labeled box with compartments: each compartment has a name and stores one value.

Consider a rectangle, as the usual first example, students see. A rectangle has a width and a height. _All_ rectangles have a width and a height. But not all rectangles have the _same_ width and height. We might define a rectangle as (width, height), and then various unique _instances_ of rectangles, like (3, 4), (1, 1), (5, 5), etc. 

One is a "template" for a rectangle, and the other is an "instance" of a rectangle.

## A first look

Here is a record that holds three values about a book. Notice it is declared _outside_ the main method. Alternatively, it goes into its own file.

```java
// define the Book record template
record Book(String title, String author, int year) {}

void main() {
    // create an instance of the Book record
    Book book = new Book("The Hobbit", "J.R.R. Tolkien", 1937);

    IO.println(book); // print the book
}
```

This declares a `Book` container with three fields (`title`, `author`, and `year`), creates one book, and prints it.

Once you create a record, its contents stay as they were given. You read the values; you do not change them later.

In the next pages, you will learn how to declare records, create them, and read their values.
