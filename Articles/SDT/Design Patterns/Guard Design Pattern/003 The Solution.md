# The Solution

The Guard pattern solves validation noise by moving checks to short, explicit guard clauses at the top of methods.

## Fail Fast

**Fail fast** means:

- validate early
- stop immediately on invalid input/state
- return clear feedback close to the source of the problem

## Guard Clauses

A guard clause is usually a one-liner:

```java
if (email == null) throw new IllegalArgumentException("email must not be null");
```

It protects the rest of the method.

## The Guard class

The Guard class is a utility class that contains methods for validating input.

We will start out simple, but there are many ways to expand on this.


### Before

```java
public void buyStock(String symbol, int amount) {
    if (symbol == null) {
        throw new IllegalArgumentException("symbol is null");
    }
    if (symbol.isBlank()) {
        throw new IllegalArgumentException("symbol is blank");
    }
    if (amount <= 0) {
        throw new IllegalArgumentException("amount must be > 0");
    }

    // business logic...
}
```

### After (with centralized guards)

```java
public void buyStock(String symbol, int amount) {
    Guard.againstBlank(symbol, "symbol");
    Guard.againstNonPositive(amount, "amount");

    // business logic...
}
```