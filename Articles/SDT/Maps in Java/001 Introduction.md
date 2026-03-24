# Introduction to Java Maps

A `Map` in Java stores data as **key-value pairs**.

- The **key** is used to look up a value
- Keys are **unique**
- Values can be duplicated

Think of this like a phone book, or a dictionary. You look up a word (key), and get the definition (value).

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

Notice in the above example that the `Map` is an interface, and we are using a concrete implementation of it, the `HashMap` class. There are other implementations of the `Map` interface, such as `TreeMap` and `LinkedHashMap`. For most cases, the `HashMap` is a good default choice.

In this learning path, you will work with the most useful `Map` operations.
