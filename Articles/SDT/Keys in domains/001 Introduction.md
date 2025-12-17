# Introduction to Keys in Domain Models

When building software systems, we create objects that represent real-world things. These are commonly called domain entities. 

> An entity is a key concept or "thing" in the problem domain that has distinct identity and attributes. Entities become classes in your domain model. Examples: `Book`, `Member`, `Loan`, `Author`. Each entity has attributes (properties) like `Book` has `title`, `ISBN`, and `author`.
> 
> An entity is uniquely identifiable, usually by an identifier, i.e. some ID attribute.
> 
> An entity has a life cycle. That means the entity changes over time, its data changes.

A `Planet` object represents a planet. An `Explorer` object represents a space explorer. But how do we tell one planet apart from another? How do we know which explorer we're talking about?

## The Identity Problem

Imagine you're building a system to track space exploration missions (sounds familiar?). You have two planets in your system:

- Planet with name "Kepler-442b"
- Planet with name "Kepler-442b"

Wait... are these the same planet? Or did someone accidentally add it twice? Or are there actually two different planets with the same name? Probably someone messed up, as planet names are generally unique, but is that a hard rule?

In the real world, we solve this problem all the time:

| Domain | Identifier |
|--------|------------|
| People in Denmark | CPR number |
| Students at VIA | Student ID (e.g., 310254) |
| Books | ISBN number |
| Cars | License plate / VIN number |
| Bank accounts | Account number |
| Packages | Tracking number |

Each of these identifiers is **unique** - no two people share the same CPR number (yet, we have a problem around year 2050), no two books have the same ISBN. This uniqueness is what allows us to distinguish one thing from another, even if they have similar attributes.

## Why Names Aren't Enough

You might think: "Why not just use the name as the identifier?"

Consider these problems:

1. **Duplicates exist** - Two people can be named "Anders Jensen". Two companies can be named "Apple" (the tech company and the Beatles' record label had a famous dispute over this).

2. **Names can change** - A person might change their name after marriage. A company might rebrand. If you used the name as the identifier, you'd lose track of the entity.

3. **Names might be empty or unknown** - What if you discover a new planet but haven't named it yet? You still need to track it in your system.

## What You'll Learn

In this learning path, we'll explore how to properly identify and link entities in your Java domain models:

1. **Primary Keys** - How to give each entity a unique identifier
2. **Foreign Keys** - How to create relationships between entities using their identifiers. No, we don't use associations for this anymore.

By the end, you'll understand how to build robust domain models where every entity can be uniquely identified and properly linked to related entities.

## Prerequisites

This learning path assumes you're familiar with:

- Java classes with fields, constructors, and methods
- Object relationships (association, aggregation, composition)
- ArrayList and basic collections
- Basic UML class diagrams

This is all PRO1 stuff, so you are obviously familiar with all of this.

