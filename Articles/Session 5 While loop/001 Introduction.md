# The while loop

The `while` loop is a control flow statement that allows code to be executed repeatedly based on a given condition. The loop continues as long as the condition evaluates to `true`. If the condition is `false`, the loop stops.

It is similar to the for-loop, but perhaps a bit simpler in its structure. The `while` loop is particularly useful when the number of iterations is not known beforehand and depends on dynamic conditions.

### Syntax:

```java
while (condition) {
    // Code to execute
}
```

As a diagram, we can represent the `while` loop as follows:


![While Loop Diagram](Resources/While%20loop%20diagram.png)


### Key Points:
- The condition is evaluated before the loop body is executed.
- If the condition is `false` initially, the loop body will not execute at all.

## Example 1: Print Numbers from 1 to 5
You have seen this example done with the `for-loop`, but it's also easily done with a `while` loop.

```java
public class WhileExample {
    public static void main(String[] args) {
        int i = 1;
        while (i <= 5) {
            System.out.println(i);
            i++;
        }
    }
}
```

Remember how the `for-loop` had 3 parts: initialization, condition, and update?
Here, we have the initialization (`int i = 1;`), the condition (`i <= 5`), and the update (`i++`) all handled in different parts of the code.

### Output:
```
1
2
3
4
5
```

## Example 2: Request Hello World Input

In this example, we will use a `while` loop to repeatedly ask the user for input until they enter "Hello World".

```java
import java.util.Scanner;

public class HelloWorldExample {

    public static void main(String[] args) {
        Scanner scanner = new Scanner(System.in);
        boolean keepGoing = true;
        
        while (keepGoing) {
            System.out.print("Please enter 'Hello World': ");
            String input = scanner.nextLine();
            
            if (input.equals("Hello World")) {
                keepGoing = false;
            } else {
                System.out.println("Incorrect input, please try again.");
            }
        }
        System.out.println("Success! You entered 'Hello World'. That was very well done! Praise to you!");
    }
}
```