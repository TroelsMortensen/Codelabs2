# Aggregation Relationship

**Aggregation** is a "has-a" relationship where one class contains or owns another class as a part, but the contained object can exist independently. It represents a whole-part relationship where the part can be shared among multiple wholes or exist on its own.

## Key Characteristics

- **"Has-a" relationship**: One object contains another as a component
- **Independent existence**: The contained object can exist without the container
- **Shared ownership**: The same object can be part of multiple containers
- **Loose coupling**: Container and contained objects have separate lifecycles

## How Aggregation Works in Java

Aggregation is implemented through:
- **Instance variables** that hold references to other objects
- **Constructor parameters** that accept existing objects
- **Setter methods** to assign or change contained objects

## Example 1: Library and Book

```java
public class Book 
{
    private String title;
    private String author;
    private String isbn;
    
    public Book(String title, String author, String isbn) 
    {
        this.title = title;
        this.author = author;
        this.isbn = isbn;
    }
    
    public String getBookInfo() 
    {
        return title + " by " + author + " (ISBN: " + isbn + ")";
    }
    
    public String getTitle() 
    {
        return title;
    }
}

public class Library 
{
    private String libraryName;
    private Book featuredBook; // Aggregation - Library has a Book
    
    public Library(String libraryName) 
    {
        this.libraryName = libraryName;
    }
    
    public void setFeaturedBook(Book book) 
    {
        this.featuredBook = book;
        System.out.println(libraryName + " now features: " + book.getBookInfo());
    }
    
    public void displayFeaturedBook() 
    {
        if (featuredBook != null) 
        {
            System.out.println("Featured at " + libraryName + ": " + featuredBook.getBookInfo());
        } 
        else 
        {
            System.out.println(libraryName + " has no featured book");
        }
    }
}
```

### Usage Example:

```java
public class AggregationExample 
{
    public static void main(String[] args) 
    {
        // Book can exist independently
        Book book1 = new Book("The Great Gatsby", "F. Scott Fitzgerald", "978-0-7432-7356-5");
        Book book2 = new Book("To Kill a Mockingbird", "Harper Lee", "978-0-06-112008-4");
        
        // Libraries can share the same book
        Library centralLibrary = new Library("Central Library");
        Library universityLibrary = new Library("University Library");
        
        centralLibrary.setFeaturedBook(book1);
        universityLibrary.setFeaturedBook(book1); // Same book in different libraries
        
        centralLibrary.displayFeaturedBook();
        universityLibrary.displayFeaturedBook();
        
        // Book still exists even if library is destroyed
        centralLibrary = null; // Library destroyed
        System.out.println("Book still exists: " + book1.getBookInfo());
    }
}
```

## Example 2: Team and Player

```java
public class Player 
{
    private String name;
    private String position;
    private int jerseyNumber;
    
    public Player(String name, String position, int jerseyNumber) 
    {
        this.name = name;
        this.position = position;
        this.jerseyNumber = jerseyNumber;
    }
    
    public String getPlayerInfo() 
    {
        return name + " (#" + jerseyNumber + ") - " + position;
    }
    
    public String getName() 
    {
        return name;
    }
}

public class Team 
{
    private String teamName;
    private Player captain; // Aggregation - Team has a Player as captain
    
    public Team(String teamName) 
    {
        this.teamName = teamName;
    }
    
    public void assignCaptain(Player player) 
    {
        this.captain = player;
        System.out.println(player.getName() + " is now captain of " + teamName);
    }
    
    public void playGame() 
    {
        if (captain != null) 
        {
            System.out.println(teamName + " is playing with captain " + captain.getName());
        } 
        else 
        {
            System.out.println(teamName + " has no captain assigned");
        }
    }
    
    public void changeCaptain(Player newCaptain) 
    {
        if (captain != null) 
        {
            System.out.println(captain.getName() + " is no longer captain");
        }
        this.captain = newCaptain;
        System.out.println(newCaptain.getName() + " is now captain of " + teamName);
    }
}
```

## Example 3: Car and Engine

```java
public class Engine 
{
    private String engineType;
    private int horsepower;
    private String fuelType;
    
    public Engine(String engineType, int horsepower, String fuelType) 
    {
        this.engineType = engineType;
        this.horsepower = horsepower;
        this.fuelType = fuelType;
    }
    
    public void start() 
    {
        System.out.println("Engine started: " + engineType + " (" + horsepower + " HP)");
    }
    
    public String getEngineSpecs() 
    {
        return engineType + " engine, " + horsepower + " HP, " + fuelType;
    }
}

public class Car 
{
    private String make;
    private String model;
    private Engine engine; // Aggregation - Car has an Engine
    
    public Car(String make, String model) 
    {
        this.make = make;
        this.model = model;
    }
    
    public void installEngine(Engine engine) 
    {
        this.engine = engine;
        System.out.println(make + " " + model + " now has " + engine.getEngineSpecs());
    }
    
    public void startCar() 
    {
        if (engine != null) 
        {
            System.out.println("Starting " + make + " " + model + "...");
            engine.start();
        } 
        else 
        {
            System.out.println("Cannot start car - no engine installed");
        }
    }
    
    public void replaceEngine(Engine newEngine) 
    {
        System.out.println("Replacing engine in " + make + " " + model);
        this.engine = newEngine;
        System.out.println("New engine installed: " + newEngine.getEngineSpecs());
    }
}
```

## Key Points About Aggregation

1. **Independent Lifecycle**: The contained object can exist without the container
2. **Shared Ownership**: The same object can be part of multiple containers
3. **Flexible Association**: Objects can be added, removed, or replaced
4. **No Strong Ownership**: Container doesn't control the creation/destruction of contained objects
5. **Bidirectional Access**: Both objects can reference each other

## Aggregation vs Association

- **Association**: Objects work together but are completely independent
- **Aggregation**: Objects have a whole-part relationship, but parts can exist independently
- **Aggregation** implies a stronger relationship than association but weaker than composition

Aggregation is useful when you need to model relationships where objects are components of other objects but can exist and be used independently.
