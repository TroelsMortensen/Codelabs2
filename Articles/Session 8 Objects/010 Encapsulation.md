# Encapsulation

This topic is about hiding the internals of an object and exposing only what is necessary. 

Look at your laptop. It is encased, you cannot directly see the internal components, but you can use it to perform tasks. The laptop exposes a _public_ way to interact with it, through buttons.

Many electronic devices are designed this way, to protect the internal components, so you cannot accidentally do something to the internals, which you are not supposed to do.

We apply the same principle to objects in programming. Given that one object, _A_, can interact with another object, _B_, we want to make sure that _A_ can only interact with _B_ through a well-defined interface, exposing only the necessary methods and properties, while hiding the internal implementation details of _B_. This is called encapsulation.

## Encapsulation in Java

In Java programming, encapsulation is the practice of keeping the internal state (properties, aka. fields) of an object hidden from the outside world, and only allowing access or modification through public methods (getters and setters). This is achieved by:

- Declaring fields as `private` so they cannot be accessed directly from outside the class.
- Providing `public` methods to read (get) or change (set) the values of these fields, if needed.

Encapsulation helps to:
- Protect the internal state of an object from unintended or harmful changes.
- Control how the data is accessed or modified.
- Make code easier to maintain and understand.

**Example:**

```java
public class Person {
    private String name; // private field

    // public getter
    public String getName() {
        return name;
    }

    // public setter
    public void setName(String name) {
        this.name = name;
    }
}
```

In this example, the `name` field is private and cannot be accessed directly from outside the `Person` class. Instead, you use the `getName()` and `setName()` methods to access or change the value.


