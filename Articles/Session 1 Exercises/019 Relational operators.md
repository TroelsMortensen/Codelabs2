# Relational operators

Sometimes it is fine to check if two values are equal or not. And sometimes we want to check if one value is greater than or less than another value.\

In Java, we have relational operators for this purpose. These operators allow us to compare two values and determine their relationship.

You know these operators from mathematics, and they work similarly in Java. Here are the relational operators we have in Java:

- `>`: Greater than
- `<`: Less than
- `>=`: Greater than or equal to
- `<=`: Less than or equal to

Here are some examples of how to use these operators:

```java
int a = 5;
int b = 10;
boolean isAGreaterThanB = (a > b); // false, because 5 is not greater than 10
boolean isALessThanB = (a < b); // true, because 5 is less than 10
```

Again, parentheses are used for clarity, but they are not strictly necessary in this case.

You can use these operators on number types, such as `int`, `double`, and `float`. 

## Exercise - Can you vote?

Create a class with a main method. In the main method, declare three integer values:

* petersAge = 17;
* johnsAge = 18;
* marysAge = 19;

Then, write a program that checks if Peter, John, and Mary are old enough to vote. In many countries, the voting age is 18. Use the relational operators to check if each person is old enough to vote and print the result to the console.
