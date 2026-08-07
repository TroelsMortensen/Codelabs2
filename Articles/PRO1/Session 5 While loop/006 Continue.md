# The continue keyword

We continue with more content, more exercises, by introducing the `continue` keyword.

The `continue` keyword is another control statement in Java that affects loop execution. Unlike `break`, which exits the loop entirely, `continue` skips the rest of the current iteration and jumps directly to the next iteration of the loop. Or, it skips the rest of the loop-body, and starts over from the top of the loop-body.

## How continue works

When a `continue` statement is encountered inside a loop:
1. The remaining code in the body of the loop is skipped
2. The loop immediately jumps to the next iteration, i.e. back to the top of the loop-body
3. For `for` loops, the increment/update expression is executed before the next iteration
4. For `while` loops, control goes back to the condition check

The `continue` statement can be used in each of the four types of loops.

## Example 1: Skip even numbers in a for loop

This example prints only odd numbers from 1 to 10. The if-statement is used to skip the even numbers.

```java
public class SkipEvenNumbers {
    public static void main(String[] args) {
        System.out.println("Odd numbers from 1 to 10:");
        
        for (int i = 1; i <= 10; i++) {
            if (i % 2 == 0) {
                continue;  // Skip even numbers
            }
            System.out.println(i);
        }
        
        System.out.println("Done!");
    }
}
```

**Output:**
```
Odd numbers from 1 to 10:
1
3
5
7
9
Done!
```

When `i` is even (2, 4, 6, 8, 10), the `continue` statement skips the `System.out.println(i)` and jumps to the next iteration.

## Example 2: Skip negative numbers in user input

This example asks for 5 numbers but only processes positive ones:

```java
import java.util.Scanner;

public class SkipNegativeNumbers {
    public static void main(String[] args) {
        Scanner scanner = new Scanner(System.in);
        int sum = 0;
        int count = 0;
        
        System.out.println("Enter 5 numbers:");
        
        for (int i = 1; i <= 5; i++) {
            System.out.print("Number " + i + ": ");
            int number = scanner.nextInt();
            
            if (number < 0) {
                System.out.println("Negative number ignored.");
                continue;  // Skip processing this negative number
            }
            
            sum += number;
            count++;
            System.out.println("Added " + number + " to sum.");
        }
        
        System.out.println("Sum of positive numbers: " + sum);
        System.out.println("Count of positive numbers: " + count);
    }
}
```

**Example Input/Output:**
```
Enter 5 numbers:
Number 1: 5
Added 5 to sum.
Number 2: -3
Negative number ignored.
Number 3: 8
Added 8 to sum.
Number 4: -1
Negative number ignored.
Number 5: 12
Added 12 to sum.
Sum of positive numbers: 25
Count of positive numbers: 3
```

## Example 3: Continue with while loop

This example shows using `continue` in a while loop to validate user input:

```java
import java.util.Scanner;

public class ContinueWhileExample {
    public static void main(String[] args) {
        Scanner scanner = new Scanner(System.in);
        int attempts = 0;
        int maxAttempts = 5;
        
        while (attempts < maxAttempts) {
            attempts++;
            System.out.print("Enter a number between 1 and 100 (attempt " + attempts + "): ");
            int number = scanner.nextInt();
            
            if (number < 1 || number > 100) {
                System.out.println("Invalid input! Must be between 1 and 100.");
                continue;  // Skip to next iteration without processing
            }
            
            // Valid input - process it
            System.out.println("Great! You entered: " + number);
            System.out.println("The square of " + number + " is " + (number * number));
            break;  // Exit the loop since we got valid input
        }
        
        if (attempts >= maxAttempts) {
            System.out.println("Too many invalid attempts. Exiting.");
        }
    }
}
```

## Difference between break and continue

| Statement | Effect |
|-----------|--------|
| `break` | Exits the loop completely |
| `continue` | Skips rest of current iteration, continues with next iteration |

## When to use continue

The `continue` statement is useful when:

1. **Filtering data**: Skip processing certain values that don't meet criteria
2. **Input validation**: Skip invalid input and ask again
3. **Conditional processing**: Only process items that meet specific conditions
4. **Error handling**: Skip problematic data and continue with the rest
5. **Performance optimization**: Avoid unnecessary processing for certain cases

## Important Notes

- `continue` only affects the innermost loop containing it
- In `for` loops, the increment expression still executes after `continue`
- `continue` makes code more readable by avoiding deeply nested `if-else` statements
- Overusing `continue` can make code harder to follow - use it judiciously

The `continue` statement is a powerful tool for controlling loop flow and making your code more efficient and readable by skipping unnecessary processing.
