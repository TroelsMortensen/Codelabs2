# Introduction to Data Transfer Objects

When building applications with multiple layers, you need to pass data between those layers. But how should you do it? Should the presentation layer directly use domain entities? Should the business logic layer expose its internal data structures?

Eventually, your domain models may become too complex to pass between layers.\
Or your view requires data that is organized in a way that is not the same as the domain model.

## What are Data Transfer Objects?

A **Data Transfer Object (DTO)** is a simple object that carries data between different parts of an application, typically between layers, or between a client program and a server program. It's a "data container" - it holds information but doesn't contain business logic.

**Real-world analogy:**

Think about filling out a form at a government office. The form doesn't contain your entire life history - it only has the specific fields needed for that transaction. The form is like a DTO:

- It has **only the data needed** for that specific purpose
- It's **simple and flat** - no complex relationships
- It's **easy to process** - just read the fields
- It's **disposable** - once used, you might throw it away

Similarly, when you receive a shipping label, it doesn't contain the entire product database - just the information needed to ship that package.

## Why Do We Need DTOs?

In a three-layer architecture (Presentation, Business Logic, Persistence), each layer has different concerns:

- **Presentation Layer**: Displays data to users, handles user input
- **Business Logic Layer**: Contains domain rules and operations
- **Persistence Layer**: Stores and retrieves data

If the presentation layer directly uses domain entities from the business logic layer, you create **tight coupling**:

- Changes to domain entities break the presentation layer
- The presentation layer depends on internal business logic structure
- Domain logic might accidentally leak into the presentation layer
- Testing becomes harder because layers are intertwined

DTOs solve this by creating a **contract** between layers - the presentation layer only knows about simple data objects, not complex domain entities.

## Prerequisites

This learning path assumes you're familiar with:

- Three-layer architecture (Presentation, Business Logic, Persistence)
- Domain entities with primary keys and foreign keys
- Java classes, constructors, and getters/setters
- The Space Explorer domain from the "Keys in Domains" learning path (or other learning paths, we have seen it multiple times)

If you've completed the learning paths on application design and keys, you're ready to continue.

