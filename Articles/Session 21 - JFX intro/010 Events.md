# Events

Events are actions that occur in your application, typically triggered by user interaction. Examples include clicking a button, typing in a text field, selecting a checkbox, or moving the mouse.

In JavaFX, you can listen for these events and respond to them with your own code.

## Event Listeners

An event listener is a piece of code that "listens" for a specific event to occur. When the event happens, your code is executed.

All event listeners are attached using methods that start with `setOn...`:

## Common Event Types

Many UI components support different types of events:

- **Button**: `setOnAction()` - Clicked
- **TextField**: `setOnAction()` - Enter key pressed
- **TextField**: `setOnKeyReleased()` - Any key released after typing
- **ComboBox**: `setOnAction()` - Item selected
- **CheckBox**: `setOnAction()` - State changed

### Example of Action Event

```java
button.setOnAction(_ -> {
    System.out.println("Button clicked!");
});
```

### Example of Keyboard Event

```java
textField.setOnKeyReleased(_ -> {
    System.out.println("Key released, text is now: " + textField.getText());
});
```

## Example 1: Checkbox State Listener

Here's an example that prints the checkbox state whenever it's clicked:

```java
CheckBox checkBox = new CheckBox("Enable notifications");

checkBox.setOnAction(_ -> {
    if (checkBox.isSelected()) {
        System.out.println("Checkbox is now SELECTED");
    } else {
        System.out.println("Checkbox is now UNSELECTED");
    }
});
```

Every time the user clicks the checkbox, the action event fires and prints the current state.

## Example 2: TextField to Label

Here's an example that updates a label whenever the user types in the text field:

```java
TextField textField = new TextField();
Label label = new Label("Your text will appear here");

textField.setOnKeyReleased(_ -> {
    label.setText(textField.getText());
});
```

This uses `setOnKeyReleased()` which fires every time the user releases a key after typing. The label updates in real-time to match the text field content.

**Alternative with action event (Enter key only):**

```java
TextField textField = new TextField();
Label label = new Label("Your text will appear here");

textField.setOnAction(_ -> {
    label.setText(textField.getText());
});
```

This version only updates the label when the user presses Enter, not on every keystroke.



## When to Use Which Event

| Event Type | Use When |
|------------|----------|
| `setOnAction()` | You want to respond to the primary user action (click, Enter key) |
| `setOnKeyReleased()` | You want to respond to every keystroke in a text field |
| `setOnKeyPressed()` | You want to detect when a specific key is pressed down |

For most user interactions, `setOnAction()` is the simplest and most appropriate choice.

> There is a different approach, using `properties`, but I will postpone those until second semester.