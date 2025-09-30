# Interfaces in UML

## Representing Interfaces in UML

UML (Unified Modeling Language) provides specific notation to represent interfaces and their relationships. In class diagrams, we can show interfaces using both the standard interface box notation and the lollipop notation.

## Basic Interface Notation

### Standard Interface Box
Interfaces are shown as rectangles with the `<<interface>>` stereotype:

```mermaid
classDiagram
    class Drawable {
        <<interface>>
        _+ draw() void_
        _+ setColor(color : String) void_
        _+ getColor() String_
    }
```

Otherwise, this looks like just another class.

### Lollipop Notation
Interfaces can also be shown as circles (lollipops) connected to classes. Sometimes this simplifies the diagram, when the methods on the interface are not relevant. Or if you use an interface from the Java library, and that interface is commonly known. Then, showing the details of the interface is not necessary.

```mermaid
classDiagram
    class Circle {
        - x : double
        - y : double
        - radius : double
        + Circle(x : double, y : double, radius : double)
        + draw() void
        + setColor(color : String) void
        + getColor() String
    }
    
    Drawable ()-- Circle
```

## Interface Implementation

When a class _inherits_ from another class, we use a relationship with a full drawn line, and a closed arrowhead:

```mermaid
classDiagram
    Super <|-- Sub
```

For interface implementation, we use a similar relationship line, but with a dotted line instead:

```mermaid
classDiagram
    class SomeInterface {
        <<interface>>
    }
    
    class SomeClass {
    }

    SomeInterface <|.. SomeClass
```



## Conventions

In class diagrams, interfaces are drawn _above_ the class(es) that implement them.\
If a class associates the interface, that class is drawn above or next to the interface:
```mermaid
classDiagram
    class Drawable {
        <<interface>>
        _+ draw() void_
        _+ setColor(color : String) void_
        _+ getColor() String_
    }

    class PaintApp{

    }

    PaintApp --> Drawable
    Drawable <|.. Square
```

## Only some methods are shown

When dealing with abstract super classes, and subclasses, it was not necessary to repeat all the inherited methods in the subclass. That would just be redundant. 

We do the same for interfaces. If a method is declared on the interface, there is no need to also show it in the class that implements the interface.

Like this:

```mermaid
classDiagram
    class SomeInterface {
        <<interface>>
        _+ doSomething() void_
    }

    class SomeClass {
        + otherMethod() void
    }

    SomeInterface <|.. SomeClass
```

The `SomeClass` class has two methods now, one declared only on the class, and another one declared on the interface, but then implemented on the class.