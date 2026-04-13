# Introduction to the Adapter Design Pattern

Software projects often need to integrate code that was not designed to work together.\
You may have:

- a class that depends on one interface (the target interface),
- and an existing class (often third-party or legacy) that exposes a different interface, or none at all.

Now you have a problem, because the class you want to use does not implement the interface you need. And you either cannot or should not modify the class you want to use.

The **Adapter** design pattern solves this mismatch by wrapping the existing class (the one you want to use) and translating calls from the expected interface to the available one.

In this learning path, we focus on **Adapter in Java** with practical examples and diagrams.

## The Core Idea

The pattern will consist of four parts:

- **Target**: the interface your context already expects.
- **Adaptee**: the existing class with an incompatible API.
- **Adapter**: a bridge class that implements `Target` and delegates to `Adaptee`.
- **Context**: uses the `Target` interface without knowing about incompatibilities.

The context stays clean and stable, while the adapter handles translation.

## Why This Pattern Matters

Without Adapter, teams may have to modify stable context code or duplicate logic just to fit one mismatched class.

With Adapter:
- you preserve existing context code,
- you reuse legacy or third-party code safely,
- and you isolate integration details in one place.

## What You Will Learn

1. **The problem** - what incompatible interfaces look like in Java.
2. **The pattern** - structure, participants, UML, and trade-offs.
3. **Applying the pattern** - refactor a problematic design into a clean adapter-based solution.
4. **More examples** - additional Java scenarios where Adapter is useful.

## Scope

We focus on the **object adapter** style (composition), because it is the most common and flexible approach in Java. There is also the **class adapter** style (inheritance), but we will not cover it in this learning path. And you will rarely encounter this, if you go off researching the adapter yourself.
