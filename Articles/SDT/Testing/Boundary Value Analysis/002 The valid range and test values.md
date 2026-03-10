# The Valid Range and Test Values

This page focuses on one input variable with a closed valid range: **[min, max]**.

## Example Range

Assume valid values are from **1 to 100** (inclusive).

BVA test values are:

- `min - 1` -> `0`, just outside the lower boundary
- `min` -> `1`, the lower boundary
- `min + 1` -> `2`, just inside the lower boundary
- `max - 1` -> `99`, just inside the upper boundary
- `max` -> `100`, the upper boundary
- `max + 1` -> `101`, just outside the upper boundary


It can be illustrated as a number line:

```text
Valid range [1, 100]

invalid      boundary      inside ... inside      boundary      invalid
   |            |                                   |              |
---+------------+------------+----------- ... ------+--------------+---
   0            1            2                     100            101
```

## Why These Specific Values?

- `1` and `100` test the exact accepted boundaries.
- `2` and `99` test values just inside the boundaries.
- `0` and `101` test values just outside the boundaries.

For `0` and `101`, tests should verify **rejection** (for example false result, error, or exception), not acceptance.

## 4-Value vs 6-Value Variant

Above, we used 6 values, two of which were "just inside", but not "on" the boundary. This is the 6-value variant.

You might cut down to 4 values, by using only the "just outside", and "on" the boundary, at both ends. This is the 4-value variant.

The 6-value boundary set is usually better when you specifically want strong boundary coverage. And, really, creating these tests are fairly quick, so better just be safe.

## Summary

If a method accepts integers from `1` to `100`, BVA suggests at least: `0, 1, 2, 99, 100, 101`.
