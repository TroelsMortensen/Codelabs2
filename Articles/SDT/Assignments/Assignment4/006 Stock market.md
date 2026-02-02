# The Stock Market

This class represents the live stock market, and manages the LiveStock objects and their updates.

It is a singleton, and should be called `StockMarket`.

## Location

I would put this in the "stockmarket" package, in the business logic layer.

## Fields

You will need a `List<LiveStock>` field.

You may also need access to a `Logger`, to print out information about the stock market, so you can see what is happening.

## Add new stock method

You must create a method to add a new LiveStock object to the market. The parameter of the method is just a Stock symbol. Then, create a new LiveStock object, and add it to the list.

## Add existing stock method

You will probably, eventually, also need to add an existing Stock to the market, e.g. when the game is loaded. The parameter of the method is a Stock object. Then, create a new LiveStock object, and add it to the list.

## Update all stocks method

This method should iterate over all the LiveStock objects in the market, and call their `updatePrice()` method.

At the end of the loop, you should log the information about the LiveStock, using the `Logger`, just as a way to test what is happening.

## Singleton

Make the `StockMarket` class a singleton.