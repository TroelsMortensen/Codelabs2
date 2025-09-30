# Multiple Interfaces

## The Power of Multiple Interface Implementation

One of the key advantages of interfaces over abstract classes is that a class can implement multiple interfaces. This allows you to combine different capabilities and create flexible, modular designs.

## Basic Multiple Interface Implementation

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

class Circle implements Drawable, Movable, Resizable {
    private String color;
    private double x, y, radius;
    
    public Circle(double x, double y, double radius) {
        this.x = x;
        this.y = y;
        this.radius = radius;
        this.color = "black";
    }
    
    // Drawable interface methods
    @Override
    public void draw() {
        System.out.println("Drawing circle at (" + x + ", " + y + ") with radius " + radius);
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
        this.radius *= factor;
    }
    
    @Override
    public double getWidth() {
        return radius * 2;
    }
    
    @Override
    public double getHeight() {
        return radius * 2;
    }
}
```

## Real-World Example: Smartphone

```java
interface Phone {
    void makeCall(String number);
    void receiveCall();
    void endCall();
}

interface Camera {
    void takePhoto();
    void recordVideo();
    void setFlash(boolean on);
}

interface MusicPlayer {
    void playMusic();
    void pauseMusic();
    void nextSong();
    void previousSong();
}

interface InternetBrowser {
    void openWebsite(String url);
    void refreshPage();
    void goBack();
    void goForward();
}

class Smartphone implements Phone, Camera, MusicPlayer, InternetBrowser {
    private boolean isCallActive;
    private boolean isMusicPlaying;
    private boolean isFlashOn;
    private String currentWebsite;
    
    public Smartphone() {
        this.isCallActive = false;
        this.isMusicPlaying = false;
        this.isFlashOn = false;
        this.currentWebsite = "";
    }
    
    // Phone interface methods
    @Override
    public void makeCall(String number) {
        if (!isCallActive) {
            isCallActive = true;
            System.out.println("Calling " + number);
        }
    }
    
    @Override
    public void receiveCall() {
        isCallActive = true;
        System.out.println("Incoming call");
    }
    
    @Override
    public void endCall() {
        if (isCallActive) {
            isCallActive = false;
            System.out.println("Call ended");
        }
    }
    
    // Camera interface methods
    @Override
    public void takePhoto() {
        System.out.println("Taking photo" + (isFlashOn ? " with flash" : ""));
    }
    
    @Override
    public void recordVideo() {
        System.out.println("Recording video" + (isFlashOn ? " with flash" : ""));
    }
    
    @Override
    public void setFlash(boolean on) {
        isFlashOn = on;
        System.out.println("Flash " + (on ? "on" : "off"));
    }
    
    // MusicPlayer interface methods
    @Override
    public void playMusic() {
        if (!isMusicPlaying) {
            isMusicPlaying = true;
            System.out.println("Playing music");
        }
    }
    
    @Override
    public void pauseMusic() {
        if (isMusicPlaying) {
            isMusicPlaying = false;
            System.out.println("Music paused");
        }
    }
    
    @Override
    public void nextSong() {
        System.out.println("Next song");
    }
    
    @Override
    public void previousSong() {
        System.out.println("Previous song");
    }
    
    // InternetBrowser interface methods
    @Override
    public void openWebsite(String url) {
        currentWebsite = url;
        System.out.println("Opening website: " + url);
    }
    
    @Override
    public void refreshPage() {
        System.out.println("Refreshing page: " + currentWebsite);
    }
    
    @Override
    public void goBack() {
        System.out.println("Going back");
    }
    
    @Override
    public void goForward() {
        System.out.println("Going forward");
    }
}
```

## Polymorphism with Multiple Interfaces

You can use different interfaces to access different capabilities:

```java
public class Main {
    public static void main(String[] args) {
        Smartphone phone = new Smartphone();
        
        // Using as Phone
        Phone phoneInterface = phone;
        phoneInterface.makeCall("123-456-7890");
        phoneInterface.endCall();
        
        // Using as Camera
        Camera cameraInterface = phone;
        cameraInterface.setFlash(true);
        cameraInterface.takePhoto();
        
        // Using as MusicPlayer
        MusicPlayer musicInterface = phone;
        musicInterface.playMusic();
        musicInterface.nextSong();
        
        // Using as InternetBrowser
        InternetBrowser browserInterface = phone;
        browserInterface.openWebsite("https://example.com");
        browserInterface.refreshPage();
    }
}
```

## Interface Segregation

Multiple interfaces allow you to create focused, single-purpose interfaces:

```java
// Instead of one large interface
interface BadSwissArmyKnife {
    void cut();
    void screw();
    void openBottle();
    void openCan();
    void file();
    void saw();
    void measure();
    void magnify();
}

// Better: Multiple focused interfaces
interface CuttingTool {
    void cut();
    void saw();
}

interface ScrewTool {
    void screw();
    void unscrew();
}

interface OpeningTool {
    void openBottle();
    void openCan();
}

interface MeasuringTool {
    void measure();
    void magnify();
}

// A class can implement only what it needs
class PocketKnife implements CuttingTool, OpeningTool {
    @Override
    public void cut() {
        System.out.println("Cutting with knife");
    }
    
    @Override
    public void saw() {
        System.out.println("Sawing with knife");
    }
    
    @Override
    public void openBottle() {
        System.out.println("Opening bottle with knife");
    }
    
    @Override
    public void openCan() {
        System.out.println("Opening can with knife");
    }
}

class MultiTool implements CuttingTool, ScrewTool, OpeningTool, MeasuringTool {
    @Override
    public void cut() {
        System.out.println("Cutting with multi-tool");
    }
    
    @Override
    public void saw() {
        System.out.println("Sawing with multi-tool");
    }
    
    @Override
    public void screw() {
        System.out.println("Screwing with multi-tool");
    }
    
    @Override
    public void unscrew() {
        System.out.println("Unscrewing with multi-tool");
    }
    
    @Override
    public void openBottle() {
        System.out.println("Opening bottle with multi-tool");
    }
    
    @Override
    public void openCan() {
        System.out.println("Opening can with multi-tool");
    }
    
    @Override
    public void measure() {
        System.out.println("Measuring with multi-tool");
    }
    
    @Override
    public void magnify() {
        System.out.println("Magnifying with multi-tool");
    }
}
```

## Method Name Conflicts

When implementing multiple interfaces, you might encounter method name conflicts:

```java
interface Drawable {
    void draw();
}

interface Printable {
    void draw(); // Same method name
}

// This works fine - same method signature
class Document implements Drawable, Printable {
    @Override
    public void draw() {
        System.out.println("Drawing and printing document");
    }
}
```

### Different Method Signatures
```java
interface Drawable {
    void draw();
}

interface DrawableWithColor {
    void draw(String color);
}

class Shape implements Drawable, DrawableWithColor {
    @Override
    public void draw() {
        System.out.println("Drawing shape");
    }
    
    @Override
    public void draw(String color) {
        System.out.println("Drawing shape with color: " + color);
    }
}
```

## Interface Composition

You can combine interfaces to create more complex behaviors:

```java
interface Flyable {
    void fly();
}

interface Swimmable {
    void swim();
}

interface Walkable {
    void walk();
}

// A class can implement any combination
class Duck implements Flyable, Swimmable, Walkable {
    @Override
    public void fly() {
        System.out.println("Duck is flying");
    }
    
    @Override
    public void swim() {
        System.out.println("Duck is swimming");
    }
    
    @Override
    public void walk() {
        System.out.println("Duck is walking");
    }
}

class Penguin implements Swimmable, Walkable {
    @Override
    public void swim() {
        System.out.println("Penguin is swimming");
    }
    
    @Override
    public void walk() {
        System.out.println("Penguin is walking");
    }
}

class Eagle implements Flyable, Walkable {
    @Override
    public void fly() {
        System.out.println("Eagle is flying");
    }
    
    @Override
    public void walk() {
        System.out.println("Eagle is walking");
    }
}
```

## Using Multiple Interfaces in Methods

You can create methods that work with specific interface combinations:

```java
class AnimalZoo {
    public void showFlyingAnimals(Flyable[] animals) {
        for (Flyable animal : animals) {
            animal.fly();
        }
    }
    
    public void showSwimmingAnimals(Swimmable[] animals) {
        for (Swimmable animal : animals) {
            animal.swim();
        }
    }
    
    public void showWalkingAnimals(Walkable[] animals) {
        for (Walkable animal : animals) {
            animal.walk();
        }
    }
    
    public void showAmphibiousAnimals(Swimmable[] swimmers, Walkable[] walkers) {
        System.out.println("Animals that can both swim and walk:");
        for (Swimmable swimmer : swimmers) {
            if (swimmer instanceof Walkable) {
                ((Walkable) swimmer).walk();
                swimmer.swim();
            }
        }
    }
}
```

## Best Practices for Multiple Interfaces

### 1. **Keep Interfaces Focused**
```java
// Good - focused interfaces
interface Drawable {
    void draw();
}

interface Movable {
    void move(int x, int y);
}

// Bad - too many responsibilities
interface Shape {
    void draw();
    void move(int x, int y);
    void saveToFile(String filename);
    void sendEmail(String recipient);
}
```

### 2. **Use Descriptive Names**
```java
// Good - clear purpose
interface PaymentProcessor {
    boolean processPayment(double amount);
}

interface EmailSender {
    void sendEmail(String to, String subject, String body);
}

// Bad - vague names
interface Processor {
    boolean process(double amount);
}

interface Sender {
    void send(String to, String subject, String body);
}
```

### 3. **Avoid Interface Pollution**
```java
// Good - only implement what you need
class SimpleShape implements Drawable {
    // Only implements what it actually needs
}

// Bad - implementing interfaces you don't use
class SimpleShape implements Drawable, Movable, Resizable, Rotatable, Colorable {
    // Implements many interfaces but only uses Drawable
}
```

## Summary

Multiple interface implementation allows you to:

- **Combine different capabilities** in a single class
- **Create flexible, modular designs** that are easy to extend
- **Use polymorphism** with different interface types
- **Follow the Interface Segregation Principle** by creating focused interfaces
- **Avoid the limitations** of single inheritance in abstract classes

This powerful feature makes interfaces essential for creating maintainable, flexible object-oriented designs.
