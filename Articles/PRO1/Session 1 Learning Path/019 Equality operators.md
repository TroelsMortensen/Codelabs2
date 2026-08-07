# Equality operators

Continuing from the previous page, we will now explore equality operators in Java. These operators are used to compare two values and determine if they are equal or not.

## Equality Operators for simple types

We have two equality operators in Java:
- `==`: This operator checks if two values are equal.
- `!=`: This operator checks if two values are not equal.

Here are some examples of how to use these operators:

```java
int a = 5;
int b = 5;
int c = 10;
boolean isEqual = (a == b); // true, because 5 is equal to 5
boolean isEqualAgain = a == b; // true, because 5 is equal to 5
boolean isNotEqual = (a != c); // true, because 5 is not equal to 10
boolean isNotEqualAgain = a != c; // true, because 5 is not equal to 10
System.out.println("Is a equal to b? " + isEqual); // Prints true
System.out.println("Is a not equal to c? " + isNotEqual); // Prints true
```

In the above code:
- I declare three integer variables `a`, `b`, and `c`.
- I use the `==` operator to check if `a` is equal to `b`, which evaluates to `true`. Notice here that I surround the expression with parentheses to make it clear that I are performing a comparison, though, the parentheses are not strictly needed here. This comparison is then calculated, and the result is a boolean value (`true` or `false`). This boolean value is then assigned to the variable `isEqual`.
- In the next line, line 5, I do the same comparison without parentheses, which is also valid in Java. The result is still `true`, and it is assigned to `isEqualAgain`.
- I then use the `!=` operator to check if `a` is not equal to `c`, which evaluates to `true`. Again, I surround the expression with parentheses for clarity.
- Finally, I print the results to the console.

I can compare other simple types as well, such as `double`, `char`, and `boolean`:

```java
double x = 3.14;
double y = 3.14;
double z = 2.71;
boolean isDoubleEqual = (x == y); // true, because 3.14 is equal to 3.14
boolean isDoubleNotEqual = (x != z); // true, because 3.14 is not equal to 2.71
System.out.println("Is x equal to y? " + isDoubleEqual); // Prints true
System.out.println("Is x not equal to z? " + isDoubleNotEqual); // Prints true
```

