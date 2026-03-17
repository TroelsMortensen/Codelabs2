# Implementation

This page shows a small, hand-written Java implementation of an Application Context.

The goal is not to build a full DI framework. The goal is to clearly show:

- how types are registered,
- how types are resolved,
- and how lifecycle (shared vs new instance) can be controlled.

## 1) A Minimal Context

```java
import java.util.HashMap;
import java.util.Map;
import java.util.function.Function;

public class ApplicationContext {
    private final Map<Class<?>, Function<ApplicationContext, ?>> providers = new HashMap<>();
    private final Map<Class<?>, Object> singletons = new HashMap<>();

    public <T> void registerTransient(Class<T> type, Function<ApplicationContext, T> provider) {
        providers.put(type, provider);
    }

    public <T> void registerSingleton(Class<T> type, Function<ApplicationContext, T> provider) {
        providers.put(type, ctx -> singletons.computeIfAbsent(type, t -> provider.apply(ctx)));
    }

    @SuppressWarnings("unchecked")
    public <T> T get(Class<T> type) {
        Function<ApplicationContext, ?> provider = providers.get(type);
        if (provider == null) {
            throw new IllegalStateException("No provider registered for " + type.getName());
        }
        return (T) provider.apply(this);
    }
}
```

### What happens here?

- `registerTransient(...)` creates a new instance each time `get(...)` is called.
- `registerSingleton(...)` creates once and reuses the same instance.
- `get(...)` can recursively resolve dependencies because providers receive the context.

## 2) Example Types

```java
public class PortfolioDao {}

public class PortfolioService {
    private final PortfolioDao dao;

    public PortfolioService(PortfolioDao dao) {
        this.dao = dao;
    }
}

public class PortfolioViewModel {
    private final PortfolioService service;

    public PortfolioViewModel(PortfolioService service) {
        this.service = service;
    }
}
```

## 3) Register and Resolve

```java
public class Bootstrap {
    public static void main(String[] args) {
        ApplicationContext context = new ApplicationContext();

        context.registerSingleton(PortfolioDao.class, ctx -> new PortfolioDao());
        context.registerSingleton(PortfolioService.class,
                ctx -> new PortfolioService(ctx.get(PortfolioDao.class)));
        context.registerTransient(PortfolioViewModel.class,
                ctx -> new PortfolioViewModel(ctx.get(PortfolioService.class)));

        PortfolioViewModel vm1 = context.get(PortfolioViewModel.class);
        PortfolioViewModel vm2 = context.get(PortfolioViewModel.class);

        // vm1 and vm2 are different (transient)
        // both share the same PortfolioService and PortfolioDao (singleton)
    }
}
```

## 4) Design Notes

- Keep registration code in one place (startup/composition root).
- Prefer constructor injection for mandatory dependencies.
- Keep the context out of domain logic; business classes should receive dependencies, not call `context.get(...)` everywhere.

This keeps the pattern clean and avoids turning the context into a global service locator.
