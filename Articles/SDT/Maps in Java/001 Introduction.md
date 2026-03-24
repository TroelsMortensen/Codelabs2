# Introduction to Java Maps

A `Map` in Java stores data as **key-value pairs**.

- The **key** is used to look up a value
- Keys are **unique**
- Values can be duplicated

## Why Use a Map?

Use a `Map` when you need fast lookup by an identifier, such as:

- student id -> student name
- country code -> country name
- product id -> product price

With a list, you often loop to find an item. With a `Map`, you can usually access it directly by key.

## Small Example

```java
import java.util.HashMap;
import java.util.Map;

Map<Integer, String> students = new HashMap<>();
students.put(101, "Mia");
students.put(102, "Ethan");

System.out.println(students.get(101)); // Mia
```

In this learning path, you will work with the most useful `Map` operations.
