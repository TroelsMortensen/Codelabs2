# Shallow vs Deep References

When one package uses another package, the dependency can be "shallow" or "deep".

## Shallow Reference

A shallow reference targets the package's intended public surface, i.e. a package higher up in the package tree.

Example:

```java
import com.example.customer.api.CustomerFacade;
import com.example.customer.api.CustomerProfileView;
```

This is usually good because callers depend on stable API types.

## Deep Reference

A deep reference reaches into nested internal packages.

Example:

```java
import com.example.customer.internal.profile.preferences.notification.channel.EmailNotificationPreference;
```

This is risky because callers now depend on implementation details.

## Important: Transitive Leakage

Even if package A references package B *shallowly*, leakage still happens if B returns deep internal types.

### Problem Example

Here the `CustomerFacade` package is the public surface of the `Customer` package. But it is a deeply nested internal class.

```java
// package: com.example.customer
public class CustomerFacade {
    public EmailNotificationPreference getCustomerProfile(String customerId) {
        // ...
    }
}
```

Package A only calls `CustomerFacade` (looks shallow), but the returned type is:

```java
com.example.customer.internal.profile.preferences.notification.channel.EmailNotificationPreference
```

So package A is forced to know and depend on B's internals. This is leakage.

## Better Version (No Leakage)

```java
// package: com.example.customer
public class CustomerFacade {
    public CustomerProfileView getCustomerProfile(String customerId) {
        // Map internal entity to surface view
    }
}
```

Now callers depend only on:

```java
com.example.customer.CustomerProfileView
```


## Quick Decision Rule

Before exposing a type from a package method, ask:

1. Is this type part of the package's intentional public surface?
2. Would I be comfortable if many packages depended on this type?
3. Is this type stable enough to be public API?

If the answer is no, do not expose it.

