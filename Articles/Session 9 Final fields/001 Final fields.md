# Final Fields and Immutability

So far, you have defined _variables_, with values, which can _vary_. For example, the following code is just fine:

```java
int x = 7;
x = 9;
```

You declare a variable, `x`, assign it a value of `7`, and on the second line, `x` is reassigned to another value, `9`. Here we can _mutate_ the variable.

When a variable is _immutable_, it means the value of the variable is assigned once, and cannot be changed afterwards. Some programming langauges use this a lot. Java, less so. But some times, it makes sense.

Making field variables immutable in Java is done with the `final` keyword. A `final` field can be assigned only once (typically in a constructor or at declaration) and then never changed.

```java
public class Example
{
    private final int number;

    public Example(int number)
    {
        this.number = number;
    }
}
```
In the above, the `number` field gets its value upon creation of an `Example` instance. The value can then never be changed again.

Alternatively, the field variable can get a value at the declaration. Like this:

```java
public class MathStuff
{
    private final int PI = 3.141509;
}
```


## How to make fields immutable

- Declare fields with `final` and assign a value either:
  - at the point of declaration, or
  - in every constructor.


## How to handle “mutations” instead

With immutable objects, you do not change existing instances; you create new ones with the desired differences.

Patterns:
- "With" methods that return new instances:

```java
public final class Rectangle {
    private final int width;
    private final int height;

    public Rectangle(int width, int height) {
        this.width = width;
        this.height = height;
    } 

    // Copy constructor, makes a of the other rectangle
    public Rectangle(Rectangle other) {
        this.width = other.width;
        this.height = other.height;
    }

    public Rectangle withWidth(int newWidth) {
        return new Rectangle(newWidth, this.height);
    }

    public Rectangle withHeight(int newHeight) {
        return new Rectangle(this.width, newHeight);
    }

    public int getWidth() { return width; }
    public int getHeight() { return height; }
}
```


