# The Valid Range and Test Values

This page focuses on one input variable with a closed valid range: **[min, max]**.

## Example Range

Assume valid values are from **1 to 100** (inclusive).

BVA test values are:

- `min - 1` -> `0`
- `min` -> `1`
- `min + 1` -> `2`
- `max - 1` -> `99`
- `max` -> `100`
- `max + 1` -> `101`

Optionally add one normal middle value (for example `50`).

## ASCII Number Line

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

## 3-Value vs 6-Value Variant

You may see a smaller set (min, middle, max). That is useful for quick checks.

The 6-value boundary set is usually better when you specifically want strong boundary coverage.

## One-Line Example

If a method accepts integers from `1` to `100`, BVA suggests at least: `0, 1, 2, 99, 100, 101`.
