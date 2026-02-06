# Properties in JavaFX

Before you can bind values, you need **properties**: observable wrappers around a value. JavaFX provides several property types and simple implementations you can use in your code.

## Observable and Property

- **Observable**: Something that can notify listeners when it changes. JavaFX uses this so that bindings and UI controls can react to updates.
- **Property**: A read/write value that is also an `Observable`. You can get and set the value and observe changes.

You do not need to implement these interfaces yourself. Use the **simple property** classes (e.g. `SimpleIntegerProperty`, `SimpleStringProperty`) that JavaFX provides. They already implement the right behaviour.

## Property Types

All of these live in the package `javafx.beans.property`:

| Type | Interface | Simple implementation | Holds |
|------|-----------|------------------------|-------|
| Integer | `IntegerProperty` | `SimpleIntegerProperty` | `int` |
| Double | `DoubleProperty` | `SimpleDoubleProperty` | `double` |
| Long | `LongProperty` | `SimpleLongProperty` | `long` |
| Float | `FloatProperty` | `SimpleFloatProperty` | `float` |
| String | `StringProperty` | `SimpleStringProperty` | `String` |
| Boolean | `BooleanProperty` | `SimpleBooleanProperty` | `boolean` |
| Any object | `ObjectProperty<T>` | `SimpleObjectProperty<T>` | Reference type `T` |

For most uses, you work with the **Simple** implementation: create it, get and set values, and later bind it to other properties or to UI controls.

## Creating and Using Properties

Create a property with an initial value, then use `get()` and `set()` to read and write it:

```java
import javafx.beans.property.IntegerProperty;
import javafx.beans.property.SimpleIntegerProperty;
import javafx.beans.property.SimpleStringProperty;
import javafx.beans.property.StringProperty;

public class PropertiesExample {
    public static void main(String[] args) {
        IntegerProperty count = new SimpleIntegerProperty(0);
        StringProperty name = new SimpleStringProperty("");

        System.out.println(count.get());   // 0
        System.out.println(name.get());    // ""

        count.set(10);
        name.set("Alice");

        System.out.println(count.get());   // 10
        System.out.println(name.get());    // Alice
    }
}
```

- **Constructor**: `new SimpleIntegerProperty(0)` gives an integer property with value 0. `new SimpleStringProperty("")` gives an empty string. Other types work the same way.
- **get()**: Returns the current value (unboxed for primitives, or the object for `ObjectProperty`/`StringProperty`).
- **set(value)**: Updates the value. When we introduce bindings, changing a property will automatically update anything bound to it.

## UI Controls and Properties

In a JavaFX UI, controls expose properties. For example, a `TextField` has a `textProperty()` that returns a `StringProperty`; a `Label` has `textProperty()` as well. You can bind the label's text to the text field's text so the label always shows what the user types—without writing a listener. We do not build full UI here; just be aware that the same property types you create in code are what those controls use under the hood.

## Summary

- **Observable**: can notify when it changes; **Property**: observable and read/write.
- Use **SimpleXxxProperty** (e.g. `SimpleIntegerProperty`, `SimpleStringProperty`) to create properties.
- Use **get()** and **set()** to read and write the value. In the next files we will bind properties together so that one update propagates to others.
