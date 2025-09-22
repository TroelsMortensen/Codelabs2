# Exercises - round 3

This time, we will model a library system.

We will need a Book class.

And we will build a console UI to manage the library system, allowing users to add, remove, and search for books.

The exercise is intentionally vaguely described, to allow for your creativity.

## Exercise 14: The book

First, the book.

You are given some freedom here, in what attributes, you think a book needs.

Consider at least 
- isbn 
- title 
- author 
- isAvailable (whether the book is loaned out or not)

Which methods are necessary for a book class? Maybe it is not entirely clear at this point, but you can add methods, as you need to.

## Exercise 15: The console UI

You will create an ArrayList to contain the books.

And then through a console text UI, it must be possible to:
1. Add a new book to the library.
2. Search for books, either by:
   1. Title
   2. Author
   3. ISBN
3. Mark a book as loaned out.
4. Mark a book as returned.
5. Remove a book from the library.
6. List all books in the library. Display this in some nicely formatted way.

Run the program in a loop, as usual, and consider having an option to exit the program.

You could optionally, initially, add a couple of books to the library for testing purposes.
