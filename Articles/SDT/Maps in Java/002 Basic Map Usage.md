# Basic Map Usage

Let's start with the two most important methods: `put()` and `get()`.

## `put(key, value)`

`put()` adds a new key-value pair to the map.

```java
import java.util.HashMap;
import java.util.Map;

Map<Integer, String> students = new HashMap<>();

students.put(1, "Luna");
students.put(2, "Noah");
students.put(3, "Ava");
```

## `get(key)`

`get()` returns the value for a given key.

```java
String studentName = students.get(2);
System.out.println(studentName); // Noah
```

If the key does not exist, `get()` returns `null`.

```java
System.out.println(students.get(999)); // null
```

