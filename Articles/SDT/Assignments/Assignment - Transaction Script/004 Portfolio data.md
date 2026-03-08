# Portfolio data

You will probably end up with a view to show various data relevant to the player's portfolio. Examples are mentioned on this page.  
However, you will have a fair amount of freedom when you design your UI, and the different views, so the examples below may or may not really fit, what you need.

These will be query methods, in a Service class.

## Pick you strategy

In class I presented two ways of constructing data for the views:
* DAO-Level Data Assembly
* Service-Level Data Assembly

Pick one.  
You should probably be consistent with your choice.

## Ideas for queries

* Seeing available stocks to buy
* Seeing which stocks the player owns (and number of shares)
* The player's current balance
* The player's total portfolio value (i.e. balance, and value of all owned stock shares)

And some perhaps slightly less relevant queries:

* The player's transaction history
* The player's portfolio history, i.e. how their balance has changed over time
* The player's total profit/loss from all transactions, net profit/loss

