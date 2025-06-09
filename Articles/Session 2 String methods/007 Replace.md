# The `replace()` Method in Java

The `replace()` method is a built-in function in Java that allows you to create a _new_ string by replacing all occurrences of a specified character or substring with another character or substring.

This method does **not** change the original string (because strings in Java are immutable, meaning they cannot be changed), but instead returns a new string with the replacements made.

## Syntax
```java
String newString = originalString.replace(oldChar, newChar);            // Replaces all occurrences of a character
String newString = originalString.replace(oldSubstring, newSubstring);  // Replaces all occurrences of a substring
```
- **`oldChar`**: The character to be replaced.
- **`newChar`**: The character to replace with.
- **`oldSubstring`**: The substring to be replaced.
- **`newSubstring`**: The substring to replace with.

## Example 1: Replacing Characters
```java
String text = "banana";
String replaced = text.replace('a', 'o');
System.out.println(replaced); // bonono
```

## Example 2: Replacing Substrings
```java
String sentence = "I like cats. Cats are cute.";
String replaced = sentence.replace("cat", "dog");
System.out.println(replaced); // I like dogs. Cats are cute.
```

Notice that `replace()` is case-sensitive and replaces **all** occurrences of the target. In the example above, "Cats" remains unchanged because it does not match the case of "cat".

# Exercises

### Exercise 1: Replace Characters
Write a program that asks the user to enter a word and two characters.\
Replace all occurrences of the first character with the second character and display the result.

Example Output:
```
Enter a word: 
banana
Enter the character to replace: 
a
Enter the new character: 
o
Result: bonono
```

<hint title="Solution">

```java
import java.util.Scanner;

public class ReplaceCharacters {
    public static void main(String[] args) {
        Scanner scanner = new Scanner(System.in);

        System.out.print("Enter a word: ");
        String word = scanner.nextLine();

        System.out.print("Enter the character to replace: ");
        String oldCharInput = scanner.next();
        char oldChar = oldCharInput.charAt(0);

        System.out.print("Enter the new character: ");
        String newCharInput = scanner.next();
        char newChar = newCharInput.charAt(0);

        String result = word.replace(oldChar, newChar);
        System.out.println("Result: " + result);
    }
}
```

</hint>

### Exercise 2: Replace Substrings
Write a program that asks the user to enter a sentence and two words. Replace all occurrences of the first word with the second word and display the result.

Example Output:
```
Enter a sentence: 
I like cats. Cats are cute.
Enter the word to replace: 
cat
Enter the new word: 
dog
Result: I like dogs. Cats are cute.
```

<hint title="Solution">

```java
import java.util.Scanner;

public class ReplaceSubstrings {
    public static void main(String[] args) {
        Scanner scanner = new Scanner(System.in);

        System.out.print("Enter a sentence: ");
        String sentence = scanner.nextLine();

        System.out.print("Enter the word to replace: ");
        String oldWord = scanner.next();

        System.out.print("Enter the new word: ");
        String newWord = scanner.next();

        String result = sentence.replace(oldWord, newWord);
        System.out.println("Result: " + result);
    }
}
```

</hint>

### Exercise 3: Remove All Spaces
Write a program that asks the user to enter a sentence. Use the `replace()` method to remove all spaces from the sentence and display the result.

Example Output:
```
Enter a sentence: 
Java is fun
Result: Javaisfun
```

<hint title="Hint">
A space is a character in Java, just like any other letter or symbol. You can write it as ' ' (a single space between single quotes).
</hint>

<hint title="Solution">

```java
import java.util.Scanner;

public class RemoveSpaces {
    public static void main(String[] args) {
        Scanner scanner = new Scanner(System.in);

        System.out.print("Enter a sentence: ");
        String sentence = scanner.nextLine();

        String result = sentence.replace(" ", "");
        System.out.println("Result: " + result);
    }
}
```

</hint>
