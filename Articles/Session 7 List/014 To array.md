
# The `toArray()` Method on Lists in Java

The `toArray()` method is used to convert a list to an array. This is useful when you need to work with array-based APIs or want to process the elements as an array.

## Syntax

```java
Object[] arr = list.toArray();
// or, for a specific type:
String[] arr = list.toArray(new String[0]);
```

## Example 1: Convert a List of Strings to an Array

This example shows how to convert an `ArrayList<String>` to a `String[]` array.

```java
import java.util.ArrayList;

public class ToArrayExample {
    public static void main(String[] args) {
        ArrayList<String> fruits = new ArrayList<>();
        fruits.add("apple");
        fruits.add("banana");
        fruits.add("orange");

        String[] fruitArray = fruits.toArray(new String[0]);

        for (String fruit : fruitArray) {
            System.out.println(fruit);
        }
    }
}
```


