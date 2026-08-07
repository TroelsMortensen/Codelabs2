# Ternary Operator

The ternary operator in Java is a shorthand for a specific type of `if-else` statement: we can use it to evaluate a condition and return one of two values based on whether the condition is `true` or `false`.

It allows you to write conditional expressions in a more concise way. The syntax is:

```java
[Type] value = condition ? expression1 : expression2;
```

- **`Type`**: The data type of the variable being assigned, e.g. `int`, `String`, etc.
- **`value`**: The variable that will store the result of the expression.
- **`condition`**: A boolean expression that evaluates to `true` or `false`.
- **`expression1`**: The value returned if the condition is `true`.
- **`expression2`**: The value returned if the condition is `false`.

## Example 1: Checking Even or Odd

First, let's use the if-statement to check if a number is even or odd. Then, we will rewrite it using the ternary operator.

```java	
int number = 5;
String result;          // variable declaration, without assigning a value.
if (number % 2 == 0) 
{
    result = "Even";
} 
else 
{
    result = "Odd";
}
System.out.println("The number is " + result);
```

And now, let's use the ternary operator to achieve the same result:

```java
int number = 5;
String result = (number % 2 == 0) ? "Even" : "Odd";
System.out.println("The number is " + result);
```

### Output:
```
The number is Odd
```

## Example 2: Finding the Maximum of Two Numbers

Again, we start with an if-statement to find the maximum of two numbers:

```java
int a = 10;
int b = 20;
if (a > b) 
{
    System.out.println("The maximum is " + a);
} 
else 
{
    System.out.println("The maximum is " + b);
}
```

And now, let's use the ternary operator:

```java
int a = 10;
int b = 20;
int max = (a > b) ? a : b;
System.out.println("The maximum is " + max);
```

### Output:
```
The maximum is 20
```

# Exercises

### Exercise 1: Positive or Negative
Write a program that uses the ternary operator to check if a number is positive or negative. Print "Positive" if the number is greater than or equal to 0, otherwise print "Negative".

Example Output:
```
Enter a number:
-5
The number is Negative
```

<hint title="Solution">

```java
import java.util.Scanner;

public class PositiveOrNegative 
{
    public static void main(String[] args) 
    {
        Scanner scanner = new Scanner(System.in);
        System.out.print("Enter a number: ");
        int number = scanner.nextInt();
        String result = (number >= 0) ? "Positive" : "Negative";
        System.out.println("The number is " + result);
    }
}
```
</hint>

### Exercise 2: Minimum of Two Numbers
Write a program that uses the ternary operator to find the minimum of two numbers entered by the user.

Example Output:
```
Enter the first number:
10
Enter the second number:
5
The minimum is 5
```

<hint title="Solution">

```java
import java.util.Scanner;

public class MinimumOfTwoNumbers 
{
    public static void main(String[] args) 
    {
        Scanner scanner = new Scanner(System.in);
        System.out.print("Enter the first number: ");
        int num1 = scanner.nextInt();
        System.out.print("Enter the second number: ");
        int num2 = scanner.nextInt();
        int min = (num1 < num2) ? num1 : num2;
        System.out.println("The minimum is " + min);
    }
}
```
</hint>

### Exercise 3: Absolute Value
Write a program that uses the ternary operator to calculate the absolute value of a number entered by the user.

Example Output:
```
Enter a number:
-10
The absolute value is 10
```

<hint title="Solution">

```java
import java.util.Scanner;

public class AbsoluteValue 
{
    public static void main(String[] args) 
    {
        Scanner scanner = new Scanner(System.in);
        System.out.print("Enter a number: ");
        int number = scanner.nextInt();
        int absoluteValue = (number < 0) ? -number : number;
        System.out.println("The absolute value is " + absoluteValue);
    }
}
```
</hint>


### Exercise 4: Voting Eligibility
Write a program that uses the ternary operator to determine if a person is eligible to vote. A person is eligible to vote if their age is 18 or older.

Example Output:
```
Enter your age:
16
You are not eligible to vote
```