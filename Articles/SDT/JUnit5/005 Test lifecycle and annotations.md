# Test Lifecycle and Core Annotations

JUnit annotations define which methods are tests and which methods run before or after tests.

## Common Annotations

- `@Test`: marks a test method.
- `@BeforeEach`: runs before every test method.
- `@AfterEach`: runs after every test method.
- `@BeforeAll`: runs once before all tests in the class.
- `@AfterAll`: runs once after all tests in the class.

## Basic Example

```java
import org.junit.jupiter.api.*;

import static org.junit.jupiter.api.Assertions.assertEquals;

public class LifecycleExampleTest {

    private int value;

    @BeforeAll
    static void beforeAll() {
        System.out.println("before all");
    }

    @AfterAll
    static void afterAll() {
        System.out.println("after all");
    }

    @BeforeEach
    void setUp() {
        value = 10;
    }

    @AfterEach
    void tearDown() {
        value = 0;
    }

    @Test
    void testAdd() {
        value += 5;
        assertEquals(15, value);
    }

    @Test
    void testSubtract() {
        value -= 3;
        assertEquals(7, value);
    }
}
```

This keeps each test isolated: each test starts from a known state (`value = 10`).
