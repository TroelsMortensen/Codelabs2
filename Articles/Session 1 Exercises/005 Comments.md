# Comments in code

A comment is a piece of text in your code that is not executed by the Java compiler. It is used to explain the code, make notes, or temporarily disable parts of the code without deleting them.

Comments are useful for making your code more readable and understandable, especially when working in teams or revisiting your code later.

There are two types of comments in Java:

1. **Single-line comments**: These comments start with `//` and continue until the end of the line. They are used for brief explanations or notes.
   ```java
   // This is a single-line comment
   int x = 5; // Assigning 5 to variable x
   ```
2. **Multi-line comments**: These comments start with `/*` and end with `*/`. They can span multiple lines and are used for longer explanations or to comment out blocks of code.
   ```java
    /* This is a multi-line comment
        It can span multiple lines
        and is useful for longer explanations */
    int y = 10; /* Assigning 10 to variable y
                    This is a multi-line comment */

### Exercise - Comments

Create a new class called `CommentsExample`. In this class, write a main method which prints out to the console. Like this:

```java
public class CommentsExample {
    public static void main(String[] args) {
        System.out.println("Hello, World!"); 
        System.out.println("Hello, People!"); 
    }
}
```

Running this, you should see "Hello, World!" printed in the console.

Now, comment out the line that prints "Hello, World!".

Run the program again. You should only see "Hello, People!" printed in the console.