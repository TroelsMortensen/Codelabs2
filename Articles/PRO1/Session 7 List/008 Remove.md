# Removing Elements from the List

ArrayList provides two different `remove()` methods to delete elements from the list. Understanding the difference between these methods is crucial for proper list manipulation.

## Remove Methods Overview

1. **`remove(int index)`** - Removes the element at a specific index position
2. **`remove(Object o)`** - Removes the first occurrence of a specific object/value

Both methods shift remaining elements to the left and decrease the list size by 1.

## Method 1: Remove by Index

The `remove(int index)` method removes the element at the specified index position.

### Syntax
```java
listName.remove(index);
```

### Example 1: Remove by Index

In this example, five fruits are added to the list, and then the element at index 2 is removed, i.e. "Cherry".

```java
import java.util.ArrayList;

public class Main {
    public static void main(String[] args) {
        ArrayList<String> fruits = new ArrayList<>();
        fruits.add("Apple");
        fruits.add("Banana");
        fruits.add("Cherry");
        fruits.add("Date");
        fruits.add("Elderberry");

        System.out.println("Before removal: " + fruits);
        
        // Remove element at index 2
        fruits.remove(2);
        
        System.out.println("After removal: " + fruits);
        System.out.println("New size: " + fruits.size());
    }
}
```

**Output:**
```
Before removal: [Apple, Banana, Cherry, Date, Elderberry]
After removal: [Apple, Banana, Date, Elderberry]
New size: 4
```

### Visual Representation: Remove by Index

Before removal:

| Index | 0     | 1      | 2      | 3    | 4          |
|-------|-------|--------|--------|------|------------|
| Value | Apple | Banana | Cherry | Date | Elderberry |

After `fruits.remove(2)` removes "Cherry":

| Index | 0     | 1      | 2    | 3          |
|-------|-------|--------|------|------------|
| Value | Apple | Banana | Date | Elderberry |

Notice how elements after index 2 shift left to fill the gap.

## Method 2: Remove by Object

The `remove(Object o)` method removes the first occurrence of the specified object.

### Syntax
```java
boolean wasRemoved = listName.remove(object);
```

### Example 2: Remove by Object
```java
import java.util.ArrayList;

public class Main {
    public static void main(String[] args) {
        ArrayList<String> colors = new ArrayList<>();
        colors.add("Red");
        colors.add("Blue");
        colors.add("Green");
        colors.add("Blue");  // Duplicate, Blue now exists at indices 1 and 3
        colors.add("Yellow");

        System.out.println("Before removal: " + colors);
        
        // Remove first occurrence of "Blue"
        colors.remove("Blue");
        
        System.out.println("After removal: " + colors);
        
        // Try to remove something that doesn't exist
        colors.remove("Purple");
        System.out.println("After removal again: " + colors);
    }
}
```

**Output:**
```
Before removal: [Red, Blue, Green, Blue, Yellow]
After removal: [Red, Green, Blue, Yellow]
After removal again: [Red, Green, Blue, Yellow]  // No change since "Purple" was not found
```

## A detail
Above, both remove methods were called the same way, for example: `colors.remove("Blue");` and `colors.remove(2);`.

However, both methods actally also return a result:
- `remove(int index)` returns the removed element.
- `remove(Object o)` returns `true` if the element was found and removed, or `false` if it was not found.

First, the remove object method:

```java
import java.util.ArrayList;

public class Main {
    public static void main(String[] args) {
        ArrayList<String> colors = new ArrayList<>();
        colors.add("Red");
        colors.add("Blue");
        colors.add("Green");
        colors.add("Blue");  // Duplicate
        colors.add("Yellow");

        System.out.println("Before removal: " + colors);
        
        // Remove first occurrence of "Blue"
        boolean wasRemoved = colors.remove("Blue");  // Returns true because "Blue" was found and removed
        
        System.out.println("After removal: " + colors);
        System.out.println("Was removed: " + wasRemoved);
        
        // Try to remove something that doesn't exist
        boolean notRemoved = colors.remove("Purple");  // Returns false because "Purple" was not found
        System.out.println("After removal: " + colors);
        System.out.println("Purple removed: " + notRemoved);
    }
}
```

**Output:**
```
Before removal: [Red, Blue, Green, Blue, Yellow]
After removal: [Red, Green, Blue, Yellow]
Was removed: true
After removal: [Red, Green, Blue, Yellow]
Purple removed: false
```

Then, the remove index method:

```java
import java.util.ArrayList;
public class Main {
    public static void main(String[] args) {
        ArrayList<String> colors = new ArrayList<>();
        colors.add("Red");
        colors.add("Blue");
        colors.add("Green");
        colors.add("Blue");  // Duplicate
        colors.add("Yellow");

        System.out.println("Before removal: " + colors);
        
        // Remove element at index 1
        String removedColor = colors.remove(1);  // Returns the removed element
        
        System.out.println("After removal: " + colors);
        System.out.println("Removed element: " + removedColor);
    }
}
```

**Output:**
```
Before removal: [Red, Blue, Green, Blue, Yellow]
After removal: [Red, Green, Blue, Yellow]
Removed element: Blue
```


## Important Differences

### Return Values
- **Remove by index**: Returns the removed element
- **Remove by object**: Returns `true` if element was found and removed, `false` otherwise


## Working with Integer Lists

When working with `ArrayList<Integer>`, be careful about the method overloading:

```java
import java.util.ArrayList;

public class Main {
    public static void main(String[] args) {
        ArrayList<Integer> numbers = new ArrayList<>();
        numbers.add(0);
        numbers.add(1);
        numbers.add(2);
        numbers.add(3);

        System.out.println("Original: " + numbers);
        
        // Remove by index 1
        numbers.remove(1);
        System.out.println("After remove(1) by index: " + numbers);
        
        // Remove by value 1
        numbers.remove(Integer.valueOf(1));
        System.out.println("After remove(1) by value: " + numbers);
    }
}
```

**Output:**
```
Original: [0, 1, 2, 3]
After remove(1) by index: [0, 2, 3]
After remove(1) by value: [0, 2, 3]
```



## Summary

| Method | Parameter | Returns | Use Case |
|--------|-----------|---------|----------|
| `remove(int index)` | Index position | Removed element | When you know the exact position |
| `remove(Object o)` | Object to remove | boolean (success) | When you know the value to remove |

Choose the appropriate method based on whether you know the position or the value of the element you want to remove.

## Exercise: Interactive list

Create a program, which creates a list of strings.

Then, in a loop, ask the user to either add or remove an element from the list. 
- If add, then request which string to add.
- If remove, then request which index to remove.
- If print, then print the current state of the list.
- If exit, then exit the program.

Do this in a while loop, so the user can keep adding or removing until they enter "exit" to stop.