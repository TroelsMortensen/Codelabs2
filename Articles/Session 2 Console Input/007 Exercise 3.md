# Exercise 3 - read and increment integer

Write a program which requests an integer input from the user,
increments it by 1, and outputs the result.


The interaction should look like this:

```console
Please input an integer:
5
Here is your incremented integer:
6
```


<hint title="Hint 1">

You have two approaches:
1. Use `nextInt()` to read an integer directly.
2. Use `nextLine()` to read a string and then convert it to an integer using `Integer.parseInt()`.

Parsing a `String` to an `int` looks like this:

```java
int number = Integer.parseInt("123");
```

The above code will crash your program, if you do not input a valid integer.

</hint>

<hint title="Solution 1">

```java
import java.util.Scanner;
public class IncrementInteger {
    public static void main(String[] args) {
        Scanner in = new Scanner(System.in);
        
        System.out.println("Please input an integer:");
        int input = in.nextInt(); // Read an integer directly
        
        int incrementedValue = input + 1; // Increment the integer
        
        System.out.println("Here is your incremented integer:");
        System.out.println(incrementedValue); // Output the incremented value
    }
}
```
</hint>

<hint title="Solution 2">

```java
import java.util.Scanner;
public class IncrementInteger {
    public static void main(String[] args) {
        Scanner in = new Scanner(System.in);
        
        System.out.println("Please input an integer:");
        String input = in.nextLine(); // Read a string input
        
        int number = Integer.parseInt(input); // Convert the string to an integer
        int incrementedValue = number + 1; // Increment the integer
        
        System.out.println("Here is your incremented integer:");
        System.out.println(incrementedValue); // Output the incremented value
    }
}
```
</hint>
