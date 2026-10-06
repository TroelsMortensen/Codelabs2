# What is association

An **association** is a relationship between two classes where one class "knows about", "uses", or "references" another class.

It represents a loose coupling where objects can exist independently of each other. In a one-to-one association, each instance of one class is associated with one instance of another class.

Association is the most common relationship between two objects.

The short version: one object has a reference to another object — a field variable of the first object is an instance of the second object.

Watch the following video for an overview of the association relationship:

<video src="https://youtu.be/pnRQPfMuyQY"></video>

## Key characteristics

- **Loose coupling**: Objects can exist independently
- **Bidirectional or unidirectional**: Objects can reference each other (though one-way is more common)
- **No ownership**: Neither object _owns_ the other
- **Flexible**: Objects can be created and destroyed independently

## How association works in Java

Association is implemented by having a field variable of the first class which is an instance of the second class.

Class `A` has a field variable `b` of type `B`. So `A` has an association with `B`.

```java
public class A
{
    private B b; // association with B
}

public class B
{
}
```

## Key points

1. **Independence**: Both objects can exist without each other
2. **Flexibility**: Objects can be associated and disassociated at runtime
3. **No lifecycle dependency**: Destroying one object does not affect the other
4. **Reference-based**: Uses object references
5. **Runtime binding**: Associations can be established and changed during program execution

Association is the most flexible type of relationship and is commonly used when you need objects to work together but maintain their independence.
