# Applying the Pattern

We now apply the Observer pattern to the problem from the second file: a weather sensor that multiple components—current conditions display, forecast panel, history log, frost alert—must react to when the readings change.

## Before: The Poor Solution

Previously, the source class held direct references to each concrete display and called them explicitly:

```java
public void setReading(double temperature, double humidity) {
    this.temperature = temperature;
    this.humidity = humidity;
    currentConditions.update(temperature, humidity);
    forecastPanel.update(temperature, humidity);
    historyLog.update(temperature, humidity);
    frostAlert.update(temperature, humidity);
}
```

The source was tightly coupled to `CurrentConditionsDisplay`, `ForecastPanel`, `HistoryLog`, and `FrostAlert`. Adding or removing a listener required changing this class.

## After: Subject and Listeners

The source becomes a **ConcreteSubject** that extends the abstract **Subject**. The displays become **ConcreteListener**s that implement **Listener**. The source no longer knows their concrete types; it only calls `notifyListeners()`.

### ConcreteSubject: WeatherSensor

```java
public class WeatherSensor extends Subject {
    private double temperature;
    private double humidity;

    public double getTemperature() {
        return temperature;
    }

    public double getHumidity() {
        return humidity;
    }

    public void setReading(double temperature, double humidity) {
        this.temperature = temperature;
        this.humidity = humidity;
        notifyListeners();
    }
}
```

When the readings change, `setReading` calls `notifyListeners()`. Every attached listener (current conditions, forecast, history, frost alert, or any future listener) is notified through the Listener interface.

### ConcreteListeners: Current Conditions, Forecast, History, Frost Alert

Each component implements Listener and reacts in `update`:

```java
public class CurrentConditionsDisplay implements Listener {
    @Override
    public void update(Subject source) {
        if (source instanceof WeatherSensor sensor) {
            System.out.println("Current: " + sensor.getTemperature() + " °C, "
                + sensor.getHumidity() + "% humidity");
        }
    }
}

public class ForecastPanel implements Listener {
    @Override
    public void update(Subject source) {
        if (source instanceof WeatherSensor sensor) {
            System.out.println("Forecast: temp=" + sensor.getTemperature()
                + ", humidity=" + sensor.getHumidity());
        }
    }
}

public class HistoryLog implements Listener {
    @Override
    public void update(Subject source) {
        if (source instanceof WeatherSensor sensor) {
            System.out.println("History: temp=" + sensor.getTemperature()
                + ", humidity=" + sensor.getHumidity());
        }
    }
}

public class FrostAlert implements Listener {
    private static final double FROST_THRESHOLD = 0.0;

    @Override
    public void update(Subject source) {
        if (source instanceof WeatherSensor sensor) {
            if (sensor.getTemperature() < FROST_THRESHOLD) {
                System.out.println("Frost alert: temperature " + sensor.getTemperature()
                    + " °C is below " + FROST_THRESHOLD + " °C!");
            }
        }
    }
}
```

Each listener receives the Subject and, if it is a `WeatherSensor`, reads the state and reacts. The Subject does not reference these classes—only the Listener interface.

### Wiring and Using

Listeners are attached and detached at runtime. The Subject does not need to be changed when you add or remove listeners.

```java
WeatherSensor sensor = new WeatherSensor();
CurrentConditionsDisplay currentConditions = new CurrentConditionsDisplay();
ForecastPanel forecastPanel = new ForecastPanel();
HistoryLog historyLog = new HistoryLog();
FrostAlert frostAlert = new FrostAlert();

sensor.attach(currentConditions);
sensor.attach(forecastPanel);
sensor.attach(historyLog);
sensor.attach(frostAlert);

sensor.setReading(5.0, 80.0);   // All four are notified
sensor.setReading(-2.0, 90.0);   // All four are notified; FrostAlert shows warning

sensor.detach(historyLog);
sensor.setReading(3.0, 85.0);   // Only current conditions, forecast, and frost alert are notified
```

## Summary

- **Before**: The source depended on concrete display types and called each one explicitly. Adding or removing a listener meant changing the source.
- **After**: The source extends Subject and calls `notifyListeners()`. Displays implement Listener and register with `attach`/`detach`. The source never references concrete listener classes.

The same `WeatherSensor` subject can later be used with other listener types (e.g. a statistics panel, a persistence layer) without changing `WeatherSensor` or the existing listeners. That is the benefit of depending only on the Listener interface.
