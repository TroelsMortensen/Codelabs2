# Declaration and assignment

You have already seen that we can create a variable and assign a value to it. For example:


```java
int x = 5;
```

This is actually two operations in one line: declaration and assignment.
The first part, `int x`, is the declaration. It tells the Java compiler that we want to create a variable named `x` of type `int`.\
The second part, `= 5`, is the assignment. It assigns the value `5` to the variable `x`.

We can split these two operations into two lines if we want:

```java
int x; // Declaration
x = 5; // Assignment
```

Or with a `String` variable:

```java
String name;    // Declaration
name = "Alice"; // Assignment
```

In rare cases it can be useful to declare a variable without assigning a value immediately. In that case, the variable will have a **default** value based on its type. 