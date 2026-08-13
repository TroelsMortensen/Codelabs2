# The Main method

A method is a collection of commands (statements) that perform a specific task. 

We will get back to methods in detail later, but for now, we will focus on the `main` method, which is essential for running any Java program.

In Java, the `main` method is the entry point of any Java application. It is where the program starts executing. It is the button, we press, to start the machine.

The main method has a specific structure, and is defined as follows:

```java
public static void main(String[] args) {
    // Your code here
}
```

Alternatively, if you are on Java 26 or later, you can use the simplified syntax, which I **strongly recommend**:

```java
void main() {
    // Your code here
}
```

You don't even need to declare the class!

Between the curly braces `{..}` is where you will write the code that you want to execute when the program runs.\
This part is called the **method body**.

Arrange the lines of the classic `main` method. You will still see this form in older examples and videos.

<Quiz>
{
  "Type": "ParsonsProblem",
  "Question": "Arrange the lines to form the classic Java main method.",
  "Lines": [
    { "Id": 1, "Content": "public static void main(String[] args) {" },
    { "Id": 2, "Content": "    // Your code here" },
    { "Id": 3, "Content": "}" }
  ],
  "Hint": "The method signature comes first, then the body, then the closing brace."
}
</Quiz>

A few important points about the `main` method, which may not all make sense yet:

1. **Public**: The `main` method must be declared as `public` so that the Java Virtual Machine (JVM) can access it.
2. **Static**: The `main` method is declared as `static` so that it can be called without creating an instance of the class.
3. **Void**: The `main` method does not return any value, hence it is declared as `void`.
4. **String[] args**: This parameter allows the program to accept command-line arguments. It is an array of `String` objects that can be used to pass information to the program when it is executed.
5. **Method Body**: The code inside the curly braces `{ }` is where you write the statements that will be executed when the program runs.

Most of the above may not make sense right now, but we will cover these concepts in detail as we progress through the course. The point is that the `main` method has a very specific structure (or _signature_) that must be followed for the program to run correctly.

You can think of the `main` method as the starting point of your Java program, where you will write the code that you want to execute when the program runs.

Most of the following exercises will just be writing some code inside the `main` method to see how it works.

## Running a main method

Walk through the ways to run a `main` method in IntelliJ. Any of them is fine.

<Quiz>
{
    "Type": "StepGuide",
    "Title": "Running a main method in IntelliJ",
    "Details": [
        {
            "Header": "Several ways to run",
            "Content": "<p>In IntelliJ you can run a main method in several ways. There are even more than the three shown here, but these are enough to get started. It does not matter which you pick.</p>"
        },
        {
            "Header": "Green play button",
            "Content": "<p>The simplest is clicking the green play button next to the <code>main</code> method declaration.</p>"
        },
        {
            "Header": "Right-click the file",
            "Content": "<p>You can also right-click the file in the project window and select run.</p>"
        },
        {
            "Header": "Dropdown at the top right",
            "Content": "<p>Or you select a specific file (with a main method) in the dropdown at the top right, and then click the green play button.</p>"
        },
        {
            "Header": "Watch the dropdown",
            "Content": "<p>Be careful with the dropdown option. As you complete exercises, it will fill up with more and more main methods. It is a common mistake to forget to change the dropdown back to the main method you want to run, and thereby running the wrong code.</p>"
        }
    ]
}
</Quiz>

The green play button next to `main`:

![Running main method](Resources/RunningTheMainMethod.png)

Right-click the file in the project window:

![Running main method](Resources/RightClickToRun.png)

The dropdown at the top right:

![Running main method](Resources/RunSelectedFile.png)


## Video

Here is John explaining the main method in 7 minutes. John has many fine videos, I will use him occasionally.

<video src="https://www.youtube.com/watch?v=P-_Nzi_mCRo"></video>