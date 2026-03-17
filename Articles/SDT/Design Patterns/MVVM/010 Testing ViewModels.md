# Testing ViewModels

One of the biggest benefits of MVVM is that ViewModel behavior can be tested without rendering JavaFX UI.

## Learning objective

Learn how to unit test ViewModels by asserting state transitions and collaborator interactions.

## What to test

Focus on behavior:

- input leads to expected property changes
- validation flags/messages update correctly
- actions call services with expected arguments
- failure scenarios set proper error state

## What not to test here

- JavaFX control rendering/layout details
- FXML loading mechanics
- framework internals

Those belong to integration/UI tests, not ViewModel unit tests.

## Typical test setup

Use:

- real ViewModel
- mocked/fake service dependencies
- direct property assertions

Example checks:

- `canSubmit` is false on invalid input
- `attemptSave()` calls service once on valid state
- service failure sets `errorMessage`

## Useful test cases

1. initial state is clean
2. invalid input disables action
3. valid input enables action
4. successful action clears errors
5. failed action sets user-facing error

## Exit criteria

After this page, you can:

- write unit tests for ViewModel state transitions
- isolate ViewModel tests from JavaFX rendering concerns
- verify both happy-path and failure-path behavior
