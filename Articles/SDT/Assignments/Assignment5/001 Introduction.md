# Introduction to Assignment 5

In this assignment, you will apply the Observer design pattern, in your project:

1) The StockMarket must notify the system that a stock has been updated.
2) The business logic layer must notify the UI that a stock has been updated.

## Class structure

We will cover four major features:

1) Update the persisted Stock data with the current price and state.
2) Notify the UI that a stock has been updated.
3) Update the OwnedStock when a Stock goes bankrupt.
4) Notifying the Presentation layer about critical events. (This one is optional.)

In this assignment learning path, I will suggest a design using three classes:
- StockListenerService: persists updated stock data, and notifies the Presentation layer about updated stock prices (maybe the second part could be moved to the StockAlertService..?).
- StockAlertService: notifies the Presentation layer about critical events.
- StockBankruptService: updates the OwnedStock when a Stock goes bankrupt.

**However**, you are free to design your own classes, and you are free to use more or less classes.  
It is allowed to change your classes, and how you distribute the functionality, and responsibilities, over the classes.


## Assignment 5 deliverables

- Conversion of the StockMarket to use the Observer pattern.
- Implementation of the StockListenerService
- Conversion of the StockListenerService to use the Observer pattern.
Optional:
- Implementation of StockAlertService

## Deadline

See itslearning.

## Handing in

If you hand in on time, you I plan on providing feedback.