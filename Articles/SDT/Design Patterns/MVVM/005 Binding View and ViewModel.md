# Binding View and ViewModel

Once ViewModel state is exposed as properties, the view can bind controls to that state.

## Learning objective

Learn practical binding patterns between JavaFX controls and ViewModel properties in MVVM.

## Binding directions

## Unidirectional binding (`bind`)

Use when the UI should only display state:

- label text showing computed values
- disable state of a button from validation flags

## Bidirectional binding (`bindBidirectional`)

Use when the user edits values directly:

- text fields bound to editable form properties
- selected value controls where edits should update ViewModel

## Example controller wiring

```java
public void bind(LoginViewModel vm) {
    usernameField.textProperty().bindBidirectional(vm.usernameProperty());
    passwordField.textProperty().bindBidirectional(vm.passwordProperty());
    loginButton.disableProperty().bind(vm.canLoginProperty().not());
    errorLabel.textProperty().bind(vm.errorMessageProperty());
}
```

## Common pitfalls

- binding everything bidirectionally by default
- mutating domain/service state directly from controllers
- adding business decisions in controller event handlers

Keep controller code as wiring and delegation.

## Exit criteria

After this page, you can:

- choose between unidirectional and bidirectional binding for common controls
- wire a controller so UI state reflects ViewModel state automatically
- keep binding code free from business logic
