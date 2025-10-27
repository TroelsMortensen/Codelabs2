# Requirements for requirements

There are some common things that requirements should have, no matter how you express those requirements.

- **ID**: A unique identifier for the requirement. We must be able to refer to the requirement by its ID.

Hmm... that's probably actually it on first semester.

This means your user stories are numbered. If those numbers also come sequentially, that's fine.\
But you may discover user stories over time, and when you show them in your report, you may choose to organize them by some other criteria, e.g. importance.

Example:

1. As a _librarian_, I want to be able to _add a new book to the library_, so that I can _be able to loan out books_.
2. As a _librarian_, I want to be able to _search for a book by title_, so that I can _find a book quickly_.
3. ...

Your non-functional requirements are also numbered. Here, you start with 1 again. _Do not just continue the numbering from the user stories._

Why?

Functional and non-functional requirements are two completely separate things. Their IDs should not have any relationship to each other.

For clarity, you could prefix the ID with "F" for functional and "N" for non-functional, or some other convention, which you will explain in your report.