# The StockBankruptService class

This is a service class, it belongs to the business logic layer. It is responsible for reacting to the bankrupt state of a stock. You could roll the functionality into the StockListenerService, if you like. That's also okay.

Sometimes, a Stock can go bankrupt. This means it cannot be purchased anymore. For a while. Then it will reset and be available for purchase again.

But a seoncd side effect is, that the player should loose all shares of that stock. So, this service class should be responsible for handling this case this.

## StockMarket notification

You might want to add another event to the StockMarket, to notify the system that a stock has gone bankrupt.

## StockListenerService reaction

The class has a method to handle reacting to the bankrupt state of a stock. It should:

1) The update of the Stock data is already handled by the StockListenerService. So, you don't need to do that here.
2) Load the OwnedStock entity for this bankrupt Stock (if it exists)
3) If the OwnedStock entity exists, delete it. Thereby, the player looses all shares of that stock.
4) You may need to also update the Portfolio entity
5) Commit the changes with the Unit of Work.

