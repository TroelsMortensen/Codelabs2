# Expansion: Check That Against

This expansion introduces two intent-focused entry points:

- `Check.Against` for invalid input (negative constraints)
- `Check.That` for business/state requirements (positive constraints)

## Example

Notice we now have an outer class, called `Check`, which contains two inner classes: `Guard` and `Requirement`. The `Guard` class contains methods for "negative constraints", and the `Requirement` class contains methods for "positive constraints".

Sure, you always "flip" the positive constraints to negative constraints, and put them all into one Guard class. But this way is more explicit, and perhaps easier to read.

```java
public final class Check {
    private Check() {
    }

    public static final Guard Against = new Guard();
    public static final Requirement That = new Requirement();

    public static final class Guard {
        public void nullValue(Object input, String name) {
            if (input == null) throw new IllegalArgumentException(name + " is null");
        }        
        
        // or without 
        public void nullValue(Object input) {
            if (input == null) throw new IllegalArgumentException("Value is null");
        }
    }

    public static final class Requirement {
        public void isLargerThan(int value, int minimum, String name) {
            if (value <= minimum) {
                throw new IllegalStateException(name + " must be larger than " + minimum);
            }
        }
    }
}
```

## When to use

Use this when you want validation calls to communicate intent directly in the method body.

## Usage Example

```java
public void registerUser(User user, int age) {
    Check.Against.nullValue(user, "user");
    Check.That.isLargerThan(age, 17, "age");

    // happy path continues
}
```
