# Package-level Encapsulation

At class level, a class hides fields and exposes methods.

At package level, a package should hide internal structure and expose a small, stable API (the surface, e.g. a package of interfaces) to other packages.

## Public Surface vs Internal Structure

Think of a package as having two zones:

- **Public package surface**: what other packages are allowed to use.
- **Internal package structure**: implementation details that may change.

It is inconvenient if I rework some internal details of the package, and suddenly other packages in other layers break, because they are using the internal details.

## Package Top Level as an Interface

A useful analogy:

- A class interface defines what callers may use.
- A package top-level API defines what other packages may use.

So the top level of a package acts like an interface boundary:

- stable
- intentional
- minimal

This is the package "public access" idea: other packages should depend on exposed package API types, not on nested internal types.


## Using `package-private` (default access)

Java gives you a practical enforcement lever for package encapsulation: access level with **no modifier** (often called *package-private*).

With `package-private`:

- a type or method is accessible from code **in the same package**
- code **outside the package** cannot directly use it (unless it is part of the package's intentional public surface)

This helps you manage the “implementation details zone”:

- keep internal helper types in nested packages
- allow package internals to collaborate freely
- prevent other packages from depending on those internals by accident

Example (conceptually):

```java
// com.example.customer.internal.workflow
class CustomerWorkflowEngine {  // package-private by default
    void execute(...) { /* ... */ }
}
```

## Important Limitation: It Does Not Prevent Return-Type Leakage

`package-private` mainly protects *direct access* (importing/using a type from outside the package).

Leakage can also happen through **types that appear in public method signatures**:

- if a package’s public method returns a deep/internal type, callers become coupled to internals even if they cannot “use it directly” beyond the returned value

So use `package-private` to protect implementation helpers, but still apply the “public surface per package” rule for method parameters and return types.

## Quick Summary

Package-level encapsulation means treating package boundaries like class boundaries: expose only what clients need, keep internals private to the package boundary.

