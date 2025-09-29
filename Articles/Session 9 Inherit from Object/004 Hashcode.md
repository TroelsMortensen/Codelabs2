# The `hashCode` Method in Java

`hashCode` is a method defined on `Object` that returns an `int`. It is a way to represent on object, with its specific data, as an int. In some cases, this is convenient.\
When you override `equals` to define logical equality, you must also override `hashCode` so that equal objects produce the same hash code.

Summary of the contract:
- If `a.equals(b)` is true, then `a.hashCode() == b.hashCode()` must also be true.
- If `a.equals(b)` is false, `a.hashCode()` and `b.hashCode()` can be equal or different (collisions are allowed).
- `hashCode` should be consistent: multiple calls on the same object (while relevant fields are unchanged) must return the same value.

Why it matters:
- Collections (like the ArrayList) such as `HashSet` and `HashMap` use `hashCode` to find the bucket where an object might be stored, then use `equals` to confirm equality. If you override `equals` but not `hashCode`, objects that are logically equal may not be found or may appear multiple times in hash-based collections.

Example: overriding `equals` and `hashCode` in `Person`:

```java
// language: java
import java.util.Objects;

public class Person {
    private String name;
    private int age;

    public Person(String name, int age) {
        this.name = name;
        this.age = age;
    }

    @Override
    public boolean equals(Object obj) {
        if (this == obj) return true;
        if (obj == null || getClass() != obj.getClass()) return false;
        Person other = (Person) obj;
        return age == other.age && name.equals(other.name);
    }

    @Override
    public int hashCode() {
        // Simple and common approach using java.util.Objects, notice the import at the top
        return Objects.hash(name, age);
    }
}
```


**Common pitfalls and best practices**
- Always override `hashCode` when you override `equals`.
- Use the same fields in both `equals` and `hashCode`.
- Use `Objects.hash(...)` or IDE-generated implementations for correctness and simplicity.