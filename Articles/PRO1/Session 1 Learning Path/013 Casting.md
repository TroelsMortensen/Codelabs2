# Casting

Sometimes, you may need to convert a number from one type to another. This is called "casting." We have two types of casting in Java: up-casting and down-casting.

## Up-casting

For example, if you want to convert an `int` to a `double`, you can do it like this:

```java
int myInt = 5;
double myDouble = (double) myInt; // Cast int to double
```

The `(double)` before `myInt` is the cast operator. It converts the `int` value to a `double` type.

This tells the Java compiler to treat `myInt` as a `double`, assign that "double" value to the variable `myDouble`, allowing you to perform operations that require a floating-point number.

In the above example, we don't actually need the cast, as the conversion does not lose any information. 


### Exercise - Up-casting

Try copying the above code snippet into a main method, and print out the `myDouble` variable. You will see that it prints `5.0`, which is the `double` representation of the integer `5`.

Then remove the cast and run the code again. You will see that it still works without any issues, because Java automatically converts `int` to `double` when needed.
This is known as "implicit casting" or "automatic type conversion."

## Down-casting

However, if you were converting from a `double` to an `int`, you would lose the decimal part, and you would need to use casting. This is a way to tell the compiler, you are aware of the potential dangers, and that you accept loosing the decimal digits:

```java
double myDouble = 5.7;
int myInt = (int) myDouble; // Cast double to int, losing the decimal part
```

If you run this code, `myInt` will be `5`, as the decimal part is discarded during the conversion.

If you remove the cast, i.e. `(int)`, you will get a compiler errror, that red squiggly line again, indicating that you cannot assign a `double` to an `int` without explicitly casting it.

This is because converting from a larger type (like `double`) to a smaller type (like `int`) can potentially lose information, so Java requires you to explicitly state that you understand the risk of losing data.

Open each item for a short recap of the three conversion ideas.

<Quiz>
{
    "Type": "ExpandableDetails",
    "Details": [
        {
            "Header": "Up-casting",
            "Content": "<p>Converting a smaller type to a larger type, for example <code>int</code> to <code>double</code>. You can write <code>double myDouble = (double) myInt;</code>.</p>"
        },
        {
            "Header": "Implicit conversion",
            "Content": "<p>When no information is lost, Java can convert automatically. <code>double myDouble = myInt;</code> works without a cast, because <code>5</code> becomes <code>5.0</code>.</p>"
        },
        {
            "Header": "Down-casting",
            "Content": "<p>Converting a larger type to a smaller type, for example <code>double</code> to <code>int</code>. You must write an explicit cast, and the decimal part is discarded: <code>(int) 5.7</code> becomes <code>5</code>.</p>"
        }
    ]
}
</Quiz>

## Additional reading

You can read more about casting [here](https://www.w3schools.com/java/java_type_casting.asp)