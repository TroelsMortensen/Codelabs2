# Applying the Pattern

Now we apply the Application Context pattern to a JavaFX MVVM scenario.

From page `2`, the problem was scattered wiring in UI classes.  
From page `3`, the pattern gave us one place to create and connect objects.

## Scenario

- `PlanetController` needs `PlanetViewModel`.
- `PlanetViewModel` needs `PlanetService`.
- `PlanetService` needs `PlanetDao`.

The application context builds this chain.

## Domain and ViewModel Classes

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
    @Override
    public void add(Planet planet) {
        // Save to file (omitted)
    }
}

public class PlanetService {
    private final PlanetDao dao;

    public PlanetService(PlanetDao dao) {
        this.dao = dao;
    }

    public void addPlanet(Planet planet) {
        dao.add(planet);
    }
}

public class PlanetViewModel {
    private final PlanetService service;

    public PlanetViewModel(PlanetService service) {
        this.service = service;
    }

    public void createPlanet(int id, String name) {
        service.addPlanet(new Planet(id, name));
    }
}
```

## Configure the Application Context

```java
public class AppContext {
    private static AppContext instance;

    private final PlanetDao planetDao;
    private final PlanetService planetService;
    private final PlanetViewModel planetViewModel;

    private AppContext() {
        planetDao = new FilePlanetDao();
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

## Controller Gets a Ready ViewModel

```java
public class PlanetController {
    private final PlanetViewModel viewModel;

    public PlanetController() {
        this.viewModel = AppContext.getInstance().getPlanetViewModel();
    }
}
```

The controller no longer knows how services or DAOs are created. It only asks for what it needs.

## Small Testing Benefit

For tests, create another context configuration:

- register a fake or in-memory DAO instead of `FilePlanetDao`,
- keep the same ViewModel and service classes.

This allows testing behavior without touching production wiring.

## Result

The object graph is now assembled in one place, lifecycle rules are explicit, and UI classes stay focused on UI concerns.
