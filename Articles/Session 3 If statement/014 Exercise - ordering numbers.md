# Exercises

Write a program that asks the user to input three numbers. Print out the numbers from smallest to largest, using (many) if statements.

Example Output:
```yaml
Enter first number:
5
Enter second number:
3
Enter third number:
8   
The numbers in ascending order are: 3, 5, 8
```

<hint title="Solution">

```java
import java.util.Scanner;

public class SortThreeNumbers {

    public static void main(String[] args) {
        Scanner scanner = new Scanner(System.in);

        System.out.print("Enter first number: ");
        int num1 = scanner.nextInt();
        System.out.print("Enter second number: ");
        int num2 = scanner.nextInt();
        System.out.print("Enter third number: ");
        int num3 = scanner.nextInt();

        int smallest, middle, largest;

        if (num1 <= num2 && num1 <= num3) {
            smallest = num1;
            if (num2 <= num3) {
                middle = num2;
                largest = num3;
            } else {
                middle = num3;
                largest = num2;
            }
        } else if (num2 <= num1 && num2 <= num3) {
            smallest = num2;
            if (num1 <= num3) {
                middle = num1;
                largest = num3;
            } else {
                middle = num3;
                largest = num1;
            }
        } else {
            smallest = num3;
            if (num1 <= num2) {
                middle = num1;
                largest = num2;
            } else {
                middle = num2;
                largest = num1;
            }
        }

        System.out.println("The numbers in ascending order are: " + smallest + ", " + middle + ", " + largest);
        
        scanner.close();
    }
}
```