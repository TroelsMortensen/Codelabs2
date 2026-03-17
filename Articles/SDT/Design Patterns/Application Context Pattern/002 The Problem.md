# The Problem

The Application Context pattern addresses a common construction problem:

> Who creates all the objects, and who wires all dependencies together?

In JavaFX MVVM, this question appears quickly when controllers need ViewModels, ViewModels need services, and services need DAOs.

## A Poor Solution: Controller Creates Everything

A common first approach is to construct the full object graph inside each controller.

```java
public class PortfolioController {
    private final PortfolioViewModel viewModel;

    public PortfolioController() {
        PortfolioDao dao = new SqlPortfolioDao("jdbc:postgresql://localhost:5432/trading");
        PortfolioService service = new PortfolioService(dao);
        viewModel = new PortfolioViewModel(service);
    }
}
```

This works for a tiny example, but it scales badly.

## Why This Is a Problem

### 1) Scattered wiring logic

Object creation appears in many places (controllers, helper classes, startup code). It becomes difficult to see the full dependency graph.

### 2) Tight coupling to concrete classes

The controller now depends on `SqlPortfolioDao` and connection details. UI code should not know persistence details.

### 3) Duplication and inconsistency

If multiple controllers need similar services, the same wiring is repeated. Repeated code drifts over time and leads to inconsistent setups.

### 4) Harder testing

You cannot easily substitute a fake DAO or mock service without changing production classes.

### 5) Unclear lifecycle decisions

Should `PortfolioService` be shared? Should each controller get a new ViewModel? Without a central place, lifecycle rules become accidental.

## Consequences in Practice

- More fragile startup code.
- Bigger constructors and more boilerplate.
- UI classes that know too much about infrastructure.
- Higher cost when changing dependencies.

## What We Need Instead

We need one clear place that:

1. knows how to build each object,
2. resolves dependencies automatically when needed,
3. controls lifecycle decisions consistently.

This is exactly what the **Application Context** pattern provides.
