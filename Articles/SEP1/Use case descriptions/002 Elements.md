# The elements of a use case description

A use case description is a detailed description of a piece of functionality in the system, that the actor can perform. It contains many pieces of information, some of which are mandatory, some of which are optional.

The description commonly takes one of two forms:

- Table structure
- Section structure (not sure what to call this)

Either way, they both express the same information, and contains the same elements.

## The elements

A use case description contains (at least) the following elements.

- Use Case Name
  - What is the name of the use case?
- Summary
  - A short summary of the use case.
- User stories
  - Which user stories does this use case cover?
- Primary Actor
  - Who is the primary actor? Librarian, Customer, etc.
- Preconditions
  - What are the preconditions for the use case? Some use cases only make sense or can only be started if certain conditions are met.
- Includes
  - List the other use cases that are included in this use case. These must be executed before this use case can be started. List them in the order they must be executed.
- Post conditions
  - What are the post conditions for the use case? What is the outcome of the use case?
- Main Success Scenario
  - What is the main success scenario for the use case? This is the happy path. It is a numbered list of steps that the user must take to complete the use case.
- Extensions
  - What are the uses cases which extend this one?
- Alternative Scenarios
  - What are the alternative scenarios for the use case? Here we write the alternative sequences of steps. Often this is where the unhappy paths are described.
- Notes [Optional]
  - Any additional notes about the use case. 


You can probably find many variations of this list of elements, but this is what we require. You are free to add more elements, if relevant.

Astah has a format too, you can use, but I find that somewhat inflexible.