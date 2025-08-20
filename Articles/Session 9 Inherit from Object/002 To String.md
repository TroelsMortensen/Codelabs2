# To String

All your classes have a default `toString()` method, even though it is not clearly visible from the start. For example, here is a, by now, well-known `Person` class:

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

If you create an instance of `Person` and print it, like this:

```java
Person person = new Person("Alice", 30);
System.out.println(person);
```

You will get an output like this:

```
Person@1a2b3c4d
```

This is the default implementation of `toString()`, which returns the class name followed by the object's "hash code". However, you can _override_ this method to provide a more meaningful string representation of your object.

With this method inside the `Person` class:

```java
@Override
public String toString() {
    return "Person{name='" + name + "', age=" + age + "}";
}
```

Now, if you print the `Person` object again, you will see:

```
Person{name='Alice', age=30}
```

So, every class comes with a default `toString()` method, which prints out some less-useful representation of the object. You can then override the method to provide a more meaningful representation of your objects.