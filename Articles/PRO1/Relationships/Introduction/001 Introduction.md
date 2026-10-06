# Introduction to Relationships

In the real world, objects are related to each other. A car has an engine. A person lives at an address. An order belongs to a customer, and includes a product and a shipping address.

In programming, we model these relationships using object-oriented programming. One object holds a reference to another object — that is a relationship.

## Why do we need relationships?

Objects rarely work alone. A `Person` class should not store street, city, and zip code as plain strings if those belong to an `Address`. Separating them into two classes keeps each class focused on one job, and the relationship between them lets them work together.

When many objects reference each other, your program becomes a web of connected objects. That is sometimes called a _graph_. Relationships are how we build that graph.

Watch the following video for some conceptual examples of real-world relationships:

<video src="https://youtu.be/uVzUWwndg30"></video>

On the next pages you will see how to create a one-to-one and a one-to-many relationship in Java. Later learning paths dive into the different _kinds_ of relationships: dependency, association, aggregation, and composition.
