# Bidirectional Binding

**Bidirectional binding** keeps two properties in sync: changing either one updates the other. Both remain writable. This is useful when two properties represent the same logical value (e.g. the same field in different parts of the UI or in a model and a copy).

## The API

Call **`prop1.bindBidirectional(prop2)`**. After that:

- Setting `prop1` updates `prop2` to the same value.
- Setting `prop2` updates `prop1` to the same value.
- Neither property becomes read-only; you can use `set()` on either.

To remove the link, call **`prop1.unbindBidirectional(prop2)`** (same two properties as when you bound them).

## Example: Two Integer Properties

```java
import javafx.beans.property.IntegerProperty;
import javafx.beans.property.SimpleIntegerProperty;

public class BidirectionalInteger {
    public static void main(String[] args) {
        IntegerProperty a = new SimpleIntegerProperty(10);
        IntegerProperty b = new SimpleIntegerProperty(20);

        System.out.println("Before bindBidirectional: a=" + a.get() + ", b=" + b.get());

        a.bindBidirectional(b);
        System.out.println("After bindBidirectional:  a=" + a.get() + ", b=" + b.get());

        a.set(100);
        System.out.println("After a.set(100):         a=" + a.get() + ", b=" + b.get());

        b.set(200);
        System.out.println("After b.set(200):        a=" + a.get() + ", b=" + b.get());
    }
}
```

Output:

```
Before bindBidirectional: a=10, b=20
After bindBidirectional:  a=20, b=20
After a.set(100):         a=100, b=100
After b.set(200):         a=200, b=200
```

When you bind bidirectionally, one of the two "wins" for the initial value (here `b`'s value is used for both). After that, whichever property you set, the other follows.

## Example: Two String Properties

```java
import javafx.beans.property.SimpleStringProperty;
import javafx.beans.property.StringProperty;

public class BidirectionalString {
    public static void main(String[] args) {
        StringProperty first = new SimpleStringProperty("Alice");
        StringProperty second = new SimpleStringProperty("Bob");

        first.bindBidirectional(second);
        System.out.println("first=" + first.get() + ", second=" + second.get());  // both "Bob" (second's value)

        first.set("Carol");
        System.out.println("first=" + first.get() + ", second=" + second.get());  // both "Carol"

        second.set("Dave");
        System.out.println("first=" + first.get() + ", second=" + second.get());  // both "Dave"
    }
}
```

Same idea: after `bindBidirectional`, both properties always hold the same value, and you can set either one.

## Summary

- **`prop1.bindBidirectional(prop2)`**: The two properties stay in sync; both stay writable.
- Changing either property updates the other.
- Use **`prop1.unbindBidirectional(prop2)`** to remove the link. After that, each property keeps its current value and can be set independently again.
