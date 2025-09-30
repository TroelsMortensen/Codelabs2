# Interfaces in UML

## Representing Interfaces in UML

UML (Unified Modeling Language) provides specific notation to represent interfaces and their relationships. In Mermaid class diagrams, we can show interfaces using both the standard interface box notation and the lollipop notation.

## Basic Interface Notation

### Standard Interface Box
Interfaces are shown as rectangles with the `<<interface>>` stereotype:

```mermaid
classDiagram
    class <<interface>> Drawable {
        + draw() void
        + setColor(color : String) void
        + getColor() String
    }
```

### Lollipop Notation
Interfaces can also be shown as circles (lollipops) connected to classes:

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
    
    class <<interface>> Drawable {
        + draw() void
        + setColor(color : String) void
        + getColor() String
    }
    
    Circle ..|> Drawable : implements
```

## Interface Implementation

### Single Interface Implementation
```mermaid
classDiagram
    class <<interface>> Drawable {
        + draw() void
        + setColor(color : String) void
        + getColor() String
    }
    
    class Circle {
        - x : double
        - y : double
        - radius : double
        + Circle(x : double, y : double, radius : double)
        + draw() void
        + setColor(color : String) void
        + getColor() String
    }
    
    class Rectangle {
        - x : double
        - y : double
        - width : double
        - height : double
        + Rectangle(x : double, y : double, width : double, height : double)
        + draw() void
        + setColor(color : String) void
        + getColor() String
    }
    
    Drawable <|.. Circle : implements
    Drawable <|.. Rectangle : implements
```

## Multiple Interface Implementation

### Using Standard Notation
```mermaid
classDiagram
    class <<interface>> Drawable {
        + draw() void
        + setColor(color : String) void
    }
    
    class <<interface>> Movable {
        + move(x : double, y : double) void
        + getX() double
        + getY() double
    }
    
    class <<interface>> Resizable {
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
    
    Drawable <|.. Circle : implements
    Movable <|.. Circle : implements
    Resizable <|.. Circle : implements
```

### Using Lollipop Notation
```mermaid
classDiagram
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
    
    class <<interface>> Drawable {
        + draw() void
        + setColor(color : String) void
    }
    
    class <<interface>> Movable {
        + move(x : double, y : double) void
        + getX() double
        + getY() double
    }
    
    class <<interface>> Resizable {
        + resize(factor : double) void
        + getWidth() double
        + getHeight() double
    }
    
    Circle ..|> Drawable : implements
    Circle ..|> Movable : implements
    Circle ..|> Resizable : implements
```

## Interface Inheritance

### Interface Extending Interface
```mermaid
classDiagram
    class <<interface>> Drawable {
        + draw() void
        + setColor(color : String) void
    }
    
    class <<interface>> Movable {
        + move(x : double, y : double) void
        + getX() double
        + getY() double
    }
    
    class <<interface>> Shape {
        + getArea() double
        + getPerimeter() double
    }
    
    class <<interface>> DrawableShape {
        + draw() void
        + setColor(color : String) void
        + getArea() double
        + getPerimeter() double
    }
    
    class <<interface>> MovableShape {
        + move(x : double, y : double) void
        + getX() double
        + getY() double
        + getArea() double
        + getPerimeter() double
    }
    
    Drawable <|-- DrawableShape : extends
    Shape <|-- DrawableShape : extends
    Movable <|-- MovableShape : extends
    Shape <|-- MovableShape : extends
```

## Real-World Example: Media Player System

### Interface Definitions
```mermaid
classDiagram
    class <<interface>> MediaPlayer {
        + play() void
        + pause() void
        + stop() void
        + next() void
        + previous() void
    }
    
    class <<interface>> VolumeControl {
        + setVolume(volume : int) void
        + getVolume() int
        + mute() void
        + unmute() void
    }
    
    class <<interface>> Trackable {
        + getCurrentTrack() String
        + getCurrentPosition() int
        + getTotalDuration() int
    }
```

### Implementation Classes
```mermaid
classDiagram
    class <<interface>> MediaPlayer {
        + play() void
        + pause() void
        + stop() void
        + next() void
        + previous() void
    }
    
    class <<interface>> VolumeControl {
        + setVolume(volume : int) void
        + getVolume() int
        + mute() void
        + unmute() void
    }
    
    class <<interface>> Trackable {
        + getCurrentTrack() String
        + getCurrentPosition() int
        + getTotalDuration() int
    }
    
    class MusicPlayer {
        - currentSong : String
        - volume : int
        - isMuted : boolean
        - playlist : String[]
        - currentIndex : int
        + MusicPlayer()
        + play() void
        + pause() void
        + stop() void
        + next() void
        + previous() void
        + setVolume(volume : int) void
        + getVolume() int
        + mute() void
        + unmute() void
        + getCurrentTrack() String
        + getCurrentPosition() int
        + getTotalDuration() int
    }
    
    class VideoPlayer {
        - currentVideo : String
        - volume : int
        - isMuted : boolean
        - videoList : String[]
        - currentIndex : int
        + VideoPlayer()
        + play() void
        + pause() void
        + stop() void
        + next() void
        + previous() void
        + setVolume(volume : int) void
        + getVolume() int
        + mute() void
        + unmute() void
        + getCurrentTrack() String
        + getCurrentPosition() int
        + getTotalDuration() int
    }
    
    MediaPlayer <|.. MusicPlayer : implements
    VolumeControl <|.. MusicPlayer : implements
    Trackable <|.. MusicPlayer : implements
    MediaPlayer <|.. VideoPlayer : implements
    VolumeControl <|.. VideoPlayer : implements
    Trackable <|.. VideoPlayer : implements
```

## Interface Constants

### Showing Constants in Interfaces
```mermaid
classDiagram
    class <<interface>> GameConstants {
        <<constant>> MAX_PLAYERS : int = 4
        <<constant>> MIN_PLAYERS : int = 1
        <<constant>> GAME_VERSION : String = "1.0.0"
        <<constant>> GRAVITY : double = 9.81
        + startGame() void
        + endGame() void
        + pauseGame() void
    }
    
    class Game {
        - playerCount : int
        - isRunning : boolean
        + Game(playerCount : int)
        + startGame() void
        + endGame() void
        + pauseGame() void
        + applyGravity() void
    }
    
    GameConstants <|.. Game : implements
```

## Complex Interface Hierarchy

### Multiple Interface Inheritance
```mermaid
classDiagram
    class <<interface>> Flyable {
        + fly() void
        + canFly() boolean
    }
    
    class <<interface>> Swimmable {
        + swim() void
        + canSwim() boolean
    }
    
    class <<interface>> Walkable {
        + walk() void
        + canWalk() boolean
    }
    
    class <<interface>> Animal {
        + eat() void
        + sleep() void
        + makeSound() void
    }
    
    class <<interface>> FlyingAnimal {
        + fly() void
        + canFly() boolean
        + eat() void
        + sleep() void
        + makeSound() void
        + getMaxAltitude() double
        + land() void
    }
    
    class <<interface>> AmphibiousAnimal {
        + fly() void
        + canFly() boolean
        + swim() void
        + canSwim() boolean
        + walk() void
        + canWalk() boolean
        + eat() void
        + sleep() void
        + makeSound() void
        + getMaxAltitude() double
        + land() void
        + getMaxDepth() double
        + surface() void
        + getMaxSpeed() double
        + run() void
        + migrate() void
        + getHabitat() String
    }
    
    Animal <|-- FlyingAnimal : extends
    Flyable <|-- FlyingAnimal : extends
    FlyingAnimal <|-- AmphibiousAnimal : extends
    Swimmable <|-- AmphibiousAnimal : extends
    Walkable <|-- AmphibiousAnimal : extends
```

## UML Notation Rules

### 1. **Interface Stereotype**
- Use `<<interface>>` before the interface name
- Place it above the interface name in the diagram

### 2. **Implementation Relationship**
- Use `<|..` to show implementation
- Interface is typically at the top
- Concrete classes implement interfaces

### 3. **Interface Extension**
- Use `<|--` to show interface inheritance
- Parent interface is typically at the top
- Child interfaces extend parent interfaces

### 4. **Method Visibility**
- `+` for public methods (all interface methods are public)
- `-` for private methods (not applicable to interfaces)
- `#` for protected methods (not applicable to interfaces)

### 5. **Method Parameters**
- Use format: `methodName(parameter : type) returnType`
- Example: `+ calculate(a : double, b : double) double`

### 6. **Constants**
- Use `<<constant>>` stereotype for constants
- Show type and value: `<<constant>> MAX_SIZE : int = 100`

## Best Practices for Interface UML Diagrams

### 1. **Clear Hierarchy**
- Place interfaces at the top
- Show clear implementation relationships
- Group related interfaces together

### 2. **Complete Information**
- Show all interface methods
- Include all constants
- Display all relationships

### 3. **Consistent Naming**
- Use clear, descriptive names
- Follow Java naming conventions
- Be consistent with parameter types

### 4. **Logical Grouping**
- Group related interfaces together
- Use spacing to separate different hierarchies
- Consider the flow of relationships

### 5. **Choose Appropriate Notation**
- Use standard interface boxes for detailed views
- Use lollipop notation for simplified views
- Mix both notations for complex diagrams

## Summary

UML diagrams for interfaces help you:

- **Visualize interface contracts** clearly
- **Identify implementation requirements** for classes
- **Understand relationships** between interfaces and classes
- **Communicate design** to other developers
- **Plan implementation** before coding

The `<<interface>>` stereotype and implementation arrows (`<|..`) make it easy to see which classes implement which interfaces, helping you understand the structure and requirements of your interface-based design.
