# Testing ViewModels

One of the biggest benefits of MVVM is that ViewModel behavior can be tested without rendering JavaFX UI.


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
- direct property assertions, i.e. the test verifies the ViewModel properties are set to the expected values

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


