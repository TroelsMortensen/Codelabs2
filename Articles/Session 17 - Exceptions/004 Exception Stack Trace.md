# Exception Stack Trace

When an exception occurs, Java provides a **stack trace** - a detailed report showing exactly what happened and where. Understanding stack traces is essential for debugging your programs.

## What is a Stack Trace?

A stack trace is a list of method calls that led to the exception. It shows the **call stack** - the sequence of method calls from the beginning of your program to the point where the exception occurred.

## Anatomy of a Stack Trace

Let's look at a real example:

```java
public class StackTraceDemo {
    public static void main(String[] args) {
        System.out.println("Starting program...");
        methodA();
        System.out.println("Program finished.");
    }
    
    public static void methodA() {
        System.out.println("In methodA");
        methodB();
    }
    
    public static void methodB() {
        System.out.println("In methodB");
        methodC();
    }
    
    public static void methodC() {
        System.out.println("In methodC");
        String name = null;
        int length = name.length(); // This will cause a NullPointerException
    }
}
```

**Run this program and observe the stack trace:**

```
Starting program...
In methodA
In methodB
In methodC
Exception in thread "main" java.lang.NullPointerException
    at StackTraceDemo.methodC(StackTraceDemo.java:18)
    at StackTraceDemo.methodB(StackTraceDemo.java:12)
    at StackTraceDemo.methodA(StackTraceDemo.java:7)
    at StackTraceDemo.main(StackTraceDemo.java:3)
```

## Reading the Stack Trace

Let's break down each part:

### 1. **Exception Type and Message**
```
Exception in thread "main" java.lang.NullPointerException
```
- **Exception in thread "main"**: The exception occurred in the main thread
- **java.lang.NullPointerException**: The type of exception that occurred

### 2. **The Call Stack** (Read from bottom to top)
```
    at StackTraceDemo.methodC(StackTraceDemo.java:18)  ← WHERE IT HAPPENED
    at StackTraceDemo.methodB(StackTraceDemo.java:12)  ← WHO CALLED methodC
    at StackTraceDemo.methodA(StackTraceDemo.java:7)   ← WHO CALLED methodB
    at StackTraceDemo.main(StackTraceDemo.java:3)      ← WHO CALLED methodA
```

**Reading order**: Start from the **bottom** and work your way up to understand the call sequence.

## Understanding Each Line

Each line in the stack trace follows this format:
```
at ClassName.methodName(FileName.java:lineNumber)
```

- **ClassName**: The class where the method is defined
- **methodName**: The method that was executing
- **FileName.java**: The source file name
- **lineNumber**: The exact line where the exception occurred

## More Complex Example

Let's create a more realistic example with multiple classes:

```java
// File: Calculator.java
public class Calculator {
    public static int divide(int a, int b) {
        return a / b; // This will cause ArithmeticException if b is 0
    }
}

// File: MathHelper.java
public class MathHelper {
    public static double calculateAverage(int[] numbers) {
        int sum = 0;
        for (int i = 0; i < numbers.length; i++) {
            sum += numbers[i];
        }
        return Calculator.divide(sum, numbers.length); // Calls Calculator.divide
    }
}

// File: Main.java
public class Main {
    public static void main(String[] args) {
        int[] numbers = {10, 20, 30};
        double average = MathHelper.calculateAverage(numbers);
        System.out.println("Average: " + average);
    }
}
```

**What happens if we pass an empty array?** Let's modify the main method:

```java
public static void main(String[] args) {
    int[] numbers = {}; // Empty array!
    double average = MathHelper.calculateAverage(numbers);
    System.out.println("Average: " + average);
}
```

**Stack trace:**
```
Exception in thread "main" java.lang.ArithmeticException: / by zero
    at Calculator.divide(Calculator.java:3)
    at MathHelper.calculateAverage(MathHelper.java:8)
    at Main.main(Main.java:4)
```

## Reading This Stack Trace

1. **Bottom line**: `Main.main(Main.java:4)` - The program started in main method
2. **Middle line**: `MathHelper.calculateAverage(MathHelper.java:8)` - main called calculateAverage
3. **Top line**: `Calculator.divide(Calculator.java:3)` - calculateAverage called divide, and that's where the exception occurred

## Common Stack Trace Patterns

### 1. **NullPointerException**
```
Exception in thread "main" java.lang.NullPointerException
    at MyClass.processData(MyClass.java:25)
    at MyClass.main(MyClass.java:10)
```
**What to look for**: Line 25 in MyClass.processData() - something is null

### 2. **ArrayIndexOutOfBoundsException**
```
Exception in thread "main" java.lang.ArrayIndexOutOfBoundsException: Index 5 out of bounds for length 3
    at MyClass.accessArray(MyClass.java:15)
    at MyClass.main(MyClass.java:8)
```
**What to look for**: Line 15 in MyClass.accessArray() - trying to access index 5 in an array of size 3

### 3. **FileNotFoundException**
```
Exception in thread "main" java.io.FileNotFoundException: data.txt (The system cannot find the file specified)
    at java.base/java.io.FileInputStream.open0(Native Method)
    at java.base/java.io.FileInputStream.open(FileInputStream.java:219)
    at java.base/java.io.FileInputStream.<init>(FileInputStream.java:157)
    at MyClass.readFile(MyClass.java:12)
    at MyClass.main(MyClass.java:6)
```
**What to look for**: The file "data.txt" doesn't exist

## Debugging Tips

### 1. **Start from the Top**
The first line in the stack trace shows where the exception actually occurred.

### 2. **Follow the Call Chain**
Work your way down to understand how you got to that point.

### 3. **Check the Line Numbers**
The line numbers tell you exactly where to look in your code.

### 4. **Look for Your Code**
Focus on lines that mention your classes, not Java library classes.

### 5. **Use IDE Features**
Most IDEs allow you to click on stack trace lines to jump directly to the code.

## Practice Exercise

Create this program and run it to see a stack trace:

```java
public class PracticeStackTrace {
    public static void main(String[] args) {
        System.out.println("Starting...");
        processUserInput("hello");
        System.out.println("Finished.");
    }
    
    public static void processUserInput(String input) {
        System.out.println("Processing: " + input);
        convertToNumber(input);
    }
    
    public static void convertToNumber(String text) {
        System.out.println("Converting: " + text);
        int number = Integer.parseInt(text); // This will fail!
        System.out.println("Converted to: " + number);
    }
}
```

**Run this and analyze the stack trace. What went wrong and where?**

## What's Next?

Now that you can read stack traces, let's learn how to catch and handle exceptions using try-catch blocks!
