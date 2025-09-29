# When are two objects considered the same?

The `equals` method is used to test logical equality between two objects. It is declared in the `Object` class and inherited by every class in Java. The default implementation in `Object` compares references (same as `==`), so two distinct objects with the same content are not considered equal unless a class overrides `equals`. This means that the default equals methods checks whether two variables reference the same object in memory. This may not always be what you want.

Why override `equals`?
- To define equality in terms of object content (fields) rather than memory identity (memory address).
- To make objects usable in collections and algorithms that rely on logical equality (e.g., `List.contains`, `Set`, `Map`).

Basic differences:
- `==` checks if two references point to the same object.
- `equals` (when overridden) checks if two objects are logically equivalent.

Example: `==` vs `equals`
```java
String a = new String("hello");
String b = new String("hello");

System.out.println(a == b);        // false (different objects)
System.out.println(a.equals(b));   // true  (String overrides equals)
```

How to override `equals`, here is a template.:

```java
// Signature: 
@Override
public boolean equals(Object obj)
{
  // Typical steps inside the method:
  if (this == obj) return true; // check if the two objects reference the same memory address
  if (obj == null || getClass() != obj.getClass()) return false; // check if the other object is null or not of the same class
  // Cast to the class and compare relevant fields (use Objects.equals for null-safe comparisons).
  return true;
}
```

Also override `hashCode` (see next page) whenever you override `equals` so equal objects produce the same hash code (important for `HashSet`, `HashMap`, etc.).

Example Person class with equals:
```java
import java.util.Objects;

public class Person {
    private String name;
    private int age;

    public Person(String name, int age) {
        this.name = name;
        this.age = age;
    }

    // Standard getters/setters omitted for brevity

    @Override
    public boolean equals(Object obj) {
        if (this == obj) return true; // same reference
        if (obj == null || getClass() != obj.getClass()) return false; // null or different class
        Person other = (Person) obj;
        return age == other.age && Objects.equals(name, other.name); // compare fields
    }
}
```

Alternatively, instead of the `getClass()`, you might use `instanceof`, like this:

 ```java
    @Override
    public boolean equals(Object obj) {
        if (this == obj) return true; // same reference
        if ( ! (obj instanceof Person person)) return false; // different class
        Person other = (Person) obj;
        return age == other.age && name.equals(other.name); // compare fields
    }
```

**Common pitfalls and best practices**
- Always override `hashCode` with `equals`.
- Prefer the `instanceof` check if your class is designed for inheritance; prefer `getClass()` check for strict class equality.

