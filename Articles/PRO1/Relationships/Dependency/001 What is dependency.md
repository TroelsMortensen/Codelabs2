# What is dependency

A **dependency** is a relationship where one class _uses_ another class temporarily or for a specific operation. It is the weakest form of relationship. One class depends on another class's services or methods, but does not maintain a permanent reference to it.

In short: there is **no field variable** involved.

## Everything is somehow a dependency

All four relationships you will learn about are some kind of dependency. Some are just stronger, so it makes sense to show them as such. Whenever one class knows about another class in any way, there is a dependency.

This "knows" can be many things, for example:

- having a field variable of the other class
- having a method parameter of the other class
- having a local variable of the other class
- having a return value of the other class
- having a static method call to the other class
- having a constructor call to the other class

If you have a class `Person`, and in another class you can search for the word "Person" and find it, there is probably a dependency of some kind.

When a field variable is involved, we show the stronger relationship (association, aggregation, or composition). Dependencies on their own are the weakest, and we always show the strongest relationship. So pure dependencies are rarely shown in UML diagrams — and only when they matter.

## Key characteristics

- **Temporary relationship**: Objects interact only when needed
- **No permanent reference**: The dependent class does not store a reference in a field
- **Method-level interaction**: Used through method parameters, local variables, or static calls
- **Loose coupling**: Classes are independent and can exist separately
