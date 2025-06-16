# Enums as Integers in Java

In Java, enums are not directly represented as integers, but they can be associated with integer values using fields and constructors.\
By default, enums are objects, and their ordinal position (starting from 0) can be retrieved using the `ordinal()` method.

This means that the first value by default has an ordinal value of 0, the second has 1, and so on. However, you can also define custom integer values for each enum constant.

Each enum constant has a default ordinal value based on its position in the enum declaration.

### Example
```java
public class EnumOrdinalExample {
    public static void main(String[] args) {
        System.out.println(Day.MONDAY + " has ordinal value: " + Day.MONDAY.ordinal());
        System.out.println(Day.TUESDAY + " has ordinal value: " + Day.TUESDAY.ordinal());
        System.out.println(Day.WEDNESDAY + " has ordinal value: " + Day.WEDNESDAY.ordinal());
        System.out.println(Day.THURSDAY + " has ordinal value: " + Day.THURSDAY.ordinal());
    }
}

enum Day {
    MONDAY,
    TUESDAY,
    WEDNESDAY,
    THURSDAY,
    FRIDAY,
    SATURDAY,
    SUNDAY;
}
```

### Output
```
MONDAY has ordinal value: 0
TUESDAY has ordinal value: 1
WEDNESDAY has ordinal value: 2
THURSDAY has ordinal value: 3
```