# Assignment - MVVM

This is a larger one, because it spans more time. You will implement the GUI, with JavaFX, following the MVVM pattern.

Some of the parts below are introduced in the second session about MVVM.

## Deliverables

* You must use the MVVM pattern to implement a JavaFX GUI for the presentation layer
* You must use a ViewManager to handle the navigation between views
* You must have at least two views (not including a main view)
* You must show a line chart of the stock data
* It must be possible to buy a stock
* It must be possible to sell a stock
* It must be possible to see relevant portfolio data
* Your ViewManager must use a ControllerFactory to create the controllers
* Your ControllerFactory must use a ApplicationContext to create the dependencies
* You must use a NotificationService interface with implementation to show notifications to the user
* You should update your class diagram to reflect the new classes, and the changes you have made. You will need this at the exam.

Optional:
* You may build a Single View Application, as introduced on first semester.
* You may decide how your views look
* You may decide how your organize your features
* Maybe you have created a bunch of query methods in a service class, you can expand your features to use these
* You made a stock notification service kind of class. You may want to make your presentation layer observe this service, and update the UI when the service notifies it. If you have a main view, that could listen to events, and show popups when the service notifies it.


## Relevant resources
* [ViewManager](https://troelsmortensen.github.io/Codelabs2/article/TroelsMortensen/Session%2022%20-%20JFX%20Continued?pagenumber=11)
* [ControllerFactory](https://troelsmortensen.github.io/Codelabs2/article/TroelsMortensen/Session%2023%20-%20JFX%20Application?pagenumber=5)
* [MVVM](https://troelsmortensen.github.io/Codelabs2/article/TroelsMortensen/SDT%2FDesign%20Patterns%2FMVVM)
* [How the LineChart works](https://troelsmortensen.github.io/Codelabs2/article/TroelsMortensen/JavaFX%2FLineChart)
* [Maps in Java](https://troelsmortensen.github.io/Codelabs2/article/TroelsMortensen/SDT%2FMaps%20in%20Java)
* [Application Context Pattern](https://troelsmortensen.github.io/Codelabs2/article/TroelsMortensen/SDT%2FDesign%20Patterns%2FApplication%20Context%20Pattern)

## Deadline

See itslearning.