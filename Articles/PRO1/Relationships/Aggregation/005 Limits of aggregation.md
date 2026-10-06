# Limits of aggregation

This relationship is primarily used in the _modelling_ part. You can express the intent in UML diagrams as a concept, but we cannot really enforce it in the code.

## The problem

Consider a `Car` that receives the engine as a parameter:

```java
public Car(String make, String model, Engine engine)
{
    this.make = make;
    this.model = model;
    this.engine = engine;
}
```

Given that the `Engine` is created elsewhere, nothing stops you from giving that same `Engine` instance to another `Car`:

```java
public class CarTest
{
    public static void main(String[] args)
    {
        Engine engine = new Engine("V8", 400, "Gasoline");
        Car car1 = new Car("Ford", "Mustang", engine);
        Car car2 = new Car("Chevrolet", "Camaro", engine);
        // Same engine in two cars — aggregation intent is broken
    }
}
```

And now we are back to this being an association. There are various hacks to make it more difficult to violate aggregation, but it is still possible.

## So why use aggregation at all?

- In **UML**, aggregation documents your intent: "this is a whole-part relationship, and the part can be transferred."
- In **code**, aggregation looks almost identical to association. The difference is conceptual, not something Java enforces for you.

That is why aggregation is used less often in practice than association and composition. When ownership is truly exclusive and the part cannot exist alone, use composition instead. When objects just know about each other with no whole-part meaning, use association.

## Bottom line

Association versus aggregation is a matter of interpretation and intent. It is rarely super clear from the code alone. Use the empty diamond in diagrams when you want to communicate weak ownership — but do not expect the compiler to police it.

<Quiz>
{
  "Type": "TrueFalseQuiz",
  "Statements": [
    {
      "Text": "Java automatically prevents the same Engine from being installed in two cars.",
      "IsCorrect": false
    },
    {
      "Text": "Aggregation is mainly useful to express intent in UML diagrams.",
      "IsCorrect": true
    },
    {
      "Text": "In code, aggregation often looks the same as association.",
      "IsCorrect": true
    }
  ],
  "Hint": "Read the CarTest example and the bottom line on this page."
}
</Quiz>
