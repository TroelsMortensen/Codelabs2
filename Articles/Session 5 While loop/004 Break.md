# The break keyword.

No, it is not a break for _you_, the reader, you still have a lot of work to do.

The `break` keyword is a powerful control statement in Java that allows you to exit or "break out of" loops prematurely. When a `break` statement is encountered inside a loop, the loop is immediately terminated, and the program control flows to the statement after the loop.

## How break works

The `break` statement can be used in:
- `for` loops
- `while` loops 
- `do-while` loops
 

When `break` is executed, it immediately exits the innermost loop that contains it.

## Example 1: Using break in a while loop

Let's look at a simple example where we want to find the first number divisible by 7:

```java
public class BreakWhileExample {
    public static void main(String[] args) {
        int number = 1;
        
        while (true) {  // Infinite loop!
            if (number % 7 == 0) {
                System.out.println("Found first number divisible by 7: " + number);
                break;  // Exit the loop
            }
            number++;
        }
        
        System.out.println("Loop ended. Final number: " + number);
    }
}
```

**Output:**
```
Found first number divisible by 7: 7
Loop ended. Final number: 7
```

In this example, we create an infinite loop with `while (true)`, but use `break` to exit when we find what we're looking for.

Notice that in this example, we could also just have used the while-condition to stop the loop. Generally, the break keyword is nice-to-have, it does not do something, that cannot be done in a different way. It is sometimes just slightly more convenient.


## Example 2: Using break in a for loop

Here's an example that searches for a specific value in an array:

```java
public class BreakForExample {
    public static void main(String[] args) {
        int[] numbers = {3, 7, 12, 5, 9, 15, 2};
        int target = 9;
        boolean found = false;
        
        for (int i = 0; i < numbers.length; i++) {
            System.out.println("Checking: " + numbers[i]);
            
            if (numbers[i] == target) {
                System.out.println("Found " + target + " at index " + i);
                found = true;
                break;  // Exit the loop early
            }
        }
        
        if (!found) {
            System.out.println(target + " not found in the array");
        }
        
        System.out.println("Search completed.");
    }
}
```

**Output:**
```
Checking: 3
Checking: 7
Checking: 12
Checking: 5
Checking: 9
Found 9 at index 4
Search completed.
```

Notice how the loop stops checking the remaining elements (15 and 2) once the target is found.

## Example 3: User input validation with break

This example shows how to keep asking for user input until they provide a valid number (between 1 and 10), using `break` to exit when valid input is received:

```java
import java.util.Scanner;

public class InputValidationExample {
    public static void main(String[] args) {
        Scanner scanner = new Scanner(System.in);
        int validNumber = 0;
        
        while (true) {
            System.out.print("Enter a number between 1 and 10: ");
            int input = scanner.nextInt();
            
            if (input >= 1 && input <= 10) {
                validNumber = input;
                System.out.println("Thank you! You entered: " + validNumber);
                break;  // Exit when valid input is received
            } else {
                System.out.println("Invalid input. Please try again.");
            }
        }
        
        System.out.println("Program continues with valid number: " + validNumber);
    }
}
```

**Example Input/Output:**
```
Enter a number between 1 and 10: 15
Invalid input. Please try again.
Enter a number between 1 and 10: -3
Invalid input. Please try again.
Enter a number between 1 and 10: 7
Thank you! You entered: 7
Program continues with valid number: 7
```

## When to use break

The `break` statement is useful when:

1. **Early termination**: You want to exit a loop as soon as a condition is met
2. **Infinite loops with exit conditions**: Creating intentional infinite loops that exit based on specific conditions
3. **Search operations**: Stopping a search once the target is found
4. **Input validation**: Continuing to ask for input until valid data is received
5. **Performance optimization**: Avoiding unnecessary iterations once the desired result is achieved

## Important Notes

- `break` can make your code more efficient by avoiding unnecessary iterations
- Always (almost) ensure your loop has a way to terminate to avoid infinite loops
- In case of nested loops (introduced later), `break` will only exit out of the inner loop.

The `break` statement is a powerful tool for controlling loop execution and making your programs more efficient and readable.