# Most Used Assert Methods

Assertions are checks that decide pass or fail.

Import examples:

```java
import static org.junit.jupiter.api.Assertions.*;
```

## Common Assertions

- `assertEquals(expected, actual)`
- `assertTrue(condition)`
- `assertFalse(condition)`
- `assertNull(value)`
- `assertNotNull(value)`
- `assertAll(...)`
- `assertThrows(...)`

## Basic Examples

```java
@Test
void basicAsserts() {
    assertEquals(4, 2 + 2);
    assertTrue(10 > 3);
    assertFalse(2 > 5);
    assertNull(null);
    assertNotNull("hello");
}
```

Sometimes you may want to group several assertions together. This is where `assertAll` comes in. I generally don't like this all that much, because you should minimize the number of assertions in a test method, and if you have several assertions, you should split them into several test methods.

```java
@Test
void groupedAsserts() {
    int a = 2;
    int b = 3;
    assertAll(
        () -> assertEquals(5, a + b),
        () -> assertTrue(b > a)
    );
}
```

`assertThrows` is useful when an exception is the expected behavior. Here, the first argument is the expected exception _type_, and the second argument is a lambda expression that when executed, throws the exception.

```java	
@Test
void throwAssertExample() {
    assertThrows(IllegalArgumentException.class, () -> {
        throw new IllegalArgumentException("bad input");
    });
}
```


