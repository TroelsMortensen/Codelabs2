# Exercises

## Exercise 0: 

Write a program that continuously reads numbers from the console. You will need to create two ArrayLists: one for positive numbers and one for negative numbers. The program should:

- If the number is positive, add it to an `ArrayList` of positive numbers.
- If the number is negative, add it to an `ArrayList` of negative numbers.
- If the number is 0, print:
    - The number of elements in each list
    - The sum of each list
    - The combined sum of both lists
  Then terminate the program.

**Example (user input in bold):**

```
Enter a number: **5**
Enter a number: **-3**
Enter a number: **7**
Enter a number: **-2**
Enter a number: **0**
Positive numbers: 2
Negative numbers: 2
Sum of positive numbers: 12
Sum of negative numbers: -5
Combined sum: 7
```

## Exercise 1: Count number of different numbers
Write a program that continuously reads numbers from the console until the user enters 0. 

When 0 is read from the console, the program should print out how many different numbers were entered (excluding 0) and print the count at the end.

### Example Input:
```
5
3
5 // duplicate
7
3 // duplicate
0 // terminate input
```

### Example Output:
```
Different numbers entered: 3
```

<hint title="Hint 1">
Use an `ArrayList` to store the numbers as they are entered.
</hint>

<hint title="Hint 2">
Before adding a number to your list or set, check if it is already present.
</hint>

<hint title="Hint 3">
Remember to ignore the terminating 0 when counting different numbers.
</hint>

## Exercise 2: Second largest number

Write a program that continuously reads numbers from the console until the user enters 0.

When 0 is read from the console, the program should print out the second largest number entered (excluding 0). If there are fewer than two different numbers, print a message saying so.

### Example Input:
```
8
3
5
8
0
```

### Example Output:
```
Second largest number: 5
```

### Example Input (not enough numbers):
```
4
0
```

### Example Output:
```
Not enough different numbers entered.
```

### Exercise 3: Count evens

Start with an empty main method. Then add a helper method that takes an `ArrayList<Integer>` as a parameter and prints the count of even numbers in that list.

The template is as follows:

```java
import java.util.ArrayList;
import java.util.Arrays;
public class CountEvens {
    public static void main(String[] args) {
        // Example usage
        countEvens(Arrays.asList(1, 2, 3, 4, 5, 6));
        countEvens(Arrays.asList(7, 8, 9, 10, 11, 12));
        countEvens(Arrays.asList(33, 42, 17, 18, 24, 30, 45, 60, 72, 99, 100, 101));
    }

    public static void countEvens(ArrayList<Integer> list) {
        // Your code here        
    }
}
```

### Exercise 4: Largest difference
Write a method that takes an `ArrayList<Integer>` as a parameter and prints the largest difference between any two numbers in the list. If the list has fewer than two elements, return 0.

Use a helper method like the previous exercise.

Example of list and the biggest difference:

```
[10, 3, 5, 6] → 7 (10 - 3)
[1, 2, 3, 4] → 3 (4 - 1)
[7, 2, 10, 9] → 8 (10 - 2)
[2, 10, 7, 2] → 8 (10 - 2)
```

### Exercise 5: Unlucky 13

Print the sum of the numbers in a list, returning 0 for an empty list. Except the number 13 is very unlucky, so it does not count and numbers that come immediately after a 13 also do not count.

Example of list and the sum:

```
[1, 2, 3, 4] → 10
[1, 2, 13, 4] → 3 (13 and the number after it are ignored)
[1, 2, 13, 4, 5] → 8 (13 and the number after it are ignored)
[1, 2, 13] → 3 (only the first two numbers count)
[] → 0 (empty list)
```

### Exercise 6: has 22

Given a list of ints, print true if the list contains a 2 next to a 2 somewhere.

```
has22([1, 2, 2]) → true
has22([1, 2, 1, 2]) → false
has22([2, 1, 2]) → false
```

### Exercise 7: more14

Given a list of ints, print true if the number of 1's is greater than the number of 4's


more14([1, 4, 1]) → true
more14([1, 4, 1, 4]) → false
more14([1, 1]) → true

### Exercise 8: fizz list

Given a number n, create and print a new int array of length n, containing the numbers 0, 1, 2, ... n-1. The given n may be 0, in which case just return a length 0 array. 

```
fizzArray(4) → [0, 1, 2, 3]
fizzArray(1) → [0]
fizzArray(10) → [0, 1, 2, 3, 4, 5, 6, 7, 8, 9]
fizzArray(0) → []
```

### Exercise 9: Even split of list


Given a non-empty list, return true if there is a place to split the list so that the sum of the numbers on one side is equal to the sum of the numbers on the other side.


canBalance([1, 1, 1, 2, 1]) → true
canBalance([2, 1, 1, 2, 1]) → false
canBalance([10, 10]) → true


