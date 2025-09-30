# Interface Inheritance

An interface can extend another interface. As usual, this would make the sub-interface include all the methods of the parent interface.\
An interface can extend multiple interfaces.

### Interface Extending Interface
```mermaid
classDiagram
    class Drawable {
        <<interface>>
        _+ draw() void_
        _+ setColor(color : String) void_
    }

    
    class Shape {
        <<interface>>
        _+ getArea() double_
        _+ getPerimeter() double_
    }
    
    class DrawableShape {
        <<interface>>
        _+ draw() void_
        _+ setColor(color : String) void_
        _+ getArea() double_
        _+ getPerimeter() double_
    }

    
    Drawable <|-- DrawableShape
    Shape <|-- DrawableShape
    DrawableShape <|.. Square
```

## Complex Interface Hierarchy

Interfaces generally specify what a class must/can do, or what a class _is_. So in order to collect multiple behaviours, a class can implement multiple interfaces.

In the below example, all methods are repeated for clarity, but in practice, you would not repeat the methods in subclasses or sub
interfaces.

### Multiple Interface Inheritance
```mermaid
classDiagram
    class Flyable {
        <<interface>>
        _+ fly() void_
        _+ canFly() boolean_
    }
    
    class Swimmable {
        <<interface>>
        _+ swim() void_
        _+ canSwim() boolean_
    }
    
    class Walkable {
        <<interface>>
        _+ walk() void_
        _+ canWalk() boolean_
    }
    
    class Animal {
        <<interface>>
        _+ eat() void_
        _+ sleep() void_
        _+ makeSound() void_
    }
    
    class FlyingAnimal {
        <<interface>>
        _+ fly() void_
        _+ canFly() boolean_
        _+ eat() void_
        _+ sleep() void_
        _+ makeSound() void_
        _+ getMaxAltitude() double_
        _+ land() void_
    }
    
    class AmphibiousAnimal {
        <<interface>>
        _+ fly() void_  
        _+ canFly() boolean_
        _+ swim() void_
        _+ canSwim() boolean_
        _+ walk() void_
        _+ canWalk() boolean_
        _+ eat() void_
        _+ sleep() void_
        _+ makeSound() void_
        _+ getMaxAltitude() double_
        _+ land() void_
        _+ getMaxDepth() double_
        _+ surface() void_
        _+ getMaxSpeed() double_
        _+ run() void_
        _+ migrate() void_
        _+ getHabitat() String_
    }
    
    Animal <|-- FlyingAnimal
    Flyable <|-- FlyingAnimal
    Swimmable <|-- AmphibiousAnimal
    FlyingAnimal <|-- AmphibiousAnimal
    Walkable <|-- AmphibiousAnimal
```
