# MVVM data flow for LineChart

For maintainable JavaFX applications, keep chart data in the ViewModel and keep the controller focused on UI wiring.

This follows the same responsibility split as your stock chart example:

- ViewModel owns series data and updates it
- Controller configures the chart and displays ViewModel data

## Responsibilities

### ViewModel

- transforms domain data into `XYChart.Series<Number, Number>`
- exposes series through getters/properties
- updates status text and other UI-facing properties

Example ViewModel pattern:

```java
public class MissionTelemetryViewModel {
    private final Map<String, XYChart.Series<Number, Number>> seriesMap = new HashMap<>();
    private final StringProperty message = new SimpleStringProperty("Waiting for telemetry...");

    public MissionTelemetryViewModel() {
        ensureSeries("Mission Alpha");
        ensureSeries("Mission Beta");
    }

    public Map<String, XYChart.Series<Number, Number>> getAllSeries() {
        return seriesMap;
    }

    public StringProperty messageProperty() {
        return message;
    }

    private XYChart.Series<Number, Number> ensureSeries(String missionName) {
        return seriesMap.computeIfAbsent(missionName, key -> {
            XYChart.Series<Number, Number> created = new XYChart.Series<>();
            created.setName(key);
            return created;
        });
    }
}
```

### Controller

- sets axis labels, chart title, and visual options
- adds ViewModel-provided series to the `LineChart`
- binds labels to ViewModel properties
- does not perform domain-to-chart mapping

Example controller pattern:

```java
public class MissionTelemetryController {
    private final MissionTelemetryViewModel viewModel;

    @FXML private LineChart<Number, Number> distanceChart;
    @FXML private NumberAxis xAxis;
    @FXML private NumberAxis yAxis;
    @FXML private Label messageLabel;

    @FXML
    private void initialize() {
        xAxis.setLabel("Days since mission launch");
        yAxis.setLabel("Distance from star (AU)");
        distanceChart.setTitle("Mission Telemetry");
        distanceChart.setCreateSymbols(false);
        distanceChart.setAnimated(false);

        for (XYChart.Series<Number, Number> series : viewModel.getAllSeries().values()) {
            if (!distanceChart.getData().contains(series)) {
                distanceChart.getData().add(series);
            }
        }

        messageLabel.textProperty().bind(viewModel.messageProperty());
    }
}
```

## Rule of thumb

If code answers "what data should be shown", it belongs in the ViewModel.  
If code answers "how should this control look and bind", it belongs in the Controller.
