# Implementing Interfaces

## How Classes Implement Interfaces

When a class implements an interface, it promises to provide implementations for all the methods defined in that interface. This is done using the `implements` keyword.

## Basic Implementation

### Interface Definition
```java
interface Drawable {
    void draw();
    void setColor(String color);
    String getColor();
}
```

### Class Implementation
```java
class Circle implements Drawable {
    private String color;
    private double x, y, radius;
    
    public Circle(double x, double y, double radius) {
        this.x = x;
        this.y = y;
        this.radius = radius;
        this.color = "black"; // default color
    }
    
    @Override
    public void draw() {
        System.out.println("Drawing circle at (" + x + ", " + y + ") with radius " + radius);
    }
    
    @Override
    public void setColor(String color) {
        this.color = color;
    }
    
    @Override
    public String getColor() {
        return color;
    }
}
```

## Multiple Interface Implementation

A class can implement multiple interfaces:

```java
interface Drawable {
    void draw();
    void setColor(String color);
}

interface Movable {
    void move(double x, double y);
    double getX();
    double getY();
}

interface Resizable {
    void resize(double factor);
    double getWidth();
    double getHeight();
}

class Rectangle implements Drawable, Movable, Resizable {
    private String color;
    private double x, y, width, height;
    
    public Rectangle(double x, double y, double width, double height) {
        this.x = x;
        this.y = y;
        this.width = width;
        this.height = height;
        this.color = "black";
    }
    
    // Drawable interface methods
    @Override
    public void draw() {
        System.out.println("Drawing rectangle at (" + x + ", " + y + ") with size " + width + "x" + height);
    }
    
    @Override
    public void setColor(String color) {
        this.color = color;
    }
    
    // Movable interface methods
    @Override
    public void move(double x, double y) {
        this.x = x;
        this.y = y;
    }
    
    @Override
    public double getX() {
        return x;
    }
    
    @Override
    public double getY() {
        return y;
    }
    
    // Resizable interface methods
    @Override
    public void resize(double factor) {
        this.width *= factor;
        this.height *= factor;
    }
    
    @Override
    public double getWidth() {
        return width;
    }
    
    @Override
    public double getHeight() {
        return height;
    }
}
```

## Interface Constants Usage

When implementing interfaces with constants, those constants are available in the class that implements the interface. Notice how the `MIN_PLAYERS` and `MAX_PLAYERS` constants are used in the `Game` class:

```java{16}
interface GameConstants {
    int MAX_PLAYERS = 4;
    int MIN_PLAYERS = 1;
    String GAME_VERSION = "1.0.0";
    double GRAVITY = 9.81;
    
    void startGame();
    void endGame();
}

class Game implements GameConstants {
    private int playerCount;
    private boolean isRunning;
    
    public Game(int playerCount) {
        if (playerCount < MIN_PLAYERS || playerCount > MAX_PLAYERS) {
            throw new IllegalArgumentException("Invalid player count");
        }
        this.playerCount = playerCount;
        this.isRunning = false;
    }
    
    @Override
    public void startGame() {
        if (!isRunning) {
            isRunning = true;
            System.out.println("Starting game version " + GAME_VERSION + " with " + playerCount + " players");
        }
    }
    
    @Override
    public void endGame() {
        if (isRunning) {
            isRunning = false;
            System.out.println("Game ended");
        }
    }
    
    public void applyGravity() {
        System.out.println("Applying gravity: " + GRAVITY);
    }
}
```

Given that the constants are public, they actually be acccess from any class, whether they implement the interface or not. This works like whenever you reference something static on a class.

```java
class GameTest {
    public static void main(String[] args) {
        System.out.println(GameConstants.MAX_PLAYERS);
    }
}
```

## Implementation Rules

### 1. **Must Implement All Methods**
```java
interface Example {
    void method1();
    void method2();
}
```

The below will cause a compilation error, because one method is not implemented.
```java
// This will cause a compilation error
class BadImplementation implements Example {
    @Override
    public void method1() {
        // Only implementing method1, missing method2
    }
}
```

This will work:
```java
// Correct implementation
class GoodImplementation implements Example {
    @Override
    public void method1() {
        System.out.println("Method 1");
    }
    
    @Override
    public void method2() {
        System.out.println("Method 2");
    }
}
```

### 2. **Method Signatures Must Match**


```java
interface Example {
    void method(String param);
}
```

This will not work, because the parameter type is different. If you include the `@Override` annotation, IntelliJ will check if the method signature matches the interface method signature.

```java
// This will cause a compilation error
class BadImplementation implements Example {
    @Override
    public void method(int param) { // Wrong parameter type
        // ...
    }
}
```

This will work:
```java
// Correct implementation
class GoodImplementation implements Example {
    @Override
    public void method(String param) { // Correct parameter type
        System.out.println("Method with: " + param);
    }
}
```

### 3. **Access Modifiers Must Be Public**

All methods in an interface are public, so they must be public in the class that implements the interface.

```java
interface Example {
    void method();
}
```

This will not work, because the method in the concrete class is not public, but package-private.

```java
// This will cause a compilation error
class BadImplementation implements Example {
    @Override
    void method() { // Missing public
        // ...
    }
}
```

This will work, because the access modifiers match.

```java
// Correct implementation
class GoodImplementation implements Example {
    @Override
    public void method() { // Must be public
        System.out.println("Method");
    }
}
```
