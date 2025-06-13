# Exercise: Age and Description

Write a program that reads an age (`int`) from the keyboard and then prints a message. The message should depend on the typed value in the following way:

- **If the age is less than 0**, display the message: `Error in age value`.
- **If the age is between 0 and 12** (both included), display the message: `Child`.
- **If the age is between 13 and 19** (both included), display the message: `Teenager`.
- **If the age is between 20 and 65** (both included), display the message: `Adult`.
- **If the age is larger than 65**, display the message: `Senior citizen`.

### Instructions
Test the program by running it at least 5 times to ensure that it prints the correct message for each age group.

<hint title="Solution">

```java
import java.util.Scanner;

public class AgeDescription {
    public static void main(String[] args) {
        Scanner scanner = new Scanner(System.in);

        System.out.print("Enter your age: ");
        int age = scanner.nextInt();

        if (age < 0) {
            System.out.println("Error in age value");
        } else if (age <= 12) {
            System.out.println("Child");
        } else if (age <= 19) {
            System.out.println("Teenager");
        } else if (age <= 65) {
            System.out.println("Adult");
        } else {
            System.out.println("Senior citizen");
        }
    }
}
```

</hint>

