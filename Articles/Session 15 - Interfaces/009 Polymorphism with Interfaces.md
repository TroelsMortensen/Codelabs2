# Polymorphism with Interfaces

## Interface Polymorphism

Polymorphism with interfaces works similarly to polymorphism with abstract classes, but with even more flexibility. Since a class can implement multiple interfaces, you can treat the same object as different types depending on which interface you're using.

## Basic Interface Polymorphism

### Simple Example
```java
interface Drawable {
    void draw();
}

interface Movable {
    void move(int x, int y);
}

class Circle implements Drawable, Movable {
    private int x, y, radius;
    
    public Circle(int x, int y, int radius) {
        this.x = x;
        this.y = y;
        this.radius = radius;
    }
    
    @Override
    public void draw() {
        System.out.println("Drawing circle at (" + x + ", " + y + ") with radius " + radius);
    }
    
    @Override
    public void move(int x, int y) {
        this.x = x;
        this.y = y;
    }
}

class Rectangle implements Drawable, Movable {
    private int x, y, width, height;
    
    public Rectangle(int x, int y, int width, int height) {
        this.x = x;
        this.y = y;
        this.width = width;
        this.height = height;
    }
    
    @Override
    public void draw() {
        System.out.println("Drawing rectangle at (" + x + ", " + y + ") with size " + width + "x" + height);
    }
    
    @Override
    public void move(int x, int y) {
        this.x = x;
        this.y = y;
    }
}
```

### Using Polymorphism
```java
public class Main {
    public static void main(String[] args) {
        Circle circle = new Circle(10, 20, 5);
        Rectangle rectangle = new Rectangle(30, 40, 10, 15);
        
        // Polymorphism with Drawable interface
        Drawable[] drawables = {circle, rectangle};
        for (Drawable drawable : drawables) {
            drawable.draw(); // Each draws differently
        }
        
        // Polymorphism with Movable interface
        Movable[] movables = {circle, rectangle};
        for (Movable movable : movables) {
            movable.move(100, 200); // Each moves differently
        }
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
}

interface VolumeControl {
    void setVolume(int volume);
    int getVolume();
}

interface Trackable {
    String getCurrentTrack();
    void nextTrack();
    void previousTrack();
}
```

### Different Implementations
```java
class MusicPlayer implements MediaPlayer, VolumeControl, Trackable {
    private String currentSong;
    private int volume;
    private String[] playlist;
    private int currentIndex;
    
    public MusicPlayer() {
        this.volume = 50;
        this.playlist = new String[]{"Song1", "Song2", "Song3"};
        this.currentIndex = 0;
        this.currentSong = playlist[currentIndex];
    }
    
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
    public void setVolume(int volume) {
        this.volume = volume;
        System.out.println("Music volume set to: " + volume);
    }
    
    @Override
    public int getVolume() {
        return volume;
    }
    
    @Override
    public String getCurrentTrack() {
        return currentSong;
    }
    
    @Override
    public void nextTrack() {
        currentIndex = (currentIndex + 1) % playlist.length;
        currentSong = playlist[currentIndex];
        System.out.println("Next track: " + currentSong);
    }
    
    @Override
    public void previousTrack() {
        currentIndex = (currentIndex - 1 + playlist.length) % playlist.length;
        currentSong = playlist[currentIndex];
        System.out.println("Previous track: " + currentSong);
    }
}

class VideoPlayer implements MediaPlayer, VolumeControl, Trackable {
    private String currentVideo;
    private int volume;
    private String[] videoList;
    private int currentIndex;
    
    public VideoPlayer() {
        this.volume = 75;
        this.videoList = new String[]{"Video1", "Video2", "Video3"};
        this.currentIndex = 0;
        this.currentVideo = videoList[currentIndex];
    }
    
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
    public void setVolume(int volume) {
        this.volume = volume;
        System.out.println("Video volume set to: " + volume);
    }
    
    @Override
    public int getVolume() {
        return volume;
    }
    
    @Override
    public String getCurrentTrack() {
        return currentVideo;
    }
    
    @Override
    public void nextTrack() {
        currentIndex = (currentIndex + 1) % videoList.length;
        currentVideo = videoList[currentIndex];
        System.out.println("Next video: " + currentVideo);
    }
    
    @Override
    public void previousTrack() {
        currentIndex = (currentIndex - 1 + videoList.length) % videoList.length;
        currentVideo = videoList[currentIndex];
        System.out.println("Previous video: " + currentVideo);
    }
}

class AudioBookPlayer implements MediaPlayer, VolumeControl, Trackable {
    private String currentChapter;
    private int volume;
    private String[] chapters;
    private int currentIndex;
    
    public AudioBookPlayer() {
        this.volume = 60;
        this.chapters = new String[]{"Chapter1", "Chapter2", "Chapter3"};
        this.currentIndex = 0;
        this.currentChapter = chapters[currentIndex];
    }
    
    @Override
    public void play() {
        System.out.println("Playing audiobook: " + currentChapter);
    }
    
    @Override
    public void pause() {
        System.out.println("Audiobook paused");
    }
    
    @Override
    public void stop() {
        System.out.println("Audiobook stopped");
    }
    
    @Override
    public void setVolume(int volume) {
        this.volume = volume;
        System.out.println("Audiobook volume set to: " + volume);
    }
    
    @Override
    public int getVolume() {
        return volume;
    }
    
    @Override
    public String getCurrentTrack() {
        return currentChapter;
    }
    
    @Override
    public void nextTrack() {
        currentIndex = (currentIndex + 1) % chapters.length;
        currentChapter = chapters[currentIndex];
        System.out.println("Next chapter: " + currentChapter);
    }
    
    @Override
    public void previousTrack() {
        currentIndex = (currentIndex - 1 + chapters.length) % chapters.length;
        currentChapter = chapters[currentIndex];
        System.out.println("Previous chapter: " + currentChapter);
    }
}
```

### Polymorphic Usage
```java
public class MediaController {
    public static void main(String[] args) {
        // Create different media players
        MusicPlayer musicPlayer = new MusicPlayer();
        VideoPlayer videoPlayer = new VideoPlayer();
        AudioBookPlayer audioBookPlayer = new AudioBookPlayer();
        
        // Polymorphism with MediaPlayer interface
        MediaPlayer[] players = {musicPlayer, videoPlayer, audioBookPlayer};
        for (MediaPlayer player : players) {
            player.play();
            player.pause();
            player.stop();
            System.out.println("---");
        }
        
        // Polymorphism with VolumeControl interface
        VolumeControl[] volumeControls = {musicPlayer, videoPlayer, audioBookPlayer};
        for (VolumeControl control : volumeControls) {
            control.setVolume(80);
            System.out.println("Current volume: " + control.getVolume());
        }
        
        // Polymorphism with Trackable interface
        Trackable[] trackables = {musicPlayer, videoPlayer, audioBookPlayer};
        for (Trackable trackable : trackables) {
            System.out.println("Current track: " + trackable.getCurrentTrack());
            trackable.nextTrack();
        }
    }
}
```

## Interface as Method Parameters

You can use interfaces as parameter types to make methods more flexible:

```java
interface Drawable {
    void draw();
}

interface Movable {
    void move(int x, int y);
}

class Canvas {
    // Method that works with any Drawable
    public void drawShape(Drawable shape) {
        shape.draw();
    }
    
    // Method that works with any Movable
    public void moveShape(Movable shape, int x, int y) {
        shape.move(x, y);
    }
    
    // Method that works with shapes that are both Drawable and Movable
    public void drawAndMove(Drawable drawable, Movable movable, int x, int y) {
        movable.move(x, y);
        drawable.draw();
    }
}

class Circle implements Drawable, Movable {
    private int x, y, radius;
    
    public Circle(int x, int y, int radius) {
        this.x = x;
        this.y = y;
        this.radius = radius;
    }
    
    @Override
    public void draw() {
        System.out.println("Drawing circle at (" + x + ", " + y + ") with radius " + radius);
    }
    
    @Override
    public void move(int x, int y) {
        this.x = x;
        this.y = y;
    }
}

// Usage
public class Main {
    public static void main(String[] args) {
        Canvas canvas = new Canvas();
        Circle circle = new Circle(10, 20, 5);
        
        // Using as Drawable
        canvas.drawShape(circle);
        
        // Using as Movable
        canvas.moveShape(circle, 100, 200);
        
        // Using as both
        canvas.drawAndMove(circle, circle, 50, 75);
    }
}
```

## Interface Collections

You can store different implementations in collections using interface types:

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

public class Zoo {
    public static void main(String[] args) {
        // Array of Animal references
        Animal[] animals = {
            new Dog(),
            new Cat(),
            new Bird(),
            new Dog(),
            new Cat()
        };
        
        // Polymorphic behavior
        for (Animal animal : animals) {
            animal.makeSound();
            animal.move();
            System.out.println("---");
        }
        
        // Count different types
        int dogCount = 0, catCount = 0, birdCount = 0;
        for (Animal animal : animals) {
            if (animal instanceof Dog) {
                dogCount++;
            } else if (animal instanceof Cat) {
                catCount++;
            } else if (animal instanceof Bird) {
                birdCount++;
            }
        }
        
        System.out.println("Dogs: " + dogCount);
        System.out.println("Cats: " + catCount);
        System.out.println("Birds: " + birdCount);
    }
}
```

## Interface Casting

You can cast between interfaces and classes:

```java
interface Drawable {
    void draw();
}

interface Movable {
    void move(int x, int y);
}

class Circle implements Drawable, Movable {
    private int x, y, radius;
    
    public Circle(int x, int y, int radius) {
        this.x = x;
        this.y = y;
        this.radius = radius;
    }
    
    @Override
    public void draw() {
        System.out.println("Drawing circle at (" + x + ", " + y + ") with radius " + radius);
    }
    
    @Override
    public void move(int x, int y) {
        this.x = x;
        this.y = y;
    }
}

public class Main {
    public static void main(String[] args) {
        Circle circle = new Circle(10, 20, 5);
        
        // Cast to interface
        Drawable drawable = (Drawable) circle;
        drawable.draw();
        
        // Cast to another interface
        Movable movable = (Movable) circle;
        movable.move(100, 200);
        
        // Cast back to class
        Circle circle2 = (Circle) drawable;
        circle2.draw();
        circle2.move(50, 75);
    }
}
```

## Benefits of Interface Polymorphism

### 1. **Flexibility**
```java
// Can easily swap implementations
interface DatabaseService {
    void save(Object data);
    Object load(String id);
}

class MySQLDatabase implements DatabaseService {
    @Override
    public void save(Object data) {
        System.out.println("Saving to MySQL");
    }
    
    @Override
    public Object load(String id) {
        System.out.println("Loading from MySQL");
        return null;
    }
}

class PostgreSQLDatabase implements DatabaseService {
    @Override
    public void save(Object data) {
        System.out.println("Saving to PostgreSQL");
    }
    
    @Override
    public Object load(String id) {
        System.out.println("Loading from PostgreSQL");
        return null;
    }
}

class Application {
    private DatabaseService database;
    
    public Application(DatabaseService database) {
        this.database = database;
    }
    
    public void saveData(Object data) {
        database.save(data); // Works with any DatabaseService implementation
    }
}
```

### 2. **Testability**
```java
// Easy to create mock implementations for testing
class MockDatabase implements DatabaseService {
    @Override
    public void save(Object data) {
        System.out.println("Mock: Saving data");
    }
    
    @Override
    public Object load(String id) {
        System.out.println("Mock: Loading data");
        return "Mock data";
    }
}

// Use mock in tests
public class TestApplication {
    public static void main(String[] args) {
        Application app = new Application(new MockDatabase());
        app.saveData("Test data");
    }
}
```

## Summary

Interface polymorphism provides:

- **Flexibility** - Easy to swap implementations
- **Loose coupling** - Code depends on interfaces, not concrete classes
- **Testability** - Easy to create mock implementations
- **Extensibility** - Easy to add new implementations
- **Multiple inheritance** - Objects can be treated as different types
- **Code reuse** - Same code works with different implementations

This makes interfaces essential for creating maintainable, flexible, and testable code.
