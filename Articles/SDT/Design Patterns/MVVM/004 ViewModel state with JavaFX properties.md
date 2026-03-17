# ViewModel state with JavaFX properties

In JavaFX MVVM, the ViewModel exposes state through JavaFX properties so views can observe and bind to changes.

## Learning objective

Understand how to model ViewModel state using JavaFX properties and when to expose read-only vs writable state.

## Reference before this page

This page assumes you already know the property APIs.  
For full property and binding mechanics, read:

- `../../Data Bindings/001 Introduction.md`
- `../../Data Bindings/002 Properties.md`
- `../../Data Bindings/003 Unidirectional binding.md`
- `../../Data Bindings/004 Bidirectional binding.md`

Here we focus on architectural usage in MVVM.

## What belongs in ViewModel state

Typical examples:

- form input values (`StringProperty`)
- derived display text (`StringProperty` or computed binding)
- selected item (`ObjectProperty<T>`)
- validation flags (`BooleanProperty`)
- status messages (`StringProperty`)

## Example shape

```java
public class LoginViewModel {
    private final StringProperty username = new SimpleStringProperty("");
    private final StringProperty password = new SimpleStringProperty("");
    private final BooleanProperty canLogin = new SimpleBooleanProperty(false);
    private final StringProperty errorMessage = new SimpleStringProperty("");
}
```

## Exposure guideline

- expose property accessors where binding is needed (`usernameProperty()`)
- expose value getters for read-only usage (`getUsername()`)
- keep mutation through methods when business rules apply (`attemptLogin()`)

This avoids scattering mutation logic across controllers.

## Exit criteria

After this page, you can:

- design ViewModel state using appropriate property types
- explain why properties are useful in MVVM
- decide which values should be mutable directly and which should be updated through ViewModel methods
