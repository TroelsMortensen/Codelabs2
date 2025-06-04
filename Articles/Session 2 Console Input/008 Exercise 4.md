# Exercise 4 - Sum two integers

Write a program which requests two integer inputs from the user,
sums them, and outputs the result.

The interaction should look like this:

```console
Please input the first integer:
5
Please input the second integer:
6
The sum of the two integers is:
11
```

<hint title="Solution">

```java
import java.util.Scanner;

public class SumTwoIntegers {
    public static void main(String[] args) {
        Scanner in = new Scanner(System.in);
        
        System.out.println("Please input the first integer:");
        int firstInput = in.nextInt(); // Read the first integer
        
        System.out.println("Please input the second integer:");
        int secondInput = in.nextInt(); // Read the second integer
        
        int sum = firstInput + secondInput; // Calculate the sum
        
        System.out.println("The sum of the two integers is:");
        System.out.println(sum); // Output the sum
    }
}
```


</hint>