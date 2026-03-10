# Ranges and Partitions

Boundary value analysis changes slightly when the specification is not a simple closed range.

## Open, Closed, and Half-Open Ranges

A closed range includes both ends: `[min, max]`.

But specs may use open or half-open intervals.

Example: valid values are `(0, 100]`.

- `0` is invalid (left side is open)
- `1` is the first valid value
- `100` is valid
- `101` is invalid

Useful BVA-style values here: `0, 1, 2, 99, 100, 101`.

This is just a slightly rephrased version of the 6-value variant, on the previous page. The point is just to be vigilant about the boundaries.

## Multiple Partitions

Sometimes one input has several partitions, not just one valid interval.

Example:

- `x < 0` -> invalid
- `0..50` -> low
- `51..100` -> high
- `x > 100` -> invalid

Then apply boundary checks at **each partition border**:

- around 0: `-1, 0, 1`
- around 50/51: `49, 50, 51`
- around 100: `99, 100, 101`

This gives focused test values that target transition points between partitions.

## Quick Rule

Whenever behavior changes at a value, that value and its neighbors are boundary candidates.
