# The Discard Operator

Sometimes a lambda expression receives a parameter that you don't actually need to use. In these cases, you can use the underscore `_` as the parameter name to indicate it's intentionally unused.

## Why Use the Discard?

Using `_` makes it clear to anyone reading your code that the parameter is not needed, rather than accidentally forgotten.

## Example: Button Click

In JavaFX, when a button is clicked, the event handler receives an `ActionEvent` parameter. Often, you don't need this event information:

**Without discard (parameter not used):**

```java
button.setOnAction(event -> System.out.println("Button clicked!"));
```

**With discard (explicitly showing parameter is unused):**

```java
button.setOnAction(_ -> System.out.println("Button clicked!"));
```

Both work the same way, but the second version makes it explicit that you're not using the event parameter.


