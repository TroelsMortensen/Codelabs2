# Static field variables (class variables)

So far, all your field variables have been _instance variables_, that is, each instance of a given class can have different values for their field variables.

If we reminisce about the often seen Person class:

```java
public class Person {
    private String name;
    private int age;

    public Person(String name, int age) {
        this.name = name;
        this.age = age;
    }
}
```

I can create multiple instances of the `Person` class, each with its own `name` and `age`. For example:

```java
Person p1 = new Person("Alice", 25);
Person p2 = new Person("Bob", 30);
```

Now I have an Alice person, and a Bob person. Each instance with their own values.

Watch the following video to understand the difference between static and instance fields:

<video src="https://youtu.be/meKwQcN-UEY"></video>

## The shared data

A _static_ field (also called a class variable) is a field that belongs to the class itself rather than to any single instance. There is exactly one copy of a static field, shared by all instances of the class.

All instances of a class have access to this field variable, and they all share the same value. If the value is modified from one instance, it affects all instances.

Key points
- Declared with the `static` keyword on a field: `private static int count;`
- Stored once for the class and shared by every object of that class.
- Useful for values that are common to all instances (counters, configuration constants, etc.).
- Be careful with mutable static fields: changes affect every instance and can introduce bugs or thread-safety issues.

Example 1 — instance counter
```java
// language: java
public class Person {
    private String name;
    private int age;

    // static field shared by all Person objects
    private static int population = 0;

    public Person(String name, int age) {
        this.name = name;
        this.age = age;
        population++; // increment the class-wide counter
    }

    public int getPopulation() {
        return population;
    }

    @Override
    public String toString() {
        return "Person{name='" + name + "', age=" + age + "}";
    }
}
```

Usage:
```java
// language: java
public class Main {
    public static void main(String[] args) {
        System.out.println(Person.getPopulation()); // 0
        Person p1 = new Person("Alice", 25);
        Person p2 = new Person("Bob", 30);
        System.out.println(p1.getPopulation()); // 2 (shared value)
        Person p3 = new Person("Charlie", 35);
        System.out.println(p1.getPopulation()); // 3 (shared value)
    }
}
```

Pitfalls and advice
- Do not use static fields to store per-instance state.
- Mutable static fields can make testing and reasoning about code harder.
- Initialize static fields carefully (static initializers or inline initialization) and avoid using instance values when initializing static fields.