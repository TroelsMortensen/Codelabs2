# Introduction to the Application Context Pattern

In many applications, objects depend on other objects:

- a controller depends on a ViewModel,
- a ViewModel depends on one or more services,
- a service depends on one or more DAOs.

If each class starts creating these dependencies itself, construction logic spreads everywhere and quickly becomes difficult to maintain. The coupling between the classes is high. And we are breaking the Dependency Inversion Principle.

The **Application Context** pattern attempts to solve this by putting object creation and wiring (dependency injection) in one place. The context creates and holds objects, and resolves dependencies when a type is requested.

You will probably encounter the pattern in many frameworks, like Spring or ASP.NET. Here, the pattern looks slightly different, and is called "Dependency Injection Container". Or sometimes a Service Registry. Many names, for similar concepts.

## Core Idea

- **One place for wiring**: The application context is the composition root.
- **Request a type, receive a ready object**: For example, request a ViewModel and get it with all required dependencies already injected.
- **Centralized lifecycle decisions**: The context decides what is shared (singleton-like) and what is created per request.


## Why This Helps

- Keeps construction logic out of UI classes. Otherwise a controller might have to call `new PlanetViewModel(new PlanetService(new FilePlanetDao("planets.bin")))`. This is not good, because the controller is now tightly coupled to the implementation details of the ViewModel, service, and DAO.
- Makes dependency graphs explicit in one place.
- Makes it easier to swap implementations for tests.
- Reduces repeated wiring code across the app. Each type of object is created in only a single place!

## What You Will Learn

1. **The problem**: Why scattered object creation causes coupling and maintenance issues.
2. **A poor solution**: Controllers and classes constructing the dependency graph directly.
3. **The pattern**: Intent, structure, participants, and consequences.
4. **Implementation**: A simple Java `AppContext` singleton that creates and holds DAOs, services, and ViewModels.
5. **Applying the pattern**: A JavaFX MVVM planet-management example with controller, ViewModel, service, and DAO.

## Scope

This learning path focuses on the pattern and a hand-written implementation in plain Java. It does not require external DI frameworks.
