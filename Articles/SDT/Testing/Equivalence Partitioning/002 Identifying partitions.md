# Identifying Partitions

This page focuses on splitting input values into equivalence classes.

## Valid and Invalid Partitions

When defining partitions, include both:

- **valid classes** (inputs that should be accepted)
- **invalid classes** (inputs that should be rejected)

## Example 1: Numeric Rule

Rule: score must be between `0` and `100`.

Possible partitions:

- Class A: `score < 0` (invalid)
- Class B: `0 <= score <= 100` (valid)
- Class C: `score > 100` (invalid)

## Example 2: Category Rule

Rule: category must be `A`, `B`, or `C`.

Possible partitions:

- Class A: `{A, B, C}` (valid)
- Class B: everything else (invalid)

## ASCII Visual (Range Example)

```text
score input:

< 0            0..............100              > 100
|--------------|================|----------------|
 invalid class      valid class       invalid class
```

## Quick Checklist

1. Find the input constraint.
2. Split the input into classes with the same expected behavior.
3. Ensure classes are non-overlapping for practical purposes.
4. Include invalid classes, not only valid ones.
