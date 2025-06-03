# Naming rules

When naming variables in Java, there are some rules you must follow:
1. **Start with a letter**: Variable names must start with a letter (a-z, A-Z), underscore (_), or dollar sign ($).
2. **Followed by letters, digits, underscores, or dollar signs**: After the first character, you can use letters (a-z, A-Z), digits (0-9), underscores (_).
3. **No spaces**: Variable names cannot contain spaces.
4. **Case-sensitive**: Variable names are case-sensitive, meaning `myVariable` and `myvariable` are considered different variables.

## Naming conventions
Java has some conventions for naming variables that help make your code more readable and maintainable. 

Conventions generally makes things simpler, especially when working in teams or on larger projects. You will follow these conventions throughout the course.

### Class Names

The names of classes should be written in **PascalCase**, where each word starts with a capital letter and there are no spaces or underscores. For example:
```java
public class MyClass {
    // Class code here
}
```

### Variable Names
Variable names should be written in **camelCase**, where the first word starts with a lowercase letter and each subsequent word starts with a capital letter. 

For example:

```java
int myVariable = 10;
double myDoubleValue = 3.14;
String myName = "Alice";
```

Identifiers should be descriptive and meaningful, so that anyone reading the code can understand what the variable represents. For example, instead of using `x` or `y`, use `age`, `height`, or `firstName`.

### Package Names

Package names should be written in all **lowercase**.
For example:

```java
package com.example.myapp;
```