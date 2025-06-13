# The `contains()` Method in Java

The `contains()` method is a built-in function in Java that checks whether a string contains a specific sequence of characters (substring). It returns `true` if the substring is found within the string, and `false` otherwise.

This method is case-sensitive, meaning "Hello" and "hello" are treated as different strings.

## Syntax
```java
boolean result = myString.contains(substring);
```
- **`myString`**: The string you want to search within.
- **`substring`**: The sequence of characters you want to check for.

## Example 1: Basic Usage
```java
String text = "Hello, world!";
boolean containsHello = text.contains("Hello");
boolean containsJava = text.contains("Java");
System.out.println("Contains 'Hello': " + containsHello); // true
System.out.println("Contains 'Java': " + containsJava);   // false
```

### Output:
```
Contains 'Hello': true
Contains 'Java': false
```

## Example 2: Case Sensitivity
```java
String text = "Hello, world!";
boolean containsLowercase = text.contains("hello");
System.out.println("Contains 'hello': " + containsLowercase); // false
```

### Output:
```
Contains 'hello': false
```

## Example 3: Searching for Substrings
```java
String text = "Java programming is fun.";
boolean containsProgramming = text.contains("programming");
System.out.println("Contains 'programming': " + containsProgramming); // true
```

### Output:
```
Contains 'programming': true
```

# Exercises

### Exercise 1: Check for a Word
Write a program that asks the user to enter a sentence and a word. Use the `contains()` method to check if the word is present in the sentence.

Example Output:

```yaml
Enter a sentence:
Java is awesome!
Enter a word:
awesome
The sentence contains the word.
```

<hint title="Solution">

```java
import java.util.Scanner;

public class CheckForWord {
    public static void main(String[] args) {
        Scanner scanner = new Scanner(System.in);

        System.out.print("Enter a sentence: ");
        String sentence = scanner.nextLine();

        System.out.print("Enter a word: ");
        String word = scanner.nextLine();

        boolean result = sentence.contains(word);

        System.out.println("The sentence contains the word: " + result);
    }
}
```
</hint>


### Exercise 2: Check for a word ignoring case
Write a program that asks the user to enter a sentence and a word. Check if the word is present in the sentence, ignoring case.

Example Output:

```yaml
Enter a sentence:
Java is awesome!
Enter a word:
awesome
The sentence contains the word (ignoring case): true
```

Example Output:

```yaml
Enter a sentence:
Java is aWeSoME!
Enter a word:
awesome
The sentence contains the word (ignoring case): true
```


<hint title="Solution">

```java
import java.util.Scanner;

public class CheckForWordIgnoringCase {
    public static void main(String[] args) {
        Scanner scanner = new Scanner(System.in);

        System.out.print("Enter a sentence: ");
        String sentence = scanner.nextLine();
        String sentenceLower = sentence.toLowerCase();

        System.out.print("Enter a word: ");
        String word = scanner.nextLine();
        String wordLower = word.toLowerCase();

        boolean result = sentenceLower.contains(wordLower);

        System.out.println("The sentence contains the word (ignoring case): " + result);
    }
}
```