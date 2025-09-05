# Exercise - Is it a Leap Year?

To determine if a year is a leap year, follow these rules:

1. A year is a leap year if it is divisible by 4.
2. However, if the year is a centurial year (e.g., 1900, 2000), it must also be divisible by 400 to be a leap year.

You will probably need the module operator: `%`.\
Example:

```java
int remainder = 10 % 3; // 1
```


### Summary of Rules:
- **Divisible by 4**: Leap year.
- **Divisible by 100 but not by 400**: Not a leap year.
- **Divisible by 400**: Leap year.

### Examples:
- **2024**: Leap year (divisible by 4).
- **2000**: Leap year (divisible by 4 and 400).
- **1900**: Not a leap year (divisible by 100 but not by 400).
- **2100**: Not a leap year (centurial year and not divisible by 400).


Write a program that asks the user to enter a year and then determines if it is a leap year or not.

### Hint
For quicker testing, instead of re-running the program, and try new values, you can create a "helper method", and call it several times with different years, from the main method.

```java
public class LeapYearChecker
{
    public static void main(String[] args) {
        checkLeapYear(2024);
        checkLeapYear(2000);
        checkLeapYear(1900);
        checkLeapYear(2100);
    }

    static void checkLeapYear(int year) {
        // Your code here
    }
}