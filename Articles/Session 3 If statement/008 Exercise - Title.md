# Exercise: Gender and Age Description

Write a program that reads a gender (`char` 'M' or 'F') and an age (`int`) from the keyboard and then prints a message. The message should depend on the typed values, in the following way:

- **If gender is not either 'M' or 'F' or age is less than 0**, display the message: `Error in typed values`.
- **If gender is 'M' and age is less than 18**, display the message: `Boy`.
- **If gender is 'M' and age is greater than or equal to 18**, display the message: `Man`.
- **If gender is 'F' and age is less than 18**, display the message: `Girl`.
- **If gender is 'F' and age is greater than or equal to 18**, display the message: `Woman`.

### Instructions
Test the program by running it multiple times and entering different values.

<hint title="Hint 1">

To read a character from the console in Java, you can first read a string using the `nextLine()` method of the `Scanner` class, and then extract the first character using the `charAt(0)` method. For example:

```java
Scanner scanner = new Scanner(System.in);
System.out.print("Enter a character: ");
String input = scanner.nextLine();
char character = input.charAt(0);
```
This will store the first character of the input string in the `character` variable.
</hint>

<hint title="Solution">

```java
import java.util.Scanner;

public class GenderAndAgeDescription {
    public static void main(String[] args) {
        Scanner scanner = new Scanner(System.in);

        System.out.print("Enter gender (M/F): ");
        String genderInput = scanner.nextLine();
        char gender = genderInput.charAt(0);

        System.out.print("Enter age: ");
        int age = scanner.nextInt();

        if ((gender != 'M' && gender != 'F') || age < 0) {
            System.out.println("Error in typed values");
        } else if (gender == 'M' && age < 18) {
            System.out.println("Boy");
        } else if (gender == 'M' && age >= 18) {
            System.out.println("Man");
        } else if (gender == 'F' && age < 18) {
            System.out.println("Girl");
        } else if (gender == 'F' && age >= 18) {
            System.out.println("Woman");
        }
    }
}
```
</hint>
