# Nested if-statements

Nested if-statements allow you to place one if-statement inside the body of another if-statement. This is useful when you need to check multiple conditions that depend on each other.

## How It Works
When an outer if-statement evaluates to `true`, the program executes its body, which can contain another if-statement. The inner if-statement is only evaluated if the outer condition is `true`.

## Example 1: Checking Multiple Conditions
```java
int age = 20;
boolean hasID = true;

if (age >= 18) 
{
    if (hasID) 
    {
        System.out.println("You are allowed to enter.");
    } 
    else
     {
        System.out.println("You need an ID to enter.");
    }
} 
else 
{
    System.out.println("You are not old enough to enter.");
}
```

### Explanation:
1. The outer `if (age >= 18)` checks if the person is 18 or older.
2. If `true`, the inner `if (hasID)` checks if the person has an ID.
3. Depending on the result of the inner condition, a different message is printed.

## Example 2: Grading System
```java
int score = 85;

if (score >= 60) 
{
    System.out.println("You passed.");
    if (score >= 90) 
    {
        System.out.println("Excellent work!");
    } 
    else if (score >= 75) 
    {
        System.out.println("Good job!");
    } 
    else 
    {
        System.out.println("You can do better.");
    }
} 
else 
{
    System.out.println("You failed.");
}
```

Yes, this is the same example as on the previous page, just more convoluted, because of the nested if-structures. Generally, we want to avoid nesting if possible, it will make your code cleaner.

### Explanation:
1. The outer `if (score >= 60)` checks if the score is a passing grade.
2. If `true`, the inner if-else structure evaluates the specific range of the score and prints an appropriate message.

Nested if-statements are a powerful way to handle complex decision-making in your programs. However, be cautious of creating too many levels of nesting, as it can make your code harder to read and maintain.

## Avoiding Deep Nesting
Generally, if you start nesting your if-statements, your code quickly becomes harder to read. If you find yourself nesting too deeply, consider using logical operators (`&&`, `||`) or refactoring your code into separate methods to keep it clean and understandable.

For example, the first example from above could be simplified using logical operators:

```java
int age = 20;
boolean hasID = true;
if (age >= 18 && hasID) 
{
    System.out.println("You are allowed to enter.");
} 
else if (age < 18) 
{
    System.out.println("You are not old enough to enter.");
} 
else 
{
    System.out.println("You need an ID to enter.");
}
```
