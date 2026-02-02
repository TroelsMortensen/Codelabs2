# The LiveStock class

You currently have a Stock entity, in your domain model. This entity can change over time, and players can purchase and sell shares of the stock. This data is persisted to a file.

But we must simulate the change in price of the stock over time. This data lives live in the memory as long as the program is running.

Therefore, we sort of have two sides of the same coin:
- The Stock entity, which is persisted to a file.
- The LiveStock entity, which is stored in memory and updated in real-time.

You already have the former, now you must implement the latter.

## Project structure

The behaviour of the LiveStock is considered business logic. Therefore, it should be in the business logic layer.

I recommend a package here: src/business/stockmarket/simulation/

## LiveStock class

Create a class called `LiveStock`.

### Fields

The class must have three fields:
- The `symbol` of the stock it represents, e.g. "AAPL", or "GOOG", or "MSFT". This must match the symbol of the Stock entity.
- The `currentState`, i.e. a reference to a state object. See next page.
- The `currentPrice`, i.e. the price of the stock at the current time.

### Constructor

You will probably need more than one constructor:
1) One for creating a new LiveStock object the first time.
2) One for creating re-creating a LiveStock when the game is loaded.

**The former (1.)** should simply take the `symbol` as a parameter. `currentState` can be set to a default state of your choice. `currentPrice` should be found in the `AppConfig` singleton.

**The latter (2.)** may be done later, if you need it. It will take the relevant data from the Stock entity, and setup a LiveStock. This means mapping the _name_ of a state, to the actual state object.


### Update price method

Add this method to the LiveStock class, `updatePrice()`.  
This method should call the `currentState`'s `updatePrice()` method, which returns _a change in price_. This change is added to the `currentPrice`.

If the current price drops below 0, the stock is considered bankrupt, and the state should be set to "Bankrupt".  
You _may_ check for bankrupcy in each of the state classes. I found it easier to do it here.

```java
public void updatePrice() {
    double priceChange = currentState.calculatePriceChange(this);
    
    currentPrice += priceChange;
    
    // check for bankruptcy?
}
```

### set state method

You will need a method to set the state of the LiveStock. This is to be called from other states.

Consider access modifier...?

### getters

You will probably need getters for one or more fields.  
Including a method to get the current state _name_, so that this information can be persisted.