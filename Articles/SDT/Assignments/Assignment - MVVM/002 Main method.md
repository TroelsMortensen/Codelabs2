# Main method

You should start by creating a class to start your JavaFX application.

This is where the system is now started. This class should extend the `Application` class, and override the `start` method. You know how to do this from the previous semester.

Given that this is the class that kickstarts everything, it is often placed in the root package of your project, e.g. the `src/stockgame/` package. Alternatively, put it in the `presentation` package, if you like. 

Your start method is probably going to have to do a lot of work, to get the application started.

* Setup the Application Context
* Initialize the ViewManager
* Show the main/first view
* Initialize stock data, if none is present. You should probably have a handfuld of hardcoded stocks, in case your stocks file is empty
* Initialize the stock market, with data. I.e. load stocks from StockDAO, and add them to the StockMarket singleton
* Portfolio needs to be checked for existence, and created if it doesn't exist.
* Listeners need to be added to subjects.
* Market update thread needs to be started.

Some of the above can live in the start method. Some of it may live in a GameService class (if you have one) handling starting, loading, saving, restarting the game. The design is up to you.