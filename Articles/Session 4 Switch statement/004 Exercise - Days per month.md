# Exercise - Days per month

Write a program that takes a month either as a number (1-12), and prints the number of days in that month. In case of February, just print 28, we ignore leap year.

You don't have to read from the console, you can instead create a helper method, and call it with different months from the main method.

Example Output:

```yaml
Enter a month (1-12): 2
28 days
```

```yaml
Enter a month (1-12): 4
30 days
```

<hint title="Hint 1">

Remember, you can use the fall-through feature of the switch statement to handle multiple cases that have the same output.

</hint>

<hint title="Solution">

```java
import java.util.Scanner;

public class DaysInMonth 
{
    public static void main(String[] args) 
    {
        Scanner scanner = new Scanner(System.in);
        
        System.out.print("Enter a month (1-12): ");
        int month = scanner.nextInt();

        printDaysInMonth(month);

    }

    static void printDaysInMonth(int month) 
    {
        switch (month) 
        {
            case 1: // January
            case 3: // March
            case 5: // May
            case 7: // July
            case 8: // August
            case 10: // October
            case 12: // December
                System.out.println("31 days");
                break;
            case 4: // April
            case 6: // June
            case 9: // September
            case 11: // November
                System.out.println("30 days");
                break;
            case 2: // February
                System.out.println("28 days");
                break;
            default:
                System.out.println("Invalid month");
        }
    }
}
```

</hint>


## Extra

Extend the above exercise to also request a year, and if the month is February, print 29 days if the year is a leap year.