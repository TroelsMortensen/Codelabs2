# Basic If-statement

Watch the introcuction video to understand the concepts of the if-statement and how it works in Java.

<video src="https://youtu.be/aK1hu_LXYs8"></video>

Once you have watched the video, then watch the following video to see how the if-statement works in Java.

<video src="https://youtu.be/Vu3C2OFt9cU"></video>

# Exercises

### Exercise 1: Is number positive?
Write a program that asks the user to enter a number. Use an if-statement to print "The number is positive" if the number is greater than or equal to 0. If the number is negative, nothing should be printed.

Example Output:
```yaml
Enter a number:
-5
```
(prints nothing)

```yaml
Enter a number:
7
The number is positive
```

<hint title="Code Solution">

```java
import java.util.Scanner;

public class PositiveOrNegative {
    public static void main(String[] args) {
        Scanner scanner = new Scanner(System.in);
        System.out.print("Enter a number: ");
        int number = scanner.nextInt();
        if (number >= 0) 
        {
            System.out.println("The number is positive");
        }
    }
}
```
</hint>

<hint title="Video Solution">

<video src="https://youtu.be/978Xc-4jsc4"></video>

</hint>

### Exercise 2: Is number positive or negative?

In the previous exercise, expand the program to also print "The number is negative" if the number is less than 0. If the number is 0, print "The number is zero".

Example Output:
```yaml
Enter a number:
-5
The number is negative
```

```yaml
Enter a number:
0
The number is zero
```

```yaml
Enter a number:
7
The number is positive
```

<hint title="Hint 1">

Use three separate if-statements: one for checking if the number is positive, one for zero, and one for negative.

</hint>

<hint title="Code Solution">

```java
import java.util.Scanner;

public class PositiveNegativeZero {
    public static void main(String[] args) {
        Scanner scanner = new Scanner(System.in);
        System.out.print("Enter a number: ");
        int number = scanner.nextInt();
        if (number > 0) 
        {
            System.out.println("The number is positive");
        }
        if (number == 0) 
        {
            System.out.println("The number is zero");
        }
        if (number < 0) 
        {
            System.out.println("The number is negative");
        }
        scanner.close();
    }
}
```

</hint>

<hint title="Video Solution">

<video src="https://youtu.be/FMD2p797lXk"></video>

</hint>

### Exercise 3: Even or Odd
Write a program that asks the user to enter a number. Use an if-statement to print "The number is even" if the number is divisible by 2.\
If the number is odd, then print that out.

Example Output:
```yaml
Enter a number:
7
The number is odd
```


```yaml
Enter a number:
8
The number is even
```

<hint title="Hint 1">

Remember, you can use the modulo operator (`%`) to find the remainder when dividing by 2. If `number % 2 == 0`, the number is even.

</hint>

<hint title="Solution">

```java
import java.util.Scanner;

public class EvenOrOdd 
{
    public static void main(String[] args) 
    {
        Scanner scanner = new Scanner(System.in);
        System.out.print("Enter a number: ");
        int number = scanner.nextInt();
        if (number % 2 == 0) 
        {
            System.out.println("The number is even");
        }
    }
}
```

</hint>
