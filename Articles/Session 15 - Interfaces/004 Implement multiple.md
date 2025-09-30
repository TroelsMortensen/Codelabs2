# Multiple Interface Implementation


A class can extend one class, at most.

A class can implement multiple interfaces.

```mermaid
classDiagram
    class Drawable {
        <<interface>>
        + draw() void
        + setColor(color : String) void
    }
    
    class Movable {
        <<interface>>
        + move(x : double, y : double) void
        + getX() double
        + getY() double
    }
    
    class Resizable {
        <<interface>>
        + resize(factor : double) void
        + getWidth() double
        + getHeight() double
    }
    
    class Circle {
        - x : double
        - y : double
        - radius : double
        + Circle(x : double, y : double, radius : double)
        + draw() void
        + setColor(color : String) void
        + move(x : double, y : double) void
        + getX() double
        + getY() double
        + resize(factor : double) void
        + getWidth() double
        + getHeight() double
    }
    
    Drawable <|.. Circle
    Movable <|.. Circle
    Resizable <|.. Circle
```
