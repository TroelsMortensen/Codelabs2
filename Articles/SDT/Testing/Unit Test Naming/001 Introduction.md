# Unit Test Naming: Introduction

Unit test names are part of your documentation. When a test fails, the name should quickly tell you what behavior is broken.

## Why Test Naming Matters

Good test names make it easier to:

- understand failures quickly,
- maintain tests over time,
- communicate intent to teammates (which includes future you).

A name like `test1` gives almost no information. A name like `shouldReturnSum_WhenAddingTwoPositiveNumbers` immediately tells the expected behavior.

## Behavior Over Implementation

Prefer names that describe **observable behavior**, not private implementation details.

For example, "returns rejected status for negative input" is stronger than "calls validateInternalFlag".

## Scope

There is no single perfect naming convention for all teams. The key is to choose a convention that is readable for your context and use it consistently across the project.

## What This Learning Path Covers

- In page `2`, common naming conventions with examples.
- In page `3`, pros and cons of each style.
- In page `4`, practical rules for choosing one style and applying it consistently.
