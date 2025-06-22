# Exercise - Print a Triangle

## Task
Write a Java program that uses nested `for` loops to print a triangle of `*` characters. The triangle should have a height specified by the user.

### Example Input:
```
Enter the height of the triangle: 5
```

### Example Output:
```
*
**
***
****
*****
```

<hint title="Hint 1">

Use an outer loop to iterate through the rows and an inner loop to print the `*` characters for each row.

</hint>

<hint title="Hint 2">

The outer loop should run from 1 to the height specified by the user, and the inner loop should run from 1 to the current row number, given by the outer loop's index.

</hint>

<hint title="Solution">

```java
import java.util.Scanner;

public class TrianglePrinter {
    public static void main(String[] args) {
        Scanner scanner = new Scanner(System.in);
        System.out.print("Enter the height of the triangle: ");
        int height = scanner.nextInt();

        for (int i = 1; i <= height; i++) {
            for (int j = 1; j <= i; j++) {
                System.out.print("*");
            }
            System.out.println();
        }
    }
}
```

</hint>

## Exercise 2: Print a Custom Number of Lines
Expand on Exercise 1. Modify the program so that the user can input a number for the number of `*` lines to print out.

### Example Input:
```
Enter the number of lines: 3
```

### Example Output:
```
*
**
***
```

<hint title="Hint 1">

Use the same nested loop structure as Exercise 1, but prompt the user for the number of lines instead of the height.

</hint>

<hint title="Solution">

```java
import java.util.Scanner;

public class CustomLinesPrinter {
    public static void main(String[] args) {
        Scanner scanner = new Scanner(System.in);
        System.out.print("Enter the number of lines: ");
        int lines = scanner.nextInt();

        for (int i = 1; i <= lines; i++) {
            for (int j = 1; j <= i; j++) {
                System.out.print("*");
            }
            System.out.println();
        }
    }
}
```

</hint>