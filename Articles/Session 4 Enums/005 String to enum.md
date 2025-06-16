# Converting a String to an Enum in Java

In Java, you can convert a string to an enum using the `valueOf()` method provided by the `Enum` class.\
This method takes a string and returns the corresponding enum constant, if it exists. If the string does not match any enum constant, you will get an exception, which crashes your program.\
This last part is inconvenient, and we will learn about exceptions later.

### Example
```java
public class StringToEnumExample {
    public static void main(String[] args) {
        String dayString = "MONDAY";

        Day day = Day.valueOf(dayString);

        System.out.println("Converted to enum: " + day);
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

### Explanation
1. **`valueOf()` Method**: Converts the string to the corresponding enum constant.
2. **Case Sensitivity**: The string must match the enum constant exactly, including case.
3. **Error Handling**: Use a `try-catch` block to handle invalid strings. We will cover this towar the end of the course.

### Exercises

#### Exercise 1: Convert Traffic Light String to Enum

Redo the previous traffic light exercise, but now request input from the user instead. Convert the input string to an enum representing the traffic light color. 

Example Output:
```
Enter the traffic light color (RED, YELLOW, GREEN):
RED
Action: Stop
```