# Using lambdas in UI 

When creating GUI applications in JavaFX, you will often need to tie _behaviour_ to some ui _event_. For example:
- A button is clicked, you want some code to be executed.
- A text field is edited, you want some code to be executed.
- A checkbox is checked or unchecked, you want some code to be executed.

When the user does something to the UI, some event is triggered by the UI code, and we can supply a lambda expression to be executed when the event is triggered.

This scenario, reacting to UI events, is primarily what you will be using lambdas for.