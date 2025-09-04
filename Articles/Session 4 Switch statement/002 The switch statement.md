# The Traditional Switch Statement

The `switch` statement in Java is a control structure that allows you to execute one block of code out of many based on the value of a variable or expression. It is often used as an alternative to a sequence of `if-else` statements when you need to compare a single value against multiple possible cases.

## How It Works
The `switch` statement evaluates the value of an expression and matches it against a list of cases. If a match is found, the code block associated with that case is executed. If no match is found, the `default` case (if provided) is executed.

### Syntax
```java
switch (expression) {
    case value1:
        // Code to execute if expression equals value1
        break;
    case value2:
        // Code to execute if expression equals value2
        break;
    ...
    default:
        // Code to execute if no case matches
}
```

### Key Points:
- **Expression**: The value being tested. It must be of type `byte`, `short`, `int`, `char`, `String`, or an `enum`.
- **Case**: Each case specifies a value to compare against the expression.
- **Break**: Prevents the execution from "falling through" to the next case. More on this later.
- **Default**: Optional. Executes if no other case matches. Similar to the `else` block in an `if-else` structure.

## Example 1: Basic Usage
```java
public class SwitchExample {
    public static void main(String[] args) {
        int day = 3;

        switch (day) {
            case 1:
                System.out.println("Monday");
                break;
            case 2:
                System.out.println("Tuesday");
                break;
            case 3:
                System.out.println("Wednesday");
                break;
            case 4:
                System.out.println("Thursday");
                break;
            case 5:
                System.out.println("Friday");
                break;
            default:
                System.out.println("Weekend");
        }
    }
}
```

### Output:
```yaml
Wednesday
```

## Example 2: Using Strings
```java
public class SwitchWithStrings 
{
    public static void main(String[] args) 
    {
        String fruit = "Apple";

        switch (fruit) {
            case "Apple":
                System.out.println("You chose Apple.");
                break;
            case "Banana":
                System.out.println("You chose Banana.");
                break;
            case "Cherry":
                System.out.println("You chose Cherry.");
                break;
            default:
                System.out.println("Unknown fruit.");
        }
    }
}
```

### Output:
```yaml
You chose Apple.
```

## Example 3: Fall-Through Behavior
If you omit the `break` statement, execution will "fall through" to the next case.

This means that when the first match is found, that statement is executed, and then all subsequent cases are executed until a `break` is encountered or the switch statement ends. This can be useful in certain scenarios but can also lead to unintended behavior if not handled carefully. Personally, I try to avoid it.

```java
public class FallThroughExample 
{
    public static void main(String[] args) 
    {
        int number = 2;

        switch (number) 
        {
            case 1:
                System.out.println("One");
            case 2:
                System.out.println("Two");
            case 3:
                System.out.println("Three");
            default:
                System.out.println("Default");
        }
    }
}
```

### Output:
```
Two
Three
Default
```



