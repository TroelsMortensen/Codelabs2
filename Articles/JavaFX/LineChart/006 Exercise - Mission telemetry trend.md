# Exercise - Mission telemetry trend

Build a JavaFX line chart that visualizes mission telemetry in the space exploration domain.

The chart should show how measured distance changes over updates.

## UI

Your view should contain:

- a `LineChart<Number, Number>`
- `NumberAxis` for x and y
- a status `Label`

Suggested labels:

- X-axis: `Update tick`
- Y-axis: `Distance from star (AU)`
- Chart title: `Mission Telemetry`

## Logic

Implement the feature with MVVM responsibilities:

- ViewModel stores and updates one or more `XYChart.Series<Number, Number>`
- Controller configures chart options and attaches ViewModel series
- Controller binds status label text to a ViewModel property

Use dynamic updates:

- append a point on each telemetry event
- use `Platform.runLater(...)` for UI updates
- cap series size to avoid unlimited growth

## Extra

If you want more challenge:

- support one series per mission name
- add a checkbox to pause/resume updates
- add a button to clear chart history

---

<hint title="Solution">

Example ViewModel skeleton:

```java
public class MissionTelemetryViewModel {
    private final Map<String, XYChart.Series<Number, Number>> seriesMap = new HashMap<>();
    private final StringProperty status = new SimpleStringProperty("Waiting for telemetry...");
    private int tickCounter;

    public Map<String, XYChart.Series<Number, Number>> getAllSeries() {
        return seriesMap;
    }

    public StringProperty statusProperty() {
        return status;
    }

    public void onTelemetry(TelemetryEvent event) {
        Platform.runLater(() -> {
            XYChart.Series<Number, Number> s = seriesMap.computeIfAbsent(event.missionName(), key -> {
                XYChart.Series<Number, Number> created = new XYChart.Series<>();
                created.setName(key);
                return created;
            });

            s.getData().add(new XYChart.Data<>(tickCounter, event.distanceFromStarAU()));
            if (s.getData().size() > 100) {
                s.getData().remove(0);
            }
            tickCounter++;
            status.set("Last update from " + event.missionName());
        });
    }
}
```

Example Controller skeleton:

```java
public class MissionTelemetryController {
    private final MissionTelemetryViewModel viewModel;

    @FXML private LineChart<Number, Number> lineChart;
    @FXML private NumberAxis xAxis;
    @FXML private NumberAxis yAxis;
    @FXML private Label statusLabel;

    @FXML
    private void initialize() {
        xAxis.setLabel("Update tick");
        yAxis.setLabel("Distance from star (AU)");
        lineChart.setCreateSymbols(false);
        lineChart.setAnimated(false);

        for (XYChart.Series<Number, Number> series : viewModel.getAllSeries().values()) {
            if (!lineChart.getData().contains(series)) {
                lineChart.getData().add(series);
            }
        }

        statusLabel.textProperty().bind(viewModel.statusProperty());
    }
}
```

</hint>
