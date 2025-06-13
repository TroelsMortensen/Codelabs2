# Exercise - Lucky Sum

### Problem Statement
Given three integer values `a`, `b`, and `c`, return their sum. However, if one of the values is `13`, it does not count towards the sum, and all values to its right are ignored.

### Examples
```
luckySum(1, 2, 3) → 6
luckySum(1, 2, 13) → 3
luckySum(1, 13, 3) → 1
luckySum(13, 2, 3) → 0
```

### Instructions
Write a program that implements the `luckySum` logic. The program should:
1. Ask the user to enter three integers.
2. Calculate the sum based on the rules above.
3. Print the result.

### Example Output
```yaml
Enter the first number:
1
Enter the second number:
2
Enter the third number:
13
The lucky sum is: 3
```