# Why MVVM in JavaFX

JavaFX makes it easy to put logic directly in controllers, which is probably what you have done on first semester. This works for small apps, but as features grow, controller classes often become overloaded.

Controllers are also difficult to test, because they contain UI elements, which are inconvenient to setup correctly.

MVVM gives us a cleaner split between UI rendering and UI logic. We can test the UI logic, without the need for a JavaFX runtime.

Examples of UI logic:
- basic validation
- navigation
- holding data for display
- managing the state of the UI
- forwarding requests to the business logic
- handling errors
- handling user input
- handling UI events
- updating data
- and probably much more

We want to separate the above from UI rendering:
- UI elements, like TextFields, Buttons, etc.
- layouts, like VBox, HBox, AnchorPane, etc.
- scenes, and stages
- FXML files
- styling

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

If business or UI logic is mixed with JavaFX UI code, tests often need JavaFX runtime or become brittle.

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


