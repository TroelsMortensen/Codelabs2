# Iterating over a List

Just like the array, there are several ways to iterate (loop) through an ArrayList in Java. The two most common approaches are using a traditional for loop (fori-loop) and an enhanced for loop (for-each loop). Each method has its own advantages and use cases. These were also discussed in the array iteration learning path.

## Method 1: Traditional For Loop (fori-loop)

The traditional for-loop uses an index variable to access each element in the list using the `get(index)` method.

### Syntax
```java
for (int i = 0; i < listName.size(); i++) {
    elementType element = listName.get(i);
    // Process the element
}
```

### Example 1: Basic For Loop Iteration

In this example, we will iterate through a list of fruits and print each fruit along with its index.

```java
import java.util.ArrayList;

public class Main {
    public static void main(String[] args) {
        ArrayList<String> fruits = new ArrayList<>();
        fruits.add("Apple");
        fruits.add("Banana");
        fruits.add("Cherry");
        fruits.add("Date");

        System.out.println("Using traditional for loop:");
        for (int i = 0; i < fruits.size(); i++) {
            String fruit = fruits.get(i);
            System.out.println("Index " + i + ": " + fruit);
        }
    }
}
```

**Output:**
```
Using traditional for loop:
Index 0: Apple
Index 1: Banana
Index 2: Cherry
Index 3: Date
```

## Method 2: Enhanced For Loop (for-each loop)

The enhanced for loop provides a cleaner, more readable syntax when you only need to read the values without modifying them or needing the index.

### Syntax
```java
for (elementType element : listName) {
    // Process the element
}
```

### Example 3: Basic For-Each Loop

In this example, we will iterate through a list of colors and print each color.

```java
import java.util.ArrayList;

public class Main {
    public static void main(String[] args) {
        ArrayList<String> colors = new ArrayList<>();
        colors.add("Red");
        colors.add("Green");
        colors.add("Blue");
        colors.add("Yellow");

        System.out.println("Using enhanced for loop:");
        for (String color : colors) {
            System.out.println("Color: " + color);
        }
    }
}
```

**Output:**
```
Using enhanced for loop:
Color: Red
Color: Green
Color: Blue
Color: Yellow
```

## Comparison: When to Use Each Method

### Use Traditional For Loop When:
- You need access to the **index** of each element
- You want to **modify** elements in the list using `set()`
- You need to **iterate backwards** through the list
- You want to **skip** certain elements based on index
- You need to **compare adjacent** elements

### Use Enhanced For Loop When:
- You only need to **read** the values
- You want **cleaner, more readable** code
- You're processing each element **independently**
- You don't need the index information


## Important Notes

### Enhanced For Loop Limitations
The enhanced for loop has some limitations:
- Cannot modify the original list elements
- Cannot access the current index
- Cannot iterate in reverse order
- Cannot easily skip elements

```java
ArrayList<Integer> numbers = new ArrayList<>();
numbers.add(1);
numbers.add(2);
numbers.add(3);

// This WON'T modify the original list
for (int number : numbers) {
    number = number * 2; // Only changes the local variable, not the list
}
// List still contains [1, 2, 3]

// To modify, use traditional for loop
for (int i = 0; i < numbers.size(); i++) {
    numbers.set(i, numbers.get(i) * 2); // This WILL modify the list
}
// Now list contains [2, 4, 6]
```
