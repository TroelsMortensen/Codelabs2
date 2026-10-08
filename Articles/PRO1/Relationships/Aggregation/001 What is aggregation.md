# What is aggregation

**Aggregation** is a "has-a" relationship where one class contains or "owns" another class as a part, but the contained object can exist independently. The ownership is stronger than an association.

You may be able to find many different definitions online, many of which do not really differ from _association_. This learning path is _my_ interpretation of the relationship.

Often, the relationship is more about conceptual _intent_ rather than something that is clear from the code. It is, therefore, not really something you explicitly implement, and even then, it is hard to ensure the relation is not degraded to an assocation. 

## Conceptual example

Consider this:

- A person owns a car. There is at most one owner for this car at a time. But ownership can be transferred to another person.
- A person has a brain. There is at most one brain for this person. Ownership _cannot_ be transferred to another person (not yet, at least).

These two relationships have different implications. One ownership is transferable (weaker), the other is not (stronger — that is composition, covered later). Aggregation sits in between association and composition: whole-part, but the part can still exist on its own and ownership can move.

## Car and engine

A car has an engine. The engine is a part of the car, but the engine can exist independently. The engine can be removed from the car and placed in another car. At any given time there is only one engine in the car, and the engine is used by _only_ one car.

If this were a plain association, the engine could be used by multiple cars at once. That does not really make sense, so we use aggregation instead.

Honestly, it is difficult to distinguish between aggregation and association in code. We can use aggregation in our designs (UML diagrams) to imply intent, but generally it has little to no effect on the code we write. Mostly, association versus aggregation is a matter of interpretation and intent.

## Key characteristics

- **"Has-a" relationship**: One object contains another as a component
- **Independent existence**: The contained object can exist without the container
- **Loose coupling**: Container and contained objects have separate lifecycles
- **Stronger than association**: Implies whole-part ownership, but weaker than composition

## How aggregation works in Java

Short version: same as association — a field variable holding a reference.

Aggregation is implemented through:

- **Instance variables** that hold references to other objects
- **Constructor parameters** or methods that accept existing objects
- **Setter / install / remove methods** to assign or change contained objects

The only conceptual difference from association is that the ownership is stronger.

## Aggregation vs association

- **Association**: Objects work together but are completely independent
- **Aggregation**: Objects have a whole-part relationship, but parts can exist independently
- **Aggregation** implies a stronger relationship than association but weaker than composition


