# Exercise - Read 5 Numbers

Write a program that uses a `for` loop to read five numbers from the console and prints out their sum.

### Example Input:
```
Enter number 1: 3
Enter number 2: 5
Enter number 3: 7
Enter number 4: 2
Enter number 5: 8
```

### Example Output:
```
The sum is: 25
```

<hint title="Hint 1">

Use a `for` loop to iterate five times, reading a number during each iteration and adding it to a sum variable.

The `sum` variable should be initialized to zero _before_ the loop starts.

</hint>

<hint title="Solution">

```java
import java.util.Scanner;

public class SumOfFiveNumbers {
    public static void main(String[] args) {
        Scanner scanner = new Scanner(System.in);
        int sum = 0;

        for (int i = 1; i <= 5; i++) {
            System.out.print("Enter number " + i + ": ");
            int number = scanner.nextInt();
            sum += number;
        }

        System.out.println("The sum is: " + sum);
    }
}
```

</hint>

## Exercise 2: Calculate the Average
Create a new program, and use the previous exercise as a template. Modify the program so that instead of printing the sum, it calculates and prints the average of the numbers as a decimal number.

### Example Input:
```
Enter number 1: 3
Enter number 2: 5
Enter number 3: 7
Enter number 4: 2
Enter number 5: 8
```

### Example Output:
```
The average is: 5.0
```

<hint title="Hint 1">

 Use a `for` loop to iterate five times, reading a number during each iteration and adding it to a sum variable. Divide the sum by 5 to calculate the average.

</hint>

<hint title="Hint 2">

Make sure to use `5.0` or `5d` when dividing the sum to ensure that the result is a decimal number (double) instead of an integer.

</hint>

<hint title="Solution">

```java
import java.util.Scanner;

public class AverageOfFiveNumbers {
    public static void main(String[] args) {
        Scanner scanner = new Scanner(System.in);
        int sum = 0;

        for (int i = 1; i <= 5; i++) {
            System.out.print("Enter number " + i + ": ");
            int number = scanner.nextInt();
            sum += number;
        }

        double average = sum / 5.0;
        System.out.println("The average is: " + average);
    }
}
```

</hint>