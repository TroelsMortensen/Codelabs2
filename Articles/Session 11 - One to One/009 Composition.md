# Composition Relationship

**Composition** is a "part-of" relationship where one class contains another class as an essential component. The contained object cannot exist independently of the container - it's created, managed, and destroyed by the container. This represents the strongest form of relationship. 

Let's assume class `A` contains class `B`, A --> B. When this is a composition, it means only A _knows_ about the instance of B. No other class knows about the instance of B. When A is destroyed, B is also destroyed.

Again, we can use the parent-child terminology to describe this relationship. A is the parent, and B is the child. The child in this case cannot exist without the parent.

## Key Characteristics

- **"Part-of" relationship**: The child object is an integral part of the parent
- **Dependent existence**: The child object cannot exist without the parent
- **Exclusive ownership**: Only one parent can own the child
- **Shared lifecycle**: When the parent is destroyed, the child is also destroyed

## How Composition Works in Java

Composition is implemented through:
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

```java	
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