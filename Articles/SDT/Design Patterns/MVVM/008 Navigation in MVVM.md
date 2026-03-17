# Navigation in MVVM

Navigation can create tight coupling if controllers directly instantiate or call each other.

This page focuses on navigation responsibilities in MVVM and how to keep the architecture clean.

## Learning objective

Understand how navigation intent is expressed in MVVM while view-loading details stay in dedicated infrastructure.

## Existing implementation reference

For concrete navigation infrastructure (`ViewManager`, view loading, and controller setup), use:

- `../../../Session 23 - JFX Application/004 Single view app.md`
- `../../../Session 23 - JFX Application/005 Controller Factory.md`
- `../../../Session 23 - JFX Application/006 Exercise.md`

This page builds on that approach instead of re-implementing it from scratch.

## Responsibility split

- **ViewModel**: decides that navigation should happen (intent)
- **Navigation infrastructure** (`ViewManager`): performs actual view switch
- **Controller**: forwards user input and binds state

## Navigation with arguments

Some transitions need context, e.g. selected item id.

Examples:

- `showView("Details", selectedId)`
- `showView("EditUser", userId)`

The ViewModel should expose the selected state and trigger intent; infrastructure handles transfer/setup.

## Anti-patterns to avoid

- controller creating and calling another controller directly
- ViewModel importing UI classes (`Scene`, `Stage`, `FXMLLoader`)
- global static references to stage/view state from business logic

## Exit criteria

After this page, you can:

- explain intent-driven navigation in MVVM
- describe how `ViewManager` from Session 23 fits that model
- design one navigation flow with an argument while preserving separation of concerns
