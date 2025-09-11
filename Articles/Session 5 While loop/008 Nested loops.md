# Nested Loops

Nested loops are loops within loops. They are useful for iterating over multi-dimensional data structures, creating patterns, or performing repeated actions within a loop. You can nest any combination of loop types - `while` loops, `for` loops, or even mix different types together.

## How Nested Loops Work

When you nest loops, the inner loop runs completely for each iteration of the outer loop. This means the inner loop executes multiple times for every single execution of the outer loop.

### Basic Structures:

**Nested While Loops:**
```java
while (outerCondition) {
    // Outer loop code
    
    while (innerCondition) {
        // Inner loop code
    }
    
    // More outer loop code
}
```

**Nested For Loops:**
```java
for (int i = 0; i < outerLimit; i++) {
    // Outer loop code
    
    for (int j = 0; j < innerLimit; j++) {
        // Inner loop code
    }
    
    // More outer loop code
}
```

**Mixed Nested Loops:**
```java
for (int i = 0; i < limit; i++) {
    // Outer for loop code
    
    while (condition) {
        // Inner while loop code
    }
}
```

## Example 1: Printing a Grid

This example prints a 4x4 grid of `*` characters. Here are two implementations - one using nested `for` loops and another using nested `while` loops:

**Using Nested For Loops:**
```java
public class GridPrinterFor {
    public static void main(String[] args) {
        for (int row = 1; row <= 4; row++) {
            for (int col = 1; col <= 4; col++) {
                System.out.print("* ");
            }
            System.out.println(); // Move to next line after each row
        }
    }
}
```

**Using Nested While Loops:**
```java
public class GridPrinterWhile {
    public static void main(String[] args) {
        int row = 1;
        while (row <= 4) {
            int col = 1;
            while (col <= 4) {
                System.out.print("* ");
                col++;
            }
            System.out.println(); // Move to next line after each row
            row++;
        }
    }
}
```

### Output:
```
* * * * 
* * * * 
* * * * 
* * * * 
```

## Example 2: Multiplication Table

This example creates a multiplication table. Here are implementations using both nested loop types:

**Using Nested While Loops:**
```java
public class MultiplicationTableWhile {
    public static void main(String[] args) {
        int i = 1;
        while (i <= 5) {
            int j = 1;
            while (j <= 5) {
                System.out.print((i * j) + "\t");
                j++;
            }
            System.out.println(); // New line after each row
            i++;
        }
    }
}
```

**Using Nested For Loops:**
```java
public class MultiplicationTableFor {
    public static void main(String[] args) {
        for (int i = 1; i <= 5; i++) {
            for (int j = 1; j <= 5; j++) {
                System.out.print((i * j) + "\t");
            }
            System.out.println(); // New line after each row
        }
    }
}
```

### Output:
```
1	2	3	4	5	
2	4	6	8	10	
3	6	9	12	15	
4	8	12	16	20	
5	10	15	20	25	
```


## Important Notes

- Always ensure that loop conditions will eventually become `false` to avoid infinite loops
- For `while` loops, the counter variables should be reinitialized before each execution of the inner loop
- For `for` loops, the initialization happens automatically in each iteration
- Nested loops can significantly increase the time complexity of your program, meaning how long time it takes to run increases with the number of iterations in both loops
- Consider using `break` and `continue` statements carefully in nested loops, as they only affect the innermost loop containing them
- Choose the appropriate loop type based on your needs:
  - Use `for` loops when you know the exact number of iterations
  - Use `while` loops when the number of iterations depends on a condition
  - Mix loop types when it makes the code more readable and logical


# Exercises

## Exercise 1: Print a Number Pyramid

Write a Java program that uses nested loops to print a pyramid of numbers. The user should input the height of the pyramid. You can implement this using either nested `while` loops or nested `for` loops.

### Example Input:
```
Enter the height of the pyramid: 4
```

### Example Output:
```
1
12
123
1234
```

<hint title="Hint 1">

Use an outer loop to control the rows and an inner loop to print the numbers in each row. The inner loop should print numbers from 1 to the current row number. You can use either `for` or `while` loops.

</hint>

<hint title="Solution - Using While Loops">

```java
import java.util.Scanner;

public class NumberPyramidWhile {
    public static void main(String[] args) {
        Scanner scanner = new Scanner(System.in);
        System.out.print("Enter the height of the pyramid: ");
        int height = scanner.nextInt();
        
        int row = 1;
        while (row <= height) {
            int num = 1;
            while (num <= row) {
                System.out.print(num);
                num++;
            }
            System.out.println();
            row++;
        }
    }
}
```

Or with `for` loops:

```java
import java.util.Scanner;

public class NumberPyramidFor {
    public static void main(String[] args) {
        Scanner scanner = new Scanner(System.in);
        System.out.print("Enter the height of the pyramid: ");
        int height = scanner.nextInt();
        
        for (int row = 1; row <= height; row++) {
            for (int num = 1; num <= row; num++) {
                System.out.print(num);
            }
            System.out.println();
        }
    }
}
```

</hint>

## Exercise 2: Interactive Multiplication Table

Write a program that continuously asks the user for a number and then displays the multiplication table for that number (from 1 to 10). The program should stop when the user enters 0. You can use any combination of nested loops to implement this functionality.

### Example Input:
```
Enter a number (0 to stop): 3
Enter a number (0 to stop): 5
Enter a number (0 to stop): 0
```

### Example Output:
```
Multiplication table for 3:
3 x 1 = 3
3 x 2 = 6
3 x 3 = 9
3 x 4 = 12
3 x 5 = 15
3 x 6 = 18
3 x 7 = 21
3 x 8 = 24
3 x 9 = 27
3 x 10 = 30

Multiplication table for 5:
5 x 1 = 5
5 x 2 = 10
5 x 3 = 15
5 x 4 = 20
5 x 5 = 25
5 x 6 = 30
5 x 7 = 35
5 x 8 = 40
5 x 9 = 45
5 x 10 = 50

Goodbye!
```

<hint title="Hint 1">

Use an outer loop that continues until the user enters 0. Inside this loop, use an inner loop to print the multiplication table from 1 to 10 for the entered number. You can mix loop types - for example, use a `while` loop for user input and a `for` loop for the multiplication table.

</hint>

<hint title="Solution - Using While Loops">

```java
import java.util.Scanner;

public class InteractiveMultiplicationTableWhile {
    public static void main(String[] args) {
        Scanner scanner = new Scanner(System.in);
        int number;
        
        while (true) {
            System.out.print("Enter a number (0 to stop): ");
            number = scanner.nextInt();
            
            if (number == 0) {
                System.out.println("Goodbye!");
                break;
            }
            
            System.out.println("Multiplication table for " + number + ":");
            int multiplier = 1;
            while (multiplier <= 10) {
                System.out.println(number + " x " + multiplier + " = " + (number * multiplier));
                multiplier++;
            }
            System.out.println();
        }
    }
}
```

</hint>

<hint title="Solution - Mixed Loop Types">

```java
import java.util.Scanner;

public class InteractiveMultiplicationTableMixed {
    public static void main(String[] args) {
        Scanner scanner = new Scanner(System.in);
        int number;
        
        while (true) {
            System.out.print("Enter a number (0 to stop): ");
            number = scanner.nextInt();
            
            if (number == 0) {
                System.out.println("Goodbye!");
                break;
            }
            
            System.out.println("Multiplication table for " + number + ":");
            for (int multiplier = 1; multiplier <= 10; multiplier++) {
                System.out.println(number + " x " + multiplier + " = " + (number * multiplier));
            }
            System.out.println();
        }
    }
}
```

</hint>