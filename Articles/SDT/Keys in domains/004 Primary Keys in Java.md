# Primary Keys in Java

Now let's implement primary keys in our Java entity classes. We'll use the `Planet` and `Spacecraft` classes from our Space Explorer case.

## Adding an ID Field

The simplest approach is to add an `id` field of type `int`:

```java
public class Planet 
{
    private int id;
    private String name;
    private String climateDescription;
    private double distanceFromStarAU;
    private boolean hasAtmosphere;
    private boolean hasLife;
    
    // Constructor and methods...
}
```

But where does the ID value come from? We have several options.

## Setting the IDs

Generally, databases are responsible for creating these IDs. We will somewhat mimic this by letting our data management classes handle this, in session 3.

We need to be able to create a new entity, without knowing what ID it should get.\
We also need the data managers to be able to recreate the entity after loading it from storage.

Therefore:

- Your entity will at least one constructor: 
  - **REQURIED**: one constructor _should not_ receive an ID as parameter, only the other attributes, and 
  - **OPTIONAL**: for convenience, you can include a constructor, which takes the id, so the data manager can re-create the entity. 
- Your entity _should_ have a setId() method, so the ID can be set after the object is created, or after it has been loaded.
(the setId() is actually slightly dangerous, as someone could update the id of an entity, which is not allowed. We will just rely on discipline and good design to avoid this.)

## Example: Spacecraft Class

Let's apply the same pattern to the `Spacecraft` class:

```java
public class Spacecraft 
{
    private int id;
    private String name;
    private String model;
    private int capacity;
    
    // When creating for the first time
    public Spacecraft(String name, String model, int capacity) 
    {
        this.name = name;
        this.model = model;
        this.capacity = capacity;
    }
    
    // optional constructor, for loading from storage
    public Spacecraft(int id, String name, String model, int capacity) 
    {
        this.id = id;
        this.name = name;
        this.model = model;
        this.capacity = capacity;
    }

    // used by the data manager to set the ID after the entity has been created,
    // or after the entity has been loaded from storage.
    public void setId(int id) 
    {
        this.id = id;
    }

    // other methods, getters etc...
}
```

## Summary

- Add an `id` field as the first field in your entity class
- Provide two constructors: one for new entities, one for loading
- Always provide `setId()`, so the ID can be set after the entity has been created, or after it has been loaded from storage.

Next, we'll explore how these primary keys enable us to create relationships between entities using foreign keys.

