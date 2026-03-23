# Building a basic LineChart

`LineChart` plots points on an x-axis and y-axis, and connects them with lines.

In JavaFX, a line chart is built from:

- two axes (`NumberAxis` for numeric data)
- one or more `XYChart.Series<X, Y>`
- data points (`XYChart.Data<X, Y>`)

## Minimal setup

```java
NumberAxis xAxis = new NumberAxis();
NumberAxis yAxis = new NumberAxis();

xAxis.setLabel("Discovery order");
yAxis.setLabel("Distance from star (AU)");

LineChart<Number, Number> chart = new LineChart<>(xAxis, yAxis);
chart.setTitle("Planet Distance Trend");
chart.setCreateSymbols(false); // cleaner line, fewer markers
chart.setAnimated(false);      // predictable updates
```

## Add a data series

```java
XYChart.Series<Number, Number> series = new XYChart.Series<>();
series.setName("Discovered Planets");

series.getData().add(new XYChart.Data<>(1, 0.72));
series.getData().add(new XYChart.Data<>(2, 1.10));
series.getData().add(new XYChart.Data<>(3, 1.67));

chart.getData().add(series);
```

## Practical notes

- Keep x-values monotonic (1, 2, 3, ...) for time/order trends.
- Use meaningful axis labels. Users should understand units immediately.
- Disable animation for frequently updated charts to avoid jitter.
- Use multiple series only when comparing related trends.
