# Introduction to JFX Application

In this learning path, we will combine previous theory with what we have learned about JavaFX, to build an application, which will reflect what you will be doing in your first semester project.

This requires some structure for your application, organizing your code into packages, putting fxml files in the right places, and so on.

The basic concept will be similar to session 20's application design, but we will use JavaFX instead of console.

## Architecture

We again define four areas of responsibility for our application:
- Presentation layer
- Persistence layer
- Domain layer
- Start up

![architecture](Resources/Architecture.png)

Each area has it's own package, and you may have sub-packages within each area.

We will also put the fxml files in a Resources package, to keep them separate from the code. This is common practice. So far we have just thrown everything together in the same package, but that does not scale well.

## Example package structure

Here is an example of the package structure:

```console
🟦SpaceExplorer/
├── 📁src/
│   └── 📁spaceexplorer/
│       ├── 📄RunApplication.java
│       ├── 📁domain/
│       │   ├── 📄Alien.java
│       │   ├── 📄Encounter.java
│       │   ├── 📄Explorer.java
│       │   └── 📄Planet.java
│       ├── 📁persistence/
│       │   ├── 📄DataContainer.java
│       │   ├── 📄DataManager.java
│       │   └── 📄FileDataManager.java
│       └── 📁presentation/
│           ├── 📄ViewManager.java
│           ├── 📄AcceptsStringArgument.java
│           ├── 📁mainmenu/
│           │   └── 📄MainViewController.java
│           └── 📁planetmanagement/
│               ├── 📄AddPlanetController.java
│               ├── 📄ListPlanetsController.java
│               ├── 📄ShowPlanetController.java
│               └── 📄UpdatePlanetController.java
└── 📁resources/
    └── 📁spaceexplorer/
        └── 📁presentation/
            └── 📁views/
                ├── 📄MainView.fxml
                ├── 📄AddPlanet.fxml
                ├── 📄ListPlanets.fxml
                ├── 📄ShowPlanet.fxml
                └── 📄UpdatePlanet.fxml
```