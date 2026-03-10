# White-box Testing

White-box testing designs tests using knowledge of the code internals.

## Viewpoint

The tester looks at implementation structure and asks:

- Which statements were executed?
- Which branches were executed?
- Which conditions were evaluated true/false?

## Simple Structural Targets

At intro level, common targets are:

- **Statement coverage**: execute each statement at least once.
- **Branch coverage**: execute each branch (e.g. true and false of an `if`).
- **Condition checks**: ensure key conditions are evaluated both ways when relevant.

## Strengths

- Finds path-specific and logic defects.
- Reveals untested branches and dead spots.

## Limitations

- More coupled to implementation details.
- Tests may need updates when internal structure changes.

## Tiny Example

```java
public static String classify(int n) {
    if (n < 0) {
        return "negative";
    } else {
        return "non-negative";
    }
}
```

To cover both branches:

- test with `n = -1` (true branch)
- test with `n = 0` (false branch)

ASCII control-flow view:

```text
          [n < 0 ?]
           /     \
        true     false
        /          \
  "negative"   "non-negative"
```
