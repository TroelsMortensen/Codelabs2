# Method Chaining with Strings in Java


Method chaining is a programming technique where you call multiple methods on the same object in a single line, one after another. Each method returns an object, allowing you to "chain" the next method call directly after the previous one.

In Java, many methods on the `String` class return a _new_ `String` object, which means you can chain them together. This can make your code shorter and sometimes easier to read. And, you don't have to create intermediate variables for each step.

## Why is Method Chaining Useful?
- **Conciseness:** You can perform several operations in a single line.
- **Readability:** It can make the sequence of operations clear and logical.
- **Immutability:** Since `String` objects are immutable, each method returns a new string, making chaining possible and safe.

## Example Without Method Chaining
Suppose you want to trim a string (removing first and last white spaces, but leaving middle spaces), convert it to lowercase, and then replace all remaining spaces with underscores. Without method chaining, you would write:

```java
String input = "   Hello World   ";
String trimmed = input.trim();
String lower = trimmed.toLowerCase();
String result = lower.replace(" ", "_");
System.out.println(result); // hello_world
```

## Example With Method Chaining
With method chaining, you can do all of this in a single line:

```java
String input = "   Hello World   ";
String result = input.trim().toLowerCase().replace(" ", "_");
System.out.println(result); // hello_world
```

You can also split a long method chain across several lines for better readability. In Java, whitespace (including newlines) is ignored, so you can write:

```java
String result = input
    .trim()
    .toLowerCase()
    .replace(" ", "_");
System.out.println(result); // hello_world
```

This style is common when chaining many methods, as it makes the sequence of operations easier to read. The two previous code snippets are equivalent.

## More Examples

### Example 1: Remove spaces and capitalize
**Without method chaining:**
```java
String name = "   alice smith   ";
String trimmed = name.trim();
String upper = trimmed.toUpperCase();
System.out.println(upper); // ALICE SMITH
```
**With method chaining:**
```java
String name = "   alice smith   ";
System.out.println(name.trim().toUpperCase()); // ALICE SMITH
```

### Example 2: Get the first character of a cleaned string
**Without method chaining:**
```java
String word = "  Java  ";
String trimmed = word.trim();
String lower = trimmed.toLowerCase();
char first = lower.charAt(0);
System.out.println(first); // j
```
**With method chaining:**
```java
String word = "  Java  ";
char first = word.trim().toLowerCase().charAt(0);
System.out.println(first); // j
```

## When to Use Method Chaining
- When you want to perform several operations in sequence on the same object.
- When it makes your code more readable and concise.
- When each method returns a new object (as with `String` methods).

**Tip:** If the chain gets too long or hard to read, you can always break it up into intermediate variables for clarity. Provide good names for those variables to explain what this intermediate step represents.
