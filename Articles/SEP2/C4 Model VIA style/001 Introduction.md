# Introduction to the C4 Model (VIA Style)

Welcome to the **C4 Model**! This is a powerful approach for documenting and visualizing software architecture at different levels of detail.

## The Original C4 Model

The [C4 model](https://c4model.com/) was created by **Simon Brown** as a way to describe software architecture using four levels of abstraction. The original C4 model uses these four levels:

1. **Context** - The system in context, showing how it interacts with users and external systems
2. **Container** - High-level applications and data stores (like web applications, databases, file systems)
3. **Component** - Components within containers, showing the internal structure
4. **Code** - Detailed class diagrams showing the implementation

The C4 model has become a popular standard for software architecture documentation because it provides a simple, hierarchical way to visualize systems at different levels of detail.

## VIA's Adaptation

Based on my experience of supervising several diffent semester projects, I will suggest a slightly modified approach. While inspired by Simon Brown's C4 model, I've adapted it to better fit our curriculum and the way we teach software architecture.

### VIA's Four Levels

Our adaptation uses these four levels, each (still) starting with C:

1. **Components** - Architecture diagram showing high-level system components (clients, servers, databases, other similarly important high-level processes)
2. **Compartments** - Package diagram showing packages within components, especially layers. This shows your logical organization of your code.
3. **Classes** - Low detailed class diagram showing classes and relationships (without methods/attributes)
4. **Complete** - Full detailed class diagram with all implementation details

While the original C4 model is obviously still valid, should you prefer it, I just want to give you more inspiration on how you can document your software. The namings are less important, just pay attention to the different ways we can look at a software system.

## The Concept: Zooming into Detail

Think of the C4 model like **zooming into a map**:

```
Country → City → Street → Building
```

At each zoom level, you see different details:
- **Country level**: You see major cities and roads between them
- **City level**: You see neighborhoods, streets, and landmarks
- **Street level**: You see individual buildings and addresses
- **Building level**: You see rooms, doors, and internal layout

Similarly, with the C4 model:

```
Components → Compartments → Classes → Complete
```

- **Components level**: See main system components and how they connect
- **Compartments level**: See packages/layers within a component
- **Classes level**: See classes and their relationships
- **Complete level**: See full implementation with all details

## Our Case Study: Space Explorer System

Throughout this learning path, we'll use the **Space Explorer System** as our running example. This system:

- Tracks space exploration missions
- Manages explorers, planets, aliens, and encounters
- Is a console-based application with layered architecture
- Uses file-based persistence

**Key entities:**
- Planet, Alien, Explorer, Encounter
- Presentation layer (console menus)
- Persistence layer (file storage)
- Domain layer (business logic)

We'll zoom through all four levels of the C4 model using this system, showing how each level reveals more detail about the same architecture.

## The Four C's

Let's briefly introduce each level:

1. **Components** - "What are the main parts of the system?" (Architecture diagram)
2. **Compartments** - "How is each component organized?" (Package/layer diagram)
3. **Classes** - "What classes exist and how do they relate?" (Structure diagram)
4. **Complete** - "What are all the details of the implementation?" (Full class diagram)

In the following sections, we'll explore each level in detail, using the Space Explorer System to demonstrate how to create and use each type of diagram.



