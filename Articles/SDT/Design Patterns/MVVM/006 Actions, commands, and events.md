# Actions, commands, and events

Bindings keep values synchronized. Actions define what should happen when the user does something.

Often, actions are just methods in the ViewModel.

But sometimes, actions are attached as listeners to properties. For example, whenever the content of a text field changes, we want to do something in the ViewModel. 


## Action flow in MVVM

1. user clicks a button
2. controller (view) class a ViewModel method. The method takes no parameters, all relevant data is already in the ViewModel properties.
3. ViewModel calls services and updates properties
4. UI updates automatically through bindings

## Example code

In the ViewModel, we have a method for the action:

```java
public class LoginViewModel {
    public void attemptLogin() {
        // validate, call auth service, update properties
    }
}
```

In the controller (view), there is a method which is called when the user clicks the login button. This method calls the ViewModel method. Notice we do not provide arguments. The ViewModel already knows all the data we need.

```java
public void onLoginClicked() {
    viewModel.attemptLogin();
}
```

It is important that the controller does as little as possible. And yes, sometimes, it is not this simple. But, keep the guideline in mind.

## Why this helps

- action logic becomes testable without UI runtime
- controller remains thin and predictable
- side effects are centralized, and manage by the ViewModel, making this testable too

## Event handling guideline

If an event handler has branching business logic, move that logic into ViewModel methods and keep the handler as a one-liner delegate (method call).

## Recap

In short:
* Actions are methods in the ViewModel.
* Actions are called from the controller (view) when the user performs an action.
* Actions should be testable.
* Actions takes no parameters, all relevant data is already in the ViewModel properties.
