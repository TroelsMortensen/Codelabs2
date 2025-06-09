# The `trim()` Method in Java

The `trim()` method is a built-in function in Java that removes any leading and trailing whitespace from a string. Whitespace includes spaces, tabs, and newline characters at the beginning or end of the string.\
The method does not change the original string, but returns a _new_ string with the whitespace removed.

This is useful when you want to clean up user input or data that may have extra spaces before or after the actual content.

## Syntax
```java
String trimmedString = originalString.trim();
```

## Example 1: Removing Leading and Trailing Spaces
```java
String text = "   Hello, World!   ";
String trimmed = text.trim();
System.out.println("Before: [" + text + "]");
System.out.println("After:  [" + trimmed + "]");
```

Output:
```
Before: [   Hello, World!   ]
After:  [Hello, World!]
```

## Example 2: Trimming User Input
```java
Scanner scanner = new Scanner(System.in);
System.out.print("Enter your name: ");
String name = scanner.nextLine();
String trimmedName = name.trim();
System.out.println("Hello, " + trimmedName + "!");
```

# Exercises

### Exercise 1: Trim User Input
Write a program that asks the user to enter a word with spaces before and after it. Use the `trim()` method to remove the spaces and display the cleaned word.

Example Output:
```
Enter a word:
    banana   
Trimmed word: banana
```

<hint title="Solution">

```java
import java.util.Scanner;

public class TrimUserInput {
    public static void main(String[] args) {
        Scanner scanner = new Scanner(System.in);
        System.out.print("Enter a word: ");
        String word = scanner.nextLine();
        String trimmed = word.trim();
        System.out.println("Trimmed word: " + trimmed);
    }
}
```

</hint>

### Exercise 2: Compare Trimmed Strings
Write a program that asks the user to enter two words. Trim both words and check if they are equal. Display the result.

Example Output:
```
Enter the first word:
   apple  
Enter the second word:
 apple
Are the trimmed words equal? true
```

<hint title="Solution">

```java
import java.util.Scanner;

public class CompareTrimmedStrings {
    public static void main(String[] args) {
        Scanner scanner = new Scanner(System.in);
        System.out.print("Enter the first word: ");
        String first = scanner.nextLine();
        System.out.print("Enter the second word: ");
        String second = scanner.nextLine();
        boolean areEqual = first.trim().equals(second.trim());
        System.out.println("Are the trimmed words equal? " + areEqual);
    }
}
```

</hint>
