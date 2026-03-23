# Space scenario - Mission telemetry trend

In the space exploration example, the application collects telemetry information so we can analyze it later.

A LineChart scenario is live telemetry: each mission reports how its distance from the star changes over time.

In this learning path, we use exactly two missions:

- `Mission Alpha`
- `Mission Beta`

The point is, each mission travels around a star system to explore and collect data. We track the distance of the mission from the star over time.

## Why this fits a line chart

- X-axis: days since mission launch (1, 2, 3, ...) 
- Y-axis: `distanceFromStarAU`
- Trend meaning: how quickly each mission moves farther from the star, and whether one mission diverges from the other

## Event shape

A minimal telemetry event can look like this:

```java
XYChart.Series<Number, Number> alphaSeries = new XYChart.Series<>();
alphaSeries.setName("Mission Alpha");

XYChart.Series<Number, Number> betaSeries = new XYChart.Series<>();
betaSeries.setName("Mission Beta");
```

In the above example, I have hardcoded the series names. In a real application, you should probably use a `Map` to store the series, it will be simpler:

```java
private final Map<String, XYChart.Series<Number, Number>> seriesMap = new HashMap<>();
```

## Domain mapping

Each telemetry measurement becomes one point in the correct hardcoded series:

```java
alphaSeries.getData().add(new XYChart.Data<>(1, 0.30)); // day 1
alphaSeries.getData().add(new XYChart.Data<>(2, 0.37)); // day 2
alphaSeries.getData().add(new XYChart.Data<>(3, 0.45)); // day 3

betaSeries.getData().add(new XYChart.Data<>(1, 0.22));  // day 1
betaSeries.getData().add(new XYChart.Data<>(2, 0.28));  // day 2
betaSeries.getData().add(new XYChart.Data<>(3, 0.31));  // day 3
```

Then add both series to the chart:

```java
lineChart.getData().add(alphaSeries);
lineChart.getData().add(betaSeries);
```

This makes it easy to compare discovery profiles between expeditions.
