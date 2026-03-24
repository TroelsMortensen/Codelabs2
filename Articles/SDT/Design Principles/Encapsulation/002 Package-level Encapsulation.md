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


## Quick Summary

Package-level encapsulation means treating package boundaries like class boundaries: expose only what clients need, keep internals private to the package boundary.

