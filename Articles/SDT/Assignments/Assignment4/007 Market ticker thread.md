# Market ticker thread

This class is responsible for making the stock market update in real-time.

## Initialization

It should get a reference to the StockMarket singleton.  
The `AppConfig` singleton should contain the update frequency in milliseconds.  
You may also need a reference to a `Logger`, to print out information about the market ticker, so you can see what is happening.

## Running the updates

The class should have a while(true) loop, and inside it, it should call the `StockMarket.updateAllStocks()` method.

Then the loop should sleep for the update frequency, i.e. pause this thread for the update frequency:

```java
Thread.sleep(updateFrequency);
```

This must be run in a separate thread, one way or another, started from the main method.

## The flow

1. Background thread triggers market tick every second
2. StockMarket calls updatePrice() on all LiveStock objects
3. Each LiveStock delegates to its current state to calculate price change
4. LiveStock applies the change to its current price
5. State may transition to a new state
6. LiveStock checks for bankruptcy (price <= 0)
7. StockMarket logs the price change and new price to console
8. (later session: StockMarket tells the application that the stock has been updated)