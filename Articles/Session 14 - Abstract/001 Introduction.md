# Introduction to Abstract Classes

## Building on Inheritance

In the previous learning path (Session 13 - Inheritance), you learned the fundamentals of inheritance in Java. You discovered how classes can inherit from other classes using the `extends` keyword, how to override methods, and how polymorphism allows objects of different types to be treated uniformly. For example, Animal, Dog, and Cat are all animals, and they can all be treated as Animal objects, but they can also be treated as Dog or Cat objects, depending on the context.

Now it's time to explore the next level of inheritance: **abstract classes and methods**. These concepts take inheritance to a new level by allowing you to create classes that cannot be instantiated directly but serve as blueprints for other classes. Several of the exercises from the previous session would have benefited from using abstract classes. This will now be fixed.

## What You'll Learn

This session will cover:

1. **Polymorphism Recap** - A quick review of what polymorphism means in Java
2. **Casting Recap** - Understanding `instanceof` and type casting
3. **What is Abstract** - The conceptual foundation of abstract programming
4. **Abstract Classes** - Creating classes that cannot be instantiated
5. **Abstract Methods** - Defining methods that must be implemented by subclasses
6. **Abstract in UML** - How to represent abstract classes in diagrams
7. **The `final` Keyword** - Preventing inheritance and method overriding
8. **Fixing `equals` Method** - Proper implementation in inheritance hierarchies

## Why Abstract Classes Matter

Abstract classes are powerful because they:

- **Force structure** - Ensure subclasses implement required methods
- **Share common code** - Provide implementation that all subclasses can use
- **Define contracts** - Specify what subclasses must do without saying how
- **Enable polymorphism** - Allow different implementations of the same interface

## Real-World Analogy

Think of an abstract class like a **recipe template**. 

- You can't eat the template itself (can't instantiate abstract class)
- It tells you what ingredients you need
- It provides some common steps (concrete methods)
- Each chef must follow the template but can add their own twist (subclass implementation)

For example, a "Cake Recipe" template might specify:
- You must add flour (abstract method)
- You must add sugar (abstract method)
- You must bake at 350°F (concrete method)
- But you can choose chocolate, vanilla, or strawberry (subclass choice)
