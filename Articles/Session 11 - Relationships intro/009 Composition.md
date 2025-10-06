# Composition Relationship

**Composition** is a "part-of" relationship where one class contains another class as an essential component. The contained object cannot exist independently of the container object - it's created, managed, and destroyed by the container. This represents the strongest form of relationship. 

Let's assume class `A` contains class `B`, A ➜ B. When this is a composition, it means only A _knows_ about the instance of B. No other class knows about the instance of B. When A is destroyed, B is also destroyed.

Again, we can use the parent-child terminology to describe this relationship. A is the parent, and B is the child. The child in this case cannot exist without the parent.



## Key Characteristics

- **"Part-of" relationship**: The child object is an integral part of the parent
- **Dependent existence**: The child object cannot exist without the parent
- **Exclusive ownership**: Only one parent can own the child
- **Shared lifecycle**: When the parent is destroyed, the child is also destroyed

## How Composition Works in Java

Composition is generally implemented through (but there can be other ways):

- **Instance variables** that hold references to other objects, so, similar to association and aggregation, but with stronger ownership.
- **Constructor creation** of contained objects within the container
- **Private access** to prevent external modification
- **No setter methods** for contained objects (they're created internally)
- **No external references** to the child object
- **No getter methods** for the child object. We cannot let others reference the child object. But, we can do something else, to be explained later.

## Example 1: House and Room

Any given room must always exist within a house. It cannot exist without a house. And when the house is destroyed, the room is also destroyed. Obviously, the room is _very_ dependent on the house.

Consider the code below, first we have the `Room` class.

```java
public class Room 
{
    private String roomType;
    private double area;
    private boolean hasWindow;
    
    public Room(String roomType, double area, boolean hasWindow) 
    {
        this.roomType = roomType;
        this.area = area;
        this.hasWindow = hasWindow;
    }
    
    public String getRoomInfo() 
    {
        return roomType + " (" + area + " sq ft" + (hasWindow ? ", with window" : "") + ")";
    }
    
    public double getArea() 
    {
        return area;
    }
}
```

And now the `House` class.

Notice how the constructor instantiates the `Room` objects.

**Version 1**

```java{11-12}
public class House 
{
    private String address;
    private Room livingRoom; // Composition - House owns a Room
    private Room kitchen;    // Composition - House owns a Room
    
    public House(String address) 
    {
        this.address = address;
        // Rooms are created when house is created - composition
        this.livingRoom = new Room("Living Room", 300.0, true);
        this.kitchen = new Room("Kitchen", 150.0, true);
        System.out.println("House at " + address + " created with rooms");
    }
    
    public void displayHouseInfo() 
    {
        System.out.println("House at: " + address);
        System.out.println("  " + livingRoom.getRoomInfo());
        System.out.println("  " + kitchen.getRoomInfo());
        System.out.println("Total area: " + getTotalArea() + " sq ft");
    }
    
    private double getTotalArea() 
    {
        return livingRoom.getArea() + kitchen.getArea();
    }
    
    // No setter methods for rooms - they're part of the house
}
```

Alternatively, we can still provide room information from the outside to the house, either through the constructor or a specific method. But, in either case neither constructor nor method takes a `Room` object as a parameter.\
Instead we pass in relevant information about the rooms, and the house then creates the `Room` objects internally.

Here is an updated example with an `addRoom` method


**Version 2**

```java
public class House 
{
    private String address;
    private List<Room> rooms; // List of rooms - composition
    
    public House(String address) 
    {
        this.address = address;
        this.rooms = new ArrayList<>();
    }
    
    // Method to add a new room
    public void addRoom(String roomType, double area, boolean hasWindow) 
    {
        Room newRoom = new Room(roomType, area, hasWindow);
        this.rooms.add(newRoom);
        System.out.println("Added " + roomType + " to house at " + address);
    }
    
    public void displayHouseInfo() 
    {
        System.out.println("House at: " + address);
        System.out.println("Rooms:");
        for (Room room : rooms) 
        {
            System.out.println("  " + room.getRoomInfo());
        }
        System.out.println("Total area: " + getTotalArea() + " sq ft");
    }
    
    private double getTotalArea() 
    {
        double total = 0;
        for (Room room : rooms) 
        {
            total += room.getArea();
        }
        return total;
    }
    
    public int getRoomCount() 
    {
        return rooms.size();
    }
    
}
```

### Usage Example:

```java
public class CompositionExample 
{
    public static void main(String[] args) 
    {
        House myHouse = new House("123 Oak Street");
        myHouse.displayHouseInfo();
        
        // Add more rooms using the addRoom method
        myHouse.addRoom("Bathroom", 80.0, true);
        myHouse.addRoom("Study", 120.0, false);
        
        System.out.println("\nAfter adding more rooms:");
        myHouse.displayHouseInfo();
        System.out.println("Total rooms: " + myHouse.getRoomCount());
    }
}
```

**Version 3**

Sometimes it is inconvenient to pass in all the information about the room to the house. If the room requires many parameters, the parameter list for the `addRoom` method can become too long.

Instead, you could make the method accept a `Room` object as a parameter:

```java
public void addRoom(Room room) 
```

But, now the room object is created somewhere else, outside the house object. Which means two different objects now have a reference to the same room object.
Remember, this will break the composition relationship, because the room object is now independent of the house object.

How do we fix this? Another application of the copy method.

**The copy concept is further detailed on the next page.**

The idea is that the house accepts a `Room` object as a parameter, and then creates a copy of the room object internally.

Like this:

```java{15}
public class House 
{
    private String address;
    private List<Room> rooms; // List of rooms - composition
    
    public House(String address) 
    {
        this.address = address;
        this.rooms = new ArrayList<>();
    }
    
    // Method to add a new room
    public void addRoom(Room room) 
    {
        Room newRoom = room.copy();  // notice the copy
        this.rooms.add(newRoom);
        System.out.println("Added " + roomType + " to house at " + address);
    }
// more stuff    
}    
```

## Recap

The short version is that we can enforce composition through copying objects.

In the following, parent class is `House`, and child class is `Room`. But I use "parent" and "child" terminology to describe the relationship more generally.

1. The constructor on the parent class creates the child object.
2. The constructor receives arguments, and uses them to create the child object.
3. There is a method on the parent class, which:
   1. Receives the child object as a parameter. And creates a copy. Or,
   2. Receives relevant data so that the child can be created internally.