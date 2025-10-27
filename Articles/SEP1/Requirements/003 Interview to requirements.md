# Interview to requirements

In your first semester project, you will be given a case, usually an interview with the _stakeholder_. By random chance, that stakeholder's name is often Bob.

From this interview, you must then extract the requirements for the system. The interview may not alwasy be crystal clear on what is needed, and so you will have to infer the requirements from the interview, as best you can.

Look for the following things:
- Describing real world objects, and their data
  - Book, Author, Publisher, Category, etc.
  - Customer, Order, Item, etc.
  - Person, Address, Phone, Email, etc.
  - Product, Category, Order, etc.
  - Task, Project, User, etc.
- Describing relationships between real world objects
  - Book has an author
  - Book has a publisher
  - Book has a category
  - Customer has an order
  - Customer has an item
  - Customer has a task
  - Customer has a project
  - Customer has a user
- Describing rules about the behaviour of the system
  - Book must have an ISBN
  - A book cannot be loaned out if it is not available
  - A customer must have a name
  - A product cannot be ordered if it is not in stock
  - You cannot order more products than the stock allows
