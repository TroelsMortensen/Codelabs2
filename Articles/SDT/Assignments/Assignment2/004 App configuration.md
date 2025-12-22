# Application configuration

Your application will require various settings, which may be used from different parts of the application. We will use the Singleton pattern to implement this.

Settings could be:
- The starting balance when starting a new game
- The transaction fee when buying or selling stocks
- How often the stock market is updated
- The value of a stock after it has been reset

We will keep all these settings in a single class, called `AppConfig`.

## Package

Inside the "shared" package, create a new package called "configuration".

## Design

The `AppConfig` class should be a singleton. Unlike the `Logger` class, data is probably not updated, so there is no need for thread-safety.

## Implementation

Implement the `AppConfig` class as a singleton.


### Fields
Include the following field variables:

```java
    private final int startingBalance;
    private final double transactionFee;
    private final int updateFrequencyInMs;
    private final double stockResetValue;
```

More may come later.

### Methods

Create get-methods for all the field variables.