# Exercise - Round Sum

### Problem Statement
For this problem, we'll round an integer value up to the next multiple of 10 if its rightmost digit is 5 or more (e.g., 15 rounds up to 20). Alternately, round down to the previous multiple of 10 if its rightmost digit is less than 5 (e.g., 12 rounds down to 10). Given three integers `a`, `b`, and `c`, return the sum of their rounded values.

To avoid code repetition, write a separate helper method `public int round10(int num)` and call it three times. Write the helper method entirely below and at the same indent level as `roundSum()`.

### Examples
```
roundSum(16, 17, 18)    → 60
roundSum(12, 13, 14)    → 30
roundSum(6, 4, 4)       → 10
```

### Instructions

Write a program that implements the `roundSum` logic. The program should:
1. Ask the user to enter three integers.
2. Calculate and print the sum of the rounded values.

### Example Output

```yaml
Enter the first number:
16
Enter the second number:
17
Enter the third number:
18
The rounded sum is: 60
```