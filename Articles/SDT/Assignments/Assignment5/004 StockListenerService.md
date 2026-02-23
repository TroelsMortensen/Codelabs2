# The StockListenerService class

This class is considered part of your "business logic", and resides in this layer. The responsibility of this class is to listen to the `StockMarket` for updates, and persist these updates, using the Data Access Objects from a previous assignment.

## Project structure

I recommend a package here: 

```
src/business/stockmarket/services/

📁src/
└── 📁business/
    └── 📁services/
        └── 📄StockListenerService.java
```

It is your first, of several, service classes.

You may create sub-packages inside the `services` package, but for now, it does not seem to matter.

## What is a service class?

Why many business-layer classes end with Service:
* It signals: “this class performs business operations.”
* It separates orchestration logic from data/DTO classes.
* It gives a clear place for use-case methods.

Typical characteristics of a service class:
* Methods are verb/action-oriented (createX, processY, calculateZ).
* Often depends on repositories, data access objects, gateways.
* Usually stateless (no long-lived domain state inside the service itself).
* Enforces business rules at use-case level.

So, naming something a "whatever-Service" just indicates it is responsible for performing business operations.

## StockListenerService class

Now, back to this class...

### Setup

Your class needs a bit of setup:
- Various DAOs, figure out which ones you need.
- The Logger, of course, so you can log what is happening.
- A constructor for dependency injection.

### React to price updates

Now you need a method, which handles the price updates. It has two primary responsibilities:
1) Update the Stock entity with current price and state.
2) OPTIONAL: Create a new StockPriceHistory entity. I believe I have in previous assignments, e.g. about DAOs, told you the DAO for this entity, and the Transaction entity, were optional. I better stick to that.

So, the method needs to do a few things, for each stock that has been updated:
1) Begin a new Unit of Work transaction.
2) Verify that the stock exists in the database. Maybe it is fair to assume, but it is still good to check. You will also need to update the entity.
3) Update the Stock entity with current price and state.
4) Hand over the Stock to the DAO again for update.
5) OPTIONAL BELOW:
6) Create a new StockPriceHistory entity.
7) Add it to the DAO.
8) Commit the changes with the Unit of Work.

### Listen to the StockMarket

You need to make the `StockListenerService` a listener. If you are using a Listener interface, apply it. If not, there is probably not anything to do in this step.

Attaching the class to the StockMarket is better done elsewhere, later in the project.


## Interface...?

It is fairly common to let all service classes implement an interface. This interface is then what the Presentation layer depends on, instead of the concrete service classes. It let's you hide the internal implementation details of the service classes, from the Presentation layer.

On the other hand, we are probably not really going to benefit from this interface, in our project. We are not going to swap out the service classes, with different implementations. Nor are we going to benefit when unit testing, as we are not going to mock the service classes. We will get back to this later in the course.

As a result, I will let you decide if you want to define an interface for your service classes in general.

## Testing

I recommend you test this, from a main method. 

Setup the stock market with some stocks.

Create the DAOs for the Stock and StockPriceHistory entities.

Create the StockListenerService.

Add it to the StockMarket as a listener.

Run the market update thread.

Verify data ends up in the files.