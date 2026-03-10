# Common Naming Conventions

This page introduces several naming styles for unit tests. Each style can work if applied consistently.

Do note that names are often long, and you may mix various naming styles, like camelCase and using underscores, to more clearly indicate what is being tested and how.

## 1) MethodName_WhenSomething_ExpectedResult

Example:

```java
@Test
void add_whenTwoPositiveNumbers_returnsSum() {
    assertEquals(5, 2 + 3);
}
```

The structures is "unit under test", then the particular test case, and finally the expected result.


## 2) Given_When_Then

Example:

```java
@Test
void givenTwoPositiveNumbers_whenAdd_thenReturnsSum() {
    assertEquals(5, 2 + 3);
}
```

This is a somewhat common approach, but the "unit under test", i.e. the specific method `add()` is somewhat burried in the name. Moving the unit under test up front can be a benefit, unless the entire class focuses on this single same unit.

## 3) Should Style

Example:

```java
@Test
void shouldReturnSumWhenAddingTwoPositiveNumbers() {
    assertEquals(5, 2 + 3);
}
```

## 4) UnitUnderTest_State_Expected (classic)

Example:

```java
@Test
void add_TwoPositiveNumbers_ReturnsSum() {
    assertEquals(5, 2 + 3);
}
```

## 5) Sentence-like Business Behavior Style

Example:

```java
@Test
void returns_total_price_with_tax_for_standard_rate() {
    assertEquals(125, 100 + 25);
}
```

## Mini Comparison

Same behavior, different naming styles:

| Convention | Example |
|------------|---------|
| MethodName_ExpectedResult | `add_whenTwoPositiveNumbers_returnsSum` |
| Given_When_Then | `givenTwoPositiveNumbers_whenAdd_thenReturnsSum` |
| Should style | `shouldReturnSumWhenAddingTwoPositiveNumbers` |
| UnitUnderTest_State_Expected | `add_TwoPositiveNumbers_ReturnsSum` |
| Sentence-like business style | `returns_total_price_with_tax_for_standard_rate` |

The naming pattern changes, but the tested behavior is the same.
