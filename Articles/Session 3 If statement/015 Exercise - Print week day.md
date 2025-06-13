# Exercise - Print Week Day

Write a program that asks the user to enter a number from 1 to 7. Based on the number, print the corresponding day of the week (1 for Monday, 2 for Tuesday, etc.). If the number is not in the range of 1 to 7, print "Invalid input".

Example Output:

```yaml
Enter a number (1-7):
1
Monday
```

Example Output:

```
Enter a number (1-7):
3
Wednesday
```

<hint title="Solution">

```java
import java.util.Scanner;
public class PrintWeekDay {
    public static void main(String[] args) {
        Scanner scanner = new Scanner(System.in);
        
        System.out.print("Enter a number (1-7): ");
        int dayNumber = scanner.nextInt();
        
        if (dayNumber == 1) {
            System.out.println("Monday");
        } else if (dayNumber == 2) {
            System.out.println("Tuesday");
        } else if (dayNumber == 3) {
            System.out.println("Wednesday");
        } else if (dayNumber == 4) {
            System.out.println("Thursday");
        } else if (dayNumber == 5) {
            System.out.println("Friday");
        } else if (dayNumber == 6) {
            System.out.println("Saturday");
        } else if (dayNumber == 7) {
            System.out.println("Sunday");
        } else {
            System.out.println("Invalid input");
        }
        
        scanner.close();
    }
}   
```