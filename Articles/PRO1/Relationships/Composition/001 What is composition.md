# What is composition

**Composition** is a "part-of" relationship where one class contains another class as an essential component. The contained object cannot exist independently of the container — it is created, managed, and destroyed by the container. This is the strongest form of relationship.

Let's assume class `A` contains class `B` (A ➜ B). When this is a composition, only A _knows_ about the instance of B. No other class knows about that instance of B. When A is destroyed, B is also destroyed.

We can use parent-child terminology: A is the parent, B is the child. The child cannot exist without the parent.

## Key characteristics

- **"Part-of" relationship**: The child object is an integral part of the parent
- **Dependent existence**: The child object cannot exist without the parent
- **Exclusive ownership**: Only one parent can own the child
- **Shared lifecycle**: When the parent is destroyed, the child is also destroyed

## How composition works in Java

Composition is generally implemented through:

- **Instance variables** that hold references to other objects (like association and aggregation, but with stronger ownership)
- **Constructor creation** of contained objects within the container
- **Private access** to prevent external modification
- **No setter methods** that hand out the original child reference
- **No external references** to the child object
- **No getter methods** that return the original child — or getters that return a **copy** instead

## Example: House and Room

Any given room must always exist within a house. It cannot exist without a house. When the house is destroyed, the room is also destroyed.

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

On the next pages you will see how the `House` creates and protects its rooms.

<Quiz>
{
    "Type": "SingleChoiceQuiz",
    "Question": "<p>What makes composition the strongest relationship?</p>",
    "Options": [
        {
            "Text": "Exclusive ownership and a shared lifecycle — the child cannot exist without the parent",
            "IsCorrect": true
        },
        {
            "Text": "Using an ArrayList instead of a single field",
            "IsCorrect": false
        },
        {
            "Text": "Having a dashed UML arrow",
            "IsCorrect": false
        },
        {
            "Text": "Passing the child as a method parameter only",
            "IsCorrect": false
        }
    ],
    "Shuffle": true,
    "Hint": "Read the key characteristics on this page.",
    "Explanation": "Composition means exclusive ownership and dependent existence. When the parent dies, the child dies with it."
}
</Quiz>
