# Introduction to the Observer Design Pattern

When one object's state (data) _changes_, other objects often need to react: 
* update a display, 
* log the change, 
* send an alert, or 
* refresh derived data. 

The **Observer** design pattern gives you a clean way to do this without the changing object knowing the concrete types of whoever is "listening", i.e. reacting to the change.

In this learning path I use the names **Subject** (the object whose state changes) and **Listener** (the object(s) that reacts). You may see alternative names like Observer, Subscriber, or Event Listener elsewhere; the idea is the same.

The pattern is _old_, has been around for a long time. It is a fundamental pattern in object-oriented design. It is described in the book `Design Patterns: Elements of Reusable Object-Oriented Software` by Erich Gamma, Richard Helm, Ralph Johnson, and John Vlissides, published in 1994!  
As with everything else, stuff evolves, and so has the pattern. Here, though, I will introduce the original idea. In later videos I will introduce more modern approaches.

## The Core Idea

- **Subject**: The object that holds state. When its state changes, it _notifies_ everyone who has registered an interest.
- **Listener**: An object that wants to be notified when the Subject changes. It implements a simple contract (for example, an `update` method) and registers with the Subject.

The Subject _does not_ depend on concrete listener classes — only on a `Listener` interface. That keeps the design loose and makes it easy to add or remove different types of listeners at runtime.

## What You Will Learn

1. **The problem** – Why we need a structured way to notify multiple dependents when state changes.
2. **A poor solution** – Directly wiring the "source" to concrete display or consumer classes, and why that hurts.
3. **The pattern** – Its purpose, structure (with a UML class diagram), participants, and consequences.
4. **Implementation** – How to implement it in Java using an abstract Subject superclass and a Listener interface.
5. **Applying the pattern** – Taking the initial problem and solving it with the Observer (Subject/Listener) pattern.

## Scope of This Learning Path

Here we focus on the **classic** approach: an abstract Subject superclass that maintains a list of Listeners and calls their `update` method when state changes. Other approaches are covered in my [video series](https://youtube.com/playlist?list=PL5I0mJDB37i_8jYtWtZyrkRUm5IqrtEf2&si=MfPy4SgeBN_57LvR). Once you understand this version, those alternatives will be easier to follow.
