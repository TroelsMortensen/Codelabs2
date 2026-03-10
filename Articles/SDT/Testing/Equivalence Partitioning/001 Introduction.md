# Equivalence Partitioning: Introduction

Equivalence partitioning (EP) is a test case design technique where you divide the input domain into groups that should behave the same.

## What Is Equivalence Partitioning?

An **equivalence class** (partition) is a set of inputs expected to produce the same kind of outcome.

Instead of testing every value, you choose one representative value from each class.

## Core Idea

If all values in a class should behave the same, testing one well-chosen value can represent that class.

This gives fewer tests while still covering the key behavior.

## Why It Helps

- Reduces test count.
- Keeps tests focused and systematic.
- Makes expected behavior explicit per class.

## Where It Is Used

- Unit testing
- Input validation tests
- API parameter validation
- Business rule checks

## Scope

EP does not replace all testing. It is commonly combined with other techniques, especially boundary value analysis (BVA).

## What This Learning Path Covers

- In `002`, how to identify valid and invalid partitions.
- In `003`, how to choose representative values.
- In `004`, how to turn partitions into concrete test cases.
