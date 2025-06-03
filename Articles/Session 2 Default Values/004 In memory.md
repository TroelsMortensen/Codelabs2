# In memory

In Java, when you create a variable, it is stored in memory, your RAM. The way it is stored depends on the type of the variable.

We will keep the explanation simple for now, I just think this will help with understanding the difference between primitive types and reference types, for the upcoming pages

![DM](Resources/DungeonMaster.png)

> "You are an adventurer in a fantasy world. On your hip is your utility belt, which has several slots for items. Each slot can hold a different type of item, like a sword, a potion, or magic scrolls.\
On your back is a backpack, which can hold many items, but it is not as easy to access as your utility belt."

If you know anything about computer games, think of an inventory system. This is your memory, where we can store data.

This is you (or your program):

![Adventurer](Resources/Adventurer.png)

Now, the two types of variables in Java can be compared to the items you can carry, and they are stored either on your utility belt (primitive types) or in your backpack (reference types).

### Primitive types

When you declare a primitive type variable, like `int`, `double`, or `boolean`, the value is stored directly in that cell of memory. In a slot on your utility belt.

```java
int num = 5; // The value 5 is stored directly in memory
```

### Reference types

When you declare a reference type variable, like `String`, the variable doesn't hold the actual value directly. Instead, it holds a reference (or pointer) to where the value is stored in memory.

So, in your utility belt, instead of the value (item), you have a little note that tells you where to find the actual item in your backpack.\
This is like having a note that says "Potion is in the left-side, lower pocket of my backpack."


For example:

```java
String jarLocation = "Large Jar os weird stuff!"; // The variable 'jarLocation' holds a reference to the String object in memory
```

![Memory Reference](Resources/JarLocation.png)

Notice "Large Jar of weird stuff!" is in the backpack (a separate place in your computers memory), and the variable `jarLocation` is just a note that tells you where to find the actual value.

So, if you don't assign a value to a reference type variable, it will point to `null`, meaning it doesn't point to any object in memory. You have a note, but it doesn't tell you where to find anything.
