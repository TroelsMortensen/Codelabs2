# Conditional operators

The last operators we need are used to combine multiple boolean values into a single boolean value.\
These operators are called _conditional operators_, and they allow us to create complex conditions by combining simpler ones.

In Java, we have three conditional operators:
- `&&`: Logical AND
- `||`: Logical OR
- `!`: Logical NOT

## Logical AND (`&&`)
The logical AND operator (`&&`) checks if both conditions are true. If both conditions are true, the result is true; otherwise, it is false.

Here is an example of how to use the logical AND operator:

```java
boolean condition1 = true;
boolean condition2 = false;
boolean result = condition1 && condition2; // false, because one condition is false
System.out.println("Result of condition1 && condition2: " + result); // Prints false
```

In the above code the value of `result` is `false` because `condition1` is `true`, but `condition2` is `false`.\
The AND operator requires both conditions to be true for the result to be true.

You can also use the logical AND operator with relational operators:

### Exercise

Create a class with a main method. In the main method, declare three integer variables:
```java
int a = 5;
int b = // you pick a value here. Statement: "This value is between a and c."
int c = 15;
```

Then write code which prints out `true` if `a` is less than `b` AND `b` is less than `c`. Otherwise, print out `false`.

<hint title="Solution">

You have multiple ways of solving this exercise. Here is one way to do it:

```java
boolean bIsLargerThanA = (a < b);
boolean bIsSmallerThanC = (b < c);
boolean result = bIsLargerThanA && bIsSmallerThanC;
System.out.println("Is b between a and c? " + result);
```

You can also write it in one line:
```java
boolean result = (a < b) && (b < c);
System.out.println("Is b between a and c? " + result);
```

</hint>

<hint title="Video solution">

<video src="https://youtu.be/kYIexNLNH9I"></video>

</hint>

Try with different values for `b` to see how the result changes.

## Logical OR (`||`)
The logical OR operator (`||`) checks if at least one of the conditions is true. If at least one condition is true, the result is true; otherwise, it is false.


Here is an example of how to use the logical OR operator:
```java
boolean condition1 = true;
boolean condition2 = false;
boolean result = condition1 || condition2; // true, because one condition is true
System.out.println("Result of condition1 || condition2: " + result); // Prints true
```

In the above code, the value of `result` is `true` because `condition1` is `true`, even though `condition2` is `false`.

### Exercise
Create a class with a main method. In the main method, declare three integer variables:
```java
int a = 5;
int b = // you pick a value here. Statement: "This value is not between a and c."
int c = 15;
```

Then write code which prints out `true` if `a` is greater than `b` OR `b` is greater than `c`. Otherwise, print out `false`.

<hint title="Solution">
You have multiple ways of solving this exercise. Here is one way to do it:

```java
boolean bIsSmallerThanA = (b < a);
boolean bIsLargerThanC = (b > c);
boolean result = bIsSmallerThanA || bIsLargerThanC;
System.out.println("Is b not between a and c? " + result);
```
You can also write it in one line:
```java
boolean result = (b < a) || (b > c);
System.out.println("Is b not between a and c? " + result);
```
</hint>
Try with different values for `b` to see how the result changes.


## Logical NOT (`!`)
The logical NOT operator (`!`) negates (flips) a boolean value. If the value is true, it becomes false; if it is false, it becomes true.

Here is an example of how to use the logical NOT operator:

```java
boolean condition = true;
boolean result = !condition; // false, because we negate true
System.out.println("Result of !condition: " + result); // Prints false
```

In the above code, the value of `result` is `false` because we negated `condition`, which was `true`.

## Exercise - Simple weather

Create a class with a main method. In the main method, declare a boolean variable `theTemperatureIsNice`, and an integer variable `theTemperature`.

It is a nice temperature if it is between 15 and 25 degrees Celsius (inclusive).\
Then write code which prints out `It is nice weather` if the temperature is nice, otherwise print out `Not so nice weather`.

Try with different values for `theTemperature` to see how the result changes.

Now add another boolean variable `itIsSunny`, and modify the code to print out `true` if the temperature is nice AND it is sunny. Otherwise, print out `false`.

### Exercise - Complex weather

Now, let's make it a bit more complex.\
Create another boolean variable `itIsSnowing`.

Now, it is a nice weather if:
- the temperature is nice AND it is sunny 
- OR
- it is snowing AND the temperature is between -10 and -2. 

Update the code accordingly to print out `true` if the weather is nice, otherwise print out `false`.

Test with the following values:

| Temperature | itIsSunny | itIsSnowing | Expected Output      | Reason                                        |
| ----------- | --------- | ----------- | -------------------- | --------------------------------------------- |
| 25          | true      | false       | **Nice weather**     | Sunny and temperature in 20–30                |
| 10          | true      | false       | **Not nice weather** | Too cold even though sunny                    |
| -5          | false     | true        | **Nice weather**     | Snowing and temperature between -10 and -2    |
| -11         | false     | true        | **Not nice weather** | Snowing but too cold                          |
| 22          | false     | false       | **Not nice weather** | Temperature is okay, but not sunny or snowing |
| -3          | false     | false       | **Not nice weather** | Cold, but no snow                             |
| 27          | true      | true        | **Nice weather**     | Meets both conditions — still nice            |
| -2          | false     | true        | **Nice weather**     | Edge case for lower snow-temp bound           |
| -10         | false     | true        | **Nice weather**     | Edge case for upper snow-temp bound           |
| 30          | true      | false       | **Nice weather**     | Max of nice temp range and sunny              |

### Exercise - More complex weather

Now, for it to be nice weather, if it is snowing, it _must_ also be sunny.

Update the code accordingly.

And verify using the following values:

| Temperature | itIsSunny | itIsSnowing | Expected Output      | Reason                                            |
| ----------- | --------- | ----------- | -------------------- | ------------------------------------------------- |
| 25          | true      | false       | **Nice weather**     | Sunny and temperature in 20–30                    |
| 10          | true      | false       | **Not nice weather** | Too cold even though sunny                        |
| -5          | true      | true        | **Nice weather**     | Snowing, sunny, and temp between -10 and -2       |
| -5          | false     | true        | **Not nice weather** | Snowing but **not** sunny                         |
| -11         | true      | true        | **Not nice weather** | Too cold, even though it's snowing and sunny      |
| 22          | false     | false       | **Not nice weather** | Temperature is okay, but not sunny or snowing     |
| -3          | false     | false       | **Not nice weather** | Cold and neither sunny nor snowing                |
| 27          | true      | true        | **Nice weather**     | Still sunny and warm enough; snowing doesn't hurt |
| -2          | true      | true        | **Nice weather**     | Edge case for upper snow-temp bound, and sunny    |
| -10         | false     | true        | **Not nice weather** | Temp okay, snowing, but **not sunny**             |
| 30          | true      | false       | **Nice weather**     | Upper bound of nice range and sunny               |


### Exercise - super complex

Now we up the game.

For it to be nice weather, if the temperature is above 15 degrees, it _cannot_ be snowing.\

Update the code accordingly.

And verify using the following values:

| Temperature | itIsSunny | itIsSnowing | Expected Output    | Reason                                         |
| ----------- | --------- | ----------- | ------------------ | ---------------------------------------------- |
| 25          | true      | false       | ✅ Nice weather     | Sunny, temp 25, not snowing                    |
| 25          | true      | true        | ❌ Not nice weather | Temp > 15 and snowing — ❌ invalid              |
| 10          | true      | false       | ❌ Not nice weather | Too cold for nice weather                      |
| -5          | true      | true        | ✅ Nice weather     | Snowing, sunny, and temp in -10 to -2          |
| -5          | false     | true        | ❌ Not nice weather | Snowing and temp okay, but not sunny           |
| -11         | true      | true        | ❌ Not nice weather | Snowing, sunny, but temp too low               |
| 22          | false     | false       | ❌ Not nice weather | Temp okay, but not sunny                       |
| -3          | false     | false       | ❌ Not nice weather | Cold and neither sunny nor snowing             |
| 27          | true      | true        | ❌ Not nice weather | Temp > 15 but snowing — ❌ violates new rule    |
| -2          | true      | true        | ✅ Nice weather     | Edge case — temp = -2, snowing, and sunny      |
| -10         | false     | true        | ❌ Not nice weather | Temp okay, snowing, but not sunny              |
| 30          | true      | false       | ✅ Nice weather     | Upper bound of sunny condition and not snowing |
