# Creating the child internally

To keep composition, the parent creates the child. Outside code never holds a reference to the parent's actual child instances.

## Version 1: Create in the constructor

Notice how the constructor instantiates the `Room` objects:

```java{11-12}
public class House
{
    private String address;
    private Room livingRoom;
    private Room kitchen;

    public House(String address)
    {
        this.address = address;
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

    // No setter methods for rooms — they're part of the house
}
```

## Version 2: Create from data parameters

Alternatively, you can provide room information from the outside through the constructor or a method. In either case, you do **not** take a `Room` object as a parameter. You pass in relevant data, and the house creates the `Room` objects internally.

```java{13-18}
public class House
{
    private String address;
    private List<Room> rooms;

    public House(String address)
    {
        this.address = address;
        this.rooms = new ArrayList<>();
    }

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

### Usage

```java
public class CompositionExample
{
    public static void main(String[] args)
    {
        House myHouse = new House("123 Oak Street");
        myHouse.displayHouseInfo();

        myHouse.addRoom("Bathroom", 80.0, true);
        myHouse.addRoom("Study", 120.0, false);

        System.out.println("\nAfter adding more rooms:");
        myHouse.displayHouseInfo();
        System.out.println("Total rooms: " + myHouse.getRoomCount());
    }
}
```

## Recap so far

We can handle composition by:

1. The constructor on the parent class _creates_ the child object
2. A method on the parent receives **data** and creates the child internally

On the next page: what if you want to accept a `Room` object as a parameter? That needs copying.

<Quiz>
{
    "Type": "SingleChoiceQuiz",
    "Question": "<p>Why does <code>addRoom(String roomType, double area, boolean hasWindow)</code> preserve composition?</p>",
    "Options": [
        {
            "Text": "The House creates the Room internally from data — no outside reference to that Room exists",
            "IsCorrect": true
        },
        {
            "Text": "Because it uses an ArrayList",
            "IsCorrect": false
        },
        {
            "Text": "Because the method is public",
            "IsCorrect": false
        },
        {
            "Text": "Because Room has no methods",
            "IsCorrect": false
        }
    ],
    "Shuffle": true,
    "Hint": "Compare taking data vs taking a Room object.",
    "Explanation": "Passing data and creating Room inside House means only the House holds the real Room instance."
}
</Quiz>
