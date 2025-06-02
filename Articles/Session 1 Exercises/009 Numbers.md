# Numbers

Most programming languages, including Java, have a set of built-in data types that allow you to work with numbers. These data types can be broadly categorized into two types: **integer** and **floating-point** numbers.


## Whole Numbers

There is category of whole numbers, with three types.

These numbers are whole numbers without any decimal points, e.g., 1, 42, -100, etc. In Java, whole numbers can be represented using the following data types:
- `int`: This is the most commonly used data type for whole numbers. It can store values ranging from -2,147,483,648 to 2,147,483,647.
- `long`: This data type is used for larger whole numbers. It can store values ranging from -9,223,372,036,854,775,808 to 9,223,372,036,854,775,807.
- `short`: This data type is used for smaller whole numbers. It can store values ranging from -32,768 to 32,767.

## Floating-Point Numbers

Floating-point numbers are numbers that can have decimal points, e.g., 3.14, -0.001, etc. In Java, floating-point numbers can be represented using the following data types:
- `double`: This is the most commonly used data type for floating-point numbers. It can store values with a high degree of precision, typically up to 15 decimal places.
- `float`: This data type is used for single-precision floating-point numbers. It can store values with a lower degree of precision, typically up to 7 decimal places.\
  If you use too many decimal places, you may get an error or unexpected results.


## Arithmetic Operations

You can perform standard arithmetic operations on numbers in Java, such as addition, subtraction, multiplication, and division. Here are the basic arithmetic operators:

| Operator | Description                | Example          |
|----------|----------------------------|------------------|
| `+`      | Addition                   | `5 + 3` results in `8` |
| `-`      | Subtraction                | `5 - 3` results in `2` |
| `*`      | Multiplication             | `5 * 3` results in `15` |
| `/`      | Division                   | `5 / 2` results in `2` (integer division) |
| `%`      | Modulus (remainder)        | `5 % 2` results in `1` |


Here is an example of how to use these operators in Java:

```java
public class ArithmeticExample {
    public static void main(String[] args) {
        int a = 5;
        int b = 3;

        int sum = a + b; // 8
        System.out.println("Sum: " + sum);

        int difference = a - b; // 2
        System.out.println("Difference: " + difference);

        int product = a * b; // 15
        System.out.println("Product: " + product);

        int quotient = a / b; // 1 (integer division)
        System.out.println("Quotient: " + quotient);

        int remainder = a % b; // 2
        System.out.println("Remainder: " + remainder);
    }
}
```

When you run this code, it will perform the arithmetic operations and print the results to the console.

## Exercise - Arithmetic Example

Create a new class called `ArithmeticExample`. Copy the code above into the class and run it.

## Exercise - Mixing Numbers
Create a new class called `MixingNumbers`. In this class, declare two variables: one of type `int` and another of type `double`. Assign them values of your choice. Then, perform the following operations:
1. Add the two numbers together and print the result.