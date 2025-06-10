# Logical Operators in Java

Logical operators are used to combine or modify boolean values and expressions. In Java, there are three main logical operators:

| Operator | Name      | Description                                      | Example           |
|----------|-----------|--------------------------------------------------|-------------------|
| &&       | AND       | True if both sides are true                      | true && false     |
| \|\|     | OR        | True if at least one side is true                | true || false     |
| !        | NOT       | Inverts the value (true becomes false, etc.)     | !true             |

## How They Work
- **AND (&&):** Returns true only if both expressions are true.
- **OR (||):** Returns true if at _least one_ expression is true.
- **NOT (!):** Returns the opposite of the boolean value.

## Examples
```java
boolean a = true;
boolean b = false;

System.out.println(a && b); // false
System.out.println(a || b); // true
System.out.println(!a);     // false
System.out.println(!b);     // true
```

Logical operators are often used in if-statements and loops to control the flow of a program based on multiple conditions.

## Combining Logical Operators
You can combine multiple logical operators to create complex conditions. For example:

```java
boolean a = true;
boolean b = false;
boolean c = true;

System.out.println(a && b || c);        // true (because a && b is false, but false || c is true)
System.out.println((a && b) || (a && c)); // true (a && b is false, a && c is true, so false || true)
System.out.println(!(a || b) && c);     // false (a || b is true, !true is false, false && c is false)
```

These combinations are often used in if-statements to check for multiple conditions at once.