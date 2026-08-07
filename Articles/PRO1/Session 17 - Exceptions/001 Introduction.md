# Introduction to Exceptions

Welcome to the world of Java exceptions! Before we dive into how to handle them, let's first experience what happens when things go wrong in our programs. You have probably already seen some errors before, but let's just revisit them. 

We start with a hands-on introduction to show you exactly why exception handling is so important.

## What Happens When Things Go Wrong?

Let's create some programs that will definitely cause problems. Don't worry - this is intentional! We want to see what happens when our code encounters unexpected situations.

### Example 1: The NullPointerException

Create a simple program and run it:

```java
public class NullPointerDemo {
    public static void main(String[] args) {
        String name = null;
        System.out.println("The name is: " + name);
        System.out.println("The length is: " + name.length()); // This will crash!
    }
}
```

IntelliJ may even give you a squiggly yellow line under the `name.length()` line, indicating a potential problem. Mouse over it to see the error message.

**Run this program and observe what happens!**

You should see something like:
```javastacktrace
The name is: null
Exception in thread "main" java.lang.NullPointerException: Cannot invoke "String.length()" because "name" is null
	at session17_exceptions.NullPointerDemo.main(NullPointerDemo.java:10)
```

### Example 2: The ArrayIndexOutOfBoundsException

Now let's try accessing an array element that doesn't exist:

```java
public class ArrayBoundsDemo {
    public static void main(String[] args) {
        int[] numbers = {10, 20, 30};
        System.out.println("First number: " + numbers[0]);
        System.out.println("Second number: " + numbers[1]);
        System.out.println("Third number: " + numbers[2]);
        System.out.println("Fourth number: " + numbers[3]); // This will crash!
    }
}
```

Again, notice the yellow squiggly line under the `numbers[3]` line, indicating a potential problem. Mouse over it to see the error message.

**Run this program and observe what happens!**

You should see something like:
```javastacktrace
First number: 10
Second number: 20
Third number: 30
Exception in thread "main" java.lang.ArrayIndexOutOfBoundsException: Index 3 out of bounds for length 3
    at ArrayBoundsDemo.main(ArrayBoundsDemo.java:10)
```

### Example 3: The InputMismatchException

Let's try reading user input and see what happens when they don't give us what we expect. Notice we are reading an integer in line 8. What happens if we enter a letter instead of a number?

```java{8}
import java.util.Scanner;

public class InputMismatchDemo {
    public static void main(String[] args) {
        Scanner scanner = new Scanner(System.in);
        
        System.out.print("Please enter a number: ");
        int number = scanner.nextInt(); // This will crash if user enters a letter!
        
        System.out.println("You entered: " + number);
        scanner.close();
    }
}
```

**Run this program and enter a letter (like 'a') instead of a number!**

You should see something like:

```javastacktrace
Please enter a number: a
Exception in thread "main" java.util.InputMismatchException
    at java.base/java.util.Scanner.throwFor(Scanner.java:939)
    at java.base/java.util.Scanner.next(Scanner.java:1594)
    at java.base/java.util.Scanner.nextInt(Scanner.java:2258)
    at InputMismatchDemo.main(InputMismatchDemo.java:11)
```

Also notice, we do need see the last print-out of "You entered: 0". When an exception occurs, the program stops further execution.

## What Just Happened?

In all three examples, our programs **crashed** with an **exception**. The program stopped running completely, and Java gave us an error message that tells us:

1. **What went wrong** (the type of exception, e.g. `NullPointerException`, `ArrayIndexOutOfBoundsException`, `InputMismatchException`)
2. **Where it happened** (the method and line number, e.g. `InputMismatchDemo.main(InputMismatchDemo.java:11)`)
3. **How we got there** (the call stack, i.e. which methods were called at which lines to get to the exception)


## Errors

You will and probably have encountered exceptions. They happen regularly. But, there are also _errors_. These are more severe, and usually indicate serious problems.

Try running the following code:

```java
public static void main(String[] args)
{
    recursionAllTheWayDown();
}

private static void recursionAllTheWayDown()
{
    recursionAllTheWayDown();
}  
```

You will see something like this:

```javastacktrace
Exception in thread "main" java.lang.StackOverflowError
    at session17_exceptions.RecursionDemo.recursionAllTheWayDown(RecursionDemo.java:19)
    at session17_exceptions.RecursionDemo.recursionAllTheWayDown(RecursionDemo.java:19)
    at session17_exceptions.RecursionDemo.recursionAllTheWayDown(RecursionDemo.java:19)
    at session17_exceptions.RecursionDemo.recursionAllTheWayDown(RecursionDemo.java:19)
    ...
```

This is a `StackOverflowError`. Notice the last part of the name is `Error`, instead of `Exception`. It happens with recursive methods, which call themselves over and over again, without stopping. Eventually the program crashes. 


## Why This Matters

In real-world applications, we can't just let our programs crash whenever something unexpected happens. Imagine:

- A banking application crashing every time someone enters invalid data
- A game stopping completely when a player does something unexpected (you have probably still encountered this)
- A web application showing error pages to users instead of handling problems gracefully (this has never happened with my learning path web site!)

## What We'll Learn

In this session, you'll learn how to:

- **Catch exceptions** before they crash your program
- **Handle different types of errors** appropriately
- **Create your own custom exceptions** for specific situations
- **Write robust code** that can deal with unexpected situations
- **Follow best practices** for exception handling