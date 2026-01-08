# Advanced Features: Functional Operations and Chaining

Once you understand the basics of Optional, you can use functional operations to write more elegant and concise code.

## Functional Operations

Optional provides functional-style operations for working with values. These operations allow you to transform, filter, and chain Optionals without explicit null checks.

### map - Transform the Value

The `map` operation transforms the value inside an Optional if it's present:

```java
Optional<String> name = Optional.of("alice");

// Transform if present
Optional<String> upper = name.map(String::toUpperCase);  // Optional.of("ALICE")

// If empty, map does nothing
Optional<String> empty = Optional.<String>empty();
Optional<String> result = empty.map(String::toUpperCase);  // Still empty
```

**How it works:**
- If Optional is present: applies the function and wraps the result
- If Optional is empty: returns empty Optional without calling the function

**Example:**
```java
Optional<Integer> age = Optional.of(25);
Optional<String> ageString = age.map(a -> "Age: " + a);  // Optional.of("Age: 25")

Optional<Integer> emptyAge = Optional.empty();
Optional<String> emptyString = emptyAge.map(a -> "Age: " + a);  // Optional.empty()
```

### flatMap - Chain Optionals

The `flatMap` operation is used when you have an Optional that contains another Optional. It "flattens" the nested structure:

```java
// If you have Optional<Optional<String>>, flatten it
Optional<User> user = Optional.of(new User("Alice"));

Optional<String> email = user
    .flatMap(User::getEmail);  // getEmail() returns Optional<String>
```

**Difference between map and flatMap:**

```java
// map: Returns Optional<Optional<String>>
Optional<Optional<String>> nested = user.map(User::getEmail);

// flatMap: Returns Optional<String> (flattened)
Optional<String> flat = user.flatMap(User::getEmail);
```

**When to use flatMap:**
- When the function you're applying returns an Optional
- When you want to chain operations that might return empty

**Example:**
```java
public class User {
    private Address address;
    
    public Optional<Address> getAddress() {
        return Optional.ofNullable(address);
    }
}

public class Address {
    private String city;
    
    public Optional<String> getCity() {
        return Optional.ofNullable(city);
    }
}

// Chain with flatMap
Optional<User> user = findUser("123");
Optional<String> city = user
    .flatMap(User::getAddress)  // Returns Optional<Address>
    .flatMap(Address::getCity);  // Returns Optional<String>
```

### filter - Conditionally Keep Value

The `filter` operation keeps the value only if it matches a condition:

```java
Optional<String> name = Optional.of("Alice");

// Keep only if condition is true
Optional<String> longName = name.filter(n -> n.length() > 5);  // Empty (Alice is 5 chars)
Optional<String> shortName = name.filter(n -> n.length() < 10);  // Present ("Alice")
```

**How it works:**
- If Optional is present and condition is true: returns the same Optional
- If Optional is present but condition is false: returns empty Optional
- If Optional is empty: returns empty Optional (condition not evaluated)

**Example:**
```java
Optional<Integer> age = Optional.of(25);

// Keep only if age is 18 or older
Optional<Integer> adultAge = age.filter(a -> a >= 18);  // Present (25)

// Keep only if age is over 100
Optional<Integer> centenarian = age.filter(a -> a > 100);  // Empty
```

## Chaining Operations

Optional allows you to chain operations elegantly, avoiding nested if statements:

### Before: Nested Null Checks

```java
// Bad: Deeply nested null checks
public String getCity(User user) {
    if (user != null) {
        Address address = user.getAddress();
        if (address != null) {
            return address.getCity();
        }
    }
    return null;
}
```

### After: Clean Chain with Optional

```java
// Good: Clean functional chain
public Optional<String> getCity(User user) {
    return Optional.ofNullable(user)
        .map(User::getAddress)
        .map(Address::getCity);
}

// Usage:
Optional<String> city = getCity(user);
String cityName = city.orElse("Unknown");
```

**Benefits:**
- No nested if statements
- Clear and readable
- Type-safe
- Handles null at every step

### Complex Chaining Example

```java
// Get user's shipping city, but only if user is active
public Optional<String> getActiveUserCity(String userId) {
    return findUser(userId)
        .filter(User::isActive)  // Only active users
        .map(User::getAddress)
        .map(Address::getCity)
        .filter(city -> !city.isEmpty());  // Only non-empty cities
}
```

## Combining Optionals

### Combining Two Optionals

```java
// Get user and their address, both might be missing
Optional<User> user = findUser("123");
Optional<Address> address = user.flatMap(User::getAddress);

// Combine with default
String city = address
    .map(Address::getCity)
    .orElse("No city");
```

### Combining Multiple Optionals

```java
// Get first non-empty value
Optional<String> result = Optional.ofNullable(getPrimaryEmail())
    .or(() -> Optional.ofNullable(getSecondaryEmail()))
    .or(() -> Optional.ofNullable(getDefaultEmail()));

String email = result.orElse("no-email@example.com");
```

### Combining with Conditions

```java
// Get timeout from config, but validate it
Optional<Integer> timeout = getConfigValue("timeout")
    .map(Integer::parseInt)
    .filter(t -> t > 0)  // Only positive values
    .filter(t -> t < 3600);  // Less than 1 hour
```

## Advanced Chaining Patterns

### Pattern 1: Transform and Validate

```java
// Parse and validate in one chain
Optional<Integer> validTimeout = Optional.ofNullable(System.getProperty("timeout"))
    .map(Integer::parseInt)
    .filter(t -> t > 0)
    .filter(t -> t <= 300);
```

### Pattern 2: Chain with Fallbacks

```java
// Try primary, fallback to secondary
Optional<String> email = getUserPrimaryEmail(userId)
    .filter(e -> e.contains("@"))
    .or(() -> getUserSecondaryEmail(userId))
    .or(() -> Optional.of("default@example.com"));
```

### Pattern 3: Conditional Transformation

```java
// Transform only if condition is met
Optional<String> displayName = findUser(userId)
    .filter(User::isActive)
    .map(User::getName)
    .map(name -> name.toUpperCase());
```

## Implementing Your Own Option

The Option pattern is simple enough that you can implement your own. Here's a complete implementation with all functional operations:

```java
import java.util.function.*;

public class Option<T> {
    private final T value;
    private final boolean isPresent;
    
    private Option(T value, boolean isPresent) {
        this.value = value;
        this.isPresent = isPresent;
    }
    
    // Factory methods
    public static <T> Option<T> of(T value) {
        if (value == null) {
            throw new NullPointerException("Value cannot be null");
        }
        return new Option<>(value, true);
    }
    
    public static <T> Option<T> empty() {
        return new Option<>(null, false);
    }
    
    public static <T> Option<T> ofNullable(T value) {
        return value == null ? empty() : of(value);
    }
    
    // Query methods
    public boolean isPresent() {
        return isPresent;
    }
    
    public boolean isEmpty() {
        return !isPresent;
    }
    
    // Get value
    public T get() {
        if (!isPresent) {
            throw new NoSuchElementException("No value present");
        }
        return value;
    }
    
    // Default values
    public T orElse(T other) {
        return isPresent ? value : other;
    }
    
    public T orElseGet(Supplier<T> supplier) {
        return isPresent ? value : supplier.get();
    }
    
    public <X extends Throwable> T orElseThrow(Supplier<? extends X> exceptionSupplier) throws X {
        if (isPresent) {
            return value;
        } else {
            throw exceptionSupplier.get();
        }
    }
    
    // Functional operations
    public <U> Option<U> map(Function<T, U> mapper) {
        return isPresent ? Option.of(mapper.apply(value)) : Option.empty();
    }
    
    public <U> Option<U> flatMap(Function<T, Option<U>> mapper) {
        return isPresent ? mapper.apply(value) : Option.empty();
    }
    
    public Option<T> filter(Predicate<T> predicate) {
        return isPresent && predicate.test(value) ? this : Option.empty();
    }
    
    // Consumer
    public void ifPresent(Consumer<T> consumer) {
        if (isPresent) {
            consumer.accept(value);
        }
    }
    
    public void ifPresentOrElse(Consumer<T> action, Runnable emptyAction) {
        if (isPresent) {
            action.accept(value);
        } else {
            emptyAction.run();
        }
    }
}

// Usage example:
Option<String> name = Option.of("Alice");
name.ifPresent(n -> System.out.println("Name: " + n));
String display = name.orElse("Unknown");

// Functional operations
Option<String> upper = name.map(String::toUpperCase);
Option<Integer> length = name.map(String::length);
Option<String> filtered = name.filter(n -> n.length() > 5);
```

**Key points:**
- Simple structure: value + presence flag
- Immutable
- Type-safe
- Functional operations (map, flatMap, filter)
- Easy to understand and use
- Demonstrates that Option is not magic - it's a simple, elegant solution

## Advanced Use Cases

### Use Case 1: Parsing and Validation

```java
// Parse string to integer, validate range
Optional<Integer> parseAndValidate(String input) {
    return Optional.ofNullable(input)
        .map(String::trim)
        .filter(s -> !s.isEmpty())
        .map(Integer::parseInt)
        .filter(i -> i > 0)
        .filter(i -> i < 1000);
}
```

### Use Case 2: Safe Navigation

```java
// Navigate through object graph safely
Optional<String> getShippingCity(Order order) {
    return Optional.ofNullable(order)
        .map(Order::getCustomer)
        .map(User::getAddress)
        .map(Address::getCity)
        .filter(city -> !city.isEmpty());
}
```

### Use Case 3: Conditional Processing

```java
// Process only if conditions are met
Optional<String> processIfValid(User user) {
    return Optional.ofNullable(user)
        .filter(User::isActive)
        .filter(u -> u.getEmail() != null)
        .map(User::getEmail)
        .filter(email -> email.contains("@"));
}
```

## Summary

Advanced Optional features:

1. **map** - Transform values if present
2. **flatMap** - Chain Optionals (flatten nested Optionals)
3. **filter** - Conditionally keep values
4. **Chaining** - Combine operations elegantly
5. **Combining** - Merge multiple Optionals
6. **Custom implementation** - Easy to create your own Option type

**The power:** These functional operations let you write clean, readable code that handles null cases automatically, without explicit null checks.

