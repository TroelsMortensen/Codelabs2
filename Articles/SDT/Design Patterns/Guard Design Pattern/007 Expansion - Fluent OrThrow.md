# Expansion: Fluent OrThrow

This expansion introduces a fluent style where check and throw are separated.

## Example

Here is a cut out piece of code to, it still works together with the Check class.

```java
public final class ValidationResult {
    private final boolean valid;

    public ValidationResult(boolean valid) {
        this.valid = valid;
    }

    public void orThrow(String message) {
        if (!valid) {
            throw new IllegalArgumentException(message);
        }
    }
}

public static final class Requirement {
    public ValidationResult isTrue(boolean condition) {
        return new ValidationResult(condition);
    }
}
```

Usage:

```java
Check.That.isTrue(order.getTotal() > 0).orThrow("Order total must be positive");
```

## When to use

Use this style when you want method chaining and context-specific exception messages.
