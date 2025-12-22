# Examples: Law of Demeter in Practice

Real-world examples showing violations and how to fix them.

## Example 1: Order Processing

### Violation: Train Wreck

```java
// Bad: Chain of method calls
public class OrderService {
    public void processOrder(Order order) {
        // Violation: Multiple chains
        String name = order.getCustomer().getName();
        String email = order.getCustomer().getEmail();
        String city = order.getCustomer().getAddress().getCity();
        String country = order.getCustomer().getAddress().getCountry();
        
        // Process with this data
        applyTax(order, country);
        sendEmail(email, name, city);
    }
}
```

**Problems:**
- Depends on `Customer` and `Address` structure
- Breaks if internal structure changes
- Hard to test (must mock entire chain)

### Solution: Delegate Methods

```java
// Good: Order provides what's needed
public class Order {
    private Customer customer;
    
    public String getCustomerName() {
        return customer.getName();
    }
    
    public String getCustomerEmail() {
        return customer.getEmail();
    }
    
    public String getCustomerCity() {
        return customer.getAddress().getCity();
    }
    
    public String getCustomerCountry() {
        return customer.getAddress().getCountry();
    }
}

public class OrderService {
    public void processOrder(Order order) {
        // Single level of calls
        String name = order.getCustomerName();
        String email = order.getCustomerEmail();
        String city = order.getCustomerCity();
        String country = order.getCustomerCountry();
        
        applyTax(order, country);
        sendEmail(email, name, city);
    }
}
```

**Benefits:**
- Only depends on `Order`
- If `Customer` or `Address` changes, only `Order` needs updating
- Easier to test

## Example 2: Email Sending

### Violation: Nested Calls

```java
// Bad: Nested method calls
public class NotificationService {
    public void sendOrderConfirmation(Order order) {
        emailService.send(
            order.getCustomer().getEmail(),  // Chain!
            "Order confirmed",
            "Your order total: " + order.getTotal()
        );
    }
}
```

### Solution: Tell, Don't Ask

```java
// Good: Tell Order to send confirmation
public class Order {
    private Customer customer;
    private EmailService emailService;
    
    public void sendConfirmation() {
        emailService.send(
            customer.getEmail(),
            "Order confirmed",
            "Your order total: " + getTotal()
        );
    }
}

public class NotificationService {
    public void sendOrderConfirmation(Order order) {
        order.sendConfirmation();  // Tell, don't ask
    }
}
```

**Benefits:**
- Behavior stays with the object that has the data
- No chain of calls
- Better encapsulation

## Example 3: Tax Calculation

### Violation: Deep Navigation

```java
// Bad: Deep navigation
public class TaxCalculator {
    public double calculateTax(Order order) {
        String country = order.getCustomer().getAddress().getCountry();
        double rate = getTaxRate(country);
        return order.getTotal() * rate;
    }
}
```

### Solution: DTO or Delegate Method

```java
// Option 1: Delegate method
public class Order {
    public String getCustomerCountry() {
        return customer.getAddress().getCountry();
    }
}

public class TaxCalculator {
    public double calculateTax(Order order) {
        String country = order.getCustomerCountry();  // Single call
        double rate = getTaxRate(country);
        return order.getTotal() * rate;
    }
}

// Option 2: Tell, don't ask (even better)
public class Order {
    private TaxCalculator taxCalculator;
    
    public double calculateTax() {
        String country = customer.getAddress().getCountry();
        double rate = taxCalculator.getTaxRate(country);
        return getTotal() * rate;
    }
}

public class TaxCalculator {
    public double calculateTax(Order order) {
        return order.calculateTax();  // Tell, don't ask
    }
}
```

## Example 4: User Profile Display

### Violation: Multiple Chains

```java
// Bad: Multiple chains
public class ProfileService {
    public void displayUserProfile(User user) {
        String name = user.getProfile().getPersonalInfo().getName();
        String email = user.getProfile().getContactInfo().getEmail();
        String city = user.getProfile().getAddress().getCity();
        
        display(name, email, city);
    }
}
```

### Solution: DTO

```java
// Good: Use a DTO
public class UserProfileDTO {
    private String name;
    private String email;
    private String city;
    
    // Constructor and getters
}

public class User {
    public UserProfileDTO getProfileInfo() {
        Profile profile = this.profile;
        return new UserProfileDTO(
            profile.getPersonalInfo().getName(),
            profile.getContactInfo().getEmail(),
            profile.getAddress().getCity()
        );
    }
}

public class ProfileService {
    public void displayUserProfile(User user) {
        UserProfileDTO profile = user.getProfileInfo();  // Single call
        display(profile.getName(), profile.getEmail(), profile.getCity());
    }
}
```

## Example 5: Shopping Cart

### Violation: Method Chaining

```java
// Bad: Long chain
public class CheckoutService {
    public void checkout(ShoppingCart cart) {
        double total = cart.getItems().stream()
            .mapToDouble(item -> item.getProduct().getPrice() * item.getQuantity())
            .sum();
        
        String customerEmail = cart.getCustomer().getEmail();
        String customerName = cart.getCustomer().getName();
        
        processPayment(total, customerEmail);
        sendReceipt(customerEmail, customerName, total);
    }
}
```

### Solution: Delegate Methods

```java
// Good: Cart provides what's needed
public class ShoppingCart {
    private List<CartItem> items;
    private Customer customer;
    
    public double getTotal() {
        return items.stream()
            .mapToDouble(item -> item.getProduct().getPrice() * item.getQuantity())
            .sum();
    }
    
    public String getCustomerEmail() {
        return customer.getEmail();
    }
    
    public String getCustomerName() {
        return customer.getName();
    }
}

public class CheckoutService {
    public void checkout(ShoppingCart cart) {
        double total = cart.getTotal();  // Single call
        String customerEmail = cart.getCustomerEmail();  // Single call
        String customerName = cart.getCustomerName();  // Single call
        
        processPayment(total, customerEmail);
        sendReceipt(customerEmail, customerName, total);
    }
}
```

## Example 6: Connection to Coupling

The Law of Demeter directly relates to coupling:

### High Coupling (Violation)

```java
// OrderService is coupled to Order, Customer, and Address
public class OrderService {
    public void process(Order order) {
        String city = order.getCustomer().getAddress().getCity();
        // Depends on 3 classes
    }
}
```

### Low Coupling (Following LoD)

```java
// OrderService is only coupled to Order
public class OrderService {
    public void process(Order order) {
        String city = order.getCustomerCity();
        // Depends on 1 class
    }
}
```

## Key Takeaways

From these examples:

1. **Avoid chains** - Don't call methods on returned objects
2. **Delegate methods** - Have objects provide what callers need
3. **Use DTOs** - For complex data needs
4. **Tell, don't ask** - Tell objects to do things
5. **Reduces coupling** - Fewer dependencies
6. **Improves encapsulation** - Internal structure hidden

**The pattern:** Instead of navigating through objects, ask the object you know to provide what you need.

