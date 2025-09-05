# Exercise - Comparing doubles

Write a program, which asks the user to enter two decimal numbers (`double`) 

Print out `true` if the two numbers are the same up to three decimal places, and `false` otherwise.

Example Output:
```yaml
Enter first number:     5.123456
Enter second number:    5.123
The numbers are the same up to three decimal places: true
```

```yaml
Enter first number:     5.123456
Enter second number:    5.1237
The numbers are the same up to three decimal places: true
```

```yaml
Enter first number:     5.123456
Enter second number:    5.124
The numbers are the same up to three decimal places: false
```

```yaml
Enter first number:     4.124
Enter second number:    5.124
The numbers are the same up to three decimal places: false
```

<hint title="Hint 0">
Consider converting the numbers to strings and comparing the relevant parts.
</hint>


<hint title="Hint 1">
You can perhaps use the `chartAt()` method.
</hint>

<hint title="Hint 2">
You can also use `substring()` to extract the relevant part of the numbers.
</hint>


## Follow up Exercise

What should happen if either number has less than three decimal places?
