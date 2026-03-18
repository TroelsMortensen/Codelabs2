# Validation and error state

Validation should be part of presentation logic, not scattered across UI event handlers.

## Recommended validation state

We want to expose properties such as:

- `BooleanProperty valid`
- `StringProperty validationMessage`
- `BooleanProperty canSubmit`

These are then bound to UI controls (labels, button disable state, error styles).

## Updating state based on service response

Here is a method in the ViewModel that asks the service to validate the username and password.

```java
public void validate() {
    boolean ok = service.validate(username.get(), password.get());
    valid.set(ok); // boolean property
    canSubmit.set(ok); // boolean property
    validationMessage.set(ok ? "" : "Username/password is invalid"); // string property
}
```

Notice the last property, `validationMessage`. This is a string property, and it is set to an empty string if the username and password are valid, and to "Username/password is invalid" if they are not.

The controller can then bind a label (or something else) to the `validationMessage` property, so the label will show the validation message.

## Input validation

Should you validate the input in the ViewModel? We probably know it does not make sense to call the service, if either input is empty. So, you _could_ do some basic input validation in the ViewModel.

However, I always recommend to ensure complete validation in the service. And so, any validation in the ViewModel is just duplicate code.
