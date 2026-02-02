# Applying the Pattern

We now apply the Observer pattern to the problem from the second file: a data source (e.g. stock price) that multiple components—dashboard, log panel, alert widget—must react to when the value changes.

## Before: The Poor Solution

Previously, the source class held direct references to each concrete display and called them explicitly:

```java
public void setPrice(double newPrice) {
    this.price = newPrice;
    dashboard.update(price);
    logPanel.update(price);
    alertWidget.update(price);
}
```

The source was tightly coupled to `DashboardDisplay`, `LogPanel`, and `AlertWidget`. Adding or removing a listener required changing this class.

## After: Subject and Listeners

The source becomes a **ConcreteSubject** that extends the abstract **Subject**. The displays become **ConcreteListener**s that implement **Listener**. The source no longer knows their concrete types; it only calls `notifyListeners()`.

### ConcreteSubject: StockPrice

```java
public class StockPrice extends Subject {
    private double price;

    public double getPrice() {
        return price;
    }

    public void setPrice(double price) {
        this.price = price;
        notifyListeners();
    }
}
```

When the price changes, `setPrice` calls `notifyListeners()`. Every attached listener (dashboard, log, alert, or any future listener) is notified through the Listener interface.

### ConcreteListeners: Dashboard, Log, Alert

Each component implements Listener and reacts in `update`:

```java
public class DashboardDisplay implements Listener {
    @Override
    public void update(Subject source) {
        if (source instanceof StockPrice stockPrice) {
            System.out.println("Dashboard: price = " + stockPrice.getPrice());
        }
    }
}

public class LogPanel implements Listener {
    @Override
    public void update(Subject source) {
        if (source instanceof StockPrice stockPrice) {
            System.out.println("Log: price changed to " + stockPrice.getPrice());
        }
    }
}

public class AlertWidget implements Listener {
    private static final double THRESHOLD = 100.0;

    @Override
    public void update(Subject source) {
        if (source instanceof StockPrice stockPrice) {
            if (stockPrice.getPrice() > THRESHOLD) {
                System.out.println("Alert: price " + stockPrice.getPrice() + " above threshold!");
            }
        }
    }
}
```

Each listener receives the Subject and, if it is a `StockPrice`, reads the state and reacts. The Subject does not reference these classes—only the Listener interface.

### Wiring and Using

Listeners are attached and detached at runtime. The Subject does not need to be changed when you add or remove listeners.

```java
StockPrice stockPrice = new StockPrice();
DashboardDisplay dashboard = new DashboardDisplay();
LogPanel logPanel = new LogPanel();
AlertWidget alertWidget = new AlertWidget();

stockPrice.attach(dashboard);
stockPrice.attach(logPanel);
stockPrice.attach(alertWidget);

stockPrice.setPrice(50.0);   // All three are notified
stockPrice.setPrice(150.0);  // All three are notified; AlertWidget may show alert

stockPrice.detach(logPanel);
stockPrice.setPrice(75.0);   // Only dashboard and alert widget are notified
```

## Summary

- **Before**: The source depended on concrete display types and called each one explicitly. Adding or removing a listener meant changing the source.
- **After**: The source extends Subject and calls `notifyListeners()`. Displays implement Listener and register with `attach`/`detach`. The source never references concrete listener classes.

The same `StockPrice` subject can later be used with other listener types (e.g. a chart, a persistence layer) without changing `StockPrice` or the existing listeners. That is the benefit of depending only on the Listener interface.
