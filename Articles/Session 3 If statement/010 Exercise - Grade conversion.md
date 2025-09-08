# Exercise: Grade Conversion

Write a program that reads a grade from the Danish 7-scale from the keyboard (as an `int`) and prints the equivalent grade from the international grade scale. 

The Danish 7-scale grades are the following: `{12, 10, 7, 4, 2, 0, -3}` and the international grades are: `{A, B, C, D, E, Fx, F}`. 

### Conversion Table
| Danish Grade | International Grade |
|--------------|----------------------|
| 12           | A                    |
| 10           | B                    |
| 7            | C                    |
| 4            | D                    |
| 2            | E                    |
| 0            | Fx                   |
| -3           | F                    |

### Instructions
Test the program by running it multiple times and entering different values.

Remember to handle invalid input gracefully by printing an error message if the entered grade is not one of the valid Danish grades.

<hint title="Solution">

```java
import java.util.Scanner;

public class GradeConversion 
{
    public static void main(String[] args) 
    {
        Scanner scanner = new Scanner(System.in);

        System.out.print("Enter a Danish grade: ");
        int danishGrade = scanner.nextInt();

        if (danishGrade == 12) 
        {
            System.out.println("International grade: A");
        } 
        else if (danishGrade == 10) 
        {
            System.out.println("International grade: B");
        } 
        else if (danishGrade == 7) 
        {
            System.out.println("International grade: C");
        } 
        else if (danishGrade == 4) 
        {
            System.out.println("International grade: D");
        } 
        else if (danishGrade == 2) 
        {
            System.out.println("International grade: E");
        } 
        else if (danishGrade == 0) 
        {
            System.out.println("International grade: Fx");
        } 
        else if (danishGrade == -3) 
        {
            System.out.println("International grade: F");
        } 
        else {
            System.out.println("Error: Invalid Danish grade");
        }
    }
}
```


</hint>