# The `charAt()` Method in Java

The `charAt()` method is a built-in function in Java that allows you to access a specific character in a string by its position (index). The index starts at 0, meaning the first character is at position 0, the second character is at position 1, and so on.

## Example Table

Here is an example of how the `charAt()` method works with a word:

| H | e | l | l | o |
|---|---|---|---|---|
| 0 | 1 | 2 | 3 | 4 |

Each letter in the word "Hello" is placed in a cell, and the row below shows the index of each character. The `charAt()` method allows you to access these characters using their index.

### Syntax:
```java
char character = myString.charAt(index);
```

- **`String`**: The string you want to access.
- **`index`**: The position of the character you want to retrieve. Some number strictly less than the length of the string.

### Example:
```java
String word = "Hello";
char firstChar = word.charAt(0);
char thirdChar = word.charAt(2);

System.out.println("The first character is: " + firstChar);
System.out.println("The third character is: " + thirdChar);
```

### Output:
```
The first character is: H
The third character is: l
```

# Exercises

### Exercise 1: Access a Character
Write a program that asks the user to enter a word and an index. Use the `charAt()` method to retrieve the character at the specified index and display it.

Example Output:
```
Enter a word: Programming
Enter an index: 4
The character at index 4 is: r
```

<hint title="Solution">

```java
import java.util.Scanner;

public class AccessCharacter {
    public static void main(String[] args) {
        Scanner scanner = new Scanner(System.in);

        System.out.print("Enter a word: ");
        String word = scanner.nextLine();

        System.out.print("Enter an index: ");
        int index = scanner.nextInt();

        char character = word.charAt(index);
        System.out.println("The character at index " + index + " is: " + character);

        scanner.close();
    }
}
```

</hint>

### Exercise 2: First and Last Characters
Write a program that asks the user to enter a word. Use the `charAt()` method to retrieve the first and last characters of the word and display them.

Example Output:
```
Enter a word: Java
The first character is: J
The last character is: a
```

<hint title="Hint 1">
Remember, you can use the `length()` method to find the total number of characters in a string. The last character's index is always `length - 1`.
</hint>

<hint title="Solution">

```java
import java.util.Scanner;

public class FirstAndLastCharacters {
    public static void main(String[] args) {
        Scanner scanner = new Scanner(System.in);

        System.out.print("Enter a word: ");
        String word = scanner.nextLine();

        char firstChar = word.charAt(0);
        char lastChar = word.charAt(word.length() - 1);

        System.out.println("The first character is: " + firstChar);
        System.out.println("The last character is: " + lastChar);

        scanner.close();
    }
}
```

</hint>

### Exercise 3: Accessing an Invalid Index

Revisit exercise 1. What happens if the index is outside the string's length?

For example, if you enter a word "Hello" and an index of 10, what happens?


<hint title="Solution">
You will encounter a `StringIndexOutOfBoundsException`. This exception occurs when you try to access an index that is not valid for the string.

You should see your program crash with an error message like this:
```
Exception in thread "main" java.lang.StringIndexOutOfBoundsException: String index out of range: 10
```

</hint>
