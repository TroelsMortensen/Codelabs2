# Printing to console

Quite often, you will want to print something to the console. This is a good place to start when you are learning to program, as it can show you what is happening inside your code. This is useful for showing some information to the developer. For the majority of PRO1 this is how you will see the output of your code. 

Towards the end, we will add an actual Graphical User Interface (GUI) to the programs we create.

The command (method call) to print something to the console is `System.out.println( )`.

Between the parentheses `( )` you can put any text you want to print.\
Text is surrounded by double quotes `" "`. For example:

```java
"Hello, World!"
```

Each time you execute `System.out.println()`, it will print the text to the console and then move to a new line. If you do not provide any text between the parentheses, it will print an empty line.

## Exercise 1: Print a message

Create a new class called `PrintHelloWorld` and write a program that prints the message "Hello, World!" to the console.


<hint title="Hint 1">

Create a new class in the `session1` package.

```
📁src/
└── 📁session1/
    └── 📄PrintHelloWorld.java
```

</hint>

<hint title="Hint 2">

Inside the class, write a `main` method, I recommend using the simplified syntax.

</hint>

<hint title="Hint 3">

```java
void main() {
    // Your code here
}
```

Inside the `main` method body, use the `System.out.println` method to print "Hello, World!" to the console.

</hint>


<hint title="Solution">

This is what your class should look like:

![Hello world solution](Resources/Exercise1Solution.png)

When you run the program, the console should automatically open and display the message "Hello, World!":

![Hello world console output](Resources/FirstPrint.png)


</hint>

<hint title="Video solution">

This is an older video, and I use the old main method syntax. 

<video src="https://youtu.be/Op6m6Wp_y2c"></video>

</hint>