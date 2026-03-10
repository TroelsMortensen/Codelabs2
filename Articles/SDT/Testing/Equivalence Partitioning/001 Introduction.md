# Equivalence Partitioning: Introduction

Equivalence partitioning (EP) is a test case design technique where you divide the input domain into groups that should behave the same.

The point is to reduce the number of tests you need to write, by grouping inputs that should behave the same.

## What Is Equivalence Partitioning?

An **equivalence partition** (range of input) is a set of inputs expected to produce the same kind of outcome.

Instead of testing every value, you choose one (or a few) representative values from each partition.

## Core Idea

If all values in a partition should behave the same, testing one well-chosen value can represent that partition.

This gives fewer tests while still covering the key behavior.

## Why It Helps

- Reduces test count.
- Keeps tests focused and systematic.
- Makes expected behavior explicit per partition.

## Where It Is Used

- Unit testing
- Input validation tests
- API parameter validation
- Business rule checks

## Scope

EP does not replace all testing. It is commonly combined with other techniques, especially boundary value analysis (BVA).

## What This Learning Path Covers

- In page `2`, how to identify valid and invalid partitions.
- In page `3`, how to choose representative values.
- In page `4`, how to turn partitions into concrete test cases.
