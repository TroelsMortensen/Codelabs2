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

| Operator | Description         | Example                                   |
| -------- | ------------------- | ----------------------------------------- |
| `+`      | Addition            | `5 + 3` results in `8`                    |
| `-`      | Subtraction         | `5 - 3` results in `2`                    |
| `*`      | Multiplication      | `5 * 3` results in `15`                   |
| `/`      | Division            | `5 / 2` results in `2` (integer division) |
| `%`      | Modulus (remainder) | `5 % 2` results in `1`                    |


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

## Exercises

### Exercise - Arithmetic Example

Create a new class called `ArithmeticExample`. Copy the code above into the class and run it.

Verify the output.

### Exercise - Sum

Create a new class called `SumExample`. In this class, write a program that calculates the sum of three numbers, just use integers. 

Declare three integer variables, assign them values, and print out the sum of these three numbers.

<hint title="Solution">

```java
public class SumExample {
    public static void main(String[] args) {
        int num1 = 5;
        int num2 = 10;
        int num3 = 15;

        int sum = num1 + num2 + num3;
        System.out.println("Sum: " + sum);
    }
}
```

<video src="https://youtu.be/a9EgfSzj-ag"></video>

</hint>

### Exercise - Integer division

Division in Java can be tricky, especially when dealing with integers. It behaves perhaps not as expected.

Create a new class called `IntegerDivisionExample`. In this class' main method define two integer variables, `x` and `y`, and assign them values:

x = 10;\
y = 3;

Then, perform the division `x / y` and print the result.

What is the output? Why is it not what you expected?

<hint title="Integer Division">

In Java, when you divide two integers, the result is also an integer. The decimal part is discarded (not rounded). This is known as integer division.

So, `10 / 3` results in `3`, not `3.333...`.
</hint>

<hint title="Solution">

```java
public class IntegerDivisionExample {
    public static void main(String[] args) {
        int x = 10;
        int y = 3;

        int result = x / y;
        System.out.println("Result: " + result);
    }
}
```

<video src="https://youtu.be/zU5EOl50_5w"></video>

</hint>

### Exercise - Sales tax

Create a new class called `SalesTaxExample`. In this class, write a main method which declares two integers with values 19 and 89.

In Denmark the sales tax is 25%. Calculate the sales tax for these two integers and print the result.

<hint title="Hint">

25% of a number can be calculated by multiplying the number by 0.25.

</hint>

<hint title="Solution">

```java
public class SalesTaxExample {
    public static void main(String[] args) {
        int price1 = 19;
        int price2 = 89;

        double salesTaxRate = 0.25; // 25%

        double salesTax1 = price1 * salesTaxRate;
        double salesTax2 = price2 * salesTaxRate;

        System.out.println("Sales tax for " + price1 + " is: " + salesTax1);
        System.out.println("Sales tax for " + price2 + " is: " + salesTax2);
    }
}
```
</hint>

### Exercise - Math expressions

Inspect the following code snippet:

```java
public static void main(String[] args)
{
    System.out.println(23 * 4.5 / 0.5 + 1);
    System.out.println(23 * 4.5 / (0.5 + 1));
    System.out.println(2 + 5 - 18 + 11);
    System.out.println((2 + 5) - (18 + 11));
    System.out.println(14 * 18 / 4 + 4);
    System.out.println(14 * 18 / (4 + 4));
}
```

Parentheses can change the order of operations in mathematical expressions, this concept should be familiar.

What do you think the output will be? Try to predict the output before running the code.

Then, run the code and verify your predictions.

### Exercise - overflow

Inspect the following code snippet:

```java
public static void main(String[] args)
{
    int maxValue = Integer.MAX_VALUE;
    System.out.println(++maxValue);
}
```

Remember the maximum value of an `int` in Java is 2,147,483,647.\
What do you think will happen when you run this code? Try to predict the output before running it.

Then, run the code and verify your predictions.

Why do you think this happens?

<hint title="Hint">

When you increment the maximum value of an `int`, it wraps around to the minimum value of an `int`, which is -2,147,483,648.

This is known as **integer overflow**. When a value exceeds the maximum limit of its data type, it wraps around to the minimum limit.

</hint>

## Additional reading

You can read more about arithmetic operations in Java [here](https://www.w3schools.com/java/java_operators.asp).