# Exercises - Training the For-Loop

This file contains four exercises designed to help you practice using `for` loops in Java.

## Exercise 1: Sum of Numbers from 0 to Input
Write a Java program where the user inputs a number through the console, and the program calculates and prints the sum of all numbers from 0 to the input.

### Example Input:
```
Enter a number: 5
```

### Example Output:
```
The sum is: 15
```

<hint title="Hint 1">

Use a `for` loop to iterate from 0 to the input number, accumulating the sum in a variable.

</hint>

<hint title="Solution">

```java
import java.util.Scanner;

public class SumCalculator {

    public static void main(String[] args) {
        Scanner scanner = new Scanner(System.in);
        
        System.out.print("Enter a number: ");
        int input = scanner.nextInt();

        int sum = 0;
        for (int i = 0; i <= input; i++) {
            sum += i;
        }

        System.out.println("The sum is: " + sum);
    }
}
```

</hint>

## Exercise 2: Sum with Expanded Output
Expand on Exercise 1. Modify the program so that the output includes the numbers being summed, formatted as "The sum is (1+2+3+4+5): 15".

### Example Input:
```yaml
Enter a number: 5
```

### Example Output:
```yaml
The sum is (1+2+3+4+5): 15
```


<hint title="Solution">

```java
import java.util.Scanner;

public class SumWithDetails {

    public static void main(String[] args) {
        Scanner scanner = new Scanner(System.in);
        System.out.print("Enter a number: ");
        
        int input = scanner.nextInt();

        int sum = 0;
        String details = "(";

        for (int i = 1; i <= input; i++) {
            sum += i;
            details += i;
            if (i < input) {
                details += "+";
            }
        }
        details += "): ";

        System.out.println("The sum is " + details + sum);
    }
}

```

</hint>

## Exercise 3: Print Numbers with Conditions
Write a Java program that uses a `for` loop to print numbers from 1 to 15. If the number is divisible by 3, print "Fizz" instead of the number. If the number is divisible by 5, print "Buzz" instead of the number. If the number is divisible by both, print "FizzBuzz".

### Example Output:
```
1
2
Fizz
4
Buzz
Fizz
7
8
Fizz
Buzz
11
Fizz
13
14
FizzBuzz
```

<hint title="Hint">

Use the modulo operator, `%`, to check divisibility by 3 and 5, and print the appropriate string.

</hint>


## Exercise 4: Print even numbers

Write a program which reads a number from the console, and prints all even numbers from 0 to that number (inclusive).

### Example Input:
```
Enter a number: 10
```

### Example Output:
```
0
2
4
6
8
10
```

<hint title="Solution">

```java
import java.util.Scanner;

public class EvenNumberPrinter {

    public static void main(String[] args) {
        Scanner scanner = new Scanner(System.in);
        System.out.print("Enter a number: ");
        int input = scanner.nextInt();

        for (int i = 0; i <= input; i += 2) {
            System.out.println(i);
        }
    }
}
```

Alternative solution, using modulo operator:

```java
import java.util.Scanner;

public class EvenNumberPrinter {

    public static void main(String[] args) {
        Scanner scanner = new Scanner(System.in);
        System.out.print("Enter a number: ");
        int input = scanner.nextInt();

        for (int i = 0; i <= input; i++) {
            if (i % 2 == 0) {
                System.out.println(i);
            }
        }
    }
}
```
</hint>

## Exercise 5: Print both even and odd numbers

Write a program which reads a number from the console, and prints out all numbers from 0 to that number (inclusive). For each number, print "even" if the number is even, and "odd" if the number is odd.

### Example Input:
```
Enter a number: 5
```
### Example Output:
```
0 is even
1 is odd
2 is even
3 is odd
4 is even
5 is odd
```