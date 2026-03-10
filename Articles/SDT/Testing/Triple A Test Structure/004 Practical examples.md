# Practical Examples

This page gives complete AAA examples with simple logic.

## Example 1: Add Two Numbers

```java
@Test
void shouldReturnSumWhenAddingTwoNumbers() {
    // Arrange (Setup)
    int a = 4;
    int b = 6;

    // Act (Execute)
    int result = a + b;

    // Assert (Verify)
    assertEquals(10, result);
}
```

## Example 2: String Normalization

```java
@Test
void shouldTrimAndLowercaseText() {
    // Arrange (Setup)
    String raw = "  HeLLo  ";

    // Act (Execute)
    String normalized = raw.trim().toLowerCase();

    // Assert (Verify)
    assertEquals("hello", normalized);
}
```

## Example 3: Exception Case

```java
@Test
void shouldThrowWhenDividingByZero() {
    // Arrange (Setup)
    int value = 10;

    // Act + Assert (Execute + Verify)
    assertThrows(ArithmeticException.class, () -> {
        int ignored = value / 0;
    });
}
```

In exception tests, Act and Assert can be combined inside `assertThrows`.

## Final Checklist

- Can I identify Arrange/Act/Assert quickly?
- Is there one primary Act behavior?
- Do my assertions verify the intended behavior?
- Am I avoiding unrelated asserts in this test?
- Is the test readable by someone else in 10 seconds?
