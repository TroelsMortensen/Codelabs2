# Comparing and Combining

Black-box and white-box testing solve different but related problems.

## Side-by-side Comparison

| Aspect | Black-box | White-box |
|-------|-----------|-----------|
| Perspective | External behavior | Internal structure |
| Design basis | Requirements/specification | Source code paths/branches |
| Strength | Validates expected behavior | Validates internal path execution |
| Blind spot | Hidden internal path defects | Can over-focus on implementation |
| Maintenance | Usually stable across refactors | More sensitive to internal changes |

## Use Them Together

A practical combination is:

- black-box tests to ensure behavior and rules are correct,
- white-box checks to ensure key branches/conditions are exercised.

Ideally, you want to test observable behaviour, not the implementation details. This, however, requires that you have good documentation of the expected behavior. If this is lacking, you will have to look into the code.

If you do TDD, you can only rely on the specification, as you don't even have code to look at.

## Practical Checklist

- Do we have behavior-focused tests based on requirements?
- Do we exercise important branches/conditions in key logic?
- Are tests too tightly coupled to implementation details?
- If internals change, do our behavior tests still express the same expected outcomes?

Balanced use of black-box and white-box testing usually gives clearer, stronger test suites.
