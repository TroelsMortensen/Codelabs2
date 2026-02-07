# Computed Bindings and the Bindings Class

A **computed binding** (or **derived binding**) is a value that depends on one or more observables. When any dependency changes, the derived value can be recomputed. JavaFX does this **lazily**: the value is recalculated when something asks for it (e.g. when you call `get()` or when a UI control reads it), not on every dependency change.

The **`Bindings`** class in `javafx.beans.binding` provides factory methods for creating such bindings without implementing interfaces yourself.

## The Bindings Class

`javafx.beans.binding.Bindings` has static methods that return bindings. For example:

- **`Bindings.add(a, b)`**: numeric sum (for `IntegerProperty`, `DoubleProperty`, etc.).
- **`Bindings.createStringBinding(callable, dependencies...)`**: a string that is computed from the given observables; whenever a dependency changes, the string is recomputed when needed.
- **`Bindings.format(format, args...)`**: a formatted string (like `String.format`), with format arguments that can be observables so the string updates when they change.

The result of these methods is usually a **Binding** (read-only). You do not set it; you only read it. It stays in sync with its dependencies.

## Example: Sum of Two Numbers

Two numeric properties, and a binding that is their sum:

```java
import javafx.beans.binding.Bindings;
import javafx.beans.binding.NumberBinding;
import javafx.beans.property.IntegerProperty;
import javafx.beans.property.SimpleIntegerProperty;

public class ComputedSum {
    public static void main(String[] args) {
        IntegerProperty a = new SimpleIntegerProperty(10);
        IntegerProperty b = new SimpleIntegerProperty(20);

        NumberBinding sum = Bindings.add(a, b);
        System.out.println("sum.get() = " + sum.getValue());   // 30

        a.set(100);
        System.out.println("sum.get() = " + sum.getValue());   // 120

        b.set(5);
        System.out.println("sum.get() = " + sum.getValue());   // 105
    }
}
```

`sum` is a **NumberBinding**: it has `getValue()` (and for number types, you can use `intValue()`, `doubleValue()`, etc.). It always reflects `a.get() + b.get()` and updates when either `a` or `b` changes.

## Example: Concatenating Two Strings

A string that combines two `StringProperty` values (e.g. first and last name):

```java
import javafx.beans.binding.Bindings;
import javafx.beans.binding.StringBinding;
import javafx.beans.property.SimpleStringProperty;
import javafx.beans.property.StringProperty;

public class ComputedConcat {
    public static void main(String[] args) {
        StringProperty first = new SimpleStringProperty("John");
        StringProperty last = new SimpleStringProperty("Doe");

        StringBinding fullName = Bindings.createStringBinding(
            () -> first.get() + " " + last.get(),
            first, last
        );

        System.out.println("fullName = " + fullName.get());   // John Doe

        first.set("Jane");
        System.out.println("fullName = " + fullName.get());   // Jane Doe

        last.set("Smith");
        System.out.println("fullName = " + fullName.get());   // Jane Smith
    }
}
```

**`Bindings.createStringBinding(callable, dependencies)`**: The first argument is a lambda (or `Callable<String>`) that computes the string; the rest are observables the binding depends on. Whenever any of those observables change, the next time you call `fullName.get()` the string is recomputed.

## Example: Mapping a Number to a String

A common case is **mapping between types**: e.g. a numeric property and a string that displays it (perhaps with a prefix or formatting). Use `createStringBinding` and read the number inside the lambda:

```java
import javafx.beans.binding.Bindings;
import javafx.beans.binding.StringBinding;
import javafx.beans.property.DoubleProperty;
import javafx.beans.property.SimpleDoubleProperty;

public class ComputedNumberToString {
    public static void main(String[] args) {
        DoubleProperty value = new SimpleDoubleProperty(3.14);

        StringBinding display = Bindings.createStringBinding(
            () -> "Value: " + value.get(),
            value
        );

        System.out.println(display.get());   // Value: 3.14

        value.set(2.71);
        System.out.println(display.get());   // Value: 2.71
    }
}
```

The binding depends only on `value`. Whenever `value` changes, the next call to `display.get()` returns the updated string. This is the same pattern you use when binding a label's text to a number: the binding does the type conversion (number → string) for you.

For formatted numbers (e.g. fixed decimal places), you can use **`Bindings.format`**:

```java
StringBinding formatted = Bindings.format("Value: %.2f", value);
```

Then `formatted.get()` returns something like `"Value: 3.14"` and updates when `value` changes.

## Summary

- **Computed bindings** are values derived from one or more observables; they recompute (lazily) when dependencies change.
- **`Bindings.add(a, b)`** gives a numeric binding (sum).
- **`Bindings.createStringBinding(() -> ..., dep1, dep2, ...)`** gives a string binding that depends on the listed observables; the lambda computes the string.
- **`Bindings.format(format, ...)`** gives a formatted string; arguments can be observables so the result updates when they change.
- Use these when you need a **derived** or **mapped** value (e.g. number to string, or combining several properties into one) that stays in sync with the source properties.
