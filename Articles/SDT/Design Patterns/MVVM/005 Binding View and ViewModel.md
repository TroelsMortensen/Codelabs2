# Binding View and ViewModel

Once ViewModel state is exposed as properties, the view can bind controls to that state.

## Binding directions

We mostly use two directions of binding:
- Unidirectional: View <- ViewModel
- Bidirectional: View <-> ViewModel

## Unidirectional binding (`bind`)

This basically means that the ViewModel is the source of truth, and the View is the consumer. Whenever the ViewModel data changes, the View updates automatically. But it is one-way only. From ViewModel to View.


Use when the UI should only display state:

- label text showing computed values
- disable state of a button from validation flags

## Bidirectional binding (`bindBidirectional`)


Use when the user edits values directly:

- text fields bound to a StringProperty in the ViewModel
- selected value controls where edits should update ViewModel

The point here is for example, that if a user edits a text field, the ViewModel property is updated automatically. Thereby, the ViewModel automatically knows the new value from the user.

If the text field needs to be cleared, we can update the StringProperty in the ViewModel to an empty string. The View will automatically update to show the empty string.

## Example controller wiring

```java
public void initialize() {
    usernameField.textProperty().bindBidirectional(viewModel.usernameProperty());
    passwordField.textProperty().bindBidirectional(viewModel.passwordProperty());
    loginButton.disableProperty().bind(viewModel.canLoginProperty().not());
    errorLabel.textProperty().bind(viewModel.errorMessageProperty());
}
```

Remember, the `initialize()` method is called automatically. For a more safe approach, implement the `Initializable` interface and implement the `initialize()` method with the required parameters.

## Common pitfalls

- binding everything bidirectionally by default
- binding input unidirectionally, this will actually disable input
- adding UI logic or business decisions in controller event handlers

Keep controller code as wiring (binding) and delegation (call method on ViewModel).
