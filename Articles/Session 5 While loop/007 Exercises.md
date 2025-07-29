# Exercises - Training the Continue Keyword

This file contains four exercises designed to help you practice using the `continue` keyword in `while` loops in Java. The `continue` keyword allows you to skip the rest of the current iteration and move to the next iteration of the loop.

## Exercise 1: Skip Numbers Divisible by 4
Write a Java program that asks the user for an upper bound, then prints all numbers from 1 to that upper bound using a loop type of your choice, but skips any numbers that are divisible by 4 using the `continue` keyword.

### Example Input:
```
Enter the upper bound: 15
```

### Example Output:
```
1
2
3
5
6
7
9
10
11
13
14
15
```

<hint title="Hint 1">

Use a Scanner to get the upper bound from the user. Then use a counter variable starting from 1. Inside the loop, check if the number is divisible by 4 using the modulo operator (`%`). If it's divisible by 4, use `continue` to skip printing it.

</hint>

<hint title="Solution">

```java
import java.util.Scanner;

public class SkipDivisibleByFour {
    public static void main(String[] args) {
        Scanner scanner = new Scanner(System.in);
        System.out.print("Enter the upper bound: ");
        int upperBound = scanner.nextInt();
        
        int i = 1;
        while (i <= upperBound) {
            if (i % 4 == 0) {
                i++;
                continue;
            }
            System.out.println(i);
            i++;
        }
    }
}
```

</hint>

## Exercise 2: Skip Negative Numbers
Write a program that asks the user to enter 10 numbers. Use a `while` loop to read the numbers, but skip (don't add to the sum) any negative numbers using the `continue` keyword. Print the sum of only the positive numbers.

### Example Input:
```
Enter number 1: 5
Enter number 2: -3
Enter number 3: 8
Enter number 4: -1
Enter number 5: 4
Enter number 6: 7
Enter number 7: -2
Enter number 8: 6
Enter number 9: 3
Enter number 10: -5
```

### Example Output:
```
Sum of positive numbers: 33
```

<hint title="Hint 1">

Use a counter to track how many numbers have been entered. Inside the loop, if a number is negative, use `continue` to skip adding it to the sum, but still increment the counter.

</hint>

<hint title="Solution">

```java
import java.util.Scanner;

public class SkipNegativeNumbers {
    public static void main(String[] args) {
        Scanner scanner = new Scanner(System.in);
        int sum = 0;
        int count = 1;
        
        while (count <= 10) {
            System.out.print("Enter number " + count + ": ");
            int number = scanner.nextInt();
            
            if (number < 0) {
                count++;
                continue;
            }
            
            sum += number;
            count++;
        }
        
        System.out.println("Sum of positive numbers: " + sum);
    }
}
```

</hint>

## Exercise 3: Skip Multiples of 3
Write a program that prints numbers from 1 to 30, but skips any number that is a multiple of 3 using the `continue` keyword.

### Example Output:
```
1
2
4
5
7
8
10
11
13
14
16
17
19
20
22
23
25
26
28
29
```

<hint title="Hint 1">

Use the modulo operator (`%`) to check if a number is divisible by 3. If `number % 3 == 0`, use `continue` to skip printing it.

</hint>

<hint title="Solution">

```java
public class SkipMultiplesOfThree {
    public static void main(String[] args) {
        int i = 1;
        while (i <= 30) {
            if (i % 3 == 0) {
                i++;
                continue;
            }
            System.out.println(i);
            i++;
        }
    }
}
```

</hint>

## Exercise 4: Filter Input Numbers
Write a program that continuously asks the user to enter numbers until they enter 0. Use `continue` to skip any numbers that are outside the range of 10-50 (inclusive). Count and display how many valid numbers were entered, and also count how many times a number divisible by 10 was entered (only if it's within the valid range).

### Example Input:
```
Enter a number (0 to stop): 5
Enter a number (0 to stop): 25
Enter a number (0 to stop): 75
Enter a number (0 to stop): 30
Enter a number (0 to stop): -10
Enter a number (0 to stop): 45
Enter a number (0 to stop): 0
```

### Example Output:
```
Valid numbers entered: 3
Numbers divisible by 10: 1
```

<hint title="Hint 1">

Use a while loop that continues until the user enters 0. Check if each number is between 10 and 50 (inclusive). If not, use `continue` to skip counting it. Only count numbers divisible by 10 if they are also in the valid range.

</hint>

<hint title="Solution">

```java
import java.util.Scanner;

public class FilterInputNumbers {
    public static void main(String[] args) {
        Scanner scanner = new Scanner(System.in);
        int validCount = 0;
        int divisibleBy10Count = 0;
        int number;
        
        while (true) {
            System.out.print("Enter a number (0 to stop): ");
            number = scanner.nextInt();
            
            if (number == 0) {
                break;
            }
            
            if (number < 10 || number > 50) {
                continue;
            }
            
            validCount++;
            
            if (number % 10 == 0) {
                divisibleBy10Count++;
            }
        }
        
        System.out.println("Valid numbers entered: " + validCount);
        System.out.println("Numbers divisible by 10: " + divisibleBy10Count);
    }
}
```

</hint>