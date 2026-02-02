# Introduction to the Observer Design Pattern

When one object's state _changes_, other objects often need to react: 
* update a display, 
* log the change, 
* send an alert, or 
* refresh derived data. 

The **Observer** design pattern gives you a clean way to do this without the changing object knowing the concrete types of whoever is listening.

In this learning path we use the names **Subject** (the object whose state changes) and **Listener** (the object that reacts). You may see the same pattern called Observer, Subscriber, or Event Listener elsewhere; the idea is the same.

The pattern is _old_, and has been around for a long time. It is a fundamental pattern in object-oriented design. It was first described in the book "Design Patterns: Elements of Reusable Object-Oriented Software" by Erich Gamma, Richard Helm, Ralph Johnson, and John Vlissides, published in 1994.

## The Core Idea

- **Subject**: The object that holds state. When its state changes, it _notifies_ everyone who has registered an interest.
- **Listener**: An object that wants to be notified when the Subject changes. It implements a simple contract (for example, an `update` method) and registers with the Subject.

The Subject _does not_ depend on concrete listener classes — only on a Listener interface. That keeps the design loose and makes it easy to add or remove listeners at runtime.

## What You Will Learn

1. **The problem** – Why we need a structured way to notify multiple dependents when state changes.
2. **A poor solution** – Directly wiring the "source" to concrete display or consumer classes, and why that hurts.
3. **The pattern** – Its purpose, structure (with a UML class diagram), participants, and consequences.
4. **Implementation** – How to implement it in Java using an abstract Subject superclass and a Listener interface.
5. **Applying the pattern** – Taking the initial problem and solving it with the Observer (Subject/Listener) pattern.

## Scope of This Learning Path

Here we focus on the **classic** approach: an abstract Subject superclass that maintains a list of Listeners and calls their `update` method when state changes. Other approaches—such as Java's legacy `Observable`/`Observer`, property bindings, or reactive streams—are covered elsewhere. Once you understand this version, those alternatives will be easier to follow.
