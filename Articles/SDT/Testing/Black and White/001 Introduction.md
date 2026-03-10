# Black and White Testing: Introduction

Black-box and white-box testing are two common perspectives for designing tests.

## What Is Black-box Testing?

Black-box testing treats the system as a "box" where we only focus on:

- input,
- output,
- expected behavior from the specification.

The internal code structure is not required to design these tests.

## What Is White-box Testing?

White-box testing uses knowledge of internal code structure, for example:

- statements,
- branches,
- conditions,
- paths.

Tests are designed with awareness of how the implementation is written.

## Complementary, Not Competing

These approaches are not enemies. They answer different questions:

- Black-box: "Does behavior match the specification?"
- White-box: "Did we exercise important internal logic paths?"

In practice, strong test suites usually combine both.

## Where They Are Used

- Unit tests
- API and validation tests
- Integration tests

## What This Learning Path Covers

- In `002`, black-box approach with simple examples.
- In `003`, white-box approach with simple branch-oriented examples.
- In `004`, how to compare and combine both approaches.

```text
Black-box:  Input -> [System] -> Output
White-box:  Input -> [Internal paths/branches] -> Output
```
