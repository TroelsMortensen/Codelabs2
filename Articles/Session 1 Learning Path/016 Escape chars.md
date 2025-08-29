# Escaped Characters
In Java, you can use escaped characters to include special characters in a `String`. An escaped character is preceded by a backslash (`\`). Here are some common escaped characters:

| Escaped Character | Description                      |
| ----------------- | -------------------------------- |
| `\"`              | Double quote                     |
| `\'`              | Single quote                     |
| `\\`              | Backslash                        |
| `\n`              | New line                         |
| `\t`              | Tab                              |

You can use these escaped characters in your `String` declarations. For example:

```java
String quote = "She said, \"Hello!\"";
String singleQuote = "It's a sunny day.";
String backslash = "This is a backslash: \\";
String newLine = "This is the first line.\nThis is the second line.";
String tabbed = "This is a tab:\tTabbed text.";
``` 

## Exercise - Escaped Characters Example
Create a new class called `EscapedCharactersExample`. In this class, create a main method. Copy in the above code examples of escaped characters and print each `String` to the console.

Observe how the escape characters are not printed, but they may affect the character following them.