# Parameterized Tests and Other Annotations

This page introduces two useful annotations beyond the core lifecycle set:

- `@ParameterizedTest`
- `@Disabled`

## Parameterized Tests

A parameterized test runs the same test logic multiple times with different input values, or one test with some kind of loop for all possible inputs (super yikes!). Instead of writing several almost identical `@Test` methods, you write one method and supply a list of inputs; JUnit runs the method once for each row of data.

### Example with `@CsvSource`

You use **`@ParameterizedTest`** instead of `@Test`. The **`@CsvSource`** annotation provides the data: each string is one row of comma-separated values. JUnit turns each row into arguments for the test method. The order of the values in the row must match the order of the method parameters.

In the example below, the three rows `"2, 2, 4"`, `"3, 1, 4"`, and `"10, 5, 15"` produce three test runs: the first run gets `a=2`, `b=2`, `expected=4`; the second gets `a=3`, `b=1`, `expected=4`; and so on. The test checks that `a + b` equals `expected` in each case.

```java
import org.junit.jupiter.params.ParameterizedTest;
import org.junit.jupiter.params.provider.CsvSource;

import static org.junit.jupiter.api.Assertions.assertEquals;

public class ParameterizedSumTest {

    @ParameterizedTest
    @CsvSource({
        "2, 2, 4",
        "3, 1, 4",
        "10, 5, 15"
    })
    void shouldSumNumbers(int a, int b, int expected) {
        assertEquals(expected, a + b);
    }
}
```

### Example with `@ValueSource`

**`@ValueSource`** gives one argument per test run. You use it when the test method has a single parameter. You specify an array of values (e.g. `ints`, `strings`, `longs`). JUnit runs the test once for each value.

In the example below, the test runs four times with `n` equal to 2, 3, 5, and 7, and checks that each is positive.

```java
import org.junit.jupiter.params.ParameterizedTest;
import org.junit.jupiter.params.provider.ValueSource;

import static org.junit.jupiter.api.Assertions.assertTrue;

public class ValueSourceExampleTest {

    @ParameterizedTest
    @ValueSource(ints = {2, 3, 5, 7})
    void eachValueIsPositive(int n) {
        assertTrue(n > 0);
    }
}
```

### Example with `@MethodSource`

**`@MethodSource`** supplies arguments from a static method. You give the method name (or omit it to use a method with the same name as the test plus `Provider`). The method returns a `Stream<Arguments>` (or `Iterable`, etc.); each `Arguments.of(...)` is one set of parameters for the test. This is useful when you need to build data in code or have many rows.

In the example below, `sumProvider()` returns three argument sets; the test runs three times with the corresponding `a`, `b`, and `expected` values.

```java
import org.junit.jupiter.params.ParameterizedTest;
import org.junit.jupiter.params.provider.Arguments;
import org.junit.jupiter.params.provider.MethodSource;

import java.util.stream.Stream;

import static org.junit.jupiter.api.Assertions.assertEquals;

public class MethodSourceSumTest {

    @ParameterizedTest
    @MethodSource("sumProvider")
    void shouldSumNumbers(int a, int b, int expected) {
        assertEquals(expected, a + b);
    }

    static Stream<Arguments> sumProvider() {
        return Stream.of(
            Arguments.of(2, 2, 4),
            Arguments.of(3, 1, 4),
            Arguments.of(10, 5, 15)
        );
    }
}
```

## `@Disabled`

Use **`@Disabled`** when you want to temporarily skip a test so that it is not run. You put it on the test method (or on the class to skip all tests in that class). The optional string (e.g. `"Temporarily disabled while..."`) is the reason; it appears in the test report so you remember why the test was turned off. When you run the class, this test is skipped and does not affect pass or fail.

```java
import org.junit.jupiter.api.Disabled;
import org.junit.jupiter.api.Test;

public class DisabledExampleTest {

    @Test
    @Disabled("Temporarily disabled while example is being updated")
    void thisTestIsSkipped() {
        // not executed
    }
}
```

This is useful during refactoring or when an example is still in progress. Remove `@Disabled` when the test is ready to run again.
