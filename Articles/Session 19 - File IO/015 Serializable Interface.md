# Serializable Interface

The `Serializable` interface is a [marker interface](https://www.geeksforgeeks.org/java/marker-interface-in-java/) in Java that allows objects to be converted into a binary format that can be saved to files or transmitted over networks, and later reconstructed back into objects.

A marker interface is an interface that does not contain any methods. It is used to sort of put a label on an object.

**This interface already exists in Java!!!**

## What is Serialization?

**Serialization** is the process of converting a Java object into a stream of bytes that can be stored in a file (or transmitted over a network).

**Deserialization** is the reverse process - converting the byte stream back into a Java object.

We can serialize and deserialize objects to and from a file, which is a convenient, simple way to store (persist) objects for later use.

### Real-World Analogy

Think of serialization like **packing a suitcase**:
- **Serialization** = Packing your clothes (object) into a suitcase (binary format)
- **Deserialization** = Unpacking the suitcase to get your clothes back (object)

## The Serializable Interface

### Basic Usage

Here is a `Person` class. I wish to be able to serialize this object, and put that binary data into a file. To enable this, the `Person` class must implement the `Serializable` interface. The `Serializable` interface is already part of the Java library, we just need to import it.

```java{1,3}
import java.io.Serializable;

public class Person implements Serializable {
    private String name;
    private int age;
    private String email;
    
    public Person(String name, int age, String email) {
        this.name = name;
        this.age = age;
        this.email = email;
    }
    // getters, setters, toString, etc..
}
```

### Key Points About Serializable

1. **Marker Interface**: No methods to implement
2. **Automatic Serialization**: Java handles the conversion automatically
3. **All Fields Included**: By default, all non-static fields are serialized







## Nested serializable objects

The `Person` class above contains field variables of only primitive types (here, I include String, as it behaves the same). And as long as we have primitive types, we can serialize the object.

But what if the `Person` class contains fields that are not primitive types? For example, if the `Person` class contains an `Address` field variable. In this case, the `Address` class must also implement the `Serializable` interface.

```java
public class Address implements Serializable {
    private String street;
    private String city;
    private String state;
    private String zip;
}
```

Now, the `Person` class can contain an `Address` field variable.

```java
public class Person implements Serializable {
    private String name;
    private int age;
    private String email;
    private Address address;
}
```

And if the `Address` class is not serializable, we will get a `NotSerializableException`.

What if the `Address` class has a field variable, of some object type, e.g. `Country`, which has `name` and `code`? Once again, the `Country` class must also implement the `Serializable` interface.

It's serializable all the way down. Once again. Like the turtles.