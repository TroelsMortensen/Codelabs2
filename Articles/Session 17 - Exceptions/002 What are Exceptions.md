# What are Exceptions?

Now that you've seen exceptions in action, let's understand what they really are and why Java has this system.

## Definition

An **exception** is an event that occurs during the execution of a program that disrupts the normal flow of instructions. 

That normal flow is executing one statement (line of code, sort of) at a time, from top to bottom, in sequence. If you call a method, the sequence will continue in that method, until the method returns, and then continue where it left off. This is the normal flow of execution.

An exception disrupts this normal flow of execution, and allows the program to jump to a completely different part of the code, and continue execution from there.

When an exception occurs, Java creates an exception object that contains information about what went wrong.

## Exception vs Error

Java distinguishes between two types of problems:

### Exceptions
- **Recoverable** - You can handle them in your code
- **Expected** - Things that might go wrong in normal program operation
- **Examples**: File not found, invalid user input, network connection lost, trying to convert a letter to an integer

### Errors
- **Not recoverable** - Usually indicate serious problems
- **Unexpected** - Things that shouldn't happen in normal operation
- **Examples**: Out of memory, stack overflow, system crashes

These are rare, and usually indicate serious problems. You probably messed up really bad.

## Real-World Analogy

Think of exceptions like **traffic situations**:

### Normal Flow (No Exception)
```text
You're driving to work → Everything goes smoothly → You arrive on time
```

### Exception Occurs
```text
You're driving to work → Road is closed (exception!) → You need to take a detour (handle it)
```

### Error Occurs
```text
You're driving to work → Car engine explodes (error!) → You can't continue (program crashes)
```

## Happy paths
When the code executes with success, it is called a _happy path_. Or success flow. Or normal flow. Or the main flow. Many names.

Similarly we can talk about the _unhappy path_, or error flow, or exception flow. This is where something goes wrong. Whatever that is, it can take many forms. 

As programmers, we always need to consider both flows, and make sure that the code is robust enough to handle both.

> You must expect your users to abuse your program

## Why Do We Need Exceptions?

You have already written programs, which tried to handle invalid input, or actions. Like the user selecting a menu option, which is not valid. Or the user entering an invalid number. Or trying to divide by zero.

So far, this was handled by using if-statements, and just printing an error message to the console. But, this is not a good solution. It is not robust, and it is not user-friendly. When you have a real application, not running in IntelliJ, there is rarely a console for the user to see. They want an error message or popup in the UI.

### 1. **User-Friendly Messages**
Instead of technical error messages, users get helpful feedback:

```java
try {
    int age = Integer.parseInt(userInput);
} catch (NumberFormatException e) {
    System.out.println("Please enter a valid number for your age");
    // Ask user to try again
}
```

### 2. **Debugging Information**
Exceptions provide detailed information about what went wrong and where:

```
Exception in thread "main" java.lang.NullPointerException
    at MyClass.processData(MyClass.java:25)
    at MyClass.main(MyClass.java:10)
```

This tells us:
- **What**: NullPointerException, i.e. you tried to call a method on a null object
- **Where**: Line 25 in MyClass.processData()
- **How we got there**: Called from line 10 in MyClass.main()

### 3. **Robust Code**
Instead of the program just crashing, it can handle the problem, and continue working. Fairly often, you will encounter users, who abuse your system. Maybe not intentionally, but still, users are stupid. We must account for this.

### 4. Error flows

When your system grows in size, and you have a user interface, and some way of storing data, it can be convenient to use exceptions to stop execution, in case of some invalid situation. This can be a simpler way to return an error message to the user.

## Common Real-World Scenarios

### 1. **File Operations**

Later in the course, you will read from files on your disk. And those files may not exist, or be corrupted, in which case you can use exceptions to handle this.

```java
// What if the file doesn't exist?
File file = new File("data.txt");
```

### 2. **User Input**
```java
// What if user enters "abc" instead of a number?
int age = scanner.nextInt();
```

### 3. **Array Access**
```java
// What if we try to access index 10 in an array of size 5?
int value = numbers[10];
```

### 4. **Division**
```java
// What if we divide by zero?
int result = 10 / 0;
```

## The Exception Handling Philosophy

Java's exception system is based on the principle: **"It's better to ask for forgiveness than permission"**

Instead of checking every possible thing that could go wrong:
```java
// Tedious and error-prone
if (file != null && file.exists() && file.canRead() && file.length() > 0) {
    // Maybe it's safe to read...
}
```

We try the operation and handle problems if they occur. This is done with a try-catch block, as in "let's try this, and see how it goes. And in the catch we handle anything that went wrong".

```java
// Clean and reliable
try {
    // Try to read the file
} catch (FileNotFoundException e) {
    // Handle the specific problem
}
```

We will explore try-catch blocks further on a later page.