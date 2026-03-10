# Designing Test Cases with BVA

This page shows how to apply boundary value analysis while writing test cases.

## Step-by-Step Use

1. Identify inputs with ranges or partitions.
2. Mark each boundary where behavior may change.
3. Pick boundary and near-boundary values.
4. Define expected outcomes (accept/reject, result, or exception).
5. Add these as explicit test cases.

## BVA and Equivalence Partitioning

A common combination is:

- first split input into equivalence classes (valid/invalid or sub-ranges),
- then apply BVA at each class boundary.

This gives better coverage with fewer tests than random value selection.

## Worked Example (One Input)

Rule: score must be in range `[0, 100]`.

Suggested BVA test inputs and expected outcomes:

| Input | Expected |
|------:|----------|
| -1    | reject   |
| 0     | accept   |
| 1     | accept   |
| 99    | accept   |
| 100   | accept   |
| 101   | reject   |

### Optional Minimal Java Example

```java
public static boolean isValidScore(int score) {
    return score >= 0 && score <= 100;
}
```

```java
import static org.junit.jupiter.api.Assertions.*;
import org.junit.jupiter.api.Test;

class ScoreValidatorTest {
    @Test void bvaScoreRange() {
        assertFalse(isValidScore(-1));
        assertTrue(isValidScore(0));
        assertTrue(isValidScore(1));
        assertTrue(isValidScore(99));
        assertTrue(isValidScore(100));
        assertFalse(isValidScore(101));
    }
}
```

## Optional Two-Input Idea

If a method has two ranged inputs, hold one input at a nominal value while boundary-testing the other, then swap.

Example: test boundaries of `A` while `B` is nominal, then boundaries of `B` while `A` is nominal.

## Summary

BVA means testing at and around boundaries. This catches many boundary defects quickly.

Values just outside the valid range should usually assert **rejection**. BVA is strongest when combined with other focused test design techniques.
