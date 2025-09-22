# Shadowing in Java

"Shadowing" happens when a local variable or parameter in a method has the same name as a field (instance variable) of the class. This can cause confusion, because the local variable or parameter "shadows" (hides) the field.

## Example of Shadowing

```java
public class Person {
    private String name;

    public Person(String name) {
        name = name; 
    }

    public String toString() {
        return "Person[name=" + name + "]";
    }
}
```

## Exercise 3
Create the above `Person` class in IntelliJ, and another class with a `main` method. Print out the `Person` object using `System.out.println(person);`. 


What do you see in the console? You will see that the name is not set correctly. It is just `null`:

**Output:**
```
Person[name=null]
```

Now, look closely at the constructor, and notice that `name = name;` shows the same coloring for both variables.

Here is a screenshot from my IntelliJ, your theme may look different, but the point is that the two `name` variables have the same color, which indicates they are the same variable:

![Shadowing Example](Resources/2025-08-07%2010_28_33-Pro1%20–%20Person.java.png)

The `name` in the variable assignment is dark grey, because it does not make sense. This is a visual aid to help you see that the assignment does not do what you might expect.

Now, change the assignment in the constructor to use `this.name = name;`. Notice now, how the color of the first name variable, `this.name`, is different from the second one, which is the parameter variable. 

The `this.name` variable should have the same color as the field variable. Here is a screenshot of the updated code:

![Fixed shadowing](Resources/2025-08-07%2010_30_43-Pro1%20–%20Person.java.png)

Notice how the field variable is bright blue, while the parameter variable is white. This indicates that they are different variables, and the assignment now works as expected.

All local variables, or parameters, have one color in IntelliJ, while field variables have a different color. This is a visual aid to help you see the difference between them.
If something is grey, it means it is not used, or not needed. This should make you wonder, if you have made a mistake.


## Why is Shadowing a Problem?

- It can lead to bugs that are hard to spot, because you might think you are setting the field, but you are only working with the local variable or parameter.
- It makes code harder to read and understand.

## Using `this` to Avoid Shadowing

You can use the `this` keyword to refer to the current object's field, even if there is a local variable or parameter with the same name.

```java
public class Person {
    private String name;

    public void setName(String name) {
        this.name = name; // This sets the field!
    }
}
```

Here, `this.name` refers to the field, and `name` refers to the parameter. Using `this` makes it clear which variable you are working with and avoids the shadowing problem.

## Another solution
You can also rename the parameter to avoid shadowing. For example, you could change the parameter name to `newName`:

```java
public class Person {
    private String name;

    public void setName(String newName) {
        name = newName; // This sets the field!
    }
}
```

This way, there is no shadowing, and you can directly assign the parameter to the field without confusion.
