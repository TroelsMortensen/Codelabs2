# Introduction to One to One relationships

In the real world, objects are related to each other. For example, a car is related to an engine, and a person is related to a home, two persons are related to each other, an order is related to a customer, a product, and a shipping address.\
In programming, we can represent, or model, these relationships using object-oriented programming.

We start out with one-to-one relationships (sort of). And in later sessions we will see how to model more complex relationships.

This learning path will cover four types of relationships:
- Association
- Aggregation
- Composition
- Dependency

These are used for both one-to-one relationships, as seen in this learning path, as well as more complex relationships, as seen in later sessions.

The kind of relationship you want to model, depends on the problem you are trying to solve. And they have different implications for the code. And different meanings, conceptually, in the real world.

Consider this:
* A person owns a car. There is at most one owner for this car, at a time (in myt example). But ownership can be transferred to another person.
* A person has a brain. There is at most one brain for this person, at a time. And each brain is "owned" by exactly that person. Ownership _cannot_ be transferred to another person (yet, who knows what the future holds with medical advances).

So, these two relationships have different implications for the code. And different meanings, conceptually, in the real world. One ownership is transferable, the other is not. One ownership is weaker than the other.

Some relationships are more complex than others. And some _types_ of relationships are used more often than others. And some types of relationships are not always shown in UML diagrams.

First, let's get some context, on the next page.