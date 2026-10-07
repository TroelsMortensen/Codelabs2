# Dependency in code

Dependency is implemented through:

- **Method parameters** that accept other objects, but do not store them in a field
- **Local variables** that create temporary references
- **Return values** from method calls
- **Static method calls** to other classes

## Example 1: Static method call

Below is a class `EmailValidator`, used to validate an email address.  
To keep it simple, we only check if the email contains an `@` and a `.`.

```java
public class EmailValidator
{
    public static boolean isValidEmail(String email)
    {
        return email != null && email.contains("@") && email.contains(".");
    }
}
```

And a class that uses it:

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
    }
}
```

`EmailExample` depends on `EmailValidator` because it calls the static `isValidEmail` method. There is no field storing a reference.

## Example 2: Method parameter

Here, `Calculator` depends on `Rectangle`. The `Rectangle` type appears in method parameters. `Calculator` must know about `Rectangle`, but it does not store a `Rectangle` in a field.

A `Rectangle` is passed in, used inside the method, and when the method finishes, the relationship is gone.

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

## Example 3: Local creation

Here `PersonExample` depends on `Person` because it creates a `Person` object inside a method. Again, no field stores the reference permanently.

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

## Example 4: Return value

A method can also create a dependency by returning another type:

```java
public class AddressFactory
{
    public Address createHomeAddress(String street, String city, String houseNumber)
    {
        return new Address(street, city, houseNumber);
    }
}
```

`AddressFactory` depends on `Address` because it creates and returns an `Address`. It does not keep a field reference to it.

## Key points

1. **Temporary interaction**: Objects interact only when needed
2. **No permanent reference**: No field stores the dependency
3. **Method-level coupling**: Established through parameters, locals, returns, or static calls
4. **Independent lifecycle**: Both objects can exist and be destroyed independently
