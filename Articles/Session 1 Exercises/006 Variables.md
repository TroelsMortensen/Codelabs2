# Variables

Every program works with data, and in Java, we use variables to store and manipulate this data. 

You may be familiar with a similar concept from mathematics, where a variable can represent a number or an unknown value. In programming, variables can hold different types of data, such as numbers, text, or even more complex objects.

> x = 5

In this example, `x` is a variable that holds the value `5`. You can think of it as a box labeled `x` that contains the number `5`.

In Java, we can declare variables, but we must also define its type. The type of a variable determines what kind of data it can hold.\
For example, if you want to store a whole number, you would use the `int` type, and if you want to store a decimal number, you would use the `double` type.\
If you want to store some text, you would use the `String` type.

Here is how you can declare a variable in Java:

```java
int x = 5; 
double y = 3.14; 
String name = "Alice"; 
```

In this example:
- `int x = 5;` declares a variable `x` of type `int` and assigns it the value `5`.
- `double y = 3.14;` declares a variable `y` of type `double` and assigns it the value `3.14`.
- `String name = "Alice";` declares a variable `name` of type `String` and assigns it the value `"Alice"`.

We use the `=` operator to assign a value to a variable. This is called an **assignment**. The variable type and name comes before the `=` sign, and the value comes after it.

## Naming rules

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


