# What are Interfaces?

## Understanding Interfaces

An **interface** in Java is a reference type that defines a contract for classes to follow. Unlike abstract classes, interfaces cannot contain any implementation - they only define what methods a class must implement.

Think of an interface as a **contract** or **agreement** that specifies what a class must be able to do, without saying how it should do it.

## Key Characteristics of Interfaces

### 1. **No Implementation**
Interfaces only contain method signatures - no method bodies:

```java
interface Drawable {
    void draw();
    void setColor(String color);
    double getArea();
}
```

### 2. **All Methods are Public and Abstract**
By default, all methods in an interface are:
- `public` - accessible from anywhere
- `abstract` - must be implemented by implementing classes

```java
interface Playable {
    void play();        // Same as: public abstract void play();
    void pause();       // Same as: public abstract void pause();
    void stop();        // Same as: public abstract void stop();
}
```

### 3. **No Constructors**
Interfaces cannot have constructors because they cannot be instantiated:

```java
interface Shape {
    // No constructors allowed
    double getArea();
    double getPerimeter();
}
```

### 4. **No Instance Variables**
Interfaces cannot have instance variables, only constants:

```java
interface Constants {
    int MAX_SIZE = 100;        // Same as: public static final int MAX_SIZE = 100;
    String DEFAULT_NAME = "Unknown";  // Same as: public static final String DEFAULT_NAME = "Unknown";
}
```

## Interface vs Abstract Class

### Abstract Class
```java
abstract class Animal {
    protected String name;  // Can have fields
    
    public Animal(String name) {  // Can have constructors
        this.name = name;
    }
    
    public void eat() {  // Can have concrete methods
        System.out.println(name + " is eating");
    }
    
    public abstract void makeSound();  // Can have abstract methods
}
```

### Interface
```java
interface Animal {
    // No fields allowed (except constants)
    // No constructors allowed
    // No concrete methods allowed
    
    void makeSound();  // Only abstract methods
    void move();
    void eat();
}
```

## Real-World Example: Media Player

### Interface Definition
```java
interface MediaPlayer {
    void play();
    void pause();
    void stop();
    void next();
    void previous();
    String getCurrentTrack();
}
```

### Multiple Implementations
```java
class MusicPlayer implements MediaPlayer {
    private String currentSong;
    
    @Override
    public void play() {
        System.out.println("Playing music: " + currentSong);
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
    public void next() {
        System.out.println("Next song");
    }
    
    @Override
    public void previous() {
        System.out.println("Previous song");
    }
    
    @Override
    public String getCurrentTrack() {
        return currentSong;
    }
}

class VideoPlayer implements MediaPlayer {
    private String currentVideo;
    
    @Override
    public void play() {
        System.out.println("Playing video: " + currentVideo);
    }
    
    @Override
    public void pause() {
        System.out.println("Video paused");
    }
    
    @Override
    public void stop() {
        System.out.println("Video stopped");
    }
    
    @Override
    public void next() {
        System.out.println("Next video");
    }
    
    @Override
    public void previous() {
        System.out.println("Previous video");
    }
    
    @Override
    public String getCurrentTrack() {
        return currentVideo;
    }
}
```

## Interface Constants

Interfaces can contain constants, which are implicitly `public static final`:

```java
interface MathConstants {
    double PI = 3.14159;
    double E = 2.71828;
    int MAX_ITERATIONS = 1000;
}

class Calculator implements MathConstants {
    public double calculateCircleArea(double radius) {
        return PI * radius * radius;  // Using interface constant
    }
}
```

## Why Use Interfaces?

### 1. **Multiple Inheritance**
A class can implement multiple interfaces:

```java
interface Flyable {
    void fly();
}

interface Swimmable {
    void swim();
}

class Duck implements Flyable, Swimmable {
    @Override
    public void fly() {
        System.out.println("Duck is flying");
    }
    
    @Override
    public void swim() {
        System.out.println("Duck is swimming");
    }
}
```

### 2. **Loose Coupling**
Code depends on interfaces, not concrete classes:

```java
class MediaController {
    private MediaPlayer player;  // Depends on interface, not specific implementation
    
    public MediaController(MediaPlayer player) {
        this.player = player;
    }
    
    public void playMedia() {
        player.play();  // Works with any MediaPlayer implementation
    }
}
```

### 3. **Polymorphism**
Different implementations can be treated uniformly:

```java
MediaPlayer[] players = {
    new MusicPlayer(),
    new VideoPlayer(),
    new AudioBookPlayer()
};

for (MediaPlayer player : players) {
    player.play();  // Each plays differently, but same interface
}
```

## Common Interface Patterns

### 1. **Capability Interfaces**
Interfaces that define what an object can do:

```java
interface Drawable {
    void draw();
}

interface Movable {
    void move(int x, int y);
}

interface Resizable {
    void resize(double factor);
}
```

### 2. **Service Interfaces**
Interfaces that define services:

```java
interface DatabaseService {
    void save(Object data);
    Object load(String id);
    void delete(String id);
}

interface EmailService {
    void sendEmail(String to, String subject, String body);
    void sendBulkEmail(String[] recipients, String subject, String body);
}
```

### 3. **Listener Interfaces**
Interfaces for event handling:

```java
interface ButtonClickListener {
    void onClick();
}

interface MouseListener {
    void onMouseMove(int x, int y);
    void onMouseClick(int x, int y);
}
```

## Summary

Interfaces are powerful tools that:

- **Define contracts** without implementation
- **Enable multiple inheritance** in Java
- **Promote loose coupling** and flexibility
- **Enable polymorphism** with different implementations
- **Focus purely on what** a class must be able to do

In the next article, we'll explore how interfaces compare to abstract classes and when to use each approach.
