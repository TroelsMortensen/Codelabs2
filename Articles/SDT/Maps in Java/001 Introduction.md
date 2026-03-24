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

## Generic type parameters

When you declare a `Map`, you can specify the type of the keys and the values. That's the information between the `< >` in the declaration.

In the above example, the `Map` is declared as `Map<Integer, String>`, which means that the keys are of type `Integer` and the values are of type `String`. You can use any type you want, as long as it is a valid type in Java.

Here are a few examples of valid type parameters:
- `Map<String, String>` - keys are strings, values are strings
- `Map<Integer, Double>` - keys are integers, values are doubles
- `Map<String, Integer>` - keys are strings, values are integers
- `Map<String, Person>` - keys are strings, values are objects
- `Map<String, List<String>>` - keys are strings, values are lists of strings


In this learning path, you will work with the most useful `Map` operations.
