# Introduction to Interfaces

## Building on Abstract Classes

In the previous session (Session 14 - Abstract), you learned about abstract classes and methods. You discovered how abstract classes can define common behavior while forcing subclasses to implement specific methods. Abstract classes are powerful, but they have limitations - a class can only extend one other class.

Now it's time to explore **interfaces** - the next step in Java's object-oriented programming toolkit. Interfaces take the concept of abstract classes one step further by allowing a class to implement multiple interfaces, providing even more flexibility in your designs.

Imagine an abstract class, with only abstract methods, no constructor, and no field variables. That is essentially an interface.


## What are Interfaces?

An **interface** in Java is a reference type, like objectts, that defines a _contract_ for classes to follow. It's like a blueprint that specifies what methods a class must implement, but it doesn't provide any implementation itself.

Think of an interface as a **contract** or **agreement**:
- It defines what a class **must be able to do**
- It doesn't specify **how** the class should do it
- Any class that implements the interface **promises** to provide those capabilities

## Real-World Analogy

Think of an interface like a **job description**:

- **Job Description** (Interface): "Must be able to drive, communicate with customers, and handle money"
- **Employee** (Class): Each employee implements these requirements differently
- **Taxi Driver**: Drives a car, talks to passengers, handles cash payments
- **Delivery Person**: Drives a van, talks to customers, handles credit card payments
- **Bus Driver**: Drives a bus, makes announcements, handles fare collection

All employees fulfill the same job requirements, but they do it in their own unique way.

## Why Interfaces Matter

Interfaces are powerful because they:

- **Define contracts** - Specify what classes must be able to do
- **Enable multiple inheritance** - A class can implement multiple interfaces
- **Promote loose coupling** - Code depends on interfaces, not concrete classes
- **Enable polymorphism** - Different implementations can be treated uniformly, as the same like. Similar to abstract classes.
- **Improve testability** - They are heavily used in automated testing. Though, that is outside the scope of this course.

## The Next Step Beyond Abstract Classes

Interfaces are the natural evolution of abstract classes:

- **Abstract Classes**: "Here's some common code, but you must implement these specific methods"
- **Interfaces**: "Here's what you must be able to do, but you choose how to implement it"

Interfaces take the concept of abstract classes one step further by:
- **Removing implementation** - No concrete methods or fields
- **Allowing multiple inheritance** - A class can implement many interfaces
- **Focusing purely on contracts** - What a class must be able to do