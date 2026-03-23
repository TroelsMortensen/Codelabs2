# Space scenario - Planet distance trend

In Session 20, the application tracks exploration data so we can analyze it later.

A good line chart case is to visualize how far discovered planets are from their star over discovery order.

## Why this fits a line chart

- X-axis: discovery order (1, 2, 3, ...)
- Y-axis: `distanceFromStarAU` from the `Planet` entity
- Trend meaning: whether later missions discover planets that are generally closer or farther away

## Domain mapping

Given domain objects:

```java
public class Planet {
    private int id;
    private String name;
    private double distanceFromStarAU;
    // ...
}
```

you can map to chart points like this:

```java
int order = 1;
for (Planet planet : discoveredPlanets) {
    series.getData().add(
        new XYChart.Data<>(order, planet.getDistanceFromStarAU())
    );
    order++;
}
```

## Optional extension

If you group discoveries by mission, you can use one series per mission:

- `Mission Alpha`
- `Mission Beta`
- `Mission Gamma`

This makes it easy to compare discovery profiles between expeditions.
