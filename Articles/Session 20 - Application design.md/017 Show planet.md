# Show planet

This feature is about showing the information for a single planet.

We will follow the same pattern as the previous feature: create a new class, add the method to the class, and update the planet management menu to include it.

## Create class

Start by creating the class in the `presentation` package. Here is your current application structure:

```{8}
src/
├── presentation/
│   ├── MainMenu.java
│   ├── RunApplication.java
│   └── planetmanagement/
│       ├── AddPlanet.java
│       ├── PlanetMenu.java
│       └── ShowPlanet.java
├── persistence/
│   ├── DataContainer.java
│   ├── DataManager.java
│   └── FileDataManager.java
├── domain/
│    ├── Alien.java
│    ├── Encounter.java
│    ├── Explorer.java
│    └── Planet.java
└── test/
    ├── TestSaveAndLoadPlanet.java
    ├── TestDeletePlanet.java
    ├── TestUpdatePlanet.java
    └── TestGetAllPlanets.java
```

## Constructor

Once again, you need a constructor, which will assign the field variable `dataManager` to a new `FileDataManager` object.

## handleShowPlanet() method

Add a method called `handleShowPlanet()`. This method should print the relevant messages to guide the user through inputting the planet ID.\
Once a valid ID is entered, use the `dataManager` field to get the planet from storage. Then, print the planet information. Here is part of the code:

```java
public void handleShowPlanet() {
    System.out.println("\n=== Show Planet ===");
    
    // TODO: Read planet ID from user
    // TODO: Get planet from dataManager
    Planet planet = dataManager.getPlanet(planetId);
    if (planet != null) {
        System.out.println(planet);
    } else {
        System.out.println("Planet not found.");
    }
}
```

Now, potentially, you get an exception in line 9, when getting the planet, so you should add a try-catch block. How will you handle the exception? At least an error should be printed. Will you go back to the planet management menu? Or will you have the user start over?\
I will let you decide.

## Test

You should now run your program, and verify that you can both add and show a planet. While you cannot verify the content of the file with the binary data, if you can add a planet, and then show it, it is fair to trust that the program is working as expected.