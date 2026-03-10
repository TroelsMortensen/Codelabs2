# Boundary Value Analysis: Introduction

Boundary value analysis (BVA) is a test case design technique. The idea is simple: when an input has limits, many defects appear at or near those limits.

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
- fence-post errors in loops and indexing.

Testing only "middle" values often misses these issues.

## Scope of BVA

BVA focuses on boundary-related faults. It is usually combined with other test design approaches (for example equivalence partitioning), not used as a full replacement for all testing.

## What This Learning Path Covers

- In `002`, how to choose boundary values for a simple valid range.
- In `003`, how open/half-open ranges and multiple partitions affect BVA values.
- In `004`, how to apply BVA when writing practical test cases.
