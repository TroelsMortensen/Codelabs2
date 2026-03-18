# Implementation

This page shows a simple, hand-written Java implementation of an Application Context.

The goal is to keep the pattern easy to follow:

- one singleton context object,
- explicit fields for DAOs, services, and ViewModels,
- public getters for the ViewModels needed by controllers.

## 1) Minimal Domain Types

```java
public class Planet {
    private final int id;
    private final String name;

    public Planet(int id, String name) {
        this.id = id;
        this.name = name;
    }
}

public interface PlanetDao {
    void add(Planet planet);
}

public class FilePlanetDao implements PlanetDao {
    private final String filePath;

    public FilePlanetDao(String filePath) {
        this.filePath = filePath;
    }

    @Override
    public void add(Planet planet) {
        // Save to file (omitted)
    }
}
```

## 2) Service and ViewModel

```java
public class PlanetService {
    private final PlanetDao planetDao;

    public PlanetService(PlanetDao planetDao) {
        this.planetDao = planetDao;
    }

    public void addPlanet(Planet planet) {
        planetDao.add(planet);
    }
}

public class PlanetViewModel {
    private final PlanetService planetService;

    public PlanetViewModel(PlanetService planetService) {
        this.planetService = planetService;
    }

    public void createPlanet(int id, String name) {
        planetService.addPlanet(new Planet(id, name));
    }
}
```

## 3) AppContext Singleton

```java
public class AppContext {
    private static AppContext instance;

    // DAOs (private)
    private final PlanetDao planetDao;

    // Services (private)
    private final PlanetService planetService;

    // ViewModels (public getters)
    private final PlanetViewModel planetViewModel;

    private AppContext() {
        planetDao = new FilePlanetDao("data/planets.bin");
        planetService = new PlanetService(planetDao);
        planetViewModel = new PlanetViewModel(planetService);
    }

    public static AppContext getInstance() {
        if (instance == null) {
            instance = new AppContext();
        }
        return instance;
    }

    public PlanetViewModel getPlanetViewModel() {
        return planetViewModel;
    }
}
```

## 4) Why This Version Is Useful for Beginners

- No generics and no dynamic registration map.
- All wiring is explicit and easy to trace.
- The object graph is still centralized in one place.

## 5) Variation Note

Some applications use a more dynamic context where types are registered and resolved through a container API. Frameworks often provide this style. The core idea is still the same: one place controls object creation and dependency wiring.
