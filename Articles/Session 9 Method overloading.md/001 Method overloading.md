# Method overloading in Java

Method overloading means defining multiple methods with the same name but different parameter lists (different number, types, or order of parameters). The compiler chooses the correct method to call based on the compile-time types and the arguments you pass.

Key points:
- Overloads must differ in parameter list; return type alone is not sufficient.
- Overloading happens at compile time (static binding).
- Useful for providing the same logical operation for different input types or counts.

You have already encountered the concept, for example with the `System.out.println()` method, which is overloaded to handle different types of arguments. There are a total of 9 overloads for the println method, to support all the primitive types, arrays, Strings, and objects.


Example: utility add methods
```java
public class MathUtil {
    public int add(int a, int b) {
        return a + b;
    }

    public double add(double a, double b) {
        return a + b;
    }

    public int add(int a, int b, int c) {
        return a + b + c;
    }
}
```

Usage:

```java
MathUtil mathUtil = new MathUtil();
int s1 = mathUtil.add(2, 3);        // calls add(int,int)
double s2 = mathUtil.add(2.0, 3.5); // calls add(double,double)
int s3 = mathUtil.add(1, 2, 3);     // calls add(int,int,int)
```

## Calling `this()`

You can use `this(...)` to call another constructor in the same class. This helps avoid duplication by delegating common initialization to a single constructor.

Rules and notes:
- A call to `this(...)` must be the first statement in a constructor.
- You can chain constructor calls (one constructor calls another which calls another), but each call must obey the "first statement" rule.
- Use `this(...)` to centralize shared initialization logic and keep constructors short and consistent.

Small example:

```java
public class Example {
    private int x;
    private int y;

    public Example() {
        this(0, 0); // delegates to the two-arg constructor
    }

    public Example(int x) {
        this(x, 0); // delegates to the two-arg constructor
    }

    public Example(int x, int y) {
        this.x = x;
        this.y = y;
    }
}
```

Example: overloading in a Person class (constructors + methods)
```java
import java.util.ArrayList;

public class Person {
    private String name;
    private int age;
    private ArrayList<String> hobbies;

    // Overloaded constructors
    public Person() {
        this("Unknown", 0, new ArrayList<>()); // calls all-args constructor below with some default values
    }

    public Person(String name) {
        this(name, 0, new ArrayList<>()); // calls all-args constructor below with some default values
    }

    public Person(String name, int age) {
        this(name, age, new ArrayList<>()); // calls all-args constructor below with some default values
    }

// all arguments constructor
    public Person(String name, int age, ArrayList<String> hobbies) {
        this.name = name;
        this.age = age;
        this.hobbies = hobbies;
    }

    // Overloaded greet methods
    public void greet() {
        System.out.println("Hello, I'm " + name);
    }

    public void greet(String salutation) {
        System.out.println(salutation + " I'm " + name);
    }

    public void greet(String salutation, boolean includeAge) {
        if (includeAge) {
            System.out.println(salutation + " I'm " + name + ", age " + age);
        } else {
            System.out.println(salutation + " I'm " + name);
        }
    }
}
```

Notes and pitfalls:
- Do not rely on return type to differentiate overloads.
- Overloading is different from overriding (overriding replaces a superclass method at runtime).