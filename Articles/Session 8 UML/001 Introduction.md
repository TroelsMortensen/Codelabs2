# Introduction

This learning path introduces UML (Unified Modeling Language), and how to use it to create class diagrams. However, it will only cover concepts, you have learned about so far. In upcoming sessions, you will see new programming concepts, and how to express them in UML.

I will have a different article combining all the UML concepts, and how to use them in Astah, so that everything is in one place.

[UML overview](https://troelsmortensen.github.io/Codelabs2/article/TroelsMortensen/UML%20Class%20Diagrams)

## Conceptual

In the Objects learning path, you saw a video about objects, and how we define them by their:
- name (class name)
- data (field variables)
- behaviour (methods)

It looked something like this:

![obj template](Resources/Objects%20concept.png)

This, however, was an informal, detail-lacking approach, I just made up on the spot.

Instead, we want a standardized approach, so that everyone aggrees on what different notation means, and how to express different elements of programming. The is where UML enters the picture
  
## What is UML

UML stands for **Unified Modeling Language**. It is a standardized graphical language used to visualize, specify, construct, and document the artifacts of a software system.

Think of it as a blueprint. 

![blueprint](Resources/blueprint.jpg)

Just like an architect creates blueprints before building a house, software developers use UML to create a design for a program before they start coding.

Key points about UML:
- It is a **visual language**, using diagrams to represent system components. We use it for planning and documentation of software systems.
- It is **standardized**, meaning the symbols and notations have consistent meanings for everyone.
- It is **not a programming language**, nor is it specific to Java.
- It helps in communicating complex ideas about software design to different stakeholders (developers, project managers, clients).

There are many types of UML diagrams, each for a specific purpose (e.g., Use Case diagrams, Sequence diagrams, State diagrams). In this learning path, we will focus on one of the most common type: the **Class Diagram**. And for now, only a subset. As we move along in the course, you will see more UML too.

Above is a blueprint for a house, below is a blueprint, or, _class diagram_, for a library system:

![example library](Resources/ExampleLibrary.png)