# Throwing Exceptions

So far, we've learned how to catch and handle exceptions that Java throws when you abuse it. Now let's learn how to throw our own exceptions using the `throw` keyword. This allows you to signal that something has gone wrong in your code and let other parts of your program handle it.

## The `throw` Keyword

The `throw` keyword is used to explicitly throw an exception. You can throw either:
- **Built-in exceptions** (like `IllegalArgumentException`, `RuntimeException`)
- **Custom exceptions** (which we'll learn about later)

## Basic Syntax

```java
throw new ExceptionType("Error message");
```

Try running the following code:

```java
public static void main(String[] args) {
    throw new RuntimeException("Oops");
}
```

And you will get 

```javastacktrace
Exception in thread "main" java.lang.RuntimeException: Oops
	at session17_exceptions.Test.main(Test.java:10)
```

Notice the `Oops` message, which was provided in the code, and shown in the console.

## Simple Examples

### Throwing IllegalArgumentException

Here we do some basic validation, and in case of an invalid `age` value, we throw an `IllegalArgumentException` with a message.

```java
public class AgeValidator {
    public static void validateAge(int age) {
        if (age < 0) {
            throw new IllegalArgumentException("Age cannot be negative: " + age);
        }
        if (age > 150) {
            throw new IllegalArgumentException("Age cannot be greater than 150: " + age);
        }
        System.out.println("Age " + age + " is valid.");
    }
    
    public static void main(String[] args) {
        try {
            validateAge(25);  // Valid
            validateAge(-5);  // Invalid - will throw exception
        } catch (IllegalArgumentException e) {
            System.out.println("Invalid age: " + e.getMessage());
        }
    }
}
```

### Throwing RuntimeException

If you can't find an existing exception, with a name that fits your need, the simple solution is to throw a `RuntimeException` or `Exception` with a message.

```java
public class Calculator {
    public static double divide(double a, double b) {
        if (b == 0) {
            throw new RuntimeException("Cannot divide by zero!");
        }
        return a / b;
    }
    
    public static void main(String[] args) {
        try {
            double result1 = divide(10, 2);
            System.out.println("10 / 2 = " + result1);
            
            double result2 = divide(10, 0); // This will throw an exception
            System.out.println("10 / 0 = " + result2);
        } catch (RuntimeException e) {
            System.out.println("Error: " + e.getMessage());
        }
    }
}
```


## When to Throw Exceptions

Some languages have very ingrained exception usage, like Java or C#. These languages use exceptions in case of errors. Other languages, F#, will return values to indicate errors instead. That's out of scope for this course. We have an elective course, if you are curious.

### 1. **Input Validation**
Throw exceptions when input doesn't meet your requirements:

```java
public void setAge(int age) {
    if (age < 0 || age > 150) {
        throw new IllegalArgumentException("Age must be between 0 and 150");
    }
    this.age = age;
}
```

### 2. **Business Logic Violations**
Throw exceptions when business rules are violated, i.e. the user is trying to get the program to do something that is not allowed.

```java
public void withdraw(double amount) {
    if (amount > balance) {
        throw new RuntimeException("Insufficient funds");
    }
    balance -= amount;
}
```

### 3. **State Validation**
Throw exceptions when an object is in an invalid state:

```java
public void driveCar() {
    if (!isEngineRunning) {
        throw new RuntimeException("Engine is not running");
    }
    // Drive the car
}
```

## Common Built-in Exceptions to Throw

### IllegalArgumentException
Use when method parameters are invalid:
```java
if (value < 0) {
    throw new IllegalArgumentException("Value cannot be negative: " + value);
}
```

### IllegalStateException
Use when an object is in an invalid state:
```java
if (!isInitialized) {
    throw new IllegalStateException("Object must be initialized first");
}
```


### RuntimeException
Use for general runtime errors:
```java
if (connection == null) {
    throw new RuntimeException("Database connection not available");
}
```

## Best Practices

### 1. **Provide Meaningful Messages**
Always include descriptive error messages:

```java
// Good
throw new IllegalArgumentException("Age cannot be negative: " + age);

// Bad
throw new IllegalArgumentException("Invalid input");
```



### 2. **Choose Appropriate Exception Types**
Use the most specific exception type that fits your situation.

### 3. **Throw Early**
Validate inputs and throw exceptions as early as possible.

### 4. **Document Exceptions**
If your method can throw exceptions, document them in comments, [java doc](https://www.baeldung.com/javadoc), or method signatures. See next page about the `throws` keyword.

## Video

John explains throwing exceptions in 15 minutes, if you need a different perspective on this.

<video src="https://www.youtube.com/watch?v=OIozDnGYqIU"></video>