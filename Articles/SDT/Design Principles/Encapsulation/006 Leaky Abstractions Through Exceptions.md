# Leaky Abstractions Through Exceptions

When we talk about package-level encapsulation, we usually focus on classes and return types.

But exceptions are also part of the boundary contract.

If technical exceptions from a lower layer escape into upper layers, the abstraction leaks.

## The Problem

In layered architecture, persistence details should stay inside the persistence layer.

If persistence throws technical exceptions like `SQLException` or `IOException`, then upper layers must know those technologies:

- application layer starts importing SQL or file I/O exceptions
- presentation layer may end up handling infrastructure errors directly
- switching persistence technology causes ripple effects in upper layers

That is coupling through exception types.

## Package Tree (Leaking Version)

```console
src/
└── com/example/spaceexplorer/
    ├── presentation/
    │   └── planet/
    │       └── PlanetController.java
    ├── application/
    │   └── planet/
    │       └── PlanetService.java                 // catches IOException (leak)
    └── persistence/
        ├── api/
        │   └── PlanetRepository.java
        └── internal/
            ├── file/
            │   └── FilePlanetRepository.java      // throws IOException
            └── mapper/
                └── PlanetFileMapper.java
```

## Before: Leaky Exception Contract

```java
// package: com.example.spaceexplorer.persistence.api
import java.io.IOException;
import java.util.List;

public interface PlanetRepository {
    List<Planet> findAll() throws IOException;
}
```

```java
// package: com.example.spaceexplorer.persistence.internal.file
import java.io.IOException;
import java.nio.file.Files;
import java.nio.file.Path;
import java.util.List;

public class FilePlanetRepository implements PlanetRepository {
    @Override
    public List<Planet> findAll() throws IOException {
        String raw = Files.readString(Path.of("planets.txt"));
        return parsePlanets(raw);
    }
}
```

```java
// package: com.example.spaceexplorer.application.planet
import java.io.IOException;
import java.util.List;

public class PlanetService {
    private final PlanetRepository repository;

    public PlanetService(PlanetRepository repository) {
        this.repository = repository;
    }

    public List<Planet> getPlanets() {
        try {
            return repository.findAll();
        } catch (IOException e) {
            throw new RuntimeException("Could not load planets", e);
        }
    }
}
```

`PlanetService` now knows file I/O concerns. The persistence detail leaked.

## Diagram: Leakage Flow

```mermaid
graph TD
    appService[application.PlanetService] --> persistenceApi[persistence.api.PlanetRepository]
    persistenceApi --> persistenceInternal[persistence.internal.file.FilePlanetRepository]
    persistenceInternal --> ioEx[java.io.IOException]
    ioEx --> appService
```

## Solution: Translate Exceptions at the Boundary

Catch technical exceptions inside persistence, and translate them to a boundary-level exception that belongs to the persistence API.

## Package Tree (Encapsulated Version)

```console
src/
└── com/example/spaceexplorer/
    ├── presentation/
    │   └── planet/
    │       └── PlanetController.java
    ├── application/
    │   └── planet/
    │       └── PlanetService.java                 // catches PlanetRepositoryException
    └── persistence/
        ├── api/
        │   ├── PlanetRepository.java
        │   └── PlanetRepositoryException.java
        └── internal/
            ├── file/
            │   └── FilePlanetRepository.java      // catches IOException internally
            └── mapper/
                └── PlanetFileMapper.java
```

## After: Boundary Exception Contract

```java
// package: com.example.spaceexplorer.persistence.api
import java.util.List;

public interface PlanetRepository {
    List<Planet> findAll();
}
```

```java
// package: com.example.spaceexplorer.persistence.api
public class PlanetRepositoryException extends RuntimeException {
    public PlanetRepositoryException(String message, Throwable cause) {
        super(message, cause);
    }
}
```

```java
// package: com.example.spaceexplorer.persistence.internal.file
import java.io.IOException;
import java.nio.file.Files;
import java.nio.file.Path;
import java.util.List;

public class FilePlanetRepository implements PlanetRepository {
    @Override
    public List<Planet> findAll() {
        try {
            String raw = Files.readString(Path.of("planets.txt"));
            return parsePlanets(raw);
        } catch (IOException e) {
            throw new PlanetRepositoryException("Failed to read planet file", e);
        }
    }
}
```

```java
// package: com.example.spaceexplorer.application.planet
import java.util.List;

public class PlanetService {
    private final PlanetRepository repository;

    public PlanetService(PlanetRepository repository) {
        this.repository = repository;
    }

    public List<Planet> getPlanets() {
        try {
            return repository.findAll();
        } catch (PlanetRepositoryException e) {
            throw new ApplicationException("Could not load planets right now", e);
        }
    }
}
```

Now the application layer depends on persistence API semantics, not on file technology details.

## Diagram: Translation at Boundary

```mermaid
graph TD
    appService[application.PlanetService] --> persistenceApi[persistence.api.PlanetRepository]
    persistenceApi --> persistenceInternal[persistence.internal.file.FilePlanetRepository]
    persistenceInternal --> catchIo[CatchIOException]
    catchIo --> repoEx[persistence.api.PlanetRepositoryException]
    repoEx --> appService
```

## Practical Solutions

- **Translate at boundary:** convert `SQLException`/`IOException` to package API exceptions before crossing layers.
- **Wrap and keep cause:** keep root cause for debugging (`new PlanetRepositoryException("...", e)`).
- **Expose only boundary exceptions:** upper layers should catch semantic exceptions, not technical infrastructure exceptions.
- **Keep internals internal:** `persistence.internal.*` handles technical concerns; `persistence.api.*` defines what leaves the layer.
- **Alternative style:** for some use cases, return a result/error object instead of throwing.

## Connection to Earlier Encapsulation Topics

Leaking return types and leaking exception types are the same boundary problem:

- return type leakage exposes internal data structures
- exception leakage exposes internal failure mechanisms

In both cases, package encapsulation is broken because internal details become part of the public contract.

