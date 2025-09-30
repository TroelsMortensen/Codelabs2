# Defining Interfaces

## Interface Declaration

Creating an interface in Java is straightforward. You use the `interface` keyword followed by the interface name and a body containing method signatures.

## Basic Syntax

```java
interface InterfaceName {
    // Method signatures (no implementation)
    returnType methodName(parameters);
    
    // Constants (public static final by default)
    dataType CONSTANT_NAME = value;
}
```

## Simple Interface Example

```java
interface Drawable {
    void draw();
    void setColor(String color);
    String getColor();
}
```

## Interface with Constants

```java
interface MathConstants {
    double PI = 3.14159;
    double E = 2.71828;
    int MAX_ITERATIONS = 1000;
    
    double calculateArea(double radius);
    double calculateCircumference(double radius);
}
```

## Interface Naming Conventions

### 1. **Capability Interfaces** (What something can do)
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

interface Playable {
    void play();
    void pause();
    void stop();
}
```

### 2. **Service Interfaces** (What services something provides)
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

interface PaymentService {
    boolean processPayment(double amount);
    String getPaymentMethod();
}
```

### 3. **Listener Interfaces** (Event handling)
```java
interface ButtonClickListener {
    void onClick();
}

interface MouseListener {
    void onMouseMove(int x, int y);
    void onMouseClick(int x, int y);
    void onMouseDoubleClick(int x, int y);
}

interface KeyListener {
    void onKeyPress(char key);
    void onKeyRelease(char key);
}
```

## Interface Method Signatures

### Basic Method Signatures
```java
interface Calculator {
    // Simple methods
    double add(double a, double b);
    double subtract(double a, double b);
    double multiply(double a, double b);
    double divide(double a, double b);
    
    // Methods with parameters
    void setPrecision(int decimalPlaces);
    String formatResult(double result);
    
    // Methods with return types
    boolean isValidInput(String input);
    double[] getHistory();
}
```

### Complex Method Signatures
```java
interface FileManager {
    // Methods with arrays
    String[] listFiles(String directory);
    boolean[] deleteFiles(String[] filePaths);
    
    // Methods with objects
    FileInfo getFileInfo(String filePath);
    void setFilePermissions(String filePath, Permissions permissions);
    
    // Methods with generics (we'll cover this later)
    List<String> readLines(String filePath);
    void writeLines(String filePath, List<String> lines);
}
```

## Interface Constants

All variables in interfaces are implicitly `public static final`:

```java
interface GameConstants {
    // These are all public static final
    int MAX_PLAYERS = 4;
    int MIN_PLAYERS = 1;
    String GAME_VERSION = "1.0.0";
    double GRAVITY = 9.81;
    
    // Method signatures
    void startGame();
    void endGame();
    void pauseGame();
}
```

## Real-World Example: Media Player Interface

```java
interface MediaPlayer {
    // Constants
    int MAX_VOLUME = 100;
    int MIN_VOLUME = 0;
    String DEFAULT_FORMAT = "MP3";
    
    // Playback control
    void play();
    void pause();
    void stop();
    void next();
    void previous();
    
    // Volume control
    void setVolume(int volume);
    int getVolume();
    
    // Track information
    String getCurrentTrack();
    int getCurrentPosition();
    int getTotalDuration();
    
    // Playlist management
    void addToPlaylist(String trackPath);
    void removeFromPlaylist(String trackPath);
    String[] getPlaylist();
    
    // Status information
    boolean isPlaying();
    boolean isPaused();
    boolean isStopped();
}
```

## Interface for Shape System

```java
interface Drawable {
    void draw();
    void setColor(String color);
    String getColor();
}

interface Movable {
    void move(double x, double y);
    double getX();
    double getY();
}

interface Resizable {
    void resize(double factor);
    void setSize(double width, double height);
    double getWidth();
    double getHeight();
}

interface Rotatable {
    void rotate(double angle);
    double getRotation();
    void setRotation(double angle);
}
```

## Interface for Animal System

```java
interface Flyable {
    void fly();
    boolean canFly();
    double getMaxAltitude();
}

interface Swimmable {
    void swim();
    boolean canSwim();
    double getMaxDepth();
}

interface Walkable {
    void walk();
    boolean canWalk();
    double getMaxSpeed();
}

interface Eatable {
    void eat(String food);
    boolean isHungry();
    void setHungry(boolean hungry);
}
```

## Interface Documentation

It's important to document your interfaces clearly:

```java
/**
 * Interface for objects that can be drawn on a canvas.
 * Any class implementing this interface must provide
 * methods for drawing and color management.
 */
interface Drawable {
    /**
     * Draws the object on the current canvas.
     * The specific drawing implementation depends on
     * the concrete class.
     */
    void draw();
    
    /**
     * Sets the color of the object.
     * @param color The color name (e.g., "red", "blue", "green")
     */
    void setColor(String color);
    
    /**
     * Gets the current color of the object.
     * @return The current color name
     */
    String getColor();
}
```

## Interface Best Practices

### 1. **Keep Interfaces Focused**
```java
// Good - focused on one responsibility
interface Drawable {
    void draw();
    void setColor(String color);
}

// Bad - too many responsibilities
interface Shape {
    void draw();
    void setColor(String color);
    void saveToFile(String filename);
    void loadFromFile(String filename);
    void sendEmail(String recipient);
}
```

### 2. **Use Descriptive Names**
```java
// Good - clear and descriptive
interface PaymentProcessor {
    boolean processPayment(double amount);
}

interface EmailSender {
    void sendEmail(String to, String subject, String body);
}

// Bad - vague and unclear
interface Processor {
    boolean process(double amount);
}

interface Sender {
    void send(String to, String subject, String body);
}
```

### 3. **Group Related Methods**
```java
interface FileOperations {
    // File reading
    String readFile(String path);
    String[] readLines(String path);
    
    // File writing
    void writeFile(String path, String content);
    void writeLines(String path, String[] lines);
    
    // File management
    boolean exists(String path);
    void delete(String path);
    void rename(String oldPath, String newPath);
}
```

## Summary

Defining interfaces involves:

- **Using the `interface` keyword** to declare the interface
- **Defining method signatures** without implementation
- **Including constants** if needed (implicitly public static final)
- **Following naming conventions** for clarity
- **Documenting the interface** for other developers
- **Keeping interfaces focused** on single responsibilities

In the next article, we'll explore how classes implement these interfaces and fulfill the contracts they define.
