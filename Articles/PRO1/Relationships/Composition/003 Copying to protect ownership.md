# Copying to protect ownership

Sometimes it is inconvenient to pass every piece of room information into the house. If the room needs many parameters, the parameter list becomes too long.

You might want:

```java
public void addRoom(Room room)
```

But then the room object is created somewhere else, outside the house. Two different objects now have a reference to the same room — and that **breaks** composition.

## The problem with direct getters

The same issue appears with getters that return the real child:

```java
public class House
{
    private Room livingRoom;

    // DON'T DO THIS — breaks composition
    public Room getLivingRoom()
    {
        return livingRoom;
    }
}
```

**Why this is problematic:**

- External code can modify the room directly without the house knowing
- Multiple objects could hold references to the same room
- Breaks exclusive ownership

## The solution: copies

Instead of returning (or storing) the actual child, create a **copy**. That preserves composition while still allowing access to the child's data.

### Method 1: Copy constructor

```java{16-21}
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

    public Room(Room other)
    {
        this.roomType = other.getRoomType();
        this.area = other.getArea();
        this.hasWindow = other.hasWindow();
    }

    public String getRoomType() { return roomType; }
    public double getArea() { return area; }
    public boolean hasWindow() { return hasWindow; }

    public String getRoomInfo()
    {
        return roomType + " (" + area + " sq ft" + (hasWindow ? ", with window" : "") + ")";
    }
}
```

Safe getter on `House`:

```java{13-16}
public class House
{
    private String address;
    private Room livingRoom;

    public House(String address)
    {
        this.address = address;
        this.livingRoom = new Room("Living Room", 300.0, true);
    }

    public Room getLivingRoomCopy()
    {
        return new Room(livingRoom);
    }
}
```

### Method 2: Custom copy method

```java{15-18}
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

    public Room createCopy()
    {
        return new Room(this.roomType, this.area, this.hasWindow);
    }

    public String getRoomType() { return roomType; }
    public double getArea() { return area; }
    public boolean hasWindow() { return hasWindow; }
}
```

And `addRoom` that accepts a `Room` but stores a copy:

```java{14-18}
public class House
{
    private String address;
    private List<Room> rooms;

    public House(String address)
    {
        this.address = address;
        this.rooms = new ArrayList<>();
    }

    public void addRoom(Room room)
    {
        Room newRoom = room.createCopy();
        this.rooms.add(newRoom);
        System.out.println("Added " + newRoom.getRoomType() + " to house at " + address);
    }
}
```

## Key benefits

1. **Preserves composition**: The original child remains exclusively owned by the parent
2. **Data access**: External code can still read child information
3. **Safety**: Modifications to the copy do not affect the original
4. **Encapsulation**: The internal structure remains protected

Whether you use a copy constructor or a copy method is up to you.

## Recap

We can enforce composition by:

1. The constructor creates the child
2. A method receives data and creates the child internally
3. A method receives a child object and stores a **copy**

<Quiz>
{
    "Type": "SingleChoiceQuiz",
    "Question": "<p>Which method breaks composition?</p>",
    "Options": [
        {
            "Text": "<code>public Room getLivingRoom() { return livingRoom; }</code>",
            "IsCorrect": true
        },
        {
            "Text": "<code>public Room getLivingRoomCopy() { return livingRoom.createCopy(); }</code>",
            "IsCorrect": false
        },
        {
            "Text": "<code>public void addRoom(String type, double area, boolean hasWindow)</code> creating Room inside",
            "IsCorrect": false
        },
        {
            "Text": "<code>public void addRoom(Room room) { rooms.add(room.createCopy()); }</code>",
            "IsCorrect": false
        }
    ],
    "Shuffle": true,
    "Hint": "Returning the original reference lets outsiders share ownership.",
    "Explanation": "A getter that returns the real child breaks exclusive ownership. Returning or storing a copy preserves composition."
}
</Quiz>
