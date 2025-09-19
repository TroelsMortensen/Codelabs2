# Copy Method for Composition

In composition relationships, we typically don't provide getter methods for child objects because it could break the principle of exclusive ownership, reducing the relationship to an association. However, there are scenarios where you might need to provide access to child object data without compromising the strong ownership of the composition relationship.

## The Problem with Direct Getters

Consider the following code snippet, we have a `House` class, which contains a `Room` object.
And we are trying to provide a getter method for the `livingRoom` object.

```java
public class House 
{
    private Room livingRoom; // Composition - exclusive ownership
    
    // DON'T DO THIS - breaks composition
    public Room getLivingRoom() 
    {
        return livingRoom; // Returns direct reference - violates composition
    }
}
```

**Why this is problematic:**
- External code can modify the room directly, say, updating the area of the room or changing some other data of the Room object. Without the house knowing about it.
- Multiple objects could hold references to the same room, which could lead to inconsistencies.
- Breaks the "exclusive ownership" principle of composition.

## The Solution: Copy Methods

Instead of returning the actual child object, we can return a **copy** of it. This preserves the composition relationship while still allowing access to the child's data.



There are several ways to implement this copy functionality.

### Method 1: Copy Constructor Approach

This is the simplest way to implement the copy functionality. We add a copy constructor to the `Room` class.

Notice in the copy constructor, we are receiving a `Room` object as a parameter, called `other`. On the `other` object, we are accessing the fields of the `Room` object.\

```java
public class Room 
{
    private String roomType;
    private double area;
    private boolean hasWindow;
    
    // Original constructor
    public Room(String roomType, double area, boolean hasWindow) 
    {
        this.roomType = roomType;
        this.area = area;
        this.hasWindow = hasWindow;
    }
    
    // Copy constructor
    public Room(Room other) 
    {
        this.roomType = other.getRoomType();
        this.area = other.getArea();
        this.hasWindow = other.hasWindow();
    }
    
    // Getters for the copy, we are not providing a setter for the copy
    public String getRoomType() { return roomType; }
    public double getArea() { return area; }
    public boolean hasWindow() { return hasWindow; }
    
    public String getRoomInfo() 
    {
        return roomType + " (" + area + " sq ft" + (hasWindow ? ", with window" : "") + ")";
    }
}
```

And then the get-method on the `House` class. It returns a copy of its room, instead of the room instance itself.
```java{15}
public class House 
{
    private String address;
    private Room livingRoom; // Composition - exclusive ownership
    
    public House(String address) 
    {
        this.address = address;
        this.livingRoom = new Room("Living Room", 300.0, true);
    }
    
    // Safe getter that returns a copy
    public Room getLivingRoomCopy() 
    {
        return new Room(livingRoom); // Returns a copy, not the original
    }
    
    public void displayHouseInfo() 
    {
        System.out.println("House at: " + address);
        System.out.println("  " + livingRoom.getRoomInfo());
    }
}
```

### Method 2: Custom Copy Method Approach

This approach uses a custom method to create a copy of the child object.

```java{17}
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
    
    // Custom copy method
    public Room createCopy() 
    {
        return new Room(this.roomType, this.area, this.hasWindow);
    }
    
    // Getters
    public String getRoomType() { return roomType; }
    public double getArea() { return area; }
    public boolean hasWindow() { return hasWindow; }
    
    public String getRoomInfo() 
    {
        return roomType + " (" + area + " sq ft" + (hasWindow ? ", with window" : "") + ")";
    }
}
```

And then the get-method on the `House` class. It returns a _copy_ of its room, instead of the room instance itself. This time using a copy method instead of a copy constructor.

```java{15}
public class House 
{
    private String address;
    private Room livingRoom;
    
    public House(String address) 
    {
        this.address = address;
        this.livingRoom = new Room("Living Room", 300.0, true);
    }
    
    // Safe getter using custom copy method
    public Room getLivingRoomCopy() 
    {
        return livingRoom.createCopy(); // Returns a copy using custom method
    }
    
    public void displayHouseInfo() 
    {
        System.out.println("House at: " + address);
        System.out.println("  " + livingRoom.getRoomInfo());
    }
}
```


## Key Benefits of Copy Method or Copy Constructor

1. **Preserves Composition**: The original child object remains exclusively owned by the parent
2. **Data Access**: External code can still access child object information
3. **Safety**: Modifications to the copy don't affect the original
4. **Encapsulation**: The internal structure remains protected

Whether you decide to use a copy constructor or copy method is up to you.\
In rare cases, the copy method wins, when you need different ways of copying the child object. Though, that is so rare, I cannot think up an example.