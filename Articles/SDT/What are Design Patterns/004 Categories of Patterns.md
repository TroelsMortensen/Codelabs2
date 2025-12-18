# Categories of Patterns

Design patterns are organized into categories based on their purpose. The most well-known classification comes from the "Gang of Four" book, which groups patterns into three main categories.

## The Three Main Categories

### 1. Creational Patterns

**Purpose:** Deal with object creation mechanisms.

Creational patterns solve problems related to **how objects are created**. They provide flexibility in deciding which objects to create, how they're created, and when they're created.

**Problems they solve:**
- Creating objects in flexible ways without specifying exact classes
- Ensuring only one instance of a class exists
- Building complex objects step by step
- Creating families of related objects

**Examples of patterns in this category:**
- **Factory Pattern** - Creates objects without specifying exact classes
- **Builder Pattern** - Constructs complex objects step by step
- **Singleton Pattern** - Ensures only one instance exists


### 2. Structural Patterns

**Purpose:** Deal with the composition of classes and objects.

Structural patterns solve problems related to **how classes and objects are organized** to form larger structures. They help you compose objects and classes into larger structures while keeping them flexible and efficient.

**Problems they solve:**
- Combining objects to form larger structures
- Adding new functionality to objects without modifying them
- Providing a simplified interface to a complex subsystem
- Making incompatible interfaces work together

**Examples of patterns in this category:**
- **Adapter Pattern** - Makes incompatible interfaces work together
- **Decorator Pattern** - Adds new functionality to objects dynamically
- **Facade Pattern** - Provides a simplified interface to a complex subsystem

### 3. Behavioral Patterns

**Purpose:** Deal with communication between objects and assignment of responsibilities.

Behavioral patterns solve problems related to **how objects interact and communicate** with each other. They focus on algorithms and the assignment of responsibilities between objects.

**Problems they solve:**
- Defining how objects communicate
- Encapsulating algorithms and making them interchangeable
- Managing complex control flows
- Distributing responsibilities among objects

**Examples of patterns in this category:**
- **Observer Pattern** - Notifies multiple objects about state changes
- **Strategy Pattern** - Encapsulates algorithms and makes them interchangeable
- **Command Pattern** - Encapsulates requests as objects


## Understanding the Categories

Think of the categories this way:

- **Creational**: "How do I create this?"
- **Structural**: "How do I organize this?"
- **Behavioral**: "How do these interact?"

Each category addresses a different aspect of software design, and many applications use patterns from multiple categories.

## Other Pattern Catalogs

While the Gang of Four classification is the most famous, there are other pattern catalogs:

- **Architectural Patterns**: Higher-level patterns for organizing entire systems (e.g., MVC, Layered Architecture, Clean Architecture, etc.)
- **Concurrency Patterns**: Patterns for multi-threaded programming
- **Enterprise Patterns**: Patterns for large-scale business applications