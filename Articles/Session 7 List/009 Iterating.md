# Iterating over a List

Just like the array, there are several ways to iterate (loop) through an ArrayList in Java. The two most common approaches are using a traditional for loop (fori-loop) and an enhanced for loop (for-each loop). Each method has its own advantages and use cases.

## Method 1: Traditional For Loop (fori-loop)

The traditional for loop uses an index variable to access each element in the list using the `get(index)` method.

### Syntax
```java
for (int i = 0; i < listName.size(); i++) {
    elementType element = listName.get(i);
    // Process the element
}
```

### Example 1: Basic For Loop Iteration
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

### Example 2: Modifying Elements with For Loop
```java
import java.util.ArrayList;

public class Main {
    public static void main(String[] args) {
        ArrayList<Integer> numbers = new ArrayList<>();
        numbers.add(1);
        numbers.add(2);
        numbers.add(3);
        numbers.add(4);
        numbers.add(5);

        System.out.println("Before modification: " + numbers);

        // Double each number using traditional for loop
        for (int i = 0; i < numbers.size(); i++) {
            int currentValue = numbers.get(i);
            numbers.set(i, currentValue * 2);
        }

        System.out.println("After modification: " + numbers);
    }
}
```

**Output:**
```
Before modification: [1, 2, 3, 4, 5]
After modification: [2, 4, 6, 8, 10]
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

### Example 4: Processing Data with For-Each Loop
```java
import java.util.ArrayList;

public class Main {
    public static void main(String[] args) {
        ArrayList<Double> prices = new ArrayList<>();
        prices.add(19.99);
        prices.add(25.50);
        prices.add(12.75);
        prices.add(8.99);

        System.out.println("Original prices: " + prices);

        double total = 0;
        System.out.println("Prices with tax (25%):");
        for (double price : prices) {
            double priceWithTax = price * 1.25;
            System.out.printf("$%.2f -> $%.2f%n", price, priceWithTax);
            total += priceWithTax;
        }

        System.out.printf("Total with tax: $%.2f%n", total);
    }
}
```

**Output:**
```
Original prices: [19.99, 25.50, 12.75, 8.99]
Prices with tax (25%):
$19.99 -> $24.99
$25.50 -> $31.88
$12.75 -> $15.94
$8.99 -> $11.24
Total with tax: $84.05
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

## Example 5: Backwards Iteration (Traditional For Loop Only)
```java
import java.util.ArrayList;

public class Main {
    public static void main(String[] args) {
        ArrayList<String> words = new ArrayList<>();
        words.add("Hello");
        words.add("World");
        words.add("Java");
        words.add("Programming");

        System.out.println("Forwards iteration:");
        for (int i = 0; i < words.size(); i++) {
            System.out.println(words.get(i));
        }

        System.out.println("\nBackwards iteration:");
        for (int i = words.size() - 1; i >= 0; i--) {
            System.out.println(words.get(i));
        }
    }
}
```

**Output:**
```
Forwards iteration:
Hello
World
Java
Programming

Backwards iteration:
Programming
Java
World
Hello
```

## Example 6: Finding Elements
```java
import java.util.ArrayList;

public class Main {
    public static void main(String[] args) {
        ArrayList<String> students = new ArrayList<>();
        students.add("Alice");
        students.add("Bob");
        students.add("Charlie");
        students.add("Diana");

        String searchName = "Charlie";

        // Using traditional for loop to find index
        System.out.println("Using traditional for loop:");
        for (int i = 0; i < students.size(); i++) {
            if (students.get(i).equals(searchName)) {
                System.out.println(searchName + " found at index " + i);
                break;
            }
        }

        // Using enhanced for loop to check existence
        System.out.println("\nUsing enhanced for loop:");
        boolean found = false;
        for (String student : students) {
            if (student.equals(searchName)) {
                found = true;
                break;
            }
        }
        System.out.println(searchName + (found ? " found" : " not found"));
    }
}
```

**Output:**
```
Using traditional for loop:
Charlie found at index 2

Using enhanced for loop:
Charlie found
```

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
    number = number * 2; // Only changes the local variable
}
// List still contains [1, 2, 3]

// To modify, use traditional for loop
for (int i = 0; i < numbers.size(); i++) {
    numbers.set(i, numbers.get(i) * 2); // This WILL modify the list
}
// Now list contains [2, 4, 6]
```

### Performance Considerations
Both loop types have similar performance for ArrayList iteration. Choose based on your needs:
- **Readability**: Enhanced for loop is often cleaner
- **Functionality**: Traditional for loop is more flexible
- **Debugging**: Traditional for loop provides index information

## Summary

| Feature | Traditional For Loop | Enhanced For Loop |
|---------|---------------------|-------------------|
| Access to index | ✅ Yes | ❌ No |
| Modify elements | ✅ Yes (using set()) | ❌ No |
| Backwards iteration | ✅ Yes | ❌ No |
| Skip elements | ✅ Easy | ⚠️ Requires conditions |
| Code readability | ⚠️ More verbose | ✅ Clean and simple |
| Best for | Modification, indexing | Reading values only |

Choose the appropriate iteration method based on what you need to accomplish with your list elements.
