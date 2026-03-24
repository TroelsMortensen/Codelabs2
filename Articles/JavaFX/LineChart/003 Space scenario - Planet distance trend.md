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

A minimal telemetry domain record can look like this:

```java
public record Telemetry(
    String missionName,
    int daySinceMissionLaunch,
    double distanceFromStarAU
) {}
```

## Series creation

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

You may want to look up how the Map class works. It's simple enough.

## Domain mapping

For simplicity, here is first an example of adding hardcoded data to the series:

```java
alphaSeries.getData().add(new XYChart.Data<>(1, 0.30));
alphaSeries.getData().add(new XYChart.Data<>(2, 0.37));
alphaSeries.getData().add(new XYChart.Data<>(3, 0.45));
```

But actually, each `Telemetry` object becomes one point in the correct mission series. So we can loop through the telemetry data and add the points to the correct series:

```java
for (Telemetry t : alphaTelemetry) {
    alphaSeries.getData().add(new XYChart.Data<>(
        t.daySinceMissionLaunch(),
        t.distanceFromStarAU()
    ));
}
```

Then add both series to the chart:

```java
lineChart.getData().add(alphaSeries);
lineChart.getData().add(betaSeries);
```

This makes it easy to compare discovery profiles between expeditions.


## Visual sketch (ASCII)

Here is a poorly made ascii sketch of the chart:

```text
distanceFromStarAU
0.50 |                                   A3
0.45 |                              A2__/  \___A4
0.40 |                         A1___/
0.35 |
0.30 |                         B3
0.25 |                    B2__/
0.20 |               B1___/
     +-----------------------------------------------
       day1              day2              day3
              (days since mission launch)

A1 = Mission Alpha, day 1, 0.30 AU
A2 = Mission Alpha, day 2, 0.37 AU
A3 = Mission Alpha, day 3, 0.45 AU
B1 = Mission Beta,  day 1, 0.22 AU
B2 = Mission Beta,  day 2, 0.28 AU
B3 = Mission Beta,  day 3, 0.31 AU
```
