# The Problem with Shadowing

Now let's see exactly what goes wrong when shadowing occurs and how to identify it.

## A Detailed Example

Here's a `Person` class with a shadowing problem:

```java
public class Person {
    private String name;  // Field variable

    public Person(String name) {  // Parameter variable with same name
        name = name;  // Shadowing problem!
    }

    public String toString() {
        return "Person[name=" + name + "]";
    }
}
```

Notice there is a field variable `name`, and a parameter variable `name` in the constructor. The same variable name is used in both places. This is called **shadowing**.

## What Happens?

When you create a `Person` object and print it, you'll see that the name is not set correctly:

```java
public static void main(String[] args) {
    Person person = new Person("Alice");
    System.out.println(person);
}
```

**Output:**
```
Person[name=null]
```

The name is `null`! Even though you passed "Alice" to the constructor, the field was never set.

## Why Does This Happen?

The problem is in this line:
```java
name = name;
```

Because of shadowing, **both** `name` references point to the **parameter**, not the field. You're essentially doing:
```java
parameter = parameter;  // Assigning the parameter to itself
```

The field `name` is never touched, so it remains `null` (the default value for a `String` field).

## Why Is This Hard to Spot?

Shadowing is particularly tricky because:

1. **The code compiles** - There are no compiler errors or warnings
2. **It looks correct** - `name = name;` seems like it should work
3. **The bug is silent** - The program runs, but doesn't do what you expect
4. **It's easy to miss** - You might not notice until you test the code

