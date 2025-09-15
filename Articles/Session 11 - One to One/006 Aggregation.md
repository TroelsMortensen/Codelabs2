# Aggregation Relationship

**Aggregation** is a "has-a" relationship where one class contains or "owns" another class as a part, but the contained object can exist independently. 

Consider this example: A car has an engine. The engine is a part of the car, but the engine can exist independently of the car. The engine can be removed from the car, and placedd in another car. But at any given time, there is only one engine in the car. And the engine is used by _only_ one car.\
This is a one-to-one relationship, and the ownership is stronger than an association.

Honestly, it is difficult to distinguish between aggregation and association in code. We can use aggregation in our designs to imply intent, but generally it has little to no effect on the code we write. 


Consider the previous exercise:\
For the detective and case exercise, it was explained as a 1 to 1 relationship, but it would not be unreasonable to say that multiple detectives can work on the same case. Making this a "many to one" relationship. We deal with these in depth in the next session. But, I would call the relationships between detective and case an association. The ownership is weaker.

Mostly, association versus aggregation is a matter of interpretation and intent. But it is rarely super clear from the code.

## Key Characteristics

- **"Has-a" relationship**: One object contains another as a component
- **Independent existence**: The contained object can exist without the container
- **Loose coupling**: Container and contained objects have separate lifecycles

## How Aggregation Works in Java

Short version, same as association.

Aggregation is implemented through:
- **Instance variables** that hold references to other objects
- **Constructor parameters** that accept existing objects
- **Setter methods** to assign or change contained objects





## Example 1: Car and Engine

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
        if (engine != null) // checking there actually is an engine
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

## Aggregation vs Association

- **Association**: Objects work together but are completely independent
- **Aggregation**: Objects have a whole-part relationship, but parts can exist independently
- **Aggregation** implies a stronger relationship than association but weaker than composition

Aggregation is useful when you need to model relationships where objects are _components_ of other objects but can exist and be used independently.
