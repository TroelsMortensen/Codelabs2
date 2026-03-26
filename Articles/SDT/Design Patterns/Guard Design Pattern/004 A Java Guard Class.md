# A Java Guard Class (Ardalis-Inspired)

Steve Smith (Ardalis) popularized a practical style where guard clauses are centralized in a reusable type.

Below is a simple baseline implementation with static methods.

## Example `Guard` Class

```java
public final class Guard {
    private Guard() {
    }

    public static void againstNull(Object input, String paramName) {
        if (input == null) {
            throw new IllegalArgumentException(paramName + " must not be null");
        }
    }

    public static void againstBlank(String input, String paramName) {
        againstNull(input, paramName);
        if (input.isBlank()) {
            throw new IllegalArgumentException(paramName + " must not be blank");
        }
    }

    public static void againstNonPositive(int input, String paramName) {
        if (input <= 0) {
            throw new IllegalArgumentException(paramName + " must be > 0");
        }
    }
}
```

## Usage Example

```java
public class Product {
    private final String name;
    private final int priceInCents;

    public Product(String name, int priceInCents) {
        Guard.againstNull(name, "name");
        Guard.againstBlank(name, "name");
        Guard.againstNonPositive(priceInCents, "priceInCents");

        this.name = name;
        this.priceInCents = priceInCents;
    }
}
```

## Why this helps

- one place for common validation logic
- consistent exception messages
- shorter constructors and service methods



