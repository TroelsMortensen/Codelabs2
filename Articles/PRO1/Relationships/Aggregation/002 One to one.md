# One to one aggregation

## Example: Car and Engine

The `Car` class has an `Engine` object. The engine is a part of the car but can exist independently. Only one engine per car, and one car per engine at a time.

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

And the `Car` class. Notice the field `engine`, plus methods to install and remove the engine:

```java{5}
public class Car
{
    private String make;
    private String model;
    private Engine engine;

    // Creates a car with no engine installed yet
    public Car(String make, String model)
    {
        this.make = make;
        this.model = model;
    }

    // Removes the engine and returns it, so it can be used elsewhere
    public Engine removeEngine()
    {
        Engine removedEngine = this.engine;
        this.engine = null;
        return removedEngine;
    }

    // Installs an engine; throws if the car already has one
    public void installEngine(Engine engine)
    {
        if (this.engine != null)
        {
            throw new IllegalStateException("Cannot install engine - car already has an engine");
        }
        this.engine = engine;
        System.out.println(make + " " + model + " now has " + engine.getEngineSpecs());
    }

    // Starts the car; throws if no engine is installed
    public void startCar()
    {
        if (engine == null)
        {
            throw new IllegalStateException("Cannot start car - no engine installed");
        }
        System.out.println("Starting " + make + " " + model + "...");
        engine.start();
    }
}
```

### Usage

```java
Engine v8 = new Engine("V8", 400, "Gasoline");
Car mustang = new Car("Ford", "Mustang");
mustang.installEngine(v8);
mustang.startCar();

Engine removed = mustang.removeEngine();
// Engine still exists independently — can be installed in another car
```

### Conceptual meaning

The child object (`Engine`) is a component of the parent (`Car`), but it can exist independently. The parent has "weak" ownership and methods to manage the relationship. Other cars should not reference the same engine at the same time — that is the intent of aggregation.

<Quiz>
{
  "Type": "TrueFalseQuiz",
  "Statements": [
    {
      "Text": "removeEngine returns the engine so it can live on outside the car.",
      "IsCorrect": true
    },
    {
      "Text": "installEngine throws IllegalStateException if the car already has an engine.",
      "IsCorrect": true
    },
    {
      "Text": "After removeEngine, the Engine object is automatically destroyed.",
      "IsCorrect": false
    }
  ],
  "Hint": "Look at removeEngine and installEngine on this page."
}
</Quiz>
