# Use case: Buy shares of a stock

You need a method to handle the use case of buying a stock. It belongs to a Service class in the business logic layer.

## Input

Consider the minimum input required to buy a number of shares of a particular stock.  
Either provide multiple parameters, or a single parameter of a `BuyStockRequest` object (maybe a DTO/record?).

## Result

The result is either:
* a new `OwnedStock` entity, connected to the purchased stock with a number of shares. I believe your `OwnedStock` entity has a field `quantity` for this,
* or, if the player already owns shares of this particular stock, then the `quantity` of that `OwnedStock` is updated accordingly.	


## The Logic

There are many things to remember, much to validate. I will break it down, to some extent, though you may have to think this through yourself, to ensure all scenarios are covered.

### Transactions

The logic should of course be encapsulated in a transaction. You have the tools to handle this.

### Exceptions

Exceptions may occur, I recommend also wrapping the logic in a try-catch block, to handle these exceptions. Here you can also rool back the current transaction, if an exception occurs.

### Flow

Remember:

> Trust No One

You don't know where the input comes from (in theory). So, you have to validate everything. Here are things to consider:

* Is the selected number of shares to purchase a valid number? What is the upper and lower limit?
* Does the requested stock actually exist?
* Is the stock bankrupt?
* How to handle transaction fee?
* What is the total cost?
* And can the player actually afford to buy the requested number of shares, at the stock's current price?l
* Does the player already own shares of this stock? 
  * If so, how to handle this? If no, how to handle that?
* Do you have more than one portfolio? This will affect the logic about which portfolio to use for the transaction, and does a specific player own shares, or is it another player's portfolio?
* Update number of shares owned
* Update the portfolio balance
* Adding a new Transaction entity to the storage
* Logging relevant information