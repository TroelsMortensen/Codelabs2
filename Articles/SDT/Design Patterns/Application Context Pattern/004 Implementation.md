# Implementation

This page shows a simple, hand-written Java implementation of an Application Context.

The goal is to keep the pattern easy to follow:

- one singleton context object,
- explicit fields for DAOs, services, and ViewModels,
- public getters for the ViewModels needed by controllers.

## 1) DAO example class

```java
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

## 2) Service example class

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
```

## 3) ViewModel example class

```java
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

## 4) AppContext Singleton

In the below example, the various "services" are created on demand. That means each ViewModel gets new instances.

In some cases, a service might be shared, in which case you would store it as a private field, for reuse.

```java
public class AppContext {

    // fields if needed. Maybe some singleton stuff

    public static AppContext getInstance() {
        if (instance == null) {
            instance = new AppContext();
        }
        return instance;
    }

    public PlanetViewModel getPlanetViewModel() {
        return new PlanetViewModel(createPlanetService());
    }

    private PlanetService createPlanetService() {
        return new PlanetService(createPlanetDao());
    }

    private PlanetDao createPlanetDao() {
        return new FilePlanetDao("data/planets.bin");
    }
}
```

## 5) Why This Version Is Useful for Beginners

- No generics and no dynamic registration map.
- All wiring is explicit and easy to trace.
- The object graph is still centralized in one place.

## 6) Variation Note

Most applications use a more dynamic context where types are registered and resolved through a container API. Frameworks often provide this style. The core idea is still the same: one place controls object creation and dependency wiring.

But instead of writing explicit create methods, the creation of services is done through generics and reflection. This is more complex, but it is more flexible.