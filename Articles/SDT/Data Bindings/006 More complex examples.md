# More Complex Examples

This page ties the concepts together with a few slightly more involved examples, still using only a simple `main` method. Then we recap when to use which kind of binding.

You will probably not need this, but, just to let you know it exists.

## Formatted Total: Price and Quantity

Two numeric properties (e.g. price and quantity) and a string binding that shows a formatted total:

```java
import javafx.beans.binding.Bindings;
import javafx.beans.binding.StringBinding;
import javafx.beans.property.DoubleProperty;
import javafx.beans.property.SimpleDoubleProperty;

public class FormattedTotal {
    public static void main(String[] args) {
        DoubleProperty price = new SimpleDoubleProperty(10.0);
        DoubleProperty quantity = new SimpleDoubleProperty(3.0);

        StringBinding totalDisplay = Bindings.createStringBinding(
            () -> String.format("Total: %.2f (price %.2f x quantity %.0f)",
                price.get() * quantity.get(), price.get(), quantity.get()),
            price, quantity
        );

        System.out.println(totalDisplay.get());
        // Total: 30.00 (price 10.00 x quantity 3)

        price.set(5.5);
        quantity.set(4);
        System.out.println(totalDisplay.get());
        // Total: 22.00 (price 5.50 x quantity 4)
    }
}
```

The binding depends on both `price` and `quantity`. Any change to either recomputes the displayed string when `get()` is called.

## Boolean Binding: Above a Threshold

A numeric property and a boolean that is true when the number is above a threshold. JavaFX has **BooleanBinding** and `Bindings` helpers for comparisons:

```java
import javafx.beans.binding.Bindings;
import javafx.beans.binding.BooleanBinding;
import javafx.beans.property.IntegerProperty;
import javafx.beans.property.SimpleIntegerProperty;

public class ThresholdBinding {
    public static void main(String[] args) {
        IntegerProperty value = new SimpleIntegerProperty(5);
        int threshold = 10;

        BooleanBinding isAboveThreshold = Bindings.greaterThan(value, threshold);

        System.out.println("value=" + value.get() + ", isAboveThreshold=" + isAboveThreshold.get());  // false

        value.set(15);
        System.out.println("value=" + value.get() + ", isAboveThreshold=" + isAboveThreshold.get());  // true

        value.set(10);
        System.out.println("value=" + value.get() + ", isAboveThreshold=" + isAboveThreshold.get());  // false (10 is not greater than 10)
    }
}
```

**`Bindings.greaterThan(a, b)`** returns a `BooleanBinding` that is true when `a.get() > b`. Similar methods exist for less-than, equal-to, etc. The binding updates whenever the observable (here `value`) changes.

## Chained Dependencies

A depends on B, and C depends on A. Changing B should propagate to A and then to C:

```java
import javafx.beans.property.IntegerProperty;
import javafx.beans.property.SimpleIntegerProperty;

public class ChainedBinding {
    public static void main(String[] args) {
        IntegerProperty b = new SimpleIntegerProperty(1);
        IntegerProperty a = new SimpleIntegerProperty(0);
        IntegerProperty c = new SimpleIntegerProperty(0);

        a.bind(b);   // a follows b
        c.bind(a);   // c follows a

        System.out.println("b=" + b.get() + ", a=" + a.get() + ", c=" + c.get());  // 1, 1, 1

        b.set(10);
        System.out.println("b=" + b.get() + ", a=" + a.get() + ", c=" + c.get());  // 10, 10, 10
    }
}
```

When `b` is set to 10, `a` is updated (because it is bound to `b`), and then `c` is updated (because it is bound to `a`). Bindings propagate along the chain.

## When to Use Which Binding

- **Unidirectional (`bind`)**: Use when one value should always follow another and the target should not be changed directly. Example: a label's text that displays a value from the model; the label should only reflect the model, not be edited.
- **Bidirectional (`bindBidirectional`)**: Use when two properties represent the same logical value and either might be updated. Example: the same field in the model and in a text field; editing either should update the other.
- **Computed bindings (`Bindings.add`, `createStringBinding`, `format`, etc.)**: Use when the displayed or stored value is **derived** from one or more observables (sum, concatenation, formatting, comparison). The result is read-only and stays in sync with its dependencies.

In a real JavaFX app, you will often combine these: e.g. a computed binding for a total, bound unidirectionally to a label, and bidirectional binding between a text field and a property in the model.
