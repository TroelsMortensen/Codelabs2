# Use case table

A use case table provides an overview of which user stories are included in which use cases (of the use case diagram).\
This is useful when you have merged bubbles into one use case, and this way we can better ensure that all user stories are included in the use case, one way or another.

The purpose of the use case table is to ensure that all user stories are included in the use case diagram, one way or another.

We can structure the table in two ways:
- A use case includes the following user stories, or
- This user story is included in the following use case(s).

Which do you prefer? Maybe both?


## Use case --> User stories

Consider the following use case table for a library management system, with the use case name on the left, and the included user stories in the right column.

| Use Case | User Stories |
|----------|-------------|
| Search Books | US-07: Search by title<br>US-19: Search by author<br>US-03: Search by ISBN<br>US-24: Search by genre |
| Manage Member Account | US-12: Create new member<br>US-05: Update member information<br>US-21: View member details<br>US-16: Deactivate member |
| Borrow Book | US-02: Select book to borrow<br>US-14: Verify member eligibility<br>US-08: Check book availability<br>US-23: Record loan transaction<br>US-11: Set return due date |
| Return Book | US-18: Scan returned book<br>US-06: Calculate overdue fees<br>US-13: Process payment if applicable<br>US-09: Update book status |
| Manage Book Inventory | US-01: Add new book<br>US-17: Update book details<br>US-22: Remove book from system<br>US-10: Mark book as damaged |
| Generate Reports | US-15: Generate overdue books report<br>US-04: Generate popular books report<br>US-20: Generate member activity report |

As you can see, the user stories are listed in the right column, and the use case name is listed in the left column. Each use case may include multiple related user stories that have been merged for simplicity and readability of the use case diagram.

For example:
- **Search Books** merges four variations of searching (parameter variations)
- **Borrow Book** merges sequential steps that together form the complete borrowing process
- **Manage Member Account** merges CRUD operations on member accounts

This table serves as a traceability matrix, ensuring that:
- Every user story is accounted for in at least one use case
- No user stories are forgotten or overlooked
- Stakeholders can see how their requirements (user stories) map to the system design (use cases)

## User stories --> Use cases

Consider the following use case table with the same data as the previous table, but with the user story name on the left, and the included use cases in the right column.\
This is the reverse mapping of the previous table.


| User Story | Use Cases |
|----------|-------------|
| US-01: Add new book | Manage Book Inventory |
| US-02: Select book to borrow | Borrow Book |
| US-03: Search by ISBN | Search Books |
| US-04: Generate popular books report | Generate Reports |
| US-05: Update member information | Manage Member Account |
| US-06: Calculate overdue fees | Return Book |
| US-07: Search by title | Search Books |
| US-08: Check book availability | Borrow Book |
| US-09: Update book status | Return Book |
| US-10: Mark book as damaged | Manage Book Inventory |
| US-11: Set return due date | Borrow Book |
| US-12: Create new member | Manage Member Account |
| US-13: Process payment if applicable | Return Book |
| US-14: Verify member eligibility | Borrow Book |
| US-15: Generate overdue books report | Generate Reports |
| US-16: Deactivate member | Manage Member Account |
| US-17: Update book details | Manage Book Inventory |
| US-18: Scan returned book | Return Book |
| US-19: Search by author | Search Books |
| US-20: Generate member activity report | Generate Reports |
| US-21: View member details | Manage Member Account |
| US-22: Remove book from system | Manage Book Inventory |
| US-23: Record loan transaction | Borrow Book |
| US-24: Search by genre | Search Books |

This reverse mapping helps you:
- Verify that every user story is assigned to at least one use case
- Identify orphaned user stories that haven't been included
- See which user stories might belong to multiple use cases (if any, it's probably rare)
