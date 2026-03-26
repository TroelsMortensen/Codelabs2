# Expansion: Passthrough Guard

This expansion uses guard methods that return the validated value.

If a value value needs multiple checks, this approach may not be great, though.

## Example

```java
public final class Guard {
    private Guard() {
    }

    public static <T> T againstNull(T input, String name) {
        if (input == null) {
            throw new IllegalArgumentException(name + " cannot be null");
        }
        return input;
    }

    public static String againstBlank(String input, String name) {
        if (input == null || input.trim().isEmpty()) {
            throw new IllegalArgumentException(name + " cannot be empty");
        }
        return input;
    }
}
```

Usage:

```java
public User(String username) {
    this.username = Guard.againstBlank(username, "username");
}
```

## When to use

Use passthrough guards to reduce constructor noise and support direct assignment to `final` fields.


## Upgrade with chaining checks

If you combine the above with the ValidationResult class idea, you can chain checks together.

```java
public User(String username) {
    this.username = Guard.againstBlank(username, "username")
                        .againstMinimumLength(3, "username");
}
```

I will leave the implementation of the againstMinimumLength method as an exercise for the reader.