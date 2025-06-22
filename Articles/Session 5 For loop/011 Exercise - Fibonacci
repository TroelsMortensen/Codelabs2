# Exercise - Fibonacci Sequence

The Fibonacci sequence is a series of numbers where each number is the sum of the two preceding ones, starting from 0 and 1. The sequence goes as follows:
```
0, 1, 1, 2, 3, 5, 8, 13, 21, 34, ...
```
For example:
- The 3rd number is `1 + 1 = 2`
- The 4th number is `1 + 2 = 3`
- The 5th number is `2 + 3 = 5`
- The 6th number is `3 + 5 = 8`
- The 7th number is `5 + 8 = 13`
- The 8th number is `8 + 13 = 21`

## Task
Write a Java program that asks the user to input a number and prints all Fibonacci numbers up to that number.

### Example Input:
```
Enter a number: 10
```

### Example Output:
```
0
1
1
2
3
5
8
```

<hint title="Hint 1">

Use a loop to calculate Fibonacci numbers, keeping track of the last two numbers in the sequence.

</hint>

<hint title="Solution">

```java
import java.util.Scanner;

public class FibonacciPrinter {
    public static void main(String[] args) {
        Scanner scanner = new Scanner(System.in);
        System.out.print("Enter a number: ");
        int limit = scanner.nextInt();

        int a = 0, b = 1;
        System.out.println(a);
        if (limit >= 1) {
            System.out.println(b);
        }

        for (int next = a + b; next <= limit; next = a + b) {
            System.out.println(next);
            a = b;
            b = next;
        }
    }
}
```

</hint>