# Black-box Testing

Black-box testing designs tests from the outside view of the system.

## Viewpoint

The tester focuses on:

- requirements,
- input/output behavior,
- acceptance or rejection rules.

The internal implementation is not the primary basis for test design.

## Strengths

- Good for validating requirements.
- Less tied to implementation details.
- Usually more stable when code is refactored internally.

## Limitations

- Internal branch/path defects may be missed.
- Internal logic coverage is less visible from behavior alone.

## Simple Example: Score Validation

Rule: score must be between `0` and `100`.

A black-box test set can be described as input -> expected result:

```text
Input   Expected
-5      reject
0       accept
50      accept
100     accept
150     reject
```

This test design comes from the rule, not from inspecting source code.

## Connection to Other Techniques

Equivalence Partitioning and Boundary Value Analysis are common black-box test design techniques:

- EP helps select representative values from input classes.
- BVA emphasizes values at and near boundaries.
