# Encapsulation

This topic is about hiding the "internals" of an object and exposing only what is necessary. 

Look at your laptop. It is encased, you cannot directly see the internal components, but you can use it to perform tasks. The laptop exposes a _public_ way to interact with it, through buttons, keyboard, mousepad.

Many electronic devices are designed this way, to protect the internal components, so you cannot accidentally do something to the internals, which you are not supposed to do.

We apply the same principle to objects in programming. Given that one object, _A_, can interact with another object, _B_, we want to make sure that _A_ can only interact with _B_ through a well-defined interface, exposing only the necessary methods and properties, while hiding the internal implementation details of _B_. 

Or, put differently, currently you have used a main method, to interact with a person object. Try the following code, and observe the compiler error:

```java
public static void main(String[] args) {
    Person person = new Person("Alice", 30);
    person.age;
}
```

In the above code snippet, the main method is trying to directly interact with the age field variable of the person class. But, because `age` is `private`, it cannot be accessed directly from outside the class.

Here is what IntelliJ shows me:

![private age](Resources/private-age.png)

This is called encapsulation.

The core idea is that the `Person` class hides its internal state and only exposes methods to interact with that state. It is then up to the `Person` class itself to manage its internal data, to ensure someone else is not accidentally modifying it in a way that is not allowed.

## Encapsulation in Java

In Java programming, encapsulation is the practice of keeping the internal state (properties, aka. fields) of an object hidden from the outside world, and only allowing access or modification through public methods (getters and setters). This is achieved by:

- Declaring fields as `private` so they cannot be accessed directly from outside the class.
- Providing `public` methods to read (get) or change (set) the values of these fields, if needed. These methods are called "getters" and "setters", or "accessors" and "mutators".

Encapsulation helps to:
- Protect the internal state of an object from unintended or harmful changes.
- Control how the data is accessed or modified.
- Make code easier to maintain and understand.

**Example:**

```java
public class Person {
    private String name; // private field

    // public getter
    public String getName() {
        return name;
    }

    // public setter
    public void setName(String name) {
        this.name = name;
    }
}
```

In this example, the `name` field is private and cannot be accessed directly from outside the `Person` class. Instead, you use the `getName()` and `setName()` methods to access or change the value.

By default all your field variables should be private, and you can then provide public getter and setter methods as needed.

## Exercise 12: Person

For the `Person` class, implement the following, if you don't already have them:

- Add get and set methods for `age`.
- Add get and set methods for `name`.
- A method to add a hobby to the list of hobbies. For lists the set method is generally not just setting a new list, meaning it will overwrite the existing entire list. Instead the method will add an element to the list.
- A method to get the ArrayList of hobbies.

## Exercise 13: Breaking encapsulation

As you can read above, the point of encapsulation is to protect the data of the object, so that it is not accidentally modified from the outside.

Pay attention to the last method in the previous exercise, it returns the ArrayList. The ArrayList is an object type, so what is returned is actually reference to the ArrayList object inside the Person class. This means that if you modify the ArrayList outside the class, you are actually modifying the internal state of the Person object, which breaks encapsulation.

To test this, try the following: 

```java
public static void main(String[] args){
    Person person = new Person("Alice", 30);
    person.addHobby("Reading");
    person.addHobby("Traveling");

    // This will break encapsulation
    ArrayList<String> hobbies = person.getHobbies();
    hobbies.add("Cooking");
    System.out.println(person);
}
```

In the last line, we print out the person object. This means calling the `toString()` method of the `Person` class, which should return a string representation of the person, including their name, age, and _hobbies_.

You should see that the ArrayList of your person object now has "Cooking" as one of its elements. You have successfully broken encapsulation! 

To prevent this, we generally don't return the ArrayList directly. Instead, we can return a copy of the ArrayList. On the previous page, you were tasked with returning an array copy of the ArrayList. This is one way to ensure encapsulation is not broken. Alternatively, a new ArrayList can be created and the elements can be copied to it, like this:

```java
public ArrayList<String> getHobbies() {
    return new ArrayList<>(hobbies);
}
```
