# Append method

> This is an optional challenge. You can choose to skip this.

## The problem

Some of your daos will update the data quite often, but not modify any existing data. We could call these read-only. This includes the StockPriceHistoryDao and the TransactionDao.

- You do not modify the history of stock prices. Or, at least, I don't see why you would want to.
- You do not modify the transactions. Again, this is historical data.

In both cases, you will mainly just _add_ new entity instances to the data storage (file).

The price history is updated about once per second. When you have played the game for a minute, you have 60 entries. The amount of data will grow quite quickly.

In the current version, every time you need to add a new entry, the Unit of Work will load the entire file content. This quickly becomes inefficient.

## The solution

For the type of entities which are _append-heavy_, we can implement a shortcut, where the UoW will not load the entire file content, but rather append the new entity to the end of the file.

## Unit of Work

First we must update the UoW for this optimization.


### Buffer Lists

In this class, add a new List for each entity which is append-heavy. You may call this List "&lt;entity&gt;Buffer", e.g. "StockPriceHistoryBuffer". It is initially a new, empty list. Unlike the other Lists, which are null.


### Get buffer method
You add a new method, to return this list: `getStockPriceHistoryAppendOnly()`.	

### Update commit method

In the commit method, where you are writing other data to the files, add a check for the buffer list. If it is not empty, you append the entities in the buffer to the file.

Java has a convenient method to append to a file:

```java
private void appendLinesToFile(String filePath, List<String> list)
{
    try
    {
        Files.write(Path.of(filePath), list, StandardOpenOption.CREATE, StandardOpenOption.APPEND);
    }
    catch (IOException e)
    {
        // ... handle the exception
    }
}
```

### rollback method

To this method just add a line to clear the buffer list. Or assign it to a new, empty list.