# Introducing domain models

A domain model is a conceptual model that represents the key concepts, *entities*, and *relationships* within a specific *problem domain* (business area). It's a visual representation that helps understand and communicate the information in the system you're building.

> The domain model is a conceptual diagram. It has nothing to do with the code. It is a way to understand the problem domain, and to communicate that understanding to others.

## What is a problem domain?

The problem domain is the specific area or subject matter that your system addresses. It includes the business rules, processes, terminology, and concepts that exist in that area. For example, in a library system, the problem domain includes concepts like books, members, loans, late fees, and catalog searches.

## What is an entity?

An entity is a key concept or "thing" in the problem domain that has distinct identity and attributes. Entities become classes in your domain model. Examples: `Book`, `Member`, `Loan`, `Author`. Each entity has attributes (properties) like `Book` has `title`, `ISBN`, and `author`.\
An entity is uniquely identifiable, usually by an identifier, i.e. some ID attribute.

## What is a relationship?

A relationship describes how entities are connected or related to each other. It shows which entities interact or are associated with one another, and in what quantity (multiplicity). For example: "A Member can borrow many Books" or "A Book belongs to one Library".

## The focus

The point is to focus on the problem domain, not technical details. No Java classes, no UI, no code. Just the entities and relationships.