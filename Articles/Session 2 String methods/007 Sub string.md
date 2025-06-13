# The `substring()` Method in Java


The `substring()` method is a built-in function in Java that allows you to extract a portion of a string. 

You specify the starting index and optionally the ending index, and the method returns the part of the string between those indices.\
This means there are two ways to use the `substring()` method: one that takes only a starting index and another that takes both a starting and an ending index.

### Syntax:
```java
String subString = myString.substring(startIndex);
String subString = myString.substring(startIndex, endIndex);
```

- **`startIndex`**: The position where the substring starts (inclusive).
- **`endIndex`**: The position where the substring ends (exclusive). If omitted, the substring continues to the end of the string.

### Example:
```java
String word = "Programming";
String sub1 = word.substring(0, 6); // Extracts "Progra"
String sub2 = word.substring(6);   // Extracts "mming"

System.out.println("Substring 1: " + sub1);
System.out.println("Substring 2: " + sub2);
```

### Output:
```
Substring 1: Progra
Substring 2: mming
```

# Exercises

### Exercise 1: Extract from Start Index
Write a program that asks the user to enter a word and a starting index. Use the `substring()` method to extract the portion of the word starting from the given index and display it.

Example Output:
```
Enter a word: Programming
Enter the start index: 6
The substring is: mming
```

<hint title="Solution">

```java
import java.util.Scanner;

public class ExtractFromStartIndex {
    public static void main(String[] args) {
        Scanner scanner = new Scanner(System.in);

        System.out.print("Enter a word: ");
        String word = scanner.nextLine();

        System.out.print("Enter the start index: ");
        int startIndex = scanner.nextInt();

        String subString = word.substring(startIndex);
        System.out.println("The substring is: " + subString);

        scanner.close();
    }
}
```

</hint>

### Exercise 2: Extract a Substring

Write a program that asks the user to enter a word or sentence and two indices.\
Use the `substring()` method to extract the portion of the word between the two indices and display it.

Example Output:
```
Enter a word: Programming
Enter the start index: 0
Enter the end index: 6
The substring is: Progra
```

<hint title="Solution">

```java
import java.util.Scanner;

public class ExtractSubstring {
    public static void main(String[] args) {
        Scanner scanner = new Scanner(System.in);

        System.out.print("Enter a word: ");
        String word = scanner.nextLine();

        System.out.print("Enter the start index: ");
        int startIndex = scanner.nextInt();

        System.out.print("Enter the end index: ");
        int endIndex = scanner.nextInt();

        String subString = word.substring(startIndex, endIndex);
        System.out.println("The substring is: " + subString);

        scanner.close();
    }
}
```
</hint>

What happens if you the start index is greater than the end index?

### Exercise 3: Split and Transform
Write a program that asks the user to enter a word or sentence and two indices. The program should output the first part (before the first index) in lowercase, the part between the indices in uppercase, and the last part (after the second index) in lowercase.

Example Output:
```
Enter a word: Programming
Enter the first index: 3
Enter the second index: 6
Transformed output: proGRAMming
```

<hint title="Hint 1">
You will need three `String` variables to hold the three parts of the word: before the first index, between the indices, and after the second index.

Use `toLowerCase()` and `toUpperCase()` methods to transform them as needed.

Then concatenate the three parts to form the final output, using the `+` operator.
  
</hint>

<hint title="Solution">

```java
import java.util.Scanner;

public class SplitAndTransform {
    public static void main(String[] args) {
        Scanner scanner = new Scanner(System.in);

        System.out.print("Enter a word: ");
        String word = scanner.nextLine();

        System.out.print("Enter the first index: ");
        int firstIndex = scanner.nextInt();

        System.out.print("Enter the second index: ");
        int secondIndex = scanner.nextInt();

        // Extract parts of the string
        String part1 = word.substring(0, firstIndex);
        String part2 = word.substring(firstIndex, secondIndex);
        String part3 = word.substring(secondIndex);

        // Modify parts of the string
        String modifiedPart1 = part1.toLowerCase();
        String modifiedPart2 = part2.toUpperCase();
        String modifiedPart3 = part3.toLowerCase();

        // Combine the modified parts
        System.out.println("Transformed output: " + modifiedPart1 + modifiedPart2 + modifiedPart3);

        scanner.close();
    }
}
```

</hint>

