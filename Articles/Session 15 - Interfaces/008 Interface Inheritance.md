# Interface Inheritance

## Interfaces Can Extend Other Interfaces

Just like classes can extend other classes, interfaces can extend other interfaces. This allows you to create hierarchies of interfaces, building more complex contracts from simpler ones.

## Basic Interface Inheritance

### Simple Extension
```java
interface Drawable {
    void draw();
    void setColor(String color);
}

interface Movable extends Drawable {
    void move(double x, double y);
    double getX();
    double getY();
}
```

### Multiple Interface Extension
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

// Interface extending multiple interfaces
interface Shape extends Drawable, Movable, Resizable {
    double getArea();
    double getPerimeter();
}
```

## Real-World Example: Media System

### Base Interfaces
```java
interface Playable {
    void play();
    void pause();
    void stop();
}

interface VolumeControl {
    void setVolume(int volume);
    int getVolume();
    void mute();
    void unmute();
}

interface Trackable {
    String getCurrentTrack();
    int getCurrentPosition();
    int getTotalDuration();
}
```

### Extended Interfaces
```java
// Audio player extends multiple base interfaces
interface AudioPlayer extends Playable, VolumeControl, Trackable {
    void setEqualizer(int[] settings);
    void setRepeatMode(boolean repeat);
    void setShuffleMode(boolean shuffle);
}

// Video player extends multiple base interfaces
interface VideoPlayer extends Playable, VolumeControl, Trackable {
    void setBrightness(int brightness);
    void setContrast(int contrast);
    void setFullscreen(boolean fullscreen);
}

// Media manager combines all capabilities
interface MediaManager extends AudioPlayer, VideoPlayer {
    void switchToAudio();
    void switchToVideo();
    String getCurrentMediaType();
}
```

## Implementation of Extended Interfaces

When a class implements an extended interface, it must implement all methods from the entire inheritance hierarchy:

```java
class MusicPlayer implements AudioPlayer {
    private String currentTrack;
    private int volume;
    private boolean isMuted;
    private boolean isPlaying;
    private boolean repeatMode;
    private boolean shuffleMode;
    
    public MusicPlayer() {
        this.volume = 50;
        this.isMuted = false;
        this.isPlaying = false;
        this.repeatMode = false;
        this.shuffleMode = false;
    }
    
    // Playable interface methods
    @Override
    public void play() {
        isPlaying = true;
        System.out.println("Playing music: " + currentTrack);
    }
    
    @Override
    public void pause() {
        isPlaying = false;
        System.out.println("Music paused");
    }
    
    @Override
    public void stop() {
        isPlaying = false;
        System.out.println("Music stopped");
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
    
    // Trackable interface methods
    @Override
    public String getCurrentTrack() {
        return currentTrack;
    }
    
    @Override
    public int getCurrentPosition() {
        return 0; // Simplified implementation
    }
    
    @Override
    public int getTotalDuration() {
        return 180; // Simplified implementation
    }
    
    // AudioPlayer specific methods
    @Override
    public void setEqualizer(int[] settings) {
        System.out.println("Equalizer settings applied");
    }
    
    @Override
    public void setRepeatMode(boolean repeat) {
        this.repeatMode = repeat;
        System.out.println("Repeat mode: " + (repeat ? "on" : "off"));
    }
    
    @Override
    public void setShuffleMode(boolean shuffle) {
        this.shuffleMode = shuffle;
        System.out.println("Shuffle mode: " + (shuffle ? "on" : "off"));
    }
}
```

## Interface Hierarchy Example: Animal System

### Base Interfaces
```java
interface Animal {
    void eat();
    void sleep();
    void makeSound();
}

interface Flyable {
    void fly();
    boolean canFly();
}

interface Swimmable {
    void swim();
    boolean canSwim();
}

interface Walkable {
    void walk();
    boolean canWalk();
}
```

### Extended Interfaces
```java
// Flying animals
interface FlyingAnimal extends Animal, Flyable {
    double getMaxAltitude();
    void land();
}

// Swimming animals
interface SwimmingAnimal extends Animal, Swimmable {
    double getMaxDepth();
    void surface();
}

// Walking animals
interface WalkingAnimal extends Animal, Walkable {
    double getMaxSpeed();
    void run();
}

// Amphibious animals (can fly, swim, and walk)
interface AmphibiousAnimal extends FlyingAnimal, SwimmingAnimal, WalkingAnimal {
    void migrate();
    String getHabitat();
}
```

### Implementation
```java
class Duck implements AmphibiousAnimal {
    private String habitat;
    private double maxAltitude;
    private double maxDepth;
    private double maxSpeed;
    
    public Duck() {
        this.habitat = "Wetlands";
        this.maxAltitude = 1000.0;
        this.maxDepth = 5.0;
        this.maxSpeed = 20.0;
    }
    
    // Animal interface methods
    @Override
    public void eat() {
        System.out.println("Duck is eating");
    }
    
    @Override
    public void sleep() {
        System.out.println("Duck is sleeping");
    }
    
    @Override
    public void makeSound() {
        System.out.println("Quack! Quack!");
    }
    
    // Flyable interface methods
    @Override
    public void fly() {
        System.out.println("Duck is flying");
    }
    
    @Override
    public boolean canFly() {
        return true;
    }
    
    // Swimmable interface methods
    @Override
    public void swim() {
        System.out.println("Duck is swimming");
    }
    
    @Override
    public boolean canSwim() {
        return true;
    }
    
    // Walkable interface methods
    @Override
    public void walk() {
        System.out.println("Duck is walking");
    }
    
    @Override
    public boolean canWalk() {
        return true;
    }
    
    // FlyingAnimal interface methods
    @Override
    public double getMaxAltitude() {
        return maxAltitude;
    }
    
    @Override
    public void land() {
        System.out.println("Duck is landing");
    }
    
    // SwimmingAnimal interface methods
    @Override
    public double getMaxDepth() {
        return maxDepth;
    }
    
    @Override
    public void surface() {
        System.out.println("Duck is surfacing");
    }
    
    // WalkingAnimal interface methods
    @Override
    public double getMaxSpeed() {
        return maxSpeed;
    }
    
    @Override
    public void run() {
        System.out.println("Duck is running");
    }
    
    // AmphibiousAnimal interface methods
    @Override
    public void migrate() {
        System.out.println("Duck is migrating");
    }
    
    @Override
    public String getHabitat() {
        return habitat;
    }
}
```

## Polymorphism with Interface Hierarchies

You can use different levels of the interface hierarchy for different purposes:

```java
public class Main {
    public static void main(String[] args) {
        Duck duck = new Duck();
        
        // Using as base Animal
        Animal animal = duck;
        animal.eat();
        animal.makeSound();
        
        // Using as Flyable
        Flyable flyer = duck;
        flyer.fly();
        System.out.println("Can fly: " + flyer.canFly());
        
        // Using as Swimmable
        Swimmable swimmer = duck;
        swimmer.swim();
        System.out.println("Can swim: " + swimmer.canSwim());
        
        // Using as Walkable
        Walkable walker = duck;
        walker.walk();
        System.out.println("Can walk: " + walker.canWalk());
        
        // Using as AmphibiousAnimal
        AmphibiousAnimal amphibian = duck;
        amphibian.migrate();
        System.out.println("Habitat: " + amphibian.getHabitat());
    }
}
```

## Interface Constants Inheritance

Constants are inherited from parent interfaces:

```java
interface BaseConstants {
    int MAX_VALUE = 100;
    String DEFAULT_NAME = "Unknown";
}

interface ExtendedConstants extends BaseConstants {
    int MIN_VALUE = 0;
    String ERROR_MESSAGE = "Error occurred";
}

class Implementation implements ExtendedConstants {
    public void useConstants() {
        System.out.println("Max value: " + MAX_VALUE); // From BaseConstants
        System.out.println("Min value: " + MIN_VALUE); // From ExtendedConstants
        System.out.println("Default name: " + DEFAULT_NAME); // From BaseConstants
        System.out.println("Error: " + ERROR_MESSAGE); // From ExtendedConstants
    }
}
```

## Method Resolution in Interface Hierarchies

When interfaces extend other interfaces, method resolution follows the inheritance chain:

```java
interface A {
    void method();
}

interface B extends A {
    void method(); // Same method signature
}

interface C extends B {
    void method(); // Same method signature
}

class Implementation implements C {
    @Override
    public void method() {
        System.out.println("Implementation of method");
    }
}

// All interfaces point to the same implementation
public class Main {
    public static void main(String[] args) {
        Implementation impl = new Implementation();
        
        A a = impl;
        B b = impl;
        C c = impl;
        
        a.method(); // Calls the same implementation
        b.method(); // Calls the same implementation
        c.method(); // Calls the same implementation
    }
}
```

## Best Practices for Interface Inheritance

### 1. **Keep Inheritance Shallow**
```java
// Good - shallow hierarchy
interface Drawable {
    void draw();
}

interface Movable extends Drawable {
    void move(int x, int y);
}

// Bad - deep hierarchy
interface A {
    void method();
}

interface B extends A {
    void method();
}

interface C extends B {
    void method();
}

interface D extends C {
    void method();
}
```

### 2. **Use Composition Over Deep Inheritance**
```java
// Good - composition
interface Drawable {
    void draw();
}

interface Movable {
    void move(int x, int y);
}

interface Shape extends Drawable, Movable {
    double getArea();
}

// Bad - deep inheritance
interface A {
    void method();
}

interface B extends A {
    void method();
}

interface C extends B {
    void method();
}
```

### 3. **Make Interfaces Cohesive**
```java
// Good - related functionality
interface MediaPlayer {
    void play();
    void pause();
    void stop();
}

interface VolumeControl {
    void setVolume(int volume);
    int getVolume();
}

interface MediaController extends MediaPlayer, VolumeControl {
    void nextTrack();
    void previousTrack();
}

// Bad - unrelated functionality
interface MediaPlayer {
    void play();
    void pause();
    void stop();
}

interface DatabaseConnection {
    void connect();
    void disconnect();
}

interface MediaDatabase extends MediaPlayer, DatabaseConnection {
    // Unrelated functionality mixed together
}
```

## Summary

Interface inheritance allows you to:

- **Build complex contracts** from simpler ones
- **Create hierarchies** of related interfaces
- **Combine multiple interfaces** into more comprehensive contracts
- **Maintain polymorphism** at different levels of the hierarchy
- **Inherit constants** from parent interfaces
- **Create focused, cohesive** interface designs

This powerful feature enables you to create sophisticated, flexible designs while maintaining the benefits of interfaces.
