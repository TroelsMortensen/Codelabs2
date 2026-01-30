# Data Access Object pattern

Next, we will implement the Data Access Object pattern.

## Required

Some DAOs are required. These are the DAOs for the following entities:
- Stock
- Portfolio
- OwnedStock

Then the domain model from assignment 1 also included entities for StockPriceHistory and Transaction.\
These are less important for the core game play, and you may choose to not implement them.

## Logging

Do keep in mind if there are relevant exceptions, you should log them. You have that functionality from the previous assignment.


## The interface

For each entity type, you should create an interface. You could call it `EntityDao`, e.g. `StockDao`.

The interface should contain the methods you will need to perform CRUD operations on the entity type.

You will need to get an entity by ID, get all entities, add an entity, update an entity, and delete an entity.

For the "get all entities" method, just keep it simple for now. As your system grows, you can consider adding filtering options. Or adding more complex queries.

## The implementation

For each entity type you should create a class implementing the interface. You could call it `FileEntityDao`, e.g. `FileStockDao`. If/when you swap to Postgres, you could call it `PostgresEntityDao`, e.g. `PostgresStockDao`.

## The constructor

The constructor should receive a FileUnitOfWork object, i.e. the implementation, not the interface.

I recommend also getting all the entities from the UoW, finding the highest ID, and storing that in a static field variable. This will make it easier to assign new IDs to new entities.

```java
private static int nextId = 1;

public StockPurchaseFileDAO(FileUnitOfWork uow)
{
    this.uow = uow;
    findNextId();
}
```

## Create method

This method accepts an entity as a parameter.

If relevant, increment and set the ID of the new entity. Use the static field variable to get the next ID.

From the UoW, get the list of entities. 

Add the entity to the list.

## Update method

This method accepts an entity as a parameter.

You have three options here:

1. Delete the entity from the list, and add the new entity.
2. Find the entity in the list and update the fields.
3. Set the entity. The List interface has a `set(index, element)` method, which overwrites the element at the given index with the new element. 

Either way, you first need to get the list of entities from the UoW.

Consider what to do if the entity is not found in the list. Should you throw an exception? Should you return false? 

## Delete method

This method accepts an ID as a parameter.

Get the list of entities from the UoW.

Delete the entity from the list.

Consider what to do if the entity is not found in the list. Should you throw an exception? Should you return false? 

## Get by ID method

This method accepts an ID as a parameter.

Get the list of entities from the UoW.

Find the entity in the list with the given ID.

Return the entity.

Consider what to do if the entity is not found in the list. Should you throw an exception? Should you return null? Do you use the Option pattern?

## Get by something else method

For some of your entity types, you may want to find an entity by something other than ID. You can add methods for this as needed.

## Get all method

This method returns a list of all entities.

**Optional challenge:** Returning a list of entities gives the caller the option to do something with the entities, like modifying an entity or deleting an entity. This is not ideal, as there are specific methods for such modifications. 

You may consider returning an immutable list. You may consider copying each entity in the list to a new immutable list. This will break the connection to the data held in the UoW, ensuring other classes cannot misuse the List.

For this project I am fine with just accepting this potential problem.

When you attach an actual database, this is no longer a problem.