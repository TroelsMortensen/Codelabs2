# If-Else

Sometimes you have two pieces of code, and you want to run only one of them based on a condition. This is where the `else` block comes in: execute either _this_ block of code or _that_ block of code, depending on whether a condition is true or false.

Watch the video below to learn how to use the `else` block in Java.

<video src="https://youtu.be/MFHkY9TNI18"></video>

# Exercises

### Exercise 1: Pass or Fail
Write a program that asks the user to enter their exam score. Use an if-else statement to print "You passed" if the score is 50 or higher, and "You failed" otherwise.

Example Output:
```
Enter your score:
45
You failed
```

```
Enter your score:
75
You passed
```

<hint title="Solution">

```java
import java.util.Scanner;

public class PassOrFail {
    public static void main(String[] args) {
        Scanner scanner = new Scanner(System.in);
        System.out.print("Enter your score: ");
        int score = scanner.nextInt();
        if (score >= 50) {
            System.out.println("You passed");
        } else {
            System.out.println("You failed");
        }
    }
}
```
</hint>

### Exercise 2: Odd or Even
Write a program that asks the user to enter a number. Use an if-else statement to print "The number is even" if the number is divisible by 2, and "The number is odd" otherwise.

Example Output:
```yaml
Enter a number:
7
The number is odd
```

```yaml
Enter a number:
8
The number is even
```

<hint title="Hint 1">

Remember, you can use the modulo operator (`%`) in Java to find the remainder when dividing two numbers. For example, `number % 2 == 0` checks if a number is even.

</hint>

<hint title="Solution">

```java
import java.util.Scanner;

public class OddOrEven {
    public static void main(String[] args) {
        Scanner scanner = new Scanner(System.in);
        System.out.print("Enter a number: ");
        int number = scanner.nextInt();
        if (number % 2 == 0) {
            System.out.println("The number is even");
        } else {
            System.out.println("The number is odd");
        }
    }
}
```
</hint>

### Exercise 3: Temperature Check
Write a program that asks the user to enter the current temperature. Use an if-else statement to print "It's warm outside" if the temperature is 20 degrees or higher, and "It's cold outside" otherwise.

Example Output:
```
Enter the temperature:
15
It's cold outside
```

```
Enter the temperature:
25
It's warm outside
```

<hint title="Solution">

```java
import java.util.Scanner;

public class TemperatureCheck {
    public static void main(String[] args) {
        Scanner scanner = new Scanner(System.in);
        System.out.print("Enter the temperature: ");
        int temperature = scanner.nextInt();
        if (temperature >= 20) {
            System.out.println("It's warm outside");
        } else {
            System.out.println("It's cold outside");
        }
    }
}
```
</hint>

All of the above exercises could be solved with two if-statements, rather than an if-else. So, what's the point?

You might have a case, where two if-statments might both be true, ending up executing both bodies. But you wanted to only execute one body, always.

Eventually, I will come up with a good code example here...