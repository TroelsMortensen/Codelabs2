# Designing Test Cases with EP

This page shows how to use equivalence partitioning to design concrete test cases.

## Step-by-Step

1. List the input condition(s).
2. Define valid and invalid partitions.
3. Pick one representative per partition.
4. Write expected outcome for each representative.
5. Add one test case per representative (minimum EP set).

## Worked Example

Rule: score must be in `[0, 100]`.

EP representatives:

- `-5` -> reject
- `50` -> accept
- `150` -> reject

### Minimal Test Case Table

| Input | Expected |
|------:|----------|
| -5    | reject   |
| 50    | accept   |
| 150   | reject   |

### Optional Minimal Java/JUnit Snippet

```java
public static boolean isValidScore(int score) {
    return score >= 0 && score <= 100;
}
```

```java
import org.junit.jupiter.api.Test;
import static org.junit.jupiter.api.Assertions.*;

class ScoreValidatorEpTest {
    @Test
    void epScoreValidation() {
        assertFalse(isValidScore(-5));
        assertTrue(isValidScore(50));
        assertFalse(isValidScore(150));
    }
}
```

## Optional Two-Input Note

If there are two inputs, begin with one representative per partition for each input.

To avoid too many combinations, start with a simple set and extend only when needed.

## Summary

EP gives compact, structured tests by covering behavior classes instead of individual values.

It is very effective for input validation and pairs naturally with BVA for boundary-focused coverage.
