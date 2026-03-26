# Expansion: General Boolean Requirement

This expansion adds a general requirement method based on a boolean condition.

## Example

```java
public static final class Requirement {
    public void isTrue(boolean condition, String message) {
        if (!condition) {
            throw new IllegalStateException("Requirement failed: " + message);
        }
    }

    public <T> void matches(T value, java.util.function.Predicate<T> rule, String message) {
        if (!rule.test(value)) {
            throw new IllegalStateException("Requirement failed: " + message);
        }
    }

    public void require(java.util.function.BooleanSupplier condition, String message) {
        if (!condition.getAsBoolean()) {
            throw new IllegalStateException("Requirement failed: " + message);
        }
    }
}
```

## When to use

Use `isTrue(...)` for simple rule checks, `matches(...)` for value-based predicates, and `require(...)` for no-input conditions.

## Usage Example

```java
public void processOrder(Order order) {
    Check.Against.nullValue(order, "order");

    Check.That.isTrue(order.getTotal() > 0, "Order total must be positive");
    Check.That.matches(order.getCustomerEmail(), email -> email.contains("@"), "Email must contain @");
    Check.That.require(() -> order.hasItems(), "Order must contain at least one item");

    // happy path continues
}
```


