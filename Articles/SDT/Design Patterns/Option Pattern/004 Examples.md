# Examples: Option Pattern in Practice

Real-world examples showing how to use the Option pattern with Java's `Optional` class.

## Example 1: Finding Elements in Collections

### Before: Null Return

```java
// Bad: Returns null if not found
public User findUser(String id) {
    for (User user : users) {
        if (user.getId().equals(id)) {
            return user;
        }
    }
    return null;  // Caller must remember to check for null
}

// Usage: Easy to forget null check
User user = findUser("123");
String email = user.getEmail();  // NullPointerException if not found!
```

### After: Optional Return

```java
// Good: Returns Optional
public Optional<User> findUser(String id) {
    return users.stream()
        .filter(user -> user.getId().equals(id))
        .findFirst();  // Returns Optional<User>
}

// Usage: Must handle empty case
Optional<User> user = findUser("123");
if (user.isPresent()) {
    String email = user.get().getEmail();
} else {
    System.out.println("User not found");
}

// Or with ifPresent:
user.ifPresent(u -> System.out.println("Found: " + u.getEmail()));
```

**Benefits:**
- Type-safe - cannot forget to check
- Clear intent - method signature shows it might not find a value
- Functional style - clean operations

## Example 2: Method Return Values

### Before: Null Return

```java
// Bad: Returns null, not explicit
public String getConfigValue(String key) {
    Properties props = loadProperties();
    return props.getProperty(key);  // Returns null if not found
}

// Usage: Must remember null check
String value = getConfigValue("timeout");
if (value != null) {
    int timeout = Integer.parseInt(value);
}
```

### After: Optional Return

```java
// Good: Returns Optional, explicit
public Optional<String> getConfigValue(String key) {
    Properties props = loadProperties();
    String value = props.getProperty(key);
    return Optional.ofNullable(value);
}

// Usage: Type-safe handling
Optional<String> value = getConfigValue("timeout");
if (value.isPresent()) {
    int timeout = Integer.parseInt(value.get());
    // Use timeout
} else {
    int timeout = 30;  // Default to 30 if not found
}
```

## Example 3: Default Values and Fallbacks

### Simple Default

```java
Optional<String> name = findName(userId);

// Simple default
String displayName = name.orElse("Anonymous");

// Lazy default (only computed if needed)
String displayName = name.orElseGet(() -> generateDefaultName());

// Throw exception if missing
String displayName = name.orElseThrow(() -> 
    new IllegalArgumentException("Name required for user: " + userId));
```

### Conditional Defaults

```java
Optional<String> timeoutStr = getConfigValue("timeout");
if (timeoutStr.isPresent()) {
    try {
        int timeout = Integer.parseInt(timeoutStr.get());
        if (timeout > 0) {
            // Use timeout
        } else {
            int timeout = 30;  // Default if invalid
        }
    } catch (NumberFormatException e) {
        int timeout = 30;  // Default if parse fails
    }
} else {
    int timeout = 30;  // Default if missing
}
```




## Key Takeaways

From these examples:

1. **Use Optional for return values** - Makes absence explicit
2. **Always check before using** - Use `isPresent()` or `ifPresent()`
3. **Provide defaults** - Use `orElse` or `orElseGet`
4. **Handle empty cases** - Never assume a value exists
5. **Better than null** - Type-safe, explicit, prevents errors

**The pattern:** Wrap potentially missing values in Optional, then handle the empty case explicitly.

For advanced features like functional operations (map, flatMap, filter) and elegant chaining, see the Advanced Features section.

