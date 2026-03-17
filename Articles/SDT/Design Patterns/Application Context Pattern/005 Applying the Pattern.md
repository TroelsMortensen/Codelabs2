# Applying the Pattern

Now we apply the Application Context pattern to a JavaFX MVVM scenario.

From page `2`, the problem was scattered wiring in UI classes.  
From page `3`, the pattern gave us one place to create and connect objects.

## Scenario

- `PortfolioController` needs `PortfolioViewModel`.
- `PortfolioViewModel` needs `PortfolioService`.
- `PortfolioService` needs `PortfolioDao`.

The application context builds this chain.

## Domain and ViewModel Classes

```java
public interface PortfolioDao {
    double getCurrentValue();
}

public class SqlPortfolioDao implements PortfolioDao {
    @Override
    public double getCurrentValue() {
        return 125000.0;
    }
}

public class PortfolioService {
    private final PortfolioDao dao;

    public PortfolioService(PortfolioDao dao) {
        this.dao = dao;
    }

    public double loadPortfolioValue() {
        return dao.getCurrentValue();
    }
}

public class PortfolioViewModel {
    private final PortfolioService service;

    public PortfolioViewModel(PortfolioService service) {
        this.service = service;
    }

    public double currentValue() {
        return service.loadPortfolioValue();
    }
}
```

## Configure the Application Context

```java
ApplicationContext context = new ApplicationContext();

context.registerSingleton(PortfolioDao.class, ctx -> new SqlPortfolioDao());
context.registerSingleton(PortfolioService.class,
        ctx -> new PortfolioService(ctx.get(PortfolioDao.class)));
context.registerTransient(PortfolioViewModel.class,
        ctx -> new PortfolioViewModel(ctx.get(PortfolioService.class)));
```

## Controller Gets a Ready ViewModel

```java
public class PortfolioController {
    private final PortfolioViewModel viewModel;

    public PortfolioController(ApplicationContext context) {
        this.viewModel = context.get(PortfolioViewModel.class);
    }
}
```

The controller no longer knows how services or DAOs are created. It only asks for what it needs.

## Small Testing Benefit

For tests, create another context configuration:

- register a fake or in-memory DAO instead of `SqlPortfolioDao`,
- keep the same ViewModel and service classes.

This allows testing behavior without touching production wiring.

## Result

The object graph is now assembled in one place, lifecycle rules are explicit, and UI classes stay focused on UI concerns.
