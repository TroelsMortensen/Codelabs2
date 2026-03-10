# Identifying Partitions

This page focuses on splitting input values into equivalence partitions.

## Valid and Invalid Partitions

When defining partitions, include both:

- **valid partitions** (inputs that should be accepted)
- **invalid partitions** (inputs that should be rejected)

## Example 1: Numeric Rule

Rule: score must be between `0` and `100`.

Possible partitions:

- Partition A: `score < 0` (invalid)
- Partition B: `0 <= score <= 100` (valid)
- Partition C: `score > 100` (invalid)

## Example 2: Category Rule

Rule: category must be `A`, `B`, or `C`.

Possible partitions:

- Partition A: `{A, B, C}` (valid)
- Partition B: everything else (invalid)

## ASCII Visual (Partition Example)

```text
score input:

< 0                  0...............100                  > 100
|--------------------|=================|--------------------|
  invalid partition    valid partition    invalid partition
```

## Quick Checklist

1. Find the input constraint.
2. Split the input into partitions with the same expected behavior.
3. Ensure partitions are non-overlapping for practical purposes.
4. Include invalid partitions, not only valid ones.
