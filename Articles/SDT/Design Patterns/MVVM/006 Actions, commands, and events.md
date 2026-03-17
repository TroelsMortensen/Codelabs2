# Actions, commands, and events

Bindings keep values synchronized. Actions define what should happen when the user does something.

## Learning objective

Design user-action flow where the view forwards intent and the ViewModel performs behavior and state updates.

## Action flow in MVVM

1. user clicks a button or triggers an event
2. controller/view forwards the event to a ViewModel method
3. ViewModel calls services and updates properties
4. UI updates automatically through bindings

## Example shape

```java
public class LoginViewModel {
    public void attemptLogin() {
        // validate, call auth service, update properties
    }
}
```

```java
public void onLoginClicked() {
    viewModel.attemptLogin();
}
```

## Why this helps

- action logic becomes testable without UI runtime
- controller remains thin and predictable
- side effects are centralized

## Event handling guideline

If an event handler has branching business logic, move that logic into ViewModel methods and keep the handler as a one-liner delegate.

## Exit criteria

After this page, you can:

- implement a simple action flow from UI event to ViewModel method
- explain where business behavior should live
- keep controllers thin while still handling JavaFX events correctly
