# Black and White Testing: Introduction

Black-box and white-box testing are two common perspectives for designing tests.

## What Is Black-box Testing?

Black-box testing treats the system as a "box" where we only focus on:

- input,
- output,
- expected behavior from the specification.

The internal code structure is not required to design these tests.

This let's us focus on the behavior of the system, and not the implementation details. Implementation details are often not relevant to the behavior of the system, and can change without the behavior changing.

## What Is White-box Testing?

White-box testing uses knowledge of internal code structure, for example:

- statements,
- branches,
- conditions,
- loops,
- paths.

Tests are designed with awareness of how the implementation is written.

While this can help you get better coverage of the internal logic, it can also be a hindrance. If the implementation changes, the tests may need to be updated.

## Complementary, Not Competing

These approaches are not enemies. They answer different questions:

- Black-box: "Does behavior match the specification?"
- White-box: "Did we exercise important internal logic paths?"

In practice, strong test suites usually combine both.

You may have a particular complicated method, which is _just_ internal detail, but still it is important enough to test explicitly. 

## Where They Are Used

- Unit tests
- API and validation tests
- Integration tests

## What This Learning Path Covers

- In page `2`, black-box approach with simple examples.
- In page `3`, white-box approach with simple branch-oriented examples.
- In page `4`, how to compare and combine both approaches.

```text
Black-box:  Input -> [System] -> Output
White-box:  Input -> [Internal paths/branches] -> Output
```
