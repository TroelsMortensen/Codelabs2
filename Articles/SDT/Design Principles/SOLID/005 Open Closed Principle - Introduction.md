# Open Closed Principle - Introduction

The **Open Closed Principle (OCP)** is the second principle in SOLID. It guides how to design software that can be extended without modification.

## Definition

**Software entities (classes, modules, functions) should be open for extension but closed for modification.**

This means:
- **Open for extension** - You should be able to add new functionality
- **Closed for modification** - You shouldn't need to modify existing, working code

## The Core Idea

When you need to add new features, you should **extend/expand** the system rather than **modify** existing code. This keeps existing code stable and reduces the risk of introducing bugs.


## When OCP Applies

OCP is especially important when:
- You expect the system to grow and change
- You want to minimize risk when adding features
- You need to maintain backward compatibility
- You want to enable plugin-like architectures

## Summary

- **Definition:** Open for extension, closed for modification
- **Key idea:** Add functionality by extending, not modifying
- **Benefits:** Stability, extensibility, testability, maintainability
- **Techniques:** Use interfaces, abstraction, polymorphism
- **Question to ask:** "Can I add this feature without changing existing code?"


