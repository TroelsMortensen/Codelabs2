# Principles vs Patterns

It's important to understand how design principles relate to design patterns, as they're often mentioned together but serve different purposes.

## Key Differences

### Principles: Guidelines (What to Do)

**Design principles** are guidelines and rules:

- They tell you **what to aim for**
- They're **abstract** - high-level guidance
- They're **evaluative** - help you judge if a design is good
- Examples: "Keep classes focused", "Reduce coupling", "Favor simplicity"

### Patterns: Solutions (How to Do It)

**Design patterns** are concrete solutions:

- They tell you **how to structure** your code
- They're **concrete** - specific class structures and relationships
- They're **prescriptive** - show you a way to solve a problem
- Examples: Factory pattern, Observer pattern, Adapter pattern

## The Relationship

Think of it this way:

- **Principles** are the "why" and "what" - the goals and guidelines
- **Patterns** are the "how" - the concrete ways to achieve those goals

### Principles Guide Patterns

Good design patterns **embody** good design principles:

- A pattern that follows the "reduce coupling" principle will show you how to structure classes to achieve low coupling
- A pattern that follows the "single responsibility" principle will organize code so each class has one clear purpose

### Patterns Implement Principles

When you use a pattern, you're often applying one or more principles:

- Using the Factory pattern might apply the "dependency inversion" principle
- Using the Observer pattern might apply the "loose coupling" principle
- Using the Strategy pattern might apply the "open/closed" principle

