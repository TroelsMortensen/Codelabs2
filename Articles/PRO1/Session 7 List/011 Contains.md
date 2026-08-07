
# The `contains` Method on Lists in Java

The `contains` method checks if a list contains a specific element. It returns `true` if the element is found, and `false` otherwise.

## Syntax

```java
boolean wasFound = list.contains(element)
```

## Example 1: Checking for a String

This example shows how to check if a list contains a specific string.

```java
import java.util.ArrayList;

public class ContainsExample {
    public static void main(String[] args) {
        ArrayList<String> names = new ArrayList<>();
        names.add("Alice");
        names.add("Bob");
        names.add("Charlie");

        System.out.println(names.contains("Bob"));      // true
        System.out.println(names.contains("Diana"));    // false
    }
}
```

## Example 2: Checking for a Number

This example shows how to check if a list contains a specific number.

```java
import java.util.ArrayList;

public class ContainsNumberExample {
    public static void main(String[] args) {
        ArrayList<Integer> numbers = new ArrayList<>();
        numbers.add(10);
        numbers.add(20);
        numbers.add(30);

        System.out.println(numbers.contains(20));    // true
        System.out.println(numbers.contains(40));    // false
    }
}
```

## Exercise: Check if a List Contains an Element
Redo the exercise on the previous page, but this time use the `contains` method to check if the list contains a specific element.


