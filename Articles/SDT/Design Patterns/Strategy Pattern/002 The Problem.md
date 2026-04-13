# The Problem

The Strategy pattern addresses a common design issue: **one class contains many algorithm variants selected through conditionals**.

## The Scenario

Imagine a checkout system where shipping cost can be calculated in different ways:

- Standard shipping
- Express shipping
- Store pickup

A straightforward implementation is to store all logic in one `ShippingCostCalculator` class with a `switch` statement.

## A Poor Solution: Conditional-Heavy Logic

```java
public class ShippingCostCalculator {
    public double calculate(String shippingType, double weightKg, double distanceKm) {
        switch (shippingType) {
            case "STANDARD":
                return 5.0 + (weightKg * 0.8) + (distanceKm * 0.02);
            case "EXPRESS":
                return 12.0 + (weightKg * 1.2) + (distanceKm * 0.05);
            case "PICKUP":
                return 0.0;
            default:
                throw new IllegalArgumentException("Unknown shipping type: " + shippingType);
        }
    }
}
```

This works initially, but it does not scale well.

## Why This Is a Problem

### Tight Coupling of Policies

The calculator class knows all shipping policies directly. Any policy change forces edits in the same class.

### Violates Open/Closed Principle

Adding a new policy (for example overnight shipping) requires modifying `calculate`, instead of simply adding a new implementation.

### Harder Testing

You test one large method with many branches instead of testing small policy classes independently.

### Risky Growth Over Time

As discounts, seasonal rules, and edge cases are added, the method becomes long and fragile.

