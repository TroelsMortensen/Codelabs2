# Exercises - Practice with the Break Keyword

This file contains three exercises designed to help you practice using the `break` statement in Java loops.

## Exercise 1: Find the First Number Divisible by 9
Write a Java program that finds the first number divisible by 9 starting from a user-provided number. Use a `while` loop with `break` to exit when the first number divisible by 9 is found.

### Example Input:
```
Enter a starting number: 7
```

### Example Output:
```
The first number divisible by 9 starting from 7 is: 9
```

### Another Example:
**Input:**
```
Enter a starting number: 11
```

**Output:**
```
The first number divisible by 9 starting from 11 is: 18
```

<hint title="Hint 1">

Use a `while (true)` loop and check if the current number is divisible by 9 using the modulo operator (`%`). If it's divisible by 9, print the result and use `break` to exit.

</hint>

<hint title="Solution">

```java
import java.util.Scanner;

public class FindFirstDivisibleBy9 {
    public static void main(String[] args) {
        Scanner scanner = new Scanner(System.in);
        System.out.print("Enter a starting number: ");
        int startingNumber = scanner.nextInt();
        int number = startingNumber;
        
        while (true) {
            if (number % 9 == 0) {
                System.out.println("The first number divisible by 9 starting from " + 
                                   startingNumber + " is: " + number);
                break;
            }
            number++;
        }
    }
}
```

</hint>

## Exercise 2: Password Attempts with Limit
Create a program that gives the user a maximum of 3 attempts to enter the correct password. The correct password is "secret123". Use `break` to exit early if the correct password is entered before the maximum attempts are reached.

### Example Input:
```
Enter password (attempt 1/3): wrong
Enter password (attempt 2/3): guess
Enter password (attempt 3/3): secret123
```

### Example Output:
```
Access granted!
```

<hint title="Hint 1">

Use a `for` loop that runs from 1 to 3 (for attempts). Inside the loop, check if the password is correct. If it is, print success message and use `break` to exit early.

</hint>

<hint title="Solution">

```java
import java.util.Scanner;

public class PasswordAttempts {
    public static void main(String[] args) {
        Scanner scanner = new Scanner(System.in);
        String correctPassword = "secret123";
        boolean accessGranted = false;
        
        for (int attempt = 1; attempt <= 3; attempt++) {
            System.out.print("Enter password (attempt " + attempt + "/3): ");
            String password = scanner.nextLine();
            
            if (password.equals(correctPassword)) {
                System.out.println("Access granted!");
                accessGranted = true;
                break;
            }
        }
        
        if (!accessGranted) {
            System.out.println("Access denied. Maximum attempts reached.");
        }
    }
}
```

</hint>

## Exercise 3: Sum Until Below -10
Write a program that continuously asks the user to enter numbers (both positive and negative) and calculates their running sum. Stop immediately when the sum becomes smaller than -10. Use `break` to exit the loop when this condition is met.

### Example Input:
```
Enter a number: 5
Enter a number: -3
Enter a number: 2
Enter a number: -7
Enter a number: -8
```

### Example Output:
```
Current sum: 5
Current sum: 2
Current sum: 4
Current sum: -3
Current sum: -11
Sum has dropped below -10. Stopping.
Final sum: -11
```

<hint title="Hint 1">

Use a `while (true)` loop to continuously ask for input. After adding each number to the sum, check if the sum is less than -10, and if so, use `break` to exit.

</hint>

<hint title="Solution">

```java
import java.util.Scanner;

public class SumUntilBelowMinusTen {
    public static void main(String[] args) {
        Scanner scanner = new Scanner(System.in);
        int sum = 0;
        
        while (true) {
            System.out.print("Enter a number: ");
            int number = scanner.nextInt();
            
            sum += number;
            System.out.println("Current sum: " + sum);
            
            if (sum < -10) {
                System.out.println("Sum has dropped below -10. Stopping.");
                break;
            }
        }
        
        System.out.println("Final sum: " + sum);
    }
}
```

</hint>