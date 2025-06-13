# Exercise - Grade Conversion

Write a program that converts a numerical grade to a letter grade using a switch statement. The program should ask the user to enter a numerical grade on the danish grading scale and print the corresponding letter grade.

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

Use the switch statement to print out the internaltional grade based on the Danish grade entered by the user.

### Example Output
```yaml
Enter a Danish grade:
12
International grade: A
```

<hint title="Solution">

```java
import java.util.Scanner;
public class GradeConversion {
    public static void main(String[] args) {
        Scanner scanner = new Scanner(System.in);

        System.out.print("Enter a Danish grade: ");
        int danishGrade = scanner.nextInt();

        switch (danishGrade) {
            case 12:
                System.out.println("International grade: A");
                break;
            case 10:
                System.out.println("International grade: B");
                break;
            case 7:
                System.out.println("International grade: C");
                break;
            case 4:
                System.out.println("International grade: D");
                break;
            case 2:
                System.out.println("International grade: E");
                break;
            case 0:
                System.out.println("International grade: Fx");
                break;
            case -3:
                System.out.println("International grade: F");
                break;
            default:
                System.out.println("Error: Invalid Danish grade");
        }
    }
}
```
