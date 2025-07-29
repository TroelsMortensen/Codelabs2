# Exercises - Training the While-Loop

This file contains five exercises designed to help you practice using `while` loops in Java. You may solve the exercises with either the while or the do-while. It is up to you to pick whichever loop fits your problem best.

## Exercise 1: Count Down from User Input
Write a Java program that asks the user to enter a positive number and then counts down from that number to 1 using a `while` loop.

### Example Input:
```
Enter a positive number: 5
```

### Example Output:
```
5
4
3
2
1
Countdown complete!
```

<hint title="Hint 1">

Initialize a variable with the user's input, then use a `while` loop that continues as long as the variable is greater than 0. Don't forget to decrement the variable inside the loop.

</hint>

<hint title="Solution">

```java
import java.util.Scanner;

public class CountDown {
    public static void main(String[] args) {
        Scanner scanner = new Scanner(System.in);
        System.out.print("Enter a positive number: ");
        int number = scanner.nextInt();
        
        while (number > 0) {
            System.out.println(number);
            number--;
        }
        System.out.println("Countdown complete!");
    }
}
```

</hint>

## Exercise 2: Sum Until X
Write a program that continuously asks the user to enter numbers and adds them to a running sum. The program should stop when the user enters "x" and then display the total sum.

### Example Input:
```
Enter a number (x to stop): 5
Enter a number (x to stop): 3
Enter a number (x to stop): -2
Enter a number (x to stop): 4
Enter a number (x to stop): x
```

### Example Output:
```
The total sum is: 10
```

<hint title="Hint 1">

Use a `while` loop that continues as long as the input is not equal to "x". Keep track of the sum by adding each valid number input to a sum variable. Remember to use `nextLine()` for string input.

</hint>

<hint title="Hint 2">

To convert a string to an integer, use `Integer.parseInt(stringVariable)`.

</hint>

<hint title="Solution">

```java
import java.util.Scanner;

public class SumUntilX {
    public static void main(String[] args) {
        Scanner scanner = new Scanner(System.in);
        int sum = 0;
        String input;
        
        do {
            System.out.print("Enter a number (x to stop): ");
            input = scanner.nextLine();
            
            if (!input.equals("x")) {
                int number = Integer.parseInt(input);
                sum += number;
            }
        } while (!input.equals("x"));
        
        System.out.println("The total sum is: " + sum);
    }
}
```

</hint>

## Exercise 3: Password Validation
Create a program that asks the user to enter a password. The correct password is "java123". Keep asking until the user enters the correct password, then display a success message. Upon incorrect input, show an appropriate error message.

### Example Input:
```
Enter the password: hello
Incorrect password, try again.
Enter the password: java
Incorrect password, try again.
Enter the password: java123
```

### Example Output:
```
Access granted! Welcome!
```

<hint title="Solution">

```java
import java.util.Scanner;

public class PasswordValidation {
    public static void main(String[] args) {
        Scanner scanner = new Scanner(System.in);
        String correctPassword = "java123";
        String userPassword;
        boolean accessGranted = false;
        
        while (!accessGranted) {
            System.out.print("Enter the password: ");
            userPassword = scanner.nextLine();
            
            if (userPassword.equals(correctPassword)) {
                accessGranted = true;
                System.out.println("Access granted! Welcome!");
            } else {
                System.out.println("Incorrect password, try again.");
            }
        }
    }
}
```

</hint>

## Exercise 4: Number Guessing Game
Write a program where the computer picks a random number between 1 and 10, and the user has to guess it. Keep asking for guesses until the user guesses correctly, providing hints if the guess is too high or too low.

### Example Input:
```
Guess the number (1-10): 5
Too low! Try again.
Guess the number (1-10): 8
Too high! Try again.
Guess the number (1-10): 7
```

### Example Output:
```
Congratulations! You guessed it! The number was 7.
```

<hint title="Hint 1">

Use `Math.random()` to generate a random number: `int randomNumber = (int)(Math.random() * 10) + 1;`. This will generate a random number between 1 and 10.

</hint>

<hint title="Solution">

```java
import java.util.Scanner;

public class NumberGuessingGame {
    public static void main(String[] args) {
        Scanner scanner = new Scanner(System.in);
        int randomNumber = (int)(Math.random() * 10) + 1;
        int guess = 0;
        
        while (guess != randomNumber) {
            System.out.print("Guess the number (1-10): ");
            guess = scanner.nextInt();
            
            if (guess < randomNumber) {
                System.out.println("Too low! Try again.");
            } else if (guess > randomNumber) {
                System.out.println("Too high! Try again.");
            }
        }
        
        System.out.println("Congratulations! You guessed it! The number was " + randomNumber + ".");
    }
}
```

</hint>

## Exercise 5: Calculate Factorial
Write a program that asks the user for a positive integer and calculates its factorial using a `while` loop. The factorial of n (written as n!) is the product of all positive integers from 1 to n.

### Example Input:
```
Enter a positive integer: 5
```

### Example Output:
```
The factorial of 5 is: 120
```

As an extra challenge make the example output like this instead:

```
The factorial of 5 is: 5 * 4 * 3 * 2 * 1 = 120
```

<hint title="Hint 1">

Start with a factorial variable set to 1, and multiply it by each number from 1 to the input number. Use a counter variable to track which number you're currently multiplying.

</hint>

<hint title="Hint 2">

Remember that the factorial of 0 is 1, and factorial is only defined for non-negative integers.

</hint>

<hint title="Solution">

```java
import java.util.Scanner;

public class FactorialCalculator {
    public static void main(String[] args) {
        Scanner scanner = new Scanner(System.in);
        System.out.print("Enter a positive integer: ");
        int number = scanner.nextInt();
        
        if (number < 0) {
            System.out.println("Factorial is not defined for negative numbers.");
        } else {
            long factorial = 1;
            int counter = 1;
            
            while (counter <= number) {
                factorial *= counter;
                counter++;
            }
            
            System.out.println("The factorial of " + number + " is: " + factorial);
        }
    }
}
```

</hint>