# Exercises - Practice with the Break Keyword

This page contains some exercises designed to help you practice using the `break` statement in Java loops.


## Exercise 1: Password Attempts with Limit
Create a program that gives the user a maximum of 3 attempts to enter the correct password. The correct password is "secret123". Use `break` to exit early if the correct password is entered before the maximum attempts are reached.

### Example Output:
```
Enter password (attempt 1/3): wrong
Enter password (attempt 2/3): guess
Enter password (attempt 3/3): secret123
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

## Exercise 2: Sum Until Below -10
Write a program that continuously asks the user to enter numbers (both positive and negative) and calculates their running sum. Stop immediately when the sum becomes smaller than -10. Use `break` to exit the loop when this condition is met.

### Example Output:
```
Enter a number: 5
Current sum: 5
Enter a number: -3
Current sum: 2
Enter a number: 2
Current sum: 4
Enter a number: -7
Current sum: -3
Enter a number: -8
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