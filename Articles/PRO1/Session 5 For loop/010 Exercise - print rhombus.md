# Exercise - Print a Rhombus

Write a Java program that uses nested `for` loops to print a rhombus of `*` characters. The rhombus should have a height specified by the user.

### Example Input:
```
Enter the height of the rhombus: 5
```

### Example Output:
```
  *
 ***
*****
 ***
  *
```

<hint title="Hint 1">

Use two nested loops: one for the top half of the rhombus and one for the bottom half. Use spaces to align the `*` characters.

</hint>

<hint title="Solution">

```java
import java.util.Scanner;

public class RhombusPrinter {
    public static void main(String[] args) {
        
        Scanner scanner = new Scanner(System.in);
        System.out.print("Enter the height of the rhombus: ");
        int height = scanner.nextInt();

        // Top half
        for (int i = 1; i <= height; i++) {
            for (int j = height; j > i; j--) {
                System.out.print(" ");
            }
            for (int k = 1; k <= (2 * i - 1); k++) {
                System.out.print("*");
            }
            System.out.println();
        }

        // Bottom half
        for (int i = height - 1; i >= 1; i--) {
            for (int j = height; j > i; j--) {
                System.out.print(" ");
            }
            for (int k = 1; k <= (2 * i - 1); k++) {
                System.out.print("*");
            }
            System.out.println();
        }
    }
}
```

</hint>

## Exercise 2: Print a Custom Rhombus
Expand on Exercise 1. Modify the program so that the user can input the number of lines for the rhombus through the console. If the input number is even, print out an error message instead.

### Example Input:
```
Enter the number of lines: 4
```

### Example Output:
```
Error: The number of lines must be odd.
```

### Example Input:
```
Enter the number of lines: 5
```

### Example Output:
```
  *
 ***
*****
 ***
  *
```

<hint title="Hint 1">

Use an `if` statement to check if the input number is even before proceeding with the nested loops.

</hint>

<hint title="Solution">

```java
import java.util.Scanner;

public class CustomRhombusPrinter {
    public static void main(String[] args) {
        Scanner scanner = new Scanner(System.in);
        System.out.print("Enter the number of lines: ");
        int lines = scanner.nextInt();

        if (lines % 2 == 0) {
            System.out.println("Error: The number of lines must be odd.");
            return;
        }

        int height = lines / 2 + 1;

        // Top half
        for (int i = 1; i <= height; i++) {
            for (int j = height; j > i; j--) {
                System.out.print(" ");
            }
            for (int k = 1; k <= (2 * i - 1); k++) {
                System.out.print("*");
            }
            System.out.println();
        }

        // Bottom half
        for (int i = height - 1; i >= 1; i--) {
            for (int j = height; j > i; j--) {
                System.out.print(" ");
            }
            for (int k = 1; k <= (2 * i - 1); k++) {
                System.out.print("*");
            }
            System.out.println();
        }
    }
}
```

</hint>