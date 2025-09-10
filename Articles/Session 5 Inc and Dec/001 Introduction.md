# Incrementing and Decrementing

In programming you will often need to increase or decrease a number value by one. This is called incrementing (one up) or decrementing (one down).

Here is how, you might do this in Java:

```java
int number = 5;
number = number + 1; // Incrementing, number becomes 6
number = number - 1; // Decrementing, number becomes 5
```

## Incrementing and Decrementing Operators
Java provides special operators for incrementing and decrementing values:

```java
int number = 5;
number++; // Incrementing, number becomes 6
number--; // Decrementing, number becomes 5
```

These operators are shorthand for adding or subtracting one from a variable. The two above examples do the same thing. The latter is just shorter and easier to read.

## Operation and Assignment

The above increment and decrement examples are an operation _and_ assignment in one statement.


There are other mathematical operations that can be done in a similar way, such as adding or subtracting a number other than one. Here is how you can do that:

```java
int number = 5;
number += 2; // Incrementing by 2, number becomes 7
number -= 2; // Decrementing by 2, number becomes 5
```

And we can do multiplication and division in a similar way:

```java
int number = 5;
number *= 2; // Multiplying by 2, number becomes 10
number /= 2; // Dividing by 2, number becomes 5
```
