# Text (aka Strings)

In Java, text is represented by the `String` type. A `String` is a sequence of characters enclosed in double quotes (`""`).

A `String` can contain letters, numbers, symbols, and whitespace. Here are some examples of `String` declarations:

```java
String greeting = "Hello, World!";
String name = "Alice";
String number = "12345"; // This is still a String, not an integer
String specialChars = "!@#$%^&*()";
String multiline = "This is a\nmultiline String."; // Using \n for a new line
```

Notice that `String` values are enclosed in double quotes (`"`), while characters are enclosed in single quotes (`'`).

Even though `String` can contain numbers, it is still treated as text. For example, `"123"` is a `String`, not an integer.

In the last example, the `\n` character is used to create a new line _within_ the `String`. When printed, it will display the text across two lines.

## Exercise - String Example

Create a new class called `StringExample`. In this class create a main method. Copy in the above code examples of `String` declarations and print each `String` to the console.

Notice the last string contains a `\n` character. When you print it, it will display the text on two lines.
