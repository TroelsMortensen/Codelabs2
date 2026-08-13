# Assertions

At this point you can actually write all your test cases, and manage validating the output yourself. However, it is a bit cumbersome to write all that code for each test case.

That's where the `Assert` class comes in. It contains helper methods, to validate _something_, and if that validation fails, it will throw an `AssertionFailure` exception.

## AssertionFailure exception

First, though, I have created a custom exception class, called `AssertionFailure`. It looks like this:

```java
public class AssertionFailure extends RuntimeException
{
    public AssertionFailure(String message)
    {
        super(message);
    }
}
```

Pretty simple. I could have just used the `RuntimeException` class, but I wanted to make it clear, that this is a custom exception, supposed to be used within this testing setup.

## Assert class

I have created the bare bones of the `Assert` class, with the following methods. You are of course free to add more methods, if you think they are relevant.

```java
public class Assert
{
    public static void isEqual(Object a, Object b)
    {
        if (!Objects.equals(a, b))
        {
            throw new AssertionFailure("Objects are not equal");
        }
    }

    public static void isEqual(int a, int b)
    {
        if(a != b)
        {
            throw new AssertionFailure(a + " != " + b);
        }
    }

    public static void isTrue(boolean b)
    {
        if(!b)
        {
            throw new AssertionFailure("The boolean expression was false");
        }
    }

    public static void isFalse(boolean b, String message)
    {
        if(!b)
        {
            throw new AssertionFailure("The boolean expression was true");
        }
    }
}
```

This class contains only static helper methods. Some methods are overloaded, to support different types, for example the `isEqual` method is overloaded to support `Object` and `int` types. I should create more overloads for the other simple types. You can do that yourself.

When comparing float or double values, a recommended approach is actually to use a small epsilon value, to check if the difference is within a certain tolerance. That's because of the way floating point arithmetic works. So:

```java
public static void isEqualTo(float a, float b, float epsilon)
{
    if(Math.abs(a - b) > epsilon)
    {
        throw new AssertionFailure(a + " != " + b);
    }
}
```

There are methods to assert that a boolean expression is true or false.

This approach is common in testing frameworks, and _must_ be used when using such frameworks. In our case here, it's merely convenient.

Other common assert methods are:

- `isNotNull(Object o)`: Asserts that the object is not null.
- `isNull(Object o)`: Asserts that the object is null.
- `isInstanceOf(Class<?> clazz, Object o)`: Asserts that the object is an instance of the given class.
- `isEmpty(String s)`: Asserts that the string is empty.
- `isNotEmpty(String s)`: Asserts that the string is not empty.
- `isEmpty(List<?> c)`: Asserts that the list is empty.
- `isNotEmpty(List<?> c)`: Asserts that the list is not empty.

Feel free to add more methods, if you think they are relevant.

## Using the Assert class

The way we use this, is in the test case methods. Generally, the method we wish to test either
- returns a value, which we can check. Given certain input, the expected output can be verified 
- returns nothing in case of success
- throws an exception in case of failure.

For the first case, we can use the `isEqual` method to verify the output.\
For the second case, we may not need to do anything.\
For the third case
- we can catch the exception (if it should be thrown in this case)
- or we can leave out the catch block, if the exception is not expected to be thrown 

Here is an example of how to use the Assert class:

```java
public class MyMath {
    public static int add(int a, int b)
    {
        return a + b;
    }
}

// -----

public class MethodsToTest {
    public static void testAdd()
    {
        int result = MyMath.add(1, 2);
        Assert.isEqual(result, 3);
    }
}
```