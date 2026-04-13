# More Examples

Here are additional Java scenarios where Adapter is useful.

## Example 1: Payment Provider Integration

Your app expects:

```java
public interface PaymentProcessor {
    void pay(int amountInCents);
}
```

Stripe is a payment provider that offers a SDK. Assume the SDK offers the following method:

```java
public class StripeSdk {
    public void charge(double amountInDollars) {
        System.out.println("Charging $" + amountInDollars);
    }
}
```

Adapter:

```java
public class StripeAdapter implements PaymentProcessor {
    private final StripeSdk stripe;

    public StripeAdapter(StripeSdk stripe) {
        this.stripe = stripe;
    }

    @Override
    public void pay(int amountInCents) {
        stripe.charge(amountInCents / 100.0);
    }
}
```

This hides unit conversion and SDK dependency from business code.


## Example 3: External Weather API Normalization

Your app expects temperature in Celsius:

```java
public interface WeatherProvider {
    double currentTempCelsius(String city);
}
```

External API returns Fahrenheit:

```java
public class ExternalWeatherApi {
    public double getTempFahrenheit(String city) {
        return 77.0;
    }
}
```

Adapter:

```java
public class WeatherApiAdapter implements WeatherProvider {
    private final ExternalWeatherApi api;

    public WeatherApiAdapter(ExternalWeatherApi api) {
        this.api = api;
    }

    @Override
    public double currentTempCelsius(String city) {
        double f = api.getTempFahrenheit(city);
        return (f - 32) * 5 / 9;
    }
}
```

## Example 4: XML Service in a JSON-Oriented App

If your app expects a `JsonCustomerClient`, but a vendor library only supports XML request/response models, an adapter can:
- map JSON domain objects to XML DTOs,
- call the XML context-side adapter target,
- map results back to JSON-oriented domain models.

This keeps XML concerns outside core business layers.

## When Not to Use Adapter

- When you control both sides and can align interfaces directly.
- When the incompatibility is too great, and it is not worth the effort to create an adapter.
- When mapping logic becomes large business logic (then consider a dedicated translator/service layer).

## Key Takeaways

1. Adapter solves interface mismatch without changing stable context code.
2. It centralizes conversion logic and protects the rest of your code from vendor APIs.
3. It works best at integration boundaries: third-party SDKs, legacy systems, and external services.
