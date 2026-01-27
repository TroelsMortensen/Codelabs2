# Unit of Work pattern

Given that the Data Access Objects will depend on the Unit of Work implementation, you should start with the Unit of Work implementation.

## Logging

Do keep in mind if there are relevant exceptions, you should log them. You have that functionality from the previous assignment.

## The interface

Start by defining the interface, with the three methods you will need. You could call it `UnitOfWork`.

## The implementation

Then create the class implementing the interface. You could call it `FileUnitOfWork`, as it is a file-based implementation of the Unit of Work pattern. If/when you swap to Postgres, you could call it `PostgresUnitOfWork`.

## Collections

It should contain a List for each entity type in your system.

## Constructor

The constructor should verify that the relevant files exist, and if not, create them. Remember, you will need a file per entity type.

## Get methods

For each List, you should have a method that returns the list.\
If the list is null, you should create a new list, and load all the entities from the file into the list.

I recommend a dedicated function to convert from Pipe Separated Value to the entity type.

Read through the lines of the file, or read them all at once into a list of Strings. The convert to entities.

Return the list.

This method will read a file into a list of Strings, for each line of the file:

```java
private List<String> readAllLines(String filePath)
{
    try
    {
        return Files.readAllLines(Paths.get(filePath));
    }
    catch (IOException e)
    {
        throw new RuntimeException("Failed to read from file: " + filePath, e);
    }
}	
```

A similar approach can be used to write to a file.

## To text (PSV)

You may choose your text format, but adhere to the following requirements:
- It must be text-based, i.e. readable when opening the file. Not binary.
- It must be line-based, i.e. each entity is on a separate line.
- It must be entity-based, i.e. each entity is represented by a string.

I will explain the PSV format. You may pick CSV, JSON, XML, or invent your own format.

I recommend writing a dedicated method for each entity type to convert it to a Pipe Separated Value string. For example:

```java
private String toPSV(Stock stock)
{
    return stock.getSymbol() + "|" + stock.getName() + "|" + stock.getCurrentPrice() + "|" + stock.getCurrentState();
}
```

## From PSV

And similarly, a dedicated method for each entity type to convert it from a Pipe Separated Value string to the entity type. For example:

```java
private Stock fromPSV(String psv)
{
    String[] parts = psv.split("\\|"); // The split method takes a regular expression, which is why we need to escape the pipe character.
    return new Stock(parts[0], parts[1], Double.parseDouble(parts[2]), parts[3]);
}
```

## Begin transaction method

This method should simply set all lists to null, indicating no data has been loaded or modified yet.

## Rollback method

This method should simply set all lists to null. This will essentially undo all changes made to the lists of entities.

## Commit method

For each List, check if it is not null. If it is not null, convert each entity to a Pipe Separated Value string, and write it to the file.

There is a catch here: Multithreading. You will eventually have multiple threads in your system, each thread can use the Unit of Work. To avoid race conditions when writing to the files, you must synchronize the writing to the files.

You will need an Object field variable to use as lock.

```java
private static final Object FILE_WRITE_LOCK = new Object();
```

And you must synchronize on this lock when writing to the files.

```java
@Override
public void commit()
{
    synchronized (FILE_WRITE_LOCK)
    {
        if (stocks != null)
        {
            //... write all stocks to file
        }
        
        //... write all other entities to files
    }


    // Clear the data, to reset the Unit of Work
    clearData();
}
```

## Clear data method

I have multiple methods which needs to clear the data, so I have made a dedicated method for this.

