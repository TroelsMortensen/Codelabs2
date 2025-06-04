# Casting

Sometimes, you may need to convert a number from one type to another. This is called "casting." We have two types of casting in Java: up-casting and down-casting.

## Up-casting

For example, if you want to convert an `int` to a `double`, you can do it like this:

```java
int myInt = 5;
double myDouble = (double) myInt; // Cast int to double
```

The `(double)` before `myInt` is the cast operator. It converts the `int` value to a `double` type.

This tells the Java compiler to treat `myInt` as a `double`, allowing you to perform operations that require a floating-point number.

In the above example, we don't actually need the cast, as the conversion does not lose any information. 

### Exercise - Up-casting

Try copying the above code snippet into a main method, and print out the `myDouble` variable. You will see that it prints `5.0`, which is the `double` representation of the integer `5`.

Then remove the cast and run the code again. You will see that it still works without any issues, because Java automatically converts `int` to `double` when needed.
This is known as "implicit casting" or "automatic type conversion."

## Down-casting

However, if you were converting from a `double` to an `int`, you would lose the decimal part, and you would need to use casting:

```java
double myDouble = 5.7;
int myInt = (int) myDouble; // Cast double to int, losing the decimal part
```

If you run this code, `myInt` will be `5`, as the decimal part is discarded during the conversion.

If you remove the cast, i.e. `(int)`, you will get a compiler errror, that red squiggly line again, indicating that you cannot assign a `double` to an `int` without explicitly casting it.

This is because converting from a larger type (like `double`) to a smaller type (like `int`) can potentially lose information, so Java requires you to explicitly state that you understand the risk of losing data.

## Additional reading

You can read more about casting [here](https://www.w3schools.com/java/java_type_casting.asp)