# Introduction to Shadowing

Welcome to **Shadowing**! This is an important concept in Java that can cause subtle bugs if you're not aware of it. Understanding shadowing will help you write clearer, more reliable code.

## What is Shadowing?

**Shadowing** happens when a local variable or parameter in a method has the same name as a field (instance variable) of the class. The local variable or parameter "shadows" (hides) the field, making the field inaccessible by its simple name.

### The Core Idea

When you use a variable name in Java, the compiler looks for that name starting from the most local scope and working outward. If it finds a match in a local scope (like a parameter), it stops looking and uses that variable - even if there's a field with the same name in the class.

## Why Does Shadowing Happen?

Shadowing is most common in two situations:

### 1. Constructors

When you create a constructor, it's natural to use the same name for parameters as the fields you want to initialize:

```java
public class Person {
    private String name;  // Field
    
    public Person(String name) {  // Parameter with same name
        // How do we assign the parameter to the field?
    }
}
```

### 2. Setter Methods

Similarly, in setter methods, you often want to use the same name for the parameter as the field:

```java
public class Person {
    private String name;  // Field
    
    public void setName(String name) {  // Parameter with same name
        // How do we assign the parameter to the field?
    }
}
```

## Variable Scope and Name Resolution

Java uses a concept called **scope** to determine which variable you're referring to. The scope rules work like this:

1. **Local scope** (parameters, local variables) - Most specific, checked first
2. **Class scope** (fields) - Less specific, checked if nothing found locally

When you write `name` inside a method, Java first looks for a local variable or parameter named `name`. If it finds one, it uses that - even if there's a field with the same name. The field is "shadowed" by the local variable.

## A Simple Example

Consider this code:

```java
public class Person {
    private String name;  // Field variable
    
    public Person(String name) {  // Parameter variable with same name
        name = name;  // What does this do?
    }
}
```

At first glance, `name = name;` looks like it should assign the parameter to the field. But because of shadowing, both `name` references point to the **parameter**, not the field. The field never gets set!

Instead the parameter variable is assigned to itself, and the field remains uninitialized.

## Why This Matters

Shadowing can lead to:
- **Silent bugs** - Code compiles but doesn't work as expected
- **Confusing code** - It's unclear which variable you're referring to
- **Hard-to-find errors** - The problem might not be obvious until runtime

## Visual Aids in IntelliJ

The good news is that IntelliJ IDEA provides visual clues to help you identify shadowing:
- **Color coding** - Fields and parameters have different colors
- **Grey highlighting** - Unused or problematic code is shown in grey
- **Syntax highlighting** - Helps distinguish between different variable types

## Summary

Shadowing is:
- **A name conflict** - Local variable/parameter has the same name as a field
- **A scope issue** - Java prioritizes local scope over class scope
- **A common problem** - Especially in constructors and setters
- **Hard to spot** - Code compiles but may not work correctly

In the following sections, we'll see exactly what goes wrong with shadowing, how to identify it, and learn two solutions to fix it.
