# The Problem

Many methods start with defensive checks. That is good in principle, but it often grows into noisy code.

## Example: Validation Noise

```java
public void registerUser(String email, String password, int age) {
    if (email == null) {
        throw new IllegalArgumentException("email is null");
    }
    if (email.isBlank()) {
        throw new IllegalArgumentException("email is blank");
    }
    if (password == null) {
        throw new IllegalArgumentException("password is null");
    }
    if (password.length() < 8) {
        throw new IllegalArgumentException("password must be at least 8 characters");
    }
    if (age < 13) {
        throw new IllegalArgumentException("age must be at least 13");
    }

    // Actual use-case logic starts here
}
```

The checks are necessary, but there are common problems:

- business logic is pushed down and hard to see
- same checks are duplicated in many classes
- error messages become inconsistent over time
- developers forget to validate in some places

## Why this hurts maintainability

When validation is copied everywhere, updating a rule becomes risky:

1. one class is updated
2. another class still has old logic
3. behavior differs based on where the method is called

This increases bugs and makes code reviews slower.

## Key observation

Validation is often **cross-cutting** at boundaries.  
That makes it a strong candidate for a small, reusable pattern.

