# Common Naming Conventions

This page introduces several naming styles for unit tests. Each style can work if applied consistently.

## 1) MethodName_ExpectedResult

Example:

```java
@Test
void add_whenTwoPositiveNumbers_returnsSum() {
    assertEquals(5, 2 + 3);
}
```

## 2) Given_When_Then

Example:

```java
@Test
void givenTwoPositiveNumbers_whenAdd_thenReturnsSum() {
    assertEquals(5, 2 + 3);
}
```

## 3) Should Style

Example:

```java
@Test
void shouldReturnSumWhenAddingTwoPositiveNumbers() {
    assertEquals(5, 2 + 3);
}
```

## 4) UnitOfWork_State_ExpectedBehavior (classic)

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

## ASCII Mini Comparison

Same behavior, different naming styles:

```text
MethodName_ExpectedResult:      add_whenTwoPositiveNumbers_returnsSum
Given_When_Then:                givenTwoPositiveNumbers_whenAdd_thenReturnsSum
Should style:                   shouldReturnSumWhenAddingTwoPositiveNumbers
UnitOfWork_State_Expected:      add_TwoPositiveNumbers_ReturnsSum
Sentence-like business style:   returns_total_price_with_tax_for_standard_rate
```

The naming pattern changes, but the tested behavior is the same.
