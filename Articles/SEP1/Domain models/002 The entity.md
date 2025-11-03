# The entity

An entity is a key concept or "thing" in the problem domain that has distinct identity and attributes. Entities become boxes in the domain model. And later, some of these boxes will become classes in the code.

Common entities are:
- Person
- Place
- Book
- Event
- Vehicle
- Product
- Transaction
- Order
- Invoice
- Payment
- Delivery
- Review
- Rating
- Comment

As you can see, entities are not always obvious. And you need to think about the problem domain to come up with the right entities.
These entities are generally found across several places:
- The interview with the customer
- The requirements (user stories)
- The use case descriptions

## Noun, but more than one

Entities are generally nouns. And usually it is only interesting if more instances of such an entity can exist. Otherwise, it is rarely relevant to include.

- The library has many books. So, books is an entity. But there is only a single library, so it is not relevant to include.
- VIA Campus Horsens has many rooms. In a room booking system, a room is an entity. But "VIA Campus Horsens" is not an entity, as there is only one. 
- A car rental shop has many cars. In a car rental system, a car is an entity. But "Car Rental Shop" is not an entity, as there is only one.
- A bank has many customers. In a banking system, a customer is an entity. But "Bank" is not an entity, as there is only one.

In the above examples, we can view the "single-entity" as some sort of overall container, encapsulating many of the other entities. The entities exist within this "boundary" that is the single-entity.

## Example

In the below description of a library system, I have marked potential entities with green boxes.


> The Riverside Public Library serves a community of over 50,000 residents. The library maintains a collection of physical ```Book```s and digital ```E-Book```s. Each ```Book``` has details like title, ISBN, publication year, and genre. ```Book```s are written by ```Author```s, and some books may have multiple authors collaborating.
>
> The library has registered ```Member```s who can borrow materials. Each ```Member``` has a unique membership ID, name, contact information, and membership status (active, suspended, expired). Members can place ```Reservation```s on books that are currently checked out by others.
>
> When a ```Member``` borrows a ```Book```, a ```Loan``` record is created which tracks the loan date, due date, and return date. If a book is returned late, the system calculates a ```Fine``` based on the number of days overdue. Members must pay outstanding fines before borrowing additional materials.
>
> The library organizes ```Event```s such as book clubs, author readings, and children's story time. Members can register for these events. Each ```Event``` has a date, time, location, and maximum capacity.
>
> The library building has multiple ```Room```s available for public use, including study rooms and meeting rooms. Members can make ```Room Booking```s to reserve these spaces for specific time slots.
>
> Library staff members, called ```Librarian```s, manage the day-to-day operations. They process loans and returns, assist members with searches, and maintain the catalog. Each ```Librarian``` has an employee ID, name, and assigned department (circulation, reference, technical services).



## Not all nouns are entities

Note that some of these entities might be questionable or depend on the specific requirements. For example:
- Is ```E-Book``` a separate entity from ```Book```, or just a type of book?
- Is ```Fine``` an entity, or just an attribute of a loan?
- Should ```Room Booking``` be an entity, or is it just an association between Member and Room?
- Is ```Librarian``` different enough from ```Member``` to be its own entity, or should it be a type of member?



These decisions depend on the specific needs of your system and how detailed your model needs to be.
