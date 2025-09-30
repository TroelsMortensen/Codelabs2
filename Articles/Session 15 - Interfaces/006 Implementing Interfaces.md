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

## Real-World Example: Media Player System

### Interface Definitions
```java
interface MediaPlayer {
    void play();
    void pause();
    void stop();
    String getCurrentTrack();
}

interface VolumeControl {
    void setVolume(int volume);
    int getVolume();
    void mute();
    void unmute();
}

interface PlaylistManager {
    void addTrack(String trackPath);
    void removeTrack(String trackPath);
    String[] getPlaylist();
    void nextTrack();
    void previousTrack();
}
```

### Implementation
```java
class MusicPlayer implements MediaPlayer, VolumeControl, PlaylistManager {
    private String currentTrack;
    private int volume;
    private boolean isMuted;
    private String[] playlist;
    private int currentTrackIndex;
    
    public MusicPlayer() {
        this.volume = 50;
        this.isMuted = false;
        this.playlist = new String[0];
        this.currentTrackIndex = 0;
    }
    
    // MediaPlayer interface methods
    @Override
    public void play() {
        if (currentTrack != null) {
            System.out.println("Playing: " + currentTrack);
        } else {
            System.out.println("No track selected");
        }
    }
    
    @Override
    public void pause() {
        System.out.println("Music paused");
    }
    
    @Override
    public void stop() {
        System.out.println("Music stopped");
    }
    
    @Override
    public String getCurrentTrack() {
        return currentTrack;
    }
    
    // VolumeControl interface methods
    @Override
    public void setVolume(int volume) {
        if (volume >= 0 && volume <= 100) {
            this.volume = volume;
            System.out.println("Volume set to: " + volume);
        }
    }
    
    @Override
    public int getVolume() {
        return isMuted ? 0 : volume;
    }
    
    @Override
    public void mute() {
        isMuted = true;
        System.out.println("Muted");
    }
    
    @Override
    public void unmute() {
        isMuted = false;
        System.out.println("Unmuted");
    }
    
    // PlaylistManager interface methods
    @Override
    public void addTrack(String trackPath) {
        String[] newPlaylist = new String[playlist.length + 1];
        System.arraycopy(playlist, 0, newPlaylist, 0, playlist.length);
        newPlaylist[playlist.length] = trackPath;
        playlist = newPlaylist;
        System.out.println("Added track: " + trackPath);
    }
    
    @Override
    public void removeTrack(String trackPath) {
        // Implementation to remove track from playlist
        System.out.println("Removed track: " + trackPath);
    }
    
    @Override
    public String[] getPlaylist() {
        return playlist.clone();
    }
    
    @Override
    public void nextTrack() {
        if (playlist.length > 0) {
            currentTrackIndex = (currentTrackIndex + 1) % playlist.length;
            currentTrack = playlist[currentTrackIndex];
            System.out.println("Next track: " + currentTrack);
        }
    }
    
    @Override
    public void previousTrack() {
        if (playlist.length > 0) {
            currentTrackIndex = (currentTrackIndex - 1 + playlist.length) % playlist.length;
            currentTrack = playlist[currentTrackIndex];
            System.out.println("Previous track: " + currentTrack);
        }
    }
}
```

## Interface Constants Usage

When implementing interfaces with constants:

```java
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

## Polymorphism with Interfaces

Interfaces enable polymorphism - treating different implementations uniformly:

```java
interface Animal {
    void makeSound();
    void move();
}

class Dog implements Animal {
    @Override
    public void makeSound() {
        System.out.println("Woof! Woof!");
    }
    
    @Override
    public void move() {
        System.out.println("Dog is running");
    }
}

class Cat implements Animal {
    @Override
    public void makeSound() {
        System.out.println("Meow! Meow!");
    }
    
    @Override
    public void move() {
        System.out.println("Cat is walking");
    }
}

class Bird implements Animal {
    @Override
    public void makeSound() {
        System.out.println("Tweet! Tweet!");
    }
    
    @Override
    public void move() {
        System.out.println("Bird is flying");
    }
}

// Using polymorphism
public class Main {
    public static void main(String[] args) {
        Animal[] animals = {
            new Dog(),
            new Cat(),
            new Bird()
        };
        
        for (Animal animal : animals) {
            animal.makeSound();
            animal.move();
            System.out.println("---");
        }
    }
}
```

## Interface as Method Parameters

You can use interfaces as parameter types:

```java
interface Drawable {
    void draw();
}

class Circle implements Drawable {
    @Override
    public void draw() {
        System.out.println("Drawing circle");
    }
}

class Rectangle implements Drawable {
    @Override
    public void draw() {
        System.out.println("Drawing rectangle");
    }
}

class Canvas {
    public void drawShape(Drawable shape) {
        shape.draw(); // Works with any Drawable implementation
    }
    
    public void drawShapes(Drawable[] shapes) {
        for (Drawable shape : shapes) {
            shape.draw();
        }
    }
}

// Usage
public class Main {
    public static void main(String[] args) {
        Canvas canvas = new Canvas();
        
        Drawable[] shapes = {
            new Circle(),
            new Rectangle(),
            new Circle()
        };
        
        canvas.drawShapes(shapes);
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

// This will cause a compilation error
class BadImplementation implements Example {
    @Override
    public void method1() {
        // Only implementing method1, missing method2
    }
}

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

// This will cause a compilation error
class BadImplementation implements Example {
    @Override
    public void method(int param) { // Wrong parameter type
        // ...
    }
}

// Correct implementation
class GoodImplementation implements Example {
    @Override
    public void method(String param) { // Correct parameter type
        System.out.println("Method with: " + param);
    }
}
```

### 3. **Access Modifiers Must Be Public**
```java
interface Example {
    void method();
}

// This will cause a compilation error
class BadImplementation implements Example {
    @Override
    void method() { // Missing public
        // ...
    }
}

// Correct implementation
class GoodImplementation implements Example {
    @Override
    public void method() { // Must be public
        System.out.println("Method");
    }
}
```

## Summary

Implementing interfaces involves:

- **Using the `implements` keyword** to declare interface implementation
- **Providing implementations** for all interface methods
- **Using `@Override` annotation** for clarity
- **Ensuring method signatures match** exactly
- **Making all methods public** (as required by interfaces)
- **Supporting multiple interface implementation** for flexibility

In the next article, we'll explore how interfaces can extend other interfaces, creating inheritance hierarchies for interfaces.
