# The `toUpperCase()` and `toLowerCase()` Methods in Java


The `toUpperCase()` and `toLowerCase()` methods are built-in functions in Java that allow you to change the case of letters in a string.

- **`toUpperCase()`**: Converts all the letters in a string to uppercase. For example, "hello" becomes "HELLO".
- **`toLowerCase()`**: Converts all the letters in a string to lowercase. For example, "HELLO" becomes "hello".

These methods are useful when you need to standardize the case of text, such as for comparisons or formatting.

Remember, "Hello" and "hello" are considered different strings in Java, because the equals() method is case-sensitive. Using `toUpperCase()` or `toLowerCase()` can help you avoid issues with case sensitivity when comparing strings.

## How Do They Work?

Here is how you can use these methods:

```java
String original = "Hello, World!";
String upper = original.toUpperCase();
String lower = original.toLowerCase();

System.out.println("Original: " + original);
System.out.println("Uppercase: " + upper);
System.out.println("Lowercase: " + lower);
```

### Explanation:
1. **Create a String**: In the example above, we create a string called `original` with the value "Hello, World!".
2. **Call `toUpperCase()`**: We use `original.toUpperCase()` to convert the string to uppercase.
3. **Call `toLowerCase()`**: We use `original.toLowerCase()` to convert the string to lowercase.
4. **Print the Results**: The original, uppercase, and lowercase versions of the string are printed to the screen.

### Output:
```
Original: Hello, World!
Uppercase: HELLO, WORLD!
Lowercase: hello, world!
```

# Exercises

### Exercise 1: Convert to Uppercase
Write a program that asks the user to enter a word. Use the `toUpperCase()` method to convert the word to uppercase and display the result.

Example Output:
```
Enter a word: hello
Uppercase: HELLO
```

<hint title="Solution">

```java
import java.util.Scanner;

public class ConvertToUppercase {
    public static void main(String[] args) {
        Scanner scanner = new Scanner(System.in);

        System.out.print("Enter a word: ");
        String word = scanner.nextLine();

        String upper = word.toUpperCase();
        System.out.println("Uppercase: " + upper);
    }
}
```

</hint>

### Exercise 2: Convert to Lowercase
Write a program that asks the user to enter a word. Use the `toLowerCase()` method to convert the word to lowercase and display the result.

Example Output:
```
Enter a word: HELLO
Lowercase: hello
```

Example Output:
```
Enter a word: HelLo
Lowercase: hello
```

<hint title="Solution">

```java
import java.util.Scanner;

public class ConvertToLowercase {
    public static void main(String[] args) {
        Scanner scanner = new Scanner(System.in);

        System.out.print("Enter a word: ");
        String word = scanner.nextLine();

        String lower = word.toLowerCase();
        System.out.println("Lowercase: " + lower);
    }
}
```

</hint>