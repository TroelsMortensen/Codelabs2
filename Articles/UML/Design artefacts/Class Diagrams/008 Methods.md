# Methods

In UML, methods are represented in the bottom compartment of the class diagram. They are shown with their visibility (public, private, protected) and their parameters.

For example, the `getName()` and `getAge()` methods from the previous example are public and have no parameters.

![methods](Resources/Methods.png)

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

Notice the public visibility of the methods in the above snippet.

Methods can also be private in Java, in which case you just mark them with `-` in UML.

## UML Format

The format of a method in UML is:
```
visibility name(parameters) : return type
```

Where:
- `visibility` is the access modifier, one of `+`, `-`, `#`, or `~`.
- `name` is the name of the method.
- `parameters` is a comma separated list of parameters, in the format `parameterName : parameterType`.
- `return type` is the type of the return value.

Example:
```
+ getName() : String
+ getAge() : int
+ setName(name : String) : void
+ setAge(age : int) : void
```

## Adding methods to a class in Astah

This is the same as with constructors, you just also have the return type. Go to the previous page to see how to add a method.