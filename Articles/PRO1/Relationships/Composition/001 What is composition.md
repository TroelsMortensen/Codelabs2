# What is composition

**Composition** is a "part-of" relationship where one class contains another class as an essential component. The contained object cannot exist independently of the container (or owner or parent object) — it is created, managed, and destroyed by the container. This is the strongest form of relationship.

Almost always, the composed child object can be "unwrapped" and merged into the parent object. This may not be pretty, but it is possible. Often the separate object just make it easier to work with.

Let's assume class `A` contains class `B` (A ➜ B). When this is a composition, _only_ A knows about the instance of B. No other class knows about that instance of B. When A is destroyed, B is also destroyed.

If we can use parent-child terminology: A is the parent, B is the child. The child cannot exist without the parent.

## Key characteristics

- **"Part-of" relationship**: The child object is an integral part of the parent
- **Dependent existence**: The child object cannot exist without the parent, it simply does not make sense to have it without the parent
- **Exclusive ownership**: Only one parent can own the child(ren)
- **Shared lifecycle**: When the parent is destroyed (garbage collected), the child is also destroyed (marked for garbage collection)

## How composition works in Java

Composition is generally implemented through:

- **Instance variables** that hold references to other objects (like association and aggregation, but with stronger ownership)
- **Constructor creation** of contained objects within the container
- **Private access** to prevent external modification
- **No setter methods** that accepts the original child reference
- **No external references** to the child object
- **No getter methods** that return the original child — or getters that return a **copy** instead

## Example: House and Room

Any given room must always exist within a house. It cannot exist without a house. A room cannot exist within two houses at the same time. When the house is destroyed, the room is also destroyed. Sure, maybe you can build a modular house, in some way, but for the most part - and this example - a room is a part of a house.

Here is a room class:

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

On the next pages you will see how the `House` _creates_ and _protects_ its rooms.

