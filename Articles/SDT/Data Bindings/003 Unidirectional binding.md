# Unidirectional Binding

**Unidirectional binding** means one property (the **target**) is tied to another (the **source**). The target always reflects the source and cannot be set directly. When the source changes, the target updates automatically.

## The API

Call **`target.bind(source)`** on the property that should follow:

- The **target** is the one you call `bind` on; it becomes the "follower."
- The **source** is the argument; it is the "leader."
- After binding, the target's value is always equal to the source's value. Setting the target directly is not allowed and will throw an exception.

## Rules

- The target must be **writable** before you call `bind`. Once bound, it is **read-only**: you must not call `set()` on it.
- The source remains writable; change it and the target updates automatically.
- To change what the target follows, first call **`target.unbind()`**, then call **`target.bind(newSource)`** with a different source. After unbinding, the target is writable again (but its value is unchanged until you set or re-bind it).

## Example: Integer Properties

```java
import javafx.beans.property.IntegerProperty;
import javafx.beans.property.SimpleIntegerProperty;

public class UnidirectionalInteger {
    public static void main(String[] args) {
        IntegerProperty source = new SimpleIntegerProperty(100);
        IntegerProperty target = new SimpleIntegerProperty(0);

        System.out.println("Before bind: source=" + source.get() + ", target=" + target.get());

        target.bind(source);
        System.out.println("After bind:  source=" + source.get() + ", target=" + target.get());

        source.set(50);
        System.out.println("After set source to 50: source=" + source.get() + ", target=" + target.get());

        // target.set(200);  // Would throw UnsupportedOperationException
    }
}
```

Output:

```
Before bind: source=100, target=0
After bind:  source=100, target=100
After set source to 50: source=50, target=50
```

The target immediately takes the source's value when bound, and then follows every change to the source.

## Example: String Properties

```java
import javafx.beans.property.SimpleStringProperty;
import javafx.beans.property.StringProperty;

public class UnidirectionalString {
    public static void main(String[] args) {
        StringProperty source = new SimpleStringProperty("Hello");
        StringProperty target = new SimpleStringProperty("");

        target.bind(source);
        System.out.println("target = " + target.get());   // Hello

        source.set("World");
        System.out.println("target = " + target.get());   // World
    }
}
```

Same idea: the target is bound to the source, so it always shows the source's value and cannot be set on its own.

## Summary

- **`target.bind(source)`**: Target follows source and becomes read-only.
- Only the **source** should be modified after binding; the target updates automatically.
- Use **`target.unbind()`** if you need to re-bind the target to a different source or set it manually again.
