# Exercises - Round 1

### Exercise 6.0: Person class

Create a `Person` class with the following field variables:
- `name` (String)
- `age` (int)

Add at least one constructor to set these fields.

Add a toString method, so you can print out the person's name and age in a readable format.

**Example output:**
```
Person[name=Alice, age=25]
```

Create a separate `PersonTest` class with a `main` method to create and print out one or more `Person` objects using your constructor(s).

### Exercise 6.1: Hobbies in Person class

You will update your `Person` class to include a new field variable.

Now, add a new field variable, of type `ArrayList<String>`, called `hobbies`.

And add a new constructor, which takes three parameters: `name`, `age`, and `hobbies`. The hobbies parameter should be an `ArrayList<String>`.

In the other constructor, you can set the hobbies to an empty list, like this: `this.hobbies = new ArrayList<>();`

Then, update the `toString` method to include the hobbies in the output.

Exmple of main method:
```java
public class PersonTest {
    public static void main(String[] args) {
        ArrayList<String> hobbies = new ArrayList<>();
        hobbies.add("Reading");
        hobbies.add("Cycling");

        Person personAlice = new Person("Alice", 25, hobbies);
        System.out.println(personAlice); // Calls personAlice.toString()
    }
}
```

**Output:**
```
Person(name=Alice, age=25, hobbies=[Reading, Cycling] )
```

Formatting the above output may be a bit tricky, but that's part of the fun. Remeber, you can use string concatenation, by adding two strings together, like this:
```java
String s1 = "Hello";
String s2 = "World";
String combined = s1 + " " + s2; // combined will be "Hello World"
```

### Exercise 6.2: Rectangle class

Create a `Rectangle` class with the following field variables:
- `width` (double)
- `height` (double)
- `color` (String)

Add two constructors:
- One that takes both width, height, and color as parameters
- One that takes only two parameters, and sets both width and height to same value (for a square), and a color.

Add the `toString` method to return a string representation of the rectangle, including its width, height, and color.

If the rectangle is a square, also output that information in the string.

Create a separate `RectangleTest` class with a `main` method to create and print out one or more `Rectangle` objects using your constructors.

```java
Rectangle r1 = new Rectangle(4.0, 6.0, "blue");
System.out.println(r1); // Calls r1.toString()
Rectangle r2 = new Rectangle(5.0, "green"); // square
System.out.println(r2); // Calls r2.toString()
```

**Output:**
```
Rectangle[width=4.0, height=6.0, color=blue]
Rectangle[width=5.0, height=5.0, color=green] (square)
```