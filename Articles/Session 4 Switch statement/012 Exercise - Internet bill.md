# Exercise - Internet Bill

An Internet service provider has three different subscription packages for its customers:

| Package | Monthly Fee | Included Hours | Additional Hour Cost |
| ------- | ----------- | -------------- | -------------------- |
| A       | $9.95       | 10             | $2.00 per hour       |
| B       | $13.95      | 20             | $1.00 per hour       |
| C       | $19.95      | Unlimited      | No additional cost   |

### Instructions
Write a program that calculates a customer’s monthly bill. The program should:
1. Ask the user to enter the letter of the package the customer has purchased (`A`, `B`, or `C`).
2. Ask the user to enter the number of hours that were used.
3. Calculate and display the total charges based on the package and hours used.

### Example Output
```
Enter the package (A, B, or C):
A
Enter the number of hours used:
15
Total charges: $19.95
```


## Exercise - Internet Advertisement

Modify the program you wrote for the Internet Bill exercise so it also calculates and displays:

1. The amount of money Package A customers would save if they purchased Package B.
2. The amount of money Package B customers would save if they purchased Package C.

If there would be no savings, no message should be printed.

### Example Output

```yaml
Enter the package (A, B, or C):
A
Enter the number of hours used:
15
Total charges: $19.95
You would save $5.00 by switching to Package B.
You would save $0.00 by switching to Package C.
```

