# The Three Phases

This page explains each phase of Arrange-Act-Assert in detail.

## Arrange

Use this section to prepare everything needed before the action:

- create objects,
- prepare input values,
- configure simple test doubles if needed.

Do not run the behavior under test here. Do not assert here.

## Act

Run the one primary behavior being tested.

- usually one method call,
- one clear action.

Avoid multiple unrelated actions in the same test.

## Assert

Check that the result matches expectations.

You can verify:

- return value,
- object state,
- thrown exception (`assertThrows`).

Keep assertions focused on the intended behavior.

## ASCII Template

```text
// Arrange (Setup)
...

// Act (Execute)
...

// Assert (Verify)
...
```

## Tiny Java/JUnit Example

```java
import org.junit.jupiter.api.Test;
import static org.junit.jupiter.api.Assertions.assertEquals;

class AaaStructureExampleTest {

    @Test
    void shouldReturnSumForTwoNumbers() {
        // Arrange (Setup)
        int a = 2;
        int b = 3;

        // Act (Execute)
        int result = a + b;

        // Assert (Verify)
        assertEquals(5, result);
    }
}
```
