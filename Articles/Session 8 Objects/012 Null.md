# Understanding `null` in Java

I have previously mentioned the various default values of different types in Java. And for objects, the default value is `null`.

In Java, `null` is a special value that represents the absence of a value or a reference to an object. It is the default value for all reference types (e.g., `String`, `ArrayList`, or custom objects) when they are declared _but not initialized_.

## How `null` Works

When you declare a reference type variable without assigning it a value, it is automatically set to `null`. This means the variable exists, but it does not point to any object in memory.

### Example:
```java
String myString; // Declared but not initialized
System.out.println(myString); // Prints: null
```

In this example, `myString` is declared but not assigned a value, so it defaults to `null`.

## Why `null` Happens

`null` occurs when:
1. A reference type variable is declared but not initialized.
2. A method returns `null` to indicate that no object was found or created.
3. A variable is explicitly assigned the value `null`.

### Example:
```java
String myString = null; // Explicitly assigned null
```

## What the Error Looks Like

If you try to call a method or access a property on a `null` reference, Java will throw a `NullPointerException` (NPE). This is a runtime error that occurs because there is no object to operate on.

Runtime errors happen during program execution. Unlike compile errors, when you make a mistake in your code, which are caught by the compiler. In the case of compile error you cannot run your program, until the error is fixed.

### Example:
```java
String myString = null;
System.out.println(myString.length()); // Throws NullPointerException
```

### Error Output:
```
Exception in thread "main" java.lang.NullPointerException: Cannot invoke "String.length()" because "myString" is null
    at Main.main(Main.java:5)
```

The error message tells you:
1. The type of exception (`NullPointerException`).
2. The method or property that caused the error (`String.length()`).
3. The line in your code where the error occurred (`Main.java:5`).

## What the Problem Is

The problem with `null` is that it represents the absence of an object, so there is nothing to operate on. When you try to call a method or access a property on `null`, Java doesn't know what to do, leading to a crash.



### Common Scenarios:
1. Forgetting to initialize a variable:
   ```java
   String name;
   System.out.println(name.length()); // NullPointerException
   ```
2. Receiving `null` from a method:
   ```java
   String result = findName();
   System.out.println(result.length()); // NullPointerException if findName() returns null
   ```
3. Explicitly assigning `null` and forgetting to check:
   ```java
   String text = null;
   if (text.equals("Hello")) { // NullPointerException
       System.out.println("Match found!");
   }
   ```

## How to Avoid `null` Problems

1. **Initialize Variables**: Always assign a value to reference type variables when declaring them.
   ```java
   String name = ""; // Initialize with an empty string
   ```

2. **Check for `null`**: Use an `if` statement to check if a variable is `null` before using it.
   ```java
   if (myString != null) {
       System.out.println(myString.length());
   }
   ```

3. **Avoid Explicit `null` Assignments**: Only assign `null` when absolutely necessary, and document why it is being used.

By understanding how `null` works and taking precautions, you can avoid `NullPointerException` and write