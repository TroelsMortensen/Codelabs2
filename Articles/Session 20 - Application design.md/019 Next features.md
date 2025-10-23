# Next features

I won't cover more features. 

You are still missing a few, related to the planet management menu:

- Updating a planet
- Deleting a planet

You should be able to follow the same _pattern_ as the previous features.

Then you can start on the features related to the other entities.

I recommend doing: Explorer, then Alien, then Encounter. Not necessarily _all_ features for each entity, some are perhaps less interesting. 

I suspect your application structure will then look something like this:

```
src/
├── domain/
│   ├── Alien.java
│   ├── Encounter.java
│   ├── Explorer.java
│   └── Planet.java
├── persistence/
│   ├── DataContainer.java
│   ├── DataManager.java
│   └── FileDataManager.java
├── presentation/
│   ├── MainMenu.java
│   ├── RunApplication.java
│   ├── alienmanagement/
│   │   ├── AddAlien.java
│   │   ├── AlienMenu.java
│   │   ├── DeleteAlien.java
│   │   ├── ListAliens.java
│   │   ├── ShowAlien.java
│   │   └── UpdateAlien.java
│   ├── encountermanagement/
│   │   ├── AddEncounter.java
│   │   ├── EncounterMenu.java
│   │   ├── DeleteEncounter.java
│   │   ├── ListEncounters.java
│   │   ├── ShowEncounter.java
│   │   └── UpdateEncounter.java
│   ├── explorermanagement/
│   │   ├── AddExplorer.java
│   │   ├── ExplorerMenu.java
│   │   ├── DeleteExplorer.java
│   │   ├── ListExplorers.java
│   │   ├── MoveExplorer.java
│   │   ├── ShowExplorer.java
│   │   └── UpdateExplorer.java
│   └── planetmanagement/
│       ├── AddPlanet.java
│       ├── DeletePlanet.java
│       ├── ListPlanets.java
│       ├── PlanetMenu.java
│       ├── ShowPlanet.java
│       └── UpdatePlanet.java
└── test/
    ├── TestDeletePlanet.java
    ├── TestGetAllPlanets.java
    ├── TestSaveAndLoadPlanet.java
    └── TestUpdatePlanet.java
```

## Class Diagram

I have a class diagram below, though, without any methods or fields.

![cd](Resources/ClassDiagram.svg)