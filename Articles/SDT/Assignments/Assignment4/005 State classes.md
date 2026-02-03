# State classes

As mentioned, you need at least four state classes:
- Steady
- Growing
- Declining
- Bankrupt

You may consider more states:
- Reset: I use this to just reset the price of a stock, and then go to the default initial state.
- Rapid growth: Grows fast, maybe for a fixed number of ticks, or higher chance of transitioning.
- Rapid decline
- Rapid crash: Just cras
- Wild fluctuations
- ... whatever else you can come up with.

Create these classes in the same package as the LiveStock class.

I will provide some example code below, you can use it as a starting point.

## Steady state class

Create a class called `SteadyState`.

### Fields

I have a static final field to hold a `Random` object. This class is used to generate random numbers.

Like this:

```java
private static final Random random = new Random();
```

### calculatePriceChange method

You use the `Random` object to generate a random change in price. Then you return this change.

You may find two relevant methods:
- `nextInt(int bound)`: returns a random integer between 0 and `bound` (exclusive).
- `nextDouble()`: returns a random double between 0.0 and 1.0.

Using these, you can generate a random change in price.

**Examples:**

```java
int change = random.nextInt(10) - 5; // between -5 and 5
```

or 

```java
double change = random.nextDouble() - 0.5; // between -0.5 and 0.5
```

or if you want a percentage change:

```java
double changePercent = (random.nextDouble() * 2 - 1) / 100; // -0.01 to +0.01
```

### Transitioning

After the price change is calculated, but before it is returned to the LiveStock class, you should check for a transition. 

I suggest that transitions happen randomly, with a certain probability. You can also just do a fixed number of ticks before a transition happens, like 10 updates. But maybe this becomes too predictable. Or find a third way. Up to you.

For example:

```java
double rand = random.nextDouble();
        
// 5% chance to transition to Growing
if (rand < 0.05) {
    liveStock.setState(new GrowingState());
} 
// 5% chance to transition to Declining (total 10%)
else if (rand < 0.10) {
    liveStock.setState(new DecliningState());
}
// more transitions..?
// Otherwise stay Steady (90%)
```	

### Constructor

The constructor should take the `liveStock` as a parameter.

## Other state classes

Their implementation will be pretty similar. But the random change in price will be a bit skewed.

For example, if the stock is growing, it should be more likely to go up than down. And if the stock is declining, it should be more likely to go down than up. Just shift the probabilities a bit.

You can use the same methods as in the `SteadyState` class to generate the random change in price. But you may need to adjust the probabilities.

## Bankrupt state class

The `BankruptState` class is simple. It just sets the price to 0, and stays there. After a while, random or fixed number of ticks, it should transition to another state. Either pick a Reset, or a default state. Reset the price of the Stock to the value from the AppConfig singleton. Now the Stock is back in the game again.

## Reset state class

I have this state, which on first tick just sets the price to the value from the AppConfig singleton. Then it transitions to the default state, for me that is the Steady state.

This means this state is only used for one tick. Maybe it is overkill. I just though resetting/reviving a Stock is different from a Stock being brankrupt. But up to you.