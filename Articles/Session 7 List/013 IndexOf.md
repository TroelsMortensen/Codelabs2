
# The `indexOf` Method on Lists in Java

The `indexOf` method returns the index of the first occurrence of a specified element in a list. If the element is not found, it returns `-1`.

## Syntax

```java
list.indexOf(element)
```

## Example 1: Finding the Index of a String

This example shows how to find the index of a string in a list. If the string is not found, -1 is returned.

```java
import java.util.ArrayList;

public class IndexOfExample {
    public static void main(String[] args) {
        ArrayList<String> names = new ArrayList<>();
        names.add("Alice");
        names.add("Bob");
        names.add("Charlie");

        System.out.println(names.indexOf("Bob"));      // 1
        System.out.println(names.indexOf("Diana"));    // -1
    }
}
```

## Example 2: Finding the Index of a Number

This example demonstrates finding the index of a number in a list. If the number is not present, -1 is returned.

```java
import java.util.ArrayList;

public class IndexOfNumberExample {
    public static void main(String[] args) {
        ArrayList<Integer> numbers = new ArrayList<>();
        numbers.add(10);
        numbers.add(20);
        numbers.add(30);

        System.out.println(numbers.indexOf(20));    // 1
        System.out.println(numbers.indexOf(40));    // -1
    }
}
```

## Example 3: Duplicate Elements

This example shows that if a list contains duplicate elements, indexOf returns the index of the first occurrence only.

```java
import java.util.ArrayList;

public class IndexOfDuplicateExample {
    public static void main(String[] args) {
        ArrayList<String> colors = new ArrayList<>();
        colors.add("red");
        colors.add("blue");
        colors.add("green");
        colors.add("blue");
        colors.add("yellow");

        System.out.println(colors.indexOf("blue"));   // 1 (first occurrence)
        System.out.println(colors.indexOf("yellow")); // 4
    }
}
```

// Even though "blue" appears twice, indexOf returns the index of the first occurrence only.

---

## Exercise 0

Redo Exercise 1 from the previous page, but instead of checking if the list contains "banana", print the index of "banana" in the list using `indexOf`. What happens if you search for a fruit that is not in the list?


## Exercise 1: Find all indices

Write a program that finds all indices of a specific element in a list. For example, if the list is `[1, 2, 3, 2, 4]` and you search for `2`, the output should be `1, 3`.

## Exercise 2: All indices in a list

In the previous exercise, you probably just looped over the list, and printed out, whenever you found the element. Now:
1. First loop over the list, and collect all indices of the element in a separate list.
2. Then loop over that second list and print the indices.