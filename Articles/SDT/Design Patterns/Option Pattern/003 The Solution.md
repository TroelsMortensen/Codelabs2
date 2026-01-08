# The Solution: The Option Pattern

The Option pattern solves the problems of null references by making absence **explicit and type-safe**.

## How Option Works

The Option pattern wraps a value in a container that has exactly two states:

1. **Some/Just/Present** - Contains a value
2. **None/Empty** - Does not contain a value

This makes the possibility of absence **explicit in the type system**.

## The Two States

### State 1: Present (Some/Just)

When a value exists, it's wrapped in the "Present" state:

```
Optional.of("Hello")
┌─────────────┐
│ Present:    │
│   "Hello"   │
└─────────────┘
```

### State 2: Empty (None)

When no value exists, it's in the "Empty" state:

```
Optional.empty()
┌─────────────┐
│   Empty     │
└─────────────┘
```

## Java's Optional Class

Java 8 introduced `java.util.Optional<T>` as the standard implementation of the Option pattern:

```java
import java.util.Optional;

// Create an Optional with a value
Optional<String> name = Optional.of("Alice");

// Create an empty Optional
Optional<String> empty = Optional.empty();

// Create from a value that might be null
Optional<String> maybeName = Optional.ofNullable(getName());  // getName() might return null
```

## Basic Optional Operations

### Creating Optionals

```java
// Create with a non-null value (throws exception if null)
Optional<String> name = Optional.of("Alice");

// Create empty
Optional<String> empty = Optional.empty();

// Create from nullable value (handles null safely)
String value = getName();  // Might be null
Optional<String> maybe = Optional.ofNullable(value);  // Safe even if value is null
```

### Checking if Value Exists

```java
Optional<String> name = Optional.of("Alice");

// Check if present
if (name.isPresent()) {
    System.out.println("Name: " + name.get());
}

// Modern approach: use ifPresent
name.ifPresent(n -> System.out.println("Name: " + n));
```

### Getting the Value

```java
Optional<String> name = Optional.of("Alice");

// Get value (throws exception if empty)
String value = name.get();  // Use only if you're sure it's present

// Get with default value
String value = name.orElse("Unknown");  // Returns "Unknown" if empty

// Get with supplier (lazy evaluation)
String value = name.orElseGet(() -> generateDefaultName());

// Throw exception if empty
String value = name.orElseThrow(() -> new IllegalArgumentException("Name required"));
```

## How Optional Prevents NullPointerException

Optional **forces you to handle the empty case**:

```java
// Before: Dangerous
public String getCity(User user) {
    if (user != null && user.getAddress() != null) {
        return user.getAddress().getCity();
    }
    return null;  // Or throw exception?
}

// After: Safe with Optional
public Optional<String> getCity(User user) {
    if (user == null || user.getAddress() == null) {
        return Optional.empty();
    }
    return Optional.ofNullable(user.getAddress().getCity());
}

// Usage: Must handle empty case
Optional<String> city = getCity(user);
if (city.isPresent()) {
    System.out.println(city.get());
} else {
    System.out.println("No city available");
}

// Or with ifPresent:
city.ifPresent(c -> System.out.println("City: " + c));
String cityName = city.orElse("Unknown");
```

**Key difference:** The type system forces you to handle the empty case. You cannot accidentally access a value that doesn't exist.

## Implementing Your Own Option

The Option pattern is simple enough that you can implement your own. The basic concept is straightforward: a container that either holds a value or is empty. While Java provides `Optional`, understanding that you can create your own helps you appreciate the simplicity of the pattern.

For a complete implementation with advanced features, see the Advanced Features section.

## Optional vs Null: The Comparison

| Aspect | Null | Optional |
|--------|-----|----------|
| **Explicit** | No - implicit in all types | Yes - explicit in type |
| **Type-safe** | No - runtime errors | Yes - compile-time safety |
| **Forces handling** | No - easy to forget | Yes - must handle empty case |
| **Intent** | Unclear | Clear - absence is explicit |
| **Chaining** | Nested if statements | Clean functional chains |

## When to Use Optional

Use Optional when:

1. **Method might not return a value** - Better than returning null
2. **API design** - Makes absence explicit to callers
3. **Null safety** - Prevents NullPointerException
4. **Functional operations** - For advanced chaining (see Advanced Features)

Don't use Optional for:

1. **Required parameters** - Use regular types, not Optional
2. **Collections** - Use empty collections, not Optional<List>
3. **Performance-critical code** - Optional has slight overhead

## Summary

The Option pattern:

1. **Makes absence explicit** - Type system shows when value might not exist
2. **Prevents NullPointerException** - Forces you to handle empty case
3. **Simple concept** - Easy to understand and implement
4. **Java's Optional** - Standard implementation since Java 8
5. **Easy to implement** - You can create your own Option type
6. **Advanced features** - Functional operations for elegant code (see Advanced Features)

**The key insight:** By making absence explicit in the type system, Option prevents the runtime errors that null causes, while making code clearer and more maintainable.

