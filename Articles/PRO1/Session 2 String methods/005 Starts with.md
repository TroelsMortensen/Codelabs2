# The `startsWith()` and `endsWith()` Methods in Java

The `startsWith()` and `endsWith()` methods are built-in functions in Java that allow you to check whether a string starts or ends with a specific prefix or suffix.

- **`startsWith(prefix)`**: Returns `true` if the string starts with the specified prefix.
- **`endsWith(suffix)`**: Returns `true` if the string ends with the specified suffix.

Both methods are case-sensitive, meaning "Hello" and "hello" are treated as different strings.

They are sort of similar to the `contains()` method, but `startsWith()` and `endsWith()` depends on the position of the substring, while `contains()` checks for the presence of the substring anywhere in the string.

## Syntax
```java
boolean starts = myString.startsWith(prefix);
boolean ends = myString.endsWith(suffix);
```
- **`myString`**: The string you want to check.
- **`prefix`**: The sequence of characters you want to check for at the beginning of the string.
- **`suffix`**: The sequence of characters you want to check for at the end of the string.

## Example 1: Basic Usage
```java
String text = "Hello, world!";
boolean startsWithHello = text.startsWith("Hello");
boolean endsWithWorld = text.endsWith("world!");
System.out.println("Starts with 'Hello': " + startsWithHello); // true
System.out.println("Ends with 'world!': " + endsWithWorld);   // true
```

### Output:
```yaml
Starts with 'Hello': true
Ends with 'world!': true
```

## Example 2: Case Sensitivity
```java
String text = "Hello, world!";
boolean startsWithLowercase = text.startsWith("hello");
boolean endsWithUppercase = text.endsWith("WORLD!");
System.out.println("Starts with 'hello': " + startsWithLowercase); // false
System.out.println("Ends with 'WORLD!': " + endsWithUppercase);   // false
```

### Output:
```yaml
Starts with 'hello': false
Ends with 'WORLD!': false
```

## Example 3: Checking Substrings
```java
String text = "Java programming is fun.";
boolean startsWithJava = text.startsWith("Java");
boolean endsWithFun = text.endsWith("fun.");
System.out.println("Starts with 'Java': " + startsWithJava); // true
System.out.println("Ends with 'fun.': " + endsWithFun);     // true
```

### Output:
```yaml
Starts with 'Java': true
Ends with 'fun.': true
```

# Exercises

### Exercise 1: Check Prefix
Write a program that asks the user to enter a sentence and a prefix. Check if the sentence starts with the prefix.

Example Output:
```yaml
Enter a sentence:
Java is awesome!
Enter a prefix:
Java
The sentence starts with the prefix: true
```

<hint title="Solution">

```java
import java.util.Scanner;

public class CheckPrefix {
    public static void main(String[] args) {
        Scanner scanner = new Scanner(System.in);

        System.out.print("Enter a sentence: ");
        String sentence = scanner.nextLine();

        System.out.print("Enter a prefix: ");
        String prefix = scanner.nextLine();

        System.out.println("The sentence starts with the prefix: " + sentence.startsWith(prefix));
    }
}
```
</hint>

### Exercise 2: Check Suffix
Write a program that asks the user to enter a sentence and a suffix. Use the `endsWith()` method to check if the sentence ends with the suffix.

Example Output:
```yaml
Enter a sentence:
Java is awesome!
Enter a suffix:
awesome!
The sentence ends with the suffix: true
```

<hint title="Solution">

```java
import java.util.Scanner;

public class CheckSuffix {
    public static void main(String[] args) {
        Scanner scanner = new Scanner(System.in);

        System.out.print("Enter a sentence: ");
        String sentence = scanner.nextLine();

        System.out.print("Enter a suffix: ");
        String suffix = scanner.nextLine();

        System.out.println("The sentence ends with the suffix: " + sentence.endsWith(suffix));
    }
}
```
</hint>

### Exercise 3: Check Both Prefix and Suffix
Write a program that asks the user to enter a sentence, a prefix, and a suffix. Use the `startsWith()` and `endsWith()` methods to check if the sentence starts with the prefix and ends with the suffix.

Example Output:
```yaml
Enter a sentence:
Java is awesome!
Enter a prefix:
Java
Enter a suffix:
awesome!
The sentence starts with the prefix: true
The sentence ends with the suffix: true
```

<hint title="Solution">

```java
import java.util.Scanner;

public class CheckPrefixAndSuffix {
    public static void main(String[] args) {
        Scanner scanner = new Scanner(System.in);

        System.out.print("Enter a sentence: ");
        String sentence = scanner.nextLine();

        System.out.print("Enter a prefix: ");
        String prefix = scanner.nextLine();

        System.out.print("Enter a suffix: ");
        String suffix = scanner.nextLine();

        System.out.println("The sentence starts with the prefix: " + sentence.startsWith(prefix));
        System.out.println("The sentence ends with the suffix: " + sentence.endsWith(suffix));
    }
}
```
</hint>
