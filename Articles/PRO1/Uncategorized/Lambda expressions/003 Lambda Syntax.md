# Lambda Syntax

Lambda expressions have a flexible syntax that can be written in several ways depending on the situation.

## Basic Syntax

The basic structure of a lambda expression is:

```
(parameters) -> expression or statement
```

## Syntax Variations

Let's look at different ways to write lambda expressions, from simple to more complex.

### 1. No Parameters

When the method takes no parameters:

```java
() -> System.out.println("Hello!")
```

The empty parentheses `()` indicate no parameters.

### 2. One Parameter

When there's exactly one parameter, you can omit the parentheses:

```java
name -> System.out.println(name)
```

Or keep them (both are valid):

```java
(name) -> System.out.println(name)
```

### 3. Multiple Parameters

When there are multiple parameters, parentheses are required:

```java
(a, b) -> a + b
```

Here the calculated value is returned automatically, even though there is no `return` keyword used. 

### 5. Multiple Statements (Block Body)

When you need multiple statements, use curly braces `{}`:

```java
(a, b) -> {
    int sum = a + b;
    System.out.println("Sum: " + sum);
    return sum;
}
```

**Important:** When using curly braces, you must use `return` if the method returns a value.



## Quick Reference

| Parameters | Body | Example |
|------------|------|---------|
| None | Single expression | `() -> 42` |
| One | Single expression | `x -> x * 2` |
| Multiple | Single expression | `(x, y) -> x + y` |
| Any | Multiple statements | `(x, y) -> { System.out.println(x); return y; }` |

