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

    public Car(String make, String model)
    {
        this.make = make;
        this.model = model;
    }

    public Engine removeEngine()
    {
        Engine removedEngine = this.engine;
        this.engine = null;
        return removedEngine;
    }

    public void installEngine(Engine engine)
    {
        if (this.engine != null)
        {
            System.out.println("Cannot install engine - car already has an engine");
            return;
        }
        this.engine = engine;
        System.out.println(make + " " + model + " now has " + engine.getEngineSpecs());
    }

    public void startCar()
    {
        if (engine != null)
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
      "Text": "installEngine refuses a second engine while one is already installed.",
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
