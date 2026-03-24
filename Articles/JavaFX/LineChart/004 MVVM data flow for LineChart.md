# MVVM data flow for LineChart

For maintainable JavaFX applications, keep chart data in the ViewModel and keep the controller focused on UI wiring and data presentation.

This follows the MVVM division of responsibility split:

- ViewModel owns series data and updates it
- Controller configures the chart and displays ViewModel data

Through data binding, or in this case a slight variation of it, the ViewModel can update its data, and the View will automatically update to show the new data.

## Responsibilities

We focus on the responsibilities of the ViewModel and the View (i.e. Controller in JavaFX).

### ViewModel

- transforms data from lower layers (model, services) into `XYChart.Series<Number, Number>`
- exposes series through getters/properties
- updates status text and other UI-facing properties

Example ViewModel pattern below. Again, it is probably better to use a `Map` to store the series, it will be simpler. For example:

```java
private final Map<String, XYChart.Series<Number, Number>> seriesMap = new HashMap<>();
```

Here is the ViewModel:

```java
public class MissionTelemetryViewModel {
    private final XYChart.Series<Number, Number> alphaSeries = new XYChart.Series<>();
    private final XYChart.Series<Number, Number> betaSeries = new XYChart.Series<>();

    private final StringProperty statusMessage = new SimpleStringProperty("Waiting for telemetry...");

    public MissionTelemetryViewModel() {
        alphaSeries.setName("Mission Alpha");
        betaSeries.setName("Mission Beta");
    }

    public XYChart.Series<Number, Number> getAlphaSeries() {
        return alphaSeries;
    }

    public XYChart.Series<Number, Number> getBetaSeries() {
        return betaSeries;
    }

    public StringProperty statusMessageProperty() {
        return statusMessage;
    }


    // Who sets this?
    // Well, probably this ViewModel is a listener for telemetry events from the model/service layer.
    // I just don't show that here for simplicity.
    // In this case we get an entirely new list of telemetry data from the model/service layer.
    // So, the list is entirely cleared, and then the new list is added.
    // This is probably not always the best approach. See alternative below.
    public void setTelemetry(List<Telemetry> alpha, List<Telemetry> beta) {
        alphaSeries.getData().clear();
        for (Telemetry t : alpha) {
            alphaSeries.getData().add(
                new XYChart.Data<>(t.daySinceMissionLaunch(), t.distanceFromStarAU())
            );
        }

        betaSeries.getData().clear();
        for (Telemetry t : beta) {
            betaSeries.getData().add(
                new XYChart.Data<>(t.daySinceMissionLaunch(), t.distanceFromStarAU())
            );
        }
    }

    // This method receives a single new data point, and updates the existing series.
    // This is perhaps better, when data is received incrementally, and not in bulk.
    public void addAlphaTelemetry(Telemetry telemetry) {
        XYChart.Data<Number, Number> dataPoint = new XYChart.Data<>(telemetry.daySinceMissionLaunch(), telemetry.distanceFromStarAU());
        alphaSeries.getData().add(
            dataPoint)
        );
    }
}
```

What happens, if the number of data points is too large? We may need to limit the number of data points. We can do this by removing the oldest data point when the number of data points is too large.

Here is how to remove the oldest entry in a `XYChart.Series<Number, Number>`:

```java
if (series.getData().size() > MAX_DATA_POINTS) {
    series.getData().remove(0);
}
```

### Controller

- adds ViewModel-provided series to the `LineChart`
- configures the chart and its axes
- binds labels to ViewModel properties
- does not perform domain-to-chart mapping

Example controller pattern:

```java
public class MissionTelemetryController {
    private final MissionTelemetryViewModel viewModel;

    @FXML private LineChart<Number, Number> distanceChart;
    @FXML private NumberAxis xAxis;
    @FXML private NumberAxis yAxis;
    @FXML private Label statusMessageLabel;

    public MissionTelemetryController(MissionTelemetryViewModel viewModel) {
        this.viewModel = viewModel;
    }

    // This method is called automatically by JavaFX, when the controller is created.
    // Alternatively, you can implement the `Initializable` interface and implement the `initialize()` method with the required parameters.
    // But, this is the simpler approach for now.
    @FXML
    private void initialize() {
        
        // setup chart axes titles
        xAxis.setLabel("Days since mission launch");
        yAxis.setLabel("Distance from star (AU)");

        // setup chart title
        distanceChart.setTitle("Mission Telemetry");
        distanceChart.setCreateSymbols(false); // setup chart to not show symbols at data points
        distanceChart.setAnimated(false); // Do not animate updates

        // add ViewModel-provided series to the chart
        distanceChart.getData().add(viewModel.getAlphaSeries());
        distanceChart.getData().add(viewModel.getBetaSeries());

        statusMessageLabel.textProperty().bind(viewModel.statusMessageProperty());
    }
}
```

## Rule of thumb

If code answers "what data should be shown", it belongs in the ViewModel.  
If code answers "how should this control look and bind", it belongs in the Controller.
