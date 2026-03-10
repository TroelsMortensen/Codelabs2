# Boundary Value Analysis: Introduction

Boundary value analysis (BVA) is a test case design technique. The idea is simple: when an input has limits, many defects appear at or near those limits.

What are limits? Examples:
* A number must be between 0 and 100
* A string must be at least 3 characters long
* A date must be in the future
* A file must be less than 100MB
* A password must be at least 8 characters long
* A username must be at least 3 characters long
* A username must be less than 20 characters long
* A username must not contain any special characters

## What Is BVA?

BVA selects test values at the **edges** of an input domain:

- the smallest allowed value,
- the largest allowed value,
- and values just inside or just outside those limits.

You can use this when designing unit tests, integration tests, or API validation tests.

## Why Boundaries Matter

Boundary defects are very common:

- off-by-one mistakes,
- using `<` when `<=` was intended,
- using `>` when `>=` was intended,
- fence-post errors in loops and indexing, meaning you forgot to test the first or last element of a collection.

Testing only "middle" values often misses these issues.

## Scope of BVA

BVA focuses on boundary-related faults. It is usually combined with other test design approaches (for example equivalence partitioning), not used as a full replacement for all testing.

## What This Learning Path Covers

- In page `2`, how to choose boundary values for a simple valid range.
- In page `3`, how open/half-open ranges and multiple partitions affect BVA values.
- In page `4`, how to apply BVA when writing practical test cases.
