# Dynamic updates and threading

Real applications often receive data on background threads (network events, sensors, polling, listeners).

JavaFX UI objects must only be changed on the JavaFX Application Thread.

## Use `Platform.runLater(...)`

When a background callback receives new telemetry, push chart updates to the UI thread:

```java
@Override
public void propertyChange(PropertyChangeEvent evt) {
    TelemetryEvent event = (TelemetryEvent) evt.getNewValue();

    Platform.runLater(() -> {
        updateChartData(event);
    });
}
```

## Incremental update pattern

```java
private int tickCounter = 0;

private void updateChartData(TelemetryEvent event) {
    XYChart.Series<Number, Number> series = getSeriesForMission(event.missionName());

    series.getData().add(new XYChart.Data<>(
        tickCounter,
        event.distanceFromStarAU()
    ));

    // Keep chart responsive by limiting history size
    if (series.getData().size() > 100) {
        series.getData().remove(0);
    }

    tickCounter++;
}
```

## Good practices

- Update chart data in small increments, not full rebuilds each tick.
- Limit data points per series for long-running sessions.
- Prefer `setAnimated(false)` for real-time updates.
- Keep parsing/validation outside UI callbacks when possible.
