# What are Interfaces?

## Understanding Interfaces

An **interface** in Java is a reference type that defines a contract for classes to follow. Unlike abstract classes, interfaces cannot contain any implementation
(not exact true, but this is how it _should_ be) - they only define what methods a class must implement.

Think of an interface as a **contract** or **agreement** that specifies what a class must be able to do, without saying how it should do it.
## Key Characteristics of Interfaces

### 1. **No Implementation**
Interfaces only contain method signatures - no method bodies:

```java
public interface Drawable {
    public void draw();
    public void setColor(String color);
    public double getArea();
}
```

### 2. **All Methods are Public and Abstract**
By default, all methods in an interface are:
- `public` - accessible from anywhere, even if you omit the `public` keyword
- `abstract` - must be implemented by implementing classes

```java
public interface Playable {
    void play();        // Same as: public abstract void play();
    void pause();       // Same as: public abstract void pause();
    void stop();        // Same as: public abstract void stop();
}
```

### 3. **No Constructors**
Interfaces cannot have constructors because they cannot be instantiated. You instantiate a concrete class, and can assign that to a variable of the interface type.

```java
public interface Shape {
    // No constructors allowed
    double getArea();
    double getPerimeter();
}
```

### 4. **No Instance Variables**
Interfaces cannot have instance variables, so the follow is not allowed:

```java
public interface Constants {
    protected int x;
}
```

Only constants are allowed. This means if you declare a field variable, you must assign it a value, and that value cannot be changed.

```java
public interface Constants {
    int MAX_SIZE = 100;        // Same as: public static final int MAX_SIZE = 100;
    String DEFAULT_NAME = "Unknown";  // Same as: public static final String DEFAULT_NAME = "Unknown";
}
```

## Real-World Example: Media Player

This is a real-world example of an interface. It declares the contract, but we then have multiple implementations of that contract. One is a music player, and the other is a video player. They can perform the same operations, but do it differently.

### Interface Definition

First, the definition of what a media player can do, as an interface.

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

Then, we have multiple implementations of that interface. One is a music player, and the other is a video player. They can perform the same operations, but do it differently.

Notice we use the `implements` keyword to implement the interface. This is similar to the `extends` keyword we used for inheritance.\
A class _extends_ another class.\
A class _implements_ interface(s).

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
```

and here is the implementation of the video player.

```java
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
