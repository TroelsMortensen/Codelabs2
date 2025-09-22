# The `toString` Method in Java

So far, you have been adding a `display()` method to your classes to print information about the object.\
However, Java provides a built-in way to achieve similar functionality through the `toString` method. This is a method, you can add to any class, and Java will call it automatically when you try to print the object, using `System.out.println(myObject);`.\
Because Java already knows about a `toString` method, it is preferable to use this, instead of a custom `display()` method.

Remember, in the video, when I first printed out an object, I got a strange output like `Person@6d06d69c`.\
This is because Java was using the default `toString` method, which returns the class name followed by the object's "hash code".\
You can, however, change this method, to provide a more meaningful string representation of your object.

The `toString` method is a special method in Java that _returns_ a string representation of an object.

When you print an object (for example, with `System.out.println(myPerson)`), Java automatically calls the object's `toString` method.


## Why Override `toString`?

By default, `toString` returns a string that includes the class name and a hash code, which is not very useful. You can override `toString` in your own classes to return more meaningful information about the object.

## Example: Overriding `toString`

```java{10-13}
public class Person {
    private String name;
    private int age;

    public Person(String name, int age) {
        this.name = name;
        this.age = age;
    }

    @Override
    public String toString() {
        return "Person[name=" + name + ", age=" + age + "]";  // notice the return keyword here.
    }
}

public class Main {
    public static void main(String[] args) {
        Person personAlice = new Person("Alice", 25);
        System.out.println(personAlice); // Calls personAlice.toString()
    }
}
```

**Output:**
```
Person[name=Alice, age=25]
```

## Comment

In the above `toString()` method, notice the return keyword. We have not covered this yet, but will get to it, when you are introduced to methods on a later page.

The point is that when you call the `toString()` method, you get a string back, which you can assign to a variable, or print directly.

The simple use is just to print the object, like in the example above: `System.out.println(personAlice);`

## Another comment

It is _very_ important, that the `toString()` method has the correct "signature", which means it must be defined as:

```java
@Override
public String toString() {
    return "whatever";
}
```

Or, if you prefer to have a variable in your toString, like in the example above:

```java
@Override
public String toString() {
    String formattedString = "Person[name=" + name + ", age=" + age + "]";
    return formattedString;
}
```

Either way, include the `@Override` annotation, to indicate that you are overriding the default `toString` method. If you _method signature_ is incorrect, 
the compiler will complain, saying you are trying to override something, but it cannot figure out what. This indicates, you have not created a correct `toString` method.\

* Maybe you marked the return type as `void` instead of `String`?
* Maybe you have a spelling error, like `tostring`, instead of `toString`? Notice the upper case `S`.	


## Example: Default `toString` (not overridden)

If you do not override the `toString` method, Java will use the default implementation, which for most objects returns the class name followed by the object's "hash code".

```java
public class Animal {
    private String type;

    public Animal(String type) {
        this.type = type;
    }
}

public class Main {
    public static void main(String[] args) {
        Animal a = new Animal("Dog");
        System.out.println(a); // Uses default toString()
    }
}
```

**Output (example):**
```
Animal@6d06d69c
```

As you can see, the default output is not very informative. Overriding `toString` makes your objects easier to understand when printed.


## Exercise: Implement `toString`

Find one of the exercises from a previous page, either Person, Circle, or another class you have created. The class must have one of those `display()` methods you have created.

Then, rework the exercise to implement a `toString()` method instead of the `display()` method.\
Update the main method accordingly, so instead of calling the `display()` method, you print the object directly, like `System.out.println(myObject);`.
This will automatically call your `toString()` method and print the string representation of the object.