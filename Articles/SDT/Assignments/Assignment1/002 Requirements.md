# Project requirements

In this project you will develop a stock trading game. The user can buy and sell stocks, and see their portfolio and transaction history.

The stock market is simulated, and stocks will be updated in real-time. They will grow and decline, and the user can buy and sell them, to increase their fortune.

## Problem domain

In the game, there will be a number of stocks, which are represented by a symbol and a name. The symbol is a unique identifier for the stock, and the name is a human-readable name for the stock. Each Stock also have a current price, which is regularly updated by a background process.\
The user can create a portfolio, which is a collection of stocks they own and their quantities. The user can potentially create multiple portfolios, but this is optional.\
Stock prices are updated in real-time, and the user can buy and sell stocks at the current price. The user can also see the transaction history, and the portfolio history, i.e. how their balance has changed over time.


## Functional Requirements

There are several functional requirements for the game. They are listed below, and will be used to guide the development of the game.

Further explanation of the requirements will be provided in the assignments throughout the course.

The first five are mandatory, and the last three are optional. Each assignment will assume you are doing all 8 of them, so you may need to cut some corners in some assignments.

**Mandatory:**\
F1. User can see the stock price chart, updated in real-time\
F2. User can buy stock\
F3. User can sell stock\
F4. User can see their portfolio\
F5. User can win the game by reaching a certain balance.

**Optional:**\
F6. User can see their transaction history\
F7. User can see the portfolio history, i.e. how their balance has changed over time\
F8. User can create multiple portfolios



## Non-functional Requirements

NF1. Developed in Java.\
NF2. Uses JavaFX for the UI.\
NF3. Persistence is handled by storing data in files.\
NF4. The application is a desktop application, so it will just run locally on your machine.