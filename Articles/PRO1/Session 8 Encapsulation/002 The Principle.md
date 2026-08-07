# The Principle of Encapsulation

Now that you understand what encapsulation is and why it matters, let's explore how it works in Java.

## How Encapsulation Works in Java

In Java programming, encapsulation is achieved through **access modifiers** and **methods**:

1. **Declare fields as `private`** - Fields cannot be accessed directly from outside the class
2. **Provide `public` methods** - Methods to read (get) or change (set) the values of these fields, if needed

These methods are called **getters** and **setters**, or **accessors** and **mutators**.

## Access Modifiers: Private vs. Public

### Private Fields

Fields declared as `private` can only be accessed from within the same class. This hides the internal state from the outside world.

```java
public class Person {
    private String name;  // private field - cannot be accessed from outside
    private int age;      // private field - cannot be accessed from outside
}
```

If you try to access a private field from outside the class, you'll get a compiler error:

```java
public static void main(String[] args) {
    Person person = new Person("Alice", 30);
    person.age;  // Compiler error: age has private access
}
```

### Public Methods

Methods declared as `public` can be called from anywhere. These methods provide controlled access to the private fields.

```java
public class Person {
    private String name;
    private int age;
    
    // Public getter - allows reading the name
    public String getName() {
        return name;
    }
    
    // Public setter - allows changing the name
    public void setName(String name) {
        this.name = name;
    }
}
```

## Getters and Setters

### Getters (Accessors)

**Getters** are methods that allow you to read the value of a private field. They typically follow the naming convention `getFieldName()`.

```java
public class Person {
    private String name;
    
    // Getter for name
    public String getName() {
        return name;
    }
}
```

### Setters (Mutators)

**Setters** are methods that allow you to change the value of a private field. They typically follow the naming convention `setFieldName()`.

```java
public class Person {
    private String name;
    
    // Setter for name
    public void setName(String name) {
        this.name = name;
    }
}
```

## Complete Example

Here's a complete example showing encapsulation in action:

```java
public class Person {
    private String name;  // private field
    private int age;      // private field
    
    // Public getter for name
    public String getName() {
        return name;
    }
    
    // Public setter for name
    public void setName(String name) {
        this.name = name;
    }
    
    // Public getter for age
    public int getAge() {
        return age;
    }
    
    // Public setter for age
    public void setAge(int age) {
        this.age = age;
    }
}
```

In this example, the `name` and `age` fields are private and cannot be accessed directly from outside the `Person` class. Instead, you use the `getName()`, `setName()`, `getAge()`, and `setAge()` methods to access or change the values.

## Data Validation in Setters

One of the key benefits of encapsulation is that you can add validation logic to setters. This ensures that data is never set to an invalid value.

### Example: Validating Age

Consider the following `setAge()` method with validation:

```java
public void setAge(int age) {
    if (age >= 0) {
        this.age = age;
    }
}
```

The `Person` class now ensures that the `age` variable is not set to a negative value. If someone tries to set a negative age, the setter simply ignores the invalid value.

### Why This Matters

Without encapsulation, you could directly set invalid values:

```java
public static void main(String[] args) {
    Person person = new Person("Alice", 30);
    person.age = -1;  // If age were public, this would be possible!
}
```

With encapsulation, the setter method is public, so it can be called from outside the class. But it's not just setting the age field variable - it's also checking that the age is not negative, and if it is, it doesn't set the age field variable.

This is encapsulation in action: the `Person` class is hiding its internal state/data, and only exposing methods to interact with that state. These methods can then ensure that the data is not modified in a way that is not allowed.

## The Default Rule

**By default, all your field variables should be `private`, and you can then provide `public` getter and setter methods as needed.**

This ensures that:
- Encapsulation is the default behavior
- You must consciously decide which fields need public access
- Internal state is protected unless explicitly exposed
- You can add validation or logic later without breaking existing code

## Summary

Encapsulation in Java is achieved through:

- **Private fields** - Hide internal state from direct access
- **Public methods** - Provide controlled access through getters and setters
- **Validation** - Setters can enforce rules and prevent invalid data
- **Default practice** - Fields should be private by default

In the next section, we'll see practical examples of encapsulation, including how to properly implement it and what happens when encapsulation is broken.
