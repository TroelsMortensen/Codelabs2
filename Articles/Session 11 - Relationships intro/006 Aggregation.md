# Aggregation Relationship

**Aggregation** is a "has-a" relationship where one class contains or "owns" another class as a part, but the contained object can exist independently. The ownership is stronger than an association.

Consider this example: A car has an engine. The engine is a part of the car, but the engine can exist independently of the car. The engine can be removed from the car, and placed in another car. But at any given time, there is only one engine in the car. And the engine is used by _only_ one car.\
This is a one-to-one relationship, and the ownership is stronger than an association. If this was an association, the engine could be used by multiple cars. That does not really make sense, so we need to use aggregation instead.

Honestly, it is difficult to distinguish between aggregation and association in code. We can use aggregation in our designs (UML diagrams) to imply intent, but generally it has little to no effect on the code we write. 

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

So, those points look a lot like association. The only difference is that the ownership is stronger.

## Example 1: Car and Engine

In this example, the `Car` class has an `Engine` object. The `Engine` object is a part of the `Car` object, but the `Engine` object can exist independently of the `Car` object. The `Engine` object is used by _only_ one `Car` object.

First, the `Engine` class:

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
```

And then the `Car` class. Notice the field variable `engine` is of type `Engine`, in line 5.\
Further, there are methods to install and remove the engine.

```java{5}
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

    public Engine removeEngine()
    {
        Engine removedEngine = this.engine; // save the engine to a variable
        this.engine = null; // set the engine to null, i.e. now the car has no engine
        return removedEngine;
    }
    
    public void installEngine(Engine engine) 
    {
        if(this.engine != null)
        {
            System.out.println("Cannot install engine - car already has an engine");
            return; // exit the method
        }
        this.engine = engine; // set the engine to the new engine
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
}
```

## Aggregation vs Association

- **Association**: Objects work together but are completely independent
- **Aggregation**: Objects have a whole-part relationship, but parts can exist independently
- **Aggregation** implies a stronger relationship than association but weaker than composition

Aggregation is useful when you need to model relationships where objects are _components_ of other objects but can exist and be used independently.


## Potential issues with aggregation
This relationship is primarily used in the _modelling_ part, i.e. you can express the intent in UML diagrams as a concept, but we cannot really enforce it in the code.

If you consider the above Car, it receives the engine as a parameter in the constructor:

```java
public Car(String make, String model, Engine engine)
{
    this.make = make;
    this.model = model;
    this.engine = engine;
}
```

But, given that the `Engine` is created elsewhere, nothing is stopping you from giving that `Engine` instance to another `Car` object. Like this:

```java
public class CarTest {
    public static void main(String[] args) {
        Engine engine = new Engine("V8", 400, "Gasoline");
        Car car1 = new Car("Ford", "Mustang", engine);
        Car car2 = new Car("Chevrolet", "Camaro", engine);
    }
}
```

And now we are back to this being an association. There are various hacks to make it more difficult to violate the aggregation, but it is still possible.

So, the association is conceptual, but does not affect your code. And it is therefore rarely used in UML diagrams.