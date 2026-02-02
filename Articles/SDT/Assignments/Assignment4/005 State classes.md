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

I suggest that transitions happen randomly, with a certain probability.

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