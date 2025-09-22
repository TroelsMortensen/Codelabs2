# Replacing Elements in the List

The `set(int index, E element)` method is used to _replace_ an existing element at a specific position in an ArrayList. Unlike arrays where you can directly assign values using square brackets, ArrayLists use the `set()` method to modify existing elements.

## Syntax

```java
listName.set(index, newElement);
```

The `set()` method:
- Takes an integer index and the new element as parameters
- Replaces the element at the specified index with the new element
- Throws an `IndexOutOfBoundsException` if the index is invalid (negative or >= size)

## Example 1: Basic Set Operation

```java
import java.util.ArrayList;

public class Main {
    public static void main(String[] args) {
        ArrayList<String> fruits = new ArrayList<>();
        fruits.add("Apple");
        fruits.add("Banana");
        fruits.add("Cherry");
        fruits.add("Date");

        System.out.println("Before replacement: " + fruits);

        // Replace element at index 1
        fruits.set(1, "Blueberry");
        
        System.out.println("After replacement: " + fruits);
    }
}
```

**Output:**
```
Before replacement: [Apple, Banana, Cherry, Date]
After replacement: [Apple, Blueberry, Cherry, Date]
```

## Visual Representation

Here's how the replacement works:

Before replacement:

| Index | 0     | 1      | 2      | 3    |
|-------|-------|--------|--------|------|
| Value | Apple | Banana | Cherry | Date |

After `fruits.set(1, "Blueberry")`:

| Index | 0     | 1         | 2      | 3    |
|-------|-------|-----------|--------|------|
| Value | Apple | Blueberry | Cherry | Date |



## Important Notes

### Set vs Add
- `set()` **replaces** an existing element - the list size stays the same
- `add()` **adds** a new element - the list size increases

```java
ArrayList<String> colors = new ArrayList<>();
colors.add("Red");    // Size becomes 1: [Red]
colors.add("Green");  // Size becomes 2: [Red, Green]
colors.set(0, "Blue"); // Size stays 2: [Blue, Green]
```

### Index Bounds
The index must be valid (0 to size-1). You cannot use `set()` to add elements beyond the current size:

```java
ArrayList<String> list = new ArrayList<>();
list.add("First");
// list.set(1, "Second"); // This would throw IndexOutOfBoundsException!
list.add("Second"); // Correct way to add at index 1
```



## Comparison: Array vs ArrayList Replacement

```java
// Array replacement
String[] array = {"A", "B", "C"};
array[1] = "X"; // Direct assignment

// ArrayList replacement
ArrayList<String> list = new ArrayList<>();
list.add("A");
list.add("B");
list.add("C");
list.set(1, "X"); // Method call
```

Both achieve the same result, but the syntax differs.

## Exercise 1: Grade Update System

Create an ArrayList with 5 student grades (integers between 60-100). Display the original grades, then ask the user to select a student number (1-5) and enter a new grade. Replace the grade at that position and display the updated list. This must be done in a loop so the user can continue editing until they choose to exit. Remember to convert the user's 1-based input to 0-based indexing.

### Example Output:
```
Original grades: [85, 72, 91, 68, 95]
Enter student number (1-5) or 0 to exit: 3
Enter new grade: 88
Updated grades: [85, 72, 88, 68, 95]
Grade for student 3 changed from 91 to 88

Enter student number (1-5) or 0 to exit: 1
Enter new grade: 90
Updated grades: [90, 72, 88, 68, 95]
Grade for student 1 changed from 85 to 90

Enter student number (1-5) or 0 to exit: 0
Goodbye!
```

<hint title="Solution">

```java
import java.util.ArrayList;
import java.util.Scanner;

public class GradeUpdateSystem {
    public static void main(String[] args) {
        ArrayList<Integer> grades = new ArrayList<>();
        grades.add(85);
        grades.add(72);
        grades.add(91);
        grades.add(68);
        grades.add(95);
        
        Scanner scanner = new Scanner(System.in);
        
        System.out.println("Original grades: " + grades);
        
        while (true) {
            System.out.print("Enter student number (1-5) or 0 to exit: ");
            int studentNumber = scanner.nextInt();
            
            if (studentNumber == 0) {
                System.out.println("Goodbye!");
                break;
            }
            
            if (studentNumber >= 1 && studentNumber <= 5) {
                System.out.print("Enter new grade: ");
                int newGrade = scanner.nextInt();
                
                int index = studentNumber - 1; // Convert to 0-based index
                int oldGrade = grades.set(index, newGrade);
                
                System.out.println("Updated grades: " + grades);
                System.out.println("Grade for student " + studentNumber + " changed from " + oldGrade + " to " + newGrade);
                System.out.println();
            } else {
                System.out.println("Invalid student number!");
            }
        }
        
        scanner.close();
    }
}
```

</hint>


## Exercise 2: String Case Converter

Create an ArrayList with 6 words (mix of lowercase and uppercase). Write a program that:
1. Displays the original list
2. Asks the user to select which word to modify (by index or position)
3. Asks the user to choose an operation: "upper" (convert to uppercase) or "lower" (convert to lowercase)
4. Uses the `set()` method to replace only that specific string with its converted version
5. Displays the final list

### Example Output:
```
Original words: [hello, WORLD, Java, CODE, programming, FUN]
Enter word position (0-5): 2
Choose operation (upper/lower): upper
Updated words: [hello, WORLD, JAVA, CODE, programming, FUN]
Word at position 2 changed from 'Java' to 'JAVA'
```

<hint title="Hint 1">

Use the `toUpperCase()` and `toLowerCase()` methods on strings:
- `string.toUpperCase()` converts a string to all uppercase
- `string.toLowerCase()` converts a string to all lowercase

</hint>

<hint title="Solution">

```java
import java.util.ArrayList;
import java.util.Scanner;

public class StringCaseConverter {
    public static void main(String[] args) {
        ArrayList<String> words = new ArrayList<>();
        words.add("hello");
        words.add("WORLD");
        words.add("Java");
        words.add("CODE");
        words.add("programming");
        words.add("FUN");
        
        Scanner scanner = new Scanner(System.in);
        
        System.out.println("Original words: " + words);
        System.out.print("Enter word position (0-" + (words.size() - 1) + "): ");
        int position = scanner.nextInt();
        scanner.nextLine(); // Consume newline
        
        if (position >= 0 && position < words.size()) {
            System.out.print("Choose operation (upper/lower): ");
            String operation = scanner.nextLine();
            
            String currentWord = words.get(position);
            String newWord;
            
            if (operation.equals("upper")) {
                newWord = currentWord.toUpperCase();
                words.set(position, newWord);
                System.out.println("Updated words: " + words);
                System.out.println("Word at position " + position + " changed from '" + currentWord + "' to '" + newWord + "'");
            } else if (operation.equals("lower")) {
                newWord = currentWord.toLowerCase();
                words.set(position, newWord);
                System.out.println("Updated words: " + words);
                System.out.println("Word at position " + position + " changed from '" + currentWord + "' to '" + newWord + "'");
            } else {
                System.out.println("Invalid operation! Choose 'upper' or 'lower'.");
            }
        } else {
            System.out.println("Invalid position!");
        }
        
        scanner.close();
    }
}
```

</hint>