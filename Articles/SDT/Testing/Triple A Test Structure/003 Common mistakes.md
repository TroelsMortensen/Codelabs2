# Common Mistakes

Even when teams know AAA/SEV, tests can drift away from the structure. This page shows common mistakes and quick fixes.

## 1) Arrange After Act

Bad:

```java
int result = calculator.add(2, 3);
int expected = 5;
assertEquals(expected, result);
```

Better:

```java
int expected = 5;                 // Arrange
int result = calculator.add(2, 3); // Act
assertEquals(expected, result);    // Assert
```

## 2) Multiple Acts in One Test

Bad:

```java
int sum = calculator.add(2, 3);
int product = calculator.multiply(2, 3);
assertEquals(5, sum);
assertEquals(6, product);
```

Better: split into two tests, one behavior per test.

## 3) Assertions Mixed Into Arrange

Bad:

```java
int a = 2;
assertTrue(a > 0);
int result = a + 3;
assertEquals(5, result);
```

Better: keep verification in Assert/Verify section.

## 4) No Clear Separation

Bad:

```java
int a = 2; int b = 3; int result = a + b; assertEquals(5, result);
```

Better: use explicit sections and spacing for readability.

## 5) Over-Asserting Unrelated Behavior

Bad:

```java
assertEquals(5, result);
assertNotNull(logger);
assertEquals("v1", buildVersion);
```

Better: assert the behavior this test is about; move unrelated checks to other tests.

## Quick Rule

One test should usually have one clear Act/Execute step and assertions that verify that specific behavior.
