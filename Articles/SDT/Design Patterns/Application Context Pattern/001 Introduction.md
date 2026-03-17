# Introduction to the Application Context Pattern

In many applications, objects depend on other objects:

- a controller depends on a ViewModel,
- a ViewModel depends on one or more services,
- a service depends on one or more DAOs.

If each class starts creating these dependencies itself, construction logic spreads everywhere and quickly becomes difficult to maintain.

The **Application Context** pattern solves this by putting object creation and wiring in one place. The context creates and holds objects, and resolves dependencies when a type is requested.

## Core Idea

- **One place for wiring**: The application context is the composition root.
- **Request a type, receive a ready object**: For example, request a ViewModel and get it with all required dependencies already injected.
- **Centralized lifecycle decisions**: The context decides what is shared (singleton-like) and what is created per request.

## JavaFX + MVVM Perspective

In a JavaFX MVVM application:

- controllers typically need ViewModels,
- ViewModels depend on business services,
- services depend on persistence components.

Instead of wiring this chain inside each controller, the controller asks the application context for the needed ViewModel.

## Why This Helps

- Keeps construction logic out of UI and domain classes.
- Makes dependency graphs explicit in one place.
- Makes it easier to swap implementations for tests.
- Reduces repeated wiring code across the app.

## What You Will Learn

1. **The problem**: Why scattered object creation causes coupling and maintenance issues.
2. **A poor solution**: Controllers and classes constructing the dependency graph directly.
3. **The pattern**: Intent, structure, participants, and consequences.
4. **Implementation**: A simple Java application context that registers and resolves dependencies.
5. **Applying the pattern**: A JavaFX MVVM example with controller, ViewModel, service, and DAO.

## Scope

This learning path focuses on the pattern and a hand-written implementation in plain Java. It does not require external DI frameworks.
