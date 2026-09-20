# Quiz Recap

Test your understanding of Java records before you move on.

## 1

Match each idea to what it means for records.

<Quiz>
{
  "Type": "MatchPair",
  "Title": "Match the Record Concepts",
  "Pairs": [
    {
      "Prompt": "Record",
      "Answer": "A container for several related values"
    },
    {
      "Prompt": "Fields",
      "Answer": "The values listed in the parentheses"
    },
    {
      "Prompt": "Create",
      "Answer": "new Book(...)"
    },
    {
      "Prompt": "Accessor",
      "Answer": "book.title()"
    }
  ],
  "Hint": "See pages 1–3 — a record holds named values, you create it with new, and you read a field with its name followed by ()."
}
</Quiz>

## 2

Given this record:

```java
record Book(String title, String author, int year) {}
Book book = new Book("The Hobbit", "J.R.R. Tolkien", 1937);
```

<Quiz>
{
  "Type": "SingleChoiceQuiz",
  "Question": "<p>How do you read the title from <code>book</code>?</p>",
  "Options": [
    {
      "Text": "<code>book.title()</code>",
      "IsCorrect": true
    },
    {
      "Text": "<code>book.getTitle()</code>",
      "IsCorrect": false
    },
    {
      "Text": "<code>book.title</code>",
      "IsCorrect": false
    },
    {
      "Text": "<code>Book.title()</code>",
      "IsCorrect": false
    }
  ],
  "Shuffle": true,
  "Hint": "See page 3 Reading Values — the accessor name matches the field name, with parentheses.",
  "Explanation": "You read a field with the field name followed by (). For title, that is book.title()."
}
</Quiz>

## 3

Decide whether each statement is true or false.

<Quiz>
{
  "Type": "TrueFalseQuiz",
  "Statements": [
    {
      "Text": "When you create a record with new, the values must be in the same order as the fields in the declaration.",
      "IsCorrect": true
    },
    {
      "Text": "After you create a record, you can change one of its field values.",
      "IsCorrect": false
    },
    {
      "Text": "You read a field by using the field name followed by ().",
      "IsCorrect": true
    },
    {
      "Text": "Two records with the same field values count as equal.",
      "IsCorrect": true
    }
  ],
  "Hint": "Review pages 2–4: order matters when creating, contents stay as given, accessors use the field name, and equals compares field values."
}
</Quiz>

## 4

Arrange the lines so the program declares a `Book` record, creates one, and prints its title.

<Quiz>
{
  "Type": "ParsonsProblem",
  "Question": "Arrange the lines into a valid program that declares Book, creates one book, and prints the title.",
  "Lines": [
    { "Id": 1, "Content": "record Book(String title, String author, int year) {}" },
    { "Id": 2, "Content": "Book book = new Book(\"The Hobbit\", \"J.R.R. Tolkien\", 1937);" },
    { "Id": 3, "Content": "System.out.println(book.title());" }
  ],
  "Hint": "First declare the record, then create one with new, then read the title with book.title()."
}
</Quiz>
