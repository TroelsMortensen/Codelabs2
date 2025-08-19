# Access modifiers

In UML, access modifiers are used to specify the visibility of class members (attributes and methods). The most common access modifiers are:

1. **Public (+)**: The member is accessible from outside the class
2. **Private (-)**: The member is only accessible within the class
3. **Protected (#)**: The member is accessible within the class and its subclasses (you will learn about protected later in the course)

These modifiers are represented in the class diagram as prefixes to the member names. 

In this example, the `name` and `age` attributes are private (indicated by the `-` prefix), while the `getName()` and `getAge()` methods are public (indicated by the `+` prefix).

![access modifiers](Resources/class-example.png)

The corresponding Java code:

```java
public class Person {
    private String name;
    private int age;

    public String getName() {
        return name;
    }

    public int getAge() {
        return age;
    }
}
```

Notice public and private in the above snippet.

## Access modifiers in Astah

Video here..