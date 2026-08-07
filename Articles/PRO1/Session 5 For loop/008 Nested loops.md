# Nested For-Loops

Nested `for` loops are loops within loops. They are useful for iterating over multi-dimensional data structures, like a matrix, or a 2d game board, or performing repeated actions within a loop.

## Explanation
When you nest a `for` loop, the inner loop runs completely for each iteration of the outer loop. This means the inner loop executes multiple times for every single execution of the outer loop.

### Example 1: Printing a Grid
This example prints a grid of `*` characters:

```java
public class GridPrinter {
    public static void main(String[] args) {
        for (int i = 1; i <= 5; i++) {
            for (int j = 1; j <= 5; j++) {
                System.out.print("* ");
            }
            System.out.println();
        }
    }
}
```

### Output:
```
* * * * *
* * * * *
* * * * *
* * * * *
* * * * *
```

### Example 2: Coordinate System
This example prints coordinates:

```java
public class CoordinateSystem {
    public static void main(String[] args) {
        for (int x = 0; x < 3; x++) {
            for (int y = 0; y < 3; y++) {
                System.out.println("(" + x + ", " + y + ")");
            }
        }
    }
}
```

### Output:
```
(0, 0)
(0, 1)
(0, 2)
(1, 0)
(1, 1)
(1, 2)
(2, 0)
(2, 1)
(2, 2)
```