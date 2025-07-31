# Multi-Dimensional Arrays in Java

So far, we've worked with one-dimensional arrays - arrays that store elements in a single row. However, Java also supports multi-dimensional arrays, which are essentially "arrays of arrays." The most common type is the two-dimensional array, which can be visualized as a table with rows and columns.

## What are Multi-Dimensional Arrays?

A multi-dimensional array is an array that contains other arrays as its elements. Think of it like a grid or table:

- **1D Array**: A single row of elements `[1, 2, 3, 4, 5]`
- **2D Array**: A table with rows and columns:
  ```
  [1, 2, 3]
  [4, 5, 6]
  [7, 8, 9]
  ```

## Two-Dimensional Arrays

### Declaration and Initialization

There are several ways to create 2D arrays in Java:

#### Method 1: Declaration with Size
```java
// Create a 2D array with 3 rows and 4 columns
int[][] matrix = new int[3][4];
```

#### Method 2: Array Literal Syntax
```java
// Create and initialize a 2D array with values
int[][] numbers = {
    {1, 2, 3},
    {4, 5, 6},
    {7, 8, 9}
};
```

#### Method 3: Step-by-Step Creation
```java
// Create the outer array first
int[][] matrix = new int[3][];

// Then create each inner array
matrix[0] = new int[]{1, 2, 3};
matrix[1] = new int[]{4, 5, 6};
matrix[2] = new int[]{7, 8, 9};
```

### Accessing Elements

To access elements in a 2D array, you need two indices: `[row][column]`

```java
int[][] numbers = {
    {10, 20, 30},
    {40, 50, 60},
    {70, 80, 90}
};

// Access specific elements
System.out.println(numbers[0][0]); // Output: 10 (first row, first column)
System.out.println(numbers[1][2]); // Output: 60 (second row, third column)
System.out.println(numbers[2][1]); // Output: 80 (third row, second column)

// Modify elements
numbers[0][1] = 25;
System.out.println(numbers[0][1]); // Output: 25
```

### Understanding Array Structure

```java
int[][] matrix = {
    {1, 2, 3, 4},
    {5, 6, 7, 8},
    {9, 10, 11, 12}
};

// Get number of rows
int rows = matrix.length;           // 3
// Get number of columns in first row
int columns = matrix[0].length;     // 4

System.out.println("Rows: " + rows);
System.out.println("Columns: " + columns);
```

## Iterating Through 2D Arrays

### Using Nested For Loops
```java
int[][] matrix = {
    {1, 2, 3},
    {4, 5, 6},
    {7, 8, 9}
};

// Print all elements
System.out.println("Matrix contents:");
for (int row = 0; row < matrix.length; row++) {
    for (int col = 0; col < matrix[row].length; col++) {
        System.out.print(matrix[row][col] + " ");
    }
    System.out.println(); // New line after each row
}
```

**Output:**
```
Matrix contents:
1 2 3 
4 5 6 
7 8 9 
```

### Using Enhanced For Loops
```java
int[][] matrix = {
    {1, 2, 3},
    {4, 5, 6},
    {7, 8, 9}
};

// Print all elements using enhanced for loops
System.out.println("Matrix contents:");
for (int[] row : matrix) {
    for (int element : row) {
        System.out.print(element + " ");
    }
    System.out.println();
}
```

## Practical Examples

### Example 1: Student Grades Table
```java
public class StudentGrades {
    public static void main(String[] args) {
        // Grades for 4 students across 3 subjects
        int[][] grades = {
            {85, 92, 78},  // Student 1: Math, Science, English
            {90, 88, 95},  // Student 2: Math, Science, English
            {76, 84, 89},  // Student 3: Math, Science, English
            {95, 91, 87}   // Student 4: Math, Science, English
        };
        
        String[] subjects = {"Math", "Science", "English"};
        
        // Print grades table
        System.out.println("Student Grades:");
        System.out.println("Student\tMath\tScience\tEnglish");
        
        for (int student = 0; student < grades.length; student++) {
            System.out.print("Student " + (student + 1) + "\t");
            for (int subject = 0; subject < grades[student].length; subject++) {
                System.out.print(grades[student][subject] + "\t");
            }
            System.out.println();
        }
    }
}
```

**Output:**
```
Student Grades:
Student	Math	Science	English
Student 1	85	92	78
Student 2	90	88	95
Student 3	76	84	89
Student 4	95	91	87
```

### Example 2: Tic-Tac-Toe Board
```java
public class TicTacToe {
    public static void main(String[] args) {
        // Create a 3x3 tic-tac-toe board
        char[][] board = {
            {'X', 'O', 'X'},
            {'O', 'X', 'O'},
            {'X', ' ', 'O'}
        };
        
        // Display the board
        System.out.println("Tic-Tac-Toe Board:");
        for (int row = 0; row < board.length; row++) {
            for (int col = 0; col < board[row].length; col++) {
                System.out.print(board[row][col]);
                if (col < board[row].length - 1) {
                    System.out.print(" | ");
                }
            }
            System.out.println();
            if (row < board.length - 1) {
                System.out.println("---------");
            }
        }
    }
}
```

**Output:**
```
Tic-Tac-Toe Board:
X | O | X
---------
O | X | O
---------
X |   | O
```

## Common Operations on 2D Arrays

### Finding Sum of All Elements
```java
int[][] matrix = {
    {1, 2, 3},
    {4, 5, 6},
    {7, 8, 9}
};

int sum = 0;
for (int row = 0; row < matrix.length; row++) {
    for (int col = 0; col < matrix[row].length; col++) {
        sum += matrix[row][col];
    }
}

System.out.println("Sum of all elements: " + sum); // Output: 45
```

### Finding Maximum Element
```java
int[][] matrix = {
    {15, 23, 8},
    {42, 7, 19},
    {31, 56, 12}
};

int max = matrix[0][0]; // Start with first element
for (int row = 0; row < matrix.length; row++) {
    for (int col = 0; col < matrix[row].length; col++) {
        if (matrix[row][col] > max) {
            max = matrix[row][col];
        }
    }
}

System.out.println("Maximum element: " + max); // Output: 56
```



## Three-Dimensional Arrays and Beyond

Java supports arrays with more than two dimensions:

```java
// 3D array: [depth][rows][columns]
int[][][] cube = new int[2][3][4];

// Initialize some values
cube[0][0][0] = 1;
cube[1][2][3] = 100;

// Access elements
System.out.println(cube[0][0][0]); // Output: 1
System.out.println(cube[1][2][3]); // Output: 100
```

## Important Notes

1. **Memory Layout**: 2D arrays in Java are actually arrays of arrays, not a single block of memory like in some other languages.

2. **Different Row Lengths**: Each row in a 2D array can have a different length (jagged arrays).

3. **Null Pointer Safety**: Always check that inner arrays are not null before accessing them.

4. **Performance**: Accessing elements in multi-dimensional arrays requires multiple pointer dereferences, which can be slower than 1D arrays.

## Common Use Cases

- **Game Boards**: Chess, checkers, tic-tac-toe
- **Image Processing**: Pixels in a 2D grid
- **Mathematical Matrices**: Linear algebra operations
- **Spreadsheets**: Rows and columns of data
- **Geographic Data**: Maps with coordinates
- **Scientific Simulations**: 2D or 3D grids for modeling

Multi-dimensional arrays are powerful tools for organizing data that naturally fits into a grid or table structure. They provide an intuitive way to work with data that has multiple dimensions while maintaining the type safety and performance characteristics of Java arrays.