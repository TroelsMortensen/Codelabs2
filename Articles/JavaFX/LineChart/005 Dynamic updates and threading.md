# Dynamic updates and threading

Real applications often receive data on background threads (network events, sensors, polling, listeners).

> JavaFX UI objects _must only be changed on the JavaFX Application Thread_!!!

## Use `Platform.runLater(...)`

When the ViewModel receives data from some other thread than the JavaFX thread, like telemetry for `Mission Alpha` or `Mission Beta`, we have to wrap that update in the `runLater()` method.

The JavaFX Application Thread is the thread that runs the JavaFX application. It is the thread that is responsible for updating the UI.

When this thread has time, it will run the code in the `runLater()` method. This is a way to ensure that the UI is updated on the correct thread.

## ViewModel as a Listener

Assume your ViewModel is a listener for telemetry events from the model/service layer. It implements the `PropertyChangeListener` interface.

```java
@Override
public void propertyChange(PropertyChangeEvent evt) {
    TelemetryEvent event = (TelemetryEvent) evt.getNewValue();

    Platform.runLater(() -> {
        updateChartData(event);
    });
}
```

The event is received, and pass to another private method, `updateChartData()`. This method is responsible for updating the chart data. That method call is wrapped in the `runLater()` method, meaning it will be executed on the JavaFX Application Thread, when that thread has time. Usually, it's pretty soon, your UI is not doing that much.

## Why is the propertyChange method called by another thread?

You may have a dedicated thread to regularly generate new data, e.g. Telemetry points, to simulate getting data from the outside world. Here, we simulate a sensor.

- That thread will tell some "fake" telemetry sensor to generate new data. 
- The "sensor" will generate a new `TelemetryEvent` object, and notify listeners.
- The listener, ViewModel, will receive the event, and update the chart data.
- This happens by the `propertyChange` method being called.

Therefore, the chain of method calls, that results in the `propertyChange` method being called, originates from another thread than the JavaFX Application Thread.

## Incremental update pattern

```java
private void updateChartData(TelemetryEvent event) {
    XYChart.Series<Number, Number> series = getSeriesForMission(event.missionName());

    series.getData().add(new XYChart.Data<>(
        event.daySinceMissionLaunch(),
        event.distanceFromStarAU()
    ));

    // Keep chart responsive by limiting history size
    if (series.getData().size() > 100) {
        series.getData().remove(0);
    }

}
```

The same method handles both missions. `event.missionName()` decides whether the point is appended to the `Mission Alpha` line or the `Mission Beta` line. Or, again, use a `Map`.

## Good practices

- Update chart data in small increments, not full rebuilds for each telemetry day.
- Limit data points per series for long-running sessions.
- Prefer `setAnimated(false)` for real-time updates.
- Keep parsing/validation outside UI callbacks when possible.
