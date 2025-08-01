# Introduction to Enums in Java

Enums in Java are a special data type that represents a group of constants. They are used to define a fixed set of values that a variable can take, making your code more readable and less error-prone.

Remember how the boolean is limited to two values: `true` and `false`? Enums allow you to define a similar concept but with more than two values. 


### Key Features:
- Enums are defined using the `enum` keyword.
- Each value in an enum is a constant and is typically written in uppercase.

### Example:

```java
public class WeekDayEnumExample
{
    public static void main(String[] args)
    {
        Day today = Day.MONDAY;
        System.out.println("Today is: " + today);
    }
}

enum Day
{
    MONDAY,
    TUESDAY,
    WEDNESDAY,
    THURSDAY,
    FRIDAY,
    SATURDAY,
    SUNDAY;
}
```

Notice how the enum here is defined outside of the `{ }` block of the WeekDayEnumExample class. For now this is good enough. In practice, you generally want to define enums in their own file.

### Benefits:
- Enums provide type safety by restricting variables to predefined constants.
- They make code easier to maintain and understand.
- Enums can be used in switch statements for cleaner control flow.

Enums are commonly used for representing states, categories, or options in a program.