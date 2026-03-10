# Practical Guidelines and Examples

This page gives a practical way to adopt a naming convention and keep it consistent.

## Recommended Process

1. Pick one naming convention for your course/project.
2. Apply it to all new tests.
3. Emphasize observable behavior in names.
4. Avoid naming tests after private/internal implementation details.

## Before/After Rename Examples

```text
test1                -> shouldReturnSumWhenAddingTwoPositiveNumbers
sumTest              -> givenTwoPositiveNumbers_whenAdd_thenReturnsSum
validationTest       -> rejectScoreWhenValueIsAboveMaximum
nullCase             -> shouldThrowWhenInputIsNull
```


## Pre-commit Checklist for Test Names

- Does the name describe behavior, not internals?
- Is expected outcome clear?
- Is naming style consistent with the rest of the test class/project?
- Is the name specific enough to understand a failure quickly?
- Is it concise enough to remain readable?

Consistent naming will make your tests easier to use long after they were written.
