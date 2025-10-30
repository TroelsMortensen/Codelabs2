# Documenting Classes

Class-level JavaDoc provides an overview of what the class represents and its purpose in the system. This is the first thing developers see when looking at your code or generated documentation.

## Basic Class Documentation

```java
/**
 * Represents a bank account with basic deposit and withdrawal operations.
 */
public class BankAccount {
    // class content
}
```

## @author Tag

The `@author` tag identifies who wrote the class. This can be useful in large projects or open-source software.

**Syntax:** `@author name`

```java
/**
 * Represents a bank account with basic deposit and withdrawal operations.
 * 
 * @author John Smith
 */
public class BankAccount {
    // class content
}
```

You can have multiple `@author` tags if multiple people contributed:

```java
/**
 * Manages customer data in the system.
 * 
 * @author Jane Doe
 * @author John Smith
 */
public class CustomerManager {
    // class content
}
```

## @version Tag

The `@version` tag indicates the version of the class or API.

**Syntax:** `@version version-string`

```java
/**
 * Represents a bank account with basic deposit and withdrawal operations.
 * 
 * @author John Smith
 * @version 1.2
 */
public class BankAccount {
    // class content
}
```

## @since Tag

The `@since` tag indicates when this class was first added to the API. This is particularly useful when maintaining backward compatibility.

**Syntax:** `@since version-number`

```java
/**
 * Represents a savings account with interest calculation.
 * 
 * @author Jane Doe
 * @version 2.0
 * @since 1.5
 */
public class SavingsAccount extends BankAccount {
    // class content
}
```

The `@since` tag tells users that this class has been available since version 1.5 of the library.

## Complete Class Documentation Example

```java
/**
 * Represents a vehicle in the rental system.
 * 
 * This class manages all information related to a rental vehicle,
 * including its registration, type, availability status, and rental
 * pricing. It provides methods for reserving and returning vehicles.
 * 
 * The vehicle can be in one of three states: available, reserved, or
 * under maintenance. State transitions are managed through the
 * appropriate methods.
 * 
 * @author Sarah Johnson
 * @version 2.1
 * @since 1.0
 */
public class Vehicle {
    private String registrationNumber;
    private String type;
    private double dailyRate;
    private VehicleStatus status;
    
    // methods...
}
```

## Best Practices for Class Documentation

### Describe the Purpose
Explain what the class represents or what responsibility it has in the system.

**Good:**
```java
/**
 * Manages user authentication and session handling.
 */
```

**Bad:**
```java
/**
 * A class for users.
 */
```

### Explain Key Concepts
If the class has important concepts or behavior, explain them:

```java
/**
 * Represents a thread-safe queue with bounded capacity.
 * 
 * When the queue is full, put operations will block until space
 * becomes available. When empty, take operations will block until
 * an element is added.
 */
public class BlockingQueue<T> {
    // implementation
}
```

### Mention Related Classes
If there are important related classes, mention them:

```java
/**
 * Represents a customer in the rental system.
 * 
 * Each customer can have multiple reservations. Use the
 * ReservationManager class to create and manage reservations
 * for this customer.
 * 
 * @author Michael Chen
 * @version 1.0
 * @since 1.0
 */
public class Customer {
    // implementation
}
```

### Document Design Decisions
If there are important design decisions or constraints:

```java
/**
 * Represents an immutable date without time or timezone.
 * 
 * Once created, the date values cannot be changed. All methods
 * that appear to modify the date actually return a new instance.
 * This makes the class thread-safe and suitable for use as a
 * HashMap key.
 * 
 * @author David Lee
 * @version 1.0
 * @since 2.0
 */
public final class LocalDate {
    // implementation
}
```

## When to Use @author, @version, @since

These tags are **optional** but recommended in these situations:

- **@author**: Use in professional projects, team environments, or open-source projects
- **@version**: Use when you maintain versioned APIs or libraries
- **@since**: Use when adding new classes to an existing API to help users understand compatibility

For small personal projects or learning exercises, you can often skip these tags and focus on the description.

