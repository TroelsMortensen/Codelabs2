# MyDate Exercise (Simplified Date Class)

Implement a simplified `MyDate` class to represent a calendar date.\
Provide multiple constructors, common instance methods, and a few static utility methods. Write a small `main` program to interactively create and manipulate dates and to validate your implementation.

Below is a class diagram for the `MyDate` class.

Some methods, e.g. `plus...()` are complicated, you may want to save these for the end.

No validation is expected, as you have not yet learned about exceptions. Just assume the user will input valid values.

```mermaid
classDiagram
    class MyDate {
        - int year
        - int month
        - int day
        + MyDate()
        + MyDate(int year, int month, int day)
        + MyDate(MyDate other)
        + getYear() int
        + getMonth() int
        + getDay() int
        + setYear(int y) void
        + setMonth(int m) void
        + setDay(int d) void
        + isLeapYear() boolean
        + lengthOfMonth() int
        + plusDays(int n) void
        + plusMonths(int n) void
        + plusYears(int n) void
        + equals(Object o) boolean [override]
        + hashCode() int [override]
        + toString() String [override]
        + copy() MyDate
        + isLeapYear(int y) boolean$
        + daysBetween(MyDate a, MyDate b) int$
        + now() MyDate$
    }
```

**Fields**

- `year: int`
- `month: int` (1–12)
- `day: int` (1–28/29/30/31 depending on month)

**Constructors**

- `MyDate()` → today (use system date)
- `MyDate(int year, int month, int day)` → validate inputs
- `MyDate(MyDate other)` → copy constructor

**Instance methods**

You can see a couple of instance methods.

First, you have the accessors for the fields: `getYear()`, `getMonth()`, `getDay()`.

Then the mutator methods: `setYear(int y)`, `setMonth(int m)`, `setDay(int d)` which modify the instance fields directly.

The `isLeapYear()` method. It should return `true` if the year of the instance is a leap year, and `false` otherwise.

The `lengthOfMonth()` method should return the number of days in the month of the instance.

Three `plus...` methods. They should modify the current instance by adding the specified number of days, months, or years to the current date. These are mutating methods with `void` return type.

The `copy()` method should return a new `MyDate` instance that is a copy of the current instance.

And finally override the three methods from Object: `equals(Object o)`, `hashCode()`, `toString()`.

**Static utility methods**

- `now(): MyDate` → create a new MyDate instance with today's date
- `isLeapYear(int y): boolean` → return `true` if the year is a leap year, and `false` otherwise.
- `daysBetween(MyDate a, MyDate b): int` → return the number of days between two dates