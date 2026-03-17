# Model, View, ViewModel responsibilities

MVVM is mostly about clear boundaries. This page defines the responsibilities and allowed dependencies.

## Learning objective

Learn what each MVVM part is responsible for and how dependencies should flow.

## Responsibilities

## Model

The model represents application data and business rules:

- domain entities
- business services
- persistence abstractions/implementations

It should not know JavaFX UI classes.

## View

The view is UI structure and rendering:

- FXML or JavaFX nodes/layout
- visual state presentation
- forwarding user input to controller/ViewModel

It should not contain business logic.

## ViewModel

The ViewModel is the presentation logic:

- exposes UI state through properties
- transforms domain data for display
- handles user intent methods (save, search, select, etc.)
- coordinates with services

It should not create UI controls or load FXML.

## Dependency direction

Use this direction:

- View -> ViewModel
- ViewModel -> Model/services

Avoid:

- ViewModel -> View
- Model -> View/ViewModel

## Quick smell checks

You likely broke the boundary if:

- a controller opens database connections
- a ViewModel imports JavaFX layout classes like `VBox` or `Scene`
- a domain service imports UI control classes

## Exit criteria

After this page, you can:

- classify code into Model, View, or ViewModel correctly
- describe allowed dependency direction
- identify at least two boundary violations in a code example
