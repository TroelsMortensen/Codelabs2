# Why MVVM in JavaFX

JavaFX makes it easy to put logic directly in controllers. This works for small demos, but as features grow, controller classes often become overloaded.

MVVM gives us a cleaner split between UI rendering and application behavior.

## Learning objective

Understand the concrete problems MVVM solves in JavaFX applications and why teams adopt it.

## Typical pain points without MVVM

### 1) Fat controllers

A single controller handles:

- UI events
- validation
- business logic
- service calls
- navigation

This quickly becomes hard to read and maintain.

### 2) Hard-to-test behavior

If business logic is mixed with JavaFX UI code, tests often need JavaFX runtime or become brittle.

### 3) Tight coupling

Controllers can become coupled to persistence/services and to each other, making changes expensive.

### 4) Repeated glue code

As screens multiply, duplicated event and synchronization code appears across controllers.

## What MVVM improves

- **Separation of concerns**: View handles rendering, ViewModel handles state and behavior.
- **Testability**: ViewModel logic can be unit-tested without UI.
- **Maintainability**: clear boundaries reduce accidental coupling.
- **Scalability**: adding screens/features stays predictable.

## Practical rule of thumb

If a line of code can run meaningfully without visual components, it probably belongs in a ViewModel or service, not in a controller.

## Exit criteria

After this page, you can:

- describe at least three common controller-heavy problems
- explain how MVVM addresses them in JavaFX
- justify using MVVM for medium/large JavaFX projects
