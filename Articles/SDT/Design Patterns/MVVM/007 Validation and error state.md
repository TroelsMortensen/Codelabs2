# Validation and error state

Validation should be part of presentation logic, not scattered across UI event handlers.

## Learning objective

Model validation and user feedback as observable ViewModel state.

## Recommended validation state

Expose properties such as:

- `BooleanProperty valid`
- `StringProperty validationMessage`
- `BooleanProperty canSubmit`

These are then bound to UI controls (labels, button disable state, error styles).

## Example pattern

```java
public void validate() {
    boolean ok = !username.get().isBlank() && password.get().length() >= 8;
    valid.set(ok);
    canSubmit.set(ok);
    validationMessage.set(ok ? "" : "Username/password is invalid");
}
```

Call `validate()` whenever relevant input changes or before submit.

## Service errors vs validation errors

- validation errors: expected input issues (show immediately)
- service errors: network/persistence/business failures (show contextual message after action attempt)

Keep both as ViewModel state so the view only presents data.

## Exit criteria

After this page, you can:

- define validation-related properties in a ViewModel
- bind validation state to UI feedback controls
- separate validation failures from service/operation failures
