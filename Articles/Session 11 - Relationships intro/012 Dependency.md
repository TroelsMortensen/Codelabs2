# Dependency Relationship

A **dependency** is a relationship where one class _uses_ another class temporarily or for a specific operation. It's the weakest form of relationship where one class depends on another class's services or methods, but doesn't maintain a permanent reference to it. In short, there is no field variable involved.

All four relationships in this learning path are some kind of dependency. Some of them are just stronger, so it makes sense to show them as such. But, whenever one class knows about another class in any way, there is a dependency.

This "knows" can be many things, for example:

- having a field variable of the other class
- having a method parameter of the other class
- having a local variable of the other class
- having a return value of the other class
- having a static method call to the other class
- having a method call to the other class
- having a constructor call to the other class
- having a toString method call to the other class

If you have a class, `Person`, and you in another class can search for the word "Person", and find it, there is probably a dependency.

## Key Characteristics

- **Temporary relationship**: Objects interact only when needed
- **No permanent reference**: The dependent class doesn't store a reference to the dependency
- **Method-level interaction**: Dependency is used through method parameters or local variables
- **Loose coupling**: Classes are independent and can exist separately

## How Dependency Works in Java

Dependency is implemented through:
- **Method parameters** that accept other objects, but do not store a reference to it in a field variable
- **Local variables** that create temporary references
- **Return values** from method calls
- **Static method calls** to other classes

## Example 1: Email and EmailValidator

Below is a class, `EmailValidator`, which is used to validate an email address. To keep the example simple, we will only check if the email contains an `@` and a `.`.

```java
public class EmailValidator 
{
    public static boolean isValidEmail(String email) 
    {
        return email != null && email.contains("@") && email.contains(".");
    }
}
```

And then a class, `Main`, which uses the `EmailValidator` class to validate an email address.

```java{6}
public class EmailExample 
{
    public static void main(String[] args) 
    {
        String email = "test@test.com";
        boolean isValid = EmailValidator.isValidEmail(email);

        if (isValid) 
        {
            System.out.println("Email is valid");
        }
        else 
        {
            System.out.println("Email is invalid");
        }
        System.out.println("Email: " + email);
    }
}
```

In this example, the `EmailExample` class is dependent on the `EmailValidator` class, because it uses the static `isValidEmail` method in line 6. The `EmailValidator` class does not store a reference to the `EmailExample` class.


## Example 2: Dependency because method parameter

In this example, the `Calculator` class is dependent on the `Rectangle` class. This is clear from the `Rectangle` type being in method parameters. `Calculator` must then _know_ about the `Rectangle` class. But there is no field variable in `Calculator` that stores a reference to a `Rectangle` object.

A `Rectangle` object is passed to the `Calculator` class as a method parameter, the `Rectangle` is used in that method only, and when the method is finished, the "relationship" to the `Rectangle` object is lost.

```java
public class Calculator 
{
    public double calculateArea(Rectangle rectangle) 
    {
        return rectangle.getWidth() * rectangle.getHeight();
    }
    
    public double calculatePerimeter(Rectangle rectangle) 
    {
        return 2 * (rectangle.getWidth() + rectangle.getHeight());
    }
}

public class Rectangle 
{
    private double width;
    private double height;
    
    public Rectangle(double width, double height) 
    {
        this.width = width;
        this.height = height;
    }
    
    public double getWidth() { return width; }
    public double getHeight() { return height; }
}
```

## Example 3: Dependency because creation

Here, the `PersonExample` class is dependent on the `Person` class, because it creates a `Person` object within its method. But there is no field variable in `PersonExample` that stores a reference to a `Person` object.

```java{5}
public class PersonExample
{
    public static void main(String[] args) 
    {
        Person person = new Person("Alice", 30);
        System.out.println(person);
    }
}
```

## Key Points About Dependency

1. **Temporary Interaction**: Objects interact only when needed for specific operations
2. **No Permanent Reference**: The dependent class doesn't store references to dependencies
3. **Method-Level Coupling**: Dependency is established through method parameters
4. **Independent Lifecycle**: Both objects can exist and be destroyed independently
5. **Loose Coupling**: Changes to one class have minimal impact on the other

## Dependency vs Other Relationships

- **Association**: Objects have a permanent reference to each other
- **Aggregation**: One object contains another as a part
- **Composition**: One object owns another as an essential component
- **Dependency**: Objects interact temporarily without permanent references

## When to show Dependency

When you design your own class diagrams, dependencies are not often shown. This is because you can quickly have so many dependencies, that the diagram becomes too crowded.

I recommend showing the dependency in diagrams, as in the three above examples:

1. When you have a class, `A`, that uses a class, `B`, in a method parameter.
2. When you have a class, `A`, that creates a class, `B`, within its method.
3. When you have a class, `A`, that calls a static method of class, `B`.
